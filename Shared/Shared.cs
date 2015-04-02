using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void EventHandler();

public interface IRemObj
{
    event EventHandler InitTrigger;

    void Trigger();
    ClientData? Login(string nickname, string password);
    bool Register(String name, String nickname, String password);
}

public class Intermediate : MarshalByRefObject
{
    public event EventHandler InitTrigger;

    public void FireEvent()
    {
        InitTrigger();
    }
}

[Serializable]
public struct ClientData
{
    public int user_id;
    public float balance;
    public int diginotes;
    public float quotation;

    public ClientData(int user_id, float balance, int diginotes, float quotation) 
    {
        this.user_id = user_id;
        this.balance = balance;
        this.diginotes = diginotes;
        this.quotation = quotation;
    }
}