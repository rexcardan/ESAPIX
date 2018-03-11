namespace ESAPIX.AppKit.Data
{
    /// <summary>
    ///     Holds an underlying object and a hash to that object to make sure it hasn't been tampered with in the json file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SecureStorage<T>
    {
        /// <summary>
        ///     The storage object
        /// </summary>
        public T Storage { get; set; }

        /// <summary>
        ///     The hash for the storage object
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        ///     A boolean indicating whether or not the file has been tampered with
        /// </summary>
        public bool IsTampered { get; set; }
    }
}