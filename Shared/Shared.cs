using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void ExchangeHandler(UpdateData update);
public delegate void QuotationHandler();

public interface IRemObj
{
    event ExchangeHandler NewExchange;
    event QuotationHandler NewQuotation;

    ClientData Login(string nickname, string password);
    bool Register(String name, String nickname, String password);
    UpdateData RequestExchange(int user_id, ExchangeType exchangeType, int diginotes);
}

public class Intermediate : MarshalByRefObject
{
    public event ExchangeHandler NewExchange;
    public event QuotationHandler NewQuotation;

    public void TriggerNewExchange(UpdateData update)
    {
        NewExchange(update);
    }
}

[Serializable]
public class ClientData
{
    public int user_id;
    public string name;
    public float balance;
    public float balanceAvlb;
    public int diginotes;
    public int diginotesAvlb;
    public float quotation;

    public List<ExchangeData> exchanges;

    public ClientData(int user_id, string name, float balance, float balanceAvlb, int diginotes, int diginotesAvlb, float quotation, List<ExchangeData> exchanges) 
    {
        this.user_id = user_id;
        this.name = name;
        this.balance = balance;
        this.balanceAvlb = balanceAvlb;
        this.diginotes = diginotes;
        this.diginotesAvlb = diginotesAvlb;
        this.quotation = quotation;
        this.exchanges = exchanges;
    }

    public void UpdateAvailabilities() 
    {
        foreach (ExchangeData exchange in exchanges)
        {
            if (exchange.type == ExchangeType.BUY)
            {
                balanceAvlb -= (exchange.diginotes * quotation) - (exchange.diginotes_fulfilled);
            }
            else if (exchange.type == ExchangeType.SELL)
            {
                diginotesAvlb -= exchange.diginotes - exchange.diginotes_fulfilled;
            }
        }
    }

    public void UpdateAvailabilities(List<ExchangeData> exchangeList)
    {
        foreach (ExchangeData exchange in exchangeList)
        {
            if (exchange.type == ExchangeType.BUY)
            {
                balanceAvlb -= (exchange.diginotes * quotation) - (exchange.diginotes_fulfilled);
            }
            else if (exchange.type == ExchangeType.SELL)
            {
                diginotesAvlb -= exchange.diginotes - exchange.diginotes_fulfilled;
            }
        }
    }
}

[Serializable]
public class ExchangeData
{
    public int exchange_id;
    public int user_id;
    public ExchangeType type;
    public int diginotes;
    public int diginotes_fulfilled;
    public string created;

    public ExchangeData()
    {

    }

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

[Serializable]
public struct UpdateData
{
    public ClientData clientData;
    public ExchangeData exchange;

    public UpdateData(ClientData clientData, ExchangeData exchange)
    {
        this.clientData = clientData;
        this.exchange = exchange;
    }
}

public enum ExchangeType { BUY, SELL };