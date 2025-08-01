using Microsoft.AspNetCore.Components.Rendering;

namespace Microsoft.AspNetCore.Components;

/// <summary>
/// Provides utility methods and delegates for working with empty 
/// <see cref="RenderFragment"/> and <see cref="RenderFragment{T}"/> instances, as well as string presence checks.
/// </summary>
public static class EmptyFragment
{
    /// <summary>
    /// A reusable empty <see cref="RenderFragment"/> delegate.
    /// </summary>
    public static readonly RenderFragment Delegate = EmptyRenderFragment;

    /// <summary>
    /// Gets a reusable empty <see cref="RenderFragment{TModel}"/> delegate for the specified type.
    /// </summary>
    /// <typeparam name="TModel">The type of the model parameter.</typeparam>
    /// <returns>An empty <see cref="RenderFragment{TModel}"/> delegate.</returns>
    public static RenderFragment<TModel> GetDelegate<TModel>() => TypedEmptyFragment<TModel>.TypedDelegate;

    /// <summary>
    /// An empty <see cref="RenderFragment"/> implementation.
    /// </summary>
    /// <param name="builder">The <see cref="RenderTreeBuilder"/> instance.</param>
    private static void EmptyRenderFragment(RenderTreeBuilder builder) { /* Empty Render Fragment */ }

    /// <summary>
    /// Determines whether the specified <see cref="RenderFragment"/> is not empty.
    /// </summary>
    /// <param name="fragment">The fragment to check.</param>
    /// <returns>
    ///     <c>true</c> if the fragment is not null and not the empty delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotEmptyFragment(this RenderFragment? fragment)
    {
        return fragment is not null && !ReferenceEquals(fragment, Delegate);
    }

    /// <summary>
    /// Determines whether the specified <see cref="RenderFragment{T}"/> is not empty.
    /// </summary>
    /// <typeparam name="T">The type of the model parameter.</typeparam>
    /// <param name="fragment">The fragment to check.</param>
    /// <returns>
    ///     <c>true</c> if the fragment is not null and not the empty delegate; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotEmptyFragment<T>(this RenderFragment<T>? fragment)
    {
        return fragment is not null && !ReferenceEquals(fragment, TypedEmptyFragment<T>.TypedDelegate);
    }

    /// <summary>
    /// Provides a typed empty <see cref="RenderFragment{T}"/> delegate.
    /// </summary>
    /// <typeparam name="T">The type of the model parameter.</typeparam>
    private static class TypedEmptyFragment<T>
    {
        /// <summary>
        /// A reusable empty <see cref="RenderFragment{T}"/> delegate.
        /// </summary>
        public static readonly RenderFragment<T> TypedDelegate = TypedEmptyRenderFragment;

        /// <summary>
        /// An empty <see cref="RenderFragment{TModel}"/> implementation.
        /// </summary>
        /// <typeparam name="TModel">The type of the model parameter.</typeparam>
        /// <param name="model">The model instance.</param>
        /// <returns>An empty <see cref="RenderFragment"/>.</returns>
        public static RenderFragment TypedEmptyRenderFragment<TModel>(TModel model) => Delegate;
    }
}