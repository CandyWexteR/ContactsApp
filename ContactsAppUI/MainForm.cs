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
        bool searchingMode = false;
        public MainForm()
        {
            InitializeComponent();
        }

        public ProjectManager Manager { set => _manager = value; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _manager.Deserialize();
            BirthdayDateTimePicker.MaxDate = DateTime.Now;
            if(!searchingMode)
            {
                UpdateContactsList();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateContactsList()
        {
            if (_manager.ContactsCount == 0)
            {
                SurenameLabel.Visible = false;
                SurenameTextBox.Visible = false;
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
            }
            else
            {
                SurenameLabel.Visible = true;
                SurenameTextBox.Visible = true;
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
            if (_manager.ContactsCount == 0)
            {
                ContactsList.Items.Clear();
                ContactsList.Items.Add("No-ne");
                ContactsList.Enabled = false;
                return;
            }
            ContactsList.Enabled = true;
            ContactsList.Items.Clear();
            for (int i = 0; i < _manager.ContactsCount; i++)
            {
                Contact temp = _manager.GetContact(i);
                ContactsList.Items.Add(temp.Surename);
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
            _editForm = new EditForm(this,listedContact);
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
            listedContact = _manager.GetContact(ContactsList.SelectedIndex);
            SurenameTextBox.Text = listedContact.Surename;
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
            _manager.RemoveContact(ContactsList.SelectedIndex);
            UpdateContactsList();
        }
    }
}