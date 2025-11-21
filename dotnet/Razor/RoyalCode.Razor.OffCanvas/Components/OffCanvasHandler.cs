namespace RoyalCode.Razor.Components;

public class OffCanvasHandler
{
    private OffCanvas? offcanvas;

    public bool IsVisible => offcanvas?.IsVisible ?? false;

    public async ValueTask Toggle()
    {
        if (IsVisible)
            await Hide();
        else
            await Show();
    }
    
    public async ValueTask Show()
    {
        if (offcanvas is null)
            return;

        await offcanvas.OpenAsync();
    }

    public async ValueTask Hide()
    {
        if (offcanvas is null)
            return;

        await offcanvas.CloseAsync();
    }

    internal void Init(OffCanvas offcanvas)
    {
        this.offcanvas = offcanvas;
    }
}