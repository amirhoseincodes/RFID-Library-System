namespace MR6100Demo.Forms
{
    partial class AddOrEdit
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxBookName = new System.Windows.Forms.TextBox();
            this.textBoxBookVolume = new System.Windows.Forms.TextBox();
            this.labelBookVolume = new System.Windows.Forms.Label();
            this.labelBookDate = new System.Windows.Forms.Label();
            this.textBoxBookDate = new System.Windows.Forms.TextBox();
            this.labelBookNum = new System.Windows.Forms.Label();
            this.textBoxBookNum = new System.Windows.Forms.TextBox();
            this.labelBookTag = new System.Windows.Forms.Label();
            this.textBoxBookTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBookLoan = new System.Windows.Forms.TextBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(387, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "اضافه یا ویرایش کتاب";
            this.labelTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(426, 57);
            this.labelName.Name = "labelName";
            this.labelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelName.Size = new System.Drawing.Size(56, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "نام کتاب :";
            // 
            // textBoxBookName
            // 
            this.textBoxBookName.Location = new System.Drawing.Point(28, 57);
            this.textBoxBookName.Name = "textBoxBookName";
            this.textBoxBookName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookName.Size = new System.Drawing.Size(387, 22);
            this.textBoxBookName.TabIndex = 2;
            // 
            // textBoxBookVolume
            // 
            this.textBoxBookVolume.Location = new System.Drawing.Point(274, 98);
            this.textBoxBookVolume.Name = "textBoxBookVolume";
            this.textBoxBookVolume.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookVolume.Size = new System.Drawing.Size(141, 22);
            this.textBoxBookVolume.TabIndex = 3;
            // 
            // labelBookVolume
            // 
            this.labelBookVolume.AutoSize = true;
            this.labelBookVolume.Location = new System.Drawing.Point(426, 98);
            this.labelBookVolume.Name = "labelBookVolume";
            this.labelBookVolume.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBookVolume.Size = new System.Drawing.Size(64, 16);
            this.labelBookVolume.TabIndex = 4;
            this.labelBookVolume.Text = "شماره جلد :";
            // 
            // labelBookDate
            // 
            this.labelBookDate.AutoSize = true;
            this.labelBookDate.Location = new System.Drawing.Point(180, 137);
            this.labelBookDate.Name = "labelBookDate";
            this.labelBookDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBookDate.Size = new System.Drawing.Size(75, 16);
            this.labelBookDate.TabIndex = 5;
            this.labelBookDate.Text = "تاریخ انتشار :";
            // 
            // textBoxBookDate
            // 
            this.textBoxBookDate.Location = new System.Drawing.Point(28, 137);
            this.textBoxBookDate.Name = "textBoxBookDate";
            this.textBoxBookDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookDate.Size = new System.Drawing.Size(147, 22);
            this.textBoxBookDate.TabIndex = 6;
            // 
            // labelBookNum
            // 
            this.labelBookNum.AutoSize = true;
            this.labelBookNum.Location = new System.Drawing.Point(181, 98);
            this.labelBookNum.Name = "labelBookNum";
            this.labelBookNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBookNum.Size = new System.Drawing.Size(74, 16);
            this.labelBookNum.TabIndex = 7;
            this.labelBookNum.Text = "شماره کتاب :";
            this.labelBookNum.Click += new System.EventHandler(this.labelBookNum_Click);
            // 
            // textBoxBookNum
            // 
            this.textBoxBookNum.Location = new System.Drawing.Point(28, 98);
            this.textBoxBookNum.Name = "textBoxBookNum";
            this.textBoxBookNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookNum.Size = new System.Drawing.Size(147, 22);
            this.textBoxBookNum.TabIndex = 8;
            // 
            // labelBookTag
            // 
            this.labelBookTag.AutoSize = true;
            this.labelBookTag.Location = new System.Drawing.Point(426, 180);
            this.labelBookTag.Name = "labelBookTag";
            this.labelBookTag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBookTag.Size = new System.Drawing.Size(61, 16);
            this.labelBookTag.TabIndex = 9;
            this.labelBookTag.Text = "شماره تگ :";
            // 
            // textBoxBookTag
            // 
            this.textBoxBookTag.Location = new System.Drawing.Point(28, 174);
            this.textBoxBookTag.Name = "textBoxBookTag";
            this.textBoxBookTag.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookTag.Size = new System.Drawing.Size(387, 22);
            this.textBoxBookTag.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 140);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "وضعیت امانت :";
            // 
            // textBoxBookLoan
            // 
            this.textBoxBookLoan.Location = new System.Drawing.Point(274, 137);
            this.textBoxBookLoan.Name = "textBoxBookLoan";
            this.textBoxBookLoan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxBookLoan.Size = new System.Drawing.Size(141, 22);
            this.textBoxBookLoan.TabIndex = 12;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(28, 206);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(147, 39);
            this.buttonAccept.TabIndex = 13;
            this.buttonAccept.Text = "button1";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // AddOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 257);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxBookLoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBookTag);
            this.Controls.Add(this.labelBookTag);
            this.Controls.Add(this.textBoxBookNum);
            this.Controls.Add(this.labelBookNum);
            this.Controls.Add(this.textBoxBookDate);
            this.Controls.Add(this.labelBookDate);
            this.Controls.Add(this.labelBookVolume);
            this.Controls.Add(this.textBoxBookVolume);
            this.Controls.Add(this.textBoxBookName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTitle);
            this.Name = "AddOrEdit";
            this.Text = "AddOrEdit";
            this.Load += new System.EventHandler(this.AddOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxBookName;
        private System.Windows.Forms.TextBox textBoxBookVolume;
        private System.Windows.Forms.Label labelBookVolume;
        private System.Windows.Forms.Label labelBookDate;
        private System.Windows.Forms.TextBox textBoxBookDate;
        private System.Windows.Forms.Label labelBookNum;
        private System.Windows.Forms.TextBox textBoxBookNum;
        private System.Windows.Forms.Label labelBookTag;
        private System.Windows.Forms.TextBox textBoxBookTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBookLoan;
        private System.Windows.Forms.Button buttonAccept;
    }
}