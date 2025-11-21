using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RoyalCode.Razor.Commons.Modules;

/// <summary>
/// JavaScript module wrapper for DOM element operations such as getting/setting properties,
/// invoking methods, obtaining bounding rectangles and selecting text.
/// </summary>
public class ElementJs : JsModuleBase
{
    private const string getPropertyFn = "getProperty";
    private const string setPropertyFn = "setProperty";
    private const string invokeVoidMethodFn = "invokeVoidMethod";
    private const string invokeMethodFn = "invokeMethod";
    private const string getRectFn = "getRect";
    private const string selectTextFn = "selectText";

    /// <summary>
    /// Initializes a new instance of <see cref="ElementJs"/> bound to the specified <see cref="IJSRuntime"/>
    /// /// </summary>
    /// <param name="js">The JavaScript runtime used to load and invoke the underlying module.</param>
    public ElementJs(IJSRuntime js) : base(js, "element.js") { }

    /// <summary>
    /// Gets the value of a DOM element property.
    /// </summary>
    /// <typeparam name="T">The expected CLR type of the property value.</typeparam>
    /// <param name="element">The element reference whose property will be read.</param>
    /// <param name="propertyName">The name of the property to read (case-sensitive in JS context).</param>
    /// <returns>The property value converted to <typeparamref name="T"/>.</returns>
    public async ValueTask<T> GetPropertyAsync<T>(ElementReference element, string propertyName)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(getPropertyFn, element, propertyName);
    }

    /// <summary>
    /// Sets the value of a DOM element property.
    /// </summary>
    /// <typeparam name="T">The CLR type of the value being assigned.</typeparam>
    /// <param name="element">The element reference whose property will be set.</param>
    /// <param name="propertyName">The name of the property to set.</param>
    /// <param name="value">The value to assign to the property.</param>
    public async ValueTask SetPropertyAsync<T>(ElementReference element, string propertyName, T value)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(setPropertyFn, element, propertyName, value);
    }

    /// <summary>
    /// Invokes a void (no return) method on the underlying DOM element.
    /// </summary>
    /// <param name="element">The target element reference.</param>
    /// <param name="methodName">The JavaScript method name to invoke on the element.</param>
    /// <param name="args">Optional arguments passed to the method.</param>
    public async ValueTask InvokeVoidMethodAsync(ElementReference element, string methodName, params object[] args)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(invokeVoidMethodFn, element, methodName, args);
    }

    /// <summary>
    /// Invokes a method on the underlying DOM element and returns a typed result.
    /// The properties to read from the JavaScript object are inferred from <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The expected CLR type of the result.</typeparam>
    /// <param name="element">The target element reference.</param>
    /// <param name="methodName">The JavaScript method name to invoke on the element.</param>
    /// <param name="args">Optional arguments passed to the method.</param>
    /// <returns>The result converted to <typeparamref name="T"/>.</returns>
    public async ValueTask<T> InvokeMethodAsync<T>(ElementReference element, string methodName, params object[] args)
    {
        var js = await GetModuleAsync();
        string[] readProperties = ReadProperties.Get<T>();
        return await js.InvokeAsync<T>(invokeMethodFn, element, methodName, readProperties, args);
    }

    /// <summary>
    /// Invokes a method on the underlying DOM element and returns a typed result,
    /// using an explicit set of property names to read from the returned JavaScript object.
    /// </summary>
    /// <typeparam name="T">The expected CLR type of the result.</typeparam>
    /// <param name="element">The target element reference.</param>
    /// <param name="methodName">The JavaScript method name to invoke on the element.</param>
    /// <param name="readProperties">The list of property names (JS casing) to extract for building <typeparamref name="T"/>.</param>
    /// <param name="args">Optional arguments passed to the method.</param>
    /// <returns>The result converted to <typeparamref name="T"/>.</returns>
    public async ValueTask<T> InvokeMethodAsync<T>(ElementReference element, string methodName, string[] readProperties, params object[] args)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<T>(invokeMethodFn, element, methodName, readProperties, args);
    }

    /// <summary>
    /// Gets the bounding client rectangle of the element.
    /// </summary>
    /// <param name="element">The element reference.</param>
    /// <returns>A <see cref="DomRect"/> describing the position and size.</returns>
    public async ValueTask<DomRect> GetRectAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        return await js.InvokeAsync<DomRect>(getRectFn, element);
    }

    /// <summary>
    /// Selects all text content within the element (e.g., for an input or text container).
    /// </summary>
    /// <param name="element">The element reference whose text content will be selected.</param>
    public async ValueTask SelectTextAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync(selectTextFn, element);
    }

    /// <summary>
    /// Represents the size and position of a rectangle, typically corresponding to a bounding box in a coordinate space
    /// such as the DOM or a graphical interface.
    /// </summary>
    /// <remarks>This record is commonly used to represent the bounding rectangle of elements in graphical or
    /// web-based coordinate systems, such as those returned by DOM APIs. All coordinates are typically expressed in the
    /// same coordinate space.</remarks>
    /// <param name="X">The x-coordinate of the rectangle's origin, usually representing the left edge.</param>
    /// <param name="Y">The y-coordinate of the rectangle's origin, usually representing the top edge.</param>
    /// <param name="Width">The width of the rectangle, in coordinate units. Must be non-negative.</param>
    /// <param name="Height">The height of the rectangle, in coordinate units. Must be non-negative.</param>
    /// <param name="Top">The y-coordinate of the top edge of the rectangle.</param>
    /// <param name="Right">The x-coordinate of the right edge of the rectangle.</param>
    /// <param name="Bottom">The y-coordinate of the bottom edge of the rectangle.</param>
    /// <param name="Left">The x-coordinate of the left edge of the rectangle.</param>
    public record DomRect(double X, double Y, double Width, double Height, double Top, double Right, double Bottom, double Left);

    private static class ReadProperties
    {
        private static readonly Dictionary<Type, string[]> cache = new();

        /// <summary>
        /// Gets the list of JSON property names for the public instance properties of <typeparamref name="T"/>.
        /// Uses <see cref="JsonPropertyNameAttribute"/> if present; otherwise camelCase conversion.
        /// </summary>
        /// <typeparam name="T">The type whose properties will be inspected.</typeparam>
        /// <returns>An array of JSON property names.</returns>
        public static string[] Get<T>()
        {
            var type = typeof(T);
            if (!cache.TryGetValue(type, out var properties))
            {
                properties = type
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p =>
                    {
                        var attr = p.GetCustomAttribute<JsonPropertyNameAttribute>();
                        return attr?.Name ?? JsonNamingPolicy.CamelCase.ConvertName(p.Name);
                    })
                    .ToArray();
                cache[type] = properties;
            }
            return properties;
        }
    }
}
