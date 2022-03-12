﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContactsApp.Exceptions;

namespace ContactsApp.UI
{
    public partial class ContactForm : Form
    {
        public const string SURNAME_EXAMPLE_TEXT = "Ivanov";
        public const string NAME_EXAMPLE_TEXT = "Ivan";
        public const string IDVK_EXAMPLE_TEXT = "Write here ID vk.com/";
        public const string EMAIL_EXAMPLE_TEXT = "For example: usermail@example.com";
        public const string PHONE_EXAMPLE_TEXT = "9876543210";

        public ContactForm()
        {
            InitializeComponent();
            _contactId = int.MaxValue;
        }

        public ContactForm(Contact contact)
        {
            InitializeComponent();
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.BirthDay;

            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = contact.Email;
            VkTextBox.Text = contact.IdVk;
            _contactId = contact.Id;
        }

        private readonly int _contactId;

        public Contact Contact { get; protected set; }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var surname = string.Empty;
            var name = string.Empty;
            var parsed = long.TryParse(PhoneTextBox.Text == PHONE_EXAMPLE_TEXT
                ? "0"
                : PhoneTextBox.Text, out var number);

            //Сохраняются Фамилия и Имя следующим образом:
            //Первая буква всегда имеет верхний регистр, остальные нижний
            if (SurnameTextBox.ForeColor != Color.Gray && SurnameTextBox.Text.Length > 0)
            {
                surname += char.ToUpper(SurnameTextBox.Text[0]);
                surname += SurnameTextBox.Text.Remove(0, 1);
            }

            if (NameTextBox.ForeColor != Color.Gray && NameTextBox.Text.Length > 0)
            {
                name += char.ToUpper(NameTextBox.Text[0]);
                name += NameTextBox.Text.Remove(0, 1);
            }

            try
            {
                Contact = Contact.Create(_contactId, surname, name, parsed ? number : 0L, BirthdayDateTimePicker.Value,
                    EmailTextBox.Text != EMAIL_EXAMPLE_TEXT ? EmailTextBox.Text : string.Empty,
                    VkTextBox.Text != IDVK_EXAMPLE_TEXT ? VkTextBox.Text : string.Empty);
            }
            catch (AggregateException exception)
            {
                var msgs = exception.InnerExceptions.Select(s => $"{s.Message}\n");
                var msg = msgs.Aggregate(string.Empty, (current, str) => current + str);

                MessageBox.Show(msg, "Ошибка при создании/редактировании контакта", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            PhoneTextBox.MaxLength = 10;
            PhoneTextBox_Leave(sender, e);
            NameTextBox_Leave(sender, e);
            SurnameTextBox_Leave(sender, e);
            VkTextBox_Leave(sender, e);
            EmailTextBox_Leave(sender, e);
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SurnameTextBox_Enter(object sender, EventArgs e)
        {
            if (SurnameTextBox.ForeColor != Color.Gray) return;
            SurnameTextBox.Text = null;
            SurnameTextBox.ForeColor = Color.Black;
            SurnameTextBox.BackColor = Color.White;
        }

        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            if (SurnameTextBox.Text.Length != 0) return;
            SurnameTextBox.Text = SURNAME_EXAMPLE_TEXT;
            SurnameTextBox.ForeColor = Color.Gray;
            SurnameTextBox.BackColor = Color.Brown;
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            if (NameTextBox.ForeColor != Color.Gray) return;
            NameTextBox.Text = null;
            NameTextBox.ForeColor = Color.Black;
            NameTextBox.BackColor = Color.White;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length != 0) return;
            NameTextBox.Text = NAME_EXAMPLE_TEXT;
            NameTextBox.ForeColor = Color.Gray;
            NameTextBox.BackColor = Color.Brown;
        }

        private void PhoneTextBox_Enter(object sender, EventArgs e) //Происходит когда элемент становится активным
        {
            if (PhoneTextBox.ForeColor != Color.Gray) return;
            PhoneTextBox.Text = null;
            PhoneTextBox.ForeColor = Color.Black;
            PhoneTextBox.BackColor = Color.White;
        }

        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            if (PhoneTextBox.Text.Length != 0) return;

            PhoneTextBox.Text = PHONE_EXAMPLE_TEXT;
            PhoneTextBox.ForeColor = Color.Gray;
            PhoneTextBox.BackColor = Color.Brown;
        }

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            if (EmailTextBox.ForeColor != Color.Gray) return;
            EmailTextBox.Text = null;
            EmailTextBox.ForeColor = Color.Black;
            EmailTextBox.BackColor = Color.White;
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length != 0) return;
            EmailTextBox.Text = EMAIL_EXAMPLE_TEXT;
            EmailTextBox.ForeColor = Color.Gray;
        }

        private void VkTextBox_Enter(object sender, EventArgs e)
        {
            if (VkTextBox.ForeColor != Color.Gray) return;
            VkTextBox.Text = null;
            VkTextBox.ForeColor = Color.Black;
            VkTextBox.BackColor = Color.White;
        }

        private void VkTextBox_Leave(object sender, EventArgs e)
        {
            if (VkTextBox.Text.Length != 0) return;
            VkTextBox.Text = IDVK_EXAMPLE_TEXT;
            VkTextBox.ForeColor = Color.Gray;
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) //Проверка введена ли цифра
            {
                e.Handled = true;
            }
        }
    }
}