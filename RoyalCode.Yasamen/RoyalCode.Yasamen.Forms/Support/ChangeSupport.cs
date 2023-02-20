using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     The <see cref="ChangeSupport"/> serves to configure and manage the state-change
///     sharing between different components.
/// </para>
/// <para>
///     This class is managed by <see cref="PropertyChangeSupport"/>
///     and state change sharing is driven by a unique name (<see cref="Name"/>).
/// </para>
/// <para>
///     A component that owns a state fires a state changed event and other components can listen to this event.
/// </para>
/// </summary>
public sealed class ChangeSupport
{
    private readonly ChangeSupportCollection collection;
    private readonly PropertyChangeSupport? parentPropertyChangeSupport;
    private List<IIncludeChangeSupport>? includes;
    private List<IPropertyChangeListener>? listeners;
    private bool initialized;
    private object? initialValue;
    private bool notifying;

    internal ChangeSupport(string name,
        ChangeSupportCollection collection,
        PropertyChangeSupport? parentPropertyChangeSupport)
    {
        Name = name;
        this.collection = collection;
        this.parentPropertyChangeSupport = parentPropertyChangeSupport;
    }
    
    /// <summary>
    /// Name of the <see cref="ChangeSupport"/>, used to identify the state being shared.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// <para>
    ///     The <see cref="FieldBase{TValue}" /> that owns the state being shared.
    /// </para>
    /// </summary>
    public FieldIdentifier? Identifier { get; private set; }

    /// <summary>
    /// <para>
    ///     The field value type.
    /// </para>
    /// </summary>
    public Type? FieldType { get; private set; }

    /// <summary>
    /// Creates a listener for value changes of a specific type.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="handler">The property changed listener handler, that will be called when the property changes.</param>
    /// <returns>A new instance of <see cref="ChangeSupportListener{TValue}"/>.</returns>
    /// <exception cref="ArgumentNullException">if <paramref name="handler"/> is null.</exception>
    public ChangeSupportListener<TProperty> OnChanged<TProperty>(PropertyChangedHandler<TProperty> handler)
    {
        if (handler is null)
            throw new ArgumentNullException(nameof(handler));

        var listener = new InternalListener<TProperty>(handler);
        listeners ??= new();
        listeners.Add(listener);

        var supportListener = new ChangeSupportListener<TProperty>(() =>
        {
            listeners.Remove(listener);
        });

        if (initialValue is TProperty value)
            supportListener.InitialValue = value;

        return supportListener;
    }

    /// <summary>
    /// Creates a listener for value changes of any type.
    /// </summary>
    /// <param name="handler">The property changed listener handler, that will be called when the property changes.</param>
    /// <returns>A new instance of <see cref="ChangeSupportListener"/>.</returns>
    /// <exception cref="ArgumentNullException">if <paramref name="handler"/> is null.</exception>
    public ChangeSupportListener OnAnyChanged(AnyPropertyChangedHandler handler)
    {
        if (handler is null)
            throw new ArgumentNullException(nameof(handler));

        var listener = new InternalListener(handler);
        listeners ??= new();
        listeners.Add(listener);

        return new ChangeSupportListener(() =>
        {
            listeners.Remove(listener);
        });
    }
    
    // TODO: tentar explicar o que isso faz.
    public void Include<TValue, TIncludedProperty>(
        string changeSupportName,
        Func<TValue, TIncludedProperty> includedHandler)
    {
        var includedChangeSupport = collection.GetChangeSupport(changeSupportName);
        var include = new IncludeChangeSupport<TValue, TIncludedProperty>(includedChangeSupport, includedHandler);

        includes ??= new();
        includes.Add(include);
    }

    /// <summary>
    /// <para>
    ///     Initializes the <see cref="ChangeSupport"/> with the <see cref="FieldBase{TValue}"/> that owns the state.
    /// </para>
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="identifier">The <see cref="FieldIdentifier"/> of the <see cref="FieldBase{TValue}"/> that owns the state.</param>
    /// <param name="initialValue">The initial value of the state.</param>
    /// <exception cref="InvalidOperationException">if the <see cref="ChangeSupport"/> is already initialized.</exception>
    internal void Initialize<TValue>(FieldIdentifier identifier, TValue initialValue)
    {
        if (initialized)
            throw new InvalidOperationException($"The {nameof(ChangeSupport)} was initialized before");

        initialized = true;
        Identifier = identifier;
        FieldType = typeof(TValue);
        this.initialValue = initialValue;

        InitializeIncludes(identifier, initialValue);
    }

    internal void InitializeIncludes<TValue>(FieldIdentifier identifier, TValue initialValue)
    {
        includes?.ForEach(i => i.Initialize(identifier, initialValue));
        parentPropertyChangeSupport?.GetChangeSupport(Name).InitializeIncludes(identifier, initialValue);
    }

    //TODO: ver se isso é necessário.
    internal void SetIdentifier(FieldIdentifier identifier)
    {
        if (!initialized)
            throw new InvalidOperationException($"The {nameof(ChangeSupport)} must be initialized");

        Identifier = identifier;
    }

    internal void Reset()
    {
        initialized = false;
        Identifier = default;
        FieldType = null;
        initialValue = default;

        includes?.ForEach(i => i.Reset());
        
        parentPropertyChangeSupport?.GetChangeSupport(Name).Reset();
    }
    
    internal void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
    {
        if (notifying)
            return;

        notifying = true;

        listeners?.ForEach(l =>
        {
            if (l is IPropertyChangeListener<TProperty> typedListener)
                typedListener.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
            else
                l.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
        });
        
        includes?.ForEach(i => i.PropertyHasChanged(fieldIdentifier, oldValue, newValue));

        notifying = false;
    }

    private sealed class InternalListener : IPropertyChangeListener
    {
        public InternalListener(AnyPropertyChangedHandler handlerAny)
        {
            HandlerAny = handlerAny ?? throw new ArgumentNullException(nameof(handlerAny));
        }

        private AnyPropertyChangedHandler HandlerAny { get; }

        public void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
        {
            HandlerAny.Invoke(fieldIdentifier, oldValue, newValue);
        }
    }

    private sealed class InternalListener<TProperty> : IPropertyChangeListener<TProperty>
    {
        public InternalListener(PropertyChangedHandler<TProperty> handler)
        {
            Handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        private PropertyChangedHandler<TProperty> Handler { get; }

        public void PropertyHasChanged<T>(FieldIdentifier fieldIdentifier, T oldValue, T newValue) { }

        public void PropertyHasChanged(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
        {
            Handler.Invoke(fieldIdentifier, oldValue, newValue);
        }
    }
}
