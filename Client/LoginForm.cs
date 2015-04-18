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


        private void metroButton1_Click(object sender, EventArgs e)
        {
            string nickname = usernameText.Text;
            string password = passwordText.Text;

            bool login = client.Login(nickname, password);

            if (login)
            {
                AppForm app = new AppForm(this, client);
                app.Show();
                this.Hide();
            }
            else
            {
                passwordError.Visible = true;
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
        }

        public void Register(string name, string nickname, string password)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { Register(name, nickname, password); });
                return;
            }

            // call server
            /////////////////////////////
        }
    }
}