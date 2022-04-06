namespace RoyalCode.Yasamen.Commons;

public sealed class EventController<TEventValue>
{
    public LinkedList<EventListener<TEventValue>>? listeners;

    public EventListener<TEventValue> Listen(Action<TEventValue> callback)
    {
        listeners ??= new();

        var listener = new EventListener<TEventValue>(this, callback);
        listeners.AddLast(listener);
        return listener;
    }

    public void Fire(TEventValue value)
    {
        if (listeners is null)
            return;
        foreach (var listener in listeners)
        {
            listener.Notify(value);
        }
    }

    internal void Remove(EventListener<TEventValue> listener)
    {
        if (listeners is null)
            return;
        
        listeners.Remove(listener);
        if (listeners.Count is 0)
            listeners = null;
    }
}