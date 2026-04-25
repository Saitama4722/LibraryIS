using System;
using System.Windows.Forms;
using LibraryIS.Controllers;
using LibraryIS.Models;

namespace LibraryIS.Forms
{
    public partial class AddBookForm : Form
    {
        private readonly LibraryController _controller;

        public AddBookForm()
        {
            InitializeComponent();
            _controller = new LibraryController();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название книги.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Введите автора книги.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text, out year) || year < 0 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Введите корректный год издания.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total;
            if (!int.TryParse(txtTotalCopies.Text, out total) || total < 1)
            {
                MessageBox.Show("Количество экземпляров должно быть не меньше 1.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
                Year = year,
                ISBN = txtIsbn.Text.Trim(),
                TotalCopies = total,
                AvailableCopies = total
            };

            if (_controller.AddBook(book))
            {
                MessageBox.Show("Книга успешно добавлена.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
