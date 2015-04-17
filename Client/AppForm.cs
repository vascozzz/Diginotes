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
        private bool canEdit;


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

            // create columns for history grid
            historyGrid.ReadOnly = false;
            historyCount = 0;

            historyGrid.ColumnCount = 6;
            historyGrid.Columns[0].Name = "id";
            historyGrid.Columns[1].Name = "type";
            historyGrid.Columns[2].Name = "diginotes";
            historyGrid.Columns[3].Name = "fulfilled";
            historyGrid.Columns[4].Name = "done";
            historyGrid.Columns[5].Name = "created"; 

            // set individual column sizes
            historyGrid.Columns[0].Width = 30;
            historyGrid.Columns[1].Width = 45;
            historyGrid.Columns[2].Width = 55;
            historyGrid.Columns[3].Width = 55;
            historyGrid.Columns[4].Width = 55;
            historyGrid.Columns[5].Width = 120;

            // center colum headers
            historyGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // center all columns, make them not editable
            for (int i = 0; i < historyGrid.ColumnCount; i++)
            {
                historyGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                historyGrid.Columns[i].ReadOnly = true;
            }

            // diginotes column should be the only one 
            historyGrid.Columns[2].ReadOnly = false;

            UpdateEconomy();
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
                AddToHistory(exchange);
            }
        }


        private void SetFulfilledHistory(int historyId, bool fulfilled)
        {
            historyGrid.Rows[historyId].Cells[2].Value = fulfilled ? "yes" : "no";
        }


        public void AddToHistory(ExchangeData exchange)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { AddToHistory(exchange); });
                return;
            }

            canEdit = false;
            historyGrid.Rows.Add();
            historyGrid.Rows[historyCount].Cells[0].Value = exchange.exchange_id;
            historyGrid.Rows[historyCount].Cells[1].Value = exchange.type.ToString();
            historyGrid.Rows[historyCount].Cells[2].Value = exchange.diginotes;
            historyGrid.Rows[historyCount].Cells[3].Value = exchange.diginotes_fulfilled;
            historyGrid.Rows[historyCount].Cells[4].Value = exchange.diginotes == exchange.diginotes_fulfilled ? "yes" : "no";
            historyGrid.Rows[historyCount].Cells[5].Value = exchange.created;
            historyCount++;
            canEdit = true;
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


        public void OnNewExchange(int index)
        {
            if(InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { OnNewExchange(index); });
                return;
            }

            ExchangeData data = client.data.exchanges[index];

            canEdit = false;
            historyGrid.Rows[index].Cells[3].Value = data.diginotes_fulfilled;
            historyGrid.Rows[index].Cells[4].Value = data.diginotes == data.diginotes_fulfilled ? "yes" : "no";
            canEdit = true;

            UpdateEconomy();
            
            //nameText.Text = "Some client initiated a new exchange";
            //MetroTaskWindow.ShowTaskWindow(this, "SubControl in TaskWindow", new UserControl(), 10);
            //MetroMessageBox.Show(this, "Yeah, m8? U wanna 1v1?", "New exchange took place", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }


        public void UpdateEconomy()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { UpdateEconomy(); });
                return;
            }

            diginotesText.Text = client.data.diginotes.ToString();
            diginotesAvailableText.Text = client.data.diginotesAvlb.ToString();

            balanceText.Text = client.data.balance.ToString() + "€";
            balanceAvailableText.Text = client.data.balanceAvlb.ToString() + "€";
        }


        public void UpdateQuotation()
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { UpdateQuotation(); });
                return;
            }

            quotationText.Text = client.data.quotation.ToString() + "€ each";
            quotationUpdateText.Text = "Last updated at " + DateTime.Now.ToShortTimeString();
        }


        private void historyGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // the event is also called on programmatic changes, so we need a boolean to disable the event on such cases
            if (!canEdit)
            {
                return;
            }

            int id = Convert.ToInt32(historyGrid.Rows[e.RowIndex].Cells["id"].Value);
            int updatedTo = Convert.ToInt32(historyGrid.Rows[e.RowIndex].Cells["diginotes"].Value);
            nameText.Text = "Updated exchange " + id + " to " + updatedTo + " diginotes.";
        }
    }
}
