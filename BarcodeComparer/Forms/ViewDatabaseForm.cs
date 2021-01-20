using BarcodeComparer.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BarcodeComparer.Forms
{
    public partial class ViewDatabaseForm : Form
    {
        public ViewDatabaseForm()
        {
            InitializeComponent();
        }

        // Declare Variables
        private WatsonsEntities _Database = new WatsonsEntities();
        private Regex _Pattern = new Regex("^[0-9]*$");
        // End of Declaration

        private void ViewDatabaseForm_Load(object sender, EventArgs e)
        {
            GetAllBatchName();
        }

        /// <summary>
        /// it triggers when the tab control changes its tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChosenTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(ChosenTab.SelectedTab.Text)
            {
                case "Tagged":
                    TaggedResult(ChosenBatch.Text);
                    break;
                case "Untagged":
                    UntaggedResult(ChosenBatch.Text);
                    break;
                case "Finalized":
                    FinalizedResult(ChosenBatch.Text);
                    break;
                case "Released":
                    ReleasedResult(ChosenBatch.Text);
                    break;
                case "View All":
                    FullViewResult(ChosenBatch.Text);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// used to display all the barcodes that had been tagged
        /// </summary>
        private void TaggedResult(string _Batch)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where (barcode.Matched == "1"
                                && barcode.Finalized == "0")
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                TaggedView.DataSource = barcoded;
                TaggedView.Refresh();
            }
            else
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where (barcode.Matched == "1"
                                && barcode.Finalized == "0")
                                && barcode.Batch == _Batch
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                TaggedView.DataSource = barcoded;
                TaggedView.Refresh();
            }
        }

        /// <summary>
        /// used to display all untagged barcodes
        /// </summary>
        private void UntaggedResult(string _Batch)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "0"
                                && barcode.Finalized == "0"
                                && barcode.PrintBatch == null
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                UntaggedView.DataSource = barcoded;
                UntaggedView.Refresh();
            }
            else
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "0"
                                && barcode.Finalized == "0"
                                && barcode.PrintBatch == null
                                && barcode.Batch == _Batch
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                UntaggedView.DataSource = barcoded;
                UntaggedView.Refresh();
            }
        }

        /// <summary>
        /// used to display all finalized barcodes
        /// </summary>
        private void FinalizedResult(string _Batch)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "1"
                                && barcode.Finalized == "success"
                                && barcode.PrintBatch == null
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                FinalizedView.DataSource = barcoded;
                FinalizedView.Refresh();
            }
            else
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "1"
                                && barcode.Finalized == "success"
                                && barcode.Batch == _Batch
                                && barcode.PrintBatch == null
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                FinalizedView.DataSource = barcoded;
                FinalizedView.Refresh();
            }
        }

        /// <summary>
        /// used to display all released barcodes / printed barcodes
        /// </summary>
        private void ReleasedResult(string _Batch)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "1"
                                && barcode.Finalized == "1"
                                && barcode.PrintBatch != null
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();
                ReleasedView.DataSource = barcoded;
                ReleasedView.Refresh();
            }
            else
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Matched == "1"
                                && barcode.Finalized == "1"
                                && barcode.PrintBatch != null
                                && barcode.Batch == _Batch
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();
                ReleasedView.DataSource = barcoded;
                ReleasedView.Refresh();
            }
        }

        /// <summary>
        /// used to display all the data in the database
        /// </summary>
        private void FullViewResult(string _Batch, int BoxNumber = 0)
        {
            if (string.IsNullOrEmpty(_Batch))
            {
                var barcoded = (from barcode in _Database.Barcodes
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                FullView.DataSource = barcoded;
                FullView.Refresh();
            }
            else
            {
                var barcoded = (from barcode in _Database.Barcodes
                                where barcode.Batch == _Batch
                                select new
                                {
                                    barcode.SequenceNumber,
                                    barcode.Barcodes,
                                    barcode.PrintBatch,
                                    barcode.Batch
                                }).ToList();


                FullView.DataSource = barcoded;
                FullView.Refresh();
            }
        }

        /// <summary>
        /// Get all batch name from the database
        /// </summary>
        private void GetAllBatchName()
        {
            ChosenBatch.Items.Clear();
            var barcodeList = from barcode in _Database.Barcodes
                              group barcode by new { barcode.Batch } into barcodeGroup
                              select new { Barcode = barcodeGroup.Key };
            if (barcodeList.Count() > 0)
            {
                foreach (var barcodeData in barcodeList)
                {
                    ChosenBatch.Items.Add(barcodeData.Barcode.Batch);
                }
            }
            else
            {
                MessageBox.Show("No batch names that can be showed. Please contact EMV!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// For next update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Pattern.IsMatch(BoxNumber.Text))
                {
                }
                else
                {
                    MessageBox.Show("Please make sure you type the a correct number!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
