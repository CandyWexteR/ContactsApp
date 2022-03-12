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
        private readonly ProjectManager _manager;
        private Contact _listedContact;
        private readonly string _pathToContactsFile = Path.Combine(Directory.GetCurrentDirectory(), "contacts.json");

        public MainForm()
        {
            InitializeComponent();
            _manager = new ProjectManager(null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _manager.Deserialize(_pathToContactsFile);
            BirthdayDateTimePicker.MinDate = DateTime.Now.AddYears(-130);
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            UpdateContactsList();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void UpdateContactsList()
        {
            var contacts = _manager.Project.GetSortedContacts(FindTextBox.Text);


            var visible = contacts.Count != 0;
            panel1.Visible = visible;
            ContactsList.Enabled = visible;

            ContactsList.Items.Clear();
            if (!visible)
            {
                ContactsList.Items.Add("Список контактов пуст");
                return;
            }

            foreach (var item in contacts)
            {
                ContactsList.Items.Add($"{item.Surname} {item.Name}");
            }

            ContactsList.SelectedIndex = 0;
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }


        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAbout();
        }

        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = _manager.Project.GetSortedContacts(FindTextBox.Text);
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
            BirthdayDateTimePicker.Value = _listedContact.BirthDay;

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
            RemoveContact();
        }


        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateContactsList();
        }

        private void F1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                RunAbout();
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BirthdayDateTimePicker.Value = _listedContact.BirthDay;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RunAbout()
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        private void AddContact()
        {
            var editForm = new ContactForm();
            var result = editForm.ShowDialog(this);

            if (result != DialogResult.OK)
                return;

            _manager.Project.AddContact(editForm.Contact.Surname, editForm.Contact.Name,
                editForm.Contact.PhoneNumber.Number, editForm.Contact.BirthDay, editForm.Contact.Email,
                editForm.Contact.IdVk);
            
            _manager.Serialize(_pathToContactsFile);
            UpdateContactsList();
        }

        private void RemoveContact()
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
            _manager.Serialize(_pathToContactsFile);
            UpdateContactsList();
        }
        
        private void EditContact()
        {
            if (_manager.Project.ContactsCount == 0)
            {
                MessageBox.Show("Отсутствуют контакты в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new ContactForm(_listedContact);
            var result = editForm.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            _manager.Project.EditContact(_listedContact.Id, editForm.Contact.Surname, editForm.Contact.Name,
                editForm.Contact.PhoneNumber.Number, editForm.Contact.BirthDay, editForm.Contact.Email,
                editForm.Contact.IdVk);
            _manager.Serialize(_pathToContactsFile);
            UpdateContactsList();
        }
    }
}