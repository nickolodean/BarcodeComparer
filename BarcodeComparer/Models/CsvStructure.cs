using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace BarcodeComparer.Models
{
    [DelimitedRecord("|")]
    [IgnoreFirst(1)]
    public class CsvStructure
    {
        public string SequenceNumber { get; set; }

        public string CardNumber { get; set; }

        public string Barcode { get; set; }

        public string LeanBarcode { get; set; }

        public string BarItem { get; set; }

        public string LeanBarItem { get; set; }

        public string FileName { get; set; }

        public string Barcoded { get; set; }

        public string Finalized { get; set; }

        public string Batch { get; set; }


    }
}
