using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YDT.WinForm.Common;
using YDT.WinForm.Graphic;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.Model
{
    /// <summary>
    /// ReportTemplate
    /// </summary>
    [XmlRootAttribute("ReportTemplate", Namespace = "YDT.ReportTemplate", IsNullable = false)]
    [ReportDescription(RangeAttachData.Text, "通用报告模板1")]
    public class ReportTemplate : GraphicBase, IReportTemplate, IDisposable
    {
        #region Graphic Resource
        private Pen LinePen = new Pen(Color.Gray, 2);
        private Font normalFont = new Font("宋体", 12, FontStyle.Regular);
        private Font gutterFont = new Font("黑体", 8, FontStyle.Regular);
        private Font titleFont = new Font("黑体", 25, FontStyle.Bold);
        private Font gridFont = new Font("宋体", 16, FontStyle.Regular);
        private Brush normalBrush = new SolidBrush(Color.Black);
        private Brush gutterBrush = new SolidBrush(Color.Gray);
        #endregion

        #region Private Property
        /// <summary>
        /// The paper left margin
        /// </summary>
        private static int leftMargin = 32;
        /// <summary>
        /// The paper width
        /// </summary>
        private static int paperWidth = GlobalSetting.DefaultPrintPageSizeMM.Width;
        /// <summary>
        /// The paper height
        /// </summary>
        private static int paperHeight = GlobalSetting.DefaultPrintPageSizeMM.Height;
        /// <summary>
        /// The header rect
        /// </summary>
        private RectangleF gutterRect = new RectangleF(0, 0, leftMargin, paperHeight);
        /// <summary>
        /// The header rect
        /// </summary>
        private RectangleF headerRect = new RectangleF(leftMargin, 0, paperWidth - leftMargin, 15);
        /// <summary>
        /// The title rect
        /// </summary>
        private RectangleF titleRect = new RectangleF(leftMargin, 15, paperWidth - leftMargin, 30);
        /// <summary>
        /// The grid rect
        /// </summary>
        private RectangleF gridRect = new RectangleF(leftMargin, 45, paperWidth - leftMargin, 55);
        /// <summary>
        /// The finger rect
        /// </summary>
        private RectangleF fingerRect = new RectangleF(leftMargin, 100, paperWidth - leftMargin, 90);
        /// <summary>
        /// The finger rect
        /// </summary>
        private RectangleF locPicRect = new RectangleF(leftMargin, 190, paperWidth - leftMargin, 80);
        /// <summary>
        /// The footer rect
        /// </summary>
        private RectangleF footerRect = new RectangleF(leftMargin, 270, paperWidth - leftMargin, 27);
        /// <summary>
        /// The hands
        /// </summary>
        private DoubleHand hands = new DoubleHand();
        /// <summary>
        /// The graphic ID card grid or image
        /// </summary>
        private GraphicIDGrid graphicIDGrid = new GraphicIDGrid();
        /// <summary>
        /// The locale picture
        /// </summary>
        private GraphicLocalePicture graphicLocPic = new GraphicLocalePicture();
        #endregion

        #region Public Property
        /// <summary>
        /// Gets or sets the hands.
        /// </summary>
        /// <value>
        /// The hands.
        /// </value>
        public DoubleHand Hands
        {
            get
            {
                return hands;
            }
            set
            {
                hands = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public GraphicIDGrid GraphicIDGrid
        {
            get { return graphicIDGrid; }
            set { graphicIDGrid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public GraphicLocalePicture GraphicLocPic
        {
            get { return graphicLocPic; }
            set { graphicLocPic = value; }
        }
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
        public void Draw(System.Drawing.Graphics g)
        {
            DrawGutter(g);
            // DrawReportBorder(g);
            DrawPageHeader(g);
            DrawTitle(g);
            DrawGridInfo(g);
            DrawHands(g);
            DrawLocPic(g);
            DrawPageFooter(g);
        }

        #endregion

        #region Drawing Method
        /// <summary>
        /// DrawGutter
        /// </summary>
        /// <param name="g"></param>
        private void DrawGutter(Graphics g)
        {
            StringFormat strFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionVertical,
            };
            base.GenerateRectangleString(g, LinePen, "···········装···········订···········线···········", gutterFont, gutterBrush, strFormat, gutterRect, false);
        }
        /// <summary>
        /// DrawReportBorder
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawReportBorder(Graphics g)
        {
            g.DrawRectangles(LinePen, PrintHelper.MillimetreToPixel(new RectangleF(0, 0, paperWidth, paperHeight)).ToArray());
            // Draw background
            g.FillRectangle(new SolidBrush(Color.White), PrintHelper.MillimetreToPixel(new RectangleF(0, 0, paperWidth, paperHeight)));
        }
        /// <summary>
        /// DrawPageHeader
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawPageHeader(Graphics g)
        {
            var drawRect = headerRect;

            //g.DrawLine(LinePen, PrintHelper.MillimetreToPixel(new Point(10, (int)drawRect.Top)), PrintHelper.MillimetreToPixel(new Point((int)drawRect.Width - 10, (int)drawRect.Top)));

            StringFormat strFormat = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
            };
            base.GenerateRectangleString(g, LinePen, DocSetting.Instance.ReportHeader, normalFont, normalBrush, strFormat, drawRect, false);

        }
        /// <summary>
        /// DrawTitle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawTitle(Graphics g)
        {
            var drawRect = titleRect;
            StringFormat strFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            base.GenerateRectangleString(g, LinePen, DocSetting.Instance.ReportTitle, titleFont, normalBrush, strFormat, drawRect, false);
        }
        /// <summary>
        /// DrawHandImages
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawHands(Graphics g)
        {
            if (this.hands != null)
            {
                this.hands.Draw(g, fingerRect);
            }
        }
        /// <summary>
        /// DrawLocalePicture
        /// </summary>
        /// <param name="g"></param>
        private void DrawLocPic(Graphics g)
        {
            if (this.graphicLocPic != null)
            {
                this.graphicLocPic.Draw(g, locPicRect);
            }
        }
        /// <summary>
        /// DrawGridInfo
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawGridInfo(Graphics g)
        {
            if (this.graphicIDGrid != null)
            {
                this.graphicIDGrid.Draw(g, gridRect);
            } 
        }
        /// <summary>
        /// DrawPageFooter
        /// </summary>
        /// <param name="g"></param>
        /// <param name="doc"></param>
        private void DrawPageFooter(Graphics g)
        {
            var drawRect = footerRect;

            g.DrawLine(LinePen, PrintHelper.MillimetreToPixel(new PointF(footerRect.Left, footerRect.Top)), PrintHelper.MillimetreToPixel(new PointF(footerRect.Right, footerRect.Top)));

            StringFormat strFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            base.GenerateRectangleString(g, LinePen, DocSetting.Instance.ReportFooter, normalFont, normalBrush, strFormat, drawRect, false);
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

        public override void Draw(Graphics g, RectangleF rectF)
        {
            throw new NotImplementedException();
        }
    }
}
