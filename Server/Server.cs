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

    public String Ping()
    {
        return "Pong";
    }

    /* Actual implementation */

    private SQLiteConnection db;

    public RemObj()
    {
        Console.WriteLine("Server constructor called.");
        db = new SQLiteConnection("Data Source=diginote.sqlite;Version=3;");
        db.Open();
    }

    public bool Login(string nickname, string password)
    {
        Console.WriteLine("A client called Login().");
        string sql = "select * from user where nickname = @nickname and password = @password";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        int rowCount = Convert.ToInt32(command.ExecuteScalar());

        return (rowCount > 0);
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