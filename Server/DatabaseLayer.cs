using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

class DatabaseLayer
{
    private SQLiteConnection db;


    public DatabaseLayer()
    {
        db = new SQLiteConnection("Data Source=diginote.sqlite;Version=3;");
        db.Open();
    }


    public ClientData GetLogin(string nickname, string password)
    {
        string sql = "SELECT user_id, name, balance FROM USER where nickname = @nickname AND password = @password";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read()) {
            int user_id = Convert.ToInt32((long) data["user_id"]);
            string name = (string) data["name"];
            float balance = Convert.ToSingle((double) data["balance"]);
            float quotation = 1;

            ClientData clientData = new ClientData(user_id, name, balance, balance, -1, -1, quotation, null);
            return clientData;
        }
        else
        {
            return null;
        }     
    }


    public ClientData GetClientData(int user_id)
    {
        string sql = "SELECT name, balance FROM USER WHERE user_id = @user_id";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        SQLiteDataReader data = command.ExecuteReader();
        data.Read();

        string name = (string) data["name"];
        float balance = Convert.ToSingle((double) data["balance"]);

        ClientData clientData = new ClientData(user_id, name, balance, balance, -1, -1, 1, null);
        return clientData;
    }


    public bool Register(string name, string nickname, string password)
    {
        string sql = "SELECT * from user WHERE nickname = @nickname";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read())
        {
            return false;
        }

        sql = "INSERT INTO USER(name, nickname, password) VALUES(@name, @nickname, @password)";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();

        sql = "SELECT user_id FROM user WHERE nickname = @nickname";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        data = command.ExecuteReader();
        data.Read();
        int user_id = Convert.ToInt32((long) data["user_id"]);

        for (int i = 0; i < 20; i++)
        {
            sql = "INSERT INTO diginote VALUES(null, @user_id, @value)";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@value", 1);
            command.ExecuteNonQuery();
        }
 
        return true;
    }


    public int GetDiginotes(int user_id)
    {
        string sql = "SELECT COUNT(*) AS diginotes FROM diginote WHERE owner_id = @owner_id";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@owner_id", user_id);
        SQLiteDataReader data = command.ExecuteReader();
        data.Read();

        return Convert.ToInt32((long) data["diginotes"]);
    }


    public List<ExchangeData> GetExchanges(int user_id)
    {
        // find all previous exchanges
        string sql = "SELECT * FROM exchange where user_id = @user_id";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        SQLiteDataReader data = command.ExecuteReader();

        List<ExchangeData> exchanges = new List<ExchangeData>();

        // add them to an array that can be passed to the client data struct
        while (data.Read())
        {
            int exchange_id = Convert.ToInt32((long)data["exchange_id"]);
            ExchangeType type = (string)data["type"] == "BUY" ? ExchangeType.BUY : ExchangeType.SELL;
            int exchange_diginotes = Convert.ToInt32((long)data["diginotes"]);
            int diginotes_fulfilled = Convert.ToInt32((long)data["diginotes_fulfilled"]);
            string created = (string)data["created"];

            ExchangeData exchange = new ExchangeData(exchange_id, user_id, type, exchange_diginotes, diginotes_fulfilled, created);
            exchanges.Add(exchange);
        }

        return exchanges;
    }


    public ExchangeData RegisterExchange(int user_id, ExchangeType exchangeType, int diginotes)
    {
        string created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int diginotes_fulfilled = 0;
        int exchange_id = -1;

        // insert new exchange
        string sql = "INSERT INTO exchange VALUES(null, @user_id, @type, @diginotes, @diginotes_fulfilled, @created, 0)";
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

        return new ExchangeData(exchange_id, user_id, exchangeType, diginotes, diginotes_fulfilled, created);
    }


    public List<ExchangeData> GetMatches(ExchangeData exchange)
    {
        int user_id = exchange.user_id;
        ExchangeType type = exchange.type == ExchangeType.BUY ? ExchangeType.SELL : ExchangeType.BUY;

        string sql = "SELECT * FROM exchange WHERE blocked = 0 AND user_id != @userId AND type = @matchingType AND diginotes - diginotes_fulfilled > 0 ORDER BY created ASC";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@userId", user_id.ToString());
        command.Parameters.AddWithValue("@matchingType", type.ToString());
        SQLiteDataReader data = command.ExecuteReader();

        List<ExchangeData> matches = new List<ExchangeData>();

        while (data.Read())
        {
            int exchange_id = Convert.ToInt32((long) data["exchange_id"]);
            int exchange_user_id = Convert.ToInt32((long) data["user_id"]);
            int exchange_diginotes = Convert.ToInt32((long) data["diginotes"]);
            int diginotes_fulfilled = Convert.ToInt32((long) data["diginotes_fulfilled"]);
            string created = (string)data["created"];

            ExchangeData matchingExchange = new ExchangeData(exchange_id, exchange_user_id, type, exchange_diginotes, diginotes_fulfilled, created);
            matches.Add(matchingExchange);
        }

        return matches;
    }


    /* Used by the server when detecting exchange matches to make the transfer of digicoins/balances between clients. */
    public void RegisterTransfer(ExchangeData buyExchange, ExchangeData sellExchange, int diginotes, float quotation)
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

    public void UpdateExchange(int id, int updatedTo)
    {
        string sql = "UPDATE exchange SET diginotes = @updatedTo WHERE exchange_id = @id";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@updatedTo", updatedTo);
        command.ExecuteNonQuery();
    }


    /* Blocks all non-completed exchanges, except the user's. */
    public void BlockAllExchanges(int user_id, ExchangeType type)
    {
        string sql = "UPDATE exchange SET blocked = 1 WHERE user_id != @user_id AND type = @type AND diginotes - diginotes_fulfilled > 0";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        command.Parameters.AddWithValue("@type", type.ToString());
        command.ExecuteNonQuery();
    }

    public void UnblockAllExchanges()
    {
        string sql = "UPDATE exchange SET blocked = 0 WHERE diginotes - diginotes_fulfilled > 0";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.ExecuteNonQuery();
    }

    public void UnblockClientExchanges(int user_id)
    {
        string sql = "UPDATE exchange SET blocked = 0 WHERE user_id = @user_id AND diginotes - diginotes_fulfilled > 0";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        command.ExecuteNonQuery();
    }

    public void RemoveClientExchanges(int user_id)
    {
        // mark all exchanges as fulfilled
        string sql = "UPDATE exchange SET diginotes = diginotes_fulfilled WHERE user_id = @user_id AND diginotes - diginotes_fulfilled > 0";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        command.ExecuteNonQuery();

        // delete completely unfulfilled exchanges
        sql = "DELETE FROM exchange WHERE user_id = @user_id AND diginotes = 0";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@user_id", user_id);
        command.ExecuteNonQuery();
    }
}
