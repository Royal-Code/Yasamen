using RoyalCode.Yasamen.Commons.Modules;

namespace RoyalCode.Yasamen.Commons.Interops;

/// <summary>
/// <para>
///     Options to listen for events via the <see cref="EventsJsModule"/> and <see cref="JsEventInterop{TData}"/>.
/// </para>
/// </summary>
public class JsEventListenerOptions
{
    internal static readonly JsEventListenerOptions Default = new();

    /// <summary>
    /// <para>
    ///     If the event should only be executed when the target of the event
    ///     is the same as the element added the listener.
    /// </para>
    /// <para>
    ///     This prevents listener execution if the event occurs on a child element.
    /// </para>
    /// </summary>
    public bool OnlyTarget { get; set; }

    /// <summary>
    /// Whether to run the preventDefault() method on the event object.
    /// </summary>
    public bool PreventDefault { get; set; }

    /// <summary>
    /// Whether to run the stopPropagation() method on the event object.
    /// </summary>
    public bool StopPropagation { get; set; }
}
