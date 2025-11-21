using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Commons;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Internal.OffCanvas;

public class OffCanvasState : VisibleState
{
    public OffCanvasState(Func<Task> stateHasChangedAsync) 
        : base(stateHasChangedAsync)
    {
    }

    public bool Closeable { get; internal set; } = true;

    public bool Modal { get; internal set; } = true;

    public Positions Position { get; internal set; } = Positions.End;

    public Fitting Fitting { get; internal set; } = Fitting.Incorporated;

    public ElementReference ElementReference { get; internal set; }
}
