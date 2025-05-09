using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed partial class CheckField : CheckFieldBase
{
    public const string CssScopeAttribute = "b-checkbox-field";

    public static readonly Dictionary<string, object> AdditionalContainerAttributes = new()
    {
        {CssScopeAttribute, true}
    };

    private readonly RenderFragment contentFragment;
    private bool isFocused;
    private bool blurListenerAdded;

    public CheckField()
    {
        contentFragment = BuildContent;
    }

    private static readonly CssMap<CheckField> formCssClasses = Css.Map<CheckField>()
        .Add("form-check")
        .Add(static c => c.ModelContext.ContainerState.UsingContainer, "within-container")
        .Add(static c => c.Reverse, "form-check-reverse")
        .Add(static c => c.InlineSize, "form-check-large")
        .Build();

    private static readonly CssMap<CheckField> inputCssClasses = Css.Map<CheckField>()
        .Add("form-check-input")
        .Add(static c => c.InputAdditionalClasses)
        .Add(static c => c.IsInvalid, "is-invalid")
        .Build();

    private static readonly CssMap<CheckField> labelCssClasses = Css.Map<CheckField>()
        .Add("form-check-label")
        .Add(static c => c.LabelAdditionalClasses)
        .Build();

    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    [Parameter]
    public string? LabelAdditionalClasses { get; set; }

    [Parameter]
    public string? InputAdditionalClasses { get; set; }

    [Parameter]
    public bool Reverse { get; set; }

    [Parameter]
    public bool InlineSize { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (ModelContext.ContainerState.UsingContainer)
        {
            builder.OpenComponent<Column>(0);
            builder.AddAttribute(1, "ParentColumn", this);
            builder.AddAttribute(2, "AdditionalClasses", "field");
            builder.AddMultipleAttributes(3, AdditionalContainerAttributes);
            builder.AddAttribute(4, "ChildContent", contentFragment);
            builder.CloseComponent();
        }
        else
        {
            BuildContent(builder);
        }
    }

    private void BuildContent(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", formCssClasses(this));
        builder.AddAttribute(2, CssScopeAttribute);

        int index = RenderInput(builder, 3);
        index = RenderLabel(builder, index);

        index = RenderFieldMessages(builder, index);
        index = RenderLoadingState(builder, index);

        builder.CloseElement();
    }

    private int RenderInput(RenderTreeBuilder builder, int index)
    {
        if (!(ModelContext?.ContainerState.IsLoading ?? false))
        {
            builder.OpenElement(index, "input");
            builder.AddMultipleAttributes(1 + index, AdditionalAttributes);
            builder.AddAttribute(2 + index, "id", FieldId);
            builder.AddAttribute(3 + index, "name", FieldName);
            builder.AddAttribute(4 + index, "type", "checkbox");
            builder.AddAttribute(5 + index, "class", inputCssClasses(this));
            builder.AddAttribute(6 + index, CssScopeAttribute);
            builder.AddAttribute(7 + index, "checked", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(8 + index, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddAttribute(9 + index, "onfocus", EventCallback.Factory.Create(this, OnFocus));
            builder.AddAttribute(10 + index, "onblur", EventCallback.Factory.Create(this, OnBlur));
            builder.AddAttribute(11 + index, "onmouseout", EventCallback.Factory.Create(this, OnMouseOut));
            builder.AddAttribute(12 + index, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
            if (ModelContext?.ContainerState.IsLoading ?? false)
                builder.AddAttribute(13 + index, "disabled", true);
            if (IsInvalid)
                builder.AddAttribute(14 + index, "aria-invalid", true);
            builder.AddElementReferenceCapture(15 + index, __inputReference => Element = __inputReference);

            builder.CloseElement();
        }
        else
        {
            Element = default;
        }

        return index + 16;
    }

    private int RenderLabel(RenderTreeBuilder builder, int index)
    {
        if (Label is not null)
        {
            builder.OpenElement(index, "label");
            builder.AddAttribute(1 + index, "class", labelCssClasses(this));
            builder.AddAttribute(2 + index, "for", FieldId);
            builder.AddAttribute(3 + index, CssScopeAttribute);
            builder.AddAttribute(4 + index, "onfocus", EventCallback.Factory.Create(this, OnFocus));
            builder.AddAttribute(5 + index, "onblur", EventCallback.Factory.Create(this, OnBlur));
            builder.AddAttribute(6 + index, "onmouseout", EventCallback.Factory.Create(this, OnMouseOut));
            builder.AddAttribute(7 + index, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
            builder.AddContent(8 + index, Label == string.Empty ? FieldLabel : Label);
            
            builder.CloseElement();
        }
        
        return index + 9;
    }

    private int RenderFieldMessages(RenderTreeBuilder builder, int index)
    {
        builder.OpenComponent<FieldMessages>(index);
        builder.AddAttribute(1 + index, "FieldIdentifier", FieldIdentifier);
        builder.AddAttribute(2 + index, "FieldName", FieldName);
        builder.CloseComponent();

        return index + 3;
    }

    private int RenderLoadingState(RenderTreeBuilder builder, int index)
    {
        // TODO: requer adição correta das classes, segundo alinhamento, esquerda, direita...

        if (ModelContext?.ContainerState.IsLoading ?? false)
        {
            builder.OpenElement(index, "div");
            builder.AddAttribute(1 + index, "class", "spinner-border spinner-border-sm");
            builder.AddAttribute(2 + index, "role", "status");
            builder.AddAttribute(3 + index, "aria-hidden", "true");
            builder.AddAttribute(4 + index, CssScopeAttribute);
            builder.CloseElement();
        }
        return index + 5;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (string.IsNullOrEmpty(Element.Id))
        {
            if (blurListenerAdded)
                blurListenerAdded = false;
        }
        else if (!blurListenerAdded)
        {
            await Js.BlurOnPressEnterAsync();
            blurListenerAdded = true;
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private void OnFocus()
    {
        isFocused = true;
        if (IsInvalid)
            ModelContext.EditorMessages.Show(FieldIdentifier);
    }

    private void OnBlur()
    {
        isFocused = false;
        if (IsInvalid)
            ModelContext.EditorMessages.Hide(FieldIdentifier);
    }

    private void OnMouseOut()
    {
        if (IsInvalid && isFocused is false)
            ModelContext.EditorMessages.Hide(FieldIdentifier);
    }

    private void OnMouseEnter()
    {
        if (IsInvalid && isFocused is false)
            ModelContext.EditorMessages.Show(FieldIdentifier);
    }
}
