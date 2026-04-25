namespace LibraryIS.Forms
{
    partial class RegisterReaderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 23);
            this.lblFullName.Text = "ФИО:";

            this.txtFullName.Location = new System.Drawing.Point(160, 20);
            this.txtFullName.Size = new System.Drawing.Size(280, 20);

            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(20, 53);
            this.lblBirthDate.Text = "Дата рождения:";

            this.dtpBirthDate.Location = new System.Drawing.Point(160, 50);
            this.dtpBirthDate.Size = new System.Drawing.Size(280, 20);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(20, 83);
            this.lblCardNumber.Text = "Номер билета:";

            this.txtCardNumber.Location = new System.Drawing.Point(160, 80);
            this.txtCardNumber.Size = new System.Drawing.Size(280, 20);

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 113);
            this.lblPhone.Text = "Телефон:";

            this.txtPhone.Location = new System.Drawing.Point(160, 110);
            this.txtPhone.Size = new System.Drawing.Size(280, 20);

            this.btnRegister.Location = new System.Drawing.Point(160, 155);
            this.btnRegister.Size = new System.Drawing.Size(140, 30);
            this.btnRegister.Text = "Зарегистрировать";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnCancel.Location = new System.Drawing.Point(310, 155);
            this.btnCancel.Size = new System.Drawing.Size(130, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 204);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterReaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация читателя";
        }
    }
}
