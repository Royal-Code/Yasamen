namespace RoyalCode.Razor.Components;

/// <summary>
/// Visibility event args for modal.
/// </summary>
public sealed class ModalEventArgs : EventArgs
{
    /// <summary>
    /// The modal.
    /// </summary>
    public required Modal Modal { get; init; }

    /// <summary>
    /// <para>
    ///     Defines whether the modal is open or closed.
    /// </para>
    /// </summary>
    public required bool IsOpen { get; init; }
}
