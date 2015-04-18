﻿namespace Client
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
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.usernameText = new MetroFramework.Controls.MetroTextBox();
            this.passwordLabel = new MetroFramework.Controls.MetroLabel();
            this.passwordText = new MetroFramework.Controls.MetroTextBox();
            this.loginBtn = new MetroFramework.Controls.MetroButton();
            this.passwordError = new MetroFramework.Controls.MetroLabel();
            this.registerBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(35, 86);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 19);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // usernameText
            // 
            this.usernameText.Lines = new string[0];
            this.usernameText.Location = new System.Drawing.Point(125, 86);
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
            this.passwordLabel.Location = new System.Drawing.Point(39, 128);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(66, 19);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // passwordText
            // 
            this.passwordText.Lines = new string[0];
            this.passwordText.Location = new System.Drawing.Point(125, 128);
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
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(125, 169);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(127, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginBtn.UseSelectable = true;
            this.loginBtn.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // passwordError
            // 
            this.passwordError.AutoSize = true;
            this.passwordError.ForeColor = System.Drawing.Color.Maroon;
            this.passwordError.Location = new System.Drawing.Point(258, 128);
            this.passwordError.Name = "passwordError";
            this.passwordError.Size = new System.Drawing.Size(191, 19);
            this.passwordError.Style = MetroFramework.MetroColorStyle.Magenta;
            this.passwordError.TabIndex = 5;
            this.passwordError.Text = "Wrong username or password!";
            this.passwordError.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordError.UseCustomForeColor = true;
            this.passwordError.Visible = false;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(222, 234);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(127, 23);
            this.registerBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Register Now";
            this.registerBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerBtn.UseSelectable = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(121, 234);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "No account?";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(200, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(464, 280);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.passwordError);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.usernameLabel);
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Diginotes - Welcome";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel usernameLabel;
        private MetroFramework.Controls.MetroTextBox usernameText;
        private MetroFramework.Controls.MetroLabel passwordLabel;
        private MetroFramework.Controls.MetroTextBox passwordText;
        private MetroFramework.Controls.MetroButton loginBtn;
        private MetroFramework.Controls.MetroLabel passwordError;
        private MetroFramework.Controls.MetroButton registerBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

