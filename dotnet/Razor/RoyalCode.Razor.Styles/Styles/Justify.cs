namespace RoyalCode.Razor.Styles;

/// <summary>
/// <para>
///     Values for justify content inside a container.
/// </para>
/// <para>
///     justify-start => justify-content: flex-start; <br />
///     justify-end => justify-content: flex-end; <br />
///     justify-end-safe => justify-content: safe flex-end; <br />
///     justify-center  => justify-content: center; <br />
///     justify-center-safe => justify-content: safe center; <br />
///     justify-between => justify-content: space-between; <br />
///     justify-around => justify-content: space-around; <br />
///     justify-evenly => justify-content: space-evenly; <br />
///     justify-stretch => justify-content: stretch; <br />
///     justify-baseline => justify-content: baseline; <br />
///     justify-normal => justify-content: normal; <br />
/// </para>
/// </summary>
public enum ContentJustify
{
    Default,
    Start,
    End,
    EndSafe,
    Center,
    CenterSafe,
    Between,
    Around,
    Evenly,
    Stretch,
    Baseline,
    Normal
}

/// <summary>
/// <para>
///     Values for justify items inside a container.
/// </para>
/// <para>
///     justify-items-start => justify-items: start; <br />
///     justify-items-end => justify-items: end; <br />
///     justify-items-end-safe => justify-items: safe end; <br />
///     justify-items-center => justify-items: center; <br />
///     justify-items-center-safe => justify-items: safe center; <br />
///     justify-items-stretch => justify-items: stretch; <br />
///     justify-items-normal => justify-items: normal; <br />
/// </para>
/// </summary>
public enum ItemsJustify
{
    Default,
    Start,
    End,
    EndSafe,
    Center,
    CenterSafe,
    Stretch,
    Normal
}

/// <summary>
/// <para>
///     Values for self justify items inside a container.
/// </para>
/// <para>
///     justify-self-auto => justify-self: auto; <br />
///     justify-self-start => justify-self: start; <br />
///     justify-self-center => justify-self: center; <br />
///     justify-self-center-safe => justify-self: safe center; <br />
///     justify-self-end => justify-self: end; <br />
///     justify-self-end-safe => justify-self: safe end; <br />
///     justify-self-stretch => justify-self: stretch; <br />
/// </para>
/// </summary>
public enum SelfJustify
{
    Default,
    Auto,
    Start,
    Center,
    CenterSafe,
    End,
    EndSafe,
    Stretch
}

/// <summary>
/// <para>
///     Values for text justification (align).
/// </para>
/// <para>
///     text-left => text-align: left; <br />
///     text-center => text-align: center; <br />
///     text-right => text-align: right; <br />
///     text-justify => text-align: justify; <br />
///     text-start => text-align: start; <br />
///     text-end => text-align: end; <br />
/// </para>
/// </summary>
public enum TextJustify
{
    Default,
    Left,
    Center,
    Right,
    Justify,
    Start,
    End
}

public static class JustifyExtensions
{
    public static string ToCssClass(this ContentJustify justify)
    {
        return justify switch
        {
            ContentJustify.Default => string.Empty,
            ContentJustify.Start => "justify-start",
            ContentJustify.End => "justify-end",
            ContentJustify.EndSafe => "justify-end-safe",
            ContentJustify.Center => "justify-center",
            ContentJustify.CenterSafe => "justify-center-safe",
            ContentJustify.Between => "justify-between",
            ContentJustify.Around => "justify-around",
            ContentJustify.Evenly => "justify-evenly",
            ContentJustify.Stretch => "justify-stretch",
            ContentJustify.Baseline => "justify-baseline",
            ContentJustify.Normal => "justify-normal",
            _ => throw new NotSupportedException($"The current justify ({justify}) is not supported for content justification.")
        };
    }

    public static string ToCssClass(this ItemsJustify justify)
    {
        return justify switch
        {
            ItemsJustify.Default => string.Empty,
            ItemsJustify.Start => "justify-items-start",
            ItemsJustify.End => "justify-items-end",
            ItemsJustify.EndSafe => "justify-items-end-safe",
            ItemsJustify.Center => "justify-items-center",
            ItemsJustify.CenterSafe => "justify-items-center-safe",
            ItemsJustify.Stretch => "justify-items-stretch",
            ItemsJustify.Normal => "justify-items-normal",
            _ => throw new NotSupportedException($"The current justify ({justify}) is not supported for items justification.")
        };
    }

    public static string ToCssClass(this SelfJustify justify)
    {
        return justify switch
        {
            SelfJustify.Default => string.Empty,
            SelfJustify.Auto => "justify-self-auto",
            SelfJustify.Start => "justify-self-start",
            SelfJustify.Center => "justify-self-center",
            SelfJustify.CenterSafe => "justify-self-center-safe",
            SelfJustify.End => "justify-self-end",
            SelfJustify.EndSafe => "justify-self-end-safe",
            SelfJustify.Stretch => "justify-self-stretch",
            _ => throw new NotSupportedException($"The current justify ({justify}) is not supported for self justification.")
        };
    }

    public static string ToCssClass(this TextJustify justify)
    {
        return justify switch
        {
            TextJustify.Default => string.Empty,
            TextJustify.Left => "text-left",
            TextJustify.Center => "text-center",
            TextJustify.Right => "text-right",
            TextJustify.Justify => "text-justify",
            TextJustify.Start => "text-start",
            TextJustify.End => "text-end",
            _ => throw new NotSupportedException($"The current justify ({justify}) is not supported for text justification.")
        };
    }
}