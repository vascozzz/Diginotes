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
    public partial class AppForm : MetroForm
    {
        private MetroForm parent;
        private Client client;
        private int historyCount;

        public AppForm()
        {
            InitializeComponent();
        }

        public AppForm(MetroForm parent, Client client)
        {
            InitializeComponent();

            this.parent = parent;
            this.client = client;

            nameText.Text += client.clientData.name;
            quotationText.Text = client.clientData.quotation.ToString() + "€ each";
            quotationUpdateText.Text = "Last updated at " + DateTime.Now.ToShortTimeString();

            diginotesText.Text = client.clientData.diginotes.ToString();
            diginotesAvailableText.Text = client.clientData.diginotesAvlb.ToString();

            balanceText.Text = client.clientData.balance.ToString() + "€";
            balanceAvailableText.Text = client.clientData.balanceAvlb.ToString() + "€";

            historyGrid.ColumnCount = 5;
            historyGrid.Columns[0].Name = "id";
            historyGrid.Columns[1].Name = "type";
            historyGrid.Columns[2].Name = "diginotes";
            historyGrid.Columns[3].Name = "fulfilled";
            historyGrid.Columns[4].Name = "created";
            historyCount = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Close();
        }

        private void ResetErrors()
        {
            buyError.Visible = false;
            sellError.Visible = false;
        }

        private void AddToHistory(ExchangeType exchangeType, int diginotes)
        {
            historyGrid.Rows.Add();
            historyGrid.Rows[historyCount].Cells[0].Value = historyCount;
            historyGrid.Rows[historyCount].Cells[1].Value = exchangeType;
            historyGrid.Rows[historyCount].Cells[2].Value = diginotes;
            historyGrid.Rows[historyCount].Cells[3].Value = "no";
            historyGrid.Rows[historyCount].Cells[4].Value = DateTime.Now.ToShortTimeString();
            historyCount++;
        }

        private void SetFulfilledHistory(int historyId, bool fulfilled)
        {
            historyGrid.Rows[historyId].Cells[2].Value = fulfilled ? "yes" : "no";
        }

        private void RequestBuyExchange()
        {
            int buyAmount = 0;
            float balanceNeeded = 0;

            ResetErrors();

            try
            {
                buyAmount = Convert.ToInt32(buyText.Text);
                balanceNeeded = client.clientData.quotation * buyAmount;
            }
            catch (Exception err)
            {
                buyError.Text = err.Message;
                buyError.Visible = true;
                return;
            }

            if (buyAmount <= 0 || balanceNeeded > client.clientData.balanceAvlb)
            {
                buyError.Text = "Please specify a valid number.";
                buyError.Visible = true;
                return;
            }

            client.clientData.balanceAvlb -= balanceNeeded;
            balanceAvailableText.Text = client.clientData.balanceAvlb.ToString() + "€";

            AddToHistory(ExchangeType.BUY, buyAmount);
        }

        private void RequestSellExchange()
        {
            int sellAmount = 0;

            ResetErrors();

            try
            {
                sellAmount = Convert.ToInt32(sellText.Text);
            }
            catch (Exception err)
            {
                sellError.Text = err.Message;
                sellError.Visible = true;
                return;
            }

            if (sellAmount <= 0 || sellAmount > client.clientData.diginotesAvlb)
            {
                sellError.Text = "Please specify a valid number.";
                sellError.Visible = true;
                return;
            }

            client.clientData.diginotesAvlb -= sellAmount;
            diginotesAvailableText.Text = client.clientData.diginotesAvlb.ToString();

            AddToHistory(ExchangeType.SELL, sellAmount);
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            RequestBuyExchange();
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            RequestSellExchange();
        }

        private void buyText_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                RequestBuyExchange();
                e.Handled = true; // disables "ding" sound on enter/newline press
            }
        }

        private void sellText_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                RequestSellExchange();
                e.Handled = true;
            }
        }
    }
}
