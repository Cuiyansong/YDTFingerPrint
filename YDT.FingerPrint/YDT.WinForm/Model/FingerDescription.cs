using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    public class FingerDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
         

        public FingerDescriptionAttribute(string description) 
        {
            Description = description;
        }
    }
}
