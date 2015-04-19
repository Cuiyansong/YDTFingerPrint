using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YDT.WinForm.Common;

namespace YDT.WinForm.Model
{
    public class Document : IDocument, IDisposable
    {
        #region Private Property
        private DoubleHand hands;
        private DocSetting setting;
        private IReportTemplate template;
        #endregion

        #region Public Property

        #endregion

        #region Constructure
        /// <summary>
        /// Constructure
        /// </summary>
        public Document()
        {
            hands = new DoubleHand();
            setting = new DocSetting();
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
        ~Document()
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
                if (Hands != null)
                {
                    Hands.Dispose();
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

        #region Public Method
        /// <summary>
        /// Draw graphic items
        /// </summary>
        /// <param name="g"></param>
        public void DrawItems(System.Drawing.Graphics g)
        {
            if (template != null)
            { 
                template.Draw(g, this);
            }
        }
        #endregion

        #region Private Method

        #endregion

        #region Interface of IDocument
        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>
        /// The template.
        /// </value>
        public IReportTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        /// <summary>
        /// Setting
        /// </summary>
        public DocSetting Setting
        {
            get
            {
                return setting;
            }
            set
            {
                setting = value;
            }
        }
        /// <summary>
        /// Gets or sets the hands.
        /// </summary>
        /// <value>
        /// The hands.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
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
        #endregion
    }
}
