namespace LibraryIS.Forms
{
    partial class AddBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.Label lblTotalCopies;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtTotalCopies;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.lblTotalCopies = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtTotalCopies = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 23);
            this.lblTitle.Text = "Название:";

            this.txtTitle.Location = new System.Drawing.Point(140, 20);
            this.txtTitle.Size = new System.Drawing.Size(280, 20);

            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 53);
            this.lblAuthor.Text = "Автор:";

            this.txtAuthor.Location = new System.Drawing.Point(140, 50);
            this.txtAuthor.Size = new System.Drawing.Size(280, 20);

            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(20, 83);
            this.lblGenre.Text = "Жанр:";

            this.txtGenre.Location = new System.Drawing.Point(140, 80);
            this.txtGenre.Size = new System.Drawing.Size(280, 20);

            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 113);
            this.lblYear.Text = "Год издания:";

            this.txtYear.Location = new System.Drawing.Point(140, 110);
            this.txtYear.Size = new System.Drawing.Size(280, 20);

            this.lblIsbn.AutoSize = true;
            this.lblIsbn.Location = new System.Drawing.Point(20, 143);
            this.lblIsbn.Text = "ISBN:";

            this.txtIsbn.Location = new System.Drawing.Point(140, 140);
            this.txtIsbn.Size = new System.Drawing.Size(280, 20);

            this.lblTotalCopies.AutoSize = true;
            this.lblTotalCopies.Location = new System.Drawing.Point(20, 173);
            this.lblTotalCopies.Text = "Кол-во экземпляров:";

            this.txtTotalCopies.Location = new System.Drawing.Point(140, 170);
            this.txtTotalCopies.Size = new System.Drawing.Size(280, 20);
            this.txtTotalCopies.Text = "1";

            this.btnAdd.Location = new System.Drawing.Point(140, 215);
            this.btnAdd.Size = new System.Drawing.Size(130, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnCancel.Location = new System.Drawing.Point(290, 215);
            this.btnCancel.Size = new System.Drawing.Size(130, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 264);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblIsbn);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.lblTotalCopies);
            this.Controls.Add(this.txtTotalCopies);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление книги";
        }
    }
}
