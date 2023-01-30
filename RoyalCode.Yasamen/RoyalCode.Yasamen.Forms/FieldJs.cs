
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Forms.Modules;

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
}
