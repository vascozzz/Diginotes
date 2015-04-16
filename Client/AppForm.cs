using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
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
            client.SetAppForm(this);

            nameText.Text += client.data.name;
            quotationText.Text = client.data.quotation.ToString() + "€ each";
            quotationUpdateText.Text = "Last updated at " + DateTime.Now.ToShortTimeString();

            diginotesText.Text = client.data.diginotes.ToString();
            diginotesAvailableText.Text = client.data.diginotesAvlb.ToString();

            balanceText.Text = client.data.balance.ToString() + "€";
            balanceAvailableText.Text = client.data.balanceAvlb.ToString() + "€";

            historyGrid.ColumnCount = 5;
            historyGrid.Columns[0].Name = "id";
            historyGrid.Columns[1].Name = "type";
            historyGrid.Columns[2].Name = "diginotes";
            historyGrid.Columns[3].Name = "fulfilled";
            historyGrid.Columns[4].Name = "created";
            historyCount = 0;

            InitHistory();
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

        private void InitHistory()
        {
            foreach (ExchangeData exchange in client.data.exchanges)
            {
                bool fulfilled = exchange.diginotes == exchange.diginotes_fulfilled;

                if (!fulfilled)
                {
                    if (exchange.type == ExchangeType.BUY)
                    {
                        client.data.balanceAvlb -= (exchange.diginotes * client.data.quotation) - (exchange.diginotes_fulfilled);
                    }
                    else if (exchange.type == ExchangeType.SELL)
                    {
                        client.data.diginotesAvlb -= exchange.diginotes - exchange.diginotes_fulfilled;
                    }
                }
                
                historyGrid.Rows.Add();
                historyGrid.Rows[historyCount].Cells[0].Value = exchange.exchange_id;
                historyGrid.Rows[historyCount].Cells[1].Value = exchange.type.ToString();
                historyGrid.Rows[historyCount].Cells[2].Value = exchange.diginotes;
                historyGrid.Rows[historyCount].Cells[3].Value = fulfilled ? "yes" : "no";
                historyGrid.Rows[historyCount].Cells[4].Value = exchange.created;
                historyCount++;
            }

            balanceAvailableText.Text = client.data.balanceAvlb.ToString() + "€";
            diginotesAvailableText.Text = client.data.diginotesAvlb.ToString();
        }

        private void AddToHistory(ExchangeType exchangeType, int diginotes)
        {
            historyGrid.Rows.Add();
            historyGrid.Rows[historyCount].Cells[0].Value = historyCount;
            historyGrid.Rows[historyCount].Cells[1].Value = exchangeType;
            historyGrid.Rows[historyCount].Cells[2].Value = diginotes;
            historyGrid.Rows[historyCount].Cells[3].Value = "no";
            historyGrid.Rows[historyCount].Cells[4].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
                balanceNeeded = client.data.quotation * buyAmount;
            }
            catch (Exception err)
            {
                buyError.Text = err.Message;
                buyError.Visible = true;
                return;
            }

            if (buyAmount <= 0 || balanceNeeded > client.data.balanceAvlb)
            {
                buyError.Text = "Please specify a valid number.";
                buyError.Visible = true;
                return;
            }

            client.data.balanceAvlb -= balanceNeeded;
            balanceAvailableText.Text = client.data.balanceAvlb.ToString() + "€";

            AddToHistory(ExchangeType.BUY, buyAmount);
            client.RequestExchange(ExchangeType.BUY, buyAmount);
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

            if (sellAmount <= 0 || sellAmount > client.data.diginotesAvlb)
            {
                sellError.Text = "Please specify a valid number.";
                sellError.Visible = true;
                return;
            }

            client.data.diginotesAvlb -= sellAmount;
            diginotesAvailableText.Text = client.data.diginotesAvlb.ToString();

            AddToHistory(ExchangeType.SELL, sellAmount);
            client.RequestExchange(ExchangeType.SELL, sellAmount);
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

        public void OnNewExchange()
        {
            if (InvokeRequired)
                BeginInvoke((MethodInvoker)delegate { OnNewExchange(); });
            else
            {
                MetroMessageBox.Show(this, "Yeah, m8? U wanna 1v1?", "New exchange took place", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            }

            // nameText.Text = "Some client initiated a new exchange";
            //MetroTaskWindow.ShowTaskWindow(this, "SubControl in TaskWindow", new UserControl(), 10);
            //MetroMessageBox.Show(this, "Yeah, m8? U wanna 1v1?", "New exchange took place", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

            // run through client history, if ids match, update history row at index
            // should also remember to check if user ids match before trying to do anything
        }
    }
}
