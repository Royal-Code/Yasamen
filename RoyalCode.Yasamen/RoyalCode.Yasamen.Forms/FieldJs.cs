
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Forms.Modules;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     This class is responsible for the communication between the Blazor application and the JavaScript code.
/// </para>
/// </summary>
public class FieldJs
{
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
}
