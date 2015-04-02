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
        private IRemObj remObj;
        private Intermediate inter;

        public Client()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.InitTrigger += OnFireEvent;

            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.InitTrigger += inter.FireEvent;
        }

        public bool Login(string nickname, string password) 
        {
            return remObj.Login(nickname, password);
        }

        public void Disconnect()
        {
            Debug.WriteLine("Disconnect called.");
            remObj.InitTrigger -= inter.FireEvent;
            inter.InitTrigger -= OnFireEvent;
        }

        public void OnFireEvent()
        {
            Debug.WriteLine("Event fired.");
        }

        [STAThread]
        static void Main()
        {
            Client client = new Client();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(client));
        }
    }
}