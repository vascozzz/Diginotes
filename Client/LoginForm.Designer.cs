namespace Client
{
    partial class LoginForm
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
            this.loginNicknameLabel = new MetroFramework.Controls.MetroLabel();
            this.loginNicknameText = new MetroFramework.Controls.MetroTextBox();
            this.loginPasswordLabel = new MetroFramework.Controls.MetroLabel();
            this.loginPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.loginBtn = new MetroFramework.Controls.MetroButton();
            this.loginError = new MetroFramework.Controls.MetroLabel();
            this.registerBtn = new MetroFramework.Controls.MetroButton();
            this.separator = new MetroFramework.Controls.MetroLabel();
            this.registerNameText = new MetroFramework.Controls.MetroTextBox();
            this.registerNameLabel = new MetroFramework.Controls.MetroLabel();
            this.registerNicknameText = new MetroFramework.Controls.MetroTextBox();
            this.registerNicknameLabel = new MetroFramework.Controls.MetroLabel();
            this.registerPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.registerPasswordLabel = new MetroFramework.Controls.MetroLabel();
            this.registerError = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // loginNicknameLabel
            // 
            this.loginNicknameLabel.AutoSize = true;
            this.loginNicknameLabel.Location = new System.Drawing.Point(26, 75);
            this.loginNicknameLabel.Name = "loginNicknameLabel";
            this.loginNicknameLabel.Size = new System.Drawing.Size(71, 19);
            this.loginNicknameLabel.TabIndex = 0;
            this.loginNicknameLabel.Text = "Username:";
            this.loginNicknameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // loginNicknameText
            // 
            this.loginNicknameText.Lines = new string[0];
            this.loginNicknameText.Location = new System.Drawing.Point(116, 75);
            this.loginNicknameText.MaxLength = 32767;
            this.loginNicknameText.Name = "loginNicknameText";
            this.loginNicknameText.PasswordChar = '\0';
            this.loginNicknameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.loginNicknameText.SelectedText = "";
            this.loginNicknameText.Size = new System.Drawing.Size(127, 23);
            this.loginNicknameText.TabIndex = 1;
            this.loginNicknameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginNicknameText.UseSelectable = true;
            this.loginNicknameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginField_KeyPress);
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Location = new System.Drawing.Point(30, 117);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(66, 19);
            this.loginPasswordLabel.TabIndex = 2;
            this.loginPasswordLabel.Text = "Password:";
            this.loginPasswordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // loginPasswordText
            // 
            this.loginPasswordText.Lines = new string[0];
            this.loginPasswordText.Location = new System.Drawing.Point(116, 117);
            this.loginPasswordText.MaxLength = 32767;
            this.loginPasswordText.Name = "loginPasswordText";
            this.loginPasswordText.PasswordChar = '*';
            this.loginPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.loginPasswordText.SelectedText = "";
            this.loginPasswordText.Size = new System.Drawing.Size(127, 23);
            this.loginPasswordText.TabIndex = 3;
            this.loginPasswordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginPasswordText.UseSelectable = true;
            this.loginPasswordText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginField_KeyPress);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(116, 160);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(127, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginBtn.UseSelectable = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // loginError
            // 
            this.loginError.AutoSize = true;
            this.loginError.ForeColor = System.Drawing.Color.Maroon;
            this.loginError.Location = new System.Drawing.Point(88, 186);
            this.loginError.Name = "loginError";
            this.loginError.Size = new System.Drawing.Size(191, 19);
            this.loginError.Style = MetroFramework.MetroColorStyle.Magenta;
            this.loginError.TabIndex = 5;
            this.loginError.Text = "Wrong username or password!";
            this.loginError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginError.UseCustomForeColor = true;
            this.loginError.Visible = false;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(433, 202);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(127, 23);
            this.registerBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Register Now";
            this.registerBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerBtn.UseSelectable = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.separator.Location = new System.Drawing.Point(297, 54);
            this.separator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(2, 193);
            this.separator.TabIndex = 8;
            this.separator.UseCustomBackColor = true;
            // 
            // registerNameText
            // 
            this.registerNameText.Lines = new string[0];
            this.registerNameText.Location = new System.Drawing.Point(433, 75);
            this.registerNameText.MaxLength = 32767;
            this.registerNameText.Name = "registerNameText";
            this.registerNameText.PasswordChar = '\0';
            this.registerNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.registerNameText.SelectedText = "";
            this.registerNameText.Size = new System.Drawing.Size(127, 23);
            this.registerNameText.TabIndex = 10;
            this.registerNameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerNameText.UseSelectable = true;
            this.registerNameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.registerField_KeyPress);
            // 
            // registerNameLabel
            // 
            this.registerNameLabel.AutoSize = true;
            this.registerNameLabel.Location = new System.Drawing.Point(366, 75);
            this.registerNameLabel.Name = "registerNameLabel";
            this.registerNameLabel.Size = new System.Drawing.Size(48, 19);
            this.registerNameLabel.TabIndex = 9;
            this.registerNameLabel.Text = "Name:";
            this.registerNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // registerNicknameText
            // 
            this.registerNicknameText.Lines = new string[0];
            this.registerNicknameText.Location = new System.Drawing.Point(433, 117);
            this.registerNicknameText.MaxLength = 32767;
            this.registerNicknameText.Name = "registerNicknameText";
            this.registerNicknameText.PasswordChar = '\0';
            this.registerNicknameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.registerNicknameText.SelectedText = "";
            this.registerNicknameText.Size = new System.Drawing.Size(127, 23);
            this.registerNicknameText.TabIndex = 12;
            this.registerNicknameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerNicknameText.UseSelectable = true;
            this.registerNicknameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.registerField_KeyPress);
            // 
            // registerNicknameLabel
            // 
            this.registerNicknameLabel.AutoSize = true;
            this.registerNicknameLabel.Location = new System.Drawing.Point(343, 117);
            this.registerNicknameLabel.Name = "registerNicknameLabel";
            this.registerNicknameLabel.Size = new System.Drawing.Size(71, 19);
            this.registerNicknameLabel.TabIndex = 11;
            this.registerNicknameLabel.Text = "Username:";
            this.registerNicknameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // registerPasswordText
            // 
            this.registerPasswordText.Lines = new string[0];
            this.registerPasswordText.Location = new System.Drawing.Point(433, 160);
            this.registerPasswordText.MaxLength = 32767;
            this.registerPasswordText.Name = "registerPasswordText";
            this.registerPasswordText.PasswordChar = '*';
            this.registerPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.registerPasswordText.SelectedText = "";
            this.registerPasswordText.Size = new System.Drawing.Size(127, 23);
            this.registerPasswordText.TabIndex = 14;
            this.registerPasswordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerPasswordText.UseSelectable = true;
            this.registerPasswordText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.registerField_KeyPress);
            // 
            // registerPasswordLabel
            // 
            this.registerPasswordLabel.AutoSize = true;
            this.registerPasswordLabel.Location = new System.Drawing.Point(343, 160);
            this.registerPasswordLabel.Name = "registerPasswordLabel";
            this.registerPasswordLabel.Size = new System.Drawing.Size(66, 19);
            this.registerPasswordLabel.TabIndex = 13;
            this.registerPasswordLabel.Text = "Password:";
            this.registerPasswordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // registerError
            // 
            this.registerError.AutoSize = true;
            this.registerError.ForeColor = System.Drawing.Color.Maroon;
            this.registerError.Location = new System.Drawing.Point(420, 228);
            this.registerError.Name = "registerError";
            this.registerError.Size = new System.Drawing.Size(154, 19);
            this.registerError.Style = MetroFramework.MetroColorStyle.Magenta;
            this.registerError.TabIndex = 15;
            this.registerError.Text = "Please fill in all the fields!";
            this.registerError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerError.UseCustomForeColor = true;
            this.registerError.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(200, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(593, 270);
            this.Controls.Add(this.registerError);
            this.Controls.Add(this.registerPasswordText);
            this.Controls.Add(this.registerPasswordLabel);
            this.Controls.Add(this.registerNicknameText);
            this.Controls.Add(this.registerNicknameLabel);
            this.Controls.Add(this.registerNameText);
            this.Controls.Add(this.registerNameLabel);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.loginError);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.loginPasswordText);
            this.Controls.Add(this.loginPasswordLabel);
            this.Controls.Add(this.loginNicknameText);
            this.Controls.Add(this.loginNicknameLabel);
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Diginotes - Welcome";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel loginNicknameLabel;
        private MetroFramework.Controls.MetroTextBox loginNicknameText;
        private MetroFramework.Controls.MetroLabel loginPasswordLabel;
        private MetroFramework.Controls.MetroTextBox loginPasswordText;
        private MetroFramework.Controls.MetroButton loginBtn;
        private MetroFramework.Controls.MetroLabel loginError;
        private MetroFramework.Controls.MetroButton registerBtn;
        private MetroFramework.Controls.MetroLabel separator;
        private MetroFramework.Controls.MetroTextBox registerNameText;
        private MetroFramework.Controls.MetroLabel registerNameLabel;
        private MetroFramework.Controls.MetroTextBox registerNicknameText;
        private MetroFramework.Controls.MetroLabel registerNicknameLabel;
        private MetroFramework.Controls.MetroTextBox registerPasswordText;
        private MetroFramework.Controls.MetroLabel registerPasswordLabel;
        private MetroFramework.Controls.MetroLabel registerError;
    }
}

