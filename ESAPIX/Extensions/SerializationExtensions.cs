#region

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

#endregion

namespace ESAPIX.Extensions
{
    public static class SerializationExtensions
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null)
                return string.Empty;
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
    }
}