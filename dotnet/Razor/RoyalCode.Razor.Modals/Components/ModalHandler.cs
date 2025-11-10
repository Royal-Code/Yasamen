namespace RoyalCode.Razor.Components;

/// <summary>
/// Handler for modal operations.
/// </summary>
public class ModalHandler
{
    private Func<ModalEventArgs, Task>? listeners;

    /// <summary>
    /// The modal component.
    /// </summary>
    public Modal? Modal { get; internal set; }

    /// <summary>
    /// Executes the opening of the modal.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public Task OpenAsync()
    {
        if (Modal is null)
            throw new InvalidOperationException("Modal is not set.");

        return Modal.OpenAsync();
    }

    /// <summary>
    /// Executes the closing of the modal.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public Task CloseAsync()
    {
        if (Modal is null)
            throw new InvalidOperationException("Modal is not set.");

        return Modal.CloseAsync();
    }

    /// <summary>
    /// Adds a listener for the modal visibility event.
    /// </summary>
    /// <param name="listener"></param>
    public void AddModalEventListener(Func<ModalEventArgs, Task> listener)
    {
        if (listeners is null)
            listeners = listener;
        else
            listeners += listener;
    }

    /// <summary>
    /// Removes a listener for the modal visibility event.
    /// </summary>
    /// <param name="listener"></param>
    public void RemoveModalEventListener(Func<ModalEventArgs, Task> listener)
    {
        if (listeners is null)
            return;
        listeners -= listener;
    }

    /// <summary>
    /// Triggers the modal visibility event.
    /// </summary>
    /// <param name="args">Event arguments.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task OnModalEventAsync(ModalEventArgs args)
    {
        if (listeners is null)
            return;
        await listeners.Invoke(args);
    }
}

