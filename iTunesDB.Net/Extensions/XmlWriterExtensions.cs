using System.Xml;

namespace iTunesDB.Net.Extensions
{
    public static class XmlWriterExtensions
    {
        public static void WriteNode(this XmlWriter xmlWriter, string nodeName, string value)
        {
            xmlWriter.WriteStartElement(nodeName);
            xmlWriter.WriteValue(value);
            xmlWriter.WriteEndElement();
        }

        public static void WriteNodeWithAttribute(this XmlWriter xmlWriter, string nodeName, string nodeValue,
            string attributeName, string attributeValue)
        {
            xmlWriter.WriteStartElement(nodeName);
            xmlWriter.WriteAttributeString(attributeName, attributeValue);
            xmlWriter.WriteValue(nodeValue);
            xmlWriter.WriteEndElement();
        }
    }
}
