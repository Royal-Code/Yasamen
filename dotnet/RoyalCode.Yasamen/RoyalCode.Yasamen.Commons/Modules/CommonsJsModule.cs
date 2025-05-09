using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace RoyalCode.Yasamen.Commons.Modules;

public sealed class CommonsJsModule : JsModuleBase
{
    private const string getPropertyFn = "getProperty";
    private const string setPropertyFn = "setProperty";
    private const string readPropertyFn = "readProperty";
    private const string callMethodFn = "callMethod";
    private const string setLocalStorageItem = "setLocalStorageItem";
    private const string getLocalStorageItem = "getLocalStorageItem";
    private const string removeLocalStorageItem = "removeLocalStorageItem";
    private const string setSessionStorageItem = "setSessionStorageItem";
    private const string getSessionStorageItem = "getSessionStorageItem";
    private const string removeSessionStorageItem = "removeSessionStorageItem";

    // do not use this field, use the property Options
    private JsonSerializerOptions __jsonSerializerOptions = null!;

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

    #region Element properties ( get and set )

    /// <summary>
    /// Get the value of a property of an element.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="element">The element reference.</param>
    /// <param name="property">The name of the property.</param>
    /// <returns>The value of the property.</returns>
    public async ValueTask<T> GetPropertyAsync<T>(ElementReference element, string property)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(getPropertyFn, element, property);
    }

    /// <summary>
    /// Get the value of a property of an element.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="element">The element reference.</param>
    /// <param name="property">The name of the property.</param>
    /// <returns>The value of the property.</returns>
    public static async ValueTask<T> GetPropertyAsync<T>(IJSRuntime js, ElementReference element, string property)
    {
        return await js.InvokeAsync<T>(getPropertyFn, element, property);
    }

    /// <summary>
    /// Set the value of a property of an element.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="element">The element reference.</param>
    /// <param name="property">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async ValueTask SetPropertyAsync(ElementReference element, string property, object value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setPropertyFn, element, property, value);
    }

    /// <summary>
    /// Set the value of a property of an element.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="element">The element reference.</param>
    /// <param name="property">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async ValueTask SetPropertyAsync(IJSRuntime js, ElementReference element, string property, object value)
    {
        await js.InvokeVoidAsync(setPropertyFn, element, property, value);
    }

    #endregion

    #region JS properties and functions

    public async ValueTask<T> ReadPropertyAsync<T>(string path)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(readPropertyFn, path);
    }

    public static async ValueTask<T> ReadPropertyAsync<T>(IJSRuntime js, string path)
    {
        return await js.InvokeAsync<T>(readPropertyFn, path);
    }

    public async ValueTask<T> CallMethodAsync<T>(ElementReference element, string method, params object[]? arguments)
    {
        var js = await GetModuleAsync();

        if (arguments is null || arguments.Length is 0)
            return await js.InvokeAsync<T>(callMethodFn, method);

        return await js.InvokeAsync<T>(callMethodFn, args: ReOrgArgs(element, method, 0, arguments));
    }

    public static async ValueTask<T> CallMethodAsync<T>(IJSRuntime js, ElementReference element, string method, params object[]? arguments)
    {
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

    public static async ValueTask CallMethodWithSetTimeoutAsync(IJSRuntime js, ElementReference element, string method, int timeout, params object[]? arguments)
    {
        if (arguments is null || arguments.Length is 0)
            await js.InvokeVoidAsync(callMethodFn, method, timeout);
        else
            await js.InvokeVoidAsync(callMethodFn, args: ReOrgArgs(element, method, timeout, arguments));
    }

    #endregion

    #region local storage

    public async ValueTask SetLocalStorageItem(string key, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setLocalStorageItem, key, value);
    }

    public ValueTask SetLocalStorageItem<T>(T value, string? key = null)
    {
        // serialize value to json
        var jsonValue = JsonSerializer.Serialize<T>(value, Options);

        // check key name
        key ??= typeof(T).Name;

        return SetLocalStorageItem(key, jsonValue);
    }

    public async ValueTask<string> GetLocalStorageItem(string key)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(getLocalStorageItem, key);
    }

    public async ValueTask<T> GetLocalStorageItem<T>(string? key = null)
    {
        // check key name
        key ??= typeof(T).Name;

        var jsonValue = await GetLocalStorageItem(key);

        // deserialize from json
        return JsonSerializer.Deserialize<T>(jsonValue, Options)!;
    }

    public async ValueTask RemoveLocalStorageItem(string key)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(removeLocalStorageItem, key);
    }

    public ValueTask RemoveLocalStorageItem<T>()
    {
        return RemoveLocalStorageItem(typeof(T).Name);
    }

    #endregion

    #region session storage

    public async ValueTask SetSessionStorageItem(string key, string value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setSessionStorageItem, key, value);
    }

    public ValueTask SetSessionStorageItem<T>(T value, string? key = null)
    {
        // serialize value to json
        var jsonValue = JsonSerializer.Serialize<T>(value, Options);

        // check key name
        key ??= typeof(T).Name;

        return SetSessionStorageItem(key, jsonValue);
    }

    public async ValueTask<string> GetSessionStorageItem(string key)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<string>(getSessionStorageItem, key);
    }

    public async ValueTask<T> GetSessionStorageItem<T>(string? key = null)
    {
        // check key name
        key ??= typeof(T).Name;

        var jsonValue = await GetSessionStorageItem(key);

        // deserialize from json
        return JsonSerializer.Deserialize<T>(jsonValue, Options)!;
    }

    public async ValueTask RemoveSessionStorageItem(string key)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(removeSessionStorageItem, key);
    }

    public ValueTask RemoveSessionStorageItem<T>()
    {
        return RemoveSessionStorageItem(typeof(T).Name);
    }

    #endregion

    private static object[] ReOrgArgs(ElementReference element, string method, int timeout, params object[] arguments)
    {
        var args = new object[arguments.Length + 3];

        args[0] = element;
        args[1] = method;
        args[2] = timeout;
        Array.Copy(arguments, 0, args, 3, arguments.Length);

        return args;
    }
}