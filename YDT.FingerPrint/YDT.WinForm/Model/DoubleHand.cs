using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YDT.WinForm.Common;
using YDT.WinForm.Graphic;

namespace YDT.WinForm.Model
{
    public class DoubleHand : IDisposable
    {
        /// <summary>
        /// The fingers
        /// </summary>
        private SortedDictionary<Finger, GraphicFinger> fingers;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleHand"/> class.
        /// </summary>
        public DoubleHand()
        {
            fingers = new SortedDictionary<Finger, GraphicFinger>();
            fingers.Add(Finger.LeftThumb, null);
            fingers.Add(Finger.LeftForeFinger, null);
            fingers.Add(Finger.LeftMiddleFinger, null);
            fingers.Add(Finger.LeftRingFinger, null);
            fingers.Add(Finger.LeftLittleFinger, null);
            fingers.Add(Finger.RightThumb, null);
            fingers.Add(Finger.RightForeFinger, null);
            fingers.Add(Finger.RightMiddleFinger, null);
            fingers.Add(Finger.RightRingFinger, null);
            fingers.Add(Finger.RightLittleFinger, null);
        }

        /// <summary>
        /// Adds the finger.
        /// </summary>
        /// <param name="fprint">The fprint.</param>
        public void AddFinger(GraphicFinger fprint)
        {
            //var fingerprint = fingers[fprint.Finger];
            //if (fingerprint != null)
            //    fingerprint.Dispose();
            fingers[fprint.Finger] = fprint;
        }

        /// <summary>
        /// Gets the finger.
        /// </summary>
        /// <param name="ftype">The ftype.</param>
        /// <returns></returns>
        public GraphicFinger GetFinger(Finger ftype)
        {
            return fingers[ftype];
        }

        /// <summary>
        /// Gets the finger.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public GraphicFinger GetFinger(int index)
        {
            return fingers.First(x => x.Key.Equals((Finger)index)).Value;
        }

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectF">The rect f.</param>
        public void Draw(Graphics g, RectangleF rectF)
        {
            if (fingers != null && fingers.Count > 0)
            {
                int index = 0;
                foreach (KeyValuePair<Finger, GraphicFinger> item in fingers)
                {
                    if (item.Value != null)
                    {
                        float cellWidth = rectF.Width / 5;
                        float cellHeight = rectF.Height / 2;
                        item.Value.Draw(g, new RectangleF(rectF.X + index % 5 * cellWidth, rectF.Y + index / 5 * cellHeight, cellWidth, cellHeight));
                        index++;
                    }
                }
            }
        }

        /// <summary>
        /// Fingers the attribut value.
        /// </summary>
        /// <param name="ftype">The ftype.</param>
        /// <returns></returns>
        [Obsolete("Replace with Finger.GetTest().")]
        public string FingerAttributValue(Finger ftype)
        {
            return ftype.GetText();
        }

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
        ~DoubleHand()
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
                if (fingers != null && fingers.Count > 0)
                {
                    foreach (var item in fingers)
                    {
                        if (item.Value != null)
                            item.Value.Dispose();
                    }
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
