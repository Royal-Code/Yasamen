using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Commons;

/// <summary>
/// Registering missing event handlers.
/// </summary>
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