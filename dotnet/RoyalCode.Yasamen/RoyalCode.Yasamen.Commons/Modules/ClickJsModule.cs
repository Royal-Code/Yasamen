
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Interops;

namespace RoyalCode.Yasamen.Commons.Modules;

public sealed class ClickJsModule : JsModuleBase
{
    public ClickJsModule(IJSRuntime js) : base(js, "click.js") { }

    public async ValueTask<JsBodyClickListener> CreateListenerAsync(Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        var module = await GetModuleAsync();
        return new JsBodyClickListener(module, callback);
    }
}
