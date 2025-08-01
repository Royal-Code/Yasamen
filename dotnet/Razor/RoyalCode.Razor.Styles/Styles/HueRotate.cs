namespace RoyalCode.Razor.Styles;

public enum HueRotate
{
    Default,
    None,
    Rotate15,
    Rotate30,
    Rotate45,
    Rotate60,
    Rotate75,
    Rotate90,
    Rotate105,
    Rotate120,
    Rotate135,
    Rotate150,
    Rotate165,
    Rotate180,
    Rotate195,
    Rotate210,
    Rotate225,
    Rotate240,
    Rotate255,
    Rotate270,
    Rotate285,
    Rotate300,
    Rotate315,
    Rotate330,
    Rotate345
}

public static class HueRotateExtensions
{
    public static string ToCssClass(this HueRotate hueRotate)
    {
        return hueRotate switch
        {
            HueRotate.Default => string.Empty,
            HueRotate.None => "hue-rotate-0",
            HueRotate.Rotate15 => "hue-rotate-15",
            HueRotate.Rotate30 => "hue-rotate-30",
            HueRotate.Rotate45 => "hue-rotate-45",
            HueRotate.Rotate60 => "hue-rotate-60",
            HueRotate.Rotate75 => "hue-rotate-75",
            HueRotate.Rotate90 => "hue-rotate-90",
            HueRotate.Rotate105 => "hue-rotate-105",
            HueRotate.Rotate120 => "hue-rotate-120",
            HueRotate.Rotate135 => "hue-rotate-135",
            HueRotate.Rotate150 => "hue-rotate-150",
            HueRotate.Rotate165 => "hue-rotate-165",
            HueRotate.Rotate180 => "hue-rotate-180",
            HueRotate.Rotate195 => "hue-rotate-195",
            HueRotate.Rotate210 => "hue-rotate-210",
            HueRotate.Rotate225 => "hue-rotate-225",
            HueRotate.Rotate240 => "hue-rotate-240",
            HueRotate.Rotate255 => "hue-rotate-255",
            HueRotate.Rotate270 => "hue-rotate-270",
            HueRotate.Rotate285 => "hue-rotate-285",
            HueRotate.Rotate300 => "hue-rotate-300",
            HueRotate.Rotate315 => "hue-rotate-315",
            HueRotate.Rotate330 => "hue-rotate-330",
            HueRotate.Rotate345 => "hue-rotate-345",
            _ => throw new ArgumentOutOfRangeException(nameof(hueRotate), hueRotate, null)
        };
    }

    public static string ToBackdropCssClass(this HueRotate hueRotate)
    {
        return hueRotate switch
        {
            HueRotate.Default => string.Empty,
            HueRotate.None => "backdrop-hue-rotate-0",
            HueRotate.Rotate15 => "backdrop-hue-rotate-15",
            HueRotate.Rotate30 => "backdrop-hue-rotate-30",
            HueRotate.Rotate45 => "backdrop-hue-rotate-45",
            HueRotate.Rotate60 => "backdrop-hue-rotate-60",
            HueRotate.Rotate75 => "backdrop-hue-rotate-75",
            HueRotate.Rotate90 => "backdrop-hue-rotate-90",
            HueRotate.Rotate105 => "backdrop-hue-rotate-105",
            HueRotate.Rotate120 => "backdrop-hue-rotate-120",
            HueRotate.Rotate135 => "backdrop-hue-rotate-135",
            HueRotate.Rotate150 => "backdrop-hue-rotate-150",
            HueRotate.Rotate165 => "backdrop-hue-rotate-165",
            HueRotate.Rotate180 => "backdrop-hue-rotate-180",
            HueRotate.Rotate195 => "backdrop-hue-rotate-195",
            HueRotate.Rotate210 => "backdrop-hue-rotate-210",
            HueRotate.Rotate225 => "backdrop-hue-rotate-225",
            HueRotate.Rotate240 => "backdrop-hue-rotate-240",
            HueRotate.Rotate255 => "backdrop-hue-rotate-255",
            HueRotate.Rotate270 => "backdrop-hue-rotate-270",
            HueRotate.Rotate285 => "backdrop-hue-rotate-285",
            HueRotate.Rotate300 => "backdrop-hue-rotate-300",
            HueRotate.Rotate315 => "backdrop-hue-rotate-315",
            HueRotate.Rotate330 => "backdrop-hue-rotate-330",
            HueRotate.Rotate345 => "backdrop-hue-rotate-345",
            _ => throw new ArgumentOutOfRangeException(nameof(hueRotate), hueRotate, null)
        };
    }
}