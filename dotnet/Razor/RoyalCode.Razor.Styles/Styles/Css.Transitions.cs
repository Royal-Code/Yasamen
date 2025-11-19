namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    /// <summary>
    /// Transition utilities.
    /// </summary>
    public static Transitions Transition => new();
}

/// <summary>
/// Utility for transition classes.
/// </summary>
public readonly struct Transitions
{
    /// <summary>
    /// The default base duration for transitions in milliseconds.
    /// </summary>
    public int TransitionDurationBase => 150;

    /// <summary>
    /// Transition all builder.
    /// </summary>
    public TransitionAllBuilder All => TransitionAll.Default;
}

/// <summary>
/// Transition all class builder.
/// </summary>
public readonly struct TransitionAll
{
    private readonly string className;

    /// <summary>
    /// Creates a new instance of <see cref="TransitionAll"/>.
    /// </summary>
    /// <param name="className"></param>
    public TransitionAll(string className)
    {
        this.className = className;
    }

    /// <summary>
    /// Gets the CSS class name.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => className;

    /// <summary>
    /// Implicit conversion to string.
    /// </summary>
    /// <param name="transition"></param>
    public static implicit operator string(TransitionAll transition) => transition.className;

    /// <summary>
    /// Default transition all builder.
    /// </summary>
    public static TransitionAllBuilder Default => new TransitionAllBuilder(
        TransitionTiming.Linear,
        TransitionSpeed.Default,
        TransitionSpeed.Initial);

    /// <summary>
    /// Linear transition all builder.
    /// </summary>
    public static TransitionAllBuilder Linear => new TransitionAllBuilder(
        TransitionTiming.Linear,
        TransitionSpeed.Default,
        TransitionSpeed.Initial);

    /// <summary>
    /// In transition all builder.
    /// </summary>
    public static TransitionAllBuilder In => new TransitionAllBuilder(
        TransitionTiming.In,
        TransitionSpeed.Default,
        TransitionSpeed.Initial);

    /// <summary>
    /// Out transition all builder.
    /// </summary>
    public static TransitionAllBuilder Out => new TransitionAllBuilder(
        TransitionTiming.Out,
        TransitionSpeed.Default,
        TransitionSpeed.Initial);

    /// <summary>
    /// InOut transition all builder.
    /// </summary>
    public static TransitionAllBuilder InOut => new TransitionAllBuilder(
        TransitionTiming.InOut,
        TransitionSpeed.Default,
        TransitionSpeed.Initial);
}

/// <summary>
/// Utility to build transition all CSS classes.
/// </summary>
public class TransitionAllBuilder
{
    private readonly TransitionTiming ease;
    private readonly TransitionSpeed duration;
    private readonly TransitionSpeed delay;

    /// <summary>
    /// Creates a new instance of <see cref="TransitionAllBuilder"/>.
    /// </summary>
    /// <param name="ease"></param>
    /// <param name="duration"></param>
    /// <param name="delay"></param>
    public TransitionAllBuilder(TransitionTiming ease, TransitionSpeed duration, TransitionSpeed delay)
    {
        this.ease = ease;
        this.duration = duration;
        this.delay = delay;
    }

    /// <summary>
    /// Convenience builder for setting the transition ease.
    /// </summary>
    public TransactionEaseBuilder Ease => new TransactionEaseBuilder(this);

    /// <summary>
    /// Convenience builder for setting the transition duration.
    /// </summary>
    public TransactionDurationBuilder Duration => new TransactionDurationBuilder(this);

    /// <summary>
    /// Convenience builder for setting the transition delay.
    /// </summary>
    public TransactionDelayBuilder Delay => new TransactionDelayBuilder(this);

    /// <summary>
    /// Sets the transition ease.
    /// </summary>
    /// <param name="ease">The transition timing function.</param>
    /// <returns>A new instance of <see cref="TransitionAllBuilder"/> with the specified ease.</returns>
    public TransitionAllBuilder WithEase(TransitionTiming ease)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    /// <summary>
    /// Sets the transition duration.
    /// </summary>
    /// <param name="duration">The transition duration.</param>
    /// <returns>A new instance of <see cref="TransitionAllBuilder"/> with the specified duration.</returns>
    public TransitionAllBuilder WithDuration(TransitionSpeed duration)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    /// <summary>
    /// Sets the transition delay.
    /// </summary>
    /// <param name="delay">The transition delay.</param>
    /// <returns>A new instance of <see cref="TransitionAllBuilder"/> with the specified delay.</returns>
    public TransitionAllBuilder WithDelay(TransitionSpeed delay)
    {
        return new TransitionAllBuilder(ease, duration, delay);
    }

    /// <summary>
    /// Gets the CSS class string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Join(" ", AllClasses().Where(s => s.IsPresent()));
    }

    /// <summary>
    /// Implicit conversion to string.
    /// </summary>
    /// <param name="builder"></param>
    public static implicit operator string(TransitionAllBuilder builder)
    {
        return builder.ToString();
    }

    /// <summary>
    /// Implicit conversion to <see cref="TransitionAll"/>.
    /// </summary>
    /// <param name="builder"></param>
    public static implicit operator TransitionAll(TransitionAllBuilder builder)
    {
        return new TransitionAll(builder.ToString());
    }

    /// <summary>
    /// Gets all CSS classes.
    /// </summary>
    /// <returns></returns>
    private IEnumerable<string> AllClasses()
    {
        yield return "transition-all";
        yield return ease.ToCssClass();
        yield return duration.ToDurationCssClass();
        yield return delay.ToDelayCssClass();
    }
}

/// <summary>
/// Convenience builder to configure the easing (timing function) of a <see cref="TransitionAllBuilder"/>.
/// </summary>
/// <remarks>
/// Provides fluent helpers to set the <see cref="TransitionTiming"/> on a transition-all configuration.
/// Each method returns a new <see cref="TransitionAllBuilder"/> instance with the specified easing applied.
/// </remarks>
public readonly struct TransactionEaseBuilder
{
    private readonly TransitionAllBuilder builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionEaseBuilder"/>.
    /// </summary>
    /// <param name="builder">The current transition-all builder.</param>
    public TransactionEaseBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }

    /// <summary>
    /// Sets the transition timing function to <see cref="TransitionTiming.Linear"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with linear easing.</returns>
    public TransitionAllBuilder Linear()
    {
        return builder.WithEase(TransitionTiming.Linear);
    }

    /// <summary>
    /// Sets the transition timing function to <see cref="TransitionTiming.In"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with ease-in timing.</returns>
    public TransitionAllBuilder In()
    {
        return builder.WithEase(TransitionTiming.In);
    }

    /// <summary>
    /// Sets the transition timing function to <see cref="TransitionTiming.Out"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with ease-out timing.</returns>
    public TransitionAllBuilder Out()
    {
        return builder.WithEase(TransitionTiming.Out);
    }

    /// <summary>
    /// Sets the transition timing function to <see cref="TransitionTiming.InOut"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with ease-in-out timing.</returns>
    public TransitionAllBuilder InOut()
    {
        return builder.WithEase(TransitionTiming.InOut);
    }

    /// <summary>
    /// Resets the transition timing function to <see cref="TransitionTiming.Initial"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with the initial timing function.</returns>
    public TransitionAllBuilder Initial()
    {
        return builder.WithEase(TransitionTiming.Initial);
    }
}

/// <summary>
/// Convenience builder to configure the duration of a <see cref="TransitionAllBuilder"/>.
/// </summary>
/// <remarks>
/// Provides fluent helpers to set the <see cref="TransitionSpeed"/> (duration) on a transition-all configuration.
/// Each method returns a new <see cref="TransitionAllBuilder"/> instance with the specified duration applied.
/// </remarks>
public readonly struct TransactionDurationBuilder
{
    private readonly TransitionAllBuilder builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionDurationBuilder"/>.
    /// </summary>
    /// <param name="builder">The current transition-all builder.</param>
    public TransactionDurationBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }

    /// <summary>
    /// Sets the transition duration to the slowest speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slowest"/> duration.</returns>
    public TransitionAllBuilder Slowest()
    {
        return builder.WithDuration(TransitionSpeed.Slowest);
    }

    /// <summary>
    /// Sets the transition duration to a slower speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slower"/> duration.</returns>
    public TransitionAllBuilder Slower()
    {
        return builder.WithDuration(TransitionSpeed.Slower);
    }

    /// <summary>
    /// Sets the transition duration to a slow speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slow"/> duration.</returns>
    public TransitionAllBuilder Slow()
    {
        return builder.WithDuration(TransitionSpeed.Slow);
    }

    /// <summary>
    /// Sets the transition duration to a normal speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Normal"/> duration.</returns>
    public TransitionAllBuilder Normal()
    {
        return builder.WithDuration(TransitionSpeed.Normal);
    }

    /// <summary>
    /// Sets the transition duration to a fast speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Fast"/> duration.</returns>
    public TransitionAllBuilder Fast()
    {
        return builder.WithDuration(TransitionSpeed.Fast);
    }

    /// <summary>
    /// Sets the transition duration to a faster speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Faster"/> duration.</returns>
    public TransitionAllBuilder Faster()
    {
        return builder.WithDuration(TransitionSpeed.Faster);
    }

    /// <summary>
    /// Sets the transition duration to the fastest speed.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Fastest"/> duration.</returns>
    public TransitionAllBuilder Fastest()
    {
        return builder.WithDuration(TransitionSpeed.Fastest);
    }
}

/// <summary>
/// Convenience builder to configure the delay of a <see cref="TransitionAllBuilder"/>.
/// </summary>
/// <remarks>
/// Provides fluent helpers to set the <see cref="TransitionSpeed"/> (delay) on a transition-all configuration.
/// Each method returns a new <see cref="TransitionAllBuilder"/> instance with the specified delay applied.
/// </remarks>
public readonly struct TransactionDelayBuilder
{
    private readonly TransitionAllBuilder builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionDelayBuilder"/>.
    /// </summary>
    /// <param name="builder">The current transition-all builder.</param>
    public TransactionDelayBuilder(TransitionAllBuilder builder)
    {
        this.builder = builder;
    }

    /// <summary>
    /// Sets the transition delay to the slowest value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slowest"/> delay.</returns>
    public TransitionAllBuilder Slowest()
    {
        return builder.WithDelay(TransitionSpeed.Slowest);
    }

    /// <summary>
    /// Sets the transition delay to a slower value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slower"/> delay.</returns>
    public TransitionAllBuilder Slower()
    {
        return builder.WithDelay(TransitionSpeed.Slower);
    }

    /// <summary>
    /// Sets the transition delay to a slow value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Slow"/> delay.</returns>
    public TransitionAllBuilder Slow()
    {
        return builder.WithDelay(TransitionSpeed.Slow);
    }

    /// <summary>
    /// Sets the transition delay to a normal value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Normal"/> delay.</returns>
    public TransitionAllBuilder Normal()
    {
        return builder.WithDelay(TransitionSpeed.Normal);
    }

    /// <summary>
    /// Sets the transition delay to a fast value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Fast"/> delay.</returns>
    public TransitionAllBuilder Fast()
    {
        return builder.WithDelay(TransitionSpeed.Fast);
    }

    /// <summary>
    /// Sets the transition delay to a faster value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Faster"/> delay.</returns>
    public TransitionAllBuilder Faster()
    {
        return builder.WithDelay(TransitionSpeed.Faster);
    }

    /// <summary>
    /// Sets the transition delay to the fastest value.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with <see cref="TransitionSpeed.Fastest"/> delay.</returns>
    public TransitionAllBuilder Fastest()
    {
        return builder.WithDelay(TransitionSpeed.Fastest);
    }

    /// <summary>
    /// Resets the transition delay to <see cref="TransitionSpeed.Initial"/>.
    /// </summary>
    /// <returns>A new <see cref="TransitionAllBuilder"/> with the initial delay.</returns>
    public TransitionAllBuilder Initial()
    {
        return builder.WithDelay(TransitionSpeed.Initial);
    }
}