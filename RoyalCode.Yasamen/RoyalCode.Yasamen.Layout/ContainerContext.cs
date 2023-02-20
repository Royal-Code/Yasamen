
namespace RoyalCode.Yasamen.Layout;

/// <summary>
/// Context with the quantity of columns for the container.
/// </summary>
public class ContainerContext
{
    /// <summary>
    /// Quantity of columns.
    /// </summary>
    public int Columns { get; set; }

    /// <summary>
    /// Determines whether columns can be automatically resized for small screens.
    /// </summary>
    public bool Resize { get; set; }

    /// <summary>
    /// Whether the number of columns is set.
    /// </summary>
    public bool HasCustomColumns => Columns > 0;
}
