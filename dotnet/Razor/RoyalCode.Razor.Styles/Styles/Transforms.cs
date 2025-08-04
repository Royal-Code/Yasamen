namespace RoyalCode.Razor.Styles;

public enum TransformRotate
{
    None,
    Rotate45,
    Rotate90,
    Rotate135,
    Rotate180,
    Rotate225,
    Rotate270,
    Rotate315
}

public enum TransformScale
{
    None,
    X0,
    X10,
    X25,
    X50,
    X75,
    X90,
    X100,
    X125,
    X150,
    X175,
    X200,
    X300,
    Y0,
    Y10,
    Y25,
    Y50,
    Y75,
    Y90,
    Y100,
    Y125,
    Y150,
    Y175,
    Y200,
    Y300,
    All0,
    All10,
    All25,
    All50,
    All75,
    All90,
    All100,
    All125,
    All150,
    All175,
    All200,
    All300
}

public enum TransformTranslate
{
    None,
    Left,
    LeftHalf,
    LeftQuarter,
    Right,
    RightHalf,
    RightQuarter,
    Top,
    TopHalf,
    TopQuarter,
    Bottom,
    BottomHalf,
    BottomQuarter,
}

public static class TransformExtensions
{
    public static string ToCssClass(this TransformRotate rotate)
    {
        return rotate switch
        {
            TransformRotate.None => "rotate-none",
            TransformRotate.Rotate45 => "rotate-45",
            TransformRotate.Rotate90 => "rotate-90",
            TransformRotate.Rotate135 => "rotate-135",
            TransformRotate.Rotate180 => "rotate-180",
            TransformRotate.Rotate225 => "rotate-225",
            TransformRotate.Rotate270 => "rotate-270",
            TransformRotate.Rotate315 => "rotate-315",
            _ => throw new ArgumentOutOfRangeException(nameof(rotate), rotate, null)
        };
    }

    public static string ToCssClass(this TransformScale scale)
    {
        return scale switch
        {
            TransformScale.None => "scale-none",
            TransformScale.X0 => "scale-x-0",
            TransformScale.X10 => "scale-x-10",
            TransformScale.X25 => "scale-x-25",
            TransformScale.X50 => "scale-x-50",
            TransformScale.X75 => "scale-x-75",
            TransformScale.X90 => "scale-x-90",
            TransformScale.X100 => "scale-x-100",
            TransformScale.X125 => "scale-x-125",
            TransformScale.X150 => "scale-x-150",
            TransformScale.X175 => "scale-x-175",
            TransformScale.X200 => "scale-x-200",
            TransformScale.X300 => "scale-x-300",
            TransformScale.Y0 => "scale-y-0",
            TransformScale.Y10 => "scale-y-10",
            TransformScale.Y25 => "scale-y-25",
            TransformScale.Y50 => "scale-y-50",
            TransformScale.Y75 => "scale-y-75",
            TransformScale.Y90 => "scale-y-90",
            TransformScale.Y100 => "scale-y-100",
            TransformScale.Y125 => "scale-y-125",
            TransformScale.Y150 => "scale-y-150",
            TransformScale.Y175 => "scale-y-175",
            TransformScale.Y200 => "scale-y-200",
            TransformScale.Y300 => "scale-y-300",
            TransformScale.All0 => "scale-0",
            TransformScale.All10 => "scale-10",
            TransformScale.All25 => "scale-25",
            TransformScale.All50 => "scale-50",
            TransformScale.All75 => "scale-75",
            TransformScale.All90 => "scale-90",
            TransformScale.All100 => "scale-100",
            TransformScale.All125 => "scale-125",
            TransformScale.All150 => "scale-150",
            TransformScale.All175 => "scale-175",
            TransformScale.All200 => "scale-200",
            TransformScale.All300 => "scale-300",
            _ => throw new ArgumentOutOfRangeException(nameof(scale), scale, null)
        };
    }

    public static string ToCssClass(this TransformTranslate translate)
    {
        return translate switch
        {
            TransformTranslate.None => "translate-none",
            TransformTranslate.Left => "-translate-x-full",
            TransformTranslate.LeftHalf => "-translate-x-1/2",
            TransformTranslate.LeftQuarter => "-translate-x-1/4",
            TransformTranslate.Right => "translate-x-full",
            TransformTranslate.RightHalf => "translate-x-1/2",
            TransformTranslate.RightQuarter => "translate-x-1/4",
            TransformTranslate.Top => "translate-y-full",
            TransformTranslate.TopHalf => "translate-y-1/2",
            TransformTranslate.TopQuarter => "translate-y-1/4",
            TransformTranslate.Bottom => "-translate-y-full",
            TransformTranslate.BottomHalf => "-translate-y-1/2",
            TransformTranslate.BottomQuarter => "-translate-y-1/4",
            _ => throw new ArgumentOutOfRangeException(nameof(translate), translate, null)
        };
    }
}