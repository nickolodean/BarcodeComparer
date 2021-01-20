namespace BarcodeComparer
{
    partial class BarcodeComparerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.FinalBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewData = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SecondBarcode = new System.Windows.Forms.TextBox();
            this.FirstBarcode = new System.Windows.Forms.TextBox();
            this.watsonsDataSet = new BarcodeComparer.WatsonsDataSet();
            this.watsonsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.watsonsViewTableAdapter = new BarcodeComparer.WatsonsDataSetTableAdapters.WatsonsViewTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ScannedCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watsonsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watsonsViewBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadCsv,
            this.FinalBarcode});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // LoadCsv
            // 
            this.LoadCsv.Name = "LoadCsv";
            this.LoadCsv.Size = new System.Drawing.Size(145, 22);
            this.LoadCsv.Text = "LoadCsv";
            this.LoadCsv.Click += new System.EventHandler(this.LoadCsv_Click_1);
            // 
            // FinalBarcode
            // 
            this.FinalBarcode.Name = "FinalBarcode";
            this.FinalBarcode.Size = new System.Drawing.Size(145, 22);
            this.FinalBarcode.Text = "Final Barcode";
            this.FinalBarcode.Click += new System.EventHandler(this.FinalBarcode_Click_1);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewData});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ViewData
            // 
            this.ViewData.Name = "ViewData";
            this.ViewData.Size = new System.Drawing.Size(126, 22);
            this.ViewData.Text = "View Data";
            this.ViewData.Click += new System.EventHandler(this.ViewData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SecondBarcode);
            this.groupBox1.Controls.Add(this.FirstBarcode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcodes";
            // 
            // SecondBarcode
            // 
            this.SecondBarcode.Location = new System.Drawing.Point(12, 63);
            this.SecondBarcode.Name = "SecondBarcode";
            this.SecondBarcode.Size = new System.Drawing.Size(469, 29);
            this.SecondBarcode.TabIndex = 1;
            this.SecondBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SecondBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecondBarcode_KeyDown);
            // 
            // FirstBarcode
            // 
            this.FirstBarcode.Location = new System.Drawing.Point(12, 28);
            this.FirstBarcode.Name = "FirstBarcode";
            this.FirstBarcode.Size = new System.Drawing.Size(469, 29);
            this.FirstBarcode.TabIndex = 0;
            this.FirstBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstBarcode_KeyDown);
            // 
            // watsonsDataSet
            // 
            this.watsonsDataSet.DataSetName = "WatsonsDataSet";
            this.watsonsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // watsonsViewBindingSource
            // 
            this.watsonsViewBindingSource.DataMember = "WatsonsView";
            this.watsonsViewBindingSource.DataSource = this.watsonsDataSet;
            // 
            // watsonsViewTableAdapter
            // 
            this.watsonsViewTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScannedCount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // ScannedCount
            // 
            this.ScannedCount.AutoSize = true;
            this.ScannedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScannedCount.Location = new System.Drawing.Point(98, 25);
            this.ScannedCount.Name = "ScannedCount";
            this.ScannedCount.Size = new System.Drawing.Size(136, 25);
            this.ScannedCount.TabIndex = 1;
            this.ScannedCount.Text = "Scanned Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scanned: ";
            // 
            // BarcodeComparerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 189);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(511, 228);
            this.MinimumSize = new System.Drawing.Size(511, 228);
            this.Name = "BarcodeComparerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Comparer";
            this.Load += new System.EventHandler(this.BarcodeComparerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watsonsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watsonsViewBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SecondBarcode;
        private System.Windows.Forms.TextBox FirstBarcode;
        private WatsonsDataSet watsonsDataSet;
        private System.Windows.Forms.BindingSource watsonsViewBindingSource;
        private WatsonsDataSetTableAdapters.WatsonsViewTableAdapter watsonsViewTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ScannedCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadCsv;
        private System.Windows.Forms.ToolStripMenuItem FinalBarcode;
    }
}

