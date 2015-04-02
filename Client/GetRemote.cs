using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Diagnostics;

class GetRemote
{
    private static IDictionary wellKnownTypes;

    public static object New(Type type)
    {
        if (wellKnownTypes == null)
            InitTypeCache();
        WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)wellKnownTypes[type];
        if (entry == null)
            throw new RemotingException("Type not found!");
        return Activator.GetObject(type, entry.ObjectUrl);
    }

    public static void InitTypeCache()
    {
        Hashtable types = new Hashtable();
        foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
        {
            if (entry.ObjectType == null)
                throw new RemotingException("A configured type could not be found!");
            types.Add(entry.ObjectType, entry);
        }
        wellKnownTypes = types;
    }
}