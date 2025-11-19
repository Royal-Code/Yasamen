namespace RoyalCode.Razor.Commons;

/// <summary>
/// Specifies the phases of a transition lifecycle.
/// </summary>
public enum TransitionPhases
{
    /// <summary>
    /// The component/element is starting to open.
    /// </summary>
    OpeningStart,

    /// <summary>
    /// The component/element is opening.
    /// </summary>
    Opening,

    /// <summary>
    /// The component/element is open.
    /// </summary>
    Open,

    /// <summary>
    /// The component/element is starting to close.
    /// </summary>
    ClosingStart,

    /// <summary>
    /// The component/element is closing.
    /// </summary>
    Closing,

    /// <summary>
    /// The component/element is closed.
    /// </summary>
    Closed
}
