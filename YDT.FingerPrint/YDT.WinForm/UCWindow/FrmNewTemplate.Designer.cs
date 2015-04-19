namespace YDT.WinForm.UCWindow
{
    partial class FrmNewTemplate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Txb_National = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txb_Address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txb_Sex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txb_Birthday = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txb_Age = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txb_IDCard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txb_Name = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Txb_ReportTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Txb_ReportPrefix = new System.Windows.Forms.TextBox();
            this.Txb_ReportFooter = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cbb_Templates = new System.Windows.Forms.ComboBox();
            this.Txb_ReportHeader = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 254);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 228);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Txb_National, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Txb_Address, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.Txb_Sex, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Txb_Birthday, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.Txb_Age, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Txb_IDCard, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Txb_Name, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 222);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // Txb_National
            // 
            this.Txb_National.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_National.Location = new System.Drawing.Point(193, 3);
            this.Txb_National.Name = "Txb_National";
            this.Txb_National.Size = new System.Drawing.Size(184, 21);
            this.Txb_National.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "国籍：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_Address
            // 
            this.Txb_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_Address.Location = new System.Drawing.Point(193, 147);
            this.Txb_Address.Name = "Txb_Address";
            this.Txb_Address.Size = new System.Drawing.Size(184, 21);
            this.Txb_Address.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "地址：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_Sex
            // 
            this.Txb_Sex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_Sex.Location = new System.Drawing.Point(193, 75);
            this.Txb_Sex.Name = "Txb_Sex";
            this.Txb_Sex.Size = new System.Drawing.Size(184, 21);
            this.Txb_Sex.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "性别：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_Birthday
            // 
            this.Txb_Birthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_Birthday.Location = new System.Drawing.Point(193, 99);
            this.Txb_Birthday.Name = "Txb_Birthday";
            this.Txb_Birthday.Size = new System.Drawing.Size(184, 21);
            this.Txb_Birthday.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_Age
            // 
            this.Txb_Age.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_Age.Location = new System.Drawing.Point(193, 51);
            this.Txb_Age.Name = "Txb_Age";
            this.Txb_Age.Size = new System.Drawing.Size(184, 21);
            this.Txb_Age.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "年龄：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_IDCard
            // 
            this.Txb_IDCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_IDCard.Location = new System.Drawing.Point(193, 123);
            this.Txb_IDCard.Name = "Txb_IDCard";
            this.Txb_IDCard.Size = new System.Drawing.Size(184, 21);
            this.Txb_IDCard.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "身份证(护照)号码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_Name
            // 
            this.Txb_Name.BackColor = System.Drawing.Color.White;
            this.Txb_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_Name.Location = new System.Drawing.Point(193, 27);
            this.Txb_Name.Name = "Txb_Name";
            this.Txb_Name.Size = new System.Drawing.Size(184, 21);
            this.Txb_Name.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 228);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模板";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.Txb_ReportTitle, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.Txb_ReportPrefix, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.Txb_ReportFooter, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Cbb_Templates, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.Txb_ReportHeader, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(380, 222);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // Txb_ReportTitle
            // 
            this.Txb_ReportTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_ReportTitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Txb_ReportTitle.Location = new System.Drawing.Point(193, 75);
            this.Txb_ReportTitle.Name = "Txb_ReportTitle";
            this.Txb_ReportTitle.Size = new System.Drawing.Size(184, 21);
            this.Txb_ReportTitle.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "报告标题：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txb_ReportPrefix
            // 
            this.Txb_ReportPrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_ReportPrefix.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Txb_ReportPrefix.Location = new System.Drawing.Point(193, 51);
            this.Txb_ReportPrefix.Name = "Txb_ReportPrefix";
            this.Txb_ReportPrefix.Size = new System.Drawing.Size(184, 21);
            this.Txb_ReportPrefix.TabIndex = 23;
            // 
            // Txb_ReportFooter
            // 
            this.Txb_ReportFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_ReportFooter.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Txb_ReportFooter.Location = new System.Drawing.Point(193, 27);
            this.Txb_ReportFooter.Name = "Txb_ReportFooter";
            this.Txb_ReportFooter.Size = new System.Drawing.Size(184, 21);
            this.Txb_ReportFooter.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(184, 24);
            this.label14.TabIndex = 19;
            this.label14.Text = "选择模板类型：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "报告前缀：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = "报告页脚：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "报告页眉：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cbb_Templates
            // 
            this.Cbb_Templates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cbb_Templates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbb_Templates.FormattingEnabled = true;
            this.Cbb_Templates.Location = new System.Drawing.Point(193, 99);
            this.Cbb_Templates.Name = "Cbb_Templates";
            this.Cbb_Templates.Size = new System.Drawing.Size(184, 20);
            this.Cbb_Templates.TabIndex = 20;
            // 
            // Txb_ReportHeader
            // 
            this.Txb_ReportHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txb_ReportHeader.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Txb_ReportHeader.Location = new System.Drawing.Point(193, 3);
            this.Txb_ReportHeader.Name = "Txb_ReportHeader";
            this.Txb_ReportHeader.Size = new System.Drawing.Size(184, 21);
            this.Txb_ReportHeader.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Btn_Cancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Btn_OK, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 263);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cancel.Location = new System.Drawing.Point(197, 0);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(197, 34);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "取消(&C)";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_OK
            // 
            this.Btn_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_OK.Location = new System.Drawing.Point(0, 0);
            this.Btn_OK.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(197, 34);
            this.Btn_OK.TabIndex = 0;
            this.Btn_OK.Text = "确认(&O)";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // FrmNewTemplate
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "FrmNewTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建-指纹采集模板";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txb_IDCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txb_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txb_Birthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txb_Age;
        private System.Windows.Forms.TextBox Txb_Address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txb_Sex;
        private System.Windows.Forms.TextBox Txb_National;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox Cbb_Templates;
        private System.Windows.Forms.TextBox Txb_ReportPrefix;
        private System.Windows.Forms.TextBox Txb_ReportFooter;
        private System.Windows.Forms.TextBox Txb_ReportHeader;
        private System.Windows.Forms.TextBox Txb_ReportTitle;
        private System.Windows.Forms.Label label9;
         
    }
}