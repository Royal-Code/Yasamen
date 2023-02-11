
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

    public void Open()
    {
        if (drop is not null)
            drop.Open();
    }

    public void Close()
    {
        if (drop is not null)
            drop.Close();
    }
}
