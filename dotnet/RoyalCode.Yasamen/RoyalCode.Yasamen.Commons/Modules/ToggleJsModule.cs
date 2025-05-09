using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules;

public class ToggleJsModule : JsModuleBase
{
    /* toggle.js */
    public const string CssClassToggleBetween = "between";
    public const string CssClassToggleToggle = "toggle";
    public const string CssClassToggleBody = "bodyToggle";

    public ToggleJsModule(IJSRuntime js) : base(js, "toggle.js") { }

    public async ValueTask CssClassToggle(ElementReference element, string cssClassTrue, string cssClassFalse, bool toggle)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(CssClassToggleBetween, element, cssClassTrue, cssClassFalse, toggle);
    }
    
    public async ValueTask CssClassToggle(ElementReference element, string cssClass, bool toggle)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(CssClassToggleToggle, element, cssClass, toggle);
    }

    public async ValueTask BodyCssClassToggle(string cssClass, bool toggle)
    {
        var js = await GetModuleAsync();

        await js.InvokeVoidAsync(CssClassToggleBody, cssClass, toggle);
    }
}
