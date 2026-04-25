using System;
using System.Windows.Forms;
using LibraryIS.Controllers;
using LibraryIS.Models;

namespace LibraryIS.Forms
{
    public partial class RegisterReaderForm : Form
    {
        private readonly LibraryController _controller;

        public RegisterReaderForm()
        {
            InitializeComponent();
            _controller = new LibraryController();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО читателя.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCardNumber.Text))
            {
                MessageBox.Show("Введите номер читательского билета.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpBirthDate.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения некорректна.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reader = new Models.Reader
            {
                FullName = txtFullName.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                CardNumber = txtCardNumber.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };

            if (_controller.RegisterReader(reader))
            {
                MessageBox.Show("Читатель успешно зарегистрирован.", "Успех",
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
