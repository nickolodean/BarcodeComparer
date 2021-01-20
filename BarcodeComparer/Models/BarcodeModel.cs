using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeComparer.Functions
{
    public class BarcodeModel
    {
        public BarcodeModel(string firstBarcode, string secondBarcode, string result)
        {
            FirstBarcode = firstBarcode;
            SecondBarcode = secondBarcode;
            Result = result;
        }

        public string FirstBarcode;
        public string SecondBarcode;
        public string Result;
    }
}
