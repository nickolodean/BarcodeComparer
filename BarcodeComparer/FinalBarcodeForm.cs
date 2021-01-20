using BarcodeComparer.Database;
using BarcodeComparer.Functions;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BarcodeComparer
{
    public partial class FinalBarcodeForm : Form
    {
        public FinalBarcodeForm()
        {
            InitializeComponent();
            ViewData();
        }
        // declare Variables
        private WatsonsEntities _Database = new WatsonsEntities();
        private Regex _Pattern = new Regex("^[0-9]*$");
        private Logs _Logs = new Logs();
        private string _Batch;
        // End of Declarations

        /// <summary>
        /// It triggers the 'ENTER' on the keyboard and compare the data into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinalBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(FinalBarcode.Text) && _Pattern.IsMatch(FinalBarcode.Text))
                {
                    _Logs.CreateLogs(">>>>>> First Barcode: " + FinalBarcode.Text);
                    if (!(FinalBarcode.Text.Length == 13))
                    {
                        FinalBarcode.Text = "";
                        _Logs.CreateLogs(">>>>>> Barcode Error: The barcode length exceeds the limit. Please check the barcode!");
                        MessageBox.Show("The barcode length exceeds the limit. Please check the barcode!");
                    }
                    else
                    {
                        CheckFinalBarcode(FinalBarcode.Text);
                        FinalBarcode.Text = "";
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
        /// used to check and validate the final barcode
        /// </summary>
        /// <param name="Barcode"></param>
        private void CheckFinalBarcode(string Barcode)
        {
            var barcodes = (from barcode in _Database.Barcodes
                            where barcode.Batch == _Batch
                            && barcode.PrintBatch != null
                            && barcode.Finalized == "1"
                            && barcode.Barcodes == Barcode
                            select barcode).ToList();

            if (barcodes.Count() > 0)
            {
                foreach (var barcode in barcodes)
                {
                    if (barcode.Barcodes == Barcode)
                    {
                        barcode.FinalBarcode = "success";
                        barcode.DateTime = DateTime.Now;
                        barcode.User = Environment.UserName;
                        _Database.SaveChanges();
                        ViewData();
                        break;
                    }
                }
                RefreshData();
            }
            else
            {
                MessageBox.Show("Barcode did not match to any barcodes in the database!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FinalBarcode.Text = "";
            }

        }

        /// <summary>
        /// used to refresh and view data
        /// </summary>
        private void ViewData()
        {
            var finalBarcode = (from barcode in _Database.Barcodes
                               where barcode.FinalBarcode != null
                               && barcode.PrintBatch != null
                               && barcode.FinalBarcode == "success"
                               && barcode.Batch == _Batch
                               select new
                               {
                                   barcode.SequenceNumber,
                                   barcode.Barcodes
                               }).ToList();

            FinalBarcodeView.DataSource = finalBarcode;
            FinalBarcodeView.Refresh();
        }

        private void FinalBarcodeForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// used to display all for final barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewAll_Click(object sender, EventArgs e)
        {
            var view = (from barcode in _Database.Barcodes
                       where barcode.Batch == _Batch
                       && barcode.PrintBatch != null
                       && barcode.FinalBarcode == "success"
                        select new
                        {
                            barcode.SequenceNumber,
                            barcode.Barcodes
                        }).ToList();

            FinalBarcodeView.DataSource = view;
            FinalBarcodeView.Refresh();
        }

        /// <summary>
        /// used to finalized all matching barcodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finalize_Click(object sender, EventArgs e)
        {
            _Logs.CreateLogs(">>>>>> Finalizing CSV report ...");
            var barcodes = from barcode in _Database.Barcodes
                           where barcode.Matched == "1"
                           && barcode.Finalized == "0"
                           select barcode;

            if (barcodes.Count() > 0)
            {
                foreach (var barcode in barcodes)
                {
                    barcode.Finalized = "success";
                }
                _Database.SaveChanges();
                _Logs.CreateLogs(">>>>>> Done finalizing csv report ...");
                MessageBox.Show("Done Finalizing Report!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Logs.CreateLogs(">>>>>> All data has been finalize and barcoded.");
                _Logs.CreateLogs(">>>>>> Done finalizing csv report ...");
                MessageBox.Show("No data can be finalize at the moment. \nAll the data has been finalized and barcoded.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to print all the user pre-defined range of data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                MessageBox.Show("Please pick a Batch Name to proceed.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var partialBatch = Interaction.InputBox("Please input a PARTIAL BATCH NAME", "Partial Batch Name");
                var startPrint = Interaction.InputBox("Please input a Starting Print Sequence", "Starting Print Sequence");
                var endPrint = Interaction.InputBox("Please input a Ending Print Sequence", "Ending Print Sequence");

                var printList = (from barcode in _Database.Barcodes
                                 where barcode.Batch == _Batch
                                 && barcode.Matched == "1"
                                 && barcode.Finalized == "success"
                                 && barcode.PrintBatch == null
                                 select barcode).ToList();
                var listToPrint = new List<Barcode>();

                if (printList.Count() > 0)
                {
                    foreach (var list in printList)
                    {
                        if (int.Parse(list.SequenceNumber) >= int.Parse(startPrint) && int.Parse(list.SequenceNumber) <= int.Parse(endPrint))
                        {
                            list.PrintBatch = partialBatch;
                            listToPrint.Add(list);
                        }
                    }
                    _Database.SaveChanges();
                    PrintReport(partialBatch, listToPrint);
                }
                else
                {
                    MessageBox.Show("No data can be printed at the moment!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Function to Re-print the user pre-defined partial batch of the main batch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RePrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                MessageBox.Show("Please pick a Batch Name to proceed.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var partialBatch = Interaction.InputBox("Please input a PARTIAL BATCH NAME", "Partial Batch Name");

                var printList = (from barcode in _Database.Barcodes
                                 where barcode.PrintBatch.ToLower() == partialBatch.ToLower()
                                 && barcode.PrintBatch != null
                                 && barcode.Batch == _Batch
                                 select barcode).ToList(); ;

                if (printList.Count() > 0)
                {
                    PrintReport(partialBatch, printList);
                }
                else
                {
                    MessageBox.Show("No data can be printed at the moment!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// used to print report
        /// </summary>
        /// <param name="Batch"></param>
        /// <param name="ListToPrint"></param>
        private void PrintReport(string Batch, List<Barcode> ListToPrint)
        {

            //sb copy
            LocalReport packingReportSB = new LocalReport();
            packingReportSB.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"Reports\WATSONSXPackingList.rdlc";
            packingReportSB.DataSources.Add(new ReportDataSource("DataSet", ListToPrint));

            List<ReportParameter> packingListParametersSB = new List<ReportParameter>();
            packingListParametersSB.Add(new ReportParameter("Title", "PACKING LIST - SB COPY"));
            packingListParametersSB.Add(new ReportParameter("Batch", Batch));

            packingReportSB.SetParameters(packingListParametersSB);

            //customer copy
            LocalReport packingReportCustomer = new LocalReport();
            packingReportCustomer.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"Reports\WATSONSXPackingList.rdlc";
            packingReportCustomer.DataSources.Add(new ReportDataSource("DataSet", ListToPrint));

            List<ReportParameter> packingListParametersCustomer = new List<ReportParameter>();
            packingListParametersCustomer.Add(new ReportParameter("Title", "PACKING LIST - Customer Copy"));
            packingListParametersCustomer.Add(new ReportParameter("Batch", Batch));

            packingReportCustomer.SetParameters(packingListParametersCustomer);

            //finance copy
            LocalReport packingReportFinance = new LocalReport();
            packingReportFinance.ReportPath = AppDomain.CurrentDomain.BaseDirectory + @"Reports\WATSONSXPackingList.rdlc";
            packingReportFinance.DataSources.Add(new ReportDataSource("DataSet", ListToPrint));

            List<ReportParameter> packingListParametersFinance = new List<ReportParameter>();
            packingListParametersFinance.Add(new ReportParameter("Title", "PACKING LIST - Finance Copy"));
            packingListParametersFinance.Add(new ReportParameter("Batch", Batch));

            packingReportFinance.SetParameters(packingListParametersFinance);

            string deviceInfo =
                 @"<DeviceInfo>
                                        <OutputFormat>EMF</OutputFormat>
                                        <PageWidth>8.27in</PageWidth>
                                        <PageHeight>11.69in</PageHeight>
                                        <MarginTop>0.0in</MarginTop>
                                        <MarginLeft>0.0in</MarginLeft>
                                        <MarginRight>0.0in</MarginRight>
                                        <MarginBottom>0.0in</MarginBottom>
                                    </DeviceInfo>";

            DynamicPrinting packingListPrinting = new DynamicPrinting();
            //sb copy
            packingListPrinting.Export(packingReportSB, deviceInfo);
            packingListPrinting.Print();
            //customer copy
            packingListPrinting.Export(packingReportCustomer, deviceInfo);
            packingListPrinting.Print();

            //finance copy
            packingListPrinting.Export(packingReportFinance, deviceInfo);
            packingListPrinting.Print();
        }

        /// <summary>
        /// used to refresh data from database to final barcode view
        /// </summary>
        private void RefreshData()
        {
            var view = (from barcode in _Database.Barcodes
                        where barcode.Batch == _Batch
                        && barcode.PrintBatch != null
                        && barcode.FinalBarcode == "success"

                        select new
                        {
                            barcode.SequenceNumber,
                            barcode.Barcodes
                        }).ToList();
            ScannedCount.Text = view.Count().ToString();
            FinalBarcodeView.DataSource = view;
            FinalBarcodeView.Refresh();
        }


    }
}
