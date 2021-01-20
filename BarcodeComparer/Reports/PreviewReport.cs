using BarcodeComparer.Functions;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodeComparer.Reports
{
    public partial class PreviewReport : Form
    {
        public PreviewReport()
        {
            InitializeComponent();
        }

        private void PreviewReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void PreviewReports()
        {
            LocalReport localReport = new LocalReport();

            WatsonsDataSet dataSet = new WatsonsDataSet();
            string con = "data source=DZPSBLM;initial catalog=Watsons;user id=emvdev;password=emv123!@#;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            SqlConnection cn = new SqlConnection(con);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Barcode where Barcoded = '1' AND Finalized = '1'", cn);

            adapter.Fill(dataSet, dataSet.Barcode.TableName);

            List<ReportParameter> parameters = new List<ReportParameter>();

            parameters.Add(new ReportParameter("ReporterGeneration", Environment.UserName));
            parameters.Add(new ReportParameter("DateGeneration", DateTime.Now.ToShortDateString()));



            ReportDataSource dataSource = new ReportDataSource("DataSet", dataSet.Tables[0]);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
        
    }
}
