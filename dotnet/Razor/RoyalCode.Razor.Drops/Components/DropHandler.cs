using RoyalCode.Razor.Internal.Drops;

namespace RoyalCode.Razor.Components;

/// <summary>
/// A handler to control a drop component, e.g., to open or close it programmatically.
/// </summary>
public sealed class DropHandler
{
    private DropBase? drop;

    /// <summary>
    /// Gets a value indicating whether the drop is currently open.
    /// </summary>
    public bool IsOpen => drop?.IsOpen ?? false;

    /// <summary>
    /// Internal method to listen to a drop component.
    /// </summary>
    /// <param name="drop"></param>
    internal void Listen(DropBase drop)
    {
        this.drop = drop;
    }

    /// <summary>
    /// Internal method to unlisten from the drop component.
    /// </summary>
    internal void Unlisten() => drop = null;

    /// <summary>
    /// Opens the drop component.
    /// </summary>
    public async Task Open()
    {
        if (drop is not null)
            await drop.Open();
    }

    /// <summary>
    /// Closes the drop component.
    /// </summary>
    public async Task Close()
    {
        if (drop is not null)
            await drop.Close();
    }
}
