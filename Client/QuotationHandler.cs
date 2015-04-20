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
        private int msTimeout = 30;

        public QuotationHandler()
        {
            InitializeComponent();
        }

        public QuotationHandler(Client client)
        {
            InitializeComponent();

            this.client = client;
            quotationTimerLabel.Text = msTimeout.ToString();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            client.UnblockExchanges();
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            client.RemoveExchanges();
            this.Close();
        }

        private void quotationTimer_Tick(object sender, EventArgs e)
        {
            if (msTimeout == 0)
            {
                this.Close();
            }
            else
            {
                quotationTimerLabel.Text = msTimeout.ToString();
                msTimeout--;
            } 
        }
    }
}
