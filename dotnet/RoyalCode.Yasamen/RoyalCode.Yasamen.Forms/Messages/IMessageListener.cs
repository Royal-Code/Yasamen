
namespace RoyalCode.Yasamen.Forms.Messages;

public interface IMessageListener : IDisposable
{
    void ListenChanges(Action listener);

    MessagesList Messages { get; }

    bool HideMessages { get; }
}