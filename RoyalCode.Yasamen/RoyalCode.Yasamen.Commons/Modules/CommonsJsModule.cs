using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Yasamen.Commons.Modules;

public class CommonsJsModule : JsModuleBase
{
    private const string getPropertyFn = "getProperty";
    private const string setPropertyFn = "setProperty";
    private const string readPropertyFn = "readProperty";
    private const string callMethodFn = "callMethod";

    public CommonsJsModule(IJSRuntime js) : base(js, "commons.js") { }

    public async ValueTask<T> GetPropertyAsync<T>(ElementReference element, string property)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(getPropertyFn, element, property);
    }

    public async ValueTask SetPropertyAsync<T>(ElementReference element, string property, object value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setPropertyFn, element, property, value);
    }

    public async ValueTask<T> ReadPropertyAsync<T>(string path)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(readPropertyFn, path);
    }

    public async ValueTask<T> CallMethodAsync<T>(ElementReference element, string method, params object[]? arguments)
    {
        var js = await GetModuleAsync();
        
        if (arguments is null || arguments.Length is 0)
            return await js.InvokeAsync<T>(callMethodFn, method);

        return await js.InvokeAsync<T>(callMethodFn, args: ReOrgArgs(element, method, 0, arguments));
    }

    public ValueTask CallMethodWithSetTimeoutAsync(ElementReference element, string method, params object[] arguments)
    {
        return CallMethodWithSetTimeoutAsync(element, method, 0, arguments);
    }
    
    public async ValueTask CallMethodWithSetTimeoutAsync(ElementReference element, string method, int timeout, params object[]? arguments)
    {
        var js = await GetModuleAsync();
        
        if (arguments is null || arguments.Length is 0)
            await js.InvokeVoidAsync(callMethodFn, method, timeout);
        else
            await js.InvokeVoidAsync(callMethodFn, args: ReOrgArgs(element, method, timeout, arguments));
    }

    private object[] ReOrgArgs(ElementReference element, string method, int timeout, params object[] arguments)
    {
        var args = new object[arguments.Length + 3];
        
        args[0] = element;
        args[1] = method;
        args[2] = timeout;
        Array.Copy(arguments, 0, args, 3, arguments.Length);

        return args;
    }
}