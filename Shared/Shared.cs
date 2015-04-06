using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void ExchangeHandler();

public interface IRemObj
{
    event ExchangeHandler NewExchange;

    ClientData? Login(string nickname, string password);
    bool Register(String name, String nickname, String password);
    bool RequestExchange(ExchangeType exchangeType, int diginotes);
}

public class Intermediate : MarshalByRefObject
{
    public event ExchangeHandler NewExchange;

    public void TriggerNewExchange()
    {
        NewExchange();
    }
}

[Serializable]
public struct ClientData
{
    public int user_id;
    public string name;
    public float balance;
    public int diginotes;
    public float quotation;

    public int diginotesAvlb;
    public float balanceAvlb;

    public ClientData(int user_id, string name, float balance, int diginotes, float quotation) 
    {
        this.user_id = user_id;
        this.name = name;
        this.balance = balance;
        this.diginotes = diginotes;
        this.quotation = quotation;
        this.diginotesAvlb = diginotes;
        this.balanceAvlb = balance;
    }
}

public enum ExchangeType { BUY, SELL };