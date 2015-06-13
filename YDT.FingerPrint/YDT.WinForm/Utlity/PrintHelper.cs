using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Utlity
{
    public class PrintHelper
    {
        private const float div = 25.4f;
        private static float dpiX = 0;
        private static float dpiY = 0;

        public static float DpiX
        {
            get
            {
                if (dpiX == 0)
                {
                    Graphics gfx = Graphics.FromHwnd(IntPtr.Zero);
                    dpiX = gfx.DpiX;
                }
                return dpiX;
            }
        }

        public static float DpiY
        {
            get
            {
                if (dpiY == 0)
                {
                    Graphics gfx = Graphics.FromHwnd(IntPtr.Zero);
                    dpiY = gfx.DpiY;
                }
                return dpiY;
            }
        }

        #region MillimetreToPixel

        public static float MillimetreToPixel(float millimetre)
        {
            return (int)Math.Round((DpiX * (1 / div)) * millimetre, 0);
        }

        public static PointF MillimetreToPixel(PointF pointF)
        {
            return new PointF()
            {
                X = MillimetreToPixel(pointF.X),
                Y = MillimetreToPixel(pointF.Y),
            };
        }

        public static RectangleF MillimetreToPixel(RectangleF rectF)
        {
            return  new RectangleF()
            {
                X = MillimetreToPixel(rectF.X),
                Y = MillimetreToPixel(rectF.Y),
                Width = MillimetreToPixel(rectF.Width),
                Height = MillimetreToPixel(rectF.Height),
            }; 
        }

        public static SizeF MillimetreToPixel(SizeF sizeF)
        {
            return new SizeF()
            {
                Width = (int)MillimetreToPixel(sizeF.Width),
                Height = (int)MillimetreToPixel(sizeF.Height),
            };
        }

        #endregion

        #region PixelToMillimetre

        public static float PixelToMillimetre(float pixel)
        {
            return (int)Math.Round((1 / DpiX) * div * pixel, 0);
        }

        public static RectangleF PixelToMillimetre(RectangleF rectF)
        {
            return new RectangleF()
            {
                X = PixelToMillimetre(rectF.X),
                Y = PixelToMillimetre(rectF.Y),
                Width = PixelToMillimetre(rectF.Width),
                Height = PixelToMillimetre(rectF.Height),
            };
        }

        public static PointF PixelToMillimetre(PointF pointF)
        {
            return new PointF()
            {
                X = PixelToMillimetre(pointF.X),
                Y = PixelToMillimetre(pointF.Y),
            };
        }

        public static SizeF PixelToMillimetre(SizeF sizeF)
        {
            return new SizeF()
            {
                Width = (int)PixelToMillimetre(sizeF.Width),
                Height = (int)PixelToMillimetre(sizeF.Height),
            };
        }
        #endregion





    }

    public static class RectangleExtension
    {
        public static RectangleF[] ToArray(this RectangleF rect)
        {
            var array = new RectangleF[1];
            array[0] = rect;
            return array;
        }
    }
}
