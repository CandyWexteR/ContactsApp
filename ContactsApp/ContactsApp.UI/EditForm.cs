using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    public partial class EditForm : Form
    {
        public const string SURNAME_EXAMPLE_TEXT = "Ivanov";
        public const string NAME_EXAMPLE_TEXT = "Ivan";
        public const string IDVK_EXAMPLE_TEXT = "Write here ID vk.com/";
        public const string EMAIL_EXAMPLE_TEXT = "For example: usermail@example.com";

        private Project _project;
        private Contact _contactBefore;

        public EditForm(Project project)
        {
            _project = project;
            InitializeComponent();
        }

        public EditForm(Project project, Contact contact)
        {
            InitializeComponent();
            _contactBefore = contact;
            _project = project;
            SurnameTextBox.Text = _contactBefore.Surname;
            NameTextBox.Text = _contactBefore.Name;
            if (_contactBefore.BirthDay is not null)
            {
                BirthdayDateTimePicker.Value = _contactBefore.BirthDay.Value;
            }

            PhoneTextBox.Text = _contactBefore.PhoneNumber.Number.ToString();
            EmailTextBox.Text = _contactBefore.Email;
            VkTextBox.Text = _contactBefore.IdVk;
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SurnameTextBox.Text.Length > 50 || SurnameTextBox.Text.Length == 0)
            {
                SurnameTextBox.BackColor = Color.Brown;
                return;
            }

            SurnameTextBox.BackColor = Color.White;
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            if (VkTextBox.Text.Length > 15 && VkTextBox.Text != IDVK_EXAMPLE_TEXT)
            {
                VkTextBox.BackColor = Color.Brown;
                return;
            }

            VkTextBox.BackColor = Color.White;
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length > 50)
            {
                EmailTextBox.BackColor = Color.Brown;
                return;
            }

            EmailTextBox.BackColor = Color.White;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length > 50 || NameTextBox.Text.Length == 0)
            {
                NameTextBox.BackColor = Color.Brown;
            }

            NameTextBox.BackColor = Color.White;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length == 0 || SurnameTextBox.Text.Length == 0 || PhoneTextBox.Text.Length != 10)
            {
                MessageBox.Show("Заполните обязательные поля.\n(Имя, фамилия, номер телефона)");
                return;
            }

            var surname = string.Empty;
            var name = string.Empty;
            var number = long.Parse(PhoneTextBox.Text);
            var phone = PhoneNumber.Create(number);

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

            string? email = null;

            if (EmailTextBox.Text != EMAIL_EXAMPLE_TEXT)
            {
                email = EmailTextBox.Text;
            }

            string? idVk = null;
            if (VkTextBox.Text != IDVK_EXAMPLE_TEXT)
            {
                idVk = VkTextBox.Text;
            }

            if (_contactBefore is not null)
            {
                _project.EditContact(_contactBefore.Id, surname, name, phone,
                    BirthdayDateTimePicker.Enabled ? BirthdayDateTimePicker.Value : null, email, idVk);
            }
            else
            {
                _project.AddContact(surname, name, phone,
                    BirthdayDateTimePicker.Enabled ? BirthdayDateTimePicker.Value : null, email, idVk);
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

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
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

            PhoneTextBox.Text = "9876543210";
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