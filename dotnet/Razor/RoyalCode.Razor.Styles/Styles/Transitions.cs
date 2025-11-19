namespace RoyalCode.Razor.Styles;

public enum TransitionTiming
{
    Linear,
    In,
    Out,
    InOut,
    Initial,
}

public enum TransitionSpeed
{
    Default,
    Slowest,
    Slower,
    Slow,
    Normal,
    Fast,
    Faster,
    Fastest,
    Initial,
}


public static class TransactionExtensions
{
    public static string ToCssClass(this TransitionTiming timing)
    {
        return timing switch
        {
            TransitionTiming.Linear => "ease-linear",
            TransitionTiming.In => "ease-in",
            TransitionTiming.Out => "ease-out",
            TransitionTiming.InOut => "ease-in-out",
            TransitionTiming.Initial => "ease-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(timing), timing, null)
        };
    }

    public static string ToDurationCssClass(this TransitionSpeed speed)
    {
        return speed switch
        {
            TransitionSpeed.Default => "duration-(--duration-default)",
            TransitionSpeed.Slowest => "duration-(--duration-slowest)",
            TransitionSpeed.Slower => "duration-(--duration-slower)",
            TransitionSpeed.Slow => "duration-(--duration-slow)",
            TransitionSpeed.Normal => "duration-(--duration-normal)",
            TransitionSpeed.Fast => "duration-(--duration-fast)",
            TransitionSpeed.Faster => "duration-(--duration-faster)",
            TransitionSpeed.Fastest => "duration-(--duration-fastest)",
            TransitionSpeed.Initial => "duration-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(speed), speed, null)
        };
    }

    public static string ToDelayCssClass(this TransitionSpeed speed)
    {
        return speed switch
        {
            TransitionSpeed.Default => "delay-(--duration-default)",
            TransitionSpeed.Slowest => "delay-(--duration-slowest)",
            TransitionSpeed.Slower => "delay-(--duration-slower)",
            TransitionSpeed.Slow => "delay-(--duration-slow)",
            TransitionSpeed.Normal => "delay-(--duration-normal)",
            TransitionSpeed.Fast => "delay-(--duration-fast)",
            TransitionSpeed.Faster => "delay-(--duration-faster)",
            TransitionSpeed.Fastest => "delay-(--duration-fastest)",
            TransitionSpeed.Initial => "delay-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(speed), speed, null)
        };
    }
}