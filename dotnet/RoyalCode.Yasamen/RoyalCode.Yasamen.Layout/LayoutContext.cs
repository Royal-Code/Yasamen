
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Layout;

public class LayoutContext
{
    private readonly EventController<bool> menuInteractedListeners = new();

    public bool MenuInteracted { get; private set; }

    public void MenuInteract()
    {
        MenuInteracted = !MenuInteracted;
        menuInteractedListeners.Fire(MenuInteracted);
    }

    public IDisposable AddMenuInteracted(Action<bool> listener)
        => menuInteractedListeners.Listen(listener);

    public void AddAsideFragment(RenderFragment renderFragment) { }
}
