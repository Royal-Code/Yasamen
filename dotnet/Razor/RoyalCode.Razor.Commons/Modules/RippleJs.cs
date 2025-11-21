using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// JS Module for Ripple effect.
/// </summary>
public sealed class RippleJs : JsModuleBase
{
    private const string rippleFn = "ripple";

    /// <summary>
    /// Initializes a new instance of the <see cref="RippleJs"/> class.
    /// </summary>
    /// <param name="js"></param>
    public RippleJs(IJSRuntime js) : base(js, "ripple.js") { }

    /// <summary>
    /// Initializes the ripple effect element.
    /// </summary>
    /// <param name="rippleSpanElement">The ripple span element reference.</param>
    /// <returns></returns>
    public async ValueTask RippleAsync(ElementReference rippleSpanElement)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(rippleFn, rippleSpanElement);
    }
}
