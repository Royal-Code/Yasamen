using RoyalCode.Razor.Commons;

namespace RoyalCode.Razor.Internal.Modals;

public class ModalState : TransitionState
{
    public ModalState(Func<Task> stateHasChangedAsync, TransitionPhases initialPhase = TransitionPhases.Closed) 
        : base(stateHasChangedAsync, initialPhase)
    {
    }

    /// <summary>
    /// Determines whether the modal can be closed by clicking the backdrop or pressing the escape key.
    /// </summary>
    public bool Closeable { get; internal set; } = true;
}
