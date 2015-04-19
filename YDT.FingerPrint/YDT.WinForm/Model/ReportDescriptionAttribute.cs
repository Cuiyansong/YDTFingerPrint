using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Model
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ReportDescriptionAttribute : Attribute
    {
        public object Key { get; private set; }

        public object Value { get; private set; }

        public ReportDescriptionAttribute(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
