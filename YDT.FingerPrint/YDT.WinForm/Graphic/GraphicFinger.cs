using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YDT.WinForm.Common;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.Graphic
{
    /// <summary>
    /// Fingerprint
    /// </summary>
    [Serializable]
    public class GraphicFinger : GraphicBase, IDisposable
    {
        #region Private Property
        private Size fSize = new Size(15, 20);
        private int fMsgHeight = 10;
        private Pen borderPen = new Pen(Color.Gray, 2);
        private Pen normalPen = new Pen(Color.Black, 1);
        private Font normalFont = new Font("宋体", 12, FontStyle.Regular);
        private Font remarkFont = new Font("宋体", 8, FontStyle.Regular);
        private Brush normalBrush = new SolidBrush(Color.Black);
        #endregion

        #region Public Property
        /// <summary>
        /// Gets or sets the identify.
        /// </summary>
        /// <value>
        /// The identify.
        /// </value>
        public string Identify { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Bitmap Image { get; set; }
        /// <summary>
        /// Gets or sets the finger.
        /// </summary>
        /// <value>
        /// The finger.
        /// </value>
        public Finger Finger { get; set; }
        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        /// <value>
        /// The remark.
        /// </value>
        public string Remark { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicFinger"/> class.
        /// </summary>
        public GraphicFinger()
        {
#if DEBUG
            Remark = "Debug Mode: 无指纹图片";
#endif
        }
        #endregion

        #region Standard Disopose Pattern
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
        ~GraphicFinger()
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
                if (Image != null)
                {
                    Image.Dispose();
                    Image = null;
                }
                if (borderPen != null)
                {
                    borderPen.Dispose();
                    borderPen = null;
                }
                if (normalPen != null)
                {
                    normalPen.Dispose();
                    normalPen = null;
                }
                if (normalFont != null)
                {
                    normalFont.Dispose();
                    normalFont = null;
                }
                if (remarkFont != null)
                {
                    remarkFont.Dispose();
                    remarkFont = null;
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

        #region Implement of IGraphic
        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectF">The rect f.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Draw(Graphics g, RectangleF rectF)
        {
            // Draw border
            g.DrawRectangle(borderPen, PrintHelper.MillimetreToPixel(new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height)));

            // Draw image
            if (this.Image != null)
            {
                Rectangle imageRect = new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)(rectF.Height - fMsgHeight));
                var width = imageRect.Width > fSize.Width ? fSize.Width : imageRect.Width;
                var height = imageRect.Height > fSize.Height ? fSize.Height : imageRect.Height;

                g.DrawImage(this.Image, PrintHelper.MillimetreToPixel(new Rectangle(imageRect.X + (imageRect.Width - width) / 2, imageRect.Y + (imageRect.Height - height) / 2, width, height)));
            }
            else // Draw Remark
            {
                var remarkRect = new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)(rectF.Height - fMsgHeight));
                base.GenerateRectangleString(g, normalPen, this.Remark, remarkFont, normalBrush, base.CenterFormat, remarkRect, false);
            }

            // Draw fing info
            var infoRect = new Rectangle((int)rectF.X, (int)(rectF.Y + rectF.Height - fMsgHeight), (int)rectF.Width, fMsgHeight);
            var fingerStr = string.Format("{0}.{1}", (int)this.Finger, this.Finger.GetText());
            base.GenerateRectangleString(g, normalPen, fingerStr, normalFont, normalBrush, base.CenterFormat, infoRect, false);
        }
        #endregion
    }
}
