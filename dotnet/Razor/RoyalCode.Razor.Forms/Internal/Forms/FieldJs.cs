using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Commons.Modules;
using RoyalCode.Razor.Styles;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Internal.Forms;

/// <summary>
/// <para>
///     This class is responsible for the communication between the Blazor application and the JavaScript code.
/// </para>
/// </summary>
public class FieldJs : IAsyncDisposable
{
    /// <summary>
    /// The module responsible for the communication between the Blazor application and the JavaScript code.
    /// </summary>
    public FormsJs? Module { get; internal set; }

    /// <summary>
    /// The reference to the element in the DOM.
    /// </summary>
    public ElementReference Element { get; internal set; }

    [MemberNotNullWhen(true, nameof(Element), nameof(Module))]
    private bool IsInitialized()
    {
        return Element.Id.IsPresent() && Module is not null;
    }

    /// <summary>
    /// Sets the focus on the element.
    /// </summary>
    /// <returns></returns>
    public ValueTask SetFocusAsync()
    {
        if(!IsInitialized())
            return default;

        return Element.FocusAsync();
    }

    /// <summary>
    /// Applies the blur effect to the element.
    /// </summary>
    /// <returns></returns>
    public ValueTask BlurAsync()
    {
        if (!IsInitialized())
            return default;

        return Module.BlurAsync(Element);
    }

    /// <summary>
    /// Applies the blur effect when the Enter key is pressed.
    /// </summary>
    /// <returns></returns>
    public ValueTask BlurOnPressEnterAsync()
    {
        if(!IsInitialized())
            return default;

        return Module.BlurOnPressEnterAsync(Element);
    }

    /// <summary>
    /// Selects the text in the input.
    /// </summary>
    /// <returns></returns>
    public ValueTask SelectTextAsync()
    {
        if(!IsInitialized())
            return default;

        return Module.SelectTextAsync(Element);
    }

    /// <inheritdoc />
    public ValueTask DisposeAsync() => default;
}
