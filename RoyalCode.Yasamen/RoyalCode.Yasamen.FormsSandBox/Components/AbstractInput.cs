
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract partial class AbstractInput<TValue> : FieldBase<TValue>
{
    private CssClassMap InputCssClasses => CssClassMap.Create("form-control")
        .Add(() => InputAdditionalClasses)
        .Add(() => IsInvalid, "is-invalid");

    protected ElementReference InputReference;

    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    [Inject]
    public FormsJsModule Js { get; set; }

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
        var index = RenderBegin(builder);
        index = RenderLabel(builder, index);

        var hasInputGroup = Prepend.IsNotEmptyFragment() || Append.IsNotEmptyFragment();
        if (hasInputGroup)
        {
            builder.OpenElement(index, "div");
            builder.AddAttribute(1 + index, "class", "input-group");

            index += 2;
        }

        index = RenderPrepend(builder, index);
        index = RenderInput(builder, index);
        index = RenderAppend(builder, index);

        if(hasInputGroup)
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
            builder.AddContent(3 + index, FieldLabel);
            builder.CloseElement();
        }
        return index + 4;
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
        builder.AddAttribute(1 + index, "id", FieldId);
        builder.AddAttribute(2 + index, "name", FieldName);
        builder.AddAttribute(3 + index, "type", Type.ToString().ToLower());
        builder.AddAttribute(4 + index, "class", InputCssClasses);
        builder.AddAttribute(5 + index, "value", CurrentValueAsString);
        builder.AddAttribute(6 + index, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString ?? string.Empty));
        if (ModelContext?.ContainerState.IsLoading ?? false)
        {
            builder.AddAttribute(7 + index, "disabled", true);
        }
        builder.AddElementReferenceCapture(8 + index, __inputReference => InputReference = __inputReference);
        builder.AddMultipleAttributes(9 + index, AdditionalAttributes);
        builder.CloseElement();

        return index + 10;
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
            builder.CloseElement();
        }
        return index + 4;
    }

    protected virtual void RenderEnd(RenderTreeBuilder builder, int index) { }
}

// TODO: Mover para layout
public class ColumnSizes : IHasColumnSizes
{
    public int Cols { get; set; }

    public int? TabletCols { get; set; }

    public int? PhoneCols { get; set; }

    public int? Quarters { get; set; }

    public int? XsCols { get; set; }

    public int? SmCols { get; set; }

    public int? LgCols { get; set; }

    public int? XlCols { get; set; }

    public bool Fullsize { get; set; }

    public bool XsFullsize { get; set; }

    public bool SmFullsize { get; set; }

    public bool LgFullsize { get; set; }

    public bool XlFullsize { get; set; }
}
