using System;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFostik/ContactsApp/tree/develop");
        }

        private void EmailFeedbackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:mr.fostik@mail.ru");
        }
    }
}
