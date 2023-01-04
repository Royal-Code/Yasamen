
namespace RoyalCode.Yasamen.Layout;

public enum BoxStyles
{
    None,
    Primary,
    Secondary,
    Success,
    Info,
    Warning,
    Danger,
    Light,
    Dark,
}

public static class BoxStylesExtensions
{
    public static string ToCssClass(this BoxStyles style)
    {
        return style switch
        {
            BoxStyles.None => string.Empty,
            BoxStyles.Primary => "box-primary",
            BoxStyles.Secondary => "box-secondary",
            BoxStyles.Success => "box-success",
            BoxStyles.Danger => "box-danger",
            BoxStyles.Warning => "box-warning",
            BoxStyles.Info => "box-info",
            BoxStyles.Light => "box-light",
            BoxStyles.Dark => "box-dark",
            _ => throw new NotSupportedException($"Box style '{style}' is not supported.")
        };
    }
}