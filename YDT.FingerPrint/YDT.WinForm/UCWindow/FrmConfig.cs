using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDT.WinForm.Model;

namespace YDT.WinForm.UCWindow
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            DocSetting.Load();

            this.Txb_ReportTitle.Text = DocSetting.Instance.ReportTitle;
            this.Txb_ReportHeader.Text = DocSetting.Instance.ReportHeader;
            this.Txb_ReportFooter.Text = DocSetting.Instance.ReportFooter;
            this.Txb_ReportPrefix.Text = DocSetting.Instance.ReportNamePrefix;
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            // TODO: Need to be chcek
            DocSetting.Instance.ReportTitle = this.Txb_ReportTitle.Text;
            DocSetting.Instance.ReportHeader = this.Txb_ReportHeader.Text;
            DocSetting.Instance.ReportFooter = this.Txb_ReportFooter.Text;
            DocSetting.Instance.ReportNamePrefix = this.Txb_ReportPrefix.Text;
            DocSetting.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
