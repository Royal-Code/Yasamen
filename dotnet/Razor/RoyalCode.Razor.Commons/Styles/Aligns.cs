namespace RoyalCode.Razor.Commons.Styles;

/// <summary>
/// Values for align content inside a container.
/// </summary>
public enum ContentAlign
{
    Default,
    Start,
    Center,
    End,
    Between,
    Around,
    evenly,
    Baseline,
    Stretch
}

/// <summary>
/// Values for align items inside a container.
/// </summary>
public enum ItemAlign
{
    Default,
    Start,
    Center,
    CenterSafe,
    End,
    EndSafe,
    Baseline,
    BaselineLast,
    Stretch
}

public enum SelfAlign
{
    Default,
    Auto,
    Start,
    Center,
    CenterSafe,
    End,
    EndSafe,
    Baseline,
    BaselineLast,
    Stretch
}

public enum TextAlign
{
    Default,
    Baseline,
    Top,
    Middle,
    Bottom,
    TextTop,
    TextBottom,
    Sub,
    Super
}

public static class AlignExtensions
{
    public static string ToCssClass(this ContentAlign align)
    {
        return align switch
        {
            ContentAlign.Default => string.Empty,
            ContentAlign.Start => "content-center",
            ContentAlign.Center => "content-start",
            ContentAlign.End => "content-end",
            ContentAlign.Between => "content-between",
            ContentAlign.Around => "content-around",
            ContentAlign.evenly => "content-evenly",
            ContentAlign.Baseline => "content-baseline",
            ContentAlign.Stretch => "content-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for content alignment.")
        };
    }

    public static string ToCssClass(this ItemAlign align)
    {
        return align switch
        {
            ItemAlign.Default => string.Empty,
            ItemAlign.Start => "items-start",
            ItemAlign.Center => "items-center",
            ItemAlign.CenterSafe => "items-center-safe",
            ItemAlign.End => "items-end",
            ItemAlign.EndSafe => "items-end-safe",
            ItemAlign.Baseline => "items-baseline",
            ItemAlign.BaselineLast => "items-baseline-last",
            ItemAlign.Stretch => "items-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for items alignment.")
        };
    }

    public static string ToCssClass(this SelfAlign align)
    {
        return align switch
        {
            SelfAlign.Default => string.Empty,
            SelfAlign.Auto => "self-auto",
            SelfAlign.Start => "self-start",
            SelfAlign.Center => "self-center",
            SelfAlign.CenterSafe => "self-center-safe",
            SelfAlign.End => "self-end",
            SelfAlign.EndSafe => "self-end-safe",
            SelfAlign.Baseline => "self-baseline",
            SelfAlign.BaselineLast => "self-baseline-last",
            SelfAlign.Stretch => "self-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for self alignment.")
        };
    }

    public static string ToCssClass(this TextAlign align)
    {
        return align switch
        {
            TextAlign.Default => string.Empty,
            TextAlign.Baseline => "align-baseline",
            TextAlign.Top => "align-top",
            TextAlign.Middle => "align-middle",
            TextAlign.Bottom => "align-bottom",
            TextAlign.TextTop => "align-text-top",
            TextAlign.TextBottom => "align-text-bottom",
            TextAlign.Sub => "align-sub",
            TextAlign.Super => "align-super",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for text alignment.")
        };
    }
}