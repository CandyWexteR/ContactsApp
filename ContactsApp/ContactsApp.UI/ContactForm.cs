using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContactsApp.Exceptions;

namespace ContactsApp.UI
{
    public partial class ContactForm : Form
    {
        public const string SURNAME_EXAMPLE_TEXT = "Иванов";
        public const string NAME_EXAMPLE_TEXT = "Иван";
        public const string IDVK_EXAMPLE_TEXT = "Тут вписать ID vk.com/{id}";
        public const string EMAIL_EXAMPLE_TEXT = "Пример: usermail@example.com";
        public const string PHONE_EXAMPLE_TEXT = "87654321098";
        public static readonly Color ExampleForeColor = Color.Gray;
        public static readonly Color UsualForeColor = Color.Black;
        public static readonly Color UsualBackgroundColor = Color.White;
        public static readonly Color BrownColor = Color.Brown;

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
            if (SurnameTextBox.ForeColor != ExampleForeColor && SurnameTextBox.Text.Length > 0)
            {
                surname += char.ToUpper(SurnameTextBox.Text[0]);
                surname += SurnameTextBox.Text.Remove(0, 1);
            }

            if (NameTextBox.ForeColor != ExampleForeColor && NameTextBox.Text.Length > 0)
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
                var exceptionsMessages = exception.InnerExceptions.Select(s => $"{s.Message}\n");
                var message = exceptionsMessages.Aggregate(string.Empty, (current, str) => current + str);

                MessageBox.Show(message, "Ошибка при создании/редактировании контакта", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            SurnameTextBox.MaxLength = 50;
            NameTextBox.MaxLength = 50;
            EmailTextBox.MaxLength = 50;
            VkTextBox.MaxLength = 15;
            PhoneTextBox.MaxLength = 11;
            PhoneTextBoxLeave();
            NameTextBoxLeave();
            SurnameTextBoxLeave();
            VkTextBoxLeave();
            EmailTextBoxLeave();
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SurnameTextBox_Enter(object sender, EventArgs e)
        {
            if (SurnameTextBox.ForeColor != ExampleForeColor) return;
            SurnameTextBox.Text = null;
            SurnameTextBox.ForeColor = UsualForeColor;
            SurnameTextBox.BackColor = UsualBackgroundColor;
        }

        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            SurnameTextBoxLeave();
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            if (NameTextBox.ForeColor != ExampleForeColor) return;
            NameTextBox.Text = null;
            NameTextBox.ForeColor = UsualForeColor;
            NameTextBox.BackColor = UsualBackgroundColor;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            NameTextBoxLeave();
        }

        private void PhoneTextBox_Enter(object sender, EventArgs e)
        {
            if (PhoneTextBox.ForeColor != ExampleForeColor) return;
            PhoneTextBox.Text = null;
            PhoneTextBox.ForeColor = UsualForeColor;
            PhoneTextBox.BackColor = UsualBackgroundColor;
        }

        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBoxLeave();
        }

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            if (EmailTextBox.ForeColor != ExampleForeColor) return;
            EmailTextBox.Text = null;
            EmailTextBox.ForeColor = UsualForeColor;
            EmailTextBox.BackColor = UsualBackgroundColor;
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            EmailTextBoxLeave();
        }

        private void VkTextBox_Enter(object sender, EventArgs e)
        {
            if (VkTextBox.ForeColor != ExampleForeColor) return;
            VkTextBox.Text = null;
            VkTextBox.ForeColor = UsualForeColor;
            VkTextBox.BackColor = UsualBackgroundColor;
        }

        private void VkTextBox_Leave(object sender, EventArgs e)
        {
            VkTextBoxLeave();
        }

        private void PhoneTextBoxLeave()
        {
            if (PhoneTextBox.Text.Length != 0) return;

            PhoneTextBox.Text = PHONE_EXAMPLE_TEXT;
            PhoneTextBox.ForeColor = ExampleForeColor;
            PhoneTextBox.BackColor = BrownColor;
        }

        private void NameTextBoxLeave()
        {
            if (NameTextBox.Text.Length != 0) return;
            NameTextBox.Text = NAME_EXAMPLE_TEXT;
            NameTextBox.ForeColor = ExampleForeColor;
            NameTextBox.BackColor = BrownColor;
        }

        private void VkTextBoxLeave()
        {
            if (VkTextBox.Text.Length != 0) return;
            VkTextBox.Text = IDVK_EXAMPLE_TEXT;
            VkTextBox.ForeColor = ExampleForeColor;
        }

        private void EmailTextBoxLeave()
        {
            if (EmailTextBox.Text.Length != 0) return;
            EmailTextBox.Text = EMAIL_EXAMPLE_TEXT;
            EmailTextBox.ForeColor = ExampleForeColor;
        }

        private void SurnameTextBoxLeave()
        {
            if (SurnameTextBox.Text.Length != 0) return;
            SurnameTextBox.Text = SURNAME_EXAMPLE_TEXT;
            SurnameTextBox.ForeColor = ExampleForeColor;
            SurnameTextBox.BackColor = BrownColor;
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