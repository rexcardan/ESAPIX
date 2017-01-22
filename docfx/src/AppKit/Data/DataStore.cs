using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.AppKit.Data
{
    /// <summary>
    /// A storage helper which stores a specific type of object in a folder as json files. Also includes integrity checks 
    /// to ensure the files have not been tampered with. User LoadSecure for that functionality
    /// </summary>
    /// <typeparam name="T">the type of objects to be stored</typeparam>
    public class DataStore<T>
    {
        string _dbPath = string.Empty;
        private readonly string DEFAULT_EXT = ".json";

        public DataStore(string storePath = "")
        {
            if (string.IsNullOrEmpty(storePath))
            {
                var basePath = StorageHelper.GetBasePath();
                storePath = Path.Combine(basePath, $"{default(T).GetType().Name}s");
            }
            InitializeDatabase(storePath);
        }

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
        public bool Save(string name, T storageObject)
        {
            var json = JsonConvert.SerializeObject(storageObject);
            var hashWrapper = new SecureStorage<T>() { Storage = storageObject, Hash = GetHashString(json) };

            json = JsonConvert.SerializeObject(hashWrapper, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });
            var savePath = GetSavePath(name);
            File.WriteAllText(savePath, json);
            return true;
        }


        /// <summary>
        /// Loads all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public IEnumerable<T> LoadAll()
        {
            foreach (var f in Directory.GetFiles(_dbPath).Where(f => Path.GetExtension(f) == DEFAULT_EXT))
            {
                yield return ReadSecure(f).Storage;
            }
        }

        /// <summary>
        /// Loads all secure storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public IEnumerable<SecureStorage<T>> LoadAllSecure()
        {
            foreach (var f in Directory.GetFiles(_dbPath).Where(f => Path.GetExtension(f) == DEFAULT_EXT))
            {
                yield return ReadSecure(f);
            }
        }

        /// <summary>
        /// Deletes all storage objects in the directory
        /// </summary>
        /// <returns>bool indicating success</returns>
        public bool DeleteAll()
        {
            foreach (var f in Directory.GetFiles(_dbPath).Where(f => Path.GetExtension(f) == DEFAULT_EXT))
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

        /// <summary>
        /// Loads a secure storage object by name
        /// </summary>
        /// <param name="name">the name of the object (the key)</param>
        /// <returns>the secure storage object</returns>
        public SecureStorage<T> LoadSecure(string name)
        {
            var path = GetSavePath(name);
            return ReadSecure(path);
        }

        /// <summary>
        /// Loads a storage object by name
        /// </summary>
        /// <param name="name">the name of the object (the key)</param>
        /// <returns>the storage object</returns>
        public T Load(string name)
        {
            var secure = LoadSecure(name);
            return secure.Storage;
        }

        private SecureStorage<T> ReadSecure(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    var hashWrapper = JsonConvert.DeserializeObject<SecureStorage<T>>(File.ReadAllText(path), new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    });
                    hashWrapper.IsTampered = !CheckIntegrity(hashWrapper);
                    return hashWrapper;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the file path of the json document describing the storage object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSavePath(string name)
        {
            var protPath = Path.Combine(_dbPath, $"{name}{DEFAULT_EXT}");
            return protPath;
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
