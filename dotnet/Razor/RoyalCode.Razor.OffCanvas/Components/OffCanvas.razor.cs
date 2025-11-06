using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public partial class OffCanvas
{
    private OffCanvasHandler handler = null!;

    public bool IsVisible { get; private set; }

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

        return base.SetParametersAsync(ParameterView.Empty);
    }

    public async ValueTask Show()
    {
        if (IsVisible)
            return;

        IsVisible = true;
        await Toogle();
    }

    public async ValueTask Hide()
    {
        if (!IsVisible)
            return;

        IsVisible = false;
        await Toogle();
    }

    private async ValueTask Toogle()
    {
        if (OnVisibilityChanged.HasDelegate)
            await OnVisibilityChanged.InvokeAsync(IsVisible);

        await InvokeAsync(StateHasChanged);
    }

    private async Task BackdropClickHandler()
    {
        if (Closeable is null || Closeable.Value)
            await Hide();
    }
}
