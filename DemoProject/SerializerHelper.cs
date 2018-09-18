using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DemoProject
{
    internal class SerializerHelper
    {
        internal static string ObjectToXml<T>(T obj)
        {
            string resultXML = String.Empty;
            XmlSerializer serializer = null;
            try
            {
                serializer = new XmlSerializer(typeof(T));
                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "  ",
                        NewLineChars = "\r\n",
                        NewLineHandling = NewLineHandling.Replace
                    };
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, obj);
                        resultXML = stringWriter.ToString(); // Your XML
                        xmlWriter.Close();
                    }
                    stringWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Or however you get it to display
            }

            return resultXML;
        }

        internal static T XmlToObject<T>(string xml) where T : new()
        {
            if (xml == String.Empty)
            {
                return new T();
            }

            T resultObject = default(T);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(xml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(stringReader))
                    {
                        resultObject = (T)serializer.Deserialize(xmlReader);
                        xmlReader.Close();
                    }
                    stringReader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Or however you get it to display
            }
            return resultObject;
        }
    }
}
