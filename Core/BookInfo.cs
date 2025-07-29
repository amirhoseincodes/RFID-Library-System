using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MR6100Demo
{
    /// <summary>
    /// Represents book information and provides database operations for library books
    /// </summary>
    public class BookInfo
    {
        // Book properties mapped to database columns
        public string Title { get; set; }         // Maps to ONVAN column
        public string RecordNo { get; set; }      // Maps to RECORDNO column
        public string Header { get; set; }        // Maps to HEADER column
        public string DateOfPublication { get; set; } // Maps to DATEOFPUB column
        public string BookTID { get; set; }       // Maps to TID column
        public bool IsRegistered { get; set; }    // Indicates if book is registered in system
        public string RfidID { get; set; }        // Maps to RFID column - unique tag ID
        public string LoanStatus { get; set; }    // Maps to LOAN column - loan status

        /// <summary>
        /// Retrieves all books from the database
        /// </summary>
        /// <returns>List of all BookInfo objects from the Books table</returns>
        public static List<BookInfo> SellectAll()
        {
            List<BookInfo> books = new List<BookInfo>();
            string connectionString = "Data Source=.;Initial Catalog=LibraryDB;Integrated Security=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Read each row and create BookInfo objects
                while (reader.Read())
                {
                    books.Add(new BookInfo
                    {
                        Title = reader["ONVAN"].ToString(),
                        RecordNo = reader["RECORDNO"].ToString(),
                        Header = reader["HEADER"].ToString(),
                        DateOfPublication = reader["DATEOFPUB"].ToString(),
                        BookTID = reader["BookTID"].ToString(),
                        LoanStatus = reader["LOAN"].ToString(),
                        RfidID = reader["RFID"].ToString(),
                        IsRegistered = true // All books from database are considered registered
                    });
                }
            }

            return books;
        }

        /// <summary>
        /// Searches for books based on text matching multiple columns
        /// </summary>
        /// <param name="text">Search text to match against book fields</param>
        /// <returns>DataTable containing matching book records</returns>
        static public DataTable Search(string text)
        {
            string connectionString = "Data Source=.;Initial Catalog=LibraryDB;Integrated Security=true";

            // Search across multiple columns using LIKE operator
            string query = "Select * From Books where ONVAN like @str or HEADER like @str or DATEOFPUB like @str or RFID like @str or RECORDNO like @str or LOAN like @str";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            // Add wildcard characters for partial matching
            adapter.SelectCommand.Parameters.AddWithValue("@str", "%" + text + "%");

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Updates book records in the database based on the specified operation
        /// </summary>
        /// <param name="dt">DataTable containing book data to update</param>
        /// <param name="status">Status value to set (for loan operations)</param>
        /// <param name="porpose">Operation type: "LOAN", "CHANGED", or "INSERT"</param>
        /// <returns>True if any records were successfully updated, false otherwise</returns>
        public static bool Edit(DataTable dt, string status, string porpose)
        {
            bool updated = false;

            try
            {
                string connectionString = "Data Source=.;Initial Catalog=LibraryDB;Integrated Security=true";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Debug information - show number of rows to process
                    MessageBox.Show("تعداد ردیف‌ها: " + dt.Rows.Count);

                    // Debug information - show all column names
                    string allColumns = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                    MessageBox.Show("ستون‌های دیتاتیبل:\n" + allColumns);

                    // Process each row in the DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            // Extract data from DataTable columns (by index)
                            string loan = row[6]?.ToString()?.Trim();    // LOAN column
                            string rfid = row[5]?.ToString()?.Trim();    // RFID column
                            string recnum = row[4]?.ToString()?.Trim();  // RECORDNO column
                            string date = row[3]?.ToString()?.Trim();    // DATEOFPUB column
                            string header = row[2]?.ToString()?.Trim();  // HEADER column
                            string name = row[1]?.ToString()?.Trim();    // ONVAN column

                            // Skip rows with empty RFID
                            if (string.IsNullOrEmpty(rfid))
                            {
                                MessageBox.Show("RFID خالی بود – ادامه می‌دهیم.");
                                continue;
                            }

                            // Debug information - show current RFID being processed
                            MessageBox.Show("RFID from table: [" + rfid + "]");

                            string query = "";
                            SqlCommand cmd = new SqlCommand(query, con);
                            int rowsAffected = 0;

                            // Perform different operations based on purpose parameter
                            switch (porpose)
                            {
                                case "LOAN":
                                    // Update only the loan status
                                    query = "UPDATE Books SET LOAN = @status WHERE RFID = @rfid";
                                    cmd = new SqlCommand(query, con);
                                    using (cmd)
                                    {
                                        cmd.Parameters.AddWithValue("@status", status == "True" ? 1 : 0);
                                        cmd.Parameters.AddWithValue("@rfid", rfid);
                                        rowsAffected = cmd.ExecuteNonQuery();
                                    }
                                    break;

                                case "CHANGED":
                                    // Update all book information
                                    query = "UPDATE Books SET LOAN = @loan, ONVAN = @name, RECORDNO = @recnum, DATEOFPUB = @date, HEADER = @header WHERE RFID = @rfid";

                                    MessageBox.Show("RFID: [" + rfid + "]");

                                    using (cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.AddWithValue("@rfid", rfid.Trim());
                                        cmd.Parameters.AddWithValue("@loan", loan == "True" ? 1 : 0);
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@header", header);
                                        cmd.Parameters.AddWithValue("@date", date);
                                        cmd.Parameters.AddWithValue("@recnum", recnum);

                                        rowsAffected = cmd.ExecuteNonQuery();
                                    }

                                    // Show update result
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("آپدیت موفق: " + rfid);
                                    }
                                    else
                                    {
                                        MessageBox.Show("هیچ ردیفی آپدیت نشد: " + rfid);
                                    }
                                    break;

                                case "INSERT":
                                    // Insert new book record
                                    query = @"
                                        INSERT INTO Books (RFID, LOAN, ONVAN, RECORDNO, DATEOFPUB, HEADER)
                                        VALUES (@rfid, @loan, @name, @recnum, @date, @header)";

                                    using (cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.AddWithValue("@rfid", rfid.Trim());
                                        cmd.Parameters.AddWithValue("@loan", loan == "True" ? 1 : 0);
                                        cmd.Parameters.AddWithValue("@name", name);
                                        cmd.Parameters.AddWithValue("@header", header);
                                        cmd.Parameters.AddWithValue("@date", date);
                                        cmd.Parameters.AddWithValue("@recnum", recnum);

                                        rowsAffected = cmd.ExecuteNonQuery();
                                    }
                                    break;

                                default:
                                    // Unknown operation type
                                    break;
                            }

                            // Check if operation was successful
                            if (rowsAffected > 0)
                            {
                                updated = true;
                                MessageBox.Show("آپدیت شد: " + rfid);
                                Tools.PlaySound(1); // Success sound
                            }
                            else
                            {
                                MessageBox.Show("هیچ ردیفی با این RFID یافت نشد: " + rfid);
                                Tools.PlaySound(4); // Error sound
                            }
                        }
                        catch (Exception w)
                        {
                            // Handle individual row processing errors
                            MessageBox.Show("خطا در آپدیت RFID [" + row["RFID"]?.ToString() + "]: " + w.Message);
                        }
                    }
                }

                return updated;
            }
            catch (Exception ex)
            {
                // Handle general method errors
                MessageBox.Show("خطای کلی در ویرایش وضعیت امانت:\n" + ex.Message);
                return false;
            }
        }
    }
}