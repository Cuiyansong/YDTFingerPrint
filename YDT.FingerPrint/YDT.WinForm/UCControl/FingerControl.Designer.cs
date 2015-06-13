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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Pcb_Finger = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Note = new System.Windows.Forms.Button();
            this.Btn_Finger = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Finger)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Pcb_Finger, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(164, 112);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // Pcb_Finger
            // 
            this.Pcb_Finger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pcb_Finger.Location = new System.Drawing.Point(40, 3);
            this.Pcb_Finger.Name = "Pcb_Finger";
            this.Pcb_Finger.Size = new System.Drawing.Size(84, 107);
            this.Pcb_Finger.TabIndex = 0;
            this.Pcb_Finger.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.Btn_Note, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btn_Finger, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 121);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(164, 26);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // Btn_Note
            // 
            this.Btn_Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Note.Location = new System.Drawing.Point(98, 0);
            this.Btn_Note.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Note.Name = "Btn_Note";
            this.Btn_Note.Size = new System.Drawing.Size(66, 26);
            this.Btn_Note.TabIndex = 2;
            this.Btn_Note.Text = "备注";
            this.Btn_Note.UseVisualStyleBackColor = true;
            this.Btn_Note.Click += new System.EventHandler(this.Btn_Note_Click);
            // 
            // Btn_Finger
            // 
            this.Btn_Finger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Finger.Location = new System.Drawing.Point(0, 0);
            this.Btn_Finger.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Finger.Name = "Btn_Finger";
            this.Btn_Finger.Size = new System.Drawing.Size(98, 26);
            this.Btn_Finger.TabIndex = 1;
            this.Btn_Finger.Text = "采集";
            this.Btn_Finger.UseVisualStyleBackColor = true;
            this.Btn_Finger.Click += new System.EventHandler(this.Btn_GetFinger);
            // 
            // FingerControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FingerControl";
            this.Size = new System.Drawing.Size(170, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Finger)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Btn_Finger;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox Pcb_Finger;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Btn_Note;

    }
}
