using System.Xml.Serialization;

namespace financial_pyramid.Helpers
{
    public static class DeserializationHelper
    {
        public static T DeserializeFromFileXML<T>(string pathToFile)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new FileStream(pathToFile, FileMode.Open))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
