
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract partial class InputFieldBase<TValue> : FieldBase<TValue>
{
    private readonly RenderFragment contentFragment;
    protected ElementReference InputReference;
    protected string cssScopeAttribute = "b-input-field";

    public InputFieldBase()
    {
        contentFragment = BuildContent;
    }

    private CssClassMap InputCssClasses => CssClassMap.Create("form-control")
        .Add(() => InputAdditionalClasses)
        .Add(() => IsInvalid, "is-invalid");

    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    [Inject]
    public FormsJsModule Js { get; set; } = null!;

    [Parameter]
    public InputType Type { get; set; }

    [Parameter]
    public string? LabelAdditionalClasses { get; set; }

    [Parameter]
    public string? InputAdditionalClasses { get; set; }

    [Parameter]
    public RenderFragment? Prepend { get; set; }

    [Parameter]
    public RenderFragment? Append { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (ModelContext.ContainerState.UsingContainer)
        {
            builder.OpenComponent<Column>(0);
            builder.AddAttribute(1, "ParentColumn", this);
            builder.AddAttribute(2, "ChildContent", contentFragment);
            builder.CloseComponent();
        }
        else
        {
            BuildContent(builder);
        }
    }

    private void BuildContent(RenderTreeBuilder builder)
    {
        var index = RenderBegin(builder);
        index = RenderLabel(builder, index);

        var hasInputGroup = Prepend.IsNotEmptyFragment() || Append.IsNotEmptyFragment();
        if (hasInputGroup)
        {
            builder.OpenElement(index, "div");
            builder.AddAttribute(1 + index, "class", "input-group");
            builder.AddAttribute(2 + index, cssScopeAttribute);

            index += 3;
        }

        index = RenderPrepend(builder, index);
        index = RenderInput(builder, index);
        index = RenderAppend(builder, index);

        if (hasInputGroup)
        {
            builder.CloseElement();
        }

        index = RenderFieldMessages(builder, index);
        index = RenderLoadingState(builder, index);
        RenderEnd(builder, index);
    }

    protected virtual int RenderBegin(RenderTreeBuilder builder)
    {
        return 0;
    }

    protected virtual int RenderLabel(RenderTreeBuilder builder, int index)
    {
        if (FieldLabel is not null)
        {
            builder.OpenElement(index, "label");
            builder.AddAttribute(1 + index, "for", FieldId);
            builder.AddAttribute(2 + index, "class", $"form-label {LabelAdditionalClasses}");
            builder.AddAttribute(3 + index, cssScopeAttribute);
            builder.AddContent(4 + index, FieldLabel);
            builder.CloseElement();
        }
        return index + 5;
    }

    protected virtual int RenderPrepend(RenderTreeBuilder builder, int index)
    {
        if (Prepend.IsNotEmptyFragment())
        {
            builder.AddContent(index, Prepend);
        }
        return index + 1;
    }

    protected virtual int RenderInput(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index, "input");
        builder.AddMultipleAttributes(1 + index, AdditionalAttributes);
        builder.AddAttribute(2 + index, "id", FieldId);
        builder.AddAttribute(3 + index, "name", FieldName);
        builder.AddAttribute(4 + index, "type", Type.ToString().ToLower());
        builder.AddAttribute(5 + index, "class", InputCssClasses);
        builder.AddAttribute(6 + index, cssScopeAttribute);
        builder.AddAttribute(7 + index, "value", CurrentValueAsString);
        builder.AddAttribute(8 + index, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString ?? string.Empty));
        if (ModelContext?.ContainerState.IsLoading ?? false)
            builder.AddAttribute(9 + index, "disabled", true);
        if (IsInvalid)
            builder.AddAttribute(10 + index, "aria-invalid", true);
        builder.AddElementReferenceCapture(11 + index, __inputReference => InputReference = __inputReference);

        
        builder.CloseElement();

        return index + 12;
    }

    protected virtual int RenderAppend(RenderTreeBuilder builder, int index)
    {
        if (Append.IsNotEmptyFragment())
        {
            builder.AddContent(index, Append);
        }
        return index + 1;
    }

    protected virtual int RenderFieldMessages(RenderTreeBuilder builder, int index)
    {
        // TODO: requer FieldMessages...

        return index;
    }

    protected virtual int RenderLoadingState(RenderTreeBuilder builder, int index)
    {
        // TODO: requer adição correta das classes, segundo alinhamento, esquerda, direita...
        
        if (ModelContext?.ContainerState.IsLoading ?? false)
        {
            builder.OpenElement(index, "div");
            builder.AddAttribute(1 + index, "class", "spinner-border spinner-border-sm");
            builder.AddAttribute(2 + index, "role", "status");
            builder.AddAttribute(3 + index, "aria-hidden", "true");
            builder.AddAttribute(4 + index, cssScopeAttribute);
            builder.CloseElement();
        }
        return index + 5;
    }

    protected virtual void RenderEnd(RenderTreeBuilder builder, int index) { }
}
