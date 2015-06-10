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
using YDT.WinForm.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace YDT.WinForm.UCControl
{
    public partial class DocumentControl : DockChildEx
    {
        #region Private Property
        private string iDCardFolder = Application.StartupPath + "\\Temp\\";
        private ReportTemplate report = new ReportTemplate();
        #endregion

        #region Public Property
        public string ReportName { get; set; }
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
            ReportName = string.Format("{0}_{1}_{2}", DocSetting.Instance.ReportNamePrefix, this.Txb_Name.Text.TrimEnd(), DateTime.Now.ToShortDateString());
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
            report.GraphicIDGrid.Image = new Bitmap(this.Pic_user.Image);
            report.GraphicIDGrid.ApplicantAddr = this.Txb_Addr.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantAge = this.Txb_Age.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantBirth = this.Txb_Birth.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantID = this.Txb_IDCard.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantName = this.Txb_Name.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantNationality = this.Txb_Country.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantSex = this.Txb_Sex.Text.TrimEnd();
            report.GraphicIDGrid.ApplicantTime = this.Txb_Time.Text.TrimEnd();

            //report.GraphicLocPic.Image = new Bitmap(200, 200);

            report.Hands.AddFinger((this.Tlt_LeftHand.Controls[0] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_LeftHand.Controls[1] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_LeftHand.Controls[2] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_LeftHand.Controls[3] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_LeftHand.Controls[4] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_RightHand.Controls[0] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_RightHand.Controls[1] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_RightHand.Controls[2] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_RightHand.Controls[3] as FingerControl).Fprint);
            report.Hands.AddFinger((this.Tlt_RightHand.Controls[4] as FingerControl).Fprint);

            report.Draw(g);
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

            if (report != null)
            {
                report.Dispose();
                report = null;
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

            this.Text = "[默认工作区]";
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
        /// Button preview click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DocumentPrintPreview();
        }
        /// <summary>
        /// Handles the Click event of the Btn_ReadIDCard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_ReadIDCard_Click(object sender, EventArgs e)
        {
            using (var idCardWrapper = new SDTTeleComLib.SDTDLLWrapper())
            {
                try
                {
                    var success = idCardWrapper.ReadIDCard();
                    if (!success)
                    {
                        MessageBox.Show("读取身份证信息失败，请检查仪器是否已正确连接。");
                    }
                    else
                    {
                        ReadIDCardInfo(idCardWrapper);
                        ReadIDCardImage(idCardWrapper);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取身份证信息失败，" + ex.Message);
                }
            }
        }
        /// <summary>
        /// Reads the identifier card image.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ReadIDCardImage(SDTTeleComLib.SDTDLLWrapper wrapper)
        {
            string wltfile = iDCardFolder + "idCard.wlt";
            string bmpfile = iDCardFolder + "idCard.bmp";
            int usbPort = 2;

            using (FileStream fs = new FileStream(wltfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Write(wrapper.ImageBytes, 0, wrapper.ImageBytes.Length);
                fs.Flush();
            }

            SDTTeleComLib.SDTWin32API.GetBmp(wltfile, usbPort);

            using (FileStream fs = new FileStream(bmpfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                this.Pic_user.SizeMode = PictureBoxSizeMode.CenterImage;
                fs.Seek(0, SeekOrigin.Begin);
                this.Pic_user.Image = Image.FromStream(fs);
            }

            File.Delete(bmpfile);
        }
        /// <summary>
        /// Reads the identifier card information.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        private void ReadIDCardInfo(SDTTeleComLib.SDTDLLWrapper wrapper)
        {
            if (wrapper == null)
                return;

            //report.GraphicIDGrid.Image = new Bitmap(200, 200);
            this.Txb_Addr.Text = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Address).Trim();
            this.Txb_Age.Text = SDTTeleComLib.Uitl.ToAge(System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Birth)).Trim();

            this.Txb_Birth.Text = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Birth).Trim();
            this.Txb_IDCard.Text = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.ID).Trim();
            this.Txb_Name.Text = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Name).Trim();
            this.Txb_Country.Text = "中华人民共和国"; // 只有中国公民才有身份证 -。-
            this.Txb_Sex.Text = SDTTeleComLib.Uitl.ToSex(System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Sex)).Trim();
            this.Txb_Nation.Text = SDTTeleComLib.Uitl.ToNation(System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Nation)).Trim();
            this.Txb_Time.Text = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Exper).Trim();

            // No use.
            var Issue = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Issue).Trim();
            var Exper2 = System.Text.UTF8Encoding.Unicode.GetString(wrapper.IDCard.Exper2).Trim();
        }
        #endregion


    }
}
