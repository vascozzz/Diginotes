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
    public event EventHandler InitTrigger;

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

        string sql = "select user_id, balance from user where nickname = @nickname and password = @password";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read())
        {
            int user_id = Convert.ToInt32((long)data["user_id"]);
            float balance = Convert.ToSingle((double)data["balance"]);

            sql = "select count(*) as diginotes from diginote where owner_id = @owner_id";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@owner_id", user_id);
            data = command.ExecuteReader();

            data.Read();
            int diginotes = Convert.ToInt32((long)data["diginotes"]);

            float quotation = 1;

            return new ClientData(user_id, balance, diginotes, quotation);
        }
        else
            return null;
    }

    public bool Register(String name, String nickname, String password)
    {
        string sql = "insert into user (name, nickname, password) values (@name, @nickname, @password)";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();

        return true;
    }

    public void Trigger()
    {
        Console.WriteLine("A client called Trigger().");
        InitTrigger();
    }
}