using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Interops;

namespace RoyalCode.Yasamen.Commons.Modules;

public class ScrollJsModule : JsModuleBase
{
    /* scroll.js */
    public static readonly string TopBarRegisterListener = "register";
    public static readonly string TopBarUnregisterListener = "unregister";

    public ScrollJsModule(IJSRuntime js) : base(js, "scroll.js") { }

    public async Task<ScrollInterop> Register(Action<bool> callback)
    {
        var js = await GetModuleAsync();
        var listener = new ScrollInterop(js);
        await listener.AddListener(callback);
        return listener;
    }
    
    public Task<ScrollInterop> Register(Func<bool, ValueTask> callback)
    {
        async void SyncCallback(bool scrolled) => await callback(scrolled);
        
        return Register(SyncCallback);
    }
}
