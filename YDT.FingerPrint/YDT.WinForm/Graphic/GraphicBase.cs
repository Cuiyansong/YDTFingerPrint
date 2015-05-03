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
            // SizeF contentSize = PrintHelper.PixelToMillimetre(g.MeasureString(content, font));
            if (isShowRect)
                g.DrawRectangle(pen, PrintHelper.MillimetreToPixel(rectF));
            g.DrawString(content, font, brush, PrintHelper.MillimetreToPixel(rectF), format);
        }
    }
}
