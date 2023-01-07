
using RoyalCode.OperationResult;

namespace RoyalCode.Yasamen.Forms.Messages;

public class MessagesList
{
    private Node? allHead;
    private Node? allTail;
    private Node? errorHead;
    private Node? errorTail;
    private Node? warningHead;
    private Node? warningTail;
    private Node? infoHead;
    private Node? infoTail;
    private Node? successHead;
    private Node? successTail;

    public int Count { get; private set; }

    public bool Any => allHead is not null;

    public bool IsEmpty => allHead is null;

    public bool HasErrors => errorHead is not null;
    public bool HasWarnings => warningHead is not null;
    public bool HasInfos => infoHead is not null;
    public bool HasSuccesses => successHead is not null;

    public IEnumerable<IResultMessage> Errors => Enumerate(errorHead, false);
    public IEnumerable<IResultMessage> Warnings => Enumerate(warningHead, false);
    public IEnumerable<IResultMessage> Infos => Enumerate(infoHead, false);
    public IEnumerable<IResultMessage> Successes => Enumerate(successHead, false);
    public IEnumerable<IResultMessage> All => Enumerate(allHead, false);

    public void Add(IResultMessage message)
    {
        var node = new Node(message);
        AddNode(node);
    }

    public void Clear()
    {
        allHead = null;
        allTail = null;
        errorHead = null;
        errorTail = null;
        warningHead = null;
        warningTail = null;
        infoHead = null;
        infoTail = null;
        successHead = null;
        successTail = null;
        Count = 0;
    }

    private void AddNode(Node node)
    {
        if (allHead is null)
        {
            allHead = node;
            allTail = node;
        }
        else
        {
            allTail!.allNext = node;
            allTail = node;
        }

        switch (node.message.Type)
        {
            case ResultMessageType.Error:
                if (errorHead is null)
                {
                    errorHead = node;
                    errorTail = node;
                }
                else
                {
                    errorTail!.perTypeNext = node;
                    errorTail = node;
                }
                break;
            case ResultMessageType.Warning:
                if (warningHead is null)
                {
                    warningHead = node;
                    warningTail = node;
                }
                else
                {
                    warningTail!.perTypeNext = node;
                    warningTail = node;
                }
                break;
            case ResultMessageType.Info:
                if (infoHead is null)
                {
                    infoHead = node;
                    infoTail = node;
                }
                else
                {
                    infoTail!.perTypeNext = node;
                    infoTail = node;
                }
                break;
            case ResultMessageType.Success:
                if (successHead is null)
                {
                    successHead = node;
                    successTail = node;
                }
                else
                {
                    successTail!.perTypeNext = node;
                    successTail = node;
                }
                break;
        }
        Count++;
    }
    
    private IEnumerable<IResultMessage> Enumerate(Node? node, bool all)
    {
        var current = node;
        while (current is not null)
        {
            yield return current.message;
            current = all ? current.allNext : current.perTypeNext;
        }
    }

    private class Node
    {
        public readonly IResultMessage message;
        public Node? allNext;
        public Node? perTypeNext;

        public Node(IResultMessage message)
        {
            this.message = message;
        }
    }
}

