namespace RoyalCode.Razor.Styles;

public enum ObjectFit
{
    Default,
    Contain,
    Cover,
    Fill,
    None,
    ScaleDown
}

public enum ObjectPosition
{
    Default,
    Top,
    Bottom,
    Left,
    Right,
    Center,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}

public static class ObjectsExtensions
{
    public static string ToCssClass(this ObjectFit objectFit)
    {
        return objectFit switch
        {
            ObjectFit.Default => string.Empty,
            ObjectFit.Contain => "object-contain",
            ObjectFit.Cover => "object-cover",
            ObjectFit.Fill => "object-fill",
            ObjectFit.None => "object-none",
            ObjectFit.ScaleDown => "object-scale-down",
            _ => throw new ArgumentOutOfRangeException(nameof(objectFit), objectFit, null)
        };
    }

    public static string ToCssClass(this ObjectPosition objectPosition)
    {
        return objectPosition switch
        {
            ObjectPosition.Default => string.Empty,
            ObjectPosition.Top => "object-top",
            ObjectPosition.Bottom => "object-bottom",
            ObjectPosition.Left => "object-left",
            ObjectPosition.Right => "object-right",
            ObjectPosition.Center => "object-center",
            ObjectPosition.TopLeft => "object-top-left",
            ObjectPosition.TopRight => "object-top-right",
            ObjectPosition.BottomLeft => "object-bottom-left",
            ObjectPosition.BottomRight => "object-bottom-right",
            _ => throw new ArgumentOutOfRangeException(nameof(objectPosition), objectPosition, null)
        };
    }
}