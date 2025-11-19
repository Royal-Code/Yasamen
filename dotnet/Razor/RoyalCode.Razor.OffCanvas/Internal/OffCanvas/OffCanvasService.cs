using RoyalCode.Razor.Commons;
using System.Collections.Concurrent;

namespace RoyalCode.Razor.Internal.OffCanvas;

public class OffCanvasService
{
    private readonly List<OffCanvasState> states = [];
    private readonly List<OffCanvasState> opened = [];
    private readonly ConcurrentQueue<Func<Task>> actionQueue = [];

    internal IReadOnlyList<OffCanvasState> OffCanvas => states.AsReadOnly();

    /// <summary>
    /// The OffCanvasOutlet component associated with this service.
    /// </summary>
    internal OffCanvasOutlet? Outlet { get; set; }

    /// <summary>
    /// The backdrop modal state.
    /// </summary>
    internal TransitionState? BackdropState { get; set; }

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

    public Task OpenAsync(OffCanvasState state)
    {
        return Task.CompletedTask;
    }

    public Task CloseAsync(OffCanvasState state)
    {
        return Task.CompletedTask;
    }

    internal Task BackdropActionAsync()
    {
        var offcanvas = opened.LastOrDefault();
        return offcanvas?.Closeable is true ? CloseAsync(offcanvas) : Task.CompletedTask;
    }

    internal Task OpenBackdropAsync()
    {
        if (BackdropState is null)
            return Task.CompletedTask;
        return BackdropState.OpenAsync();
    }

    internal Task BackdropOpenedAsync()
    {
        return ProcessActionAsync();
    }

    internal Task CloseBackdropAsync()
    {
        if (BackdropState is null)
            return Task.CompletedTask;
        return BackdropState.CloseAsync();
    }

    internal Task BackdropClosedAsync()
    {
        return ProcessActionAsync();
    }

    private Task ProcessActionAsync()
    {
        if (actionQueue.TryDequeue(out var action))
        {
            return action();
        }
        return Task.CompletedTask;
    }
}
