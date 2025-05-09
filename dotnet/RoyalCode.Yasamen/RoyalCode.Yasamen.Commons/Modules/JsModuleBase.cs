using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules;

public abstract class JsModuleBase
{
    private readonly string pathFromWwwRoot;
    private readonly bool isLibrary;
    
    private IJSObjectReference? module;

    protected JsModuleBase(IJSRuntime js, string pathFromWwwRoot, bool isLibrary = true)
    {
        JSRuntime = js;
        this.pathFromWwwRoot = pathFromWwwRoot;
        this.isLibrary = isLibrary;
    }

    public IJSRuntime JSRuntime { get; }

    protected async ValueTask<IJSObjectReference> GetModuleAsync()
    {
        if (module is not null)
            return module;

        string modulePath = isLibrary 
            ? Path.Combine($"./_content/{GetType().Assembly.GetName().Name}/", pathFromWwwRoot) 
            : pathFromWwwRoot;
        
        module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", modulePath);
        return module;
    }
}