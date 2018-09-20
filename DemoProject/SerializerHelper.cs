using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DemoProject
{
    internal class SerializerHelper
    {
        public static void SerializeXml(FruitsBasket fb, string fileName)
        {
            //XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(fb.GetType());
                serializer.Serialize(fileStream, fb);
                //xmlFormat.Serialize(fileStream, fruits);
            }
        }

        internal static string ObjectToXml<T>(T obj)
        {
            var resultXML = String.Empty;
            XmlSerializer serializer = null;
            try
            {
                serializer = new XmlSerializer(typeof(T));
                using (var stringWriter = new StringWriter())
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
