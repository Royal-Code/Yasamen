using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResult;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     Component to store the messages of the model editor.
/// </para>
/// <para>
///     The messagens will be showed in the MessagesSummary and FieldMessages Components.
/// </para>
/// </summary>
public sealed class EditorMessages
{
    private ConditionalWeakTable<object, LinkedList<IResultMessage>> messageLists = new();

    private readonly LinkedList<MessageListener> listeners = new();
    private readonly LinkedList<FallbackMessageListener> fallbackListeners = new();

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

    public IMessageListener CreateListener(FieldIdentifier fieldIdentifier, string? fieldName)
    {
        var listener = new MessageListener(this, fieldIdentifier, fieldName);
        listeners.AddLast(listener);
        return listener;
    }

    public IMessageListener CreateFallbackListner(object model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        var listener = new FallbackMessageListener(this, model);
        fallbackListeners.AddLast(listener);
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

    internal void Add(FieldIdentifier fieldIdentifier, IResultMessage message)
    {
        var list = messageLists.GetOrCreateValue(fieldIdentifier.Model);
        Add(list, fieldIdentifier, message);
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
            foreach (var l in fallbackListeners)
                if (l.Match(model))
                    l.MessageAdded(message);
    }

    private void Add(LinkedList<IResultMessage> list, FieldIdentifier fieldIdentifier, IResultMessage message)
    {
        list.AddLast(message);
        int dispatchCount = 0;
        foreach (var l in listeners)
        {
            if (l.Match(fieldIdentifier))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }
        }
        if (dispatchCount == 0)
            foreach (var l in fallbackListeners)
                if (l.Match(fieldIdentifier.Model))
                    l.MessageAdded(message);
    }

    internal void Hide(FieldIdentifier fieldIdentifier)
    {
        foreach (var l in listeners)
        {
            if (l.Match(fieldIdentifier))
            {
                l.Hide();
            }
        }
    }

    internal void Show(FieldIdentifier fieldIdentifier)
    {
        foreach (var l in listeners)
        {
            if (l.Match(fieldIdentifier))
            {
                l.Show();
            }
        }
    }

    internal void Clear(FieldIdentifier fieldIdentifier)
    {
        if (messageLists.TryGetValue(fieldIdentifier.Model, out var list))
        {
            foreach (var l in listeners)
            {
                if (l.Match(fieldIdentifier))
                {
                    foreach (var m in l.Messages)
                        list.Remove(m);
                    l.Clear();
                }
            }
        }
    }

    internal void Clear(object model)
    {
        if (messageLists.TryGetValue(model, out var messages))
        {
            messages.Clear();
            foreach (var l in listeners)
                if (l.Match(model))
                    l.Clear();
        }
    }

    internal void ClearAll()
    {
        messageLists.Clear();
    }

    internal void Remove(MessageListener messageListener)
    {
        listeners.Remove(messageListener);
    }

    internal void Remove(FallbackMessageListener messageListener)
    {
        fallbackListeners.Remove(messageListener);
    }
}
