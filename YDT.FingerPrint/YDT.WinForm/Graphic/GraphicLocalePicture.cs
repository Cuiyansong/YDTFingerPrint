using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Graphic
{
    /// <summary>
    /// GraphicLocalePicture
    /// </summary>
    [Serializable]
    public class GraphicLocalePicture : GraphicBase, IDisposable
    {
        #region Private Property
        private Bitmap image; 
        #endregion

        #region Public Property
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }
        #endregion

        #region Constructor

        #endregion

        #region Public Method
        public override void Draw(System.Drawing.Graphics g, System.Drawing.RectangleF rectF)
        {
            if (Image != null) 
            {
                g.DrawImage(this.Image, rectF);
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectF.X,rectF.Y,rectF.Width,rectF.Height);
            }
        }
        #endregion

        #region Private Method

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
        ~GraphicLocalePicture()
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
