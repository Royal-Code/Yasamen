namespace RoyalCode.Razor.Styles;

public static partial class Css
{
    public static WidthBuilder Width => new();
    public static MaxWidthBuilder MaxWidth => new();
    public static MinWidthBuilder MinWidth => new();
    public static HeightBuilder Height => new();
    public static MaxHeightBuilder MaxHeight => new();
    public static MinHeightBuilder MinHeight => new();
}

public readonly ref struct WidthBuilder
{
    public string None() => SpacingSize.None.ToWidthCssClass();
    public string One() => SpacingSize.One.ToWidthCssClass();
    public string Two() => SpacingSize.Two.ToWidthCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToWidthCssClass();
    public string Smaller () => SpacingSize.Smaller.ToWidthCssClass();
    public string Small () => SpacingSize.Small.ToWidthCssClass();
    public string Medium () => SpacingSize.Medium.ToWidthCssClass();
    public string Large () => SpacingSize.Large.ToWidthCssClass();
    public string Larger () => SpacingSize.Larger.ToWidthCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToWidthCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToWidthCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToWidthCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToWidthCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToWidthCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToWidthCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToWidthCssClass();
    public string Largest () => SpacingSize.Largest.ToWidthCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToWidthCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToWidthCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToWidthCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToWidthCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToWidthCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToWidthCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToWidthCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToWidthCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToWidthCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToWidthCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToWidthCssClass();
    public string Full() => SpacingFraction.Full.ToWidthCssClass();
    public string Auto() => "w-auto";
    public string Screen() => "w-screen";
}

public readonly ref struct MaxWidthBuilder
{
    public string None() => SpacingSize.None.ToMaxWidthCssClass();
    public string One() => SpacingSize.One.ToMaxWidthCssClass();
    public string Two() => SpacingSize.Two.ToMaxWidthCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToMaxWidthCssClass();
    public string Smaller () => SpacingSize.Smaller.ToMaxWidthCssClass();
    public string Small () => SpacingSize.Small.ToMaxWidthCssClass();
    public string Medium () => SpacingSize.Medium.ToMaxWidthCssClass();
    public string Large () => SpacingSize.Large.ToMaxWidthCssClass();
    public string Larger () => SpacingSize.Larger.ToMaxWidthCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToMaxWidthCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToMaxWidthCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToMaxWidthCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToMaxWidthCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToMaxWidthCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToMaxWidthCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToMaxWidthCssClass();
    public string Largest () => SpacingSize.Largest.ToMaxWidthCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToMaxWidthCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToMaxWidthCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToMaxWidthCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToMaxWidthCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToMaxWidthCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToMaxWidthCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToMaxWidthCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToMaxWidthCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToMaxWidthCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToMaxWidthCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToMaxWidthCssClass();
    public string Full() => SpacingFraction.Full.ToMaxWidthCssClass();
    public string Auto() => "max-w-auto";
    public string Screen() => "max-w-screen";
}

public readonly ref struct MinWidthBuilder
{
    public string None() => SpacingSize.None.ToMinWidthCssClass();
    public string One() => SpacingSize.One.ToMinWidthCssClass();
    public string Two() => SpacingSize.Two.ToMinWidthCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToMinWidthCssClass();
    public string Smaller () => SpacingSize.Smaller.ToMinWidthCssClass();
    public string Small () => SpacingSize.Small.ToMinWidthCssClass();
    public string Medium () => SpacingSize.Medium.ToMinWidthCssClass();
    public string Large () => SpacingSize.Large.ToMinWidthCssClass();
    public string Larger () => SpacingSize.Larger.ToMinWidthCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToMinWidthCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToMinWidthCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToMinWidthCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToMinWidthCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToMinWidthCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToMinWidthCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToMinWidthCssClass();
    public string Largest () => SpacingSize.Largest.ToMinWidthCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToMinWidthCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToMinWidthCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToMinWidthCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToMinWidthCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToMinWidthCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToMinWidthCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToMinWidthCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToMinWidthCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToMinWidthCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToMinWidthCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToMinWidthCssClass();
    public string Full() => SpacingFraction.Full.ToWidthCssClass();
    public string Auto() => "min-w-auto";
    public string Screen() => "min-w-screen";
}

public readonly ref struct HeightBuilder
{
    public string None() => SpacingSize.None.ToHeightCssClass();
    public string One() => SpacingSize.One.ToHeightCssClass();
    public string Two() => SpacingSize.Two.ToHeightCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToHeightCssClass();
    public string Smaller () => SpacingSize.Smaller.ToHeightCssClass();
    public string Small () => SpacingSize.Small.ToHeightCssClass();
    public string Medium () => SpacingSize.Medium.ToHeightCssClass();
    public string Large () => SpacingSize.Large.ToHeightCssClass();
    public string Larger () => SpacingSize.Larger.ToHeightCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToHeightCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToHeightCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToHeightCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToHeightCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToHeightCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToHeightCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToHeightCssClass();
    public string Largest () => SpacingSize.Largest.ToHeightCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToHeightCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToHeightCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToHeightCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToHeightCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToHeightCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToHeightCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToHeightCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToHeightCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToHeightCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToHeightCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToHeightCssClass();
    public string Full() => SpacingFraction.Full.ToHeightCssClass();
    public string Auto() => "h-auto";
    public string Screen() => "h-screen";
}

public readonly ref struct MaxHeightBuilder
{
    public string None() => SpacingSize.None.ToMaxHeightCssClass();
    public string One() => SpacingSize.One.ToMaxHeightCssClass();
    public string Two() => SpacingSize.Two.ToMaxHeightCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToMaxHeightCssClass();
    public string Smaller () => SpacingSize.Smaller.ToMaxHeightCssClass();
    public string Small () => SpacingSize.Small.ToMaxHeightCssClass();
    public string Medium () => SpacingSize.Medium.ToMaxHeightCssClass();
    public string Large () => SpacingSize.Large.ToMaxHeightCssClass();
    public string Larger () => SpacingSize.Larger.ToMaxHeightCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToMaxHeightCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToMaxHeightCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToMaxHeightCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToMaxHeightCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToMaxHeightCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToMaxHeightCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToMaxHeightCssClass();
    public string Largest () => SpacingSize.Largest.ToMaxHeightCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToMaxHeightCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToMaxHeightCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToMaxHeightCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToMaxHeightCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToMaxHeightCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToMaxHeightCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToMaxHeightCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToMaxHeightCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToMaxHeightCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToMaxHeightCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToMaxHeightCssClass();
    public string Full() => SpacingFraction.Full.ToMaxHeightCssClass();
    public string Auto() => "max-h-auto";
    public string Screen() => "max-h-screen";
}

public readonly ref struct MinHeightBuilder
{
    public string None() => SpacingSize.None.ToMinHeightCssClass();
    public string One() => SpacingSize.One.ToMinHeightCssClass();
    public string Two() => SpacingSize.Two.ToMinHeightCssClass();
    public string SmallerX2 () => SpacingSize.SmallerX2.ToMinHeightCssClass();
    public string Smaller () => SpacingSize.Smaller.ToMinHeightCssClass();
    public string Small () => SpacingSize.Small.ToMinHeightCssClass();
    public string Medium () => SpacingSize.Medium.ToMinHeightCssClass();
    public string Large () => SpacingSize.Large.ToMinHeightCssClass();
    public string Larger () => SpacingSize.Larger.ToMinHeightCssClass();
    public string LargerX2 () => SpacingSize.LargerX2.ToMinHeightCssClass();
    public string LargerX3 () => SpacingSize.LargerX3.ToMinHeightCssClass();
    public string LargerX4 () => SpacingSize.LargerX4.ToMinHeightCssClass();
    public string LargerX5 () => SpacingSize.LargerX5.ToMinHeightCssClass();
    public string LargerX6 () => SpacingSize.LargerX6.ToMinHeightCssClass();
    public string LargerX7 () => SpacingSize.LargerX7.ToMinHeightCssClass();
    public string LargerX8 () => SpacingSize.LargerX8.ToMinHeightCssClass();
    public string Largest () => SpacingSize.Largest.ToMinHeightCssClass();
    public string OneOfTwelve() => SpacingFraction.One.ToMinHeightCssClass();
    public string TwoOfTwelve() => SpacingFraction.Two.ToMinHeightCssClass();
    public string ThreeOfTwelve() => SpacingFraction.Three.ToMinHeightCssClass();
    public string FourOfTwelve() => SpacingFraction.Four.ToMinHeightCssClass();
    public string FiveOfTwelve() => SpacingFraction.Five.ToMinHeightCssClass();
    public string SixOfTwelve() => SpacingFraction.Six.ToMinHeightCssClass();
    public string SevenOfTwelve() => SpacingFraction.Seven.ToMinHeightCssClass();
    public string EightOfTwelve() => SpacingFraction.Eight.ToMinHeightCssClass();
    public string NineOfTwelve() => SpacingFraction.Nine.ToMinHeightCssClass();
    public string TenOfTwelve() => SpacingFraction.Ten.ToMinHeightCssClass();
    public string ElevenOfTwelve() => SpacingFraction.Eleven.ToMinHeightCssClass();
    public string Full() => SpacingFraction.Full.ToMinHeightCssClass();
    public string Auto() => "min-h-auto";
    public string Screen() => "min-h-screen";
}