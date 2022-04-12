namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     This class is a product of <see cref="ChangeSupport"/>
///     created each time a handler is added to listen for changes to a property.
/// </para>
/// <para>
///     It should be used to remove the handler, via the <see cref="Dispose"/>,
///     when the component that added the listening handler no longer needs to listen, usually in dispose.
/// </para>
/// </summary>
public class ChangeSupportListener : IDisposable
{
    private readonly Action onDisposing;

    protected internal ChangeSupportListener(Action onDisposing)
    {
        this.onDisposing = onDisposing;
    }

    /// <summary>
    /// Removes the listen/watch value change handler.
    /// </summary>
    public void Dispose() => onDisposing();
}

/// <summary>
/// <para>
///     This class is a product of <see cref="ChangeSupport"/>
///     created each time a handler is added to listen for changes to a property.
/// </para>
/// <para>
///     It should be used to remove the handler, via the <see cref="Dispose"/>,
///     when the component that added the listening handler no longer needs to listen, usually in dispose.
/// </para>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// </summary>
public class ChangeSupportListener<TValue> : ChangeSupportListener
{
    internal ChangeSupportListener(Action onDisposing) : base(onDisposing) { }

    /// <summary>
    /// Initial value, which would be the current value at the time the <see cref="ChangeSupport"/> was created.
    /// </summary>
    public TValue? InitialValue { get; internal set; }
}