// Decompiled with JetBrains decompiler
// Type: MR6100Demo.mainForm
// Assembly: MR6100Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1873F71C-3ADE-4CD3-9129-535384741D4F
// Assembly location: Z:\zaaferani\Desktop\book gate\MR6100Demo.exe

using MR6100Demo.classes;
using MR6100Demo.Forms;
using MR6100Demo.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace MR6100Demo
{
    /// <summary>
    /// Main form for MR6100 RFID Reader Demo application
    /// Handles dual antenna RFID reader operations, database connectivity, and real-time tag identification
    /// </summary>
    public partial class mainForm : Form
    {

        private MR6100Api.MR6100Api Api = new MR6100Api.MR6100Api();
        private MR6100Api.MR6100Api Api2 = new MR6100Api.MR6100Api();
        private ArrayList idList = new ArrayList();
        private byte[,] tagData;
        private byte[,] tagData2;
        private int tagCount;
        private int tagCount2;
        private Stopwatch stopwatch = new Stopwatch();
        private int port;
        private byte v1;
        private byte v2;
        private string strIP = "";
        private int status;
        private int readSeconds;
        private int rate;
        private int peakRate;
        private int totalReads;
        private int lastTotalReads;
        private int iReconnect;
        private int loadApiTotalRequest = 0;
        private string prevTagID = "";
        private Document findDoc;
        private string logFileName = "";
        public mainForm()
        {
            InitializeComponent();

            // Configure RTL (Right-to-Left) layout for Persian/Arabic UI
            this.password_database_info.RightToLeft = RightToLeft.No;  // Keep password field LTR
            this.username_database_info.RightToLeft = RightToLeft.No;  // Keep username field LTR
            this.name_database_info.RightToLeft = RightToLeft.No;      // Keep database name LTR
            this.ip_database_info.RightToLeft = RightToLeft.No;        // Keep IP address LTR
            this.tabControl.RightToLeft = RightToLeft.Yes;             // Main tab control RTL
            this.tabPage_EPCMultiTag.RightToLeft = RightToLeft.Yes;    // EPC multi-tag page RTL
            this.livGen2Identify.RightToLeftLayout = true;             // Gen2 identify list RTL layout

        }

        /// <summary>
        /// Form load event handler - initializes logging, database connection, and loads all configuration settings
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Initialize daily log file with date stamp
            this.logFileName = "log/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            // Load database connection information
            this.load_database_info();

            // Disable identify button until reader is connected
            this.btnIdentify.Enabled = false;

            // Load all configuration settings from saved values
            LoadDataBaseSettingConfig();    // Database connection settings
            LoadTCPSettingConfig();         // TCP/IP connection settings
            LoadR1SettingConfig();          // First reader settings
            LoadR2SettingConfig();          // Second reader settings
            LoadFrequencySettingConfig();   // RFID frequency settings
            LoadPowerSettingConfig();       // RF power settings
            LoadWorkingModeSettingConfig(); // Working mode configuration
            LoadLEDSettingConfig();         // LED indicator settings

        }

        /// <summary>
        /// Handles connection to the primary RFID reader antenna
        /// Establishes TCP connection, validates firmware, and initializes reader settings
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.Api = new MR6100Api.MR6100Api();
            this.Api2 = new MR6100Api.MR6100Api();



            string str = "";

            try
            {
                // Parse connection parameters from UI
                this.port = int.Parse(this.tbPort.Text.Trim());
                this.strIP = this.tbIP.Text.Trim();
            }
            catch (Exception ex)
            {
                this.libInfo.Items.Add("Please input the ip address and port !");
                return;
            }

            // Validate network connectivity
            if (!this.Api.isNetWorkConnect(this.strIP))
            {
                this.libInfo.Items.Add("The input ip is not exist.");
                return;
            }

            // Attempt TCP connection to reader
            if (this.Api.TcpConnectReader(this.strIP, this.port) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            {
                this.libInfo.Items.Add("Connect Reader Failed!  ");
                return;
            }

            // Verify firmware version and reader communication
            if (this.Api.GetFirmwareVersion((int)byte.MaxValue, ref this.v1, ref this.v2) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            {
                this.libInfo.Items.Add("Can not connect with the reader!  ");
                return;
            }

            // Connection successful - update UI and initialize reader
            this.libInfo.Items.Add("آنتن اول با موفقیت متصل شد");  // "First antenna connected successfully"
            this.libInfo.Items.Add(str);


            // connection sound
            Tools.PlaySound(1);



            // Update button states
            this.btnConnect.Enabled = false;
            this.btnConnect.BackColor = Color.LightPink;
            this.btnDiscon.Enabled = true;
            this.btnIdentify.Enabled = true;
            this.btnDiscon.BackColor = Color.Aquamarine;
            this.tabControl.Enabled = true;

            // Initialize reader settings by calling configuration methods
            this.btnGetFirmVersion_Click(sender, e);  // Get and display firmware version
            this.btnGetFrequency_Click(sender, e);    // Get current frequency settings
            this.btnGetPower_Click(sender, e);        // Get current power settings
            this.btnGetTagMode_Click(sender, e);      // Get current tag mode settings
            this.btnGetTCPPara_Click(sender, e);      // Get TCP parameters
            this.btnGetAnte_Click(sender, e);         // Get antenna settings



            // Connect second antenna
            //this.ConnectAnten2();
        }
        /// <summary>
        /// Establishes connection to the secondary RFID reader antenna
        /// Similar to primary antenna connection but for second reader
        /// </summary>
        private void ConnectAnten2()
        {
            string str = "";

            try
            {
                // Parse connection parameters for second antenna
                this.port = int.Parse(this.tbPort2.Text.Trim());
                this.strIP = this.tbIP2.Text.Trim();
            }
            catch (Exception ex)
            {
                this.libInfo.Items.Add("Please input the ip address and port 2!");
                return;
            }

            // Validate network connectivity for second antenna
            if (!this.Api2.isNetWorkConnect(this.strIP))
            {
                this.libInfo.Items.Add("The input ip is not exist. 2");
                return;
            }

            // Attempt TCP connection to second reader
            if (this.Api2.TcpConnectReader(this.strIP, this.port) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            {
                this.libInfo.Items.Add("Connect Reader Failed!  2");
                return;
            }

            // Verify firmware version for second reader
            // Note: Uses Api (not Api2) - this might be intentional or a bug
            if (this.Api.GetFirmwareVersion((int)byte.MaxValue, ref this.v1, ref this.v2) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            {
                this.libInfo.Items.Add("Can not connect with the reader!  2");
                return;
            }

            // Second antenna connection successful
            this.libInfo.Items.Add("آنتن دوم با موفقیت متصل شد");  // "Second antenna connected successfully"
            this.libInfo.Items.Add(str);

            // Update UI state (same as primary antenna)
            this.btnConnect.Enabled = false;
            this.btnConnect.BackColor = Color.LightPink;
            this.btnDiscon.Enabled = true;
            this.btnIdentify.Enabled = true;
            this.btnDiscon.BackColor = Color.Aquamarine;
            this.tabControl.Enabled = true;
        }


        private void btnDiscon_Click(object sender, EventArgs e)
        {
            if (this.btnIdentify.Text == "توقف")
                this.btnIdentify_Click(sender, e);
            this.timerRate.Enabled = false;
            this.timerFreePrevTagID.Enabled = false;
            if (this.timerGen2Identify.Enabled)
                this.timerGen2Identify.Enabled = false;
            if (this.timerIsoIdentify.Enabled)
                this.timerIsoIdentify.Enabled = false;
            if (this.timerIsoMultiTagRead.Enabled)
                this.timerIsoMultiTagRead.Enabled = false;
            if (this.timerMultiTagRead.Enabled)
                this.timerMultiTagRead.Enabled = false;
            if (this.timerMultiTagWrite.Enabled)
                this.timerMultiTagWrite.Enabled = false;
            this.Api.TcpCloseConnect();
            this.stopwatch.Reset();
            this.btnConnect.Enabled = true;
            this.btnIdentify.Enabled = false;
            this.btnDiscon.Enabled = false;
            this.tabControl.Enabled = false;
            this.btnConnect.BackColor = Color.Aquamarine;
            this.btnDiscon.BackColor = Color.LightPink;
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (this.btnIdentify.Text == "شروع شناسایی")
            {
                this.libInfo.Items.Add("شروع شناسایی");
                this.tagData = new byte[500, 14];
                this.tagData2 = new byte[500, 14];
                this.ClearLabel();
                this.livGen2Identify.Items.Clear();
                this.btnIdentify.Text = "توقف";
                this.idList.Clear();


                if (this.tagData == null)
                    this.tagData = new byte[500, 14];

                if (this.tagData2 == null)
                    this.tagData2 = new byte[500, 14];


                this.timerGen2Identify.Enabled = true;
                this.timerReconnect.Enabled = true;
                this.timerRate.Enabled = true;
                this.timerFreePrevTagID.Enabled = true;
                this.stopwatch.Start();
            }
            else
            {
                this.libInfo.Items.Add("توقف شناسایی");
                this.btnIdentify.Text = "شروع شناسایی";
                this.stopwatch.Reset();
                this.timerReconnect.Enabled = false;
                this.timerGen2Identify.Enabled = false;
                this.timerRate.Enabled = false;
                this.timerFreePrevTagID.Enabled = false;
            }
        }

        private void btnIdentify_Once_Click(object sender, EventArgs e)
        {
            this.tagData = new byte[500, 14];
            this.ClearLabel();
            this.livGen2Identify.Items.Clear();
            this.idList.Clear();
            this.timerInventory_Tick(sender, e);
        }



        private void timerInventory_Tick(object sender, EventArgs e)
        {


            try
            {
                this.lbTestDuration.Text = this.stopwatch.Elapsed.ToString(@"dd\:hh\:mm\:ss");

                byte tag_flag1 = 0;
                byte tag_flag2 = 0;
                this.tagCount = 0;
                this.tagCount2 = 0;

                if (this.Api != null && this.tagData != null)
                {
                    try
                    {
                        this.status = this.Api.EpcMultiTagIdentify((int)byte.MaxValue, ref this.tagData, ref this.tagCount, ref tag_flag1);
                        if (this.status == MR6100Api.MR6100Api.SUCCESS_RETURN)
                            proccessTag(tagData, tagCount, tag_flag1);
                    }
                    catch (Exception ex)
                    {
                        this.libInfo.Items.Add("خطا در Api 1: " + ex.Message);
                    }
                }

                //if (this.Api2 != null && this.tagData2 != null)
                //{
                //    try
                //    {
                //        this.status = this.Api2.EpcMultiTagIdentify((int)byte.MaxValue, ref this.tagData2, ref this.tagCount2, ref tag_flag2);
                //        if (this.status == MR6100Api.MR6100Api.SUCCESS_RETURN)
                //            proccessTag(tagData2, tagCount2, tag_flag2);
                //    }
                //    catch (Exception ex)
                //    {
                //        this.libInfo.Items.Add("خطا در Api 2: " + ex.Message);
                //    }
                //}

                if (this.lbTotalReads != null && long.TryParse(this.lbTotalReads.Text, out long totalReads))
                {
                    if (this.stopwatch.ElapsedMilliseconds / 1000L > 0L)
                        this.lbAverageRate.Text = (totalReads / (this.stopwatch.ElapsedMilliseconds / 1000L)).ToString();
                }
            }
            catch (Exception ex)
            {
                this.timerGen2Identify.Enabled = false;
                MessageBox.Show("خطای عمومی: " + ex.Message);
            }
        }


        private void timerRate_Tick(object sender, EventArgs e)
        {
            ++this.readSeconds;
            this.totalReads = int.Parse(this.lbTotalReads.Text);
            if (this.readSeconds <= 0)
                return;
            if (this.totalReads - this.lastTotalReads > this.peakRate)
                this.peakRate = this.totalReads - this.lastTotalReads;
            this.lbPeakRate.Text = this.peakRate.ToString();
            this.lastTotalReads = this.totalReads;
        }

        private void proccessTag(byte[,] _tagData, int _tagCount, byte _tag_flag1)
        {
            // فقط یک بار ستون‌ها تنظیم می‌شن
            if (livGen2Identify.Columns.Count == 0)
            {
                livGen2Identify.View = View.Details;
                livGen2Identify.Columns.Add("ردیف", 50);
                livGen2Identify.Columns.Add("عنوان", 150);
                livGen2Identify.Columns.Add("شماره جلد", 100);
                livGen2Identify.Columns.Add("تاریخ انتشار", 100);
                livGen2Identify.Columns.Add("شماره ثبت", 100);
                livGen2Identify.Columns.Add("آیدی تگ", 150);
                livGen2Identify.Columns.Add("وضعیت امانت ", 100);
            }

            for (int index1 = 0; index1 < _tagCount; ++index1)
            {
                string tagId = "";
                for (int index2 = 2; index2 < 14; ++index2)
                    tagId += string.Format("{0:X2}", _tagData[index1, index2]);

                if (tagId == "000000000000000000000000")
                    continue;

                string newTagID = tagId;

                // بررسی اینکه آیا قبلاً اضافه شده یا نه
                int existingIndex = -1;
                for (int i = 0; i < livGen2Identify.Items.Count; i++)
                {
                    if (livGen2Identify.Items[i].SubItems[5].Text == newTagID)
                    {
                        existingIndex = i;
                        break;
                    }
                }

                DataTable findDoc = Tools.getBookInfoByRFID(newTagID);

                if (findDoc == null || findDoc.Rows.Count == 0)
                {
                    libInfo.Items.Add($"تگ {tagId} ثبت نشده است.");
                    continue;
                }

                // دریافت اطلاعات کتاب
                DataRow row = findDoc.Rows[0];
                string title = row["ONVAN"]?.ToString();
                string header = row["HEADER"]?.ToString();
                string date = row["DATEOFPUB"]?.ToString();
                string recordNo = row["RECORDNO"]?.ToString();
                string status = row["LOAN"]?.ToString();

                if (existingIndex == -1)
                {
                    // اضافه کردن تگ جدید
                    ListViewItem item = new ListViewItem((livGen2Identify.Items.Count + 1).ToString());
                    item.SubItems.Add(title);
                    item.SubItems.Add(header);
                    item.SubItems.Add(date);
                    item.SubItems.Add(recordNo);
                    item.SubItems.Add(newTagID);
                    item.SubItems.Add(status);

                    livGen2Identify.Items.Add(item);

                }
                else
                {
                    // به‌روزرسانی تگ تکراری
                    ListViewItem item = livGen2Identify.Items[existingIndex];
                    item.SubItems[1].Text = title;
                    item.SubItems[2].Text = header;
                    item.SubItems[3].Text = date;
                    item.SubItems[4].Text = recordNo;
                    item.SubItems[6].Text = status;
                }

                // صدای تگ جدید در صورت نیاز
                if (!idList.Contains(newTagID))
                {
                    Tools.PlaySound(1);


                    idList.Add(newTagID);


                    //نسخه قدیمی کنترل صوت
                    //string soundPath = Path.Combine(Application.StartupPath, Properties.Settings.Default.beep);
                    //if (File.Exists(soundPath))
                    //{
                    //    new SoundPlayer(soundPath).PlaySync();
                    //}
                }
                else
                {
                    //صدای تگ تکراری
                    Tools.PlaySound(3);
                }

                // ثبت لاگ و شمارنده‌ها
                logBook(findDoc);
                loadApiTotalRequest++;
                timerFreePrevTagID.Stop();
                timerFreePrevTagID.Start();
            }

            try
            {
                this.lbUniqueTags.Text = this.livGen2Identify.Items.Count.ToString();
                this.lbReadTimes.Text = (int.Parse(this.lbReadTimes.Text) + 1).ToString();
                this.lbTotalReads.Text = (int.Parse(this.lbTotalReads.Text) + _tagCount).ToString();
                this.lblTotalRequest.Text = loadApiTotalRequest.ToString();
            }
            catch
            {
            }
        }

        private void logBook(DataTable findDoc)
        {
            if (findDoc == null)
                return;
            File.AppendAllText(this.logFileName, findDoc.ToString() + "," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "\n");
        }

        private void ClearLabel()
        {
            this.lbUniqueTags.Text = "0";
            this.lbTotalReads.Text = "0";
            this.lbPeakRate.Text = "0";
            this.lbAverageRate.Text = "0";
            this.lbReadTimes.Text = "0";
            this.lbTestDuration.Text = "0";
            this.readSeconds = 0;
        }

        private void btnSetBaudRate_Click(object sender, EventArgs e)
        {
            if (this.Api.SetBaudRate((int)byte.MaxValue, this.cbSettings_BaudRate.SelectedIndex) == MR6100Api.MR6100Api.SUCCESS_RETURN)
                return;
            this.libInfo.Items.Add("Set baudrate fail.");
        }

        private void btnGetFirmVersion_Click(object sender, EventArgs e)
        {
            this.lbFirmVersion.Text = "";
            if (this.Api.GetFirmwareVersion((int)byte.MaxValue, ref this.v1, ref this.v2) == MR6100Api.MR6100Api.SUCCESS_RETURN)
                this.lbFirmVersion.Text = string.Format("V{0:d2}.{1:d2}", this.v1, this.v2);
            else
                this.libInfo.Items.Add("Get Firmware Version fail.");
        }

        private void btnGetPower_Click(object sender, EventArgs e)
        {
            LoadPowerSettingConfig();
            //this.tbPower1.Text = "";
            //this.tbPower2.Text = "";
            //int[] power = new int[4];
            //if (this.Api.GetRf((int)byte.MaxValue, ref power) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            //    return;
            //this.tbPower1.Text = power[0].ToString();
            //this.tbPower2.Text = power[1].ToString();
        }

        private void btnSetPower_Click(object sender, EventArgs e)
        {
            SavePowerSettingConfig();
            //int power2 = 0;
            //int power3 = 0;
            //int power4 = 0;
            //int power1;
            //try
            //{
            //    power1 = int.Parse(this.tbPower1.Text.Trim());
            //}
            //catch
            //{
            //    power1 = 0;
            //}
            //try
            //{
            //    power2 = int.Parse(this.tbPower2.Text.Trim());
            //}
            //catch
            //{
            //    power4 = 0;
            //}
            //if (this.Api.SetRf((int)byte.MaxValue, power1, power2, power3, power4) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //    return;
            //this.libInfo.Items.Add("Set Power fail.");
        }

        private void btnGetAnte_Click(object sender, EventArgs e)
        {
            byte workAnt = 0;
            byte antState = 0;
            if (this.Api.GetAnt((int)byte.MaxValue, ref workAnt, ref antState) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            {
                this.libInfo.Items.Add("Get Antennas fail.");
                this.chbAnte1.Checked = false;
                this.chbAnte2.Checked = false;
                this.pbAnteStatus1.BackgroundImage = this.pbRed.BackgroundImage;
                this.pbAnteStatus2.BackgroundImage = this.pbRed.BackgroundImage;
            }
            else
            {
                this.chbAnte1.Checked = (int)workAnt % 2 == 1;
                this.chbAnte2.Checked = ((int)workAnt >> 1) % 2 == 1;
                if ((int)antState % 2 == 1)
                    this.pbAnteStatus1.BackgroundImage = this.pbGreen.BackgroundImage;
                else
                    this.pbAnteStatus1.BackgroundImage = this.pbRed.BackgroundImage;
                if (((int)antState >> 1) % 2 == 1)
                    this.pbAnteStatus2.BackgroundImage = this.pbGreen.BackgroundImage;
                else
                    this.pbAnteStatus2.BackgroundImage = this.pbRed.BackgroundImage;
            }
        }

        private void btnSetAnte_Click(object sender, EventArgs e)
        {
            int ant = 0;
            if (this.chbAnte1.Checked)
                ++ant;
            if (this.chbAnte2.Checked)
                ant += 2;
            if (this.Api.SetAnt((int)byte.MaxValue, (byte)ant) == MR6100Api.MR6100Api.SUCCESS_RETURN)
                return;
            this.libInfo.Items.Add("Set Antennas fail.");
        }

        private void btnGetTagMode_Click(object sender, EventArgs e)
        {
            LoadWorkingModeSettingConfig();
            //int mode = 0;
            //if (this.Api.GetFastTagMode((int)byte.MaxValue, ref mode) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            //{
            //    this.libInfo.Items.Add("Set Fast Tag Mode fail.");
            //    this.rbSingleFastTagMode.Checked = false;
            //    this.rbMultiFastTagMode.Checked = false;
            //}
            //else if (mode == 0)
            //    this.rbSingleFastTagMode.Checked = true;
            //else
            //    this.rbMultiFastTagMode.Checked = true;
        }

        private void btnSetTagMode_Click(object sender, EventArgs e)
        {
            SaveWorkingModeSettingConfig();
            //int mode = 0;
            //if (this.rbMultiFastTagMode.Checked)
            //    mode = 1;
            //if (this.Api.SetFastTagMode((int)byte.MaxValue, mode) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //    return;
            //this.libInfo.Items.Add("Set Fast Tag Mode fail.");
        }

        private void btnGetTestMode_Click(object sender, EventArgs e)
        {
        }

        private void btnSetOutPort_Click(object sender, EventArgs e)
        {
            int selectedIndex1 = this.cbIOPort.SelectedIndex;
            int selectedIndex2 = this.cbIOLevel.SelectedIndex;
            if (selectedIndex1 < 0 || selectedIndex2 < 0)
            {
                this.libInfo.Items.Add("Please select the IO port and level.");
            }
            else
            {
                if (this.Api.SetOutPort((int)byte.MaxValue, (byte)selectedIndex1, (byte)selectedIndex2) == MR6100Api.MR6100Api.SUCCESS_RETURN)
                    return;
                this.libInfo.Items.Add("Set  OutPort fail.");
            }
        }

        private void btnResetReader_Click(object sender, EventArgs e)
        {
            if (this.Api.ResetParameter((int)byte.MaxValue) == MR6100Api.MR6100Api.SUCCESS_RETURN)
                this.btnDiscon_Click(sender, e);
            else
                this.libInfo.Items.Add("Reset Reader fail.");
        }

        private void btnGetTCPPara_Click(object sender, EventArgs e)
        {
            //string strIP = "";
            //string strMark = "";
            //string strGate = "";
            //int nTcpPort = 0;
            //if (this.Api.GetTcpParameter((int)byte.MaxValue, ref strIP, ref strMark, ref strGate, ref nTcpPort) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //{
            //    this.tbTCPPara_IP.Text = strIP;
            //    this.tbTCPPara_Mask.Text = strMark;
            //    this.tbTCPPara_GateWay.Text = strGate;
            //}
            //else
            //{
            //    this.tbTCPPara_IP.Text = strIP;
            //    this.tbTCPPara_Mask.Text = strMark;
            //    this.tbTCPPara_GateWay.Text = strGate;
            //    this.libInfo.Items.Add("Get Tcp Parameter fail.");
            //}

            LoadTCPSettingConfig();


        }

        private void btnSetTCPPara_Click(object sender, EventArgs e)
        {

            //string strIP = this.tbTCPPara_IP.Text.Trim();
            //string strMark = this.tbTCPPara_Mask.Text.Trim();
            //string strGate = this.tbTCPPara_GateWay.Text.Trim();
            //if (this.CheckIPValid(strIP))
            //{
            //    if (this.Api.SetTcpParameter((int)byte.MaxValue, strIP, strMark, strGate, 0) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //        this.btnResetReader_Click(sender, e);
            //    else
            //        this.libInfo.Items.Add("Set Tcp Parameter fail.");
            //}
            //else
            //    this.libInfo.Items.Add("The input ip is incorrect.");


            SaveTCPSettingConfig();
        }

        public bool CheckIPValid(string strIP)
        {
            char ch = '.';
            string[] strArray = strIP.Split(ch);
            if (strArray.Length != 4)
                return false;
            short maxValue = (short)byte.MaxValue;
            foreach (string s in strArray)
            {
                if (s.Length > 3 || int.Parse(s) > (int)maxValue)
                    return false;
            }
            return true;
        }

        private void rbFreq_Others_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbFreq_Others.Checked)
            {
                this.checkedlibFrePoint.Visible = true;
                this.lbFreqPoints.Visible = true;
            }
            else
            {
                this.checkedlibFrePoint.Visible = false;
                this.lbFreqPoints.Visible = false;
            }
        }

        private void btnGetFrequency_Click(object sender, EventArgs e)
        {


            LoadFrequencySettingConfig();
            //int freqNum = 0;
            //int[] points = new int[120];
            //if (this.Api.GetFrequency((int)byte.MaxValue, ref freqNum, ref points) != MR6100Api.MR6100Api.SUCCESS_RETURN)
            //{
            //    this.libInfo.Items.Add("Get Frequency Parameter fail.");
            //    this.rbFreq_China.Checked = false;
            //    this.rbFreq_NAmerica.Checked = false;
            //    this.rbFreq_Europe.Checked = false;
            //    this.rbFreq_Others.Checked = false;
            //}
            //else if (freqNum == 0)
            //{
            //    switch (points[0])
            //    {
            //        case 0:
            //            this.rbFreq_China.Checked = true;
            //            break;
            //        case 1:
            //            this.rbFreq_NAmerica.Checked = true;
            //            break;
            //        case 2:
            //            this.rbFreq_Europe.Checked = true;
            //            break;
            //    }
            //}
            //else
            //{
            //    this.rbFreq_Others.Checked = true;
            //    this.checkedlibFrePoint.Visible = true;
            //    this.lbFreqPoints.Visible = true;
            //    for (int index = 0; index < this.checkedlibFrePoint.Items.Count; ++index)
            //        this.checkedlibFrePoint.SetItemChecked(index, false);
            //    for (int index = 0; index < freqNum; ++index)
            //    {
            //        if (points[index] <= 120)
            //        {
            //            this.checkedlibFrePoint.SetItemChecked(points[index] / 2, true);
            //        }
            //        else
            //        {
            //            this.libInfo.Items.Add("The Frequency point is illegal.");
            //            break;
            //        }
            //    }
            //}
        }

        private void btnSetFrequency_Click(object sender, EventArgs e)
        {

            SaveFrequencySettingConfig();
            //int freqNum = 0;
            //int[] points = new int[120];
            //if (this.rbFreq_China.Checked)
            //    points[0] = 0;
            //if (this.rbFreq_NAmerica.Checked)
            //    points[0] = 1;
            //if (this.rbFreq_Europe.Checked)
            //    points[0] = 2;
            //if (this.rbFreq_Others.Checked)
            //{
            //    for (int index = 0; index < this.checkedlibFrePoint.Items.Count; ++index)
            //    {
            //        if (this.checkedlibFrePoint.GetItemChecked(index))
            //        {
            //            points[freqNum] = 2 * index;
            //            ++freqNum;
            //        }
            //    }
            //}
            //if (this.Api.SetFrequency((int)byte.MaxValue, freqNum, points) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //    return;
            //this.libInfo.Items.Add("Set Frequency Parameter fail.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.libInfo.Items.Clear();
        }

        private void btnGetBuzzer_Click(object sender, EventArgs e)
        {
            LoadLEDSettingConfig();
            //byte state = 1;
            //if (this.Api.GetBuzzerLED((int)byte.MaxValue, ref state) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //{
            //    if (state == (byte)3)
            //    {
            //        this.rbBuzzerON.Checked = true;
            //        this.rbBuzzerOFF.Checked = false;
            //    }
            //    else if (state != (byte)0)
            //    {
            //        this.rbBuzzerON.Checked = false;
            //        this.rbBuzzerOFF.Checked = true;
            //    }
            //}
            //else
            //{
            //    this.libInfo.Items.Add("Get Buzzer and LED fail.");
            //    this.rbBuzzerON.Checked = false;
            //    this.rbBuzzerOFF.Checked = false;
            //}
        }

        private void btnSetBuzzer_Click(object sender, EventArgs e)
        {
            SaveLEDSettingConfig();
            //if ((!this.rbBuzzerON.Checked ? this.Api.BuzzerLEDOFF((int)byte.MaxValue) : this.Api.BuzzerLEDON((int)byte.MaxValue)) == MR6100Api.MR6100Api.SUCCESS_RETURN)
            //    this.btnResetReader_Click(sender, e);
            //else
            //    this.libInfo.Items.Add("Set Buzzer and LED fail.");
        }

        private void timerReconnect_Tick(object sender, EventArgs e)
        {
            if (this.status == 2009)
            {
                this.libInfo.Items.Add(("Disconnect at: " + DateTime.Now.ToString() + "." + DateTime.Now.Second + "." + DateTime.Now.Millisecond));
                if (MR6100Api.MR6100Api.PortType == 1)
                {
                    if (this.Api.isNetWorkConnect(this.strIP))
                    {
                        this.status = this.Api.TcpConnectReader(this.strIP, this.port);
                        if (this.status == MR6100Api.MR6100Api.SUCCESS_RETURN)
                        {
                            this.iReconnect = 0;
                            this.libInfo.Items.Add((DateTime.Now.ToString() + "." + DateTime.Now.Second + "." + DateTime.Now.Millisecond));
                        }
                        else
                        {
                            ++this.iReconnect;
                            this.libInfo.Items.Add("Aren't able to send command to the reader.");
                        }
                    }
                    else
                    {
                        ++this.iReconnect;
                        this.libInfo.Items.Add("Can't find the reader ip,reader disconnect.");
                    }
                }
            }
            if (this.iReconnect <= 25)
                return;
            if (this.btnIdentify.Text == "توقف")
                this.btnIdentify_Click(sender, e);
            this.timerReconnect.Enabled = false;
            this.btnDiscon_Click(sender, e);
            this.libInfo.Items.Add("Can't find the ip in the network,please check your reader.");
            this.iReconnect = 0;
        }

        /// <summary>
        /// Loads the LED/Buzzer configuration settings from the configuration manager
        /// and updates the UI radio button controls to reflect the current buzzer status.
        /// </summary>
        /// <remarks>
        /// This method retrieves the buzzer configuration and sets the appropriate radio button
        /// (rbBuzzerON or rbBuzzerOFF) based on the stored BuzzerStatus value.
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadLEDSettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                try
                {
                    // Check if buzzer is configured to be ON and update the corresponding radio button
                    if (config.BuzzerStatus == "ON")
                    {
                        rbBuzzerON.Checked = true;
                    }
                    // Check if buzzer is configured to be OFF and update the corresponding radio button
                    if (config.BuzzerStatus == "OFF")
                    {
                        rbBuzzerOFF.Checked = true;
                    }
                }
                catch
                {
                    // Display generic error message if configuration parsing fails
                    MessageBox.Show("Hmmm");
                }
            }
            else
            {
                // Display Persian error message when buzzer configuration is not found
                MessageBox.Show("!تنظیمات مربوطه Buzzer یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current LED/Buzzer configuration settings based on the selected radio button state.
        /// </summary>
        /// <remarks>
        /// This method reads the current state of the buzzer radio buttons (rbBuzzerON/rbBuzzerOFF)
        /// and persists the corresponding BuzzerStatus value to the configuration.
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveLEDSettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Set buzzer status to ON if the ON radio button is checked
            if (rbBuzzerON.Checked)
            {
                config.BuzzerStatus = "ON";
            }
            // Set buzzer status to OFF if the OFF radio button is checked
            if (rbBuzzerOFF.Checked)
            {
                config.BuzzerStatus = "OFF";
            }

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  working mode ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the working mode configuration settings from the configuration manager
        /// and updates the UI radio button controls to reflect the current working mode.
        /// </summary>
        /// <remarks>
        /// This method retrieves the working mode configuration and sets the appropriate radio button
        /// based on the stored WorkingMode value:
        /// - "Favor speed" maps to rbSingleFastTagMode
        /// - "Favor quantity" maps to rbMultiFastTagMode
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadWorkingModeSettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                try
                {
                    // Check if working mode is set to favor speed and update single fast tag mode radio button
                    if (config.WorkingMode == "Favor speed")
                    {
                        rbSingleFastTagMode.Checked = true;
                    }
                    // Check if working mode is set to favor quantity and update multi fast tag mode radio button
                    if (config.WorkingMode == "Favor quantity")
                    {
                        rbMultiFastTagMode.Checked = true;
                    }
                }
                catch
                {
                    // Display generic error message if configuration parsing fails
                    MessageBox.Show("Hmmm");
                }
            }
            else
            {
                // Display Persian error message when power/working mode configuration is not found
                MessageBox.Show("!تنظیمات مربوطه power یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current working mode configuration settings based on the selected radio button state.
        /// </summary>
        /// <remarks>
        /// This method reads the current state of the working mode radio buttons and persists
        /// the corresponding WorkingMode value to the configuration:
        /// - rbSingleFastTagMode maps to "Favor speed"
        /// - rbMultiFastTagMode maps to "Favor quantity"
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveWorkingModeSettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Set working mode to favor speed if single fast tag mode is selected
            if (rbSingleFastTagMode.Checked)
            {
                config.WorkingMode = "Favor speed";
            }
            // Set working mode to favor quantity if multi fast tag mode is selected
            if (rbMultiFastTagMode.Checked)
            {
                config.WorkingMode = "Favor quantity";
            }

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  working mode ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the power/antenna configuration settings from the configuration manager
        /// and populates the power textbox controls with the stored antenna values.
        /// </summary>
        /// <remarks>
        /// This method retrieves the antenna power configuration and sets the text values
        /// for tbPower1 and tbPower2 textboxes based on the stored Ante1 and Ante2 values.
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadPowerSettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Load antenna 1 power setting into the first power textbox
                this.tbPower1.Text = config.Ante1;
                // Load antenna 2 power setting into the second power textbox
                this.tbPower2.Text = config.Ante2;
            }
            else
            {
                // Display Persian error message when power configuration is not found
                MessageBox.Show("!تنظیمات مربوطه power یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current power/antenna configuration settings from the power textbox controls.
        /// </summary>
        /// <remarks>
        /// This method reads the current text values from tbPower1 and tbPower2 textboxes
        /// and persists them as Ante1 and Ante2 values in the configuration.
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SavePowerSettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Save antenna 1 power setting from the first power textbox
            config.Ante1 = this.tbPower1.Text;
            // Save antenna 2 power setting from the second power textbox
            config.Ante2 = this.tbPower2.Text;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  power ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the frequency configuration settings from the configuration manager
        /// and updates the UI controls to reflect the current frequency type and points.
        /// </summary>
        /// <remarks>
        /// This method retrieves the frequency configuration and:
        /// - Sets the appropriate frequency type radio button (Others, North America, Europe, China)
        /// - Checks the corresponding frequency points in the checkedlibFrePoint control
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadFrequencySettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Get frequency type and points from configuration
                string FrequencyType = config.FrequencyType;
                string FrequencyPoints = config.FrequencyPoints;

                // Find the index of the frequency points in the checked list box
                int index = checkedlibFrePoint.Items.IndexOf(FrequencyPoints);

                // Set the appropriate frequency type radio button based on configuration
                if (FrequencyType == "Others")
                {
                    rbFreq_Others.Checked = true;
                }
                else if (FrequencyType == "North America")
                {
                    rbFreq_NAmerica.Checked = true;
                }
                else if (FrequencyType == "Europe")
                {
                    rbFreq_Europe.Checked = true;
                }
                else if ((FrequencyType == "China"))
                {
                    rbFreq_China.Checked = true;
                }

                // Check the corresponding frequency point in the list if it exists
                if (index >= 0)
                {
                    checkedlibFrePoint.SetItemChecked(index, true);
                }
            }
            else
            {
                // Display Persian error message when frequency configuration is not found
                MessageBox.Show("!تنظیمات مربوطه Frequency یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current frequency configuration settings based on the selected radio button
        /// and checked frequency points.
        /// </summary>
        /// <remarks>
        /// This method:
        /// - Determines the frequency type from the selected radio button (Others, North America, Europe, China)
        /// - Collects all selected frequency points from the checkedlibFrePoint control
        /// - Converts the selected points to a comma-separated string
        /// - Persists both frequency type and points to the configuration
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveFrequencySettingConfig()
        {
            string FrequencyType;
            List<string> selectedFrequencies = new List<string>();

            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Determine frequency type based on selected radio button
            if (rbFreq_Others.Checked)
            {
                FrequencyType = "Others";
            }
            else if (rbFreq_NAmerica.Checked)
            {
                FrequencyType = "North America";
            }
            else if (rbFreq_Europe.Checked)
            {
                FrequencyType = "Europe";
            }
            else if (rbFreq_China.Checked)
            {
                FrequencyType = "China";
            }
            else
            {
                // Default value when no radio button is selected
                FrequencyType = "NULL";
            }

            // Collect all selected frequency points from the checked list box
            List<string> selected = new List<string>();
            foreach (var item in checkedlibFrePoint.CheckedItems)
            {
                selected.Add(item.ToString());
            }

            // Convert selected frequencies to array and then to comma-separated string
            string[] selectedArray = selected.ToArray(); // 🔁 تبدیل به آرایه
            string FrequencyPoints = string.Join(",", selectedArray);

            // Save frequency configuration to the config object
            config.FrequencyType = FrequencyType;
            config.FrequencyPoints = FrequencyPoints;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  reader1 ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the Reader 1 configuration settings from the configuration manager
        /// and populates the IP and port textbox controls with the stored values.
        /// </summary>
        /// <remarks>
        /// This method retrieves the Reader 1 network configuration and sets the text values
        /// for tbIP and tbPort textboxes based on the stored R1IP and R1Port values.
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadR1SettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Load Reader 1 IP address into the IP textbox
                this.tbIP.Text = config.R1IP;
                // Load Reader 1 port number into the port textbox
                this.tbPort.Text = config.R1Port;
            }
            else
            {
                // Display Persian error message when Reader 1 configuration is not found
                MessageBox.Show("!تنظیمات مربوطه reader1 یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current Reader 1 configuration settings from the IP and port textbox controls.
        /// </summary>
        /// <remarks>
        /// This method reads the current text values from tbIP and tbPort textboxes
        /// and persists them as R1IP and R1Port values in the configuration.
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveR1SettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Save Reader 1 IP address from the IP textbox
            config.R1IP = this.tbIP.Text;
            // Save Reader 1 port number from the port textbox
            config.R1Port = this.tbPort.Text;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  reader1 ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the Reader 2 configuration settings from the configuration manager
        /// and populates the IP and port textbox controls with the stored values.
        /// </summary>
        /// <remarks>
        /// This method retrieves the Reader 2 network configuration and sets the text values
        /// for tbIP2 and tbPort2 textboxes based on the stored R2IP and R2Port values.
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadR2SettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Load Reader 2 IP address into the second IP textbox
                this.tbIP2.Text = config.R2IP;
                // Load Reader 2 port number into the second port textbox
                this.tbPort2.Text = config.R2Port;
            }
            else
            {
                // Display Persian error message when Reader 2 configuration is not found
                MessageBox.Show("!تنظیمات مربوطه reader2 یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current Reader 2 configuration settings from the IP and port textbox controls.
        /// </summary>
        /// <remarks>
        /// This method reads the current text values from tbIP2 and tbPort2 textboxes
        /// and persists them as R2IP and R2Port values in the configuration.
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveR2SettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Save Reader 2 IP address from the second IP textbox
            config.R2IP = this.tbIP2.Text;
            // Save Reader 2 port number from the second port textbox
            config.R2Port = this.tbPort2.Text;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  reader2 ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the TCP network configuration settings from the configuration manager
        /// and populates the network parameter textbox controls with the stored values.
        /// </summary>
        /// <remarks>
        /// This method retrieves the TCP network configuration and sets the text values for:
        /// - tbTCPPara_IP: IP address from config.IP
        /// - tbTCPPara_Mask: Subnet mask from config.SubnetMask
        /// - tbTCPPara_GateWay: Gateway address from config.GateWay
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadTCPSettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Load TCP IP address into the IP parameter textbox
                this.tbTCPPara_IP.Text = config.IP;
                // Load subnet mask into the mask parameter textbox
                this.tbTCPPara_Mask.Text = config.SubnetMask;
                // Load gateway address into the gateway parameter textbox
                this.tbTCPPara_GateWay.Text = config.GateWay;
            }
            else
            {
                // Display Persian error message when TCP configuration is not found
                MessageBox.Show("!تنظیمات مربوطه TCP یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current TCP network configuration settings from the network parameter textbox controls.
        /// </summary>
        /// <remarks>
        /// This method reads the current text values from the TCP parameter textboxes and persists them:
        /// - tbTCPPara_IP text is saved as config.IP
        /// - tbTCPPara_Mask text is saved as config.SubnetMask
        /// - tbTCPPara_GateWay text is saved as config.GateWay
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        private void SaveTCPSettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Save TCP IP address from the IP parameter textbox
            config.IP = this.tbTCPPara_IP.Text;
            // Save subnet mask from the mask parameter textbox
            config.SubnetMask = this.tbTCPPara_Mask.Text;
            // Save gateway address from the gateway parameter textbox
            config.GateWay = this.tbTCPPara_GateWay.Text;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات  TCP ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }

        /// <summary>
        /// Loads the database configuration settings from the configuration manager
        /// and populates the database connection textbox controls with the stored values.
        /// </summary>
        /// <remarks>
        /// This method retrieves the database configuration and sets the text values for:
        /// - ip_database_info: Database IP address from config.DatabaseIP
        /// - name_database_info: Database name from config.DatabaseName
        /// - username_database_info: Database username from config.Username
        /// - password_database_info: Database password from config.Password
        /// If configuration loading fails or returns null, displays an error message in Persian.
        /// </remarks>
        private void LoadDataBaseSettingConfig()
        {
            var config = ConfigManager.Load();
            if (config != null)
            {
                // Load database IP address into the database IP textbox
                this.ip_database_info.Text = config.DatabaseIP;
                // Load database name into the database name textbox
                this.name_database_info.Text = config.DatabaseName;
                // Load database username into the username textbox
                this.username_database_info.Text = config.Username;
                // Load database password into the password textbox
                this.password_database_info.Text = config.Password;
            }
            else
            {
                // Display Persian error message when database configuration is not found
                MessageBox.Show("!تنظیمات مربوطه یافت نشد");
            }
        }

        /// <summary>
        /// Saves the current database configuration settings from the database connection textbox controls.
        /// </summary>
        /// <remarks>
        /// This method reads the current text values from the database textboxes and persists them:
        /// - ip_database_info text is saved as config.DatabaseIP
        /// - name_database_info text is saved as config.DatabaseName
        /// - username_database_info text is saved as config.Username
        /// - password_database_info text is saved as config.Password
        /// Creates a new configuration object if none exists.
        /// Displays success or error messages in Persian based on the save operation result.
        /// </remarks>
        /// <security>
        /// Note: This method stores database credentials in plain text. Consider implementing
        /// encryption for sensitive information like passwords in production environments.
        /// </security>
        private void SaveDataBaseSettingConfig()
        {
            // Load existing configuration or create new one if it doesn't exist
            var config = ConfigManager.Load() ?? new Config();

            // Save database IP address from the database IP textbox
            config.DatabaseIP = this.ip_database_info.Text;
            // Save database name from the database name textbox
            config.DatabaseName = this.name_database_info.Text;
            // Save database username from the username textbox
            config.Username = this.username_database_info.Text;
            // Save database password from the password textbox (consider encryption)
            config.Password = this.password_database_info.Text;

            // Save configuration and display appropriate message based on success/failure
            if (ConfigManager.Save(config))
                MessageBox.Show("تنظیمات ذخیره شد.");
            else
                MessageBox.Show("خطا در ذخیره تنظیمات");
        }


        /// <summary>
        /// Connection string for the library database using integrated security.
        /// </summary>
        /// <remarks>
        /// This connection string connects to a local SQL Server instance with the LibraryDB database
        /// using Windows Authentication (Integrated Security=true).
        /// </remarks>
        public string connectionString = "Data Source=.;Initial Catalog=LibraryDB;Integrated Security=true";

        /// <summary>
        /// Checks the checkout status of a book using its RFID tag ID.
        /// </summary>
        /// <param name="tagid">The RFID tag ID of the book to check. Defaults to empty string if not provided.</param>
        /// <returns>
        /// A string representing the checkout status (amanatflag) of the book.
        /// Returns empty string if no record is found or if an error occurs.
        /// </returns>
        /// <remarks>
        /// This method executes the "CheckOut" stored procedure to retrieve the checkout status
        /// of a book based on its RFID tag ID. The method:
        /// - Establishes a database connection using the configured connection string
        /// - Executes the CheckOut stored procedure with the provided tag ID
        /// - Returns the amanatflag value which indicates the book's checkout status
        /// - Properly closes the database connection after execution
        /// 
        /// Note: There is commented code that would use dynamic connection string from UI controls,
        /// but currently uses the hardcoded connectionString field.
        /// </remarks>
        private string check_book(string tagid = "")
        {
            // Alternative dynamic connection string construction (currently commented out)
            //SqlConnection sqlconnection = new SqlConnection(
            //    "Data Source=tcp:" + this.ip_database_info.Text +
            //    ";Initial Catalog=" + this.name_database_info.Text +
            //    ";User ID=" + this.username_database_info.Text +
            //    ";Password=" + this.password_database_info.Text);

            // Create database connection using the configured connection string
            SqlConnection sqlconnection = new SqlConnection(connectionString);

            // Set up the stored procedure command
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "CheckOut";
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Connection = sqlconnection;

            // Add the tag ID parameter to the stored procedure
            sqlcommand.Parameters.Add(new SqlParameter("@tagid", tagid));

            // Open connection and execute the stored procedure
            sqlconnection.Open();
            SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

            // Read the checkout status from the result
            string str = "";
            while (sqldatareader.Read())
            {
                str = sqldatareader["amanatflag"].ToString();
            }

            // Close the database connection
            sqlconnection.Close();
            return str;
        }

        /// <summary>
        /// Reads book information from the database using an RFID tag ID.
        /// </summary>
        /// <param name="TID">The RFID tag ID (TID) of the book to retrieve. Defaults to empty string if not provided.</param>
        /// <returns>
        /// A BookInfo object containing the book's details including title, record number, header,
        /// publication date, and registration status. Returns an empty BookInfo object if no record is found.
        /// </returns>
        /// <remarks>
        /// This method executes the "READRFID" stored procedure to retrieve comprehensive book information
        /// based on the RFID tag ID. The method:
        /// - Establishes a database connection using the configured connection string
        /// - Executes the READRFID stored procedure with input and output parameters
        /// - Populates a BookInfo object with the retrieved data (title, record number, header, publication date)
        /// - Determines registration status based on the ReturnVal output parameter
        /// - Displays a Persian message in libInfo if the tag is not registered
        /// - Properly manages database connections and resources
        /// 
        /// The stored procedure returns:
        /// - @ReturnVal: Indicates if the tag is registered (1 = not registered, other = registered)
        /// - @Count_tag: Count of matching tags (currently retrieved but not used)
        /// - Result set with book details: ONVAN, RECORDNO, HEADER, DATEOFPUB
        /// </remarks>
        private BookInfo read_rfid(string rfid)
        {
            // Create database connection using the configured connection string
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Set up the stored procedure command with parameters
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "READRFID",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            // Add input parameter for the book TID
            sqlCommand.Parameters.Add(new SqlParameter("@RFID", rfid));

            // Add output parameter to get the return value (registration status)
            SqlParameter sqlParameter1 = new SqlParameter("@ReturnVal", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            sqlCommand.Parameters.Add(sqlParameter1);

            // Add output parameter to get the count of matching tags
            SqlParameter sqlParameter2 = new SqlParameter("@Count_tag", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            sqlCommand.Parameters.Add(sqlParameter2);

            // Open connection and execute the stored procedure
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Create BookInfo object to hold the retrieved data
            BookInfo bookInfo = new BookInfo();

            // Read book details from the result set
            while (sqlDataReader.Read())
            {
                bookInfo.Title = sqlDataReader["ONVAN"].ToString();
                bookInfo.RecordNo = sqlDataReader["RECORDNO"].ToString();
                bookInfo.Header = sqlDataReader["HEADER"].ToString();
                bookInfo.DateOfPublication = sqlDataReader["DATEOFPUB"].ToString();
                bookInfo.RfidID = sqlDataReader["RFID"].ToString(); // ✅ این خط اضافه بشه
            }

            // Close the data reader before executing non-query to get output parameters
            sqlDataReader.Close();
            sqlCommand.ExecuteNonQuery();

            // Close the database connection
            sqlConnection.Close();

            // Get the return value to determine registration status
            string str1 = sqlParameter1.Value.ToString();

            // Set registration status (if ReturnVal is 1, the tag is not registered)
            bookInfo.IsRegistered = str1 != "1"; // اگر برابر با 1 باشد، یعنی تگ ثبت نشده است

            // Display Persian message if the tag is not registered
            if (!bookInfo.IsRegistered)
            {
                this.libInfo.Items.Add("تگ ثبت نشده است.");
            }

            return bookInfo;
        }
        // Static method to bind grid with columns and clear existing data
        private static void BindGrid(ListViewNF livGen2Identify)
        {
            livGen2Identify.Items.Clear();
            livGen2Identify.Columns.Clear();

            livGen2Identify.Columns.Add("ردیف", 50);
            livGen2Identify.Columns.Add("عنوان", 150);
            livGen2Identify.Columns.Add("شماره جلد", 100);
            livGen2Identify.Columns.Add("تاریخ انتشار", 100);
            livGen2Identify.Columns.Add("شماره ثبت", 100);
            livGen2Identify.Columns.Add("آیدی تگ", 250);
            livGen2Identify.Columns.Add("وضعیت امانت ", 100);
        }

        // Event handler for button1 click - Save R2 setting configuration
        private void button1_Click(object sender, EventArgs e)
        {
            SaveR2SettingConfig();
        }

        // Event handler for button2 click - Load R2 setting configuration
        private void button2_Click(object sender, EventArgs e)
        {
            LoadR2SettingConfig();
        }

        // Event handler for button3 click - Save R1 setting configuration
        private void button3_Click(object sender, EventArgs e)
        {
            SaveR1SettingConfig();
        }

        // Event handler for button4 click - Load R1 setting configuration  
        private void button4_Click(object sender, EventArgs e)
        {
            LoadR1SettingConfig();
        }

        // Event handler for button5 click - Check selected book loan status
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (livGen2Identify.SelectedItems.Count == 0)
                {
                    MessageBox.Show("لطفاً یک ردیف انتخاب کنید.");
                    return;
                }

                // Get selected item
                ListViewItem selectedItem = livGen2Identify.SelectedItems[0];

                string tagId = selectedItem.SubItems[5].Text;  // Get BookTID from hidden column 5

                MessageBox.Show(tagId);

                string status = check_book(tagId);

                MessageBox.Show("وضعیت امانت: " + status); // Check loan status in loans table
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطای اتصال به SQL Server: " + ex.Message);
            }
        }

        // Event handler for button6 click - Read RFID and display book info
        private void button6_Click(object sender, EventArgs e)
        {
            string rfid = RfidTextBox.Text;

            try
            {
                //string tagId = selectedItem.SubItems[5].Text;  // Get BookTID from hidden column 5

                BookInfo info = read_rfid(rfid);

                if (info != null)
                {
                    BindGrid(livGen2Identify);
                    ListViewItem item = new ListViewItem("1"); // Column 0 row number

                    item.SubItems.Add(info.Title);              // Column 1
                    item.SubItems.Add(info.Header);             // Column 2
                    item.SubItems.Add(info.DateOfPublication);  // Column 3
                    item.SubItems.Add(info.RecordNo);  // Column 4
                    item.SubItems.Add(info.RfidID); // Hidden column 5 
                    item.SubItems.Add(info.LoanStatus); // Hidden column 5 
                    //item.Tag = info.BookTID;

                    livGen2Identify.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطای اتصال به SQL Server: " + ex.Message);
            }
        }

        // Event handler for button7 click - Load all books into grid
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid(livGen2Identify);

                int rowIndex = 1;

                foreach (var book in BookInfo.SellectAll())
                {
                    ListViewItem item = new ListViewItem(rowIndex.ToString()); // Row number column

                    // item.SubItems.Add(rowIndex.ToString());

                    item.SubItems.Add(book.Title);              // Column 1
                    item.SubItems.Add(book.Header);             // Column 2
                    item.SubItems.Add(book.DateOfPublication);  // Column 3
                    item.SubItems.Add(book.RecordNo);  // Column 4
                    item.SubItems.Add(book.RfidID);
                    item.SubItems.Add(book.LoanStatus); // Hidden column 5

                    livGen2Identify.Items.Add(item);
                    rowIndex++; // Increment row number
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اجرای read_rfid:\n" + ex.Message);
            }
        }

        // Event handler for button8 click - Open Kiosk form with selected data
        private void button8_Click(object sender, EventArgs e)
        {
            // Create table and get information from main form to send to kiosk form
            DataTable selectedData = new DataTable();
            selectedData.Columns.Add("ردیف");
            selectedData.Columns.Add("عنوان");
            selectedData.Columns.Add("شماره جلد");
            selectedData.Columns.Add("تاریخ انتشار");
            selectedData.Columns.Add(" کد کتاب");
            selectedData.Columns.Add(" کد تگ");
            selectedData.Columns.Add(" وضعیت امانت");

            foreach (ListViewItem item in livGen2Identify.SelectedItems)
            {
                DataRow row = selectedData.NewRow();
                for (int i = 0; i < selectedData.Columns.Count; i++)
                {
                    row[i] = item.SubItems[i].Text;
                }
                selectedData.Rows.Add(row);
            }

            KioskForm form = new KioskForm(selectedData);
            form.Show();
        }

        // Event handler for IO port combobox selection changed (currently empty)  
        private void cbIOPort_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Event handler for frequency points checklist selection changed (currently empty)
        private void checkedlibFrePoint_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Event handler for antenna 1 checkbox changed (currently empty)
        private void chbAnte1_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Event handler for antenna 2 checkbox changed (currently empty)
        private void chbAnte2_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Event handler for get database button click - Load database info
        private void get_database_Click(object sender, EventArgs e)
        {
            this.load_database_info();
            LoadDataBaseSettingConfig();
        }

        // Event handler for group box 5 enter (currently empty)
        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        // Event handler for inventory button click - Open inventory form
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            // Create table and get information from main form to send to inventory form
            DataTable selectedData = new DataTable();
            selectedData.Columns.Add("ردیف");
            selectedData.Columns.Add("عنوان");
            selectedData.Columns.Add("شماره جلد");
            selectedData.Columns.Add("تاریخ انتشار");
            selectedData.Columns.Add(" کد کتاب");
            selectedData.Columns.Add(" کد تگ");
            selectedData.Columns.Add(" وضعیت امانت");

            foreach (ListViewItem item in livGen2Identify.SelectedItems)
            {
                DataRow row = selectedData.NewRow();
                for (int i = 0; i < selectedData.Columns.Count; i++)
                {
                    row[i] = item.SubItems[i].Text;
                }
                selectedData.Rows.Add(row);
            }


            InventoryForm form = new InventoryForm(selectedData);
            form.Show();
        }

        // Event handler for IP database info textbox changed (currently empty)
        private void ip_database_info_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for frequency points label click (currently empty)
        private void lbFreqPoints_Click(object sender, EventArgs e)
        {
        }

        // Event handler for library info selection changed (currently empty)
        private void libInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Event handler for live Gen2 identify selection changed (currently empty)
        private void livGen2Identify_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Method to load database connection information from file
        private void load_database_info()
        {
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            File.WriteAllText("DatabaseInfo", string.Empty);
            using (StreamReader streamReader = new StreamReader("DatabaseInfo"))
            {
                str1 = streamReader.ReadLine() ?? "";
                str2 = streamReader.ReadLine() ?? "";
                str3 = streamReader.ReadLine() ?? "";
                str4 = streamReader.ReadLine() ?? "";
            }
            this.ip_database_info.Text = str1;
            this.name_database_info.Text = str2;
            this.username_database_info.Text = str3;
            this.password_database_info.Text = str4;
        }

        // Event handler for database name textbox changed (currently empty)
        private void name_database_info_TextChanged(object sender, EventArgs e)
        {
        }

        // Method to normalize Persian text characters
        private string normalPersian(string input)
        {
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary1.Add("پ", "1");
            dictionary1.Add("‚", "2");
            dictionary1.Add("ƒ", "3");
            dictionary1.Add("„", "4");
            dictionary1.Add("…", "5");
            dictionary1.Add("†", "6");
            dictionary1.Add("‡", "7");
            dictionary1.Add("ˆ", "8");
            dictionary1.Add("‰", "9");
            dictionary1.Add("€", "0");
            dictionary1.Add("گ", "ا");
            dictionary1.Add("’", "ب");
            dictionary1.Add("•", "پ");
            dictionary1.Add("—", "ت");
            dictionary1.Add("™", "ث");
            dictionary1.Add("›", "ج");
            dictionary1.Add("ں", "ح");
            dictionary1.Add("،", "خ");
            dictionary1.Add("¨", "س");
            dictionary1.Add("ھ", "ش");
            dictionary1.Add("î", "ک");
            dictionary1.Add("ً", "گ");
            dictionary1.Add("َ", "ل");
            dictionary1.Add("ُ", "م");
            dictionary1.Add("÷", "ن");
            dictionary1.Add("ê", "ف");
            dictionary1.Add("ى", "ق");
            dictionary1.Add("¬", "ص");
            dictionary1.Add("®", "ض");
            dictionary1.Add("\u200F", "ی");
            dictionary1.Add("ژ", "ئ");
            dictionary2.Add("چ", "آ");
            dictionary1.Add("'", "ب");
            dictionary1.Add("”", "پ");
            dictionary1.Add("–", "ت");
            dictionary2.Add("ک", "ث");
            dictionary1.Add("ڑ", "ج");
            dictionary1.Add("œ", "چ");
            dictionary1.Add(" ", "خ");
            dictionary1.Add("§", "س");
            dictionary1.Add("©", "ش");
            dictionary1.Add("ي", "ک");
            dictionary1.Add("ï", "گ");
            dictionary1.Add("ٌ", "ل");
            dictionary1.Add("ô", "م");
            dictionary1.Add("ِ", "ن");
            dictionary1.Add("é", "ف");
            dictionary1.Add("ë", "ق");
            dictionary1.Add("\u00AD", "ص");
            dictionary1.Add("«", "ض");
            dictionary1.Add("ü", "ی");
            dictionary1.Add("\u200E", "ی");
            dictionary1.Add("¢", "د");
            dictionary1.Add("£", "ذ");
            dictionary1.Add("¤", "ر");
            dictionary1.Add("¥", "ز");
            dictionary1.Add("¦", "ژ");
            dictionary1.Add("¯", "ط");
            dictionary1.Add("à", "ظ");
            dictionary1.Add("ڈ", "ء");
            dictionary1.Add("ّ", "و");
            dictionary1.Add("'", "ا");
            dictionary1.Add("ٍ", "ال");
            dictionary2.Add("ل", "ع");
            dictionary1.Add("ه", "غ");
            dictionary2.Add("م", "ع");
            dictionary1.Add("ç", "غ");
            dictionary2.Add("ن", "ع");
            dictionary1.Add("û", "ه");
            dictionary1.Add("ù", "ه");
            dictionary1.Add("ْ", "ه");
            dictionary1.Add("(", " - ");
            dictionary1.Add(")", " - ");
            dictionary1.Add("[", " - ");
            dictionary1.Add("]", " - ");
            dictionary1.Add("   ", "");
            dictionary1.Add("ٹ", " , ");
            foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
                input = input.Replace(keyValuePair.Key, keyValuePair.Value);
            foreach (KeyValuePair<string, string> keyValuePair in dictionary1)
                input = input.Replace(keyValuePair.Key, keyValuePair.Value);
            input = mainForm.Reverse(input);
            return input;
        }

        // Event handler for antenna status 1 picture box click (currently empty)
        private void pbAnteStatus1_Click(object sender, EventArgs e)
        {
        }

        // Event handler for green picture box click (currently empty)
        private void pbGreen_Click(object sender, EventArgs e)
        {
        }

        // Event handler for buzzer OFF radio button changed (currently empty)
        private void rbBuzzerOFF_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Event handler for buzzer ON radio button changed (currently empty)
        private void rbBuzzerON_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Event handler for multi fast tag mode radio button changed (currently empty)
        private void rbMultiFastTagMode_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Event handler for single fast tag mode radio button changed (currently empty)
        private void rbSingleFastTagMode_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Static method to reverse a string
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse((Array)charArray);
            return new string(charArray);
        }

        // Method to save database connection information to file
        private void save_database_info(string ip = "", string name = "", string username = "", string password = "")
        {
            File.WriteAllText("DatabaseInfo", string.Empty);
            File.WriteAllText("DatabaseInfo", ip + Environment.NewLine + name + Environment.NewLine + username + Environment.NewLine + password + Environment.NewLine);
        }

        // Event handler for set database button click - Save database info
        private void set_database_Click(object sender, EventArgs e)
        {
            this.save_database_info(this.ip_database_info.Text, this.name_database_info.Text, this.username_database_info.Text, this.password_database_info.Text);
            SaveDataBaseSettingConfig();
        }

        // Event handler for settings tab page click (currently empty)
        private void tabPage_Settings_Click(object sender, EventArgs e)
        {
        }

        // Event handler for IP textbox changed (currently empty)
        private void tbIP_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for IP2 textbox changed (currently empty)
        private void tbIP2_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for Port textbox changed (currently empty)
        private void tbPort_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for Port2 textbox changed (currently empty)
        private void tbPort2_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for Power1 textbox changed (currently empty)
        private void tbPower1_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for Power2 textbox changed (currently empty)
        private void tbPower2_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for TCP parameter gateway textbox changed (currently empty)
        private void tbTCPPara_GateWay_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for TCP parameter IP textbox changed (currently empty)
        private void tbTCPPara_IP_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for TCP parameter mask textbox changed (currently empty)
        private void tbTCPPara_Mask_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for textbox1 changed (currently empty)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Event handler for timer2 tick - Reset previous tag ID and document
        private void timer2_Tick(object sender, EventArgs e)
        {
            prevTagID = "";
            findDoc = null;
        }

        // Event handler for username database info textbox changed (currently empty)
        private void username_database_info_TextChanged(object sender, EventArgs e)
        {
        }
    }
}