using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// Módulo JS para efeito ripple.
/// </summary>
public sealed class RippleJsModule : JsModuleBase
{
    private const string rippleFn = "ripple";

    /// <summary>
    /// Inicializa o módulo.
    /// </summary>
    /// <param name="js"></param>
    public RippleJsModule(IJSRuntime js) : base(js, "ripple.js") { }

    /// <summary>
    /// Inicializa o elemento de efeito ripple.
    /// </summary>
    /// <param name="rippleSpanElement"></param>
    /// <returns></returns>
    public async ValueTask RippleAsync(ElementReference rippleSpanElement)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(rippleFn, rippleSpanElement);
    }
}
