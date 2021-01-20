using System.IO;
using System.Windows.Forms;
using BarcodeComparer.Models;
using FileHelpers;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using BarcodeComparer.Database;

namespace BarcodeComparer.Functions
{
    public class CompareBarcode
    {
        // Declaration Variables
        private Logs _Logs = new Logs();
        private WatsonsEntities _Database = new WatsonsEntities();
        // End of Declarations

        /// <summary>
        /// Check if the Barcode has match in the current csv
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="BarcodeToCompare"></param>
        /// <returns></returns>
        public CompareBarcode(string BarcodeToCompare)
        {
            var barcodes = (from barcode in _Database.Barcodes
                            where barcode.Barcodes == BarcodeToCompare
                            select barcode).FirstOrDefault();

            if (barcodes != null)
            {
                if (barcodes.Matched == "0")
                {
                    barcodes.Matched = "1";
                    barcodes.DateTime = DateTime.Now;
                    barcodes.User = Environment.UserName;
                    _Database.SaveChanges();
                }
                else
                {
                    _Logs.CreateLogs(">>>>>> This barcode is already barcoded");
                    MessageBox.Show("This BARCODE is already Barcoded!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                _Logs.CreateLogs(">>>>>> Barcode Result: FAILED");
                _Logs.CreateLogs(">>>>>> Barcode Error: No barcode for comparing ...");
                MessageBox.Show("Barcode does not match on any data in database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
