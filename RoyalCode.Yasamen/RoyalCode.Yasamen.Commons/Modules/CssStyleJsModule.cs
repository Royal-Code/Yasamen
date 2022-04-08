using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules;

public class CssStyleJsModule : JsModuleBase
{
    /* css-style.js */
    public const string SetVariableFn = "setVariable";
    public const string SetDocumentVariableFn = "setDocumentVariable";
    public const string GetVariableFn = "getVariable";
    public const string GetDocumentVariableFn = "getDocumentVariable";
    public const string LookupVariableFn = "lookupVariable";
    public const string SetPropertyFn = "setProperty";
    public const string GetPropertyFn = "getProperty";
    
    public CssStyleJsModule(IJSRuntime js) : base(js, "css-style.js") { }
    
    public async ValueTask SetVariable(ElementReference element, string name, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(SetVariableFn, element, name, value);
    }
    
    public async ValueTask SetDocumentVariable(string name, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(SetDocumentVariableFn, name, value);
    }
    
    public async ValueTask<string> GetVariable(ElementReference element, string name)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(GetVariableFn, element, name);
    }
    
    public async ValueTask<string> GetDocumentVariable(string name)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(GetDocumentVariableFn, name);
    }
    
    public async ValueTask<string> LookupVariable(ElementReference element, string name)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(LookupVariableFn, element, name);
    }
    
    public async ValueTask SetProperty(ElementReference element, string name, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(SetPropertyFn, element, name, value);
    }
    
    public async ValueTask<string> GetProperty(ElementReference element, string name)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(GetPropertyFn, element, name);
    }
}