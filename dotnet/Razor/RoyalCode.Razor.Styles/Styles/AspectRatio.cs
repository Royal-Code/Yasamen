namespace RoyalCode.Razor.Styles;

public enum AspectRatio
{
    /// <summary>
    /// Do not apply any aspect ratio
    /// </summary>
    Default,

    /// <summary>
    /// 1:1 aspect ratio
    /// </summary>
    Square,

    /// <summary>
    /// 16:9 aspect ratio
    /// </summary>
    Video,

    /// <summary>
    /// Auto aspect ratio, which adapts to the content
    /// </summary>
    Auto,

    /// <summary>
    /// 2:1 aspect ratio
    /// </summary>
    TwoByOne,

    /// <summary>
    /// 3:2 aspect ratio
    /// </summary>
    ThreeByTwo,

    /// <summary>
    /// 4:3 aspect ratio
    /// </summary>
    FourByThree,

    /// <summary>
    /// 21:9 aspect ratio
    /// </summary>
    TwentyOneByNine,
}

public static class AspectRatioExtensions
{
    public static string ToCssClass(this AspectRatio aspectRatio)
    {
        return aspectRatio switch
        {
            AspectRatio.Default => string.Empty,
            AspectRatio.Square => "aspect-square",
            AspectRatio.Video => "aspect-video",
            AspectRatio.Auto => "aspect-auto",
            AspectRatio.TwoByOne => "aspect-2/1",
            AspectRatio.ThreeByTwo => "aspect-3/2",
            AspectRatio.FourByThree => "aspect-4/3",
            AspectRatio.TwentyOneByNine => "aspect-21/9",
            _ => throw new ArgumentOutOfRangeException(nameof(aspectRatio), aspectRatio, null)
        };
    }
}