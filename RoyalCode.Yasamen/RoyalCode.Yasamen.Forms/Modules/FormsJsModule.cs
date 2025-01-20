using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Modules;

namespace RoyalCode.Yasamen.Forms.Modules;

public sealed class FormsJsModule : JsModuleBase
{
    private const string BlurOnPressEnterFn = "blurOnPressEnter";
    private const string RegisterInputLengthFn = "registerInputLength";
    private const string UnregisterInputLengthFn = "unregisterInputLength";

    private readonly CommonsJsModule commonsJs;
    
    public FormsJsModule(CommonsJsModule commonsJs) : base(commonsJs.JSRuntime, "forms.js")
    {
        this.commonsJs = commonsJs;
    }
    
    public async ValueTask BlurOnPressEnterAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(BlurOnPressEnterFn, element);
    }

    public async ValueTask RegisterInputLengthListenerAsync(ElementReference element, object handler)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(RegisterInputLengthFn, element, handler);
    }

    public async ValueTask UnregisterInputLengthListenerAsync(object handler)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(UnregisterInputLengthFn, handler);
    }

    public async ValueTask<string> GetValueAsync(ElementReference element)
    {
        return await commonsJs.GetPropertyAsync<string>(element, "value");
    }

    public ValueTask SelectTextAsync(ElementReference element)
    {
        return commonsJs.CallMethodWithSetTimeoutAsync(element, "select", 20);
    }
}