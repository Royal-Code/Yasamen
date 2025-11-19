using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Commons;

/// <summary>
/// State management for transitions.
/// </summary>
public class TransitionState
{
    private readonly Func<Task> stateHasChangedAsync;

    /// <summary>
    /// Creates a new instance of <see cref="TransitionState"/>.
    /// </summary>
    /// <param name="stateHasChangedAsync"></param>
    /// <param name="initialPhase"></param>
    public TransitionState(Func<Task> stateHasChangedAsync, TransitionPhases initialPhase = TransitionPhases.Closed)
    {
        this.stateHasChangedAsync = stateHasChangedAsync;
        Phase = initialPhase;
    }

    /// <summary>
    /// Gets the default timeout, in milliseconds, for UI transitions to complete.
    /// </summary>
    /// <remarks>
    ///     This value is typically used to determine how long to wait for a CSS transition to finish
    ///     before proceeding with subsequent operations. The timeout is calculated as 110% of the base 
    ///     transition duration to provide a buffer for transition completion.
    /// </remarks>
    public int TransitionTimeoutMilliseconds => (int)(Css.Transition.TransitionDurationBase * 1.1);

    /// <summary>
    /// The current phase of the transition.
    /// </summary>
    public TransitionPhases Phase { get; private set; }

    /// <summary>
    /// Open the component, moving it to the OpeningStart phase if it is currently Closed.
    /// </summary>
    /// <returns>Asynchronous task that completes when the state has changed.</returns>
    public Task OpenAsync()
    {
        if (Phase is TransitionPhases.Closed)
        {
            Phase = TransitionPhases.OpeningStart;
            return stateHasChangedAsync();
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Close the component, moving it to the ClosingStart phase if it is currently Opened.
    /// </summary>
    /// <returns>Asynchronous task that completes when the state has changed.</returns>
    public Task CloseAsync()
    {
        if (Phase is TransitionPhases.Open)
        {
            Phase = TransitionPhases.ClosingStart;
            return stateHasChangedAsync();
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Promote the current phase from OpeningStart to Opening, or from ClosingStart to Closing.
    /// </summary>
    /// <returns></returns>
    public async Task PromoteAsync()
    {
        if (Phase is TransitionPhases.OpeningStart)
        {
            await Task.Delay(17); // Allow time for rendering
            Phase = TransitionPhases.Opening;
            RunTimeoutToComplete();
            await stateHasChangedAsync();
        }
        else if (Phase is TransitionPhases.ClosingStart)
        {
            await Task.Delay(17); // Allow time for rendering
            Phase = TransitionPhases.Closing;
            RunTimeoutToComplete();
            await stateHasChangedAsync();
        }
    }

    /// <summary>
    /// Complete the transition, moving from Opening to Opened, or from Closing to Closed.
    /// </summary>
    /// <returns></returns>
    public Task CompleteAsync()
    {
        if (Phase is TransitionPhases.Opening)
        {
            Phase = TransitionPhases.Open;
            return stateHasChangedAsync();
        }
        else if (Phase is TransitionPhases.Closing)
        {
            Phase = TransitionPhases.Closed;
            return stateHasChangedAsync();
        }

        return Task.CompletedTask;
    }

    private void RunTimeoutToComplete()
    {
        Task.Run(async () =>
        {
            await Task.Delay(TransitionTimeoutMilliseconds);
            await CompleteAsync();
        });
    }
}
