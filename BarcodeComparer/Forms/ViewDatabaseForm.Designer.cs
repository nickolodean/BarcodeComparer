namespace BarcodeComparer.Forms
{
    partial class ViewDatabaseForm
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
            this.ChosenBatch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChosenTab = new System.Windows.Forms.TabControl();
            this.Tagged = new System.Windows.Forms.TabPage();
            this.TaggedView = new System.Windows.Forms.DataGridView();
            this.Untagged = new System.Windows.Forms.TabPage();
            this.UntaggedView = new System.Windows.Forms.DataGridView();
            this.Finalized = new System.Windows.Forms.TabPage();
            this.FinalizedView = new System.Windows.Forms.DataGridView();
            this.Released = new System.Windows.Forms.TabPage();
            this.ReleasedView = new System.Windows.Forms.DataGridView();
            this.ViewAll = new System.Windows.Forms.TabPage();
            this.FullView = new System.Windows.Forms.DataGridView();
            this.BoxNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChosenTab.SuspendLayout();
            this.Tagged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaggedView)).BeginInit();
            this.Untagged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UntaggedView)).BeginInit();
            this.Finalized.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinalizedView)).BeginInit();
            this.Released.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReleasedView)).BeginInit();
            this.ViewAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChosenBatch
            // 
            this.ChosenBatch.FormattingEnabled = true;
            this.ChosenBatch.Location = new System.Drawing.Point(76, 14);
            this.ChosenBatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChosenBatch.Name = "ChosenBatch";
            this.ChosenBatch.Size = new System.Drawing.Size(180, 29);
            this.ChosenBatch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "BATCH:";
            // 
            // ChosenTab
            // 
            this.ChosenTab.Controls.Add(this.Tagged);
            this.ChosenTab.Controls.Add(this.Untagged);
            this.ChosenTab.Controls.Add(this.Finalized);
            this.ChosenTab.Controls.Add(this.Released);
            this.ChosenTab.Controls.Add(this.ViewAll);
            this.ChosenTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ChosenTab.Location = new System.Drawing.Point(0, 51);
            this.ChosenTab.Name = "ChosenTab";
            this.ChosenTab.SelectedIndex = 0;
            this.ChosenTab.Size = new System.Drawing.Size(733, 428);
            this.ChosenTab.TabIndex = 4;
            this.ChosenTab.SelectedIndexChanged += new System.EventHandler(this.ChosenTab_SelectedIndexChanged);
            // 
            // Tagged
            // 
            this.Tagged.BackColor = System.Drawing.Color.White;
            this.Tagged.Controls.Add(this.TaggedView);
            this.Tagged.Location = new System.Drawing.Point(4, 30);
            this.Tagged.Name = "Tagged";
            this.Tagged.Padding = new System.Windows.Forms.Padding(3);
            this.Tagged.Size = new System.Drawing.Size(725, 394);
            this.Tagged.TabIndex = 0;
            this.Tagged.Text = "Tagged";
            // 
            // TaggedView
            // 
            this.TaggedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaggedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaggedView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaggedView.Location = new System.Drawing.Point(3, 3);
            this.TaggedView.Name = "TaggedView";
            this.TaggedView.RowHeadersVisible = false;
            this.TaggedView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaggedView.Size = new System.Drawing.Size(719, 388);
            this.TaggedView.TabIndex = 0;
            // 
            // Untagged
            // 
            this.Untagged.Controls.Add(this.UntaggedView);
            this.Untagged.Location = new System.Drawing.Point(4, 30);
            this.Untagged.Name = "Untagged";
            this.Untagged.Padding = new System.Windows.Forms.Padding(3);
            this.Untagged.Size = new System.Drawing.Size(725, 394);
            this.Untagged.TabIndex = 1;
            this.Untagged.Text = "Untagged";
            this.Untagged.UseVisualStyleBackColor = true;
            // 
            // UntaggedView
            // 
            this.UntaggedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UntaggedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UntaggedView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UntaggedView.Location = new System.Drawing.Point(3, 3);
            this.UntaggedView.Name = "UntaggedView";
            this.UntaggedView.RowHeadersVisible = false;
            this.UntaggedView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UntaggedView.Size = new System.Drawing.Size(719, 388);
            this.UntaggedView.TabIndex = 1;
            // 
            // Finalized
            // 
            this.Finalized.Controls.Add(this.FinalizedView);
            this.Finalized.Location = new System.Drawing.Point(4, 30);
            this.Finalized.Name = "Finalized";
            this.Finalized.Size = new System.Drawing.Size(725, 394);
            this.Finalized.TabIndex = 2;
            this.Finalized.Text = "Finalized";
            this.Finalized.UseVisualStyleBackColor = true;
            // 
            // FinalizedView
            // 
            this.FinalizedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FinalizedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinalizedView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinalizedView.Location = new System.Drawing.Point(0, 0);
            this.FinalizedView.Name = "FinalizedView";
            this.FinalizedView.RowHeadersVisible = false;
            this.FinalizedView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FinalizedView.Size = new System.Drawing.Size(725, 394);
            this.FinalizedView.TabIndex = 1;
            // 
            // Released
            // 
            this.Released.Controls.Add(this.ReleasedView);
            this.Released.Location = new System.Drawing.Point(4, 30);
            this.Released.Name = "Released";
            this.Released.Size = new System.Drawing.Size(725, 394);
            this.Released.TabIndex = 3;
            this.Released.Text = "Released";
            this.Released.UseVisualStyleBackColor = true;
            // 
            // ReleasedView
            // 
            this.ReleasedView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReleasedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReleasedView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReleasedView.Location = new System.Drawing.Point(0, 0);
            this.ReleasedView.Name = "ReleasedView";
            this.ReleasedView.RowHeadersVisible = false;
            this.ReleasedView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReleasedView.Size = new System.Drawing.Size(725, 394);
            this.ReleasedView.TabIndex = 1;
            // 
            // ViewAll
            // 
            this.ViewAll.Controls.Add(this.FullView);
            this.ViewAll.Location = new System.Drawing.Point(4, 30);
            this.ViewAll.Name = "ViewAll";
            this.ViewAll.Size = new System.Drawing.Size(725, 394);
            this.ViewAll.TabIndex = 4;
            this.ViewAll.Text = "View All";
            this.ViewAll.UseVisualStyleBackColor = true;
            // 
            // FullView
            // 
            this.FullView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FullView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FullView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullView.Location = new System.Drawing.Point(0, 0);
            this.FullView.Name = "FullView";
            this.FullView.RowHeadersVisible = false;
            this.FullView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FullView.Size = new System.Drawing.Size(725, 394);
            this.FullView.TabIndex = 1;
            // 
            // BoxNumber
            // 
            this.BoxNumber.Location = new System.Drawing.Point(315, 14);
            this.BoxNumber.Name = "BoxNumber";
            this.BoxNumber.Size = new System.Drawing.Size(63, 29);
            this.BoxNumber.TabIndex = 5;
            this.BoxNumber.Visible = false;
            this.BoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoxNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "BOX:";
            this.label2.Visible = false;
            // 
            // ViewDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 479);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxNumber);
            this.Controls.Add(this.ChosenTab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChosenBatch);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ViewDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.ViewDatabaseForm_Load);
            this.ChosenTab.ResumeLayout(false);
            this.Tagged.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaggedView)).EndInit();
            this.Untagged.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UntaggedView)).EndInit();
            this.Finalized.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FinalizedView)).EndInit();
            this.Released.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReleasedView)).EndInit();
            this.ViewAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FullView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ChosenBatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl ChosenTab;
        private System.Windows.Forms.TabPage Tagged;
        private System.Windows.Forms.DataGridView TaggedView;
        private System.Windows.Forms.TabPage Untagged;
        private System.Windows.Forms.TabPage Finalized;
        private System.Windows.Forms.DataGridView UntaggedView;
        private System.Windows.Forms.DataGridView FinalizedView;
        private System.Windows.Forms.TabPage Released;
        private System.Windows.Forms.DataGridView ReleasedView;
        private System.Windows.Forms.TabPage ViewAll;
        private System.Windows.Forms.DataGridView FullView;
        private System.Windows.Forms.TextBox BoxNumber;
        private System.Windows.Forms.Label label2;
    }
}