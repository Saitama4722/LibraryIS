using System;
using System.Windows.Forms;
using LibraryIS.Controllers;

namespace LibraryIS.Forms
{
    public partial class MainForm : Form
    {
        private readonly LibraryController _controller;

        public MainForm()
        {
            InitializeComponent();
            _controller = new LibraryController();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var books = _controller.GetAllBooks();
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = books;

            if (dgvBooks.Columns["Id"] != null) dgvBooks.Columns["Id"].HeaderText = "№";
            if (dgvBooks.Columns["Title"] != null) dgvBooks.Columns["Title"].HeaderText = "Название";
            if (dgvBooks.Columns["Author"] != null) dgvBooks.Columns["Author"].HeaderText = "Автор";
            if (dgvBooks.Columns["Genre"] != null) dgvBooks.Columns["Genre"].HeaderText = "Жанр";
            if (dgvBooks.Columns["Year"] != null) dgvBooks.Columns["Year"].HeaderText = "Год";
            if (dgvBooks.Columns["ISBN"] != null) dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
            if (dgvBooks.Columns["TotalCopies"] != null) dgvBooks.Columns["TotalCopies"].HeaderText = "Всего";
            if (dgvBooks.Columns["AvailableCopies"] != null) dgvBooks.Columns["AvailableCopies"].HeaderText = "Доступно";

            int readersCount = _controller.GetAllReaders().Count;
            tsslBooksCount.Text = "Всего книг: " + books.Count;
            tsslReadersCount.Text = "Всего читателей: " + readersCount;
        }

        private void miAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new AddBookForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void miSearchBook_Click(object sender, EventArgs e)
        {
            using (var form = new SearchForm())
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        private void miRegisterReader_Click(object sender, EventArgs e)
        {
            using (var form = new RegisterReaderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информационная система библиотеки\nВерсия 1.0\n© 2026",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
