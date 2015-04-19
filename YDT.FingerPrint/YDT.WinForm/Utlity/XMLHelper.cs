using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using YDT.WinForm.Common;

namespace YDT.WinForm.Utlity
{
    public class XMLHelper
    {
        /// <summary>
        /// LoadXmlFile
        /// </summary>
        /// <typeparam name="T">Any Type</typeparam>
        /// <param name="fileName">File Name</param>
        /// <returns>Object</returns>
        public static T LoadXmlFile<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            XmlSerializer formatter = new XmlSerializer(typeof(T));
            T obj;
            using (FileStream fs = File.OpenRead(fileName))
            {
                obj = formatter.Deserialize(fs) as T;
            }
            formatter = null;
            return obj;
        }

        /// <summary>
        ///  Use XML serialization to save document object
        /// </summary>
        /// <typeparam name="T">Any Type</typeparam>
        /// <param name="obj">Document</param>
        /// <param name="fileName">File Name</param>
        public static void SaveXmlFile<T>(T obj, string fileName) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = File.Open(fileName, FileMode.Create))
            {
                XmlTextWriter writer = new XmlTextWriter(fs, GlobalSetting.DefaultEnCoding);
                formatter.Serialize(writer, obj);
                writer.Close();
            }
            formatter = null;
        }
    }
}
