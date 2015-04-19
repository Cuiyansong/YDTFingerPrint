using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    public interface IReportTemplate
    {  
        void Draw(System.Drawing.Graphics g, IDocument doc); 
    }
}
