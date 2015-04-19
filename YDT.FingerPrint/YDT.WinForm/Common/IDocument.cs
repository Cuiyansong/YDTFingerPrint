using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YDT.WinForm.Model;

namespace YDT.WinForm.Common
{
    public interface IDocument : IDisposable
    {
        IReportTemplate Template { get; set; }

        DocSetting Setting { get; set; }

        DoubleHand Hands { get; set; }

        void DrawItems(System.Drawing.Graphics g);
    }
}
