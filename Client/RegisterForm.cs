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
    public partial class RegisterForm : MetroForm
    {
        private LoginForm parent;


        public RegisterForm()
        {
            InitializeComponent();
        }


        public RegisterForm(LoginForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Close();
        }


        private void registerBtn_Click(object sender, EventArgs e)
        {
            string name = nameText.Text;
            string nickname = usernameText.Text;
            string password = passwordText.Text;

            parent.Register(name, nickname, password);

            this.Close();
        }
    }
}