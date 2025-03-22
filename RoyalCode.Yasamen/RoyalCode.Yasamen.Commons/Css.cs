using RoyalCode.Yasamen.Commons.Internal;

namespace RoyalCode.Yasamen.Commons;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    /// <summary>
    /// <para>
    ///     Create a new instance of <see cref="ICssMapBuilder{TComponent}"/> for the specified component type.
    /// </para>
    /// <para>
    ///     The builder can create a <see cref="CssMap{TComponent}"/> with the CSS classes for the component.
    /// </para>
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <returns>The builder new instance.</returns>
    public static ICssMapBuilder<TComponent> Map<TComponent>() => new CssClassesBuilder<TComponent>();

    /// <summary>
    /// <para>
    ///     Creates a builder for utilities CSS classes.
    /// </summary>
    /// <returns>The builder new instance.</returns>
    public static ICssBuilder Utils() => new CssBuilder();

    /// <summary>
    /// <para>
    ///     Creates a builder for borders CSS classes.
    /// </para>
    /// </summary>
    /// <returns>The builder new instance.</returns>
    public static IBorderBuilder Border() => new BorderBuilder();
}
