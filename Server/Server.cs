using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Data.SQLite;
using System.Collections.Generic;

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
    private SQLiteConnection db;
    private float quotation = 1.0f;


    /* Open database connection once server is initiated by the first client. */
    public RemObj()
    {
        Console.WriteLine("Server constructor called.");

        db = new SQLiteConnection("Data Source=diginote.sqlite;Version=3;");
        db.Open();
    }


    /* On login, should return all client info (including number of diginotes owned and previous exchanges). */
    public ClientData? Login(string nickname, string password)
    {
        Console.WriteLine("A client called Login().");

        // find user
        string sql = "SELECT user_id, name, balance FROM USER where nickname = @nickname AND password = @password";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read())
        {
            int user_id = Convert.ToInt32((long) data["user_id"]);
            string name = (string) data["name"];
            float balance = Convert.ToSingle((double) data["balance"]);
            float quotation = 1;

            // find number of diginotes owned
            sql = "SELECT COUNT(*) AS diginotes FROM diginote WHERE owner_id = @owner_id";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@owner_id", user_id);
            data = command.ExecuteReader();
            data.Read();

            int diginotes = Convert.ToInt32((long) data["diginotes"]);
            
            // find all previous exchanges
            sql = "SELECT * FROM exchange where user_id = @user_id";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@user_id", user_id);
            data = command.ExecuteReader();

            List<ExchangeData> exchanges = new List<ExchangeData>();

            // add them to an array that can be passed to the client data struct
            while (data.Read())
            {
                int exchange_id = Convert.ToInt32((long) data["exchange_id"]);
                ExchangeType type = (string) data["type"] == "BUY" ? ExchangeType.BUY : ExchangeType.SELL;
                int exchange_diginotes = Convert.ToInt32((long) data["diginotes"]);
                int diginotes_fulfilled = Convert.ToInt32((long) data["diginotes_fulfilled"]);
                string created = (string) data["created"];

                ExchangeData exchange = new ExchangeData(exchange_id, user_id, type, exchange_diginotes, diginotes_fulfilled, created);
                exchanges.Add(exchange);
            }

            return new ClientData(user_id, name, balance, diginotes, quotation, exchanges);
        }
        else
        {
            return null;
        }         
    }

    private void GetClientInfo(ClientData data)
    {

    }


    /* On register, should return all client info so user can be logged-in automatically. */
    public bool Register(String name, String nickname, String password)
    {
        Console.WriteLine("A client called Register().");

        string sql = "INSERT INTO USER(name, nickname, password) VALUES(@name, @nickname, @password)";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();

        return true;
    }


    /* Registers a new exchange (either buying or selling diginotes) requested by a client. Returns registration id. */
    public ExchangeData RequestExchange(int user_id, ExchangeType exchangeType, int diginotes)
    {
        Console.WriteLine("A client called RequestExchange().");

        string created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int diginotes_fulfilled = 0;
        int exchange_id = -1;

        // insert new exchange
        string sql = "INSERT INTO exchange VALUES(null, @user_id, @type, @diginotes, @diginotes_fulfilled, @created)";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        command.Parameters.AddWithValue("@type", exchangeType.ToString());
        command.Parameters.AddWithValue("@diginotes", diginotes);
        command.Parameters.AddWithValue("@diginotes_fulfilled", diginotes_fulfilled);
        command.Parameters.AddWithValue("@created", created);
        command.ExecuteNonQuery();

        // sqlite has no method of getting new id when inserting data, so we need to grab it manually
        sql = "SELECT exchange_id FROM exchange WHERE user_id = @user_id ORDER BY exchange_id DESC LIMIT 1";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        SQLiteDataReader data = command.ExecuteReader();
        data.Read();
        exchange_id = Convert.ToInt32((long) data["exchange_id"]);

        // trigger event and return exchange data
        ExchangeData newExchange = new ExchangeData(exchange_id, user_id, exchangeType, diginotes, diginotes_fulfilled, created);

        FindMatch(ref newExchange);
        return newExchange;

        // TODO: refactor so that: find match, create and modify exchange, activate event (creator doesn't have exchange yet), return resulting exchange
    }


    /* Attempts to find a match between two exchanges. */
    private void FindMatch(ref ExchangeData exchange)
    {
        int diginotesNeeded = exchange.diginotes - exchange.diginotes_fulfilled;

        ExchangeType matchingType = exchange.type == ExchangeType.BUY ? ExchangeType.SELL : ExchangeType.BUY;

        // should later update so that owner =/= exchange.owner
        string sql = "SELECT * FROM exchange WHERE user_id != @userId AND type = @matchingType AND diginotes - diginotes_fulfilled > 0 ORDER BY created ASC";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@userId", exchange.user_id.ToString());
        command.Parameters.AddWithValue("@matchingType", matchingType.ToString());
        SQLiteDataReader data = command.ExecuteReader();

        while (data.Read() && diginotesNeeded > 0)
        {
            int exchange_id = Convert.ToInt32((long) data["exchange_id"]);
            int user_id = Convert.ToInt32((long) data["user_id"]);
            int exchange_diginotes = Convert.ToInt32((long) data["diginotes"]);
            int diginotes_fulfilled = Convert.ToInt32((long) data["diginotes_fulfilled"]);
            string created = (string)data["created"];
            int diginotes_fortrade = exchange_diginotes - diginotes_fulfilled;

            int diginotesTraded = Math.Min(diginotesNeeded, diginotes_fortrade);
            diginotesNeeded -= diginotesTraded;

            ExchangeData matchingExchange = new ExchangeData(exchange_id, user_id, matchingType, exchange_diginotes, diginotes_fulfilled, created);

            if (exchange.type == ExchangeType.BUY)
                MakeTransfer(exchange, matchingExchange, diginotesTraded);
            else
                MakeTransfer(matchingExchange, exchange, diginotesTraded);

            matchingExchange.diginotes_fulfilled += diginotesTraded;
            exchange.diginotes_fulfilled += diginotesTraded;

            NewExchange(matchingExchange);

            Console.Write("Found Match: id=" + exchange_id + " fortrade=" + diginotes_fortrade + " traded=" + diginotesTraded);
        }
    }


    /* Used by the server when detecting exchange matches to make the transfer of digicoins/balances between clients. */
    private void MakeTransfer(ExchangeData buyExchange, ExchangeData sellExchange, int diginotes)
    {
        float transferValue = diginotes * quotation;

        // since a transfer involves multiple sql commands, it should be wrapped in a transaction
        using (var command = new SQLiteCommand(db))
        {
            using (var transaction = db.BeginTransaction())
            {
                // update buy exchange
                command.CommandText = "UPDATE exchange SET diginotes_fulfilled = diginotes_fulfilled + @diginotes WHERE exchange_id = @exchangeId";
                command.Parameters.AddWithValue("@diginotes", diginotes);
                command.Parameters.AddWithValue("@exchangeId", buyExchange.exchange_id);
                command.ExecuteNonQuery();

                // update sell exchange
                command.CommandText = "UPDATE exchange SET diginotes_fulfilled = diginotes_fulfilled + @diginotes WHERE exchange_id = @exchangeId";
                command.Parameters.AddWithValue("@diginotes", diginotes);
                command.Parameters.AddWithValue("@exchangeId", sellExchange.exchange_id);
                command.ExecuteNonQuery();

                // update actual diginotes
                command.CommandText = "UPDATE diginote SET owner_id = @buyerId WHERE diginote_id IN (SELECT diginote_id FROM diginote where owner_id = @sellerId LIMIT @diginotes)";
                command.Parameters.AddWithValue("@buyerId", buyExchange.user_id);
                command.Parameters.AddWithValue("@sellerId", sellExchange.user_id);
                command.Parameters.AddWithValue("@diginotes", diginotes);
                command.ExecuteNonQuery();

                // update buyer balance
                command.Parameters.Clear();
                command.CommandText = "UPDATE user SET balance = balance - @value WHERE user_id = @buyerId";
                command.Parameters.AddWithValue("@buyerId", buyExchange.user_id);
                command.Parameters.AddWithValue("@value", transferValue);
                command.ExecuteNonQuery();

                // update seller balance
                command.Parameters.Clear();
                command.CommandText = "UPDATE user SET balance = balance + @value WHERE user_id = @sellerId";
                command.Parameters.AddWithValue("@sellerId", sellExchange.user_id);
                command.Parameters.AddWithValue("@value", transferValue);
                command.ExecuteNonQuery();

                // add transaction to history
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO history VALUES(null, @buyId, @sellId, @diginotes, @quotation, @created)";
                command.Parameters.AddWithValue("@buyId", buyExchange.user_id);
                command.Parameters.AddWithValue("@sellId", sellExchange.user_id);
                command.Parameters.AddWithValue("@diginotes", diginotes);
                command.Parameters.AddWithValue("@quotation", quotation);
                command.Parameters.AddWithValue("@created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }
    }
}