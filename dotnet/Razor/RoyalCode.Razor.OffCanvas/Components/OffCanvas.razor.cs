using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public partial class OffCanvas
{
    private OffCanvasHandler handler = null!;

    internal bool IsVisible => state.IsVisible;

    [Parameter]
    public Positions Position { get; set; } = Positions.End;

    [Parameter]
    public Fitting Fitting { get; set; } = Fitting.Incorporated;

    [Parameter]
    public bool Modal { get; set; }

    [Parameter]
    public bool? Closeable { get; set; }

    [Parameter]
    public OffCanvasHandler? Handler { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public EventCallback<bool> OnVisibilityChanged { get; set; }

    [Parameter]
    public bool UseBox { get; set; }

    [Parameter]
    public Sizes BoxSize { get; set; } = Sizes.Medium;

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? AdditionalClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; } = null!;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        // validate position, start or end
        if (Position != Positions.Start && Position != Positions.End)
            throw new InvalidOperationException("OffCanvas Position must be either Start or End.");

        if (Handler is not null)
            handler = Handler;
        else
            handler ??= new();

        handler.Init(this);

        state.Closeable = Closeable ?? true;
        state.Modal = Modal;
        state.Position = Position;
        state.Fitting = Fitting;

        return base.SetParametersAsync(ParameterView.Empty);
    }

    public async ValueTask OpenAsync()
    {
        await OffCanvasService.OpenAsync(state);
    }

    public async ValueTask CloseAsync()
    {
        await OffCanvasService.CloseAsync(state);
    }

    private async Task BackdropClickHandler()
    {
        if (Closeable is null || Closeable.Value)
            await CloseAsync();
    }
	
}
