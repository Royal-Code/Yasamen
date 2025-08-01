using System.Text;

namespace RoyalCode.Razor.Styles;

/// <summary>
/// Structure for creating CSS classes.
/// </summary>
public struct CssClasses
{
    /// <summary>
    /// Implement the implicit conversion operator for strings.
    /// </summary>
    /// <param name="cssClasses"></param>
    public static implicit operator string(CssClasses cssClasses)
    {
        return cssClasses.ToString();
    }

    // fields 
    private string? first;
    private StringBuilder? builder;

    /// <summary>
    /// Creates a new instance of <see cref="CssClasses"/>.
    /// </summary>
    /// <param name="first"></param>
    public CssClasses(string? first)
    {
        this.first = first;
    }

    /// <summary>
    /// Adds a class to the class string if the other value is present.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public CssClasses AddClass(string? other)
    {
        if (other.IsPresent())
        {
            if (first is null)
            {
                first = other;
            }
            else if (builder is null)
            {
                builder = new StringBuilder(first).Append(' ').Append(other);
            }
            else
            {
                builder.Append(' ').Append(other);
            }
        }

        return this;
    }

    /// <summary>
    /// Adds a class if the condition is met and the other value is present.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public CssClasses AddClass(bool condition, string? other)
    {
        return condition
            ? AddClass(other)
            : this;
    }

    /// <summary>
    /// Adds one of two classes based on the condition.
    /// </summary>
    /// <param name="condition">Condition</param>
    /// <param name="otherWhenTrue">Class to use when the condition is met.</param>
    /// <param name="otherWhenFalse">Class to use when the condition is not met.</param>
    /// <returns></returns>
    public CssClasses AddClass(bool condition, string? otherWhenTrue, string? otherWhenFalse)
    {
        return condition
            ? AddClass(otherWhenTrue)
            : AddClass(otherWhenFalse);
    }

    /// <summary>
    /// Adds a class from a function if the value is present.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="function"></param>
    /// <returns></returns>
    public CssClasses AddClass<T>(T? value, Func<T, string?> function)
    {
        if (value is not null)
        {
            return AddClass(function(value));
        }
        return this;
    }

    /// <summary>
    /// Adds a class from a function if the values value1 and value2 are present.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="function"></param>
    /// <returns></returns>
    public CssClasses AddClass<T1, T2>(T1? value1, T2? value2, Func<T1, T2, string?> function)
    {
        if (value1 is not null && value2 is not null)
        {
            return AddClass(function(value1, value2));
        }
        return this;
    }

    /// <summary>
    /// Gets the string that represents the classes.
    /// </summary>
    /// <returns></returns>
    public override readonly string ToString()
    {
        return builder?.ToString() ?? first ?? string.Empty;
    }
}