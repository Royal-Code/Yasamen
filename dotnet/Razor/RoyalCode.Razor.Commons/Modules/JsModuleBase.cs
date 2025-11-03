using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// Base class for JavaScript modules.
/// </summary>
public abstract class JsModuleBase
{
    private readonly string pathFromWwwRoot;
    private readonly bool isLibrary;
    
    private IJSObjectReference? module;

    /// <summary>
    /// Constructor for <see cref="JsModuleBase"/>.
    /// </summary>
    /// <param name="js">The JavaScript runtime.</param>
    /// <param name="pathFromWwwRoot">The path from wwwroot to the JavaScript module.</param>
    /// <param name="isLibrary">True if the module is a library, false if it is a custom module.</param>
    protected JsModuleBase(IJSRuntime js, string pathFromWwwRoot, bool isLibrary = true)
    {
        JSRuntime = js;
        this.pathFromWwwRoot = pathFromWwwRoot;
        this.isLibrary = isLibrary;
    }

    /// <summary>
    /// The JavaScript runtime.
    /// </summary>
    public IJSRuntime JSRuntime { get; }

    /// <summary>
    /// Get or create the module asynchronously.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Creates a module asynchronously.
    /// </summary>
    /// <typeparam name="Type">The type of the module.</typeparam>
    /// <param name="js">The JavaScript runtime.</param>
    /// <param name="pathFromWwwRoot">The path from wwwroot to the JavaScript module.</param>
    /// <returns>A new instance of the module.</returns>
    protected static ValueTask<IJSObjectReference> CreateModuleAsync<Type>(IJSRuntime js, string pathFromWwwRoot)
    {
        string modulePath = Path.Combine($"./_content/{typeof(Type).Assembly.GetName().Name}/", pathFromWwwRoot);

        return js.InvokeAsync<IJSObjectReference>("import", modulePath);
    }
}