using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YDT.WinForm.Common;

namespace YDT.WinForm.Graphic
{
    /// <summary>
    /// GraphicGrid
    /// </summary>
    [Serializable]
    public class GraphicIDGrid : GraphicBase, IDisposable
    {
        #region Private Property
        private Pen gridPen = new Pen(Color.Black, 2);
        private Font gridFont = new Font("宋体", 10, FontStyle.Regular);
        private Brush normalBrush = new SolidBrush(Color.Black);
        private Bitmap image;
        #endregion

        #region Public Property
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Bitmap ApplicantPic
        {
            get { return image; }
            set { image = value; }
        }
        /// <summary>
        /// Gets or sets the name of the applicant.
        /// </summary>
        /// <value>
        /// The name of the applicant.
        /// </value>
        [TextValidation("申请人：", "")]
        public string ApplicantName { get; set; }
        /// <summary>
        /// Gets or sets the applicant identifier.
        /// </summary>
        /// <value>
        /// The applicant identifier.
        /// </value>
        [TextValidation("身份证(护照)：", "")]
        public string ApplicantID { get; set; }
        /// <summary>
        /// Gets or sets the applicant age.
        /// </summary>
        /// <value>
        /// The applicant age.
        /// </value>
        [TextValidation("年龄：", "")]
        public string ApplicantAge { get; set; }
        /// <summary>
        /// Gets or sets the applicant birth.
        /// </summary>
        /// <value>
        /// The applicant birth.
        /// </value>
        [TextValidation("出生日期：", "")]
        public string ApplicantBirth { get; set; }
        /// <summary>
        /// Gets or sets the applicant sex.
        /// </summary>
        /// <value>
        /// The applicant sex.
        /// </value>
        [TextValidation("性别：", "")]
        public string ApplicantSex { get; set; }
        /// <summary>
        /// Gets or sets the applicant addr.
        /// </summary>
        /// <value>
        /// The applicant addr.
        /// </value>
        [TextValidation("地点：", "")]
        public string ApplicantAddr { get; set; }
        /// <summary>
        /// Gets or sets the applicant time.
        /// </summary>
        /// <value>
        /// The applicant time.
        /// </value>
        [TextValidation("时间：", "")]
        public string ApplicantTime { get; set; }
        /// <summary>
        /// Gets or sets the applicant nationality.
        /// </summary>
        /// <value>
        /// The applicant nationality.
        /// </value>
        [TextValidation("国籍：", "")]
        public string ApplicantCountry { get; set; }
        /// <summary>
        /// Gets or sets the applicant nationality.
        /// </summary>
        /// <value>
        /// The applicant nationality.
        /// </value>
        [TextValidation("民族：", "")]
        public string ApplicantNation { get; set; }

        #endregion

        #region Constructor

        #endregion

        #region Public Method
        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectF">The rect f.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Draw(System.Drawing.Graphics g, System.Drawing.RectangleF rectF)
        {
            var drawRect = rectF;

            var gridMarginX = 0;
            var gridMarginY = 0;
            var gridRaws = 4;
            var gridColums = 5;
            RectangleF[,] gridRects = new RectangleF[gridRaws, gridColums];
            int gridCellWidth = (int)Math.Floor((drawRect.Width - gridMarginX * 2) / (double)gridRaws);
            int gridCellHeight = (int)Math.Floor(((drawRect.Height - gridMarginY * 2) / (double)gridColums));

            // create grid cells
            for (int i = 0; i < gridRaws; i++)
            {
                for (int j = 0; j < gridColums; j++)
                {
                    gridRects[i, j] = new RectangleF(gridMarginX + drawRect.X + j % gridColums * gridCellWidth, gridMarginY + drawRect.Y + i % gridRaws * gridCellHeight, gridCellWidth, gridCellHeight);
                }
            }
            var bmpRect = new RectangleF(gridRects[0, 3].X, gridRects[0, 3].Y, 1 * gridCellWidth, 4 * gridCellHeight);
            base.GenerateRectangleImage(g, gridPen, this.image, bmpRect, false);

            base.GenerateRectangleString(g, gridPen, string.Format("申请人: {0}", ApplicantName), gridFont, normalBrush, base.LeftFormat, gridRects[0, 0], false);
            base.GenerateRectangleString(g, gridPen, string.Format("性别: {0}", ApplicantSex), gridFont, normalBrush, base.LeftFormat, gridRects[0, 1], false);
            base.GenerateRectangleString(g, gridPen, string.Format("民族: {0}", ApplicantNation), gridFont, normalBrush, base.LeftFormat, gridRects[0, 2], false);
            base.GenerateRectangleString(g, gridPen, string.Format("出生日期: {0}", ApplicantBirth), gridFont, normalBrush, base.LeftFormat, gridRects[1, 0], false);
            base.GenerateRectangleString(g, gridPen, string.Format("国籍: {0}", ApplicantCountry), gridFont, normalBrush, base.LeftFormat, gridRects[1, 1], false);
            base.GenerateRectangleString(g, gridPen, string.Format("时间: {0}", ApplicantTime), gridFont, normalBrush, base.LeftFormat, gridRects[1, 2], false);
            base.GenerateRectangleString(g, gridPen, string.Format("身份证(护照)号码: {0}", ApplicantID), gridFont, normalBrush, base.LeftFormat, RectangleF.Union(gridRects[2, 0], gridRects[2, 2]), false);
            base.GenerateRectangleString(g, gridPen, string.Format("地点: {0}", ApplicantAddr), gridFont, normalBrush, base.LeftFormat, RectangleF.Union(gridRects[3, 0], gridRects[3, 2]), false);

            this.DrawTable(g, gridRaws, gridColums, gridCellWidth, gridCellHeight, gridRects[0, 0].Location);
        }
        #endregion

        #region Private Method
        private void DrawTable(System.Drawing.Graphics g, int rows, int columns, float gridCellWidth, float gridCellHeight, PointF location)
        {
            base.GenerateGridLine(g, gridPen, location, new PointF(location.X + columns * gridCellWidth, location.Y));
            base.GenerateGridLine(g, gridPen, new PointF(location.X, location.Y + 1 * gridCellHeight), new PointF(location.X + (columns - 2) * gridCellWidth, location.Y + 1 * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X, location.Y + 2 * gridCellHeight), new PointF(location.X + (columns - 2) * gridCellWidth, location.Y + 2 * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X, location.Y + 3 * gridCellHeight), new PointF(location.X + (columns - 2) * gridCellWidth, location.Y + 3 * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X, location.Y + rows * gridCellHeight), new PointF(location.X + columns * gridCellWidth, location.Y + rows * gridCellHeight));

            base.GenerateGridLine(g, gridPen, location, new PointF(location.X, location.Y + rows * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X + 1 * gridCellWidth, location.Y), new PointF(location.X + 1 * gridCellWidth, location.Y + (rows - 2) * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X + 2 * gridCellWidth, location.Y), new PointF(location.X + 2 * gridCellWidth, location.Y + (rows - 2) * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X + 3 * gridCellWidth, location.Y), new PointF(location.X + 3 * gridCellWidth, location.Y + rows * gridCellHeight));
            base.GenerateGridLine(g, gridPen, new PointF(location.X + columns * gridCellWidth, location.Y), new PointF(location.X + columns * gridCellWidth, location.Y + rows * gridCellHeight));

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
        ~GraphicIDGrid()
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
                if (ApplicantPic != null)
                {
                    ApplicantPic.Dispose();
                    ApplicantPic = null;
                }
                if (gridPen != null)
                {
                    gridPen.Dispose();
                    gridPen = null;
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
                if (image != null)
                {
                    image.Dispose();
                    image = null;
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
