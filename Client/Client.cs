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
            Debug.WriteLine("Client constructor called");

            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.InitTrigger += OnFireEvent;

            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.InitTrigger += inter.FireEvent;
        }

        public bool Login(string nickname, string password) 
        {
            bool loginResult = remObj.Login(nickname, password);

            if (!loginResult)
            {
                Debug.WriteLine("Login nao deu");
            }
            else
            {
                Debug.WriteLine("Yaaay");
            }

            return loginResult;
        }

        public void Disconnect()
        {
            remObj.InitTrigger -= inter.FireEvent;
            inter.InitTrigger -= OnFireEvent;
        }

        public void OnFireEvent()
        {
            Debug.WriteLine("Event Fired");
        }

        [STAThread]
        static void Main()
        {
            Client client = new Client();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(client));
        }
    }
}

class GetRemote
{
    private static IDictionary wellKnownTypes;

    public static object New(Type type)
    {
        if (wellKnownTypes == null)
            InitTypeCache();
        WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)wellKnownTypes[type];
        if (entry == null)
            throw new RemotingException("Type not found!");
        return Activator.GetObject(type, entry.ObjectUrl);
    }

    public static void InitTypeCache()
    {
        Hashtable types = new Hashtable();
        foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
        {
            if (entry.ObjectType == null)
                throw new RemotingException("A configured type could not be found!");
            types.Add(entry.ObjectType, entry);
        }
        wellKnownTypes = types;
    }
}