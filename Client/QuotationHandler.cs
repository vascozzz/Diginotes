using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Client
{
    public partial class QuotationHandler : MetroForm
    {
        private Client client;

        public QuotationHandler()
        {
            InitializeComponent();
        }

        public QuotationHandler(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            // do... ?
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // remove all pending others, tell server, update appform
            this.Close();
        }
    }
}
