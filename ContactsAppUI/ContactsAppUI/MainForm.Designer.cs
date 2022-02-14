
namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FindLabel = new System.Windows.Forms.Label();
            this.ContactsList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.VkLabel = new System.Windows.Forms.Label();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.VkTextBox = new System.Windows.Forms.TextBox();
            this.BirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindLabel
            // 
            this.FindLabel.AutoSize = true;
            this.FindLabel.Location = new System.Drawing.Point(11, 30);
            this.FindLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FindLabel.Name = "FindLabel";
            this.FindLabel.Size = new System.Drawing.Size(33, 13);
            this.FindLabel.TabIndex = 0;
            this.FindLabel.Text = "Find: ";
            // 
            // ContactsList
            // 
            this.ContactsList.FormattingEnabled = true;
            this.ContactsList.Location = new System.Drawing.Point(9, 57);
            this.ContactsList.Margin = new System.Windows.Forms.Padding(2);
            this.ContactsList.Name = "ContactsList";
            this.ContactsList.Size = new System.Drawing.Size(192, 316);
            this.ContactsList.TabIndex = 1;
            this.ContactsList.SelectedIndexChanged += new System.EventHandler(this.ContactsList_SelectedIndexChanged);
            this.ContactsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.removeContactToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            this.addContactToolStripMenuItem.Click += new System.EventHandler(this.AddContactToolStripMenuItem_Click);
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            this.editContactToolStripMenuItem.Click += new System.EventHandler(this.EditContactToolStripMenuItem_Click);
            // 
            // removeContactToolStripMenuItem
            // 
            this.removeContactToolStripMenuItem.Name = "removeContactToolStripMenuItem";
            this.removeContactToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.removeContactToolStripMenuItem.Text = "Remove Contact";
            this.removeContactToolStripMenuItem.Click += new System.EventHandler(this.RemoveContactToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(224, 59);
            this.SurnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(52, 13);
            this.SurnameLabel.TabIndex = 3;
            this.SurnameLabel.Text = "Surname:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(245, 82);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name:";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.AutoSize = true;
            this.BirthdayLabel.Location = new System.Drawing.Point(234, 102);
            this.BirthdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(48, 13);
            this.BirthdayLabel.TabIndex = 5;
            this.BirthdayLabel.Text = "Birthday:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(242, 128);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.PhoneLabel.TabIndex = 6;
            this.PhoneLabel.Text = "Phone:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(244, 150);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(38, 13);
            this.EmailLabel.TabIndex = 7;
            this.EmailLabel.Text = "E-mail:";
            // 
            // VkLabel
            // 
            this.VkLabel.AutoSize = true;
            this.VkLabel.Location = new System.Drawing.Point(240, 173);
            this.VkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VkLabel.Name = "VkLabel";
            this.VkLabel.Size = new System.Drawing.Size(45, 13);
            this.VkLabel.TabIndex = 8;
            this.VkLabel.Text = "vk.com:";
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(286, 57);
            this.SurnameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.ReadOnly = true;
            this.SurnameTextBox.Size = new System.Drawing.Size(306, 20);
            this.SurnameTextBox.TabIndex = 9;
            this.SurnameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(286, 80);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.ReadOnly = true;
            this.NameTextBox.Size = new System.Drawing.Size(306, 20);
            this.NameTextBox.TabIndex = 10;
            this.NameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(286, 125);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.ReadOnly = true;
            this.PhoneTextBox.Size = new System.Drawing.Size(306, 20);
            this.PhoneTextBox.TabIndex = 12;
            this.PhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(286, 148);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.ReadOnly = true;
            this.EmailTextBox.Size = new System.Drawing.Size(306, 20);
            this.EmailTextBox.TabIndex = 13;
            this.EmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // VkTextBox
            // 
            this.VkTextBox.Location = new System.Drawing.Point(286, 171);
            this.VkTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VkTextBox.Name = "VkTextBox";
            this.VkTextBox.ReadOnly = true;
            this.VkTextBox.Size = new System.Drawing.Size(306, 20);
            this.VkTextBox.TabIndex = 14;
            this.VkTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // BirthdayDateTimePicker
            // 
            this.BirthdayDateTimePicker.Enabled = false;
            this.BirthdayDateTimePicker.Location = new System.Drawing.Point(286, 102);
            this.BirthdayDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.BirthdayDateTimePicker.MaxDate = new System.DateTime(2021, 5, 16, 0, 0, 0, 0);
            this.BirthdayDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BirthdayDateTimePicker.Name = "BirthdayDateTimePicker";
            this.BirthdayDateTimePicker.Size = new System.Drawing.Size(127, 20);
            this.BirthdayDateTimePicker.TabIndex = 16;
            this.BirthdayDateTimePicker.Value = new System.DateTime(2021, 5, 16, 0, 0, 0, 0);
            this.BirthdayDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(41, 27);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(160, 20);
            this.FindTextBox.TabIndex = 17;
            this.FindTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            this.FindTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(600, 379);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.BirthdayDateTimePicker);
            this.Controls.Add(this.VkTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.VkLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.BirthdayLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.ContactsList);
            this.Controls.Add(this.FindLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "ContactsAppVS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FindLabel;
        private System.Windows.Forms.ListBox ContactsList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label VkLabel;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox VkTextBox;
        private System.Windows.Forms.DateTimePicker BirthdayDateTimePicker;
        private System.Windows.Forms.TextBox FindTextBox;
    }
}

