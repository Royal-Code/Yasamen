
namespace RoyalCode.Razor.Commons.Styles;

public static class BordersExtensions
{
    public static string ToBorderCssClasses(this BorderPositions style)
    {
        return style switch
        {
            BorderPositions.None => "border-0",
            BorderPositions.Default => "border",
            BorderPositions.Top => "border-top",
            BorderPositions.End => "border-end",
            BorderPositions.Bottom => "border-bottom",
            BorderPositions.Start => "border-start",
            BorderPositions.NotAtTop => "border border-top-0",
            BorderPositions.NotAtEnd => "border border-end-0",
            BorderPositions.NotAtBottom => "border border-bottom-0",
            BorderPositions.NotAtStart => "border border-start-0",
            BorderPositions.TopEnd => "border-top border-end",
            BorderPositions.TopBottom => "border-top border-bottom",
            BorderPositions.TopStart => "border-top border-start",
            BorderPositions.EndBottom => "border-end border-bottom",
            BorderPositions.EndStart => "border-end border-start",
            BorderPositions.BottomStart => "border-bottom border-start",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this Themes color)
    {
        return color switch
        {
            Themes.Default => string.Empty,
            Themes.Primary => "border-primary",
            Themes.Secondary => "border-secondary",
            Themes.Tertiary => "border-tertiary",
            Themes.Info => "border-info",
            Themes.Highlight => "border-highlight",
            Themes.Success => "border-success",
            Themes.Warning => "border-warning",
            Themes.Alert => "border-alert",
            Themes.Danger => "border-danger",
            Themes.Light => "border-light",
            Themes.Dark => "border-dark",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderWidth width)
    {
        return width switch
        {
            BorderWidth.One => "border-1",
            BorderWidth.Two => "border-2",
            BorderWidth.Three => "border-3",
            BorderWidth.Four => "border-4",
            BorderWidth.Five => "border-5",
            BorderWidth.Six => "border-6",
            BorderWidth.Seven => "border-7",
            BorderWidth.Eight => "border-8",
            BorderWidth.Nine => "border-9",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderStyles style)
    {
        return style switch
        {
            BorderStyles.Solid => "border-solid",
            BorderStyles.Dashed => "border-dashed",
            BorderStyles.DotDashed => "border-dot-dashed",
            BorderStyles.DotDotDashed => "border-dot-dot-dashed",
            BorderStyles.Dotted => "border-dotted",
            BorderStyles.Double => "border-double",
            BorderStyles.Groove => "border-groove",
            BorderStyles.Hidden => "border-hidden",
            BorderStyles.Inset => "border-inset",
            BorderStyles.Outset => "border-outset",
            BorderStyles.Ridge => "border-ridge",
            BorderStyles.Wave => "border-wave",
            BorderStyles.Revert => "border-revert",
            BorderStyles.None => "border-none",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderRound round)
    {
        return round switch
        {
            BorderRound.None => "round-0",
            BorderRound.Default => "round",
            BorderRound.Top => "round-top",
            BorderRound.End => "round-end",
            BorderRound.Bottom => "round-bottom",
            BorderRound.Start => "round-start",
            BorderRound.TopStart => "round-top-start",
            BorderRound.TopEnd => "round-top-end",
            BorderRound.BottomStart => "round-bottom-start",
            BorderRound.BottomEnd => "round-bottom-end",
            BorderRound.Circle => "round-circle",
            BorderRound.Pill => "round-pill",
            BorderRound.Ellipse => "round-ellipse",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderRadius radius)
    {
        return radius switch
        {
            BorderRadius.One => "round-1",
            BorderRadius.Two => "round-2",
            BorderRadius.Three => "round-3",
            BorderRadius.Four => "round-4",
            BorderRadius.Five => "round-5",
            BorderRadius.Six => "round-6",
            BorderRadius.Seven => "round-7",
            BorderRadius.Eight => "round-8",
            BorderRadius.Nine => "round-9",
            _ => string.Empty
        };
    }
}
