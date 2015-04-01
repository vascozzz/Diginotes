using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void EventHandler();

public interface IRemObj
{
    event EventHandler InitTrigger;

    String Ping();
    void Trigger();
    bool Login(string nickname, string password);
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