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
        public UCControl.DocumentControl TemplateControl { get; set; }

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

            this.Cbb_Templates.SelectedText = "通用模板1";
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {   
            DocSetting.Instance.ReportHeader = this.Txb_ReportHeader.Text;
            DocSetting.Instance.ReportFooter = this.Txb_ReportFooter.Text;
            DocSetting.Instance.ReportTitle = this.Txb_ReportTitle.Text;
            DocSetting.Instance.ReportNamePrefix = this.Txb_ReportPrefix.Text;
            DocSetting.Save();
             
            TemplateControl = new UCControl.DocumentControl();
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
