namespace MR6100Demo.Forms
{
    partial class InventoryForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddBookBTN = new System.Windows.Forms.Button();
            this.ExcelOutBTN = new System.Windows.Forms.Button();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.EditBookBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backMain
            // 
            this.backMain.Location = new System.Drawing.Point(900, 38);
            this.backMain.Name = "backMain";
            this.backMain.Size = new System.Drawing.Size(184, 35);
            this.backMain.TabIndex = 0;
            this.backMain.Text = "بازگشت به منوی اصلی";
            this.backMain.UseVisualStyleBackColor = true;
            this.backMain.Click += new System.EventHandler(this.backMain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1011, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "فرم انبارداری";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1072, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Teal;
            this.dataGridView1.Location = new System.Drawing.Point(8, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1076, 273);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AddBookBTN
            // 
            this.AddBookBTN.BackColor = System.Drawing.SystemColors.Highlight;
            this.AddBookBTN.Location = new System.Drawing.Point(8, 16);
            this.AddBookBTN.Name = "AddBookBTN";
            this.AddBookBTN.Size = new System.Drawing.Size(97, 57);
            this.AddBookBTN.TabIndex = 5;
            this.AddBookBTN.Text = "افزودن کتاب ";
            this.AddBookBTN.UseVisualStyleBackColor = false;
            this.AddBookBTN.Click += new System.EventHandler(this.AddBookBTN_Click);
            // 
            // ExcelOutBTN
            // 
            this.ExcelOutBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ExcelOutBTN.Location = new System.Drawing.Point(8, 386);
            this.ExcelOutBTN.Name = "ExcelOutBTN";
            this.ExcelOutBTN.Size = new System.Drawing.Size(97, 57);
            this.ExcelOutBTN.TabIndex = 7;
            this.ExcelOutBTN.Text = "خروجی اکسل";
            this.ExcelOutBTN.UseVisualStyleBackColor = false;
            this.ExcelOutBTN.Click += new System.EventHandler(this.ExcelOutBTN_Click);
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.BackColor = System.Drawing.Color.Beige;
            this.RefreshBTN.Location = new System.Drawing.Point(214, 16);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(100, 57);
            this.RefreshBTN.TabIndex = 8;
            this.RefreshBTN.Text = "به روز رسانی لیست";
            this.RefreshBTN.UseVisualStyleBackColor = false;
            this.RefreshBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditBookBTN
            // 
            this.EditBookBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.EditBookBTN.ForeColor = System.Drawing.Color.Black;
            this.EditBookBTN.Location = new System.Drawing.Point(111, 16);
            this.EditBookBTN.Name = "EditBookBTN";
            this.EditBookBTN.Size = new System.Drawing.Size(97, 57);
            this.EditBookBTN.TabIndex = 9;
            this.EditBookBTN.Text = "ویرایش کتاب ";
            this.EditBookBTN.UseVisualStyleBackColor = false;
            this.EditBookBTN.Click += new System.EventHandler(this.EditBookBTN_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1096, 450);
            this.Controls.Add(this.EditBookBTN);
            this.Controls.Add(this.RefreshBTN);
            this.Controls.Add(this.ExcelOutBTN);
            this.Controls.Add(this.AddBookBTN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backMain);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddBookBTN;
        private System.Windows.Forms.Button ExcelOutBTN;
        private System.Windows.Forms.Button RefreshBTN;
        private System.Windows.Forms.Button EditBookBTN;
    }
}