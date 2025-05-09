
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// Event arguments for when a dropdown is opened.
/// </summary>
public class DropOpenedEventArgs : EventArgs
{
    public DropOpenedEventArgs(DropBase dropBase)
    {
        DropBase = dropBase ?? throw new ArgumentNullException(nameof(dropBase));
    }

    /// <summary>
    /// The dropdown that was opened.
    /// </summary>
    public DropBase DropBase { get; }
}
