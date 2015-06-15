using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.Graphic
{
    public abstract class GraphicBase
    {
        /// <summary>
        /// The center format equal to 
        /// "Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center"
        /// </summary>
        protected StringFormat CenterFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, };

        /// <summary>
        /// The left format equal to
        /// "Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center"
        /// </summary>
        protected StringFormat LeftFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, };

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectF">The rect f.</param>
        public abstract void Draw(Graphics g, RectangleF rectF);

        /// <summary>
        /// GenerateRectangleString
        /// </summary>
        /// <param name="g"></param>
        /// <param name="content"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="format"></param>
        /// <param name="rectF"></param>
        protected void GenerateRectangleString(Graphics g, Pen pen, string content, Font font, Brush brush, StringFormat format, RectangleF rectF, bool isShowRect)
        {
            g.DrawString(content, font, brush, PrintHelper.MillimetreToPixel(rectF), format);
            if (isShowRect)
                g.DrawRectangles(pen, PrintHelper.MillimetreToPixel(rectF).ToArray());
        }

        /// <summary>
        /// Generates the rectangle image.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="image">The image.</param>
        /// <param name="rectF">The rect f.</param>
        /// <param name="isShowRect">if set to <c>true</c> [is show rect].</param>
        protected void GenerateRectangleImage(Graphics g, Pen pen, Bitmap image, RectangleF rectF, bool isShowRect)
        {
            if (image != null)
                g.DrawImage(image, PrintHelper.MillimetreToPixel(rectF));

            image.Save(@"C:\abc.bmp");
            
            if (isShowRect)
                g.DrawRectangles(pen, PrintHelper.MillimetreToPixel(rectF).ToArray());

            // Water mark
            g.DrawString("水印", new Font("宋体", 10, FontStyle.Regular), new SolidBrush(Color.Black), PrintHelper.MillimetreToPixel(rectF));
        }

        /// <summary>
        /// Generates the grid line.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        protected void GenerateGridLine(Graphics g, Pen pen, PointF startPoint, PointF endPoint)
        {
            g.DrawLine(pen, PrintHelper.MillimetreToPixel(startPoint), PrintHelper.MillimetreToPixel(endPoint));
        }
    }
}
