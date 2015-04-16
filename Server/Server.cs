using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Collections.Generic;
using System.Data.SQLite;

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
    private DatabaseLayer db;
    private float quotation = 1.0f;


    /* Open database connection once server is initiated by the first client. */
    public RemObj()
    {
        Console.WriteLine("Server constructor called.");

        db = new DatabaseLayer();
    }


    /* On login, should return all client info (including number of diginotes owned and previous exchanges). */
    public ClientData Login(string nickname, string password)
    {
        Console.WriteLine("A client called Login().");

        ClientData clientData = db.GetLogin(nickname, password);

        if (clientData != null)
        {
            clientData.diginotes = db.GetDiginotes(clientData.user_id);
            clientData.diginotesAvlb = clientData.diginotes;
            clientData.exchanges = db.GetExchanges(clientData.user_id);
            clientData.UpdateAvailabilities();

            return clientData;
        }
        else
        {
            return null;
        }         
    }


    /* On register, should return all client info so user can be logged-in automatically. */
    public bool Register(String name, String nickname, String password)
    {
        Console.WriteLine("A client called Register().");

        return db.Register(name, nickname, password); 
    }


    /* Registers a new exchange (either buying or selling diginotes) requested by a client. Returns registration id. */
    public UpdateData RequestExchange(int user_id, ExchangeType exchangeType, int diginotes)
    {
        Console.WriteLine("A client called RequestExchange().");

        ExchangeData exchange = db.RegisterExchange(user_id, exchangeType, diginotes);
        FindMatch(ref exchange);

        ClientData clientData = db.GetClientData(exchange.user_id);
        clientData.diginotes = db.GetDiginotes(clientData.user_id);
        clientData.diginotesAvlb = clientData.diginotes;

        List<ExchangeData> exchanges = db.GetExchanges(clientData.user_id);
        clientData.UpdateAvailabilities(exchanges);

        Console.WriteLine("User " + exchange.user_id + " now has " + clientData.balance + " balance and " + clientData.balanceAvlb + " balanceAvlb");

        UpdateData update = new UpdateData(clientData, exchange);
        return update;
    }


    /* Attempts to find a match between two exchanges. */
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

            if (exchange.type == ExchangeType.BUY)
                db.RegisterTransfer(exchange, match, diginotesTraded, quotation);
            else
                db.RegisterTransfer(match, exchange, diginotesTraded, quotation);

            match.diginotes_fulfilled += diginotesTraded;
            exchange.diginotes_fulfilled += diginotesTraded;

            Console.WriteLine("Client " + exchange.user_id + " issued a request. Matched with client " + match.user_id);
            // Console.Write("Found Match: id=" + match.exchange_id + " fortrade=" + diginotesAvailable + " traded=" + diginotesTraded);

            UpdateEvent(match);
        }
    }

    /* */
    private void UpdateEvent(ExchangeData exchange)
    {
        ClientData clientData = db.GetClientData(exchange.user_id);
        clientData.diginotes = db.GetDiginotes(clientData.user_id);
        clientData.diginotesAvlb = clientData.diginotes;

        List<ExchangeData> exchanges = db.GetExchanges(clientData.user_id);
        clientData.UpdateAvailabilities(exchanges);

        UpdateData update = new UpdateData(clientData, exchange);
        NewExchange(update);
    }
}