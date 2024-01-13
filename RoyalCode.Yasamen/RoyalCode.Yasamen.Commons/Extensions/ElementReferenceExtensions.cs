using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons.Modules;

namespace Microsoft.AspNetCore.Components;

/// <summary>
/// Extensions for <see cref="ElementReference"/>.
/// </summary>
public static class RoyalCodeElementReferenceExtensions
{
    /// <summary>
    /// Get the <see cref="IJSRuntime"/> for the <see cref="ElementReference"/>.
    /// </summary>
    /// <param name="elementReference"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IJSRuntime GetJSRuntime(this ElementReference elementReference)
    {
        if (elementReference.Context is not WebElementReferenceContext context)
        {
            throw new InvalidOperationException("ElementReference has not been configured correctly.");
        }

        return getJSRuntime(context);
    }

    /// <summary>
    /// Seleciona o texto de um elemento.
    /// </summary>
    /// <param name="element">Referência do elemento.</param>
    /// <returns>A <see cref="ValueTask"/> que representa a operação.</returns>
    public static async ValueTask SelectTextAsync(ElementReference element)
    {
        var js = element.GetJSRuntime();
        await CommonsJsModule.CallMethodWithSetTimeoutAsync(js, element, "select", 20);
    }

    private static Func<WebElementReferenceContext, IJSRuntime> getJSRuntime =
        typeof(WebElementReferenceContext)
            .GetProperty("JSRuntime")!
            .GetGetMethod()!
            .CreateDelegate<Func<WebElementReferenceContext, IJSRuntime>>();
}
