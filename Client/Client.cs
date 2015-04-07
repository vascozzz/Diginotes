using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Client
{
    public class Client
    {
        public ClientData clientData;

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

        public Client()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.NewExchange += OnNewExchange;

            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.NewExchange += inter.TriggerNewExchange;
        }

        public void SetAppForm(AppForm appForm)
        {
            this.appForm = appForm;
        }

        public bool Login(string nickname, string password)
        {
            ClientData? data = remObj.Login(nickname, password);

            if (!data.HasValue)
            {
                return false;
            }
            else
            {
                clientData = data.Value;
                return true;
            }          
        }

        public void RequestExchange(ExchangeType exchangeType, int diginotes)
        {
            remObj.RequestExchange(exchangeType, diginotes);
        }

        public void Disconnect()
        {
            Debug.WriteLine("Client disconnected successfully.");
            remObj.NewExchange -= inter.TriggerNewExchange;
            inter.NewExchange -= OnNewExchange;
        }

        public void OnNewExchange()
        {
            Debug.WriteLine("Some client requested a new exchange.");

            // disable events on login screen
            if (appForm != null)
            {
                
            }
        }
        
    }
}