using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms;

public sealed class FallbackMessageListener : IMessageListener
{
    private readonly LinkedList<IResultMessage> messages = new();
    private readonly LinkedList<Action> actions = new();
    private readonly EditorMessages editorMessages;
    private readonly object model;

    public FallbackMessageListener(EditorMessages editorMessages, object model)
    {
        this.editorMessages = editorMessages ?? throw new ArgumentNullException(nameof(editorMessages));
        this.model = model ?? throw new ArgumentNullException(nameof(model));
    }

    public IEnumerable<IResultMessage> Messages => messages;

    public void Dispose()
    {
        messages.Clear();
        actions.Clear();
        editorMessages.Remove(this);
    }

    public void ListenChanges(Action listener)
    {
        actions.AddLast(listener);
    }

    internal void Clear()
    {
        messages.Clear();
        Fire();
    }

    internal void MessageAdded(IResultMessage message)
    {
        messages.AddLast(message);
        Fire();
    }

    internal bool Match(object model)
    {
        return ReferenceEquals(model, this.model);
    }

    private void Fire()
    {
        foreach (var a in actions)
            a();
    }
}
