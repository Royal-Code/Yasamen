namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    public static TransitionAllBuilder Transition => TransitionAll.Default;
}

public readonly struct TransitionAll
{
    private readonly string className;

    public TransitionAll(string className)
    {
        this.className = className;
    }

    public override string ToString() => className;

    public static implicit operator string(TransitionAll transition) => transition.className;

    public static TransitionAllBuilder Default => new TransitionAllBuilder(
        TransitionTiming.Linear,
        TransitionSpeed.Normal,
        TransitionSpeed.Initial);

    public static TransitionAllBuilder Linear => new TransitionAllBuilder(
        TransitionTiming.Linear,
        TransitionSpeed.Normal,
        TransitionSpeed.Initial);

    public static TransitionAllBuilder In => new TransitionAllBuilder(
        TransitionTiming.In,
        TransitionSpeed.Normal,
        TransitionSpeed.Initial);

    public static TransitionAllBuilder Out => new TransitionAllBuilder(
        TransitionTiming.Out,
        TransitionSpeed.Normal,
        TransitionSpeed.Initial);

    public static TransitionAllBuilder InOut => new TransitionAllBuilder(
        TransitionTiming.InOut,
        TransitionSpeed.Normal,
        TransitionSpeed.Initial);
}

public class TransitionAllBuilder
{
    private readonly TransitionTiming ease;
    private readonly TransitionSpeed duration;
    private readonly TransitionSpeed delay;

    public TransitionAllBuilder(TransitionTiming ease, TransitionSpeed duration, TransitionSpeed delay)
    {
        this.ease = ease;
        this.duration = duration;
        this.delay = delay;
    }

    public TransactionEaseBuilder Ease => new TransactionEaseBuilder(this);

    public TransactionDurationBuilder Duration => new TransactionDurationBuilder(this);

    public TransactionDelayBuilder Delay => new TransactionDelayBuilder(this);

    public TransitionAllBuilder WithEase(TransitionTiming ease)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    public TransitionAllBuilder WithDuration(TransitionSpeed duration)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    public TransitionAllBuilder WithDelay(TransitionSpeed delay)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    public override string ToString()
    {
        return string.Join(" ", AllClasses().Where(s => s.IsPresent()));
    }

    public static implicit operator string(TransitionAllBuilder builder)
    {
        return builder.ToString();
    }

    public static implicit operator TransitionAll(TransitionAllBuilder builder)
    {
        return new TransitionAll(builder.ToString());
    }

    private IEnumerable<string> AllClasses()
    {
        yield return "transition-all";
        yield return ease.ToCssClass();
        yield return duration.ToDurationCssClass();
        yield return delay.ToDelayCssClass();
    }
}

public readonly struct TransactionEaseBuilder
{
    private readonly TransitionAllBuilder builder;

    public TransactionEaseBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }

    public TransitionAllBuilder Linear()
    {
        return builder.WithEase(TransitionTiming.Linear);
    }

    public TransitionAllBuilder In()
    {
        return builder.WithEase(TransitionTiming.In);
    }

    public TransitionAllBuilder Out()
    {
        return builder.WithEase(TransitionTiming.Out);
    }

    public TransitionAllBuilder InOut()
    {
        return builder.WithEase(TransitionTiming.InOut);
    }

    public TransitionAllBuilder Initial()
    {
        return builder.WithEase(TransitionTiming.Initial);
    }
}

public readonly struct TransactionDurationBuilder
{
    private readonly TransitionAllBuilder builder;

    public TransactionDurationBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }

    public TransitionAllBuilder Slowest()
    {
        return builder.WithDuration(TransitionSpeed.Slowest);
    }

    public TransitionAllBuilder Slower()
    {
        return builder.WithDuration(TransitionSpeed.Slower);
    }

    public TransitionAllBuilder Slow()
    {
        return builder.WithDuration(TransitionSpeed.Slow);
    }

    public TransitionAllBuilder Normal()
    {
        return builder.WithDuration(TransitionSpeed.Normal);
    }

    public TransitionAllBuilder Fast()
    {
        return builder.WithDuration(TransitionSpeed.Fast);
    }

    public TransitionAllBuilder Faster()
    {
        return builder.WithDuration(TransitionSpeed.Faster);
    }

    public TransitionAllBuilder Fastest()
    {
        return builder.WithDuration(TransitionSpeed.Fastest);
    }
}

public readonly struct TransactionDelayBuilder
{
    private readonly TransitionAllBuilder builder;
    public TransactionDelayBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }
    public TransitionAllBuilder Slowest()
    {
        return builder.WithDelay(TransitionSpeed.Slowest);
    }
    public TransitionAllBuilder Slower()
    {
        return builder.WithDelay(TransitionSpeed.Slower);
    }
    public TransitionAllBuilder Slow()
    {
        return builder.WithDelay(TransitionSpeed.Slow);
    }
    public TransitionAllBuilder Normal()
    {
        return builder.WithDelay(TransitionSpeed.Normal);
    }
    public TransitionAllBuilder Fast()
    {
        return builder.WithDelay(TransitionSpeed.Fast);
    }
    public TransitionAllBuilder Faster()
    {
        return builder.WithDelay(TransitionSpeed.Faster);
    }
    public TransitionAllBuilder Fastest()
    {
        return builder.WithDelay(TransitionSpeed.Fastest);
    }

    public TransitionAllBuilder Initial()
    {
        return builder.WithDelay(TransitionSpeed.Initial);
    }
}