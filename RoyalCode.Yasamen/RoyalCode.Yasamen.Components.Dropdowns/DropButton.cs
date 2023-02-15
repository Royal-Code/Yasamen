
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
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

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    #endregion

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public bool Split { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        // check if the child content is set
        if (parameters.TryGetValue(nameof(ChildContent), out RenderFragment? cc))
        {
            // if Menu is set then throw
            if (parameters.TryGetValue(nameof(DropContent), out RenderFragment? _))
                throw new InvalidOperationException(
                    $"The parameter '{nameof(ChildContent)}' and '{nameof(DropContent)}' can not be used together in DropButton.");

            DropContent = cc!;
        }

        // check if OnClick are set and the button is not split
        if (!Split && parameters.TryGetValue(nameof(OnClick), out object? _))
            throw new InvalidOperationException($"The parameter '{nameof(OnClick)}' only can be used when Split is true");

        // check if the action parameter is set
        if (parameters.TryGetValue(nameof(Action), out RenderFragment _))
            throw new InvalidOperationException($"The parameter '{nameof(Action)}' can not be used in DropButton.");

        Action = renderButton;

        return base.SetParametersAsync(parameters);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
    }

    private void RenderButton(RenderTreeBuilder builder)
    {
        if (Split && Direction == DropDirection.Left) 
        {
            RenderSplitButton(builder, 0);
        }

        builder.OpenRegion(9);

        builder.OpenComponent<Button>(10);
        // add the button properties
        builder.AddAttribute(11, nameof(Button.Label), Label);
        builder.AddAttribute(12, nameof(Button.Type), Type);
        builder.AddAttribute(13, nameof(Button.Style), Style);
        builder.AddAttribute(14, nameof(Button.Size), Size);
        builder.AddAttribute(15, nameof(Button.Icon), Icon);
        builder.AddAttribute(16, nameof(Button.IconRotateAngle), IconRotateAngle);
        builder.AddAttribute(17, nameof(Button.Outline), Outline);
        builder.AddAttribute(18, nameof(Button.Block), Block);
        builder.AddAttribute(19, nameof(Button.Active), Active);
        builder.AddAttribute(20, nameof(Button.Disabled), Disabled);
        builder.AddAttribute(21, nameof(Button.UseIconAtEnd), UseIconAtEnd);
        if (!Split)
        {
            Console.WriteLine("Add additional classes drop-button");

            // add arrow
            builder.AddAttribute(22, nameof(Button.AdditionalClasses), "drop-button");
            // add the button events
            builder.AddAttribute(23, nameof(Button.OnClick), EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler));
        }
        else
        {
            Console.WriteLine("Add additional classes drop-button-split");
            builder.AddAttribute(22, nameof(Button.AdditionalClasses), "drop-button-split");
            builder.AddAttribute(23, nameof(Button.OnClick), OnClick);
        }
        // close
        builder.CloseComponent();
        builder.CloseRegion();

        if (Split && Direction != DropDirection.Left)
        {
            RenderSplitButton(builder, 24);
        }
    }

    private void RenderSplitButton(RenderTreeBuilder builder, int start)
    {
        builder.OpenComponent<Button>(start);
        // add the button properties
        builder.AddAttribute(1 + start, nameof(Button.Style), Style);
        builder.AddAttribute(2 + start, nameof(Button.Size), Size);
        builder.AddAttribute(3 + start, nameof(Button.Outline), Outline);
        builder.AddAttribute(4 + start, nameof(Button.Active), Active);
        builder.AddAttribute(5 + start, nameof(Button.Disabled), Disabled);
        builder.AddAttribute(6 + start, nameof(Button.AdditionalClasses), "drop-button");
        builder.AddAttribute(7 + start, nameof(Button.OnClick), EventCallback.Factory.Create<MouseEventArgs>(this, OnClickHandler));
        builder.AddAttribute(8 + start, nameof(Button.ChildContent), RenderToggleDropdownSpan);
        builder.CloseComponent();
    }

    private static readonly RenderFragment RenderToggleDropdownSpan = (RenderTreeBuilder builder) =>
    {
        //<span class=\"visually-hidden\">Toggle Dropdown</span>
        builder.OpenElement(0, "span");
        builder.AddAttribute(1, "class", "visually-hidden");
        builder.AddContent(2, "Toggle Dropdown");
        builder.CloseElement();
    };

    private void OnClickHandler(MouseEventArgs args)
    {
        if (IsOpen)
            return;

        Tracer.Write<DropButton>("OnClick", "Open the drop.");
        Open();
    }
}