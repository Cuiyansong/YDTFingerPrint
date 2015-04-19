using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDT.WinForm.UCBase;
using YDT.WinForm.Common;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.UCControl
{
    public partial class DocumentControl : DockChildEx
    {
        #region Private Property
        private IDocument content;
        #endregion

        #region Public Property
        /// <summary>
        /// Content
        /// </summary>
        public IDocument Content
        {
            get { return content; }
            set { content = value; }
        }
        #endregion

        #region Constructure
        /// <summary>
        /// Constructure
        /// </summary>
        public DocumentControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// DocumentPrintPreview
        /// </summary>
        public void DocumentPrintPreview()
        {
            var ReportName = "指纹打印文件";
            if (Content != null && Content.Setting != null)
            {
                ReportName = string.Format("{0}_{1}_{2}", Content.Setting.ReportNamePrefix, Content.Setting.CurCustomer.Name, Content.Setting.CurCustomer.Time);
            }

            printDocument1.DocumentName = ReportName;
            printDocument1.DefaultPageSettings = new System.Drawing.Printing.PageSettings()
            {
                PaperSize = new System.Drawing.Printing.PaperSize("A4", (int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Width), (int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Height)),
            };
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.AutoZoom = false;
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.75;
            printPreviewDialog1.ShowDialog();
        }
        /// <summary>
        /// DrawReportImage
        /// </summary>
        /// <param name="g"></param>
        public void DrawReportImage(Graphics g)
        {
            content.Hands.AddFinger((this.Tlt_LeftHand.Controls[0] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_LeftHand.Controls[1] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_LeftHand.Controls[2] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_LeftHand.Controls[3] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_LeftHand.Controls[4] as FingerControl).Fprint);

            content.Hands.AddFinger((this.Tlt_RightHand.Controls[0] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_RightHand.Controls[1] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_RightHand.Controls[2] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_RightHand.Controls[3] as FingerControl).Fprint);
            content.Hands.AddFinger((this.Tlt_RightHand.Controls[4] as FingerControl).Fprint);

            content.DrawItems(g);
        }
        #endregion

        #region Private Method
        /// <summary>
        /// OnClosing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            // TODO: Ask if save report which hasn't been saved.

            base.OnClosing(e);

            if (content != null)
            {
                content.Dispose();
                content = null;
            }
        }
        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentControl_Load(object sender, EventArgs e)
        {
            this.printPreviewDialog1 = new PrintPreviewDialog();

            if (content != null && content.Setting != null)
            {
                this.Text = string.IsNullOrEmpty(Content.Setting.CurCustomer.Name) ? "[默认工作区]" : Content.Setting.CurCustomer.Name; // Set workspace title
                this.Lbl_Name.Text = Content.Setting.CurCustomer.Name;
                this.Lbl_Addr.Text = Content.Setting.CurCustomer.Address;
                this.Lbl_IDCard.Text = Content.Setting.CurCustomer.IDCard;
                this.Lbl_Time.Text = Content.Setting.CurCustomer.Time;
            }

            this.Tlt_LeftHand.Controls.Add(new FingerControl(Finger.LeftThumb), 0, 0);
            this.Tlt_LeftHand.Controls.Add(new FingerControl(Finger.LeftForeFinger), 2, 0);
            this.Tlt_LeftHand.Controls.Add(new FingerControl(Finger.LeftMiddleFinger), 4, 0);
            this.Tlt_LeftHand.Controls.Add(new FingerControl(Finger.LeftRingFinger), 6, 0);
            this.Tlt_LeftHand.Controls.Add(new FingerControl(Finger.LeftLittleFinger), 8, 0);

            this.Tlt_RightHand.Controls.Add(new FingerControl(Finger.RightThumb), 0, 0);
            this.Tlt_RightHand.Controls.Add(new FingerControl(Finger.RightForeFinger), 2, 0);
            this.Tlt_RightHand.Controls.Add(new FingerControl(Finger.RightMiddleFinger), 4, 0);
            this.Tlt_RightHand.Controls.Add(new FingerControl(Finger.RightRingFinger), 6, 0);
            this.Tlt_RightHand.Controls.Add(new FingerControl(Finger.RightLittleFinger), 8, 0);
        }
        /// <summary>
        /// printDocument1_PrintPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DrawReportImage(e.Graphics);
        }
        /// <summary>
        /// button1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DocumentPrintPreview();
        }
        #endregion

    }
}
