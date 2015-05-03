using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.Model
{
    /// <summary>
    /// DocSetting
    /// </summary>
    [Serializable]
    [XmlRootAttribute("DocSetting", IsNullable = false)]
    public class DocSetting : ICloneable
    {
        [XmlElementAttribute("ReportTitle")]
        public string ReportTitle { get; set; }

        [XmlElementAttribute("ReportHeader")]
        public string ReportHeader { get; set; }

        [XmlElementAttribute("ReportFooter")]
        public string ReportFooter { get; set; }

        [XmlElementAttribute("ReportNamePrefix")]
        public string ReportNamePrefix { get; set; }

        //// [XmlElementAttribute("CurCustomer", IsNullable = false)]
        //[XmlIgnoreAttribute]
        //public Customer CurCustomer { get; set; }

        public DocSetting()
        {
           // CurCustomer = new Customer();
        }

        #region Public Method
        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Seek(0, 0);
                object value = bf.Deserialize(ms);
                return value;
            }
        }
        #endregion

        #region Static Method
        private static DocSetting docSetting;

        private static string xMLSettingFullPath = "";
        /// <summary>
        /// XMLSettingFullPath
        /// </summary>
        public static string XMLSettingFullPath
        {
            get { return DocSetting.xMLSettingFullPath; }
            set { DocSetting.xMLSettingFullPath = value; }
        }
        /// <summary>
        /// Instance
        /// </summary>
        public static DocSetting Instance
        {
            get
            {
                if (docSetting == null)
                {
                    docSetting = new DocSetting();
                }
                return docSetting;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        public static void Save()
        {
            CheckFile();
            XMLHelper.SaveXmlFile<DocSetting>(docSetting, xMLSettingFullPath);
        }
        /// <summary>
        /// Load
        /// </summary>
        public static void Load()
        {
            CheckFile();
            docSetting = XMLHelper.LoadXmlFile<DocSetting>(xMLSettingFullPath);
        }
        /// <summary>
        /// CheckFile
        /// </summary>
        private static void CheckFile()
        {
            var exists = System.IO.File.Exists(xMLSettingFullPath);
            if (!exists)
                throw new ArgumentException("配置文件不存在", xMLSettingFullPath);
        }
        #endregion
    }

    /// <summary>
    /// Customer
    /// </summary>
    [Serializable]
    [XmlRootAttribute("Customer", IsNullable = false)]
    public class Customer : ICloneable
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IDCard")]
        public string IDCard { get; set; }

        [XmlAttribute("Age")]
        public string Age { get; set; }

        [XmlAttribute("Birthday")]
        public string Birthday { get; set; }

        [XmlAttribute("Sex")]
        public string Sex { get; set; }

        [XmlAttribute("Address")]
        public string Address { get; set; }

        [XmlAttribute("Time")]
        public string Time { get; set; }

        [XmlAttribute("Nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Seek(0, 0);
                object value = bf.Deserialize(ms);
                return value;
            }
        }
    }
}
