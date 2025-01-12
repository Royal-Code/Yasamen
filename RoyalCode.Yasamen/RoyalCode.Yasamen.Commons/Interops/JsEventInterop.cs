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
    public const string EventRegisterListener = "register";
    public const string EventUnregisterListener = "unregister";

    private readonly IJSObjectReference js;
    private DotNetObjectReference<JsEventInterop<TData>>? handleReference;
    
    private ElementReference? element;
    private string? eventName;
    private JsEventListenerOptions? options;
    private Action<TData?>? eventHandler;
    private Func<TData?, ValueTask>? eventHandlerAsync;

    internal JsEventInterop(IJSObjectReference js)
    {
        this.js = js;
    }

    public bool ElementHasChanged(ElementReference element)
    {
        return element.Id != this.element?.Id;
    }

    public async ValueTask UpdateElement(ElementReference element)
    {
        await Unregister();
        this.element = element;
        await Register();
    }

    internal ValueTask AddListener(
        ElementReference element,
        string eventName,
        JsEventListenerOptions options,
        Action<TData?> eventHandler)
    {
        this.element = element;
        this.eventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
        this.options = options ?? throw new ArgumentNullException(nameof(options));
        this.eventHandler = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));

        handleReference = DotNetObjectReference.Create(this);

        return Register();
    }

    internal ValueTask AddListener(
        ElementReference element,
        string eventName,
        JsEventListenerOptions options,
        Func<TData?, ValueTask> eventHandlerAsync)
    {
        this.element = element;
        this.eventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
        this.options = options ?? throw new ArgumentNullException(nameof(options));
        this.eventHandlerAsync = eventHandlerAsync ?? throw new ArgumentNullException(nameof(eventHandlerAsync));

        handleReference = DotNetObjectReference.Create(this);

        return Register();
    }

    private ValueTask Register()
    {
        if (!element.HasValue || string.IsNullOrEmpty(element.Value.Id) || options is null)
            return ValueTask.CompletedTask;

        var requiredProperties = string.Join(',', typeof(TData).GetTypeInfo()
            .GetRuntimeProperties()
            .Where(p => p.CanWrite)
            .Select(p => p.Name.ToCamelCase()));
        
        return js.InvokeVoidAsync(EventRegisterListener, element, eventName,
            options.OnlyTarget, options.PreventDefault, options.StopPropagation,
            requiredProperties,
            handleReference);
    }

    private ValueTask Unregister()
    {
        if (!element.HasValue || string.IsNullOrEmpty(element.Value.Id))
            return ValueTask.CompletedTask;

        return js.InvokeVoidAsync(EventUnregisterListener, element.Value);
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

        if (eventHandler is not null)
            eventHandler(dataObject);
        if (eventHandlerAsync is not null)
            eventHandlerAsync(dataObject).GetAwaiter().GetResult();

        return null;
    }

    [JSInvokable]
    public async Task<string?> OnEventFiredAsync(string jsonData)
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

        if (eventHandler is not null)
            eventHandler!(dataObject);
        if (eventHandlerAsync is not null)
            await eventHandlerAsync(dataObject);
        
        return null;
    }

    public async ValueTask DisposeAsync()
    {
        if (handleReference is not null)
        {
            await Unregister();
            handleReference?.Dispose();

            handleReference = null;
            eventHandler = null;
            eventHandlerAsync = null;
            element = null;
        }
    }
}
