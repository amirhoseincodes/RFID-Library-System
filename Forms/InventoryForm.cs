using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MR6100Demo.Forms
{
    public partial class InventoryForm : Form
    {
        // Constructor - Initializes the form components
        public InventoryForm(DataTable selecteddata)
        {
            InitializeComponent();

            dataGridView1.DataSource = selecteddata;
        }

        // Event handler for the Add Book button click
        private void AddBookBTN_Click(object sender, EventArgs e)
        {
            // Send mode to the add and edit form
            AddOrEdit addOrEdit = new AddOrEdit();
            addOrEdit.ShowDialog();
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

        // Event handler for the Edit Book button click
        private void EditBookBTN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dataGridView1.Columns[cell.ColumnIndex].HeaderText;
                    string value = cell.Value?.ToString() ?? "";
                    rowData[columnName] = value;
                }
                var singleRowList = new List<Dictionary<string, string>> { rowData };
                AddOrEdit form = new AddOrEdit(singleRowList);
                form.Show(); // Not ShowDialog
            }
        }

        // Event handler for the Excel export button click
        private void ExcelOutBTN_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            string outputPath = Path.Combine(Application.StartupPath, "inventory_export.xlsx");
            tools.ExportToExcel(dataGridView1, outputPath);
            Process.Start(new ProcessStartInfo("inventory_export.xlsx") { UseShellExecute = true });
        }

        // Event handler for form load (currently empty)
        private void InventoryForm_Load(object sender, EventArgs e)
        {
        }

        // Event handler for search textbox text changed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = BookInfo.Search(textBox1.Text);
            Tools.LoadBookList(dataGridView1, textBox1.Text);
        }
    }
}