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
    public partial class MainForm : MetroForm
    {
        Client client;

        public MainForm()
        {
            InitializeComponent();
            // Theme = MetroFramework.MetroThemeStyle.Dark;
            // Style = MetroFramework.MetroColorStyle.Green;
        }

        public MainForm(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string nickname = metroTextBox1.Text;
            string password = metroTextBox2.Text;

            client.Login(nickname, password);
        }
    }
}