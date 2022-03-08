using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    public partial class MainForm : Form
    {
        private ProjectManager _manager;
        private Contact _listedContact;
        private bool _lastActionEditForm;
        private readonly string _pathToContactsFile = Path.Combine(Directory.GetCurrentDirectory(), "contacts.json");

        public MainForm()
        {
            InitializeComponent();
            _manager = new ProjectManager(null);
        }


        public bool LastActionEditForm
        {
            set => _lastActionEditForm = value;
            get => _lastActionEditForm;
        }

        public ProjectManager Manager
        {
            set => _manager = value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _manager.Deserialize(Path.Combine(Directory.GetCurrentDirectory(), "contacts.json"));
            BirthdayDateTimePicker.MinDate = DateTime.Now.AddYears(-130);
            _lastActionEditForm = false;
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            UpdateContactsList();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void UpdateContactsList()
        {
            if (_lastActionEditForm)
            {
                FindTextBox.Text = null;
                _lastActionEditForm = false;
            }

            var contacts = _manager.Project.GetSortedContacts(FindTextBox.Text, 0, 0);

            if (contacts.Count == 0)
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
                return;
            }
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

            ContactsList.Enabled = true;
            ContactsList.Items.Clear();

            foreach (var item in contacts)
            {
                ContactsList.Items.Add($"{item.Surname} {item.Name}");
            }
            ContactsList.SelectedIndex = 0;
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm(_manager.Project);
            editForm.Owner = this;
            var result = editForm.ShowDialog(this);
            if (result != DialogResult.OK) return;
            _manager.Serialize(_pathToContactsFile);
            UpdateContactsList();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.Project.ContactsCount == 0)
            {
                MessageBox.Show("Отсутствуют контакты в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new EditForm(_manager.Project, _listedContact);
            editForm.Owner = this;
            var result = editForm.ShowDialog(this);
            if (result != DialogResult.OK) return;
            _manager.Serialize(_pathToContactsFile);
            UpdateContactsList();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = (AboutForm) Application.OpenForms["AboutForm"];
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
            var list = _manager.Project.GetSortedContacts(FindTextBox.Text, 0, 0);
            if (list.Count == 0)
                return;
            
            if (ContactsList.SelectedIndex >= list.Count || ContactsList.SelectedIndex < 0)
            {
                ContactsList.SelectedIndex = 0;
                return;
            }
            
            _listedContact = list[ContactsList.SelectedIndex];
            SurnameTextBox.Text = _listedContact.Surname;
            NameTextBox.Text = _listedContact.Name;
            if (_listedContact.BirthDay is not null)
            {
                BirthdayDateTimePicker.Enabled = true;
                BirthdayDateTimePicker.Value = _listedContact.BirthDay.Value;
            }
            else
            {
                BirthdayDateTimePicker.Enabled = false;
                BirthdayDateTimePicker.Value = BirthdayDateTimePicker.MinDate;
            }

            PhoneTextBox.Text = _listedContact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = _listedContact.Email;
            VkTextBox.Text = _listedContact.IdVk;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.Serialize(Path.Combine(Directory.GetCurrentDirectory(), "contacts.json"));
        }

        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manager.Project.ContactsCount == 0)
            {
                MessageBox.Show("Отсутствуют контакты в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = MessageBox.Show(
                "Вы уверены, что хотите удалить контакт '" + _listedContact.Surname + " " + _listedContact.Name + "'?",
                "Подтвердите удаление контакта", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res != DialogResult.OK) return;
            
            _manager.Project.RemoveContact(_listedContact.Id);
            _manager.Serialize(Path.Combine(Directory.GetCurrentDirectory(), "contacts.json"));
            UpdateContactsList();
        }

        
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateContactsList();
        }

        private void F1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AboutToolStripMenuItem_Click(sender, e);
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_listedContact.BirthDay is not null)
            {
                BirthdayDateTimePicker.Value = _listedContact.BirthDay.Value;
            }
        }
    }
}