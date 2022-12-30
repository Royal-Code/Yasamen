using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms;

public interface IMessageListener : IDisposable
{
    void ListenChanges(Action listener);

    IEnumerable<IResultMessage> Messages { get; }

    public bool HasError => DefaultHasError(this);

    protected static bool DefaultHasError(IMessageListener messageListener)
    {
        return messageListener.Messages.Any(m => m.Type == ResultMessageType.Error);
    }
}