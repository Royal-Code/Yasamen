namespace RoyalCode.Yasamen.Forms.Support;

public class PropertySupported<TValue>
{
    private readonly PropertyChangeSupport support;
    private PropertySupport<TValue>? component;

    public PropertySupported(PropertyChangeSupport support)
    {
        this.support = support;
    }
    
    public TValue? Value
    {
        get => component is not null ? component.Value : default;
        set => component?.SetValue(value);
    }

    internal void Initialize(PropertySupport<TValue> component)
    {
        this.component = component;
    }

    internal void Reset()
    {
        component = null;
    }
    
    public PropertySupported<TValue> ChangeSupport<TChanged>(string changeSupportName, Action<TValue, TChanged> handler)
    {
        support.GetChangeSupport(changeSupportName)
            .OnChanged<TChanged>((_, _, n) =>
            {
                var v = Value;
                handler(v, n);
                Value = v;
            });

        return this;
    }
    
    public PropertySupported<TValue> ChangeSupport<TChanged>(string changeSupportName, Func<TValue, TChanged, TValue> handler)
    {
        support.GetChangeSupport(changeSupportName)
            .OnChanged<TChanged>((_, _, n) =>
            {
                Value = handler(Value, n);
            });

        return this;
    }
}