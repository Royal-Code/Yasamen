namespace RoyalCode.Yasamen.Forms;

public class PropertyChangeSupport
{
    public PropertySupported<TValue> Property<TValue>(string name)
    {
        throw new NotImplementedException();
    }
}

public class PropertySupported<TValue>
{
    public PropertySupported<TValue> ChangeSupport<TChanged>(string changeSupportName, Action<TValue, TChanged> handler)
    {
        throw new NotImplementedException();
    }
    
    public PropertySupported<TValue> ChangeSupport<TChanged>(string changeSupportName, Func<TValue, TChanged, TValue> handler)
    {
        throw new NotImplementedException();
    }
}