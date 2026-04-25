namespace LibraryIS.Forms
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblField = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(15, 18);
            this.lblField.Text = "Поле:";

            this.cmbField.Location = new System.Drawing.Point(60, 15);
            this.cmbField.Size = new System.Drawing.Size(140, 21);
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(215, 18);
            this.lblQuery.Text = "Запрос:";

            this.txtQuery.Location = new System.Drawing.Point(270, 15);
            this.txtQuery.Size = new System.Drawing.Size(280, 20);

            this.btnSearch.Location = new System.Drawing.Point(560, 13);
            this.btnSearch.Size = new System.Drawing.Size(110, 25);
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ReadOnly = true;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.Location = new System.Drawing.Point(15, 50);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Size = new System.Drawing.Size(655, 320);
            this.dgvResults.TabIndex = 5;

            this.btnLoan.Location = new System.Drawing.Point(415, 380);
            this.btnLoan.Size = new System.Drawing.Size(120, 30);
            this.btnLoan.Text = "Выдать";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);

            this.btnClose.Location = new System.Drawing.Point(550, 380);
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 425);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnLoan);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск книги";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
        }
    }
}
