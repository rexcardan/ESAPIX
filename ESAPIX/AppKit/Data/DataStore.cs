using ESAPIX.Helpers;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ESAPIX.AppKit.Data
{
    /// <summary>
    /// A storage helper which stores a specific type of object in a folder as json files. Also includes integrity checks 
    /// to ensure the files have not been tampered with. User LoadSecure for that functionality
    /// </summary>
    /// <typeparam name="T">the type of objects to be stored</typeparam>
    public class DataStore<T> where T: ISecureStorable
    {
        string _dbPath = string.Empty;
        private string _fileExtension;
        private Func<T, string> _fileNameingMethod;
        private JsonSerializerSettings _settings;

        public DataStore(string fileExtension, Func<T, string> fileNamingMethod, string storePath = "")
        {
            _fileExtension = fileExtension;
            _fileNameingMethod = fileNamingMethod;

            if (string.IsNullOrEmpty(storePath))
            {
                var basePath = StorageHelper.GetBasePath();
                storePath = Path.Combine(basePath, $"{typeof(T).Name}s");
            }
            InitializeDatabase(storePath);

            _settings = new JsonSerializerSettings()
            {  
                Binder = new StorageBinder<T>(),
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            };
        }

        public string DataPath { get { return _dbPath; } }

        /// <summary>
        /// Creates a new json database if one does not exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool InitializeDatabase(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                _dbPath = path;
                return true;
            }
            catch (Exception e) { return false; }

        }

        /// <summary>
        /// Saves a protocol in the protocol directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public bool Save(T storageObject)
        {
            var json = JsonConvert.SerializeObject(storageObject);
            var hashWrapper = new SecureStorage<T>() { Storage = storageObject, Hash = GetHashString(json) };

            json = JsonConvert.SerializeObject(hashWrapper, Formatting.Indented, _settings);
            var savePath = GetSavePath(storageObject);
            File.WriteAllText(savePath, json);
            return true;
        }

        /// <summary>
        /// Loads all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public IEnumerable<T> LoadAll()
        {
            foreach (var f in Directory.GetFiles(_dbPath).Where(f => Path.GetExtension(f) == _fileExtension))
            {
                var read = ReadSecure(f);
                if (read != null) { yield return read.Storage; }
            }
        }

        /// <summary>
        /// Loads all secure storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public List<SecureStorage<T>> LoadAllSecure()
        {
            List<SecureStorage<T>> list = new List<SecureStorage<T>>();

            var fileCount = Directory.GetFiles(_dbPath).ToArray();
            var withExt = fileCount.Where(f => Path.GetExtension(f) == _fileExtension);

            foreach (var f in withExt)
            {
                var read = ReadSecure(f);
                if (read != null) { list.Add(read); }
                else { break; }
            }
            return list;
        }

        /// <summary>
        /// Deletes all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public bool DeleteAll()
        {
            foreach (var f in Directory.GetFiles(_dbPath).Where(f => Path.GetExtension(f) == _fileExtension))
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public void Delete(T toDelete)
        {
            var savePath = GetSavePath(toDelete);
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }

        /// <summary>
        /// Reads an object from a file and determines if it has been tampered with since initial save
        /// </summary>
        /// <param name="path">the path where the object is stored</param>
        /// <returns></returns>
        private SecureStorage<T> ReadSecure(string path)
        {
            var json = "";
            try
            {
                if (File.Exists(path))
                {
                    json = File.ReadAllText(path);
                    var hashWrapper = JsonConvert.DeserializeObject<SecureStorage<T>>(json, _settings);
                    hashWrapper.IsTampered = !CheckIntegrity(hashWrapper);
                    return hashWrapper;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \n {e.InnerException} \n {json}");
                return null;
            }
        }

        /// <summary>
        /// Returns the file path of the json document describing the storage object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSavePath(T objectToSave)
        {
            var filePath = FileHelper.RemoveIllegalCharacters($"{_fileNameingMethod(objectToSave)}{_fileExtension}");
            var savePath = Path.Combine(_dbPath, filePath);
            return savePath;
        }

        /// <summary>
        /// Checks to see whether the  storage object has been modified
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns>return true if has NOT been tampered with</returns>
        private bool CheckIntegrity(SecureStorage<T> hashWrapper)
        {
            var origHash = hashWrapper.Hash;
            hashWrapper.Hash = string.Empty;

            var json = JsonConvert.SerializeObject(hashWrapper.Storage);
            var testedHash = GetHashString(json);
            return origHash == testedHash;
        }


        /// <summary>
        /// Creates a hash of the current storage object. Will know if it has been tampered with
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// Creates a hash of the current  storage object. Will know if it has been tampered with
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
