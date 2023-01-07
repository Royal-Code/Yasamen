using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms.Messages;

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
    private readonly LinkedList<MessageListener> listeners = new();
    private readonly LinkedList<FallbackMessageListener> fallbackListeners = new();

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

    public IMessageListener CreateModellessFallbackListner()
    {
        var listener = new FallbackMessageListener(this, null);
        fallbackListeners.AddLast(listener);
        return listener;
    }

    internal void Add(object model, IEnumerable<IResultMessage> messages)
    {
        foreach (var m in messages)
            Add(model, m);
    }

    internal void Add(object model, IResultMessage message)
    {
        int dispatchCount = 0;
        foreach (var l in listeners)
            if (message.Property is not null && l.Match(model, message.Property))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }

        if (dispatchCount is not 0)
            return;

        foreach (var l in fallbackListeners)
            if (l.Match(model))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }

        if (dispatchCount is not 0)
            return;

        foreach (var l in fallbackListeners)
            if (l.IsModelless)
                l.MessageAdded(message);
    }

    internal void Add(FieldIdentifier fieldIdentifier, IResultMessage message)
    {
        int dispatchCount = 0;
        foreach (var l in listeners)
            if (l.Match(fieldIdentifier))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }

        if (dispatchCount is not 0)
            return;

        foreach (var l in fallbackListeners)
            if (l.Match(fieldIdentifier.Model))
            {
                l.MessageAdded(message);
                dispatchCount++;
            }

        if (dispatchCount is not 0)
            return;

        foreach (var l in fallbackListeners)
            if (l.IsModelless)
                l.MessageAdded(message);
    }

    internal void Hide(FieldIdentifier fieldIdentifier)
    {
        foreach (var l in listeners)
            if (l.Match(fieldIdentifier))
                l.Hide();
    }

    internal void Show(FieldIdentifier fieldIdentifier)
    {
        foreach (var l in listeners)
            if (l.Match(fieldIdentifier))
                l.Show();
    }

    internal void Clear(FieldIdentifier fieldIdentifier)
    {
        foreach (var l in listeners)
            if (l.Match(fieldIdentifier))
                l.Clear();
    }

    internal void Clear(object model)
    {
        int matchModel = 0;
        foreach (var l in listeners)
            if (l.Match(model))
                l.Clear();

        foreach (var l in fallbackListeners)
            if (l.Match(model))
            {
                l.Clear();
                matchModel++;
            }

        if (matchModel is not 0)
            return;

        foreach (var l in fallbackListeners)
            if (l.IsModelless)
                l.Clear();
    }

    internal void ClearAll()
    {
        foreach (var l in listeners)
            l.Clear();
        foreach (var l in fallbackListeners)
            l.Clear();
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
