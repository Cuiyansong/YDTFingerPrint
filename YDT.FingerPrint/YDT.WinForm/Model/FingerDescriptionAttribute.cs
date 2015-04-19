using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YDT.WinForm.Common
{
    /// <summary>
    /// FingerDescriptionAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class FingerDescriptionAttribute : Attribute
    {
        public object Key { get; private set; }

        public object Value { get; private set; }


        public FingerDescriptionAttribute(object key, object value)
        {
            Key = key;
            Value = value;
        }
    } 
}
