
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Components;

public sealed class DropIcon : DropBase
{
    private readonly RenderFragment renderButton;
    private readonly EventCallback<MouseEventArgs> onClickHandler;

    public DropIcon()
    {
        renderButton = RenderButton;
        onClickHandler = EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler);
    }

    #region Icon Button Parameters

    [Parameter, EditorRequired]
    public Enum Kind { get; set; } = default!;

    [Parameter]
    public ButtonType Type { get; set; }

    [Parameter]
    public ButtonStyles Style { get; set; }

    [Parameter]
    public Sizes Size { get; set; }

    [Parameter]
    public bool Outline { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    #endregion

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        // check if the child content is set
        if (parameters.TryGetValue(nameof(ChildContent), out RenderFragment? cc))
        {
            // if DropContent is set then throw
            if (parameters.TryGetValue(nameof(DropContent), out RenderFragment? _))
                throw new InvalidOperationException(
                    $"The parameter '{nameof(ChildContent)}' and '{nameof(DropContent)}' can not be used together in DropIcon.");

            DropContent = cc!;
        }

        // check if the action parameter is set
        if (parameters.TryGetValue(nameof(Action), out RenderFragment? _))
            throw new InvalidOperationException($"The parameter '{nameof(Action)}' can not be used in DropIcon.");

        Action = renderButton;

        return base.SetParametersAsync(parameters);
    }

    private void RenderButton(RenderTreeBuilder builder)
    {
        builder.OpenComponent<IconButton>(0);
        builder.AddAttribute(1, nameof(IconButton.Kind), Kind);
        builder.AddAttribute(2, nameof(IconButton.Type), Type);
        builder.AddAttribute(3, nameof(IconButton.Style), Style);
        builder.AddAttribute(4, nameof(IconButton.Size), Size);
        builder.AddAttribute(5, nameof(IconButton.Outline), Outline);
        builder.AddAttribute(6, nameof(IconButton.Active), Active);
        builder.AddAttribute(7, nameof(IconButton.Disabled), Disabled);
        builder.AddAttribute(8, nameof(IconButton.OnClick), onClickHandler);
        builder.AddAttribute(9, nameof(Button.AdditionalClasses), "drop-icon-button");
        builder.CloseComponent();
    }

    private async Task OnClickHandler(MouseEventArgs args)
    {
        if (IsOpen)
            return;

        Tracer.Write<DropButton>("OnClick", "Open the drop.");
        Open();

        await OnClick.InvokeAsync(args);
    }
}
