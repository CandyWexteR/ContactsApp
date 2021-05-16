using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class EditForm : Form
    {
        MainForm _main;
        private DialogResult _dialogResult;
        /// <summary>
        /// Требуется для определения действия.
        /// Если форма открыта для редактирования - true, иначе - false.
        /// </summary>
        private bool _isEdit = true;
        private ProjectManager _manager;
        private Contact _contactBefore;

        public EditForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
        }
        public EditForm(MainForm main, Contact contact)
        {
            InitializeComponent();
            _contactBefore = contact;
            SurenameTextBox.Text = _contactBefore.Surename;
            NameTextBox.Text = _contactBefore.Name;
            BirthdayDateTimePicker.Value = _contactBefore.BirthDay;
            string temp = "+7(" + _contactBefore.Number.Code.ToString() + ")-";
            string numbTemp = _contactBefore.Number.NumberPhone.ToString();
            temp += numbTemp[0];
            temp += numbTemp[1];
            temp += numbTemp[2];
            temp += "-";
            temp += numbTemp[3];
            temp += numbTemp[4];
            temp += "-";
            temp += numbTemp[5];
            temp += numbTemp[6];
            PhoneTextBox.Text = temp;
            EmailTextBox.Text = _contactBefore.Email;
            VkTextBox.Text = _contactBefore.IdVk;
            _main = main;
        }
        public Contact ContactBefore { set => _contactBefore = value; }

        public void SetIsEdit(bool obj)
        {
            _isEdit = obj;
        }

        public ProjectManager Manager { set => _manager = value; }

        private void SurenameTextBox_TextChanged(object sender, EventArgs e)
        {

            if (SurenameTextBox.Text.Length > 50 || SurenameTextBox.Text.Length == 0)
            {
                SurenameTextBox.BackColor = Color.Brown;
                return;
            }

            SurenameTextBox.BackColor = Color.White;
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            if (VkTextBox.Text.Length > 15)
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

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if(PhoneTextBox.Text.Length < 3)
            {
                PhoneTextBox.Text = "+7(";
                PhoneTextBox.SelectionStart = PhoneTextBox.Text.Length;
            }

            string temp = "";

            if (PhoneTextBox.Text[PhoneTextBox.Text.Length - 2] == ')')
            {
                for (int i = 0; i < PhoneTextBox.Text.Length - 2; i++)
                {
                    temp += PhoneTextBox.Text[i];
                }
                PhoneTextBox.Text = temp;
            }

            if (PhoneTextBox.Text[PhoneTextBox.Text.Length-1] == '-')
            {
                for(int i=0;i<PhoneTextBox.Text.Length-1;i++)
                {
                    temp += PhoneTextBox.Text[i];
                }
                PhoneTextBox.Text = temp;
            }

            if (PhoneTextBox.Text.Length == 7)
            {
                for (int i = 0; i < PhoneTextBox.Text.Length - 1; i++)
                {
                    temp += PhoneTextBox.Text[i];
                }
                temp += ")" + "-" + PhoneTextBox.Text[PhoneTextBox.Text.Length - 1];
                PhoneTextBox.Text = temp;
            }

            if (PhoneTextBox.Text.Length == 12 || PhoneTextBox.Text.Length == 15)
            {
                for (int i = 0; i < PhoneTextBox.Text.Length - 1; i++)
                {
                    temp += PhoneTextBox.Text[i];
                }
                temp += "-" + PhoneTextBox.Text[PhoneTextBox.Text.Length - 1];
                PhoneTextBox.Text = temp;
            }

            if (PhoneTextBox.Text.Length > 17 || PhoneTextBox.Text.Length == 3)
            {
                PhoneTextBox.BackColor = Color.Brown;
                return;
            }

            PhoneTextBox.BackColor = Color.White;
            PhoneTextBox.SelectionStart = PhoneTextBox.Text.Length;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length == 0 || SurenameTextBox.Text.Length == 0 || PhoneTextBox.Text.Length < 12)
            {
                MessageBox.Show("Заполните обязательные поля.\n(Имя, фамилия, номер телефона)");
                _dialogResult = DialogResult.Cancel;
                return;
            }
            //Сделать правильное сохранение номера в тип INT
            string surename = "";
            string name = "";
            string _number = "";
            _number += PhoneTextBox.Text[8];
            _number += PhoneTextBox.Text[9];
            _number += PhoneTextBox.Text[10];
            _number += PhoneTextBox.Text[12];
            _number += PhoneTextBox.Text[13];
            _number += PhoneTextBox.Text[15];
            _number += PhoneTextBox.Text[16];
            string _code = "";
            _code += PhoneTextBox.Text[3];
            _code += PhoneTextBox.Text[4];
            _code += PhoneTextBox.Text[5];
            int number;
            int code;
            try
            {
                number = int.Parse(_number);
                code = int.Parse(_code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            PhoneNumber phone = new PhoneNumber(number, code);

            //Сохраняются Фамилия и Имя следующим образом:
            //Первая буква всегда имеет верхний регистр.
            surename += char.ToUpper(SurenameTextBox.Text[0]);
            name += char.ToUpper(NameTextBox.Text[0]);
            if (SurenameTextBox.Text.Length > 1)
            {
                for (int i = 1; i < SurenameTextBox.Text.Length; i++)
                {
                    surename += char.ToLower(SurenameTextBox.Text[i]);
                }
            }
            if (NameTextBox.Text.Length > 1)
            {
                for (int i = 1; i < NameTextBox.Text.Length; i++)
                {
                    name += char.ToLower(NameTextBox.Text[i]);
                }
            }

            DateTime _dateTime = BirthdayDateTimePicker.Value;
            if (_isEdit)
            {
                _manager.EditContact(_contactBefore, new Contact(surename, name, phone, _dateTime, EmailTextBox.Text, VkTextBox.Text));
            }
            else
            {
                _manager.AddContact(new Contact(surename, name, phone, _dateTime, EmailTextBox.Text, VkTextBox.Text));
            }

            Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (PhoneTextBox.Text.Length == 0)
            {
                PhoneTextBox.Text = "+7(999)-999-99-99";
                PhoneTextBox.ForeColor = Color.Gray;
            }
            if (NameTextBox.Text.Length == 0)
            {
                NameTextBox.Text = "Ivan";
                NameTextBox.ForeColor = Color.Gray;
            }
            if (SurenameTextBox.Text.Length == 0)
            {
                SurenameTextBox.Text = "Ivanov";
                SurenameTextBox.ForeColor = Color.Gray;
            }
            if (VkTextBox.Text.Length == 0)
            {
                VkTextBox.Text = "id123123123";
                VkTextBox.ForeColor = Color.Gray;
            }
            if (EmailTextBox.Text.Length == 0)
            {
                EmailTextBox.Text = "usermail@example.com";
                EmailTextBox.ForeColor = Color.Gray;
            }
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            _dialogResult = DialogResult.Cancel;
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurenameTextBox_Enter(object sender, EventArgs e)
        {
            if (SurenameTextBox.ForeColor == Color.Gray)
            {
                SurenameTextBox.Text = null;
                SurenameTextBox.ForeColor = Color.Black;
            }
        }

        private void SurenameTextBox_Leave(object sender, EventArgs e)
        {
            if (SurenameTextBox.Text.Length == 0)
            {
                SurenameTextBox.Text = "Ivanov";
                SurenameTextBox.ForeColor = Color.Gray;
            }
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            if (NameTextBox.ForeColor == Color.Gray)
            {
                NameTextBox.Text = null;
                NameTextBox.ForeColor = Color.Black;
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length == 0)
            {
                NameTextBox.Text = "Ivan";
                NameTextBox.ForeColor = Color.Gray;
            }
        }

        private void PhoneTextBox_Enter(object sender, EventArgs e)//Происходит когда элемент становится активным
        {
            if (PhoneTextBox.ForeColor == Color.Gray)
            {
                PhoneTextBox.Text = null;
                PhoneTextBox.ForeColor = Color.Black;
            }
        }

        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            if (PhoneTextBox.Text.Length < 4)
            {
                PhoneTextBox.Text = "+7(999)-999-99-99";
                PhoneTextBox.ForeColor = Color.Gray;
            }
        }

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {

            if (EmailTextBox.ForeColor == Color.Gray)
            {
                EmailTextBox.Text = null;
                EmailTextBox.ForeColor = Color.Black;
            }
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length == 0)
            {
                EmailTextBox.Text = "usermail@example.com";
                EmailTextBox.ForeColor = Color.Gray;
            }
        }

        private void VkTextBox_Enter(object sender, EventArgs e)
        {

            if (VkTextBox.ForeColor == Color.Gray)
            {
                VkTextBox.Text = null;
                VkTextBox.ForeColor = Color.Black;
            }
        }

        private void VkTextBox_Leave(object sender, EventArgs e)
        {
            if (VkTextBox.Text.Length == 0)
            {
                VkTextBox.Text = "id123456789";
                VkTextBox.ForeColor = Color.Gray;
            }
        }

        private void EditForm_Shown(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)//Проверка введена ли цифра
            {
                e.Handled = true;
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _main.Manager = _manager;
            _main.UpdateContactsList();
            _main.Show();
        }
    }
}
