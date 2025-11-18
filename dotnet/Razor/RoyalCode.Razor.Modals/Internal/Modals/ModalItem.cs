using Microsoft.AspNetCore.Components.Sections;

namespace RoyalCode.Razor.Internal.Modals;

/// <summary>
/// <para>
///     Represents a modal item.
/// </para>
/// <para>
///     Modal item is used by <see cref="ModalService"/> and <see cref="ModalOutlet"/> 
///     to create <see cref="SectionOutlet"/> for each modal.
/// </para>
/// </summary>
public sealed class ModalItem
{
    /// <summary>
    /// Creates a new instance of <see cref="ModalItem"/>.
    /// </summary>
    /// <param name="performAsync">A callback to perform when an action is requested on the modal.</param>
    public ModalItem()
    {
        
    }

    /// <summary>
    /// <para>
    ///     Gets the value indicating whether the modal is open.
    /// </para>
    /// <para>
    ///     The set accessor is internal to allow the <see cref="ModalService"/> to control the state.
    /// </para>
    /// </summary>
    public TransitionPhases Phase { get; internal set; } = TransitionPhases.Closed;

    /// <summary>
    /// Determines whether the modal can be closed by clicking the backdrop or pressing the escape key.
    /// </summary>
    public bool Closeable { get; set; } = true;

    /// <summary>
    /// Callback to perform when an action is requested on the modal.
    /// </summary>
    public Func<object, Task> PerformAsync { get; }
}
