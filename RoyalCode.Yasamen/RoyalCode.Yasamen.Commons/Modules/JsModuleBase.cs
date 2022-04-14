using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules;

public abstract class JsModuleBase
{
    private readonly string pathFromWwwRoot;

    private IJSObjectReference? module;

    protected JsModuleBase(IJSRuntime js, string pathFromWwwRoot)
    {
        JSRuntime = js;
        this.pathFromWwwRoot = pathFromWwwRoot;
    }

    public IJSRuntime JSRuntime { get; }

    protected async Task<IJSObjectReference> GetModuleAsync()
    {
        if (module is not null)
            return module;

        var libraryName = GetType().Assembly.GetName().Name;
        module = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
            Path.Combine($"./_content/{libraryName}/", pathFromWwwRoot));
        return module;
    }
}