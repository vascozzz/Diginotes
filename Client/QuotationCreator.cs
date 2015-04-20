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
    public partial class QuotationCreator : MetroForm
    {
        private Client client;
        private float limit;
        private ExchangeType exchangeType;
        private int msTimeout = 10;

        public QuotationCreator()
        {
            InitializeComponent();
        }

        public QuotationCreator(Client client, float limit, ExchangeType exchangeType)
        {
            InitializeComponent();

            this.client = client;
            this.limit = limit;
            this.exchangeType = exchangeType;

            quotationLabel.Text = "Please set a new quotation " + (exchangeType == ExchangeType.BUY ? "bigger" : "smaller") + " than " + limit + ":";
            quotationTimerLabel.Text = msTimeout.ToString();
        }

        private void quotationBtn_Click(object sender, EventArgs e)
        {
            quotationError.Visible = false;
            float quotation = 0f;

            try
            {
                quotation = Convert.ToSingle(quotationText.Text);
            }
            catch (Exception err)
            {
                quotationError.Text = err.Message;
                quotationError.Visible = true;
                return;
            }

            if ((quotation <= 0) || (exchangeType == ExchangeType.BUY && quotation <= limit) || (exchangeType == ExchangeType.SELL && quotation >= limit))
            {
                quotationError.Text = "Please specify a valid number.";
                quotationError.Visible = true;
                return;
            }

            client.SetQuotation(quotation);
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
