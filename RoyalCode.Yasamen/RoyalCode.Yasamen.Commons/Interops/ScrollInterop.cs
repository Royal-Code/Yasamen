using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Modules;

namespace RoyalCode.Yasamen.Commons.Interops;

public class ScrollInterop : IAsyncDisposable
{
    private readonly IJSObjectReference js;
    private readonly DotNetObjectReference<ScrollInterop> thisRef;

    private Action<bool>? callback;

    internal ScrollInterop(IJSObjectReference js)
    {
        this.js = js;
        thisRef = DotNetObjectReference.Create(this);
    }

    public ValueTask AddListener(Action<bool> callback)
    {
        this.callback = callback;
        return js.InvokeVoidAsync(ScrollJsModule.TopBarRegisterListener, thisRef);
    }

    [JSInvokable]
    public void Scrolled(bool wasScrolled)
    {
        callback?.Invoke(wasScrolled);
    }

    public async ValueTask DisposeAsync()
    {
        await js.InvokeVoidAsync(ScrollJsModule.TopBarUnregisterListener, thisRef);
        thisRef.Dispose();
    }
}
