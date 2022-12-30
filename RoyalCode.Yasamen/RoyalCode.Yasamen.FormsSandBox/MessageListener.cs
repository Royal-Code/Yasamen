using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms;

internal sealed class MessageListener : IMessageListener
{
    private readonly LinkedList<IResultMessage> messages = new();
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

    internal bool Match(object model, string property)
    {
        if (!ReferenceEquals(model, fieldIdentifier.Model))
            return false;

        return (fieldName is not null && fieldName == property) || fieldIdentifier.FieldName == property;
    }

    internal bool Match(FieldIdentifier fieldIdentifier)
    {
        return this.fieldIdentifier.Equals(fieldIdentifier);
    }
    
    internal bool Match(object model)
    {
        return ReferenceEquals(model, fieldIdentifier.Model);
    }

    private void Fire()
    {
        foreach (var a in actions)
            a();
    }
}
