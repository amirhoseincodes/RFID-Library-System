using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MR6100Demo.Forms
{
    /// <summary>
    /// Form for adding new books or editing existing book information
    /// Supports both Add and Edit modes based on constructor parameters
    /// </summary>
    public partial class AddOrEdit : Form
    {
        // DataTable to hold book information for database operations
        DataTable dt = new DataTable();

        /// <summary>
        /// Constructor for Edit mode - loads existing book data into form fields
        /// </summary>
        /// <param name="selectedRowsData">List containing selected book data from main form</param>
        public AddOrEdit(List<Dictionary<string, string>> selectedRowsData)
        {
            InitializeComponent();

            // Load existing book data into text boxes
            LoadTextBoxs(selectedRowsData);

            // Configure form for edit mode
            buttonAccept.Text = "ویرایش";              // "Edit" in Persian
            labelTitle.Text = "ویرایش اطلاعات کتاب";   // "Edit Book Information" in Persian
        }

        /// <summary>
        /// Default constructor for Add mode - creates empty form for new book entry
        /// </summary>
        public AddOrEdit()
        {
            InitializeComponent();

            // Configure form for add mode
            buttonAccept.Text = "ثبت";          // "Submit/Register" in Persian
            labelTitle.Text = "افزودن کتاب";    // "Add Book" in Persian
        }

        /// <summary>
        /// Loads selected book data into form text boxes for editing
        /// Also prepares DataTable structure for database operations
        /// </summary>
        /// <param name="selectedRowsData">Selected book data from the main form grid</param>
        private void LoadTextBoxs(List<Dictionary<string, string>> selectedRowsData)
        {
            // Validate input data
            if (selectedRowsData == null || selectedRowsData.Count == 0)
            {
                MessageBox.Show("اطلاعاتی برای ویرایش وجود ندارد.");  // "No data available for editing"
                return;
            }

            // Get first selected row data
            var row = selectedRowsData[0];

            // Populate text boxes with existing book data
            textBoxBookName.Text = row["عنوان کتاب"];      // Book Title
            textBoxBookDate.Text = row["تاریخ انتشار"];    // Publication Date
            textBoxBookTag.Text = row["کد تگ"];            // Tag Code (RFID)
            textBoxBookNum.Text = row["کد کتاب"];          // Book Code
            textBoxBookVolume.Text = row["شماره جلد"];     // Volume Number
            textBoxBookLoan.Text = row["وضعیت امانت"];     // Loan Status

            // Create DataTable columns only if they don't exist
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("ردیف");          // Row Number
                dt.Columns.Add("عنوان");         // Title
                dt.Columns.Add("شماره جلد");     // Volume Number
                dt.Columns.Add("تاریخ انتشار");  // Publication Date
                dt.Columns.Add("کد کتاب");       // Book Code
                dt.Columns.Add("کد تگ");         // Tag Code
                dt.Columns.Add("وضعیت امانت");   // Loan Status
            }

            // Add row data to DataTable for database operations
            dt.Rows.Add(
                dt.Rows.Count + 1,          // Row number
                row["عنوان کتاب"],          // Book title
                row["شماره جلد"],           // Volume number
                row["تاریخ انتشار"],        // Publication date
                row["کد کتاب"],             // Book code
                row["کد تگ"],               // Tag code
                row["وضعیت امانت"]          // Loan status
            );
        }

        /// <summary>
        /// Empty event handler for label click - placeholder for future functionality
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
            // Empty event handler - no action required
        }

        /// <summary>
        /// Empty event handler for book number label click - placeholder for future functionality
        /// </summary>
        private void labelBookNum_Click(object sender, EventArgs e)
        {
            // Empty event handler - no action required
        }

        /// <summary>
        /// Handles the accept button click - performs either Edit or Insert operation based on button text
        /// Creates DataTable with form data and calls appropriate BookInfo.Edit method
        /// </summary>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            // Check if form is in Edit mode
            if (buttonAccept.Text == "ویرایش")  // "Edit" in Persian
            {
                // Create DataTable for edit operation
                DataTable dti = new DataTable();

                // Create columns only if they don't exist
                if (dti.Columns.Count == 0)
                {
                    dti.Columns.Add("ردیف");          // Row Number
                    dti.Columns.Add("عنوان");         // Title
                    dti.Columns.Add("شماره جلد");     // Volume Number
                    dti.Columns.Add("تاریخ انتشار");  // Publication Date
                    dti.Columns.Add("کد کتاب");       // Book Code
                    dti.Columns.Add("کد تگ");         // Tag Code
                    dti.Columns.Add("وضعیت امانت");   // Loan Status
                }

                // Add row with updated data from form text boxes
                dti.Rows.Add(
                    dti.Rows.Count + 1,         // Row number
                    textBoxBookName.Text,       // Book title from form
                    textBoxBookVolume.Text,     // Volume number from form
                    textBoxBookDate.Text,       // Publication date from form
                    textBoxBookNum.Text,        // Book code from form
                    textBoxBookTag.Text,        // Tag code from form
                    textBoxBookLoan.Text        // Loan status from form
                );

                // Execute update operation in database
                BookInfo.Edit(dti, "", "CHANGED");
            }
            // Check if form is in Add mode
            else if (buttonAccept.Text == "ثبت")  // "Submit/Register" in Persian
            {
                // Create DataTable for insert operation
                DataTable dti2 = new DataTable();

                // Create columns only if they don't exist
                if (dti2.Columns.Count == 0)
                {
                    dti2.Columns.Add("ردیف");          // Row Number
                    dti2.Columns.Add("عنوان");         // Title
                    dti2.Columns.Add("شماره جلد");     // Volume Number
                    dti2.Columns.Add("تاریخ انتشار");  // Publication Date
                    dti2.Columns.Add("کد کتاب");       // Book Code
                    dti2.Columns.Add("کد تگ");         // Tag Code
                    dti2.Columns.Add("وضعیت امانت");   // Loan Status
                }

                // Add row with new data from form text boxes
                dti2.Rows.Add(
                    dti2.Rows.Count + 1,        // Row number
                    textBoxBookName.Text,       // Book title from form
                    textBoxBookVolume.Text,     // Volume number from form
                    textBoxBookDate.Text,       // Publication date from form
                    textBoxBookNum.Text,        // Book code from form
                    textBoxBookTag.Text,        // Tag code from form
                    textBoxBookLoan.Text        // Loan status from form
                );

                // Execute insert operation in database
                BookInfo.Edit(dti2, "", "INSERT");
            }
        }

        /// <summary>
        /// Form load event handler - placeholder for initialization code
        /// </summary>
        private void AddOrEdit_Load(object sender, EventArgs e)
        {
            // Empty event handler - no initialization required
        }
    }
}