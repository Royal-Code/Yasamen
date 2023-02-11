
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Interops;

internal sealed class JsBodyClickInterop : IAsyncDisposable
{
    private const string register = "register";
    private const string unregister = "unregister";

    private readonly IJSObjectReference module;
    private readonly Func<bool, ValueTask> callback;
    private readonly DotNetObjectReference<JsBodyClickInterop>? handleReference;
    private ElementReference? element;

    public JsBodyClickInterop(IJSObjectReference module, Func<bool, ValueTask> callback)
    {
        this.module = module;
        this.callback = callback;

        handleReference = DotNetObjectReference.Create(this);
    }

    public ValueTask ListenAsync(ElementReference element)
    {
        this.element = element;
        return module.InvokeVoidAsync(register, element, handleReference);
    }

    public ValueTask UnlistenAsync()
    {
        if (element is null)
            return ValueTask.CompletedTask;

        element = null;
        return module.InvokeVoidAsync(unregister, element, handleReference);
    }

    [JSInvokable]
    public ValueTask OnClickedAsync(bool isInside)
    {
        return callback(isInside);
    }

    public ValueTask DisposeAsync() => UnlistenAsync();
}
