namespace RoyalCode.Yasamen.Components;

/// <summary>
/// Represents the context of a modal. This class is a cascading value that is passed to child components of a modal.
/// </summary>
public class ModalContext
{
    /// <summary>
    /// The handler of the modal.
    /// </summary>
    public ModalHandler Handler { get; internal set; }
}
