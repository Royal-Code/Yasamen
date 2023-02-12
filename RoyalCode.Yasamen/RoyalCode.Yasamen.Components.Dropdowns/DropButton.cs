
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Components;

public class DropButton : DropBase
{
    private readonly RenderFragment renderButton;

    public DropButton()
    {
        renderButton = RenderButton;
    }

    #region Button Parameters

    [Parameter, EditorRequired]
    public string Label { get; set; } = null!;

    [Parameter]
    public ButtonType Type { get; set; }

    [Parameter]
    public ButtonStyles Style { get; set; }

    [Parameter]
    public Sizes Size { get; set; }

    [Parameter]
    public Enum? Icon { get; set; }

    [Parameter]
    public int? IconRotateAngle { get; set; }

    [Parameter]
    public bool Outline { get; set; }

    [Parameter]
    public bool Block { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool UseIconAtEnd { get; set; }

    #endregion


    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        // check if the child content is set
        if (parameters.TryGetValue(nameof(ChildContent), out RenderFragment? cc))
        {
            // if Menu is set then throw
            if (parameters.TryGetValue(nameof(Menu), out RenderFragment _))
                throw new InvalidOperationException(
                    $"The parameter '{nameof(ChildContent)}' and '{nameof(Menu)}' can not be used together in DropButton.");

            Menu = cc!;
        }

        // check if the action parameter is set
        if (parameters.TryGetValue(nameof(Action), out RenderFragment _))
            throw new InvalidOperationException($"The parameter '{nameof(Action)}' can be used in DropButton.");

        Action = renderButton;

        return base.SetParametersAsync(parameters);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
    }

    private void RenderButton(RenderTreeBuilder builder)
    {
        builder.OpenComponent<Button>(0);
        // add the button properties
        builder.AddAttribute(1, nameof(Button.Label), Label);
        builder.AddAttribute(2, nameof(Button.Type), Type);
        builder.AddAttribute(3, nameof(Button.Style), Style);
        builder.AddAttribute(4, nameof(Button.Size), Size);
        builder.AddAttribute(5, nameof(Button.Icon), Icon);
        builder.AddAttribute(6, nameof(Button.IconRotateAngle), IconRotateAngle);
        builder.AddAttribute(7, nameof(Button.Outline), Outline);
        builder.AddAttribute(8, nameof(Button.Block), Block);
        builder.AddAttribute(9, nameof(Button.Active), Active);
        builder.AddAttribute(10, nameof(Button.Disabled), Disabled);
        builder.AddAttribute(11, nameof(Button.UseIconAtEnd), UseIconAtEnd);
        // add the button events
        builder.AddAttribute(12, nameof(Button.OnClick), EventCallback.Factory.Create(this, OnClick));
        // close
        builder.CloseComponent();
    }

    private void OnClick()
    {
        if (IsOpen)
            return;
        Open();
    }
}