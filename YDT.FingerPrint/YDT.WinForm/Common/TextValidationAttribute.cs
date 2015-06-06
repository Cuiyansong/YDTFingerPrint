using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TextValidationAttribute : Attribute
    {
       public object Key { get; private set; }

        public object Value { get; private set; }

        public TextValidationAttribute(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
