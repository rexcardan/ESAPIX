#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using ESAPIX.Helpers;
using ESAPIX.Helpers.IO;

#endregion

namespace ESAPIX.AppKit.Data
{
    /// <summary>
    ///     This class helps store objects as files with string content (json, xml)
    /// </summary>
    public abstract class AbstractStringDataStore<T>
    {
        private readonly string _fileExtension;
        private readonly Func<T, string> _fileNameingMethod;

        public AbstractStringDataStore(string fileExtension, Func<T, string> fileNamingMethod, string storePath = "")
        {
            _fileExtension = fileExtension;
            _fileNameingMethod = fileNamingMethod;

            if (string.IsNullOrEmpty(storePath))
            {
                var basePath = StorageHelper.GetBasePath();
                storePath = Path.Combine(basePath, $"{typeof(T).Name}s");
            }
            InitializeDatabase(storePath);
        }

        public string DataPath { get; private set; } = string.Empty;

        /// <summary>
        ///     Serialize the object to push to storage
        /// </summary>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public abstract string Serialize(T toSerialize);

        /// <summary>
        ///     Serialize the object to push to storage
        /// </summary>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public abstract string Serialize(SecureStorage<T> toSerialize);

        /// <summary>
        ///     Deserialize the object to a secure storage object
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        public abstract SecureStorage<T> Deserialize(string serial);

        /// <summary>
        ///     Creates a new json database if one does not exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool InitializeDatabase(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                DataPath = path;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        ///     Saves a protocol in the protocol directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public bool Save(T storageObject)
        {
            var serial = Serialize(storageObject);
            var hashWrapper = new SecureStorage<T> {Storage = storageObject, Hash = GetHashString(serial)};

            serial = Serialize(hashWrapper);
            var savePath = GetSavePath(storageObject);
            File.WriteAllText(savePath, serial);
            return true;
        }

        /// <summary>
        ///     Loads all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public IEnumerable<T> LoadAll()
        {
            foreach (var f in Directory.GetFiles(DataPath).Where(f => Path.GetExtension(f) == _fileExtension))
            {
                var read = ReadSecure(f);
                if (read != null) yield return read.Storage;
            }
        }

        /// <summary>
        ///     Loads all secure storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public List<SecureStorage<T>> LoadAllSecure()
        {
            var list = new List<SecureStorage<T>>();

            var fileCount = Directory.GetFiles(DataPath).ToArray();
            var withExt = fileCount.Where(f => Path.GetExtension(f) == _fileExtension);

            foreach (var f in withExt)
            {
                var read = ReadSecure(f);
                if (read != null) list.Add(read);
                else break;
            }
            return list;
        }

        /// <summary>
        ///     Deletes all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public bool DeleteAll()
        {
            foreach (var f in Directory.GetFiles(DataPath).Where(f => Path.GetExtension(f) == _fileExtension))
                try
                {
                    File.Delete(f);
                }
                catch (Exception e)
                {
                    return false;
                }
            return true;
        }

        public void Delete(T toDelete)
        {
            var savePath = GetSavePath(toDelete);
            if (File.Exists(savePath))
                File.Delete(savePath);
        }

        /// <summary>
        ///     Reads an object from a file and determines if it has been tampered with since initial save
        /// </summary>
        /// <param name="path">the path where the object is stored</param>
        /// <returns></returns>
        private SecureStorage<T> ReadSecure(string path)
        {
            var serial = "";
            try
            {
                if (File.Exists(path))
                {
                    serial = File.ReadAllText(path);
                    var hashWrapper = Deserialize(serial);
                    hashWrapper.IsTampered = !CheckIntegrity(hashWrapper);
                    return hashWrapper;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \n {e.InnerException} \n {serial}");
                return null;
            }
        }


        /// <summary>
        ///     Returns the file path of the json document describing the storage object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSavePath(T objectToSave)
        {
            var filePath = FileHelper.RemoveIllegalCharacters($"{_fileNameingMethod(objectToSave)}{_fileExtension}");
            var savePath = Path.Combine(DataPath, filePath);
            return savePath;
        }

        /// <summary>
        ///     Checks to see whether the  storage object has been modified
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns>return true if has NOT been tampered with</returns>
        private bool CheckIntegrity(SecureStorage<T> hashWrapper)
        {
            var origHash = hashWrapper.Hash;
            hashWrapper.Hash = string.Empty;

            var serial = Serialize(hashWrapper.Storage);
            var testedHash = GetHashString(serial);
            return origHash == testedHash;
        }


        /// <summary>
        ///     Creates a hash of the current storage object. Will know if it has been tampered with
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create(); //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        ///     Creates a hash of the current  storage object. Will know if it has been tampered with
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}