
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Interops;

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

    public JsBodyClickInterop(IJSObjectReference module, Func<bool, ICollection<ElementReference>, ValueTask> callback)
    {
        this.module = module;
        this.callback = callback;

        handleReference = DotNetObjectReference.Create(this);
    }

    public ValueTask ListenAsync(ElementReference element)
    {
        this.element = element;
        return module.InvokeVoidAsync(register, element, handleReference);
    }

    public ValueTask AddTargetElementAsync(ElementReference element)
    {
        targetElements ??= [];
        targetElements.Add(element);

        return module.InvokeVoidAsync(addTargetElement, handleReference, element, element.Id);
    }
    
    public async ValueTask UnlistenAsync()
    {
        if (element is null)
            return;
        
        await module.InvokeVoidAsync(unregister, handleReference);
        element = null;
        targetElements?.Clear();
        targetElements = null;
    }

    [JSInvokable]
    public ValueTask OnClickedAsync(bool isInside, string targetElementsIds)
    {
        var targetElements = this.targetElements?.Where(x => targetElementsIds.Contains(x.Id)).ToList() ?? [];

        return callback(isInside, targetElements);
    }

    public ValueTask DisposeAsync() => UnlistenAsync();
}
