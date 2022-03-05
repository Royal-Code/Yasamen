
namespace RoyalCode.Yasamen.Layout;

public class LayoutContext
{
    private Action<bool>? menuInteractedListeners;

    public bool MenuInteracted { get; set; }

    public void MenuInteract()
    {
        MenuInteracted = !MenuInteracted;
        menuInteractedListeners?.Invoke(MenuInteracted);
    }

    public void AddMenuInteracted(Action<bool> listener)
    {
        if (menuInteractedListeners == null)
            menuInteractedListeners = listener;
        else
            menuInteractedListeners += listener;
    }
}
