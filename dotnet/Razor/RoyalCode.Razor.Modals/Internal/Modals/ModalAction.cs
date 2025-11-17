namespace RoyalCode.Razor.Internal.Modals;

public class ModalAction
{
    private bool completed = false;

    public required ModalActionType Type { get; init; }

    public required Func<Task> OnComplete { get; init; }

    public Task Completed()
    {
        if (completed)
            return Task.CompletedTask;

        completed = true;
        return OnComplete();
    }
}

public enum ModalActionType
{
    Open,
    Close,
}