using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MR6100Demo_gate.Core;
using System.IO;


namespace MR6100Demo.Forms
{
    public partial class KioskForm : Form
    {
        // Mode identifier to track where form was opened from
        string mode = "fromMAIN";

        // Data table to store incoming data
        private DataTable incomingData;

        // Constructor - Initializes form with provided data table
        public KioskForm(DataTable data)
        {
            InitializeComponent();
            incomingData = data;
            dataGridView1.DataSource = incomingData;
            dataGridView1.AutoGenerateColumns = false;
            mode = "fromMAIN";
        }

        // Event handler for the back to main button click
        private void backMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for the refresh/show all books button click
        private void button1_Click(object sender, EventArgs e)
        {
            // To display books, a small change in the search section is enough
            textBox1.Text = " ";
        }

        // Event handler for data grid view cell content click (currently empty)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Event handler for the return book button click
        private void GiveItBackBTN_Click(object sender, EventArgs e)
        {
            bool res = BookInfo.Edit(selectRows("fromSELF"), "False", "LOAN");
            if (res == true)
            {
                MessageBox.Show("موفقیت آمیز بود!");
            }
            else
            {
                MessageBox.Show("عملیات با شکست مواجه شد!");
                Tools.PlaySound(2);
            }
        }

        // Event handler for form load (currently empty)
        private void KioskForm_Load(object sender, EventArgs e)
        {
        }

        // Event handler for label click (currently empty)
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Event handler for the loan book button click
        private void LoanItBTN_Click(object sender, EventArgs e)
        {


            bool res = BookInfo.Edit(selectRows("fromSELF"), "True", "LOAN");
            if (res == true)
            {
                MessageBox.Show("موفقیت آمیز بود!");
            }
            else
            {
                MessageBox.Show("عملیات با شکست مواجه شد!");
                Tools.PlaySound(2);
            }
        }

        // Method to select rows based on the specified mode
        private DataTable selectRows(string mode)
        {
            if (mode == "fromMAIN")
            {
                DataTable selectedRows = incomingData.Clone();  // Create empty copy with same structure

                var selectedRowIndexes = new HashSet<int>();
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                    selectedRowIndexes.Add(cell.RowIndex);

                foreach (int index in selectedRowIndexes)
                {
                    DataGridViewRow row = dataGridView1.Rows[index];
                    if (row.DataBoundItem is DataRowView dataRowView)
                    {
                        selectedRows.ImportRow(dataRowView.Row);
                    }
                }
                return selectedRows;
            }
            else if (mode == "fromSELF")
            {
                DataTable selectedRows = ((DataTable)dataGridView1.DataSource).Clone();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is DataRowView drv)
                    {
                        selectedRows.ImportRow(drv.Row);
                    }
                }
                return selectedRows;
            }
            else
            {
                return incomingData;
            }
        }

        // Event handler for search textbox text changed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Tools.LoadBookList(dataGridView1, textBox1.Text);
        }

        private void ExcelOutBTN_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            string outputPath = Path.Combine(Application.StartupPath, "kiosk_export.xlsx");
            tools.ExportToExcel(dataGridView1, outputPath);
            Process.Start(new ProcessStartInfo("kiosk_export.xlsx") { UseShellExecute = true });
        }
    }
}