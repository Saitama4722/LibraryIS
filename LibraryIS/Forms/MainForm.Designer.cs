namespace LibraryIS.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miBooks;
        private System.Windows.Forms.ToolStripMenuItem miAddBook;
        private System.Windows.Forms.ToolStripMenuItem miSearchBook;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miReaders;
        private System.Windows.Forms.ToolStripMenuItem miRegisterReader;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslBooksCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslReadersCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddBook = new System.Windows.Forms.ToolStripMenuItem();
            this.miSearchBook = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miReaders = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegisterReader = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslBooksCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReadersCount = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miBooks, this.miReaders, this.miHelp });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(900, 24);
            this.menuStrip.TabIndex = 0;

            this.miBooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miAddBook, this.miSearchBook, this.miExit });
            this.miBooks.Name = "miBooks";
            this.miBooks.Text = "Книги";

            this.miAddBook.Name = "miAddBook";
            this.miAddBook.Text = "Добавить книгу";
            this.miAddBook.Click += new System.EventHandler(this.miAddBook_Click);

            this.miSearchBook.Name = "miSearchBook";
            this.miSearchBook.Text = "Поиск книги";
            this.miSearchBook.Click += new System.EventHandler(this.miSearchBook_Click);

            this.miExit.Name = "miExit";
            this.miExit.Text = "Выход";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);

            this.miReaders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miRegisterReader });
            this.miReaders.Name = "miReaders";
            this.miReaders.Text = "Читатели";

            this.miRegisterReader.Name = "miRegisterReader";
            this.miRegisterReader.Text = "Зарегистрировать читателя";
            this.miRegisterReader.Click += new System.EventHandler(this.miRegisterReader_Click);

            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miAbout });
            this.miHelp.Name = "miHelp";
            this.miHelp.Text = "Помощь";

            this.miAbout.Name = "miAbout";
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);

            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(0, 24);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Size = new System.Drawing.Size(900, 500);
            this.dgvBooks.TabIndex = 1;

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslBooksCount, this.tsslReadersCount });
            this.statusStrip.Location = new System.Drawing.Point(0, 524);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(900, 22);
            this.statusStrip.TabIndex = 2;

            this.tsslBooksCount.Name = "tsslBooksCount";
            this.tsslBooksCount.Text = "Всего книг: 0";

            this.tsslReadersCount.Name = "tsslReadersCount";
            this.tsslReadersCount.Text = "Всего читателей: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 546);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система библиотеки";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
        }
    }
}
