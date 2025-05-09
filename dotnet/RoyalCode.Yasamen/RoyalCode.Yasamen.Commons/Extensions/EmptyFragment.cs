using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.AspNetCore.Components;

public static class EmptyFragment
{
    public static readonly RenderFragment Delegate = EmptyRenderFragment;

    public static RenderFragment<TModel> GetDelegate<TModel>() => TypedEmptyFragment<TModel>.TypedDelegate;

    private static void EmptyRenderFragment(RenderTreeBuilder builder) { /* Empty Render Fragment */ }

    public static bool IsNotEmptyFragment(this RenderFragment? fragment)
    {
        return fragment is not null && !ReferenceEquals(fragment, Delegate);
    }
    
    public static bool IsNotEmptyFragment<T>(this RenderFragment<T>? fragment)
    {
        return fragment is not null && !ReferenceEquals(fragment, TypedEmptyFragment<T>.TypedDelegate);
    }

    /// <summary>
    /// Checks that the value is present, it must not be null or blank.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsPresent([NotNullWhen(true)] this string? s) => !string.IsNullOrWhiteSpace(s);

    /// <summary>
    /// Checks if the value is missing, null or blank.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsMissing([NotNullWhen(false)] this string? s) => string.IsNullOrWhiteSpace(s);

    private static class TypedEmptyFragment<T>
    {
        public static readonly RenderFragment<T> TypedDelegate = TypedEmptyRenderFragment;

        public static RenderFragment TypedEmptyRenderFragment<TModel>(TModel model) => Delegate;
    }
}