using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules.Interops;

/// <summary>
/// Componente para interagir com JS e obter os clicks no body do HTML.
/// </summary>
public sealed class JsBodyClickListener : IAsyncDisposable
{
    private readonly IJSObjectReference module;
    private readonly Func<bool, ICollection<ElementReference>, ValueTask> callback;
    private JsBodyClickInterop? interop;

    internal JsBodyClickListener(IJSObjectReference module, Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        this.module = module;
        this.callback = callback;
    }

    /// <summary>
    /// Inicia uma nova escuta de clicks, passando os elementos que devem ser analisados se clicou dentro ou não.
    /// </summary>
    /// <param name="element">Elemento base para saber se clicou dentro.</param>
    /// <param name="otherElements">Outros elementos para saber se clicou dentro.</param>
    /// <returns>Task para execução async.</returns>
    public async ValueTask ListenAsync(ElementReference element, params ElementReference[] otherElements)
    {
        await UnlistenAsync();
        interop = new JsBodyClickInterop(module, callback);
        await interop.ListenAsync(element);

        foreach (var otherElement in otherElements)
            await interop.AddTargetElementAsync(otherElement);
    }

    /// <summary>
    /// Finaliza a escuta dos eventos de click.
    /// </summary>
    /// <returns></returns>
    public async ValueTask UnlistenAsync()
    {
        if (interop is null)
            return;

        await interop.UnlistenAsync();
        interop = null;
    }

    /// <summary>
    /// Dispose, chamando o <see cref="UnlistenAsync"/>.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => UnlistenAsync();
}
