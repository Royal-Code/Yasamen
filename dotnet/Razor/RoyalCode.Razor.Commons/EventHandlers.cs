using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Commons;

/// <summary>
/// Registering missing event handlers.
/// </summary>
[EventHandler("ontransitionEnded", typeof(TransitionEndedEventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("ontransitionend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onanimationend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("oninputCharCount", typeof(InputCharCountEventArgs), enableStopPropagation: true, enablePreventDefault: false)]
[EventHandler("onarrowUpDown", typeof(ArrowUpDownEventArgs), enableStopPropagation: true, enablePreventDefault: false)]
public static class EventHandlers { }

/// <summary>
/// Character count event arguments.
/// </summary>
public class InputCharCountEventArgs : EventArgs
{
    /// <summary>
    /// Number of characters.
    /// </summary>
    public int CharCount { get; set; }
}

/// <summary>
/// Arguments for the up and down arrow event.
/// </summary>
public class ArrowUpDownEventArgs : EventArgs
{
    /// <summary>
    /// Event value.
    /// </summary>
    public string Key { get; set; } = string.Empty;
}

/// <summary>
/// Arguments for transition end events.
/// </summary>
public class TransitionEndedEventArgs : EventArgs
{
    /// <summary>
    /// The name of the property associated with the transition.
    /// </summary>
    public string PropertyName { get; set; } = string.Empty;

    /// <summary>
    /// The elapsed time of the transition in seconds.
    /// </summary>
    public double ElapsedTime { get; set; }

    /// <summary>
    /// Optional, a Blazor element reference (<c>data-ref</c>).
    /// </summary>
    public string? DataRef { get; set; }

    /// <summary>
    /// Optional, the element id.
    /// </summary>
    public string? ElementId { get; set; }
}