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
    public partial class MainForm : Form
    {
        private ProjectManager _manager = new ProjectManager();
        private EditForm _editForm;
        private Contact listedContact;
        private bool lastActionEditForm;
        int firstIndex;
        int lastIndex;
        public MainForm()
        {
            InitializeComponent();
        }


        public bool LastActionEditForm { set => lastActionEditForm = value; get => lastActionEditForm; }
        public int FirstIndex { get => firstIndex; set => firstIndex = value; }
        public int LastIndex { get => lastIndex; set => lastIndex = value; }

        public ProjectManager Manager { set => _manager = value; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _manager.Deserialize();
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            firstIndex = 0;
            lastIndex = _manager.ContactsCount;
            lastActionEditForm = false;
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            UpdateContactsList();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void UpdateContactsList()
        {
            if (lastActionEditForm)
            {
                firstIndex = 0;
                lastIndex = _manager.ContactsCount;
                FindTextBox.Text = null;
                lastActionEditForm = false;
            }

            if (_manager.ContactsCount == 0)
            {
                SurnameLabel.Visible = false;
                SurnameTextBox.Visible = false;
                NameLabel.Visible = false;
                NameTextBox.Visible = false;
                BirthdayLabel.Visible = false;
                BirthdayDateTimePicker.Visible = false;
                PhoneLabel.Visible = false;
                PhoneTextBox.Visible = false;
                EmailLabel.Visible = false;
                EmailTextBox.Visible = false;
                VkTextBox.Visible = false;
                VkLabel.Visible = false;
                ContactsList.Items.Clear();
                ContactsList.Items.Add("No-ne");
            }
            else
            {
                SurnameLabel.Visible = true;
                SurnameTextBox.Visible = true;
                NameLabel.Visible = true;
                NameTextBox.Visible = true;
                BirthdayLabel.Visible = true;
                BirthdayDateTimePicker.Visible = true;
                PhoneLabel.Visible = true;
                PhoneTextBox.Visible = true;
                EmailLabel.Visible = true;
                EmailTextBox.Visible = true;
                VkTextBox.Visible = true;
                VkLabel.Visible = true;
            }
            if (firstIndex == -1 && lastIndex == -1)
            {
                ContactsList.Items.Clear();
                ContactsList.Items.Add("No-ne");
                SurnameTextBox.Text = null;
                NameTextBox.Text = null;
                PhoneTextBox.Text = null;
                VkTextBox.Text = null;
                EmailTextBox.Text = null;
                BirthdayDateTimePicker.Value = DateTime.Today;
                ContactsList.Enabled = false;
                firstIndex = 0;
                lastIndex = _manager.ContactsCount;
                SurnameLabel.Visible = false;
                SurnameTextBox.Visible = false;
                NameLabel.Visible = false;
                NameTextBox.Visible = false;
                BirthdayLabel.Visible = false;
                BirthdayDateTimePicker.Visible = false;
                PhoneLabel.Visible = false;
                PhoneTextBox.Visible = false;
                EmailLabel.Visible = false;
                EmailTextBox.Visible = false;
                VkTextBox.Visible = false;
                VkLabel.Visible = false;
                return;
            }

            _manager.SortContacts();
            ContactsList.Enabled = true;
            ContactsList.Items.Clear();

            for (int i = firstIndex; i < lastIndex; i++)
            {
                Contact temp = _manager.GetContact(i);
                string s = temp.Surname;
                s += " ";
                s += temp.Name;
                ContactsList.Items.Add(s);
            }
            ContactsList.SelectedIndex = 0;
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editForm = new EditForm(this);
            _editForm.SetIsEdit(false);
            _editForm.Manager = _manager;
            _editForm.Show();
            this.Hide();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.ContactsCount == 0)
            {
                MessageBox.Show("Отсутствуют контакты в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _editForm = new EditForm(this, listedContact);
            _editForm.SetIsEdit(true);
            _editForm.Manager = _manager;
            _editForm.ContactBefore = listedContact;
            _editForm.Show();
            Hide();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = (AboutForm)Application.OpenForms["AboutForm"];
            if (about == null)
            {
                about = new AboutForm();
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }

        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listedContact = _manager.GetContact(ContactsList.SelectedIndex + firstIndex);
            SurnameTextBox.Text = listedContact.Surname;
            NameTextBox.Text = listedContact.Name;
            BirthdayDateTimePicker.Value = listedContact.BirthDay;
            string temp = "+7(" + listedContact.Number.Code.ToString() + ")-";
            string numbTemp = listedContact.Number.NumberPhone.ToString();
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
            EmailTextBox.Text = listedContact.Email;
            VkTextBox.Text = listedContact.IdVk;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.Serialize();
        }

        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.ContactsCount == 0)
            {
                MessageBox.Show("Отсутствуют контакты в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Contact temp = _manager.GetContact(ContactsList.SelectedIndex+firstIndex);
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить контакт '" + temp.Surname + " " + temp.Name + "'?", "Подтвердите удаление контакта", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                _manager.RemoveContact(ContactsList.SelectedIndex+firstIndex);
                _manager.Serialize();
                lastIndex--;
                UpdateContactsList();
            }
            else { return; }
        }

        //Идея для поиска:
        //Найти первый элемент который начинается на заданные буквы
        //Чтобы работало изменение нужно знать его индекс, значит
        //индекс будет равен индексу первого элемента, который начинается на заданные буквы
        //плюс индекс выбранного в listbox
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text.Length == 0)
            {
                firstIndex = 0;
                lastIndex = _manager.ContactsCount;
                UpdateContactsList();
                return;
            }
            if (_manager.ContactsCount == 0)
            {
                MessageBox.Show("Невозможно найти контакты в пустом списке.");
                return;
            }
            string searching = "";
            searching += char.ToUpper(FindTextBox.Text[0]);
            if (FindTextBox.Text.Length > 1)
            {
                for (int i = 1; i < FindTextBox.Text.Length; i++)
                {
                    if (FindTextBox.Text[i] == ' ')
                    {
                        searching += char.ToUpper(FindTextBox.Text[i]);
                    }
                    else
                    {
                        searching += char.ToLower(FindTextBox.Text[i]);
                    }
                }
            }
            FindTextBox.Text = searching;
            FindTextBox.SelectionStart = FindTextBox.Text.Length;
            for (int i = 0; i < _manager.ContactsCount; i++)
            {
                bool isSimmilar = false;
                Contact temp = _manager.GetContact(i);
                string personSurnameAndName = temp.Surname;
                personSurnameAndName += " ";
                personSurnameAndName += temp.Name;
                for (int j = 0; j < searching.Length; j++)
                {
                    if (searching[j] == personSurnameAndName[j])
                    {
                        isSimmilar = true;
                    }
                    else
                    {
                        isSimmilar = false;
                        firstIndex = -1;
                        break;
                    }
                }
                if (isSimmilar)
                {
                    firstIndex = i;
                    break;
                }
            }
            if(firstIndex==-1)
            {
                lastIndex = -1;
                UpdateContactsList();
                return;
            }
            for (int i = _manager.ContactsCount - 1; i >= 0; i--)
            {
                bool isSimmilar = false;
                Contact temp = _manager.GetContact(i);
                string personSurnameAndName = temp.Surname;
                personSurnameAndName += " ";
                personSurnameAndName += temp.Name;
                for (int j = 0; j < searching.Length; j++)
                {
                    if (searching[j] == personSurnameAndName[j])
                    {
                        isSimmilar = true;
                    }
                    else
                    {
                        isSimmilar = false;
                        break;
                    }
                }
                if (isSimmilar)
                {
                    lastIndex = i + 1;
                    break;
                }
            }
            UpdateContactsList();
        }

        private void F1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AboutForm about = (AboutForm)Application.OpenForms["AboutForm"];
                if (about == null)
                {
                    about = new AboutForm();
                    about.Show();
                }
                else
                {
                    about.Activate();
                }
            }
        }
    }
}