using RoyalCode.Razor.Commons;
using System.Collections.Concurrent;

namespace RoyalCode.Razor.Internal.Modals;

/// <summary>
/// <para>
///     A service to manage modal interactions.
/// </para>
/// <para>
///     This service allows adding, removing, opening, and closing modal items.
///     It keeps track of the currently opened modals and ensures that only one modal is open at a time.
/// </para>
/// <para>
///     As a service, it is intended to be a singleton per web application, 
///     typically registered in the dependency injection container as a scoped service,
///     because on WASM it will work like singleton, and on server-side it will be scoped per user session.
/// </para>
/// </summary>
public sealed class ModalService
{
    private readonly List<ModalState> modals = [];
    private readonly List<ModalState> opened = [];
    private readonly ConcurrentQueue<Func<Task>> actionQueue = [];

    /// <summary>
    /// An ordered read-only list of modal states, representing the modals managed by the service.
    /// </summary>
    public IReadOnlyList<ModalState> Modals => modals;

    /// <summary>
    /// The ModalOutlet component associated with this service.
    /// </summary>
    internal ModalOutlet? Outlet { get; set; }

    /// <summary>
    /// The backdrop modal state.
    /// </summary>
    internal TransitionState? BackdropState { get; set; }

    /// <summary>
    /// Adds a modal. This will create a SectionOutlet for the modal state.
    /// </summary>
    /// <param name="modalState">The modal state to be added.</param>
    internal void Add(ModalState modalState)
    {
        modals.Add(modalState);
        Outlet?.StateHasChangedAsync();
    }

    /// <summary>
    /// Removes a modal. The SectionOutlet associated with the modal state will be removed.
    /// </summary>
    /// <param name="modalState">The modal state to be removed.</param>
    internal void Remove(ModalState modalState)
    {
        modals.Remove(modalState);
        Outlet?.StateHasChangedAsync();
    }

    /// <summary>
    /// Check if any modal is currently opened.
    /// </summary>
    public bool IsOpen { get; private set; }

    /// <summary>
    /// <para>
    ///     Open a specific modal.
    /// </para>
    /// <para>
    ///     If a modal is already opened, it will be closed before opening the new modal.
    /// </para>
    /// </summary>
    /// <param name="modal">A modal to be opened.</param>
    /// <returns>A task that represents the asynchronous operation, finishing when the modal is opened.</returns>
    public Task OpenAsync(ModalState modal)
    {
        if (Outlet is null || BackdropState is null)
            return Task.CompletedTask;

        var currentModal = opened.LastOrDefault();
        if (currentModal == modal)
            return Task.CompletedTask;

        opened.Add(modal);

        if (currentModal is not null)
        {
            actionQueue.Enqueue(() => CloseModalAsync(currentModal));
            actionQueue.Enqueue(() => OpenModalAsync(modal));
        }
        else
        {
            actionQueue.Enqueue(OpenOutletAsync);
            actionQueue.Enqueue(OpenBackdropAsync);
            actionQueue.Enqueue(() => OpenModalAsync(modal));
        }

        return ProcessActionAsync();
    }

    /// <summary>
    /// Close the currently opened modal.
    /// </summary>
    /// <returns></returns>
    public Task CloseAsync()
    {
        var openedModal = opened.LastOrDefault();
        if (openedModal is null)
            return Task.CompletedTask;

        return CloseAsync(openedModal);
    }

    /// <summary>
    /// Close a specific modal item. If there was a previously opened modal, it will be reopened.
    /// </summary>
    /// <param name="modal">The modal to be closed.</param>
    /// <returns></returns>
    public Task CloseAsync(ModalState modal)
    {
        if (Outlet is null || BackdropState is null)
            return Task.CompletedTask;

        var currentModal = opened.LastOrDefault();
        if (currentModal is null || currentModal != modal)
        {
            opened.Remove(modal);
            return Task.CompletedTask;
        }

        var previousModal = opened.Count > 1 ? opened[^2] : null;
        opened.RemoveAt(opened.Count - 1);

        if (previousModal is null)
        {
            actionQueue.Enqueue(() => CloseModalAsync(modal));
            actionQueue.Enqueue(CloseBackdropAsync);
            actionQueue.Enqueue(CloseOutletAsync);
        }
        else
        {
            actionQueue.Enqueue(() => CloseModalAsync(modal));
            actionQueue.Enqueue(() => OpenModalAsync(previousModal));
        }

        return ProcessActionAsync();
    }

    /// <summary>
    /// <para>
    ///     Executes the action for the backdrop.
    /// </para>
    /// <para>
    ///     If the last opened item is closeable, it will be closed.
    /// </para>
    /// </summary>
    /// <returns></returns>
    internal Task BackdropActionAsync()
    {
        var modal = opened.LastOrDefault();
        return modal?.Closeable is true ? CloseAsync(modal) : Task.CompletedTask;
    }

    internal Task OpenOutletAsync()
    {
        if (Outlet is null || IsOpen)
            return Task.CompletedTask;

        IsOpen = true;
        return Outlet.StateHasChangedAsync();
    }

    internal Task OutletOpenedAsync()
    {
        return ProcessActionAsync();
    }

    internal Task CloseOutletAsync()
    {
        if (Outlet is null || !IsOpen)
            return Task.CompletedTask;
        IsOpen = false;
        return Outlet.StateHasChangedAsync();
    }

    internal Task OutletClosedAsync()
    {
        return ProcessActionAsync();
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

    internal Task OpenModalAsync(ModalState modal)
    {
        return modal.OpenAsync();
    }

    internal Task ModalOpenedAsync()
    {
        return ProcessActionAsync();
    }

    internal Task CloseModalAsync(ModalState modal)
    {
        return modal.CloseAsync();
    }

    internal Task ModalClosedAsync()
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
