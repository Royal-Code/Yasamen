namespace RoyalCode.Razor.Components;

/// <summary>
/// Handler for controlling the visibility of an <see cref="OffCanvas"/> component.
/// </summary>
/// <remarks>
/// This class provides a simple interface to open, close, and toggle the state of an <see cref="OffCanvas"/>.
/// It is internally initialized by the <see cref="OffCanvas"/> component itself through <see cref="Init(OffCanvas)"/>.
/// It also allows registering a state update callback (for example, <c>StateHasChanged</c> in Blazor),
/// which will be triggered via <see cref="NotifyStateChanged"/> when changes occur.
/// </remarks>
public class OffCanvasHandler
{
    private OffCanvas? offcanvas;
    private Action? stateHasChanged;

    /// <summary>
    /// Indicates whether the associated <see cref="OffCanvas"/> is visible.
    /// </summary>
    public bool IsVisible => offcanvas?.IsVisible ?? false;

    /// <summary>
    /// Toggles the visibility of the <see cref="OffCanvas"/>.
    /// </summary>
    /// <returns>An asynchronous task representing the toggle operation.</returns>
    /// <remarks>
    /// If the <see cref="OffCanvas"/> is visible, it will be hidden; otherwise, it will be shown.
    /// </remarks>
    public async ValueTask Toggle()
    {
        if (IsVisible)
            await Hide();
        else
            await Show();
    }
    
    /// <summary>
    /// Shows the associated <see cref="OffCanvas"/>.
    /// </summary>
    /// <returns>An asynchronous task representing the open operation.</returns>
    /// <remarks>
    /// If no <see cref="OffCanvas"/> is associated, the operation will be ignored.
    /// Internally delegates to <see cref="OffCanvas.OpenAsync"/>.
    /// </remarks>
    public async ValueTask Show()
    {
        if (offcanvas is null)
            return;

        await offcanvas.OpenAsync();
    }

    /// <summary>
    /// Hides the associated <see cref="OffCanvas"/>.
    /// </summary>
    /// <returns>An asynchronous task representing the close operation.</returns>
    /// <remarks>
    /// If no <see cref="OffCanvas"/> is associated, the operation will be ignored.
    /// Internally delegates to <see cref="OffCanvas.CloseAsync"/>.
    /// </remarks>
    public async ValueTask Hide()
    {
        if (offcanvas is null)
            return;

        await offcanvas.CloseAsync();
    }

    /// <summary>
    /// Registers a UI state update callback.
    /// </summary>
    /// <param name="stateHasChanged">
    /// The action to be invoked when state changes occur (typically <c>StateHasChanged</c> in Blazor).
    /// </param>
    /// <remarks>
    /// Use <see cref="ClearStateHasChanged"/> to remove the registered callback.
    /// </remarks>
    public void RegisterStateHasChanged(Action stateHasChanged)
    {
        this.stateHasChanged = stateHasChanged;
    }

    /// <summary>
    /// Clears the previously registered UI state update callback.
    /// </summary>
    public void ClearStateHasChanged()
    {
        stateHasChanged = null;
    }

    /// <summary>
    /// Notifies that a state change has occurred by invoking the registered callback.
    /// </summary>
    /// <remarks>
    /// If no callback is registered, nothing will be executed.
    /// Method intended for internal use by project components.
    /// </remarks>
    internal void NotifyStateChanged()
    {
        stateHasChanged?.Invoke();
    }

    /// <summary>
    /// Initializes the handler with the <see cref="OffCanvas"/> instance to be controlled.
    /// </summary>
    /// <param name="offcanvas">Target instance of the <see cref="OffCanvas"/> component.</param>
    /// <remarks>
    /// Internal use method. Usually called by <see cref="OffCanvas"/> during parameter setup,
    /// binding the <see cref="OffCanvasHandler"/> to the state managed by
    /// <see cref="RoyalCode.Razor.Internal.OffCanvas.OffCanvasService"/>.
    /// </remarks>
    internal void Init(OffCanvas offcanvas)
    {
        this.offcanvas = offcanvas;
    }
}