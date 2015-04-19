using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using YDT.WinForm.Model;

namespace YDT.WinForm.UCWindow
{
    public partial class FrmNewTemplate : Form
    {
        public Model.DocSetting Setting { get; set; }

        public Common.IReportTemplate Template { get; set; }

        public FrmNewTemplate()
        {
            InitializeComponent();
            InitializeSetting();
        }

        private void InitializeSetting()
        {
            var set = DocSetting.Instance;
            this.Txb_ReportHeader.Text = set.ReportHeader;
            this.Txb_ReportFooter.Text = set.ReportFooter;
            this.Txb_ReportTitle.Text = set.ReportTitle;
            this.Txb_ReportPrefix.Text = set.ReportNamePrefix;
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            // TODO: need to do setting check
            if (string.IsNullOrEmpty(this.Txb_Name.Text))
            {
                MessageBox.Show("姓名不能为空，请填写。", "提示");
                return;
            }

            Setting = DocSetting.Instance;
            Setting.ReportHeader = this.Txb_ReportHeader.Text;
            Setting.ReportFooter = this.Txb_ReportFooter.Text;
            Setting.ReportTitle = this.Txb_ReportTitle.Text;
            Setting.ReportNamePrefix = this.Txb_ReportPrefix.Text;

            Setting.CurCustomer = new Customer()
            {
                Address = this.Txb_Address.Text,
                Age = this.Txb_Age.Text,
                Birthday = this.Txb_Birthday.Text,
                IDCard = this.Txb_IDCard.Text,
                Name = this.Txb_Name.Text,
                Nationality = this.Txb_National.Text,
                Sex = this.Txb_Sex.Text,
                Time = string.Format("{0}年{1}月{2}日", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),// This is for non Chinese language in OS.
            };
            DocSetting.Save();

            Template = new ReportTemplate();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #region 修正输入法全角/半角的问题
        //声明一些API函数     
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref   int lpdw, ref   int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            IntPtr HIme = ImmGetContext(this.Handle);
            //如果输入法处于打开状态    
            if (ImmGetOpenStatus(HIme))
            {
                int iMode = 0;
                int iSentence = 0;
                //检索输入法信息     
                bool bSuccess = ImmGetConversionStatus(HIme, ref   iMode, ref   iSentence);
                if (bSuccess)
                {
                    //如果是全角,转换成半角    
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);
                }

            }
        }
        #endregion  
    }
}
