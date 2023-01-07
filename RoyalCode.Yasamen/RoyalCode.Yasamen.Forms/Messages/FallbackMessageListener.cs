using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms.Messages;

public sealed class FallbackMessageListener : IMessageListener
{
    private readonly LinkedList<Action> actions = new();
    private readonly EditorMessages editorMessages;
    private readonly object? model;
    private readonly bool modelless;

    public FallbackMessageListener(EditorMessages editorMessages, object? model)
    {
        this.editorMessages = editorMessages ?? throw new ArgumentNullException(nameof(editorMessages));
        this.model = model;
        modelless = model is null;
    }

    public MessagesList Messages { get; } = new();

    public bool HideMessages => false;

    public void Dispose()
    {
        Messages.Clear();
        actions.Clear();
        editorMessages.Remove(this);
    }

    public void ListenChanges(Action listener)
    {
        actions.AddLast(listener);
    }

    internal void Clear()
    {
        Messages.Clear();
        Fire();
    }

    internal void MessageAdded(IResultMessage message)
    {
        Messages.Add(message);
        Fire();
    }

    internal bool Match(object? model)
    {
        if (modelless)
            return false;
        return ReferenceEquals(model, this.model);
    }

    internal bool IsModelless => modelless;

    private void Fire()
    {
        foreach (var a in actions)
            a();
    }
}
