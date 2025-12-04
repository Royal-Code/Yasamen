using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// Provides JavaScript interop helpers for form and input scenarios in Blazor.
/// Wraps a JS module (<c>forms.js</c>) to wire common behaviors such as blurring on Enter,
/// moving focus to the next input, reading and setting values, and selecting text.
/// </summary>
public class FormsJs : JsModuleBase
{
    private const string BlurOnPressEnterFn = "blurOnPressEnter";
    private const string BlurAndFocusNextFn = "blurAndFocusNext";

    private readonly ElementJs elementJs;

    /// <summary>
    /// Initializes a new instance of the <see cref="FormsJs"/> class.
    /// </summary>
    /// <param name="js">The <see cref="IJSRuntime"/> used to load and invoke the JS module.</param>
    /// <param name="elementJs">The helper used to get and set DOM element properties via JS interop.</param>
    public FormsJs(IJSRuntime js, ElementJs elementJs) : base(js, "forms.js")
    {
        this.elementJs = elementJs;
    }

    /// <summary>
    /// Attaches a behavior to the specified element that blurs the input when the Enter key is pressed.
    /// </summary>
    /// <param name="element">The <see cref="ElementReference"/> of the input or editable element.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public async ValueTask BlurOnPressEnterAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(BlurOnPressEnterFn, element);
    }

    /// <summary>
    /// Blurs the specified element and moves focus to the next focusable element.
    /// </summary>
    /// <param name="element">The <see cref="ElementReference"/> of the input or editable element.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public async ValueTask BlurAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(BlurAndFocusNextFn, element);
    }

    /// <summary>
    /// Gets the current value of the specified element's <c>value</c> property.
    /// </summary>
    /// <param name="element">The <see cref="ElementReference"/> of the input or editable element.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> whose result is the string value of the element.
    /// Returns an empty string if the value is <see langword="null"/>.
    /// </returns>
    public async ValueTask<string> GetValueAsync(ElementReference element)
    {
        return await elementJs.GetPropertyAsync<string>(element, "value");
    }

    /// <summary>
    /// Sets the specified element's <c>value</c> property.
    /// </summary>
    /// <param name="element">The <see cref="ElementReference"/> of the input or editable element.</param>
    /// <param name="value">The value to set. If <see langword="null"/>, an empty string is applied.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public async ValueTask SetValueAsync(ElementReference element, string? value)
    {
        await elementJs.SetPropertyAsync(element, "value", value ?? string.Empty);
    }

    /// <summary>
    /// Selects all text within the specified element (typically an input or textarea).
    /// </summary>
    /// <param name="element">The <see cref="ElementReference"/> of the input or textarea element.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public ValueTask SelectTextAsync(ElementReference element)
    {
        return elementJs.InvokeVoidMethodAsync(element, "select");
    }
}
