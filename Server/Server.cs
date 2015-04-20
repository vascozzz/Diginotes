using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Timers;

class Server
{
    static void Main(string[] args)
    {
        RemotingConfiguration.Configure("Server.exe.config", false);
        Console.WriteLine("Press return to exit");
        Console.ReadLine();
    }
}

public class RemObj : MarshalByRefObject, IRemObj
{
    // public events
    public event ExchangeHandler NewExchange;
    public event QuotationHandler NewQuotation;


    // private vars
    private DatabaseLayer db;               // db layer
    private float quotation = 1.0f;         // initial server quotation
    private System.Timers.Timer timer;      // activated after quotation changes


    /* Open database connection once server is initiated by the first client. */
    public RemObj()
    {
        Console.WriteLine("\nServer constructor called.");

        db = new DatabaseLayer();
        db.UnblockAllExchanges();

        timer = new System.Timers.Timer();
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Interval = 20000;
        timer.Enabled = false;
    }


    /* On register, should return all client info so user can be logged-in automatically. */
    public ClientData Register(String name, String nickname, String password)
    {
        Console.WriteLine("\nA client called Register().");

        bool register = db.Register(name, nickname, password);

        if (register)
        {
            return Login(nickname, password);
        }
        else
        {
            return null;
        }
    }


    /* On login, should return all client info (including number of diginotes owned and previous exchanges). */
    public ClientData Login(string nickname, string password)
    {
        Console.WriteLine("\nA client called Login().");

        ClientData clientData = db.GetLogin(nickname, password);

        if (clientData != null)
        {
            clientData.diginotes = db.GetDiginotes(clientData.user_id);
            clientData.diginotesAvlb = clientData.diginotes;
            clientData.quotation = quotation;
            clientData.exchanges = db.GetExchanges(clientData.user_id);

            clientData.UpdateAvailabilities();

            return clientData;
        }
        else
        {
            return null;
        }         
    }


    /* Used simply to know the names of users currently online. */
    public void Logout(string nickname)
    {
        Console.WriteLine("\nUser " + nickname + " disconnected successfully.");
    }


    /* Updates quotation set by a given user. */
    public void SetQuotation(int user_id, float quotation)
    {
        Console.WriteLine("\nA new quotation has been set by client " + user_id + ". Current value: " + quotation);

        // block all unfulfilled exchanges that belong to other clients
        if (quotation > this.quotation)
        {
            db.BlockAllExchanges(user_id, ExchangeType.BUY);
        }
        else
        {
            db.BlockAllExchanges(user_id, ExchangeType.SELL);
        }

        // set new quotation
        this.quotation = quotation;

        // activate timer, so it unblock all exchanges at a later time
        timer.Start();

        NewQuotation(user_id, quotation);
    }


    /* Unblocks all unfulfilled exchanges of a given client. */
    public void UnblockClientExchanges(int user_id)
    {
        Console.WriteLine("\nClient " + user_id + " accepted the new quotation (all exchanges unblocked).");

        db.UnblockClientExchanges(user_id);
    }


    /* Removes all unfulfilled exchanges of a given client. */
    public ClientData RemoveClientExchanges(int user_id)
    {
        Console.WriteLine("\nClient " + user_id + " rejected the new quotation (all exchanges retired).");

        db.RemoveClientExchanges(user_id);

        ClientData clientData = db.GetClientData(user_id);
        clientData.diginotes = db.GetDiginotes(user_id);
        clientData.quotation = quotation;
        clientData.diginotesAvlb = clientData.diginotes;
        clientData.exchanges = db.GetExchanges(clientData.user_id);

        return clientData;
    }


    /* Registers a new exchange (either buying or selling diginotes) requested by a client. 
     * After registering, the server runs a search for possible matches and makes a transaction for all that compatible.
     * Returns the new exchange (already matched, if possible) and the updated client info.
     */
    public UpdateData RequestExchange(int user_id, ExchangeType exchangeType, int diginotes)
    {
        Console.WriteLine("\nClient " + user_id + " called RequestExchange().");

        ExchangeData exchange = db.RegisterExchange(user_id, exchangeType, diginotes);
        FindMatch(ref exchange);

        UpdateData update = CreateUpdateData(exchange);
        return update;
    }


    /* Attempts to find matches for a given exchange. May find multiple matches and create transactions with all. */
    private void FindMatch(ref ExchangeData exchange)
    {
        List<ExchangeData> matches = db.GetMatches(exchange);
        int diginotesNeeded = exchange.diginotes - exchange.diginotes_fulfilled;

        foreach (ExchangeData match in matches)
        {
            if (diginotesNeeded <= 0)
            {
                break;
            }

            int diginotesAvailable = match.diginotes - match.diginotes_fulfilled;
            int diginotesTraded = Math.Min(diginotesNeeded, diginotesAvailable);

            diginotesNeeded -= diginotesTraded;

            if (exchange.type == ExchangeType.BUY) {
                db.RegisterTransfer(exchange, match, diginotesTraded, quotation);
            }
            else 
            {
                db.RegisterTransfer(match, exchange, diginotesTraded, quotation);
            }
                
            match.diginotes_fulfilled += diginotesTraded;
            exchange.diginotes_fulfilled += diginotesTraded;

            Console.Write("\nFound match with client " + match.user_id + ", id " + match.exchange_id + ". Available: " + diginotesAvailable + " | Traded: " + diginotesTraded + "\n");
            
            UpdateData update = CreateUpdateData(match);
            NewExchange(update);
        }
    }

    /* Creates an UpdateData object (with updated client data) with a given exchange. */
    private UpdateData CreateUpdateData(ExchangeData exchange)
    {
        // get associated client data
        ClientData clientData = db.GetClientData(exchange.user_id);
        clientData.diginotes = db.GetDiginotes(clientData.user_id);
        clientData.quotation = quotation;
        clientData.diginotesAvlb = clientData.diginotes;

        // update balance
        List<ExchangeData> exchanges = db.GetExchanges(clientData.user_id);
        clientData.UpdateAvailabilities(exchanges);

        // return exchange bundled with updated client data
        UpdateData update = new UpdateData(clientData, exchange);
        return update;
    }

    /* Updates the amount of digicoins for a given exchange. */
    public ClientData EditExchange(ExchangeData exchange)
    {
        Console.WriteLine("\nClient " + exchange.user_id+ " called EditExchange.");

        db.UpdateExchange(exchange.exchange_id, exchange.diginotes);

        ClientData clientData = db.GetClientData(exchange.user_id);
        clientData.diginotes = db.GetDiginotes(clientData.user_id);
        clientData.quotation = quotation;
        clientData.diginotesAvlb = clientData.diginotes;

        // update balance
        List<ExchangeData> exchanges = db.GetExchanges(clientData.user_id);
        clientData.UpdateAvailabilities(exchanges);

        return clientData;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("\nTimer has activated, all exchanges have been unblocked.");

        db.UnblockAllExchanges();
        timer.Stop();
    }
}