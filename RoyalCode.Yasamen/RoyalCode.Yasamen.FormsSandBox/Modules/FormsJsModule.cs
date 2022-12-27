using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Modules;

namespace RoyalCode.Yasamen.Forms.Modules;

public class FormsJsModule : JsModuleBase
{
    private const string BlurOnPressEnterFn = "blurOnPressEnter";
    
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
    
    public async ValueTask<string> GetValueAsync(ElementReference element)
    {
        return await commonsJs.GetPropertyAsync<string>(element, "value");
    }

    public ValueTask SelectTextAsync(ElementReference element)
    {
        return commonsJs.CallMethodWithSetTimeoutAsync(element, "select", 20);
    }

    
}