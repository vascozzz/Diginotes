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

        /* temporary placeholders */
        private int diginotesAvailable;
        private float balanceAvailable;

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

            /* temporary placeholders */
            diginotesAvailable = client.clientData.diginotes;
            balanceAvailable = client.clientData.balance;

            diginotesText.Text = diginotesAvailable.ToString();
            diginotesAvailableText.Text = diginotesAvailable.ToString();

            balanceText.Text = balanceAvailable.ToString() + "€";
            balanceAvailableText.Text = balanceAvailable.ToString() + "€";

            metroGrid1.ColumnCount = 4;
            metroGrid1.Columns[0].Name = "id";
            metroGrid1.Columns[1].Name = "type";
            metroGrid1.Columns[2].Name = "fulfilled";
            metroGrid1.Columns[3].Name = "date";

            for (int i = 0; i < 100; i++)
            {
                metroGrid1.Rows.Add();

                metroGrid1.Rows[i].Cells[0].Value = i;
                metroGrid1.Rows[i].Cells[1].Value = "BUY";
                metroGrid1.Rows[i].Cells[2].Value = "yes";
                metroGrid1.Rows[i].Cells[3].Value = "02/04/2015";
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            parent.Close();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            int buyAmount = 0;
            float balanceNeeded = 0f;

            buyError.Visible = true;

            try
            {
                buyAmount = Convert.ToInt32(buyText);
            }
            catch (Exception err)
            {
                buyError.Visible = true;
                return;
            }

            
        }
    }
}
