using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BarcodeComparer.Functions
{
    public class Logs
    {
        public void CreateLogs(string logs)
        {
            //
            // parent path for logs
            //
            string parentPath = AppDomain.CurrentDomain.BaseDirectory;
            //
            // top level path
            //
            string topLevelPath = parentPath + @"\logs";
            //
            // sub folder path
            //
            string logFilePath = topLevelPath + @"\" + Environment.UserName + "_" + DateTime.Now.ToString("MMddyyyy");
            //
            // create file
            //
            Directory.CreateDirectory(topLevelPath);
            if (!File.Exists(logFilePath))
            {
                File.AppendAllText(logFilePath, logs + "\t" + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(logFilePath, logs + "\t" + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            }
        }
    }
}
