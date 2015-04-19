using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDT.WinForm.Model;
using YDT.WinForm.Common;

namespace YDT.WinForm.UCControl
{
    public partial class FingerControl : UserControl
    {
        private FingerPrint fprint = new FingerPrint();

        /// <summary>
        /// Finger Print Class
        /// </summary>
        public FingerPrint Fprint
        {
            get { return fprint; }
            private set { fprint = value; }
        }

        public FingerControl(Finger finger)
        {
            InitializeComponent();

            fprint.Finger = finger;

            this.Btn_Finger.Text = finger.GetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TesoDevMgmt tesoMgmt = new TesoDevMgmt())
            {
                if (tesoMgmt.GetImageByPressOnce())
                {
                    fprint.Identify = System.Guid.NewGuid().ToString("N");
                    fprint.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());
                    this.Pcb_Finger.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());
                }
                //if (tesoMgmt.GetFingerImage())
                //{
                //    fprint.Identify = System.Guid.NewGuid().ToString("N");
                //    fprint.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());   
                //    this.Pcb_Finger.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());   
                //}
            }
        }
    }
}
