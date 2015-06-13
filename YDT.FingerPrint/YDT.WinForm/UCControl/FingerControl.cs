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
using YDT.WinForm.Graphic;
using YDT.WinForm.UCWindow;

namespace YDT.WinForm.UCControl
{
    public partial class FingerControl : UserControl
    {
        private GraphicFinger fprint = new GraphicFinger();

        /// <summary>
        /// Finger Print Class
        /// </summary>
        public GraphicFinger Fprint
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

        private void Btn_GetFinger(object sender, EventArgs e)
        {
            try
            {
                using (TesoDevMgmt tesoMgmt = new TesoDevMgmt())
                {
                    if (tesoMgmt.GetImageByPressOnce())
                    {
                        fprint.Identify = System.Guid.NewGuid().ToString("N");
                        fprint.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());
                        this.Pcb_Finger.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.Pcb_Finger.Image = Image.FromHbitmap(tesoMgmt.CurImg.GetHbitmap());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
            }
        }

        private void Btn_Note_Click(object sender, EventArgs e)
        {
            try
            {
                using (var note = new FrmNote() { Title = this.Btn_Finger.Text })
                {
                    if (note.ShowDialog().Equals(DialogResult.OK))
                    {
                        Bitmap bmp = new Bitmap(this.Pcb_Finger.Width, this.Pcb_Finger.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        g.DrawString(note.Remark, new Font("宋体", 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(0, 0));
                        fprint.Image = (Bitmap)bmp.Clone();
                        this.Pcb_Finger.Image = (Bitmap)bmp.Clone();
                        bmp.Dispose();
                        bmp = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
            }
        }

    }
}
