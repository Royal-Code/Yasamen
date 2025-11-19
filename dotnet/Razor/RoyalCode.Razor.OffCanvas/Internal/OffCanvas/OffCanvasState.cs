using RoyalCode.Razor.Commons;

namespace RoyalCode.Razor.Internal.OffCanvas;

public class OffCanvasState : TransitionState
{
    public OffCanvasState(Func<Task> stateHasChangedAsync, TransitionPhases initialPhase = TransitionPhases.Closed) 
        : base(stateHasChangedAsync, initialPhase)
    {
    }

    public bool Closeable { get; internal set; } = true;
}
