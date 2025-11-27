using RoyalCode.Razor.Internal.Drops;

namespace RoyalCode.Razor.Components;

/// <summary>
/// Event arguments for when a drop component is opened or closed.
/// </summary>
public class DropEventArgs : EventArgs
{
    /// <summary>
    /// Creates a new instance of <see cref="DropEventArgs"/>.
    /// </summary>
    /// <param name="dropBase">The drop component that was opened or closed.</param>
    /// <exception cref="ArgumentNullException">
    ///     When <paramref name="dropBase"/> is <see langword="null"/>.
    /// </exception>
    public DropEventArgs(DropBase dropBase)
    {
        Component = dropBase ?? throw new ArgumentNullException(nameof(dropBase));
    }

    /// <summary>
    /// The drop component that was opened or closed.
    /// </summary>
    public DropBase Component { get; }
}
