using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Interops;

namespace RoyalCode.Yasamen.Commons.Modules;

public class EventsJsModule : JsModuleBase
{
    public EventsJsModule(IJSRuntime js) : base(js, "events.js") { }

    public async ValueTask<JsEventInterop<TData>> On<TData>(
        ElementReference element,
        string eventName,
        Action<TData?> callback,
        JsEventListenerOptions? options = null)
    {
        var js = await GetModuleAsync();
        var handler = new JsEventInterop<TData>(js);
        await handler.AddListener(element, eventName, options ?? JsEventListenerOptions.Default, callback);
        return handler;
    }
}
