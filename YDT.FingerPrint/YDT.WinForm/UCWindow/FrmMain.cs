using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using YDT.WinForm.Common;
using YDT.WinForm.Model;
using YDT.WinForm.UCControl;
using YDT.WinForm.Utlity;

namespace YDT.WinForm.UCWindow
{
    public partial class FrmMain : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        }
        /// <summary>
        /// Form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// Exit button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// New button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNewTemplate())
                if (DialogResult.OK == frm.ShowDialog())
                {
                    var docContent = new DocumentControl()
                    {
                        Content = new Document()
                            {
                                Hands = new DoubleHand(),
                                Setting = frm.Setting.Clone() as DocSetting,
                                Template = frm.Template,
                            }
                    };

                    docContent.Show(this.dockPanelEx1, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                }
        }
        /// <summary>
        /// About me form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAbout())
                if (DialogResult.OK == frm.ShowDialog())
                {

                }
        }
        /// <summary>
        /// Setting form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmConfig())
                if (DialogResult.OK == frm.ShowDialog())
                {

                }
        }
        /// <summary>
        /// printPreviewToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docContent = this.dockPanelEx1.FindActiveDocument();
            if (docContent == null)
            {
                MessageBox.Show("请选择指纹采集工作区，然后在进行此操作。", "提示");
                return;
            }
            var docCtrl = docContent as DocumentControl;
            if (docCtrl != null)
            {
                docCtrl.DocumentPrintPreview();
            }
        }
        /// <summary>
        /// saveAsPDFToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docContent = this.dockPanelEx1.FindActiveDocument();
            if (docContent == null)
            {
                MessageBox.Show("请选择指纹采集工作区，然后在进行此操作。", "提示");
                return;
            }

            var docCtrl = docContent as DocumentControl;
            var ReportName = "PDF图片";
            if (docCtrl.Content != null && docCtrl.Content.Setting != null)
            {
                ReportName = string.Format("{0}_{1}_{2}", docCtrl.Content.Setting.ReportNamePrefix, docCtrl.Content.Setting.CurCustomer.Name, docCtrl.Content.Setting.CurCustomer.Time);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.FileName = ReportName;
            saveFileDialog1.Filter = "PDF|*.pdf";
            saveFileDialog1.Title = "保存PDF";
            var result = saveFileDialog1.ShowDialog();

            if (DialogResult.OK == result && !string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                if (docCtrl != null)
                {
                    Bitmap bmp = new Bitmap((int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Width), (int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Height));
                    Graphics g = Graphics.FromImage(bmp);
                    docCtrl.DrawReportImage(g);
                   
                    iTextSharp.text.Rectangle rr = new iTextSharp.text.Rectangle((int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Width), (int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Height));
                    iTextSharp.text.Document document = new iTextSharp.text.Document(rr);
                    try
                    {
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(saveFileDialog1.FileName, FileMode.CreateNew));
                        document.Open();
                        iTextSharp.text.Image sd = iTextSharp.text.Image.GetInstance(bmp as Image, ImageFormat.Bmp);
                        document.Add(sd);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                    document.Close();
                }
            }
        }
        /// <summary>
        /// saveAsBMPToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsBMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docContent = this.dockPanelEx1.FindActiveDocument();
            if (docContent == null)
            {
                MessageBox.Show("请选择指纹采集工作区，然后在进行此操作。", "提示");
                return;
            }

            var docCtrl = docContent as DocumentControl;
            var ReportName = "指纹图片";
            if (docCtrl.Content != null && docCtrl.Content.Setting != null)
            {
                ReportName = string.Format("{0}_{1}_{2}", docCtrl.Content.Setting.ReportNamePrefix, docCtrl.Content.Setting.CurCustomer.Name, docCtrl.Content.Setting.CurCustomer.Time);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.FileName = ReportName;
            saveFileDialog1.Filter = "Bitmap Image|*.bmp";
            saveFileDialog1.Title = "保存图像";
            var result = saveFileDialog1.ShowDialog();

            if (DialogResult.OK == result && !string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                if (docCtrl != null)
                {
                    Bitmap bmp = new Bitmap((int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Width), (int)PrintHelper.MillimetreToPixel(GlobalSetting.DefaultPrintPageSizeMM.Height));
                    Graphics g = Graphics.FromImage(bmp);
                    docCtrl.DrawReportImage(g);
                    bmp.Save(saveFileDialog1.FileName);
                }
            }
        }
        #endregion
    }
}
