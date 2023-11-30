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
    private object? currentValue;
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
    /// Get the current value of the state, if it is of the specified type.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <returns>
    ///     The current value of the state, if it is of the specified type, otherwise null (<c>default</c>).
    /// </returns>
    public TValue? GetValue<TValue>() => currentValue is TValue value ? value : default;

    /// <summary>
    /// Creates a listener for value changes of a specific type.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="handler">The property changed listener handler, that will be called when the property changes.</param>
    /// <returns>A new instance of <see cref="ChangeSupportListener{TValue}"/>.</returns>
    /// <exception cref="ArgumentNullException">if <paramref name="handler"/> is null.</exception>
    public ChangeSupportListener<TProperty> OnChanged<TProperty>(PropertyChangedHandler<TProperty> handler)
    {
        ArgumentNullException.ThrowIfNull(handler);

        var listener = new InternalListener<TProperty>(handler);
        listeners ??= [];
        listeners.Add(listener);

        var supportListener = new ChangeSupportListener<TProperty>(() =>
        {
            listeners.Remove(listener);
        });

        if (currentValue is TProperty value)
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
        ArgumentNullException.ThrowIfNull(handler);

        var listener = new InternalListener(handler);
        listeners ??= [];
        listeners.Add(listener);

        return new ChangeSupportListener(() =>
        {
            listeners.Remove(listener);
        });
    }

    /// <summary>
    /// <para>
    ///     Includes a property of <typeparamref name="TValue"/> type in the state change sharing.
    /// </para>
    /// <para>
    ///     This means that when the state of the property is changed (of the type <typeparamref name="TValue"/>),
    ///     the listeners of <typeparamref name="TValue"/> will be triggered 
    ///     and then the listeners of <typeparamref name="TIncludedProperty"/>.
    /// </para>
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TIncludedProperty"></typeparam>
    /// <param name="changeSupportName"></param>
    /// <param name="includedHandler"></param>
    public void Include<TValue, TIncludedProperty>(
        string changeSupportName,
        Func<TValue, TIncludedProperty> includedHandler)
    {
        var includedChangeSupport = collection.GetChangeSupport(changeSupportName);
        var include = new IncludeChangeSupport<TValue, TIncludedProperty>(includedChangeSupport, includedHandler);

        includes ??= [];
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
        currentValue = initialValue;

        InitializeIncludes(identifier, initialValue);
    }

    internal void HasCurrentValue<TValue>(TValue value)
    {
        if (Identifier is not null && currentValue is TValue previousValue && !Equals(previousValue, value))
            PropertyHasChanged(Identifier.Value, previousValue, value);
    }

    internal void InitializeIncludes<TValue>(FieldIdentifier identifier, TValue initialValue)
    {
        includes?.ForEach(i => i.Initialize(identifier, initialValue));
        parentPropertyChangeSupport?.GetChangeSupport(Name).InitializeIncludes(identifier, initialValue);
    }

    internal void Reset()
    {
        initialized = false;
        Identifier = default;
        FieldType = null;
        currentValue = default;

        includes?.ForEach(i => i.Reset());
        
        parentPropertyChangeSupport?.GetChangeSupport(Name).Reset();
    }
    
    internal void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
    {
        if (notifying)
            return;

        notifying = true;

        currentValue = newValue;

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

    private sealed class InternalListener(AnyPropertyChangedHandler handlerAny) 
        : IPropertyChangeListener
    {
        public void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, 
            TProperty oldValue, TProperty newValue)
        {
            handlerAny.Invoke(fieldIdentifier, oldValue, newValue);
        }
    }

    private sealed class InternalListener<TProperty>(PropertyChangedHandler<TProperty> handler) 
        : IPropertyChangeListener<TProperty>
    {
        public void PropertyHasChanged<T>(FieldIdentifier fieldIdentifier, T oldValue, T newValue) { }

        public void PropertyHasChanged(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
        {
            handler.Invoke(fieldIdentifier, oldValue, newValue);
        }
    }
}
