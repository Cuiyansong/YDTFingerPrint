using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YDT.WinForm.Common;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.Model
{
    /// <summary>
    /// ReportTemplate
    /// </summary>
    [XmlRootAttribute("ReportTemplate", Namespace = "YDT.ReportTemplate", IsNullable = false)]
    [ReportDescription(RangeAttachData.Text, "通用报告模板1")]
    public class ReportTemplate : IReportTemplate, IDisposable
    {
        #region Graphic Resource
        private Pen LinePen = new Pen(Color.Gray, 2);

        private Font normalFont = new Font("宋体", 12, FontStyle.Regular);

        private Font titleFont = new Font("黑体", 28, FontStyle.Bold);

        private Font gridFont = new Font("宋体", 16, FontStyle.Regular);

        private Brush normalBrush = new SolidBrush(Color.Black);
        #endregion

        #region Private Property

        private static int paperWidth = GlobalSetting.DefaultPrintPageSizeMM.Width; 

        private static int paperHeight = GlobalSetting.DefaultPrintPageSizeMM.Height; 

        private RectangleF headerRect = new RectangleF(0, 0, paperWidth, 15);

        private RectangleF titleRect = new RectangleF(0, 15, paperWidth, 47);

        private RectangleF gridRect = new RectangleF(0, 62, paperWidth, 60);

        private RectangleF fingerRect = new RectangleF(0, 122, paperWidth, 160);

        private RectangleF footerRect = new RectangleF(0, 282, paperWidth, 15);

        #endregion

        #region Public Property

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ReportTemplate()
        {

        }
        #endregion

        #region Public Method
        /// <summary>
        /// Draw Entry
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        public void Draw(System.Drawing.Graphics g, IDocument doc)
        {
            DrawReportBorder(g, doc);
            DrawPageHeader(g, doc);
            DrawTitle(g, doc);
            DrawGridInfo(g, doc);
            DrawHandImages(g, doc);
            DrawPageFooter(g, doc);
        }

        #endregion

        #region Drawing Method
        /// <summary>
        /// DrawReportBorder
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawReportBorder(Graphics g, IDocument doc)
        {
            g.DrawRectangle(LinePen, PrintHelper.MillimetreToPixel(new RectangleF(0, 0, paperWidth, paperHeight)));
            // Draw background
            g.FillRectangle(new SolidBrush(Color.White), PrintHelper.MillimetreToPixel(new RectangleF(0, 0, paperWidth, paperHeight)));
        }
        /// <summary>
        /// DrawTitle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawTitle(Graphics g, IDocument doc)
        {
            var drawRect = titleRect;
            if (doc != null && doc.Setting != null)
            {
                var titleContent = doc.Setting.ReportTitle;
                StringFormat strFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                };
                GenerateRectangleString(g, titleContent, titleFont, normalBrush, strFormat, drawRect, false);

                g.DrawRectangle(LinePen, PrintHelper.MillimetreToPixel(drawRect));
            }
        }
        /// <summary>
        /// DrawHandImages
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawHandImages(Graphics g, IDocument doc)
        {
            if (doc != null && doc.Hands != null)
            {
                var drawRect = fingerRect;
                var fingerSize = new Size(36, 65);
                var fingerXSpace = (int)(drawRect.Width - fingerSize.Width * 5) / 6;
                var fingerYSpace = (int)(drawRect.Height - fingerSize.Height * 2) / 3;

                for (int i = 0; i < 10; i++)
                {
                    g.DrawRectangle(LinePen, PrintHelper.MillimetreToPixel(new Rectangle((int)drawRect.X + fingerXSpace + i % 5 * fingerXSpace + i % 5 * fingerSize.Width, (int)drawRect.Y + fingerYSpace + i / 5 * fingerYSpace + i / 5 * fingerSize.Height, fingerSize.Width, fingerSize.Height)));

                    FingerPrint finger = doc.Hands.GetFinger(i);

                    // draw image
                    if (finger != null && finger.Image != null)
                    {
                        g.DrawImage(finger.Image, PrintHelper.MillimetreToPixel(new Rectangle((int)drawRect.X + fingerXSpace + i % 5 * fingerXSpace + i % 5 * fingerSize.Width, (int)drawRect.Y + fingerYSpace + i / 5 * fingerYSpace + i / 5 * fingerSize.Height, fingerSize.Width, fingerSize.Height - 10)));
                    }

                    // draw finger info
                    if (finger != null)
                    {
                        var fingerStr = string.Format("{0}.{1}", i + 1, finger.Finger.GetText());
                        StringFormat strFormat = new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center,
                        };
                        GenerateRectangleString(g, fingerStr, normalFont, normalBrush, strFormat, new Rectangle((int)drawRect.X + fingerXSpace + i % 5 * fingerXSpace + i % 5 * fingerSize.Width, (int)drawRect.Y + fingerYSpace + i / 5 * fingerYSpace + i / 5 * fingerSize.Height + fingerSize.Height - 10, fingerSize.Width, 10), false);
                    }
                }
            }
        }
        /// <summary>
        /// DrawGridInfo
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawGridInfo(Graphics g, IDocument doc)
        {
            var drawRect = gridRect;

            var gridMarginX = 0;
            var gridMarginY = 0;
            var gridRaws = 3;
            var gridColums = 3;
            RectangleF[,] gridRects = new RectangleF[gridRaws, gridColums];
            var gridCellWidth = (int)((drawRect.Width - gridMarginX * 2) / (float)gridRaws);
            var gridCellHeight = (int)((drawRect.Height - gridMarginY * 2) / (float)gridColums);

            // create grid cells
            for (int i = 0; i < gridRaws; i++)
            {
                for (int j = 0; j < gridColums; j++)
                {
                    gridRects[i, j] = new RectangleF(gridMarginX + drawRect.X + j % gridColums * gridCellWidth, gridMarginY + drawRect.Y + i % gridRaws * gridCellHeight, gridCellWidth, gridCellHeight);
                }
            }

            // draw grid infomation
            if (doc != null && doc.Setting != null)
            {
                StringFormat strFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, };
                GenerateRectangleString(g, string.Format("申请人: {0}", doc.Setting.CurCustomer.Name), gridFont, normalBrush, strFormat, gridRects[0, 0], true);
                GenerateRectangleString(g, string.Format("性别: {0}", doc.Setting.CurCustomer.Sex), gridFont, normalBrush, strFormat, gridRects[0, 1], true);
                GenerateRectangleString(g, string.Format("出生日期: {0}", doc.Setting.CurCustomer.Birthday), gridFont, normalBrush, strFormat, gridRects[0, 2], true);
                GenerateRectangleString(g, string.Format("国籍: {0}", doc.Setting.CurCustomer.Nationality), gridFont, normalBrush, strFormat, gridRects[1, 0], true);
                GenerateRectangleString(g, string.Format("身份证(护照)号码: {0}", doc.Setting.CurCustomer.IDCard), gridFont, normalBrush, strFormat, RectangleF.Union(gridRects[1, 1], gridRects[1, 2]), true);
                GenerateRectangleString(g, string.Format("时间: {0}", doc.Setting.CurCustomer.Time), gridFont, normalBrush, strFormat, gridRects[2, 0], true);
                GenerateRectangleString(g, string.Format("地点: {0}", doc.Setting.CurCustomer.Address), gridFont, normalBrush, strFormat, RectangleF.Union(gridRects[2, 1], gridRects[2, 2]), true);
            }
        }
        /// <summary>
        /// DrawPageFooter
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawPageFooter(Graphics g, IDocument doc)
        {
            var drawRect = footerRect;

            g.DrawLine(LinePen, PrintHelper.MillimetreToPixel(new Point(10, (int)drawRect.Top)), PrintHelper.MillimetreToPixel(new Point((int)drawRect.Width - 10, (int)drawRect.Top)));

            if (doc != null && doc.Setting != null)
            {
                var footerContent = doc.Setting.ReportFooter;
                StringFormat strFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                };
                GenerateRectangleString(g, footerContent, normalFont, normalBrush, strFormat, drawRect, false);
            }
        }
        /// <summary>
        /// DrawPageHeader
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawPageHeader(Graphics g, IDocument doc)
        {
            var drawRect = headerRect;

            //g.DrawLine(LinePen, PrintHelper.MillimetreToPixel(new Point(10, (int)drawRect.Top)), PrintHelper.MillimetreToPixel(new Point((int)drawRect.Width - 10, (int)drawRect.Top)));

            if (doc != null && doc.Setting != null)
            {
                var headerContent = doc.Setting.ReportHeader;
                StringFormat strFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                };
                GenerateRectangleString(g, headerContent, normalFont, normalBrush, strFormat, drawRect, false);
            }
        }
        /// <summary>
        /// GenerateRectangleString
        /// </summary>
        /// <param name="g"></param>
        /// <param name="content"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="format"></param>
        /// <param name="rectF"></param>
        private void GenerateRectangleString(Graphics g, string content, Font font, Brush brush, StringFormat format, RectangleF rectF, bool isShowRect)
        {
            // SizeF contentSize = PrintHelper.PixelToMillimetre(g.MeasureString(content, font));
            if (isShowRect)
                g.DrawRectangle(LinePen, PrintHelper.MillimetreToPixel(rectF));
            g.DrawString(content, font, brush, PrintHelper.MillimetreToPixel(rectF), format);
        }

        #endregion

        #region Implement of IDisopose
        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 不是必要的，提供一个Close方法仅仅是为了更符合其他语言（如C++）的规范
        /// </summary>
        public void Close()
        {
            Dispose();
        }
        /// <summary>
        /// 必须，以备程序员忘记了显式调用Dispose方法
        /// </summary>
        ~ReportTemplate()
        {
            //必须为false
            Dispose(false);
        }
        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (LinePen != null)
                {
                    LinePen.Dispose();
                    LinePen = null;
                }
                if (normalFont != null)
                {
                    normalFont.Dispose();
                    normalFont = null;
                }
                if (titleFont != null)
                {
                    titleFont.Dispose();
                    titleFont = null;
                }
                if (gridFont != null)
                {
                    gridFont.Dispose();
                    gridFont = null;
                }
                if (normalBrush != null)
                {
                    normalBrush.Dispose();
                    normalBrush = null;
                }
            }
            // 清理非托管资源
            //if (nativeResource != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(nativeResource);
            //    nativeResource = IntPtr.Zero;
            //} 
            disposed = true;
        }
        #endregion
    }
}
