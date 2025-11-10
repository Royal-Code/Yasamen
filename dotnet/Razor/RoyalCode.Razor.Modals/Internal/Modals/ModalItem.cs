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
    /// <param name="stateHasChangedAsync">The action to invoke when the state of the modal has changed.</param>
    public ModalItem(Func<Task> stateHasChangedAsync)
    {
        StateHasChangedAsync = stateHasChangedAsync;
    }

    /// <summary>
    /// <para>
    ///     Gets the value indicating whether the modal is open.
    /// </para>
    /// <para>
    ///     The set accessor is internal to allow the <see cref="ModalService"/> to control the state.
    /// </para>
    /// </summary>
    public bool IsOpen { get; internal set; }

    /// <summary>
    /// Determines whether the modal can be closed by clicking the backdrop or pressing the escape key.
    /// </summary>
    public bool Closeable { get; set; } = true;

    /// <summary>
    /// The action to invoke when the state of the modal has changed.
    /// </summary>
    public Func<Task> StateHasChangedAsync { get; }
}
