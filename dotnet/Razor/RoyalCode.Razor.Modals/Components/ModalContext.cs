using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Components;

/// <summary>
/// A context for a modal component.
/// </summary>
public sealed class ModalContext
{
    /// <summary>
    /// The handler of the modal.
    /// </summary>
    public ModalHandler? Handler { get; internal set; }

    /// <summary>
    /// The modal component.
    /// </summary>
    public Modal? Modal { get; internal set; }

    /// <summary>
    /// The element reference of the modal.
    /// </summary>
    public ElementReference Element { get; internal set; }
}
