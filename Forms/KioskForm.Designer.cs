namespace MR6100Demo.Forms
{
    partial class KioskForm
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
            this.backMain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoanItBTN = new System.Windows.Forms.Button();
            this.GiveItBackBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ExcelOutBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backMain
            // 
            this.backMain.Location = new System.Drawing.Point(876, 28);
            this.backMain.Name = "backMain";
            this.backMain.Size = new System.Drawing.Size(196, 35);
            this.backMain.TabIndex = 1;
            this.backMain.Text = "بازگشت به منوی اصلی";
            this.backMain.UseVisualStyleBackColor = true;
            this.backMain.Click += new System.EventHandler(this.backMain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1013, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "فرم امانات";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Olive;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1060, 273);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1060, 44);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search box";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1060, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LoanItBTN
            // 
            this.LoanItBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.LoanItBTN.Location = new System.Drawing.Point(93, 14);
            this.LoanItBTN.Name = "LoanItBTN";
            this.LoanItBTN.Size = new System.Drawing.Size(75, 40);
            this.LoanItBTN.TabIndex = 5;
            this.LoanItBTN.Text = "امانت بگیر";
            this.LoanItBTN.UseVisualStyleBackColor = false;
            this.LoanItBTN.Click += new System.EventHandler(this.LoanItBTN_Click);
            // 
            // GiveItBackBTN
            // 
            this.GiveItBackBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.GiveItBackBTN.Location = new System.Drawing.Point(12, 14);
            this.GiveItBackBTN.Name = "GiveItBackBTN";
            this.GiveItBackBTN.Size = new System.Drawing.Size(75, 40);
            this.GiveItBackBTN.TabIndex = 6;
            this.GiveItBackBTN.Text = "پسش بده";
            this.GiveItBackBTN.UseVisualStyleBackColor = false;
            this.GiveItBackBTN.Click += new System.EventHandler(this.GiveItBackBTN_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Location = new System.Drawing.Point(174, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "به روز رسانی لیست";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExcelOutBTN
            // 
            this.ExcelOutBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ExcelOutBTN.Location = new System.Drawing.Point(12, 389);
            this.ExcelOutBTN.Name = "ExcelOutBTN";
            this.ExcelOutBTN.Size = new System.Drawing.Size(97, 57);
            this.ExcelOutBTN.TabIndex = 8;
            this.ExcelOutBTN.Text = "خروجی اکسل";
            this.ExcelOutBTN.UseVisualStyleBackColor = false;
            this.ExcelOutBTN.Click += new System.EventHandler(this.ExcelOutBTN_Click);
            // 
            // KioskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1084, 450);
            this.Controls.Add(this.ExcelOutBTN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.backMain);
            this.Controls.Add(this.GiveItBackBTN);
            this.Controls.Add(this.LoanItBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "KioskForm";
            this.Text = "KioskForm";
            this.Load += new System.EventHandler(this.KioskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoanItBTN;
        private System.Windows.Forms.Button GiveItBackBTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ExcelOutBTN;
    }
}