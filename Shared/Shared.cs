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
    ExchangeData RequestExchange(int user_id, ExchangeType exchangeType, int diginotes);
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

    public List<ExchangeData> exchanges;

    public ClientData(int user_id, string name, float balance, int diginotes, float quotation, List<ExchangeData> exchanges) 
    {
        this.user_id = user_id;
        this.name = name;
        this.balance = balance;
        this.diginotes = diginotes;
        this.quotation = quotation;
        this.diginotesAvlb = diginotes;
        this.balanceAvlb = balance;
        this.exchanges = exchanges;
    }
}

[Serializable]
public struct ExchangeData
{
    public int exchange_id;
    public int user_id;
    public ExchangeType type;
    public int diginotes;
    public int diginotes_fulfilled;
    public string created;

    public ExchangeData(int exchange_id, int user_id, ExchangeType type, int diginotes, int diginotes_fulfilled, string created)
    {
        this.exchange_id = exchange_id;
        this.user_id = user_id;
        this.type = type;
        this.diginotes = diginotes;
        this.diginotes_fulfilled = diginotes_fulfilled;
        this.created = created;
    }
}

public enum ExchangeType { BUY, SELL };