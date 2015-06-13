using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YDT.WinForm.UCWindow
{
    public partial class FrmNote : Form
    {
        public string Title
        {
            set { this.Text = value; }
        }

        public string Remark
        {
            get
            {
                return this.Txb_Note.Text.TrimEnd();
            }
        }

        public FrmNote()
        {
            InitializeComponent();
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (this.Txb_Note.Text.Length > 255)
                MessageBox.Show("输入字符串不能大于255个字符，请重新填写。","警告");

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
