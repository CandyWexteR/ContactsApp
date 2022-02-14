
namespace UI
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.BirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.VkTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.VkLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BirthdayDateTimePicker
            // 
            this.BirthdayDateTimePicker.CustomFormat = "";
            this.BirthdayDateTimePicker.Location = new System.Drawing.Point(64, 52);
            this.BirthdayDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.BirthdayDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BirthdayDateTimePicker.Name = "BirthdayDateTimePicker";
            this.BirthdayDateTimePicker.Size = new System.Drawing.Size(132, 20);
            this.BirthdayDateTimePicker.TabIndex = 27;
            this.BirthdayDateTimePicker.Value = new System.DateTime(2021, 3, 22, 13, 44, 37, 0);
            this.BirthdayDateTimePicker.ValueChanged += new System.EventHandler(this.BirthdayDateTimePicker_ValueChanged);
            // 
            // VkTextBox
            // 
            this.VkTextBox.Location = new System.Drawing.Point(64, 120);
            this.VkTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VkTextBox.Name = "VkTextBox";
            this.VkTextBox.Size = new System.Drawing.Size(306, 20);
            this.VkTextBox.TabIndex = 26;
            this.VkTextBox.TextChanged += new System.EventHandler(this.VkTextBox_TextChanged);
            this.VkTextBox.Enter += new System.EventHandler(this.VkTextBox_Enter);
            this.VkTextBox.Leave += new System.EventHandler(this.VkTextBox_Leave);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(64, 98);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(306, 20);
            this.EmailTextBox.TabIndex = 25;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            this.EmailTextBox.Enter += new System.EventHandler(this.EmailTextBox_Enter);
            this.EmailTextBox.Leave += new System.EventHandler(this.EmailTextBox_Leave);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(64, 75);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(306, 20);
            this.PhoneTextBox.TabIndex = 24;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            this.PhoneTextBox.Enter += new System.EventHandler(this.PhoneTextBox_Enter);
            this.PhoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneTextBox_KeyPress);
            this.PhoneTextBox.Leave += new System.EventHandler(this.PhoneTextBox_Leave);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(64, 29);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(306, 20);
            this.NameTextBox.TabIndex = 23;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            this.NameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(64, 6);
            this.SurnameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(306, 20);
            this.SurnameTextBox.TabIndex = 22;
            this.SurnameTextBox.TextChanged += new System.EventHandler(this.SurnameTextBox_TextChanged);
            this.SurnameTextBox.Enter += new System.EventHandler(this.SurnameTextBox_Enter);
            this.SurnameTextBox.Leave += new System.EventHandler(this.SurnameTextBox_Leave);
            // 
            // VkLabel
            // 
            this.VkLabel.AutoSize = true;
            this.VkLabel.Location = new System.Drawing.Point(18, 123);
            this.VkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VkLabel.Name = "VkLabel";
            this.VkLabel.Size = new System.Drawing.Size(45, 13);
            this.VkLabel.TabIndex = 21;
            this.VkLabel.Text = "vk.com:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(22, 100);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(38, 13);
            this.EmailLabel.TabIndex = 20;
            this.EmailLabel.Text = "E-mail:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(20, 77);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.PhoneLabel.TabIndex = 19;
            this.PhoneLabel.Text = "Phone:";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.AutoSize = true;
            this.BirthdayLabel.Location = new System.Drawing.Point(12, 52);
            this.BirthdayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(48, 13);
            this.BirthdayLabel.TabIndex = 18;
            this.BirthdayLabel.Text = "Birthday:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(23, 32);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 17;
            this.NameLabel.Text = "Name:";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(2, 9);
            this.SurnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(58, 13);
            this.SurnameLabel.TabIndex = 16;
            this.SurnameLabel.Text = "Surname:";
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(225, 143);
            this.OkButton.Margin = new System.Windows.Forms.Padding(2);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(64, 23);
            this.OkButton.TabIndex = 28;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelButton.Location = new System.Drawing.Point(293, 143);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(70, 23);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 171);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditForm";
            this.Text = "Add/Edit contact";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.Shown += new System.EventHandler(this.EditForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker BirthdayDateTimePicker;
        private System.Windows.Forms.TextBox VkTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.Label VkLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Button OkButton;
        private new System.Windows.Forms.Button CancelButton;
    }
}