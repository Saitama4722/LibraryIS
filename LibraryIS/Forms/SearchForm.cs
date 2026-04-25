using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibraryIS.Controllers;
using LibraryIS.Models;

namespace LibraryIS.Forms
{
    public partial class SearchForm : Form
    {
        private readonly LibraryController _controller;
        private List<Book> _results = new List<Book>();

        public SearchForm()
        {
            InitializeComponent();
            _controller = new LibraryController();
            cmbField.Items.AddRange(new object[] { "Название", "Автор", "Жанр" });
            cmbField.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuery.Text))
            {
                MessageBox.Show("Введите значение для поиска.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string field = cmbField.SelectedItem != null ? cmbField.SelectedItem.ToString() : "Название";
            _results = _controller.FindBook(field, txtQuery.Text.Trim());
            dgvResults.DataSource = null;
            dgvResults.DataSource = _results;

            if (_results.Count == 0)
            {
                MessageBox.Show("По вашему запросу ничего не найдено.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow == null || dgvResults.CurrentRow.Index < 0
                || dgvResults.CurrentRow.Index >= _results.Count)
            {
                MessageBox.Show("Выберите книгу для выдачи.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = _results[dgvResults.CurrentRow.Index];
            if (book.AvailableCopies <= 0)
            {
                MessageBox.Show("Нет доступных экземпляров для выдачи.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_controller.LoanBook(book))
            {
                MessageBox.Show("Книга выдана.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSearch_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
