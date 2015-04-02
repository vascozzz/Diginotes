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
        Client client;

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(Client client)
        {
            InitializeComponent();
            this.client = client;

            // for testing purposes
            //AppForm app = new AppForm(this);
            //app.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            client.Disconnect();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string nickname = metroTextBox1.Text;
            string password = metroTextBox2.Text;

            bool login = client.Login(nickname, password);

            if (login)
            {
                AppForm app = new AppForm(this);
                app.Show();
                this.Hide();
            }
            else
            {
                metroLabel3.Visible = true;
            }
        }
    }
}