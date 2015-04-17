using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Client
{
    /* Client. Entity responsible for handling all the client data and respective communication with the server. */
    public class Client
    {
        // container for client data
        public ClientData data;


        // private pointers
        private IRemObj remObj;
        private Intermediate inter;
        private AppForm appForm;


        [STAThread]
        static void Main()
        {
            Client client = new Client();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(client));
        }


        /* When starting, a client should automatically connect to the server. */
        public Client()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.NewExchange += OnNewExchange;

            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.NewExchange += inter.TriggerNewExchange;
        }


        /* Login, server returns null when user is not found. */
        public bool Login(string nickname, string password)
        {
            data = remObj.Login(nickname, password);
            return (data != null);
        }


        /* When disconnecting, clients should unsubscribe from server events. */
        public void Disconnect()
        {
            if (data != null)
            {
                remObj.Logout(data.name);
            }

            remObj.NewExchange -= inter.TriggerNewExchange;
            inter.NewExchange -= OnNewExchange;
        }


        /* Sets a pointer to the form where all info is displayed so that it can be updated on events' callbacks. */
        public void SetAppForm(AppForm appForm)
        {
            this.appForm = appForm;
        }


        /* Updates everything related to a client's balance and diginotes. */
        public void UpdateEconomy(ClientData clientData)
        {
            data.balance = clientData.balance;
            data.balanceAvlb = clientData.balanceAvlb;

            data.diginotes = clientData.diginotes;
            data.diginotesAvlb = clientData.diginotesAvlb;
        }


        /* Requests the server to register a new exchange (either buying or selling diginotes). */
        public void RequestExchange(ExchangeType exchangeType, int diginotes)
        {
            // Request
            UpdateData update = remObj.RequestExchange(data.user_id, exchangeType, diginotes);

            data.exchanges.Add(update.exchange);
            UpdateEconomy(update.clientData);

            // should create a new exchange and update form
            appForm.AddToHistory(update.exchange);
            appForm.UpdateEconomy();
        }


        /* Callback triggered when the server pairs up two exchanges. */
        public void OnNewExchange(UpdateData update)
        {
            Debug.WriteLine("Some client requested a new exchange.");
            int exchangeIndex = -1;

            if (appForm != null && update.clientData.user_id == data.user_id) // disables events on login screen
            {
                for (int i = 0; i < data.exchanges.Count; i++) { 
                    if (data.exchanges[i].exchange_id == update.exchange.exchange_id)
                    {
                        data.exchanges[i].diginotes_fulfilled = update.exchange.diginotes_fulfilled;
                        exchangeIndex = i;
                        break;
                    }
                }

                UpdateEconomy(update.clientData);
                appForm.OnNewExchange(exchangeIndex);
            }
        }  
    }
}