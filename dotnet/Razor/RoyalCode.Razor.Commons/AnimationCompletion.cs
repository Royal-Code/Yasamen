namespace RoyalCode.Razor.Commons;

/// <summary>
/// <para>
///     Provides a simple mechanism to await the completion of an animation,
///     with an automatic timeout fallback.
/// </para>
/// </summary>
/// <remarks>
/// Usage: <br />
///     1. Create an instance before starting an animation. <br />
///     2. Pass the instance to the animation logic or event handler. <br />
///     3. Call <see cref="Complete"/> when the animation finishes. <br />
///     4. Await <see cref="Task"/> to continue after completion or timeout. <br />
/// <br />
/// If <see cref="Complete"/> is never called, the task completes after the specified timeout.
/// <br />
/// This type is thread-safe for multiple invocations of <see cref="Complete"/>.
/// </remarks>
public class AnimationCompletion
{
    /// <summary>
    /// Gets or sets the default timeout duration in milliseconds for animation completion.
    /// </summary>
    public static int DefaultTimeoutMilliseconds { get; set; } = 300;

    // Internal completion source. Non-generic as no result value is required.
    private TaskCompletionSource? taskCompletionSource = new();

    /// <summary>
    /// Initializes a new instance of <see cref="AnimationCompletion"/> with an optional timeout.
    /// </summary>
    /// <param name="timeoutMilliseconds">
    /// The maximum time (in milliseconds) to wait before completing automatically.
    /// Defaults to <see cref="DefaultTimeoutMilliseconds"/> if not specified or non-positive.
    /// </param>
    /// <remarks>
    /// A background task is started that will complete this instance if the timeout elapses first.
    /// </remarks>
    public AnimationCompletion(int timeoutMilliseconds = 0)
    {
        if (timeoutMilliseconds <= 0)
            timeoutMilliseconds = DefaultTimeoutMilliseconds;

        _ = Task.Run(async () =>
        {
            await Task.Delay(timeoutMilliseconds).ConfigureAwait(false);
            taskCompletionSource?.TrySetResult();
            taskCompletionSource = null;
        });
    }

    /// <summary>
    /// Gets the task that completes when the animation signals completion
    /// via <see cref="Complete"/> or when the timeout occurs.
    /// </summary>
    /// <returns>
    /// A task that can be awaited to resume logic after animation end or timeout.
    /// </returns>
    public Task Task => taskCompletionSource?.Task ?? Task.CompletedTask;

    /// <summary>
    /// Marks the animation as completed, transitioning the task into the completed state.
    /// Safe to call multiple times; subsequent calls are ignored.
    /// </summary>
    public void Complete()
    {
        taskCompletionSource?.TrySetResult();
        taskCompletionSource = null;
    }
}
