namespace RoyalCode.Razor.Internal.OffCanvas;

public class OffCanvasService
{
    private readonly List<OffCanvasState> states = [];
    private readonly List<OffCanvasState> opened = [];

    internal IReadOnlyList<OffCanvasState> OffCanvas => states.AsReadOnly();

    /// <summary>
    /// The OffCanvasOutlet component associated with this service.
    /// </summary>
    internal OffCanvasOutlet? Outlet { get; set; }

    internal void Add(OffCanvasState state)
    {
        states.Add(state);
        Outlet?.StateHasChanged();
    }

    internal void Remove(OffCanvasState state)
    {
        states.Remove(state);
        Outlet?.StateHasChanged();
    }

    public async Task OpenAsync(OffCanvasState state)
    {
        if (Outlet is null)
            return;

        // verificar os abertos do mesmo lado
        var sameSideOpened = opened.Count is 0 ? null : opened.Where(x => x.Position == state.Position).First();

        // se tem algum aberto do mesmo lado, fechar ele primeiro
        if (sameSideOpened is not null)
            await CloseAsync(sameSideOpened);

        // abrir o novo
        opened.Add(state);
        await state.ShowAsync();
    }

    public Task CloseAsync(OffCanvasState state)
    {
        if (Outlet is null)
            return Task.CompletedTask;

        return opened.Remove(state) ? state.HideAsync() : Task.CompletedTask;
    }

    internal Task BackdropActionAsync()
    {
        var offcanvas = opened.LastOrDefault();
        return offcanvas?.Closeable is true ? CloseAsync(offcanvas) : Task.CompletedTask;
    }
}
