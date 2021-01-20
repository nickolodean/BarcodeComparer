using BarcodeComparer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;
using BarcodeComparer.Models;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using System.IO;

namespace BarcodeComparer.Functions
{
    public class SaveToDatabase
    {
        // Declare Variables
        private WatsonsEntities _Database = new WatsonsEntities();
        private Logs _Logs = new Logs();
        // Declaration of Variables
        
        /// <summary>
        /// used to load and save the data from csv to database
        /// </summary>
        /// <param name="FilePath"></param>
        public SaveToDatabase(string FilePath)
        {
            var engine = new DelimitedFileEngine<CsvStructure>();
            var rows = engine.ReadFile(FilePath);
            var fileName = Path.GetFileNameWithoutExtension(FilePath);
            var result = CheckIfExisted(fileName, rows);

            if (result)
            {
                foreach (var row in rows)
                {
                    using (var database = _Database.Database.BeginTransaction())
                    {
                        try
                        {
                            Barcode barcode = new Barcode();
                            barcode.Matched = row.Barcoded;
                            barcode.BarcodeItem = row.BarItem;
                            barcode.Barcodes = row.Barcode;
                            barcode.CardNumber = MaskedNumber(row.CardNumber);
                            barcode.Filename = row.FileName;
                            barcode.Finalized = row.Finalized;
                            barcode.LeanBarcode = row.LeanBarcode;
                            barcode.LeanBarcodeItem = row.LeanBarItem;
                            barcode.Batch = row.Batch;
                            barcode.SequenceNumber = row.SequenceNumber;
                            barcode.DateTime = DateTime.Now;
                            barcode.User = Environment.UserName;

                            _Database.Barcodes.Add(barcode);
                            _Database.SaveChanges();

                            database.Commit();
                            _Logs.CreateLogs(">>>>>> Sequence Number: " + row.SequenceNumber + " successfully save into the database");
                        }
                        catch (DbEntityValidationException e)
                        {
                            database.Rollback();
                            _Logs.CreateLogs(">>>>>> Database Error: " + e);
                            MessageBox.Show("There's an error loading the file. \nPlease check the logs for more information about the error.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show("CSV successfully saved and loaded!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Logs.CreateLogs(">>>>>> ERROR: File Existed");
            }
        }

        /// <summary>
        /// used to masked all card numbers from the csv file
        /// </summary>
        /// <param name="CardNumber"></param>
        /// <returns></returns>
        private string MaskedNumber(string CardNumber)
        {
            string mask = "";
            mask += CardNumber.Substring(0, 4);
            mask += "XXXXXXXX";
            mask += CardNumber.Substring(mask.Length, 4);

            return mask;
        }

        /// <summary>
        /// Check if the file is existed
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        private bool CheckIfExisted(string FileName, CsvStructure[] Rows)
        {
            var result = false;


            var existingList = from barcode in Rows
                               group barcode by new { barcode.Batch, barcode.FileName } into groupExisting
                               select new { Barcode = groupExisting.Key };

            if (existingList.Count() > 0)
            {
                foreach (var list in existingList)
                {
                    var existing = (from exist in _Database.Barcodes
                                   where exist.Batch == list.Barcode.Batch
                                   && exist.Filename == list.Barcode.FileName
                                   select exist).ToList();
                    if (existing.Count() > 0)
                    {
                        MessageBox.Show("This file was already uploaded!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            return result;
        }



    }
}
