namespace RoyalCode.Yasamen.Commons;

public sealed class EventListener<TEventValue> : IDisposable
{
    private readonly EventController<TEventValue> controller;

    public EventListener(EventController<TEventValue> controller, Action<TEventValue> callback)
    {
        this.controller = controller;
        Callback = callback;
    }

    public TEventValue? LastValue { get; private set; }
    
    internal Action<TEventValue> Callback { get; }
    
    internal void Notify(TEventValue value)
    {
        LastValue = value;
        Callback(value);
    }

    public void Dispose() => controller.Remove(this);
}