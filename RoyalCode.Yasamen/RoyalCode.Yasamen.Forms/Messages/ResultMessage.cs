using RoyalCode.OperationResult;
using System.Net;

namespace RoyalCode.Yasamen.Forms.Messages;

internal class ResultMessage : IResultMessage
{
    public static ResultMessage Error(string text, string? property = null)
    {
        return new ResultMessage(text, property);
    }

    public ResultMessage(string text, string? property)
    {
        Text = text;
        Property = property;
    }

    public string Text { get; }
    public string? Property { get; }
    public string? Code { get; }
    public HttpStatusCode? Status { get; }
    public Exception? Exception { get; }
    public IDictionary<string, object>? AdditionalInformation { get; }
}
