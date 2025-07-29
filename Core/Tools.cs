using MR6100Demo.classes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using System.Media;

namespace MR6100Demo
{
    /// <summary>
    /// Utility class providing various helper methods for HTTP requests, data operations, and UI management
    /// </summary>
    class Tools
    {
        /// <summary>
        /// Sends HTTP requests to server and returns JSON response as dictionary
        /// </summary>
        /// <param name="url">API endpoint URL to call</param>
        /// <param name="postData">Data to send in POST request body</param>
        /// <param name="method">HTTP method (GET, POST, etc.)</param>
        /// <param name="contentType">Content type header for the request</param>
        /// <returns>Dictionary containing parsed JSON response, or null if error occurs</returns>
        public static Dictionary<string, object> Request(String url, String postData, String method = "POST", String contentType = "application/x-www-form-urlencoded")
        {
            // Create HTTP request using server URL from settings
            var request = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.Server + url);

            request.Method = method;

            // Handle POST request data
            if (method == "POST")
            {
                var data = Encoding.ASCII.GetBytes(postData);

                if (contentType != "")
                {
                    request.ContentType = contentType;
                    request.ContentLength = data.Length;
                }

                // Write POST data to request stream
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            try
            {
                // Get response and read response stream
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                // Parse JSON response into dictionary
                Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                return values;
            }
            catch (Exception e)
            {
                // Log error to console
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Retrieves book information from database using RFID tag
        /// </summary>
        /// <param name="RFIDTag">RFID tag identifier to search for</param>
        /// <returns>DataTable containing book information, or null if error occurs</returns>
        public static DataTable getBookInfoByRFID(string RFIDTag)
        {
            try
            {
                DataTable dt = new DataTable();
                // Search for book using RFID tag via BookInfo class
                dt = BookInfo.Search(RFIDTag);

                return dt;
            }
            catch (Exception e)
            {
                // Silent exception handling - could log error here
            }
            return null;
        }

        // COMMENTED OUT: Alternative implementation using REST API instead of direct database access
        //public static Document getBookInfoByRFID(string RFIDTag)
        //{
        //    Object cnt;
        //
        //    //var postData = "thing1=hello";
        //    //postData += "&thing2=world";
        //    try
        //    {
        //        Dictionary<string, object> values = Tools.Request("/documents/tag/" + RFIDTag + "/get", "", "GET", "");
        //        try
        //        {
        //            if (!values.TryGetValue("value", out cnt))
        //            {
        //                return null;
        //            };
        //            Document d1 = new Document();
        //            Document d = JsonConvert.DeserializeAnonymousType<Document>(cnt.ToString(), d1);
        //            //Dictionary<string, Object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Object>>(cnt.ToString());
        //            //Document d = dictionary.ToObject<Document>();
        //            return (Document)d;
        //        }
        //        catch (Exception e)
        //        {
        //            // MessageBox.Show(e.ToString());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // MessageBox.Show(e.ToString());
        //    }
        //
        //    return null;
        //}

        /// <summary>
        /// Exports DataGridView content to Excel file
        /// </summary>
        /// <param name="dgv">DataGridView containing data to export</param>
        /// <param name="filePath">File path where Excel file will be saved</param>
        public void ExportToExcel(DataGridView dgv, string filePath)
        {
            // Create new Excel workbook and worksheet
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Books");

            // Export column headers to first row
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                ws.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
            }

            // Export data rows starting from second row
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    ws.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Save workbook to specified file path
            wb.SaveAs(filePath);
        }

        /// <summary>
        /// Loads book list into DataGridView with custom column configuration
        /// </summary>
        /// <param name="dgt">DataGridView to populate with book data</param>
        /// <param name="text">Search text to filter books</param>
        /// <returns>Configured DataGridView with book data</returns>
        public static DataGridView LoadBookList(DataGridView dgt, string text)
        {
            // Get book data from database based on search text
            DataTable dt = BookInfo.Search(text);

            // Clear existing columns and disable auto-generation
            dgt.Columns.Clear(); // Clear previous grid columns
            dgt.AutoGenerateColumns = false;

            // Add manual row number column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ردیف",        // Row Number (Persian)
                Name = "RowNumber",
                Width = 40
            });

            // Add book title column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ONVAN",
                HeaderText = "عنوان کتاب",   // Book Title (Persian)
                Width = 200
            });

            // Add volume number column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HEADER",
                HeaderText = "شماره جلد",    // Volume Number (Persian)
                Width = 60
            });

            // Add publication date column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DATEOFPUB",
                HeaderText = "تاریخ انتشار", // Publication Date (Persian)
                Width = 80
            });

            // Add book code column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RECORDNO",
                HeaderText = "کد کتاب",      // Book Code (Persian)
                Width = 60
            });

            // Add RFID tag column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RFID",
                HeaderText = "کد تگ",        // Tag Code (Persian)
                Width = 200
            });

            // Add loan status column
            dgt.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LOAN",
                HeaderText = "وضعیت امانت",  // Loan Status (Persian)
                Width = 80
            });

            // Bind data to grid
            dgt.DataSource = dt;

            // Add row numbers to the first column
            for (int i = 0; i < dgt.Rows.Count; i++)
            {
                dgt.Rows[i].Cells["RowNumber"].Value = (i + 1).ToString();
            }

            return dgt;
        }

        /// <summary>
        /// Plays audio sound files based on sound number identifier
        /// </summary>
        /// <param name="soundNumber">Sound identifier (0-4) corresponding to different audio files</param>
        public static void PlaySound(int soundNumber)
        {
            string soundPath = "";

            // Select sound file based on number parameter
            switch (soundNumber)
            {
                case 0:
                    // Alarm sound
                    soundPath = Path.Combine(Application.StartupPath, "Assets/Audio/alarm.wav");
                    break;
                case 1:
                    // Success/positive beep
                    soundPath = Path.Combine(Application.StartupPath, "Assets/Audio/beep1.wav");
                    break;
                case 2:
                    // Notification beep
                    soundPath = Path.Combine(Application.StartupPath, "Assets/Audio/beep2.wav");
                    break;
                case 3:
                    // Information beep
                    soundPath = Path.Combine(Application.StartupPath, "Assets/Audio/beep3.wav");
                    break;
                case 4:
                    // Error/warning beep
                    soundPath = Path.Combine(Application.StartupPath, "Assets/Audio/beep4.wav");
                    break;
                default:
                    // Invalid sound number
                    MessageBox.Show("sound number does not exist!");
                    break;
            }

            // Play sound file if it exists
            if (File.Exists(soundPath))
            {
                new SoundPlayer(soundPath).PlaySync(); // PlaySync() for synchronous playback, Play() for asynchronous
            }
        }
    }
}