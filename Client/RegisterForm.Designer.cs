namespace Client
{
    partial class RegisterForm
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
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.usernameText = new MetroFramework.Controls.MetroTextBox();
            this.passwordLabel = new MetroFramework.Controls.MetroLabel();
            this.passwordText = new MetroFramework.Controls.MetroTextBox();
            this.registerBtn = new MetroFramework.Controls.MetroButton();
            this.nameText = new MetroFramework.Controls.MetroTextBox();
            this.nameLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(35, 117);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 19);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // usernameText
            // 
            this.usernameText.Lines = new string[0];
            this.usernameText.Location = new System.Drawing.Point(125, 117);
            this.usernameText.MaxLength = 32767;
            this.usernameText.Name = "usernameText";
            this.usernameText.PasswordChar = '\0';
            this.usernameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameText.SelectedText = "";
            this.usernameText.Size = new System.Drawing.Size(127, 23);
            this.usernameText.TabIndex = 1;
            this.usernameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usernameText.UseSelectable = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(39, 159);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(66, 19);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // passwordText
            // 
            this.passwordText.Lines = new string[0];
            this.passwordText.Location = new System.Drawing.Point(125, 159);
            this.passwordText.MaxLength = 32767;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordText.SelectedText = "";
            this.passwordText.Size = new System.Drawing.Size(127, 23);
            this.passwordText.TabIndex = 3;
            this.passwordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordText.UseSelectable = true;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(125, 202);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(127, 23);
            this.registerBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Register Now";
            this.registerBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerBtn.UseSelectable = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // nameText
            // 
            this.nameText.Lines = new string[0];
            this.nameText.Location = new System.Drawing.Point(125, 74);
            this.nameText.MaxLength = 32767;
            this.nameText.Name = "nameText";
            this.nameText.PasswordChar = '\0';
            this.nameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameText.SelectedText = "";
            this.nameText.Size = new System.Drawing.Size(127, 23);
            this.nameText.TabIndex = 7;
            this.nameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nameText.UseSelectable = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(57, 74);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(48, 19);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(200, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(464, 248);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.usernameLabel);
            this.Name = "RegisterForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Diginotes - Welcome, new user";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel usernameLabel;
        private MetroFramework.Controls.MetroTextBox usernameText;
        private MetroFramework.Controls.MetroLabel passwordLabel;
        private MetroFramework.Controls.MetroTextBox passwordText;
        private MetroFramework.Controls.MetroButton registerBtn;
        private MetroFramework.Controls.MetroTextBox nameText;
        private MetroFramework.Controls.MetroLabel nameLabel;
    }
}

