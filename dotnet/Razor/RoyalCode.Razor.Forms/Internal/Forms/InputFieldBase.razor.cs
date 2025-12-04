using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Components;

namespace RoyalCode.Razor.Internal.Forms;

/// <summary>
/// Base component for input fields.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public partial class InputFieldBase<TValue> : FieldBase<TValue>
{
    /// <summary>
    /// Defines the type of input control to render.
    /// </summary>
    [Parameter]
    public InputType Type { get; set; }

    /// <summary>
    /// Sets the maximum size for the text.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Gets or sets the name of the DOM event that triggers value binding for the component.
    /// </summary>
    /// <remarks>
    ///     The default value is "onchange". Set this property to specify a different event, such as
    ///     "oninput", to control when the component updates its bound value in response to user interaction.
    /// </remarks>
    [Parameter]
    public string BindEvent { get; set; } = "onchange";
}
