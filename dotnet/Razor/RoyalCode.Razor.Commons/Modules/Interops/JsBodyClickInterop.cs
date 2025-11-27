using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules.Interops;

/// <summary>
/// Interop com JS para eventos de click no body do HTML.
/// </summary>
internal sealed class JsBodyClickInterop : IAsyncDisposable
{
    private const string register = "register";
    private const string unregister = "unregister";
    private const string addTargetElement = "addTargetElement";

    private readonly IJSObjectReference module;
    private readonly Func<bool, ICollection<ElementReference>, ValueTask> callback;
    private readonly DotNetObjectReference<JsBodyClickInterop> handleReference;
    private ElementReference? element;
    private List<ElementReference>? targetElements;

    /// <summary>
    /// Cria novo Interop.
    /// </summary>
    /// <param name="module"></param>
    /// <param name="callback"></param>
    public JsBodyClickInterop(IJSObjectReference module, Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        this.module = module;
        this.callback = callback;

        handleReference = DotNetObjectReference.Create(this);
    }

    /// <summary>
    /// Inicia a escuta de eventos click no body.
    /// </summary>
    /// <param name="element">Elemento base para saber se clicou dentro.</param>
    /// <returns></returns>
    public ValueTask ListenAsync(ElementReference element)
    {
        this.element = element;
        return module.InvokeVoidAsync(register, element, handleReference);
    }

    /// <summary>
    /// Adiciona um elemento para saber se clicou dentro.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public ValueTask AddTargetElementAsync(ElementReference element)
    {
        targetElements ??= [];
        targetElements.Add(element);

        return module.InvokeVoidAsync(addTargetElement, handleReference, element, element.Id);
    }
    
    /// <summary>
    /// Finaliza a escuta do evento.
    /// </summary>
    /// <returns></returns>
    public async ValueTask UnlistenAsync()
    {
        if (element is null)
            return;
        
        await module.TryInvokeVoidAsync(unregister, handleReference);
        element = null;
        targetElements?.Clear();
        targetElements = null;
    }

    /// <summary>
    /// Callback do JS, informando se clicou dentro do elemento, e o id do elemento clicado.
    /// </summary>
    /// <param name="isInside"></param>
    /// <param name="targetElementsIds"></param>
    /// <returns></returns>
    [JSInvokable]
    public ValueTask OnClickedAsync(bool isInside, string targetElementsIds)
    {
        var clickedTargetElements = targetElements?.Where(x => targetElementsIds.Contains(x.Id)).ToList() ?? [];

        return callback(isInside, clickedTargetElements);
    }

    /// <summary>
    /// Finaliza o componente, chamando <see cref="UnlistenAsync"/>.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => UnlistenAsync();
}
