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

        /* When starting, a client should automatically onnect to the server. */
        public Client()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.NewExchange += OnNewExchange;

            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.NewExchange += inter.TriggerNewExchange;
        }

        /* Sets a pointer to the form where all info is displayed so that it can be updated on events' callbacks. */
        public void SetAppForm(AppForm appForm)
        {
            this.appForm = appForm;
        }

        /* Login, server returns null when user is not found. */
        public bool Login(string nickname, string password)
        {
            ClientData? loginData = remObj.Login(nickname, password);

            if (!loginData.HasValue)
            {
                return false;
            }
            else
            {
                data = loginData.Value;
                return true;
            }          
        }

        /* Requests the server to register a new exchange (either buying or selling diginotes). */
        public void RequestExchange(ExchangeType exchangeType, int diginotes)
        {
            ExchangeData exchangeData = remObj.RequestExchange(data.user_id, exchangeType, diginotes);

            // should create a new exchange and update form
            if (appForm != null) 
            {

            }
        }

        /* When disconnecting, clients should unsubscribe from server events. */
        public void Disconnect()
        {
            Debug.WriteLine("Client disconnected successfully.");
            remObj.NewExchange -= inter.TriggerNewExchange;
            inter.NewExchange -= OnNewExchange;
        }

        /* Callback triggered when the server pairs up two exchanges. */
        public void OnNewExchange()
        {
            Debug.WriteLine("Some client requested a new exchange.");

            // should update user's exchanges if needed 
            if (appForm != null) // disables events on login screen
            {
                // appForm.OnNewExchange();
            }
        }
        
    }
}