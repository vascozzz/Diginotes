using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Client
{
    public partial class LoginForm : MetroForm
    {
        private Client client;


        public LoginForm()
        {
            InitializeComponent();
        }


        public LoginForm(Client client)
        {
            InitializeComponent();
            this.client = client;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            client.Disconnect();
        }


        private void ResetErrors()
        {
            loginError.Visible = false;
            registerError.Visible = false;
        }


        private void Login()
        {
            ResetErrors();

            string nickname = loginNicknameText.Text;
            string password = loginPasswordText.Text;

            if (nickname == "" || password == "")
            {
                loginError.Visible = true;
                return;
            }

            bool login = client.Login(nickname, password);

            if (login)
            {
                AppForm app = new AppForm(this, client);
                app.Show();
                this.Hide();
            }
            else
            {
                loginError.Visible = true;
            }
        }


        private void Register()
        {
            ResetErrors();

            string name = registerNameText.Text;
            string nickname = registerNicknameText.Text;
            string password = registerPasswordText.Text;

            if (name == "" || nickname == "" || password == "")
            {
                registerError.Text = "Please fill in all the fields.";
                registerError.Visible = true;
                return;
            }

            bool register = client.Register(name, nickname, password);

            if (register)
            {
                AppForm app = new AppForm(this, client);
                app.Show();
                this.Hide();
            }
            else
            {
                registerError.Text = "User already registered.";
                registerError.Visible = true;
            }
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }


        private void registerBtn_Click(object sender, EventArgs e)
        {
            Register();
        }


        private void loginField_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Login();
                e.Handled = true; // disables "ding" sound on enter/newline press
            } 
        }


        private void registerField_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Register();
                e.Handled = true;
            } 
        }
    }
}