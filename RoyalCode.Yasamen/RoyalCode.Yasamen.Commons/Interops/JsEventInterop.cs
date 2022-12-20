using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using RoyalCode.Yasamen.Commons.Modules;
using System.Reflection;
using RoyalCode.Yasamen.Commons.Extensions;

namespace RoyalCode.Yasamen.Commons.Interops;

/// <summary>
/// <para>
///     Interop to listen for events via the <see cref="EventsJsModule"/>.
/// </para>
/// </summary>
/// <typeparam name="TData">The event data time.</typeparam>
public class JsEventInterop<TData> : IAsyncDisposable
{
    /* events.js */
    public static readonly string EventRegisterListener = "register";
    public static readonly string EventUnregisterListener = "unregister";

    private readonly IJSObjectReference js;
    private DotNetObjectReference<JsEventInterop<TData>>? handleReference;
    private Action<TData?>? eventHandler;
    private ElementReference? element;

    internal JsEventInterop(IJSObjectReference js)
    {
        this.js = js;
    }
    
    internal ValueTask AddListener(
        ElementReference element,
        string eventName,
        JsEventListenerOptions options,
        Action<TData?> eventHandler)
    {
        if (eventName is null)
            throw new ArgumentNullException(nameof(eventName));

        this.eventHandler = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));
        this.element = element;

        handleReference = DotNetObjectReference.Create(this);

        var requiredProperties = string.Join(',', typeof(TData).GetTypeInfo()
            .GetRuntimeProperties()
            .Where(p => p.CanWrite)
            .Select(p => p.Name.ToCamelCase()));

        return js.InvokeVoidAsync(EventRegisterListener, element, eventName,
            options.OnlyTarget, options.PreventDefault, options.StopPropagation,
            requiredProperties,
            handleReference);
    }

    [JSInvokable]
    public string? OnEventFired(string jsonData)
    {
        TData? dataObject;
        try
        {
            dataObject = JsonSerializer.Deserialize<TData>(jsonData, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
        }
        catch (Exception ex)
        {
            return $"Error on deserialize event json data to type {typeof(TData).FullName}."
                + $"\nThe json data is '{jsonData}'."
                + $"\nCause: {ex.Message}"
                + $"\nStack: {ex.StackTrace}";
        }

        // eventHandler is not null because this method will only be called if a listener has already been added.
        eventHandler!(dataObject);
        return null;
    }

    public async ValueTask DisposeAsync()
    {
        if (handleReference is not null)
        {
            await js.InvokeVoidAsync(EventUnregisterListener, element);
            handleReference?.Dispose();

            handleReference = null;
            eventHandler = null;
            element = null;
        }
    }
}
