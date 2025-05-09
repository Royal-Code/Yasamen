using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResults;

namespace RoyalCode.Yasamen.Forms.Messages;

internal sealed class MessageListener : IMessageListener
{
    private readonly LinkedList<Action> actions = new();
    private readonly EditorMessages editorMessages;
    private readonly FieldIdentifier fieldIdentifier;
    private readonly string? fieldName;

    public MessageListener(EditorMessages editorMessages, FieldIdentifier fieldIdentifier, string? fieldName)
    {
        this.editorMessages = editorMessages;
        this.fieldIdentifier = fieldIdentifier;
        this.fieldName = fieldName;
    }

    public MessagesList Messages { get; } = new();

    public bool HideMessages { get; private set; }

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
        HideMessages = false;
        Fire();
    }

    internal void MessageAdded(IResultMessage message)
    {
        Messages.Add(message);
        HideMessages = false;
        Fire();
    }

    internal bool Match(object model, string property)
    {
        if (!ReferenceEquals(model, fieldIdentifier.Model))
            return false;

        return fieldName is not null && fieldName == property || fieldIdentifier.FieldName == property;
    }

    internal bool Match(FieldIdentifier fieldIdentifier)
    {
        return this.fieldIdentifier.Equals(fieldIdentifier);
    }

    internal bool Match(object model)
    {
        return ReferenceEquals(model, fieldIdentifier.Model);
    }

    internal void Hide()
    {
        HideMessages = true;
        Fire();
    }

    internal void Show()
    {
        HideMessages = false;
        Fire();
    }

    private void Fire()
    {
        foreach (var a in actions)
            a();
    }
}
