namespace YDT.WinForm.UCControl
{
    partial class FingerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Pcb_Finger = new System.Windows.Forms.PictureBox();
            this.Btn_Finger = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Finger)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Pcb_Finger, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Finger, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Pcb_Finger
            // 
            this.Pcb_Finger.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Pcb_Finger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pcb_Finger.Location = new System.Drawing.Point(9, 6);
            this.Pcb_Finger.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.Pcb_Finger.Name = "Pcb_Finger";
            this.Pcb_Finger.Size = new System.Drawing.Size(152, 200);
            this.Pcb_Finger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pcb_Finger.TabIndex = 0;
            this.Pcb_Finger.TabStop = false;
            // 
            // Btn_Finger
            // 
            this.Btn_Finger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Finger.Location = new System.Drawing.Point(6, 215);
            this.Btn_Finger.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Btn_Finger.Name = "Btn_Finger";
            this.Btn_Finger.Size = new System.Drawing.Size(158, 22);
            this.Btn_Finger.TabIndex = 1;
            this.Btn_Finger.Text = "采集指纹";
            this.Btn_Finger.UseVisualStyleBackColor = true;
            this.Btn_Finger.Click += new System.EventHandler(this.button1_Click);
            // 
            // FingerControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FingerControl";
            this.Size = new System.Drawing.Size(170, 240);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Finger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Pcb_Finger;
        private System.Windows.Forms.Button Btn_Finger;

    }
}
