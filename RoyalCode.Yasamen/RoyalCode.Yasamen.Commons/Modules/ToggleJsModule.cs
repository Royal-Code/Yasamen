using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules
{
    public class ToggleJsModule : JsModuleBase
    {
        /* toggle.js */
        public static readonly string CssClassToggleBetween = "between";

        public ToggleJsModule(IJSRuntime js) : base(js, "toggle.js") { }

        public async ValueTask CssClassToggle(ElementReference element, string cssClassTrue, string cssClassFalse, bool toggle)
        {
            var js = await GetModuleAsync();
            await js.InvokeVoidAsync(CssClassToggleBetween, element, cssClassTrue, cssClassFalse, toggle);
        }
    }
}
