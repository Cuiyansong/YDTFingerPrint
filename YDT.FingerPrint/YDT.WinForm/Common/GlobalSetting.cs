using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    class GlobalSetting
    {
        /// <summary>
        /// The default en coding: UTF-8 Without BOM
        /// </summary>
        internal static Encoding DefaultEnCoding = new UTF8Encoding(false);
        /// <summary>
        /// The default print page size millimeter
        /// </summary>
        internal static System.Drawing.Size DefaultPrintPageSizeMM = new System.Drawing.Size(210, 297);
    }
}
