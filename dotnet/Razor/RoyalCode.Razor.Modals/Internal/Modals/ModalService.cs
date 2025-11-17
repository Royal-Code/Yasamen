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
    private readonly List<ModalItem> items = [];
    private readonly List<ModalItem> openedItems = [];

    /// <summary>
    /// An ordered read-only list of modal items, representing the modals managed by the service (opened).
    /// </summary>
    public IReadOnlyList<ModalItem> Items => items;

    /// <summary>
    /// The ModalOutlet component associated with this service.
    /// </summary>
    internal ModalOutlet? Outlet { get; set; }

    /// <summary>
    /// The backdrop modal item.
    /// </summary>
    internal ModalItem? Backdrop { get; set; }

    /// <summary>
    /// Adds a modal item. This will create a SectionOutlet for the modal item.
    /// </summary>
    /// <param name="item">The modal item to be added.</param>
    public void Add(ModalItem item)
    {
        items.Add(item);
        Outlet?.StateHasChanged();
    }

    /// <summary>
    /// Removes a modal item. The SectionOutlet associated with the modal item will be removed.
    /// </summary>
    /// <param name="item">The modal item to be removed.</param>
    public void Remove(ModalItem item)
    {
        items.Remove(item);
        Outlet?.StateHasChanged();
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
    /// <param name="item">A modal item to be opened.</param>
    /// <returns>A task that represents the asynchronous operation, finishing when the modal is opened.</returns>
    public async Task OpenAsync(ModalItem item)
    {
        if (Outlet is null || Backdrop is null)
            return;

        TaskCompletionSource tcs = new();

        var openAction = new ModalAction()
        {
            Type = ModalActionType.Open,
            OnComplete = () =>
            {
                openedItems.Add(item);
                tcs.SetResult();
                return Task.CompletedTask;
            }
        };

        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null)
        {
            // se não houver nenhum aberto, abre o backdrop primeiro
            var openOutletAction = new ModalAction()
            {
                Type = ModalActionType.Open,
                OnComplete= () => item.PerformAsync(openAction)
            };

            await Outlet.PerformAsync(openOutletAction);
        }
        else
        {
            var closeLastAction = new ModalAction()
            {
                Type = ModalActionType.Close,
                OnComplete = () => item.PerformAsync(openAction)
            };

            await openedItem.PerformAsync(closeLastAction);
        }
    }

    /// <summary>
    /// Close the currently opened modal.
    /// </summary>
    /// <returns></returns>
    public Task CloseAsync()
    {
        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null)
            return Task.CompletedTask;

        return CloseAsync(openedItem);
    }

    /// <summary>
    /// Close a specific modal item. If there was a previously opened modal, it will be reopened.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task CloseAsync(ModalItem item)
    {
        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null || Outlet is null || Backdrop is null)
            return;

        openedItems.Remove(item);
        if (openedItem != item)
            return;


        Func<Task> onClosedAction;

        var nextOpenedItem = openedItems.LastOrDefault();
        if (nextOpenedItem is not null)
        {
            onClosedAction = async () =>
            {
                var openNextAction = new ModalAction()
                {
                    Type = ModalActionType.Open,
                    OnComplete = () => Task.CompletedTask
                };
                await nextOpenedItem.PerformAsync(openNextAction);
            };
        }
        else
        {
            onClosedAction = async () =>
            {
                var closeOutletAction = new ModalAction()
                {
                    Type = ModalActionType.Close,
                    OnComplete = () => Task.CompletedTask
                };
                await Outlet.PerformAsync(closeOutletAction);
            };
        }

        var closeAction = new ModalAction()
        {
            Type = ModalActionType.Close,
            OnComplete = onClosedAction
        };

        await Outlet.PerformAsync(closeAction);
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
    public Task BackdropActionAsync()
    {
        var openedItem = openedItems.LastOrDefault();
        return openedItem?.Closeable is true ? CloseAsync(openedItem) : Task.CompletedTask;
    }
}

public class ModalCommandQueue
{
    private readonly ConcurrentQueue<IModalCommand> queue = new();

    public void Enqueue(IModalCommand command)
    {
        queue.Enqueue(command);
    }

    public async Task ExecuteAsync()
    {
        while (queue.TryDequeue(out var command))
        {
            await command.ExecuteAsync();
        }
    }
}

public interface IModalCommand
{
    Task ExecuteAsync();
}

public class OutletCommand : IModalCommand
{
    private readonly ModalActionType actionType;
    private readonly ModalOutlet outlet;

    public Task ExecuteAsync()
    {
        TaskCompletionSource tcs = new();

        ModalAction action = new()
        {
            Type = actionType,
            OnComplete = () =>
            {
                tcs.SetResult();
                return Task.CompletedTask;
            }
        };

        outlet.PerformAsync(action);
    }
}