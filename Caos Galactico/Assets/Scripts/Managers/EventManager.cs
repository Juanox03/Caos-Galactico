using System.Collections.Generic;

public abstract class EventManager
{
    public delegate void MyEvents(params object[] parameters);

    static Dictionary<string, MyEvents> _myEvent = new Dictionary<string, MyEvents>();

    public static void Subscribe(string name, MyEvents events)
    {
        if (_myEvent.ContainsKey(name))
            _myEvent[name] += events;
        else
            _myEvent.Add(name, events);
    }

    public static void Unsubscribe(string name, MyEvents events)
    {
        if (_myEvent.ContainsKey(name))
        {
            _myEvent[name] -= events;

            if (_myEvent[name] == null)
                _myEvent.Remove(name);
        }
    }

    public static void Trigger(string name, params object[] parameters)
    {
        if (_myEvent.ContainsKey(name))
            _myEvent[name](parameters);
    }
}