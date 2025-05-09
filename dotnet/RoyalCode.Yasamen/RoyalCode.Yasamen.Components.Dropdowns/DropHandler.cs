
namespace RoyalCode.Yasamen.Components;

public sealed class DropHandler
{
    private DropBase? drop;

    public bool IsOpen => drop?.IsOpen ?? false;

    internal void Listen(DropBase drop)
    {
        this.drop = drop;
    }

    internal void Unlisten() => drop = null;

    public async Task Open()
    {
        if (drop is not null)
            await drop.Open();
    }

    public async Task Close()
    {
        if (drop is not null)
            await drop.Close();
    }
}
