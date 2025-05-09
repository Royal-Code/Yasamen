
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// Event arguments for when a dropdown is closed.
/// </summary>
public class DropClosedEventArgs : EventArgs
{
    public DropClosedEventArgs(DropBase dropBase)
    {
        DropBase = dropBase ?? throw new ArgumentNullException(nameof(dropBase));
    }

    /// <summary>
    /// The dropdown that was closed.
    /// </summary>
    public DropBase DropBase { get; }
}