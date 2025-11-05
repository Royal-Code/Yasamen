namespace RoyalCode.Razor.Components;

public class OffCanvasHandler
{
    private OffCanvas? offCanvas;

    public bool IsVisible => offCanvas?.IsVisible ?? false;

    public async ValueTask Toggle()
    {
        if (IsVisible)
            await Hide();
        else
            await Show();
    }
    
    public async ValueTask Show()
    {
        if (offCanvas is null)
            return;

        await offCanvas.Show();
    }

    public async ValueTask Hide()
    {
        if (offCanvas is null)
            return;

        await offCanvas!.Hide();
    }

    internal void Init(OffCanvas offCanvas)
    {
        this.offCanvas = offCanvas;
    }
}