using MR6100Demo.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MR6100Demo
{
    partial class mainForm
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
        // private void InitializeComponent()
        // {
        // this.components = new System.ComponentModel.Container();
        // this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        // this.Text = "Form2";
        // }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.libInfo = new System.Windows.Forms.ListBox();
            this.timerGen2Identify = new System.Windows.Forms.Timer(this.components);
            this.timerRate = new System.Windows.Forms.Timer(this.components);
            this.timerMultiTagRead = new System.Windows.Forms.Timer(this.components);
            this.timerMultiTagWrite = new System.Windows.Forms.Timer(this.components);
            this.timerIsoIdentify = new System.Windows.Forms.Timer(this.components);
            this.timerIsoMultiTagRead = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.timerReconnect = new System.Windows.Forms.Timer(this.components);
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbPort2 = new System.Windows.Forms.TextBox();
            this.tbIP2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.password_database_info = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.username_database_info = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.name_database_info = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.set_database = new System.Windows.Forms.Button();
            this.ip_database_info = new System.Windows.Forms.TextBox();
            this.get_database = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rbBuzzerOFF = new System.Windows.Forms.RadioButton();
            this.btnSetBuzzer = new System.Windows.Forms.Button();
            this.btnGetBuzzer = new System.Windows.Forms.Button();
            this.rbBuzzerON = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbFreq_Others = new System.Windows.Forms.RadioButton();
            this.rbFreq_Europe = new System.Windows.Forms.RadioButton();
            this.rbFreq_NAmerica = new System.Windows.Forms.RadioButton();
            this.rbFreq_China = new System.Windows.Forms.RadioButton();
            this.checkedlibFrePoint = new System.Windows.Forms.CheckedListBox();
            this.label66 = new System.Windows.Forms.Label();
            this.btnGetFrequency = new System.Windows.Forms.Button();
            this.lbFreqPoints = new System.Windows.Forms.Label();
            this.btnSetFrequency = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbTCPPara_GateWay = new System.Windows.Forms.TextBox();
            this.tbTCPPara_Mask = new System.Windows.Forms.TextBox();
            this.btnGetTCPPara = new System.Windows.Forms.Button();
            this.btnSetTCPPara = new System.Windows.Forms.Button();
            this.tbTCPPara_IP = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbIOLevel = new System.Windows.Forms.ComboBox();
            this.cbIOPort = new System.Windows.Forms.ComboBox();
            this.btnSetOutPort = new System.Windows.Forms.Button();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbMultiFastTagMode = new System.Windows.Forms.RadioButton();
            this.rbSingleFastTagMode = new System.Windows.Forms.RadioButton();
            this.btnGetTagMode = new System.Windows.Forms.Button();
            this.btnSetTagMode = new System.Windows.Forms.Button();
            this.btnResetReader = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetFirmVersion = new System.Windows.Forms.Button();
            this.lbFirmVersion = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.pbAnteStatus2 = new System.Windows.Forms.PictureBox();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.pbAnteStatus1 = new System.Windows.Forms.PictureBox();
            this.chbAnte2 = new System.Windows.Forms.CheckBox();
            this.chbAnte1 = new System.Windows.Forms.CheckBox();
            this.btnSetAnte = new System.Windows.Forms.Button();
            this.btnGetAnte = new System.Windows.Forms.Button();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPower2 = new System.Windows.Forms.TextBox();
            this.tbPower1 = new System.Windows.Forms.TextBox();
            this.btnSetPower = new System.Windows.Forms.Button();
            this.btnGetPower = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetBaudRate = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.cbSettings_BaudRate = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_EPCMultiTag = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.RfidTextBox = new System.Windows.Forms.TextBox();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.livGen2Identify = new MR6100Demo.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLoaned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kioskButton = new System.Windows.Forms.Button();
            this.gbEPCDataAnalysis = new System.Windows.Forms.GroupBox();
            this.lblTotalRequest = new System.Windows.Forms.Label();
            this.lblTotalRequestCaption = new System.Windows.Forms.Label();
            this.lbTestDuration = new System.Windows.Forms.Label();
            this.lbReadTimes = new System.Windows.Forms.Label();
            this.lbAverageRate = new System.Windows.Forms.Label();
            this.lbPeakRate = new System.Windows.Forms.Label();
            this.lbTotalReads = new System.Windows.Forms.Label();
            this.lbUniqueTags = new System.Windows.Forms.Label();
            this.lbTD = new System.Windows.Forms.Label();
            this.lbRT = new System.Windows.Forms.Label();
            this.lbAR = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDiscon = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerFreePrevTagID = new System.Windows.Forms.Timer(this.components);
            this.tabPage_Settings.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbConnect.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnteStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnteStatus1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_EPCMultiTag.SuspendLayout();
            this.gbEPCDataAnalysis.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // libInfo
            // 
            this.libInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.libInfo.FormattingEnabled = true;
            this.libInfo.HorizontalScrollbar = true;
            this.libInfo.ItemHeight = 16;
            this.libInfo.Location = new System.Drawing.Point(3, 152);
            this.libInfo.Name = "libInfo";
            this.libInfo.Size = new System.Drawing.Size(246, 484);
            this.libInfo.TabIndex = 2;
            this.libInfo.SelectedIndexChanged += new System.EventHandler(this.libInfo_SelectedIndexChanged);
            // 
            // timerGen2Identify
            // 
            this.timerGen2Identify.Interval = 10;
            this.timerGen2Identify.Tick += new System.EventHandler(this.timerInventory_Tick);
            // 
            // timerRate
            // 
            this.timerRate.Interval = 1000;
            this.timerRate.Tick += new System.EventHandler(this.timerRate_Tick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(3, 640);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(246, 39);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "پاک کردن";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timerReconnect
            // 
            this.timerReconnect.Interval = 3000;
            this.timerReconnect.Tick += new System.EventHandler(this.timerReconnect_Tick);
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabPage_Settings.Controls.Add(this.groupBox6);
            this.tabPage_Settings.Controls.Add(this.gbConnect);
            this.tabPage_Settings.Controls.Add(this.groupBox12);
            this.tabPage_Settings.Controls.Add(this.groupBox10);
            this.tabPage_Settings.Controls.Add(this.groupBox9);
            this.tabPage_Settings.Controls.Add(this.groupBox8);
            this.tabPage_Settings.Controls.Add(this.groupBox7);
            this.tabPage_Settings.Controls.Add(this.groupBox5);
            this.tabPage_Settings.Controls.Add(this.btnResetReader);
            this.tabPage_Settings.Controls.Add(this.groupBox2);
            this.tabPage_Settings.Controls.Add(this.groupBox4);
            this.tabPage_Settings.Controls.Add(this.groupBox3);
            this.tabPage_Settings.Controls.Add(this.groupBox1);
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Size = new System.Drawing.Size(991, 643);
            this.tabPage_Settings.TabIndex = 3;
            this.tabPage_Settings.Text = "تنظیمات";
            this.tabPage_Settings.Click += new System.EventHandler(this.tabPage_Settings_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.tbPort2);
            this.groupBox6.Controls.Add(this.tbIP2);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(273, 210);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(202, 173);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reader 2:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(110, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Tan;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(18, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbPort2
            // 
            this.tbPort2.Enabled = false;
            this.tbPort2.Location = new System.Drawing.Point(60, 76);
            this.tbPort2.Name = "tbPort2";
            this.tbPort2.Size = new System.Drawing.Size(127, 22);
            this.tbPort2.TabIndex = 2;
            this.tbPort2.Text = "100";
            this.tbPort2.TextChanged += new System.EventHandler(this.tbPort2_TextChanged);
            // 
            // tbIP2
            // 
            this.tbIP2.Location = new System.Drawing.Point(60, 39);
            this.tbIP2.Name = "tbIP2";
            this.tbIP2.Size = new System.Drawing.Size(127, 22);
            this.tbIP2.TabIndex = 2;
            this.tbIP2.Text = "192.168.137.19";
            this.tbIP2.TextChanged += new System.EventHandler(this.tbIP2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = " IP:";
            // 
            // gbConnect
            // 
            this.gbConnect.BackColor = System.Drawing.Color.CadetBlue;
            this.gbConnect.Controls.Add(this.button3);
            this.gbConnect.Controls.Add(this.tbPort);
            this.gbConnect.Controls.Add(this.button4);
            this.gbConnect.Controls.Add(this.tbIP);
            this.gbConnect.Controls.Add(this.label2);
            this.gbConnect.Controls.Add(this.label1);
            this.gbConnect.Location = new System.Drawing.Point(273, 20);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(202, 184);
            this.gbConnect.TabIndex = 10;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Reader 1:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Tan;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(104, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 46);
            this.button3.TabIndex = 12;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbPort
            // 
            this.tbPort.Enabled = false;
            this.tbPort.Location = new System.Drawing.Point(60, 75);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(127, 22);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "100";
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Tan;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(12, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 46);
            this.button4.TabIndex = 13;
            this.button4.Text = "Get";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(60, 38);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(127, 22);
            this.tbIP.TabIndex = 2;
            this.tbIP.Text = "192.168.137.18";
            this.tbIP.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = " IP:";
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox12.Controls.Add(this.password_database_info);
            this.groupBox12.Controls.Add(this.label11);
            this.groupBox12.Controls.Add(this.username_database_info);
            this.groupBox12.Controls.Add(this.label10);
            this.groupBox12.Controls.Add(this.name_database_info);
            this.groupBox12.Controls.Add(this.label8);
            this.groupBox12.Controls.Add(this.set_database);
            this.groupBox12.Controls.Add(this.ip_database_info);
            this.groupBox12.Controls.Add(this.get_database);
            this.groupBox12.Controls.Add(this.label7);
            this.groupBox12.Location = new System.Drawing.Point(247, 397);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(228, 236);
            this.groupBox12.TabIndex = 9;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Database Setting:";
            // 
            // password_database_info
            // 
            this.password_database_info.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_database_info.Location = new System.Drawing.Point(100, 108);
            this.password_database_info.Name = "password_database_info";
            this.password_database_info.Size = new System.Drawing.Size(99, 25);
            this.password_database_info.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(33, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 37;
            this.label11.Text = "password";
            // 
            // username_database_info
            // 
            this.username_database_info.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_database_info.Location = new System.Drawing.Point(100, 81);
            this.username_database_info.Name = "username_database_info";
            this.username_database_info.Size = new System.Drawing.Size(99, 25);
            this.username_database_info.TabIndex = 36;
            this.username_database_info.TextChanged += new System.EventHandler(this.username_database_info_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(30, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "user name";
            // 
            // name_database_info
            // 
            this.name_database_info.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_database_info.Location = new System.Drawing.Point(100, 54);
            this.name_database_info.Name = "name_database_info";
            this.name_database_info.Size = new System.Drawing.Size(99, 25);
            this.name_database_info.TabIndex = 34;
            this.name_database_info.TextChanged += new System.EventHandler(this.name_database_info_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Database name";
            // 
            // set_database
            // 
            this.set_database.BackColor = System.Drawing.Color.Tan;
            this.set_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.set_database.Location = new System.Drawing.Point(102, 157);
            this.set_database.Name = "set_database";
            this.set_database.Size = new System.Drawing.Size(86, 46);
            this.set_database.TabIndex = 2;
            this.set_database.Text = "Set";
            this.set_database.UseVisualStyleBackColor = false;
            this.set_database.Click += new System.EventHandler(this.set_database_Click);
            // 
            // ip_database_info
            // 
            this.ip_database_info.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_database_info.Location = new System.Drawing.Point(100, 24);
            this.ip_database_info.Name = "ip_database_info";
            this.ip_database_info.Size = new System.Drawing.Size(99, 25);
            this.ip_database_info.TabIndex = 30;
            this.ip_database_info.TextChanged += new System.EventHandler(this.ip_database_info_TextChanged);
            // 
            // get_database
            // 
            this.get_database.BackColor = System.Drawing.Color.Tan;
            this.get_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.get_database.Location = new System.Drawing.Point(9, 157);
            this.get_database.Name = "get_database";
            this.get_database.Size = new System.Drawing.Size(86, 46);
            this.get_database.TabIndex = 2;
            this.get_database.Text = "Get";
            this.get_database.UseVisualStyleBackColor = false;
            this.get_database.Click += new System.EventHandler(this.get_database_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(35, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "IP Server";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox10.Controls.Add(this.rbBuzzerOFF);
            this.groupBox10.Controls.Add(this.btnSetBuzzer);
            this.groupBox10.Controls.Add(this.btnGetBuzzer);
            this.groupBox10.Controls.Add(this.rbBuzzerON);
            this.groupBox10.Location = new System.Drawing.Point(15, 517);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(228, 116);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Buzzer and LED Setting";
            // 
            // rbBuzzerOFF
            // 
            this.rbBuzzerOFF.AutoSize = true;
            this.rbBuzzerOFF.Location = new System.Drawing.Point(100, 19);
            this.rbBuzzerOFF.Name = "rbBuzzerOFF";
            this.rbBuzzerOFF.Size = new System.Drawing.Size(54, 20);
            this.rbBuzzerOFF.TabIndex = 0;
            this.rbBuzzerOFF.Text = "OFF";
            this.rbBuzzerOFF.UseVisualStyleBackColor = true;
            this.rbBuzzerOFF.CheckedChanged += new System.EventHandler(this.rbBuzzerOFF_CheckedChanged);
            // 
            // btnSetBuzzer
            // 
            this.btnSetBuzzer.BackColor = System.Drawing.Color.Tan;
            this.btnSetBuzzer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBuzzer.Location = new System.Drawing.Point(100, 55);
            this.btnSetBuzzer.Name = "btnSetBuzzer";
            this.btnSetBuzzer.Size = new System.Drawing.Size(86, 46);
            this.btnSetBuzzer.TabIndex = 2;
            this.btnSetBuzzer.Text = "Set";
            this.btnSetBuzzer.UseVisualStyleBackColor = false;
            this.btnSetBuzzer.Click += new System.EventHandler(this.btnSetBuzzer_Click);
            // 
            // btnGetBuzzer
            // 
            this.btnGetBuzzer.BackColor = System.Drawing.Color.Tan;
            this.btnGetBuzzer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetBuzzer.Location = new System.Drawing.Point(7, 55);
            this.btnGetBuzzer.Name = "btnGetBuzzer";
            this.btnGetBuzzer.Size = new System.Drawing.Size(86, 46);
            this.btnGetBuzzer.TabIndex = 2;
            this.btnGetBuzzer.Text = "Get";
            this.btnGetBuzzer.UseVisualStyleBackColor = false;
            this.btnGetBuzzer.Click += new System.EventHandler(this.btnGetBuzzer_Click);
            // 
            // rbBuzzerON
            // 
            this.rbBuzzerON.AutoSize = true;
            this.rbBuzzerON.Checked = true;
            this.rbBuzzerON.Location = new System.Drawing.Point(17, 19);
            this.rbBuzzerON.Name = "rbBuzzerON";
            this.rbBuzzerON.Size = new System.Drawing.Size(48, 20);
            this.rbBuzzerON.TabIndex = 0;
            this.rbBuzzerON.TabStop = true;
            this.rbBuzzerON.Text = "ON";
            this.rbBuzzerON.UseVisualStyleBackColor = true;
            this.rbBuzzerON.CheckedChanged += new System.EventHandler(this.rbBuzzerON_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox9.Controls.Add(this.rbFreq_Others);
            this.groupBox9.Controls.Add(this.rbFreq_Europe);
            this.groupBox9.Controls.Add(this.rbFreq_NAmerica);
            this.groupBox9.Controls.Add(this.rbFreq_China);
            this.groupBox9.Controls.Add(this.checkedlibFrePoint);
            this.groupBox9.Controls.Add(this.label66);
            this.groupBox9.Controls.Add(this.btnGetFrequency);
            this.groupBox9.Controls.Add(this.lbFreqPoints);
            this.groupBox9.Controls.Add(this.btnSetFrequency);
            this.groupBox9.Location = new System.Drawing.Point(481, 15);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(382, 222);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Frequency Setting";
            // 
            // rbFreq_Others
            // 
            this.rbFreq_Others.AutoSize = true;
            this.rbFreq_Others.Location = new System.Drawing.Point(8, 161);
            this.rbFreq_Others.Name = "rbFreq_Others";
            this.rbFreq_Others.Size = new System.Drawing.Size(67, 20);
            this.rbFreq_Others.TabIndex = 4;
            this.rbFreq_Others.Text = "Others";
            this.rbFreq_Others.UseVisualStyleBackColor = true;
            this.rbFreq_Others.CheckedChanged += new System.EventHandler(this.rbFreq_Others_CheckedChanged);
            // 
            // rbFreq_Europe
            // 
            this.rbFreq_Europe.AutoSize = true;
            this.rbFreq_Europe.Location = new System.Drawing.Point(7, 122);
            this.rbFreq_Europe.Name = "rbFreq_Europe";
            this.rbFreq_Europe.Size = new System.Drawing.Size(72, 20);
            this.rbFreq_Europe.TabIndex = 4;
            this.rbFreq_Europe.Text = "Europe";
            this.rbFreq_Europe.UseVisualStyleBackColor = true;
            // 
            // rbFreq_NAmerica
            // 
            this.rbFreq_NAmerica.AutoSize = true;
            this.rbFreq_NAmerica.Location = new System.Drawing.Point(7, 86);
            this.rbFreq_NAmerica.Name = "rbFreq_NAmerica";
            this.rbFreq_NAmerica.Size = new System.Drawing.Size(113, 20);
            this.rbFreq_NAmerica.TabIndex = 4;
            this.rbFreq_NAmerica.Text = "North America";
            this.rbFreq_NAmerica.UseVisualStyleBackColor = true;
            // 
            // rbFreq_China
            // 
            this.rbFreq_China.AutoSize = true;
            this.rbFreq_China.Checked = true;
            this.rbFreq_China.Location = new System.Drawing.Point(7, 48);
            this.rbFreq_China.Name = "rbFreq_China";
            this.rbFreq_China.Size = new System.Drawing.Size(62, 20);
            this.rbFreq_China.TabIndex = 4;
            this.rbFreq_China.TabStop = true;
            this.rbFreq_China.Text = "China";
            this.rbFreq_China.UseVisualStyleBackColor = true;
            // 
            // checkedlibFrePoint
            // 
            this.checkedlibFrePoint.FormattingEnabled = true;
            this.checkedlibFrePoint.Items.AddRange(new object[] {
            "900",
            "900.5",
            "901",
            "901.5",
            "902",
            "902.5",
            "903",
            "903.5",
            "904",
            "904.5",
            "905",
            "905.5",
            "906",
            "906.5",
            "907",
            "907.5",
            "908",
            "908.5",
            "909",
            "909.5",
            "910",
            "910.5",
            "911",
            "911.5",
            "912",
            "912.5",
            "913",
            "913.5",
            "914",
            "914.5",
            "915",
            "915.5",
            "916",
            "916.5",
            "917",
            "917.5",
            "918",
            "918.5",
            "919",
            "919.5",
            "920",
            "920.5",
            "921",
            "921.5",
            "922",
            "922.5",
            "923",
            "923.5",
            "924",
            "924.5",
            "925",
            "925.5",
            "926",
            "926.5",
            "927",
            "927.5",
            "928",
            "928.5",
            "929",
            "929.5",
            "930"});
            this.checkedlibFrePoint.Location = new System.Drawing.Point(109, 38);
            this.checkedlibFrePoint.Name = "checkedlibFrePoint";
            this.checkedlibFrePoint.Size = new System.Drawing.Size(94, 157);
            this.checkedlibFrePoint.TabIndex = 3;
            this.checkedlibFrePoint.Visible = false;
            this.checkedlibFrePoint.SelectedIndexChanged += new System.EventHandler(this.checkedlibFrePoint_SelectedIndexChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(5, 18);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(109, 16);
            this.label66.TabIndex = 1;
            this.label66.Text = "Frequency Type:";
            // 
            // btnGetFrequency
            // 
            this.btnGetFrequency.BackColor = System.Drawing.Color.Tan;
            this.btnGetFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetFrequency.Location = new System.Drawing.Point(253, 48);
            this.btnGetFrequency.Name = "btnGetFrequency";
            this.btnGetFrequency.Size = new System.Drawing.Size(86, 46);
            this.btnGetFrequency.TabIndex = 2;
            this.btnGetFrequency.Text = "Get";
            this.btnGetFrequency.UseVisualStyleBackColor = false;
            this.btnGetFrequency.Click += new System.EventHandler(this.btnGetFrequency_Click);
            // 
            // lbFreqPoints
            // 
            this.lbFreqPoints.AutoSize = true;
            this.lbFreqPoints.Location = new System.Drawing.Point(118, 21);
            this.lbFreqPoints.Name = "lbFreqPoints";
            this.lbFreqPoints.Size = new System.Drawing.Size(78, 16);
            this.lbFreqPoints.TabIndex = 1;
            this.lbFreqPoints.Text = "Freq Points:";
            this.lbFreqPoints.Visible = false;
            this.lbFreqPoints.Click += new System.EventHandler(this.lbFreqPoints_Click);
            // 
            // btnSetFrequency
            // 
            this.btnSetFrequency.BackColor = System.Drawing.Color.Tan;
            this.btnSetFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetFrequency.Location = new System.Drawing.Point(253, 125);
            this.btnSetFrequency.Name = "btnSetFrequency";
            this.btnSetFrequency.Size = new System.Drawing.Size(86, 46);
            this.btnSetFrequency.TabIndex = 2;
            this.btnSetFrequency.Text = "Set";
            this.btnSetFrequency.UseVisualStyleBackColor = false;
            this.btnSetFrequency.Click += new System.EventHandler(this.btnSetFrequency_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox8.Controls.Add(this.tbTCPPara_GateWay);
            this.groupBox8.Controls.Add(this.tbTCPPara_Mask);
            this.groupBox8.Controls.Add(this.btnGetTCPPara);
            this.groupBox8.Controls.Add(this.btnSetTCPPara);
            this.groupBox8.Controls.Add(this.tbTCPPara_IP);
            this.groupBox8.Controls.Add(this.label63);
            this.groupBox8.Controls.Add(this.label62);
            this.groupBox8.Controls.Add(this.label61);
            this.groupBox8.Location = new System.Drawing.Point(481, 254);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(382, 161);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "TCP Parameter Setting";
            // 
            // tbTCPPara_GateWay
            // 
            this.tbTCPPara_GateWay.Location = new System.Drawing.Point(89, 118);
            this.tbTCPPara_GateWay.Name = "tbTCPPara_GateWay";
            this.tbTCPPara_GateWay.Size = new System.Drawing.Size(138, 22);
            this.tbTCPPara_GateWay.TabIndex = 2;
            this.tbTCPPara_GateWay.TextChanged += new System.EventHandler(this.tbTCPPara_GateWay_TextChanged);
            // 
            // tbTCPPara_Mask
            // 
            this.tbTCPPara_Mask.Location = new System.Drawing.Point(89, 77);
            this.tbTCPPara_Mask.Name = "tbTCPPara_Mask";
            this.tbTCPPara_Mask.Size = new System.Drawing.Size(138, 22);
            this.tbTCPPara_Mask.TabIndex = 2;
            this.tbTCPPara_Mask.TextChanged += new System.EventHandler(this.tbTCPPara_Mask_TextChanged);
            // 
            // btnGetTCPPara
            // 
            this.btnGetTCPPara.BackColor = System.Drawing.Color.Tan;
            this.btnGetTCPPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetTCPPara.Location = new System.Drawing.Point(253, 36);
            this.btnGetTCPPara.Name = "btnGetTCPPara";
            this.btnGetTCPPara.Size = new System.Drawing.Size(86, 46);
            this.btnGetTCPPara.TabIndex = 2;
            this.btnGetTCPPara.Text = "Get";
            this.btnGetTCPPara.UseVisualStyleBackColor = false;
            this.btnGetTCPPara.Click += new System.EventHandler(this.btnGetTCPPara_Click);
            // 
            // btnSetTCPPara
            // 
            this.btnSetTCPPara.BackColor = System.Drawing.Color.Tan;
            this.btnSetTCPPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetTCPPara.Location = new System.Drawing.Point(253, 98);
            this.btnSetTCPPara.Name = "btnSetTCPPara";
            this.btnSetTCPPara.Size = new System.Drawing.Size(86, 46);
            this.btnSetTCPPara.TabIndex = 2;
            this.btnSetTCPPara.Text = "Set";
            this.btnSetTCPPara.UseVisualStyleBackColor = false;
            this.btnSetTCPPara.Click += new System.EventHandler(this.btnSetTCPPara_Click);
            // 
            // tbTCPPara_IP
            // 
            this.tbTCPPara_IP.Location = new System.Drawing.Point(89, 36);
            this.tbTCPPara_IP.MaxLength = 16;
            this.tbTCPPara_IP.Name = "tbTCPPara_IP";
            this.tbTCPPara_IP.Size = new System.Drawing.Size(138, 22);
            this.tbTCPPara_IP.TabIndex = 2;
            this.tbTCPPara_IP.TextChanged += new System.EventHandler(this.tbTCPPara_IP_TextChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(30, 124);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(67, 16);
            this.label63.TabIndex = 1;
            this.label63.Text = "GateWay:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(6, 82);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(88, 16);
            this.label62.TabIndex = 1;
            this.label62.Text = "Subnet Mask:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(60, 40);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(22, 16);
            this.label61.TabIndex = 1;
            this.label61.Text = "IP:";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox7.Controls.Add(this.cbIOLevel);
            this.groupBox7.Controls.Add(this.cbIOPort);
            this.groupBox7.Controls.Add(this.btnSetOutPort);
            this.groupBox7.Controls.Add(this.label60);
            this.groupBox7.Controls.Add(this.label59);
            this.groupBox7.Location = new System.Drawing.Point(481, 442);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(382, 108);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "OutPort Setting";
            // 
            // cbIOLevel
            // 
            this.cbIOLevel.FormattingEnabled = true;
            this.cbIOLevel.Items.AddRange(new object[] {
            "Low/OFF",
            "High/ON"});
            this.cbIOLevel.Location = new System.Drawing.Point(89, 68);
            this.cbIOLevel.Name = "cbIOLevel";
            this.cbIOLevel.Size = new System.Drawing.Size(76, 24);
            this.cbIOLevel.TabIndex = 3;
            // 
            // cbIOPort
            // 
            this.cbIOPort.FormattingEnabled = true;
            this.cbIOPort.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cbIOPort.Location = new System.Drawing.Point(89, 28);
            this.cbIOPort.Name = "cbIOPort";
            this.cbIOPort.Size = new System.Drawing.Size(76, 24);
            this.cbIOPort.TabIndex = 3;
            this.cbIOPort.SelectedIndexChanged += new System.EventHandler(this.cbIOPort_SelectedIndexChanged);
            // 
            // btnSetOutPort
            // 
            this.btnSetOutPort.BackColor = System.Drawing.Color.Tan;
            this.btnSetOutPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOutPort.Location = new System.Drawing.Point(253, 38);
            this.btnSetOutPort.Name = "btnSetOutPort";
            this.btnSetOutPort.Size = new System.Drawing.Size(86, 46);
            this.btnSetOutPort.TabIndex = 2;
            this.btnSetOutPort.Text = "Set";
            this.btnSetOutPort.UseVisualStyleBackColor = false;
            this.btnSetOutPort.Click += new System.EventHandler(this.btnSetOutPort_Click);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(42, 70);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(43, 16);
            this.label60.TabIndex = 1;
            this.label60.Text = "Level:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(30, 31);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(50, 16);
            this.label59.TabIndex = 1;
            this.label59.Text = "IO Port:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox5.Controls.Add(this.rbMultiFastTagMode);
            this.groupBox5.Controls.Add(this.rbSingleFastTagMode);
            this.groupBox5.Controls.Add(this.btnGetTagMode);
            this.groupBox5.Controls.Add(this.btnSetTagMode);
            this.groupBox5.Location = new System.Drawing.Point(15, 397);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(228, 114);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Working Mode Setting";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // rbMultiFastTagMode
            // 
            this.rbMultiFastTagMode.AutoSize = true;
            this.rbMultiFastTagMode.Location = new System.Drawing.Point(123, 28);
            this.rbMultiFastTagMode.Name = "rbMultiFastTagMode";
            this.rbMultiFastTagMode.Size = new System.Drawing.Size(112, 20);
            this.rbMultiFastTagMode.TabIndex = 0;
            this.rbMultiFastTagMode.Text = "Favor quantity";
            this.rbMultiFastTagMode.UseVisualStyleBackColor = true;
            this.rbMultiFastTagMode.CheckedChanged += new System.EventHandler(this.rbMultiFastTagMode_CheckedChanged);
            // 
            // rbSingleFastTagMode
            // 
            this.rbSingleFastTagMode.AutoSize = true;
            this.rbSingleFastTagMode.Checked = true;
            this.rbSingleFastTagMode.Location = new System.Drawing.Point(17, 29);
            this.rbSingleFastTagMode.Name = "rbSingleFastTagMode";
            this.rbSingleFastTagMode.Size = new System.Drawing.Size(105, 20);
            this.rbSingleFastTagMode.TabIndex = 0;
            this.rbSingleFastTagMode.TabStop = true;
            this.rbSingleFastTagMode.Text = "Favor speed";
            this.rbSingleFastTagMode.UseVisualStyleBackColor = true;
            this.rbSingleFastTagMode.CheckedChanged += new System.EventHandler(this.rbSingleFastTagMode_CheckedChanged);
            // 
            // btnGetTagMode
            // 
            this.btnGetTagMode.BackColor = System.Drawing.Color.Tan;
            this.btnGetTagMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetTagMode.Location = new System.Drawing.Point(23, 54);
            this.btnGetTagMode.Name = "btnGetTagMode";
            this.btnGetTagMode.Size = new System.Drawing.Size(86, 46);
            this.btnGetTagMode.TabIndex = 2;
            this.btnGetTagMode.Text = "Get";
            this.btnGetTagMode.UseVisualStyleBackColor = false;
            this.btnGetTagMode.Click += new System.EventHandler(this.btnGetTagMode_Click);
            // 
            // btnSetTagMode
            // 
            this.btnSetTagMode.BackColor = System.Drawing.Color.Tan;
            this.btnSetTagMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetTagMode.Location = new System.Drawing.Point(127, 54);
            this.btnSetTagMode.Name = "btnSetTagMode";
            this.btnSetTagMode.Size = new System.Drawing.Size(86, 46);
            this.btnSetTagMode.TabIndex = 2;
            this.btnSetTagMode.Text = "Set";
            this.btnSetTagMode.UseVisualStyleBackColor = false;
            this.btnSetTagMode.Click += new System.EventHandler(this.btnSetTagMode_Click);
            // 
            // btnResetReader
            // 
            this.btnResetReader.BackColor = System.Drawing.Color.Tan;
            this.btnResetReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetReader.Location = new System.Drawing.Point(634, 567);
            this.btnResetReader.Name = "btnResetReader";
            this.btnResetReader.Size = new System.Drawing.Size(120, 56);
            this.btnResetReader.TabIndex = 2;
            this.btnResetReader.Text = "ReSet Reader";
            this.btnResetReader.UseVisualStyleBackColor = false;
            this.btnResetReader.Click += new System.EventHandler(this.btnResetReader_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox2.Controls.Add(this.btnGetFirmVersion);
            this.groupBox2.Controls.Add(this.lbFirmVersion);
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Location = new System.Drawing.Point(13, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Get Firmware Version";
            // 
            // btnGetFirmVersion
            // 
            this.btnGetFirmVersion.BackColor = System.Drawing.Color.Tan;
            this.btnGetFirmVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetFirmVersion.Location = new System.Drawing.Point(153, 22);
            this.btnGetFirmVersion.Name = "btnGetFirmVersion";
            this.btnGetFirmVersion.Size = new System.Drawing.Size(86, 46);
            this.btnGetFirmVersion.TabIndex = 2;
            this.btnGetFirmVersion.Text = "Get";
            this.btnGetFirmVersion.UseVisualStyleBackColor = false;
            this.btnGetFirmVersion.Click += new System.EventHandler(this.btnGetFirmVersion_Click);
            // 
            // lbFirmVersion
            // 
            this.lbFirmVersion.AutoSize = true;
            this.lbFirmVersion.Location = new System.Drawing.Point(120, 34);
            this.lbFirmVersion.Name = "lbFirmVersion";
            this.lbFirmVersion.Size = new System.Drawing.Size(24, 16);
            this.lbFirmVersion.TabIndex = 1;
            this.lbFirmVersion.Text = "1.0";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(40, 34);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(82, 16);
            this.label51.TabIndex = 1;
            this.label51.Text = "FirmVersion:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox4.Controls.Add(this.pbGreen);
            this.groupBox4.Controls.Add(this.pbAnteStatus2);
            this.groupBox4.Controls.Add(this.pbRed);
            this.groupBox4.Controls.Add(this.pbAnteStatus1);
            this.groupBox4.Controls.Add(this.chbAnte2);
            this.groupBox4.Controls.Add(this.chbAnte1);
            this.groupBox4.Controls.Add(this.btnSetAnte);
            this.groupBox4.Controls.Add(this.btnGetAnte);
            this.groupBox4.Controls.Add(this.label65);
            this.groupBox4.Controls.Add(this.label64);
            this.groupBox4.Location = new System.Drawing.Point(13, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 155);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Antennas  Setting";
            // 
            // pbGreen
            // 
            this.pbGreen.BackgroundImage = global::MR6100Demo.Properties.Resources.green;
            this.pbGreen.Location = new System.Drawing.Point(221, 106);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(27, 28);
            this.pbGreen.TabIndex = 10;
            this.pbGreen.TabStop = false;
            this.pbGreen.Visible = false;
            this.pbGreen.Click += new System.EventHandler(this.pbGreen_Click);
            // 
            // pbAnteStatus2
            // 
            this.pbAnteStatus2.BackgroundImage = global::MR6100Demo.Properties.Resources.red;
            this.pbAnteStatus2.Location = new System.Drawing.Point(176, 55);
            this.pbAnteStatus2.Name = "pbAnteStatus2";
            this.pbAnteStatus2.Size = new System.Drawing.Size(27, 28);
            this.pbAnteStatus2.TabIndex = 4;
            this.pbAnteStatus2.TabStop = false;
            // 
            // pbRed
            // 
            this.pbRed.BackgroundImage = global::MR6100Demo.Properties.Resources.red;
            this.pbRed.Location = new System.Drawing.Point(221, 72);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(27, 28);
            this.pbRed.TabIndex = 11;
            this.pbRed.TabStop = false;
            this.pbRed.Visible = false;
            // 
            // pbAnteStatus1
            // 
            this.pbAnteStatus1.BackgroundImage = global::MR6100Demo.Properties.Resources.red;
            this.pbAnteStatus1.Location = new System.Drawing.Point(89, 55);
            this.pbAnteStatus1.Name = "pbAnteStatus1";
            this.pbAnteStatus1.Size = new System.Drawing.Size(27, 28);
            this.pbAnteStatus1.TabIndex = 4;
            this.pbAnteStatus1.TabStop = false;
            this.pbAnteStatus1.Click += new System.EventHandler(this.pbAnteStatus1_Click);
            // 
            // chbAnte2
            // 
            this.chbAnte2.AutoSize = true;
            this.chbAnte2.Location = new System.Drawing.Point(176, 29);
            this.chbAnte2.Name = "chbAnte2";
            this.chbAnte2.Size = new System.Drawing.Size(63, 20);
            this.chbAnte2.TabIndex = 3;
            this.chbAnte2.Text = "Ante2";
            this.chbAnte2.UseVisualStyleBackColor = true;
            this.chbAnte2.CheckedChanged += new System.EventHandler(this.chbAnte2_CheckedChanged);
            // 
            // chbAnte1
            // 
            this.chbAnte1.AutoSize = true;
            this.chbAnte1.Location = new System.Drawing.Point(89, 29);
            this.chbAnte1.Name = "chbAnte1";
            this.chbAnte1.Size = new System.Drawing.Size(63, 20);
            this.chbAnte1.TabIndex = 3;
            this.chbAnte1.Text = "Ante1";
            this.chbAnte1.UseVisualStyleBackColor = true;
            this.chbAnte1.CheckedChanged += new System.EventHandler(this.chbAnte1_CheckedChanged);
            // 
            // btnSetAnte
            // 
            this.btnSetAnte.BackColor = System.Drawing.Color.Tan;
            this.btnSetAnte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetAnte.Location = new System.Drawing.Point(124, 92);
            this.btnSetAnte.Name = "btnSetAnte";
            this.btnSetAnte.Size = new System.Drawing.Size(86, 46);
            this.btnSetAnte.TabIndex = 2;
            this.btnSetAnte.Text = "Set";
            this.btnSetAnte.UseVisualStyleBackColor = false;
            this.btnSetAnte.Click += new System.EventHandler(this.btnSetAnte_Click);
            // 
            // btnGetAnte
            // 
            this.btnGetAnte.BackColor = System.Drawing.Color.Tan;
            this.btnGetAnte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAnte.Location = new System.Drawing.Point(9, 92);
            this.btnGetAnte.Name = "btnGetAnte";
            this.btnGetAnte.Size = new System.Drawing.Size(86, 46);
            this.btnGetAnte.TabIndex = 2;
            this.btnGetAnte.Text = "Get";
            this.btnGetAnte.UseVisualStyleBackColor = false;
            this.btnGetAnte.Click += new System.EventHandler(this.btnGetAnte_Click);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(4, 66);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(77, 16);
            this.label65.TabIndex = 1;
            this.label65.Text = "Ante Status:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(16, 34);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(72, 16);
            this.label64.TabIndex = 1;
            this.label64.Text = "Work Ante:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox3.Controls.Add(this.tbPower2);
            this.groupBox3.Controls.Add(this.tbPower1);
            this.groupBox3.Controls.Add(this.btnSetPower);
            this.groupBox3.Controls.Add(this.btnGetPower);
            this.groupBox3.Controls.Add(this.label54);
            this.groupBox3.Controls.Add(this.label53);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.label52);
            this.groupBox3.Location = new System.Drawing.Point(13, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 118);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Power Setting";
            // 
            // tbPower2
            // 
            this.tbPower2.Location = new System.Drawing.Point(150, 22);
            this.tbPower2.Name = "tbPower2";
            this.tbPower2.Size = new System.Drawing.Size(38, 22);
            this.tbPower2.TabIndex = 3;
            this.tbPower2.TextChanged += new System.EventHandler(this.tbPower2_TextChanged);
            // 
            // tbPower1
            // 
            this.tbPower1.Location = new System.Drawing.Point(42, 22);
            this.tbPower1.Name = "tbPower1";
            this.tbPower1.Size = new System.Drawing.Size(38, 22);
            this.tbPower1.TabIndex = 3;
            this.tbPower1.TextChanged += new System.EventHandler(this.tbPower1_TextChanged);
            // 
            // btnSetPower
            // 
            this.btnSetPower.BackColor = System.Drawing.Color.Tan;
            this.btnSetPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPower.Location = new System.Drawing.Point(102, 59);
            this.btnSetPower.Name = "btnSetPower";
            this.btnSetPower.Size = new System.Drawing.Size(86, 46);
            this.btnSetPower.TabIndex = 2;
            this.btnSetPower.Text = "Set";
            this.btnSetPower.UseVisualStyleBackColor = false;
            this.btnSetPower.Click += new System.EventHandler(this.btnSetPower_Click);
            // 
            // btnGetPower
            // 
            this.btnGetPower.BackColor = System.Drawing.Color.Tan;
            this.btnGetPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPower.Location = new System.Drawing.Point(9, 59);
            this.btnGetPower.Name = "btnGetPower";
            this.btnGetPower.Size = new System.Drawing.Size(86, 46);
            this.btnGetPower.TabIndex = 2;
            this.btnGetPower.Text = "Get";
            this.btnGetPower.UseVisualStyleBackColor = false;
            this.btnGetPower.Click += new System.EventHandler(this.btnGetPower_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(187, 26);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(35, 16);
            this.label54.TabIndex = 1;
            this.label54.Text = "dBm";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(113, 26);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(44, 16);
            this.label53.TabIndex = 1;
            this.label53.Text = "Ante2:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(83, 26);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(35, 16);
            this.label50.TabIndex = 1;
            this.label50.Text = "dBm";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(5, 26);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(44, 16);
            this.label52.TabIndex = 1;
            this.label52.Text = "Ante1:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetBaudRate);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.cbSettings_BaudRate);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BaudRate Setting";
            this.groupBox1.Visible = false;
            // 
            // btnSetBaudRate
            // 
            this.btnSetBaudRate.BackColor = System.Drawing.Color.Tan;
            this.btnSetBaudRate.Enabled = false;
            this.btnSetBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBaudRate.Location = new System.Drawing.Point(148, 17);
            this.btnSetBaudRate.Name = "btnSetBaudRate";
            this.btnSetBaudRate.Size = new System.Drawing.Size(62, 46);
            this.btnSetBaudRate.TabIndex = 2;
            this.btnSetBaudRate.Text = "Set";
            this.btnSetBaudRate.UseVisualStyleBackColor = false;
            this.btnSetBaudRate.Click += new System.EventHandler(this.btnSetBaudRate_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(123, 34);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(30, 16);
            this.label49.TabIndex = 1;
            this.label49.Text = "bps";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 34);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 16);
            this.label48.TabIndex = 1;
            this.label48.Text = "BaudRate:";
            // 
            // cbSettings_BaudRate
            // 
            this.cbSettings_BaudRate.FormattingEnabled = true;
            this.cbSettings_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbSettings_BaudRate.Location = new System.Drawing.Point(65, 30);
            this.cbSettings_BaudRate.Name = "cbSettings_BaudRate";
            this.cbSettings_BaudRate.Size = new System.Drawing.Size(58, 24);
            this.cbSettings_BaudRate.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_EPCMultiTag);
            this.tabControl.Controls.Add(this.tabPage_Settings);
            this.tabControl.Location = new System.Drawing.Point(252, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(999, 672);
            this.tabControl.TabIndex = 0;
            this.tabControl.Tag = "";
            // 
            // tabPage_EPCMultiTag
            // 
            this.tabPage_EPCMultiTag.AutoScroll = true;
            this.tabPage_EPCMultiTag.Controls.Add(this.button6);
            this.tabPage_EPCMultiTag.Controls.Add(this.RfidTextBox);
            this.tabPage_EPCMultiTag.Controls.Add(this.inventoryButton);
            this.tabPage_EPCMultiTag.Controls.Add(this.button7);
            this.tabPage_EPCMultiTag.Controls.Add(this.livGen2Identify);
            this.tabPage_EPCMultiTag.Controls.Add(this.kioskButton);
            this.tabPage_EPCMultiTag.Controls.Add(this.gbEPCDataAnalysis);
            this.tabPage_EPCMultiTag.Location = new System.Drawing.Point(4, 25);
            this.tabPage_EPCMultiTag.Name = "tabPage_EPCMultiTag";
            this.tabPage_EPCMultiTag.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_EPCMultiTag.Size = new System.Drawing.Size(991, 643);
            this.tabPage_EPCMultiTag.TabIndex = 0;
            this.tabPage_EPCMultiTag.Text = "شناسایی تگ";
            this.tabPage_EPCMultiTag.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.NavajoWhite;
            this.button6.Location = new System.Drawing.Point(786, 563);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(199, 46);
            this.button6.TabIndex = 8;
            this.button6.Text = "بررسی آیدی تگ";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // RfidTextBox
            // 
            this.RfidTextBox.Location = new System.Drawing.Point(786, 615);
            this.RfidTextBox.Name = "RfidTextBox";
            this.RfidTextBox.Size = new System.Drawing.Size(199, 22);
            this.RfidTextBox.TabIndex = 10;
            this.RfidTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // inventoryButton
            // 
            this.inventoryButton.BackColor = System.Drawing.Color.Turquoise;
            this.inventoryButton.ForeColor = System.Drawing.Color.Black;
            this.inventoryButton.Location = new System.Drawing.Point(885, 492);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(100, 60);
            this.inventoryButton.TabIndex = 11;
            this.inventoryButton.Text = "انبار داری";
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.RosyBrown;
            this.button7.Location = new System.Drawing.Point(29, 484);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 127);
            this.button7.TabIndex = 9;
            this.button7.Text = "نمایش لیست کتاب ها";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // livGen2Identify
            // 
            this.livGen2Identify.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeaderBookCode,
            this.columnHeader3,
            this.columnHeader21,
            this.columnHeader4,
            this.columnHeaderLoaned});
            this.livGen2Identify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.livGen2Identify.FullRowSelect = true;
            this.livGen2Identify.HideSelection = false;
            this.livGen2Identify.Location = new System.Drawing.Point(29, 13);
            this.livGen2Identify.Name = "livGen2Identify";
            this.livGen2Identify.RightToLeftLayout = true;
            this.livGen2Identify.Size = new System.Drawing.Size(956, 465);
            this.livGen2Identify.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.livGen2Identify.TabIndex = 4;
            this.livGen2Identify.UseCompatibleStateImageBehavior = false;
            this.livGen2Identify.View = System.Windows.Forms.View.Details;
            this.livGen2Identify.SelectedIndexChanged += new System.EventHandler(this.livGen2Identify_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ردیف";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "عنوان کتاب";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 240;
            // 
            // columnHeaderBookCode
            // 
            this.columnHeaderBookCode.Text = "شماره جلد";
            this.columnHeaderBookCode.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "تاریخ انتشار";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "کد کتاب";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader21.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "کد تگ";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 266;
            // 
            // columnHeaderLoaned
            // 
            this.columnHeaderLoaned.Text = "وضعیت امانت";
            this.columnHeaderLoaned.Width = 100;
            // 
            // kioskButton
            // 
            this.kioskButton.BackColor = System.Drawing.Color.Khaki;
            this.kioskButton.Location = new System.Drawing.Point(786, 492);
            this.kioskButton.Name = "kioskButton";
            this.kioskButton.Size = new System.Drawing.Size(93, 60);
            this.kioskButton.TabIndex = 7;
            this.kioskButton.Text = "کیوسک";
            this.kioskButton.UseVisualStyleBackColor = false;
            this.kioskButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // gbEPCDataAnalysis
            // 
            this.gbEPCDataAnalysis.Controls.Add(this.lblTotalRequest);
            this.gbEPCDataAnalysis.Controls.Add(this.lblTotalRequestCaption);
            this.gbEPCDataAnalysis.Controls.Add(this.lbTestDuration);
            this.gbEPCDataAnalysis.Controls.Add(this.lbReadTimes);
            this.gbEPCDataAnalysis.Controls.Add(this.lbAverageRate);
            this.gbEPCDataAnalysis.Controls.Add(this.lbPeakRate);
            this.gbEPCDataAnalysis.Controls.Add(this.lbTotalReads);
            this.gbEPCDataAnalysis.Controls.Add(this.lbUniqueTags);
            this.gbEPCDataAnalysis.Controls.Add(this.lbTD);
            this.gbEPCDataAnalysis.Controls.Add(this.lbRT);
            this.gbEPCDataAnalysis.Controls.Add(this.lbAR);
            this.gbEPCDataAnalysis.Controls.Add(this.label9);
            this.gbEPCDataAnalysis.Controls.Add(this.label5);
            this.gbEPCDataAnalysis.Controls.Add(this.label3);
            this.gbEPCDataAnalysis.Location = new System.Drawing.Point(96, 484);
            this.gbEPCDataAnalysis.Name = "gbEPCDataAnalysis";
            this.gbEPCDataAnalysis.Size = new System.Drawing.Size(682, 127);
            this.gbEPCDataAnalysis.TabIndex = 6;
            this.gbEPCDataAnalysis.TabStop = false;
            this.gbEPCDataAnalysis.Text = "Data Analysis";
            // 
            // lblTotalRequest
            // 
            this.lblTotalRequest.AutoSize = true;
            this.lblTotalRequest.Location = new System.Drawing.Point(644, 30);
            this.lblTotalRequest.Name = "lblTotalRequest";
            this.lblTotalRequest.Size = new System.Drawing.Size(14, 16);
            this.lblTotalRequest.TabIndex = 3;
            this.lblTotalRequest.Text = "0";
            // 
            // lblTotalRequestCaption
            // 
            this.lblTotalRequestCaption.AutoSize = true;
            this.lblTotalRequestCaption.Location = new System.Drawing.Point(553, 30);
            this.lblTotalRequestCaption.Name = "lblTotalRequestCaption";
            this.lblTotalRequestCaption.Size = new System.Drawing.Size(111, 16);
            this.lblTotalRequestCaption.TabIndex = 2;
            this.lblTotalRequestCaption.Text = "Total api request:";
            // 
            // lbTestDuration
            // 
            this.lbTestDuration.AutoSize = true;
            this.lbTestDuration.Location = new System.Drawing.Point(469, 79);
            this.lbTestDuration.Name = "lbTestDuration";
            this.lbTestDuration.Size = new System.Drawing.Size(14, 16);
            this.lbTestDuration.TabIndex = 1;
            this.lbTestDuration.Text = "0";
            // 
            // lbReadTimes
            // 
            this.lbReadTimes.AutoSize = true;
            this.lbReadTimes.Location = new System.Drawing.Point(469, 30);
            this.lbReadTimes.Name = "lbReadTimes";
            this.lbReadTimes.Size = new System.Drawing.Size(14, 16);
            this.lbReadTimes.TabIndex = 1;
            this.lbReadTimes.Text = "0";
            // 
            // lbAverageRate
            // 
            this.lbAverageRate.AutoSize = true;
            this.lbAverageRate.Location = new System.Drawing.Point(288, 79);
            this.lbAverageRate.Name = "lbAverageRate";
            this.lbAverageRate.Size = new System.Drawing.Size(14, 16);
            this.lbAverageRate.TabIndex = 1;
            this.lbAverageRate.Text = "0";
            // 
            // lbPeakRate
            // 
            this.lbPeakRate.AutoSize = true;
            this.lbPeakRate.Location = new System.Drawing.Point(288, 30);
            this.lbPeakRate.Name = "lbPeakRate";
            this.lbPeakRate.Size = new System.Drawing.Size(14, 16);
            this.lbPeakRate.TabIndex = 1;
            this.lbPeakRate.Text = "0";
            // 
            // lbTotalReads
            // 
            this.lbTotalReads.AutoSize = true;
            this.lbTotalReads.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalReads.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbTotalReads.Location = new System.Drawing.Point(110, 74);
            this.lbTotalReads.Name = "lbTotalReads";
            this.lbTotalReads.Size = new System.Drawing.Size(26, 25);
            this.lbTotalReads.TabIndex = 1;
            this.lbTotalReads.Text = "0";
            // 
            // lbUniqueTags
            // 
            this.lbUniqueTags.AutoSize = true;
            this.lbUniqueTags.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUniqueTags.ForeColor = System.Drawing.Color.Red;
            this.lbUniqueTags.Location = new System.Drawing.Point(111, 23);
            this.lbUniqueTags.Name = "lbUniqueTags";
            this.lbUniqueTags.Size = new System.Drawing.Size(29, 30);
            this.lbUniqueTags.TabIndex = 1;
            this.lbUniqueTags.Text = "0";
            // 
            // lbTD
            // 
            this.lbTD.AutoSize = true;
            this.lbTD.Location = new System.Drawing.Point(378, 79);
            this.lbTD.Name = "lbTD";
            this.lbTD.Size = new System.Drawing.Size(90, 16);
            this.lbTD.TabIndex = 0;
            this.lbTD.Text = "Test Duration:";
            // 
            // lbRT
            // 
            this.lbRT.AutoSize = true;
            this.lbRT.Location = new System.Drawing.Point(378, 30);
            this.lbRT.Name = "lbRT";
            this.lbRT.Size = new System.Drawing.Size(85, 16);
            this.lbRT.TabIndex = 0;
            this.lbRT.Text = "Read Times:";
            // 
            // lbAR
            // 
            this.lbAR.AutoSize = true;
            this.lbAR.Location = new System.Drawing.Point(198, 79);
            this.lbAR.Name = "lbAR";
            this.lbAR.Size = new System.Drawing.Size(94, 16);
            this.lbAR.TabIndex = 0;
            this.lbAR.Text = "Average Rate:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total Reads:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Peak Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unique Tags:";
            // 
            // btnDiscon
            // 
            this.btnDiscon.BackColor = System.Drawing.Color.LightPink;
            this.btnDiscon.Enabled = false;
            this.btnDiscon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDiscon.Location = new System.Drawing.Point(22, 19);
            this.btnDiscon.Name = "btnDiscon";
            this.btnDiscon.Size = new System.Drawing.Size(82, 41);
            this.btnDiscon.TabIndex = 8;
            this.btnDiscon.Text = "قطع";
            this.btnDiscon.UseVisualStyleBackColor = false;
            this.btnDiscon.Click += new System.EventHandler(this.btnDiscon_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Aquamarine;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnConnect.Location = new System.Drawing.Point(110, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 41);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "اتصال";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnDiscon);
            this.groupBox11.Controls.Add(this.btnConnect);
            this.groupBox11.Controls.Add(this.btnIdentify);
            this.groupBox11.Location = new System.Drawing.Point(3, 15);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(246, 125);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Connect:";
            // 
            // btnIdentify
            // 
            this.btnIdentify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnIdentify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnIdentify.Location = new System.Drawing.Point(22, 66);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(207, 55);
            this.btnIdentify.TabIndex = 5;
            this.btnIdentify.Text = "شروع شناسایی";
            this.btnIdentify.UseVisualStyleBackColor = false;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // timerFreePrevTagID
            // 
            this.timerFreePrevTagID.Interval = 20000;
            this.timerFreePrevTagID.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // mainForm
            // 
            this.ClientSize = new System.Drawing.Size(1290, 683);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.libInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " (Shahed Edition) نرم افزار گیت کتابخانه بزرگمهر";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tabPage_Settings.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnteStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnteStatus1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_EPCMultiTag.ResumeLayout(false);
            this.tabPage_EPCMultiTag.PerformLayout();
            this.gbEPCDataAnalysis.ResumeLayout(false);
            this.gbEPCDataAnalysis.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion



        private ListBox libInfo;
        private Timer timerGen2Identify;
        private Timer timerRate;
        private Timer timerMultiTagRead;
        private Timer timerMultiTagWrite;
        private Timer timerIsoIdentify;
        private Timer timerIsoMultiTagRead;
        private Button btnClear;
        private Timer timerReconnect;
        private TabPage tabPage_Settings;
        private GroupBox groupBox10;
        private RadioButton rbBuzzerOFF;
        private Button btnSetBuzzer;
        private Button btnGetBuzzer;
        private RadioButton rbBuzzerON;
        private GroupBox groupBox9;
        private RadioButton rbFreq_Others;
        private RadioButton rbFreq_Europe;
        private RadioButton rbFreq_NAmerica;
        private RadioButton rbFreq_China;
        private CheckedListBox checkedlibFrePoint;
        private Label label66;
        private Button btnGetFrequency;
        private Label lbFreqPoints;
        private Button btnSetFrequency;
        private GroupBox groupBox8;
        private TextBox tbTCPPara_GateWay;
        private TextBox tbTCPPara_Mask;
        private Button btnGetTCPPara;
        private Button btnSetTCPPara;
        private TextBox tbTCPPara_IP;
        private Label label63;
        private Label label62;
        private Label label61;
        private GroupBox groupBox7;
        private ComboBox cbIOLevel;
        private ComboBox cbIOPort;
        private Button btnSetOutPort;
        private Label label60;
        private Label label59;
        private GroupBox groupBox5;
        private RadioButton rbMultiFastTagMode;
        private RadioButton rbSingleFastTagMode;
        private Button btnGetTagMode;
        private Button btnSetTagMode;
        private Button btnResetReader;
        private GroupBox groupBox2;
        private Button btnGetFirmVersion;
        private Label lbFirmVersion;
        private Label label51;
        private GroupBox groupBox4;
        private PictureBox pbAnteStatus2;
        private PictureBox pbAnteStatus1;
        private CheckBox chbAnte2;
        private CheckBox chbAnte1;
        private Button btnSetAnte;
        private Button btnGetAnte;
        private Label label65;
        private Label label64;
        private GroupBox groupBox3;
        private TextBox tbPower2;
        private TextBox tbPower1;
        private Button btnSetPower;
        private Button btnGetPower;
        private Label label54;
        private Label label53;
        private Label label50;
        private Label label52;
        private GroupBox groupBox1;
        private Button btnSetBaudRate;
        private Label label49;
        private Label label48;
        private ComboBox cbSettings_BaudRate;
        private TabControl tabControl;
        private TabPage tabPage_EPCMultiTag;
        private ListViewNF livGen2Identify;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader21;
        private GroupBox gbEPCDataAnalysis;
        private Label lbTestDuration;
        private Label lbReadTimes;
        private Label lbAverageRate;
        private Label lbPeakRate;
        private Label lbTotalReads;
        private Label lbUniqueTags;
        private Label lbTD;
        private Label lbRT;
        private Label lbAR;
        private Label label9;
        private Label label5;
        private Label label3;
        private Button btnDiscon;
        private Button btnConnect;
        private GroupBox groupBox11;
        private TextBox ip_database_info;
        private Label label7;
        private GroupBox groupBox12;
        private Button set_database;
        private Button get_database;
        private TextBox name_database_info;
        private Label label8;
        private TextBox password_database_info;
        private Label label11;
        private TextBox username_database_info;
        private Label label10;
        private Timer timer1;
        private Timer timerFreePrevTagID;
        private ColumnHeader columnHeader4;
        private GroupBox groupBox6;
        private Button button1;
        private Button button2;
        private TextBox tbPort2;
        private TextBox tbIP2;
        private Label label4;
        private Label label6;
        private GroupBox gbConnect;
        private Button button3;
        private TextBox tbPort;
        private Button button4;
        private TextBox tbIP;
        private Label label2;
        private Label label1;
        private PictureBox pbGreen;
        private PictureBox pbRed;
        private Button btnIdentify;
        private ColumnHeader columnHeaderBookCode;
        private ColumnHeader columnHeaderLoaned;
        private Label lblTotalRequest;
        private Label lblTotalRequestCaption;
        private Button button6;
        private Button button7;
        private TextBox RfidTextBox;
        private Button kioskButton;
        private Button inventoryButton;
    }
}