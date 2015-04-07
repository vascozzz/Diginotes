using System;
using System.Collections;
using System.Runtime.Remoting;
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
    public event ExchangeHandler NewExchange;
    private SQLiteConnection db;

    public RemObj()
    {
        Console.WriteLine("Server constructor called.");

        db = new SQLiteConnection("Data Source=diginote.sqlite;Version=3;");
        db.Open();
    }

    public ClientData? Login(string nickname, string password)
    {
        Console.WriteLine("A client called Login().");

        string sql = "SELECT user_id, name, balance FROM USER where nickname = @nickname AND password = @password";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read())
        {
            int user_id = Convert.ToInt32((long)data["user_id"]);
            string name = (string) data["name"];
            float balance = Convert.ToSingle((double)data["balance"]);

            sql = "SELECT COUNT(*) AS diginotes FROM diginote WHERE owner_id = @owner_id";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@owner_id", user_id);
            data = command.ExecuteReader();

            data.Read();
            int diginotes = Convert.ToInt32((long)data["diginotes"]);
            float quotation = 1;

            return new ClientData(user_id, name, balance, diginotes, quotation);
        }
        else
        {
            return null;
        }         
    }

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

    public bool RequestExchange(ExchangeType exchangeType, int diginotes)
    {
        Console.WriteLine("A client called RequestExchange().");

        NewExchange();
        return true;
    }

    private void MakeTransfer(int buyerId, int sellerId, int diginotes, float value)
    {
        using (var command = new SQLiteCommand(db))
        {
            using (var transaction = db.BeginTransaction())
            {
                command.CommandText = "UPDATE diginote SET owner_id = @buyerId WHERE diginote_id IN (SELECT diginote_id FROM diginote where owner_id = @sellerId LIMIT @diginotes)";
                command.Parameters.AddWithValue("@buyerId", buyerId);
                command.Parameters.AddWithValue("@sellerId", sellerId);
                command.Parameters.AddWithValue("@diginotes", diginotes);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "UPDATE user SET balance = balance - @value WHERE user_id = @buyerId";
                command.Parameters.AddWithValue("@buyerId", buyerId);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "UPDATE user SET balance = balance + @value WHERE user_id = @sellerId";
                command.Parameters.AddWithValue("@sellerId", sellerId);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }
    }
}