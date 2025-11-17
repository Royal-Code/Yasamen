namespace RoyalCode.Razor.Internal.Modals;

/// <summary>
/// Specifies the phases of a modal lifecycle.
/// </summary>
public enum ModalPhase
{
    /// <summary>
    /// The modal is opening.
    /// </summary>
    Opening,

    /// <summary>
    /// The modal is open.
    /// </summary>
    Opened,

    /// <summary>
    /// The modal is closing.
    /// </summary>
    Closing,

    /// <summary>
    /// The modal is closed.
    /// </summary>
    Closed
}
