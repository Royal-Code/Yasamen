
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Modules;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

#pragma warning disable S3881 // "IDisposable" should be implemented correctly

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     This class is responsible for the communication between the Blazor application and the JavaScript code.
/// </para>
/// </summary>
public class FieldJs : IAsyncDisposable
{
    private DotNetObjectReference<FieldJs>? handleReference;
    private Func<int, ValueTask>? inputLengthHandlerAsync;

    public FormsJsModule? Module { get; internal set; }

    public ElementReference Element { get; internal set; }

    [MemberNotNullWhen(true, nameof(Element), nameof(Module))]
    private bool IsInitialized()
    {
        return !string.IsNullOrEmpty(Element.Id) && Module is not null;
    }
    
    public ValueTask SetFocusAsync()
    {
        if(!IsInitialized())
            return default;

        return Element.FocusAsync();
    }

    public ValueTask BlurOnPressEnterAsync()
    {
        if(!IsInitialized())
            return default;

        return Module.BlurOnPressEnterAsync(Element);
    }

    public ValueTask SelectTextAsync()
    {
        if(!IsInitialized())
            return default;

        return Module.SelectTextAsync(Element);
    }

    public async ValueTask ListenInputLengthChangesAsync(Func<int, ValueTask> inputLengthHandlerAsync)
    {
        if (!IsInitialized())
            return;

        handleReference ??= DotNetObjectReference.Create(this);
        this.inputLengthHandlerAsync = inputLengthHandlerAsync;

        await Module.RegisterInputLengthListenerAsync(Element, handleReference);
    }

    [JSInvokable]
    public async Task<string?> OnEventFiredAsync(string jsonData)
    {
        try
        {
            int len = JsonSerializer.Deserialize<int>(jsonData);
            Tracer.Write<FieldJs>("OnEventFiredAsync", len.ToString());

            if (inputLengthHandlerAsync is not null)
                await inputLengthHandlerAsync(len);

            return string.Empty;
        }
        catch (Exception ex)
        {
            return ex.Message + "\n" + ex.StackTrace;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!IsInitialized())
            return;

        inputLengthHandlerAsync = null;
        if (handleReference is not null)
        {
            await Module.UnregisterInputLengthListenerAsync(handleReference);
            handleReference.Dispose();
            handleReference = null;
        }
    }
}
