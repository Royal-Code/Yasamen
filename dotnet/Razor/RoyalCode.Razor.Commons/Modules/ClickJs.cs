using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Razor.Commons.Modules.Interops;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// Módulo JS para interagir com clicks no body do HTML.
/// </summary>
public sealed class ClickJs : JsModuleBase
{
    /// <summary>
    /// Cria novo módulo.
    /// </summary>
    /// <param name="js"></param>
    public ClickJs(IJSRuntime js) : base(js, "click.js") { }

    /// <summary>
    /// Cria um listener para click no body do HTML.
    /// </summary>
    /// <param name="callback">Função de callback.</param>
    /// <returns>Um componente de listener. Quando não for mais necessário, deve ser dado dispose dele.</returns>
    public async ValueTask<JsBodyClickListener> CreateListenerAsync(Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        var module = await GetModuleAsync();
        return new JsBodyClickListener(module, callback);
    }
}
