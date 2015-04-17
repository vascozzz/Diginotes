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

        // TODO should close after a set amount of seconds

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
        }
    }
}
