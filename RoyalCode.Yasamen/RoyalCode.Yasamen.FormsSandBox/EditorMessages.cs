using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResult;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     Component to store the messages of the model editor.
/// </para>
/// <para>
///     The messagens will be showed in the MessagesSummary Component.
/// </para>
/// </summary>
public sealed class EditorMessages
{
    private static ConditionalWeakTable<object, LinkedList<IResultMessage>> messageLists = new();

    private readonly LinkedList<MessageListener> listeners = new();

    public IEnumerable<IResultMessage> GetMessages(object model)
    {
        if (messageLists.TryGetValue(model, out var messages))
            return messages;
        return Enumerable.Empty<IResultMessage>();
    }

    public IEnumerable<IResultMessage> GetMessages(FieldIdentifier fieldIdentifier)
    {
        if (messageLists.TryGetValue(fieldIdentifier.Model, out var messages))
            return messages.Where(m => m.Property == fieldIdentifier.FieldName);
        return Enumerable.Empty<IResultMessage>();
    }

    public IMessageListener CreateListener(FieldIdentifier fieldIdentifier, string fieldName)
    {
        if (fieldName is null)
            throw new ArgumentNullException(nameof(fieldName));

        var listener = new MessageListener(this, fieldIdentifier, fieldName);
        listeners.AddLast(listener);
        return listener;
    }


    internal void Add(object model, IEnumerable<IResultMessage> messages)
    {
        var list = messageLists.GetOrCreateValue(model);
        foreach (var m in messages)
            Add(list, model, m);
    }

    internal void Add(object model, IResultMessage message)
    {
        var list = messageLists.GetOrCreateValue(model);
        Add(list, model, message);
    }

    private void Add(LinkedList<IResultMessage> list, object model, IResultMessage message)
    {
        list.AddLast(message);
        int dispatchCount = 0;
        foreach (var l in listeners)
        {
            if (message.Property is not null && l.Match(model, message.Property))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }
        }
        if (dispatchCount == 0)
            messages.AddLast(message);
    }

    internal void Clear()
    {
        messages.Clear();
        foreach (var l in listeners)
            l.Clear();
    }

    internal void Remove(MessageListener messageListener)
    {
        listeners.Remove(messageListener);
    }
}

internal sealed class MessageListener : IMessageListener
{
    private readonly LinkedList<IResultMessage> messages = new();
    private readonly LinkedList<Action> actions = new();
    private readonly EditorMessages editorMessages;
    private readonly FieldIdentifier fieldIdentifier;
    private readonly string fieldName;

    public MessageListener(EditorMessages editorMessages, FieldIdentifier fieldIdentifier, string fieldName)
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

        return fieldName == property || fieldIdentifier.FieldName == property;
    }

    private void Fire()
    {
        foreach (var a in actions)
            a();
    }
}

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