
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Interops;

public sealed class JsBodyClickListener : IAsyncDisposable
{
    private readonly IJSObjectReference module;
    private readonly Func<bool, ICollection<ElementReference>, ValueTask> callback;
    private JsBodyClickInterop? interop;

    internal JsBodyClickListener(IJSObjectReference module, Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        this.module = module;
        this.callback = callback;
    }

    public async ValueTask ListenAsync(ElementReference element, params ElementReference[] otherElements)
    {
        await UnlistenAsync();
        interop = new JsBodyClickInterop(module, callback);
        await interop.ListenAsync(element);

        foreach (var otherElement in otherElements)
            await interop.AddTargetElementAsync(otherElement);
    }

    public async ValueTask UnlistenAsync()
    {
        if (interop is null)
            return;

        await interop.UnlistenAsync();
        interop = null;
    }

    public ValueTask DisposeAsync() => UnlistenAsync();
}
