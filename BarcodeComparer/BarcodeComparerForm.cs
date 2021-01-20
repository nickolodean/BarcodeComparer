using BarcodeComparer.Database;
using BarcodeComparer.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using BarcodeComparer.Forms;

namespace BarcodeComparer
{
    public partial class BarcodeComparerForm : Form
    {
        public BarcodeComparerForm()
        {
            InitializeComponent();
            _Logs.CreateLogs(">>>>>> Initializing Components ...");
            _Logs.CreateLogs(">>>>>> Start Comparing ...");
            
        }
        // Declare Variables
        private List<BarcodeModel> _Barcodes = new List<BarcodeModel>();
        private string _BarcodeToCompare;
        private Regex _Pattern = new Regex("^[0-9]*$");
        private Logs _Logs = new Logs();
        private WatsonsEntities _Database = new WatsonsEntities();
        private string _FilePath;
        // End of Declarations

        /// <summary>
        /// Used to GET the First Barcode and validate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(FirstBarcode.Text) && _Pattern.IsMatch(FirstBarcode.Text))
                {
                    _Logs.CreateLogs(">>>>>> First Barcode: " + FirstBarcode.Text);
                    if (!(FirstBarcode.Text.Length == 13))
                    {
                        _Logs.CreateLogs(">>>>>> Barcode Error: The barcode length exceeds the limit. Please check the barcode!");
                        MessageBox.Show("The barcode length exceeds the limit. Please check the barcode!");
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    _Logs.CreateLogs(">>>>>> Barcode Error: The Barcode is INVALID or EMPTY! \n Please check your Barcode!");
                    MessageBox.Show("The Barcode is INVALID or EMPTY! \n Please check your Barcode!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Used to GET the Second Barcode and validate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var check = CheckDatabase();
                if (!check)
                {
                    _Logs.CreateLogs(">>>>>> No Database data Detected ...");
                    var csvResult = MessageBox.Show("You don't have a data for comparing. \nLoad CSV now?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (csvResult == DialogResult.Yes)
                    {
                        _Logs.CreateLogs(">>>>>> Choosing CSV ...");
                        LoadCsv.PerformClick();
                        SendKeys.Send("{Enter}");
                        SendKeys.Send("+{TAB}");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(SecondBarcode.Text) && _Pattern.IsMatch(SecondBarcode.Text))
                    {
                        _Logs.CreateLogs(">>>>>> Second Barcode: " + SecondBarcode.Text);
                        if (!(SecondBarcode.Text.Length == 13))
                        {
                            _Logs.CreateLogs(">>>>>> Barcode Error: The barcode length is invalid. Please check the barcode!");
                            MessageBox.Show("The barcode length is invalid. Please check the barcode!","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SecondBarcode.Text = "";
                        }
                        else
                        {
                            _Logs.CreateLogs(">>>>>> Begin comparing barcodes ...");
                            if (FirstBarcode.Text == SecondBarcode.Text)
                            {
                                _BarcodeToCompare = FirstBarcode.Text;
                                CompareBarcode compare = new CompareBarcode(_BarcodeToCompare);
                                SendKeys.Send("+{TAB}");
                                FirstBarcode.Text = "";
                                SecondBarcode.Text = "";
                                UpdateScannedCount();
                            }
                            else
                            {
                                _Logs.CreateLogs(">>>>>> Barcode Error: The barcode does not match. Please check the barcode!");
                                MessageBox.Show("The barcode is not match.\nPlease check the barcode!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        _Logs.CreateLogs(">>>>>> Barcode Error: The Barcode is INVALID or EMPTY! \n Please check your Barcode!");
                        MessageBox.Show("The Barcode is INVALID or EMPTY! \n Please check your Barcode!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }
        
        /// <summary>
        /// Check if the database is empty
        /// </summary>
        /// <returns></returns>
        private bool CheckDatabase()
        {
            var barcodes = (from barcode in _Database.Barcodes
                           select barcode).ToList();
            if (barcodes.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// used to load all batch names and data from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarcodeComparerForm_Load(object sender, EventArgs e)
        {
            UpdateScannedCount();
        }

        /// <summary>
        /// used to view the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewData_Click(object sender, EventArgs e)
        {
            ViewDatabaseForm view = new ViewDatabaseForm();
            view.ShowDialog();
        }

        /// <summary>
        /// Used to GET the CSV File.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCsv_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog selectedFile = new OpenFileDialog();
            _Logs.CreateLogs(">>>>>> Opening file dialog ...");
            if (selectedFile.ShowDialog() == DialogResult.OK)
            {
                _Logs.CreateLogs(">>>>>> File selected: " + selectedFile.FileName);
                _FilePath = selectedFile.FileName;
                MessageBox.Show("You can continue Tagging while the Data is saving.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveToDatabase save = new SaveToDatabase(selectedFile.FileName);

            }
        }

        /// <summary>
        /// used to show the form of final barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinalBarcode_Click_1(object sender, EventArgs e)
        {
            FinalBarcodeForm form = new FinalBarcodeForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Update the scanned count
        /// </summary>
        private void UpdateScannedCount()
        {
            var barcodes = (from barcode in _Database.Barcodes
                            where barcode.Matched == "1"
                            && barcode.Finalized == "0"
                            select barcode).ToList();
            if (barcodes.Count() > 0)
            {
                ScannedCount.Text = barcodes.Count().ToString();
            }
            else
            {
                ScannedCount.Text = "0";
            }
        }

    }
}
