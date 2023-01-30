using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace RoyalCode.Yasamen.Commons.Modules;

public class CommonsJsModule : JsModuleBase
{
    private const string getPropertyFn = "getProperty";
    private const string setPropertyFn = "setProperty";
    private const string readPropertyFn = "readProperty";
    private const string callMethodFn = "callMethod";
    private const string setLocalStorageItem = "setLocalStorageItem";
    private const string getLocalStorageItem = "getLocalStorageItem";

    private JsonSerializerOptions __jsonSerializerOptions;

    public CommonsJsModule(IJSRuntime js) : base(js, "commons.js") { }

    private JsonSerializerOptions Options
    {
        get
        {
            return __jsonSerializerOptions ??= new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                PropertyNameCaseInsensitive = true
            };
        }
    }

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

    public async ValueTask SetLocalStorageItem(string key, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setLocalStorageItem, key, value);
    }

    public async ValueTask<string> GetLocalStorageItem(string key)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(getLocalStorageItem, key);
    }

    public ValueTask SetLocalStorageItem<T>(T value, string? key = null)
    {
        // serialize value to json
        var jsonValue = JsonSerializer.Serialize<T>(value, Options);

        // check key name
        key ??= typeof(T).Name;

        return SetLocalStorageItem(key, jsonValue);
    }

    public async ValueTask<T> GetLocalStorageItem<T>(string? key = null)
    {
        // check key name
        key ??= typeof(T).Name;

        var jsonValue = await GetLocalStorageItem(key);

        // deserialize from json
        return JsonSerializer.Deserialize<T>(jsonValue, Options)!;
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