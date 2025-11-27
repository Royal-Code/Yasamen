using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules;

internal static class Extensions
{
    public static async ValueTask TryInvokeVoidAsync(this IJSObjectReference jsObjectReference, string identifier, params object?[]? args)
    {
        try
        {
            await jsObjectReference.InvokeVoidAsync(identifier, args);
        }
        catch { /* ignore */ }
    }
}
