using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed partial class CheckField : CheckFieldBase
{
    private const string CssScopeAttribute = "b-checkbox-field";

    private static readonly Dictionary<string, object> AdditionalContainerAttributes = new()
    {
        {CssScopeAttribute, true}
    };

    private readonly RenderFragment contentFragment;
    private ElementReference InputReference;
    private bool isFocused;
    private bool blurListenerAdded;

    public CheckField()
    {
        contentFragment = BuildContent;
    }

    private CssClassMap FormCssClasses => CssClassMap.Create("form-check")
        .Add(() => ModelContext.ContainerState.UsingContainer, "within-container")
        .Add(() => Reverse, "form-check-reverse");
    
    private CssClassMap InputCssClasses => CssClassMap.Create("form-check-input")
        .Add(() => InputAdditionalClasses)
        .Add(() => IsInvalid, "is-invalid");

    private CssClassMap LabelCssClasses => CssClassMap.Create("form-check-label")
        .Add(() => LabelAdditionalClasses);

    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    [Inject]
    public FormsJsModule Js { get; set; } = null!;

    [Parameter]
    public string? LabelAdditionalClasses { get; set; }

    [Parameter]
    public string? InputAdditionalClasses { get; set; }

    [Parameter]
    public bool Reverse { get; set; }

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
        builder.AddAttribute(1, "class", FormCssClasses);
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
            builder.AddAttribute(5 + index, "class", InputCssClasses);
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
            builder.AddElementReferenceCapture(15 + index, __inputReference => InputReference = __inputReference);

            builder.CloseElement();
        }
        else
        {
            InputReference = default;
        }

        return index + 16;
    }

    private int RenderLabel(RenderTreeBuilder builder, int index)
    {
        if (Label is not null)
        {
            builder.OpenElement(index, "label");
            builder.AddAttribute(1 + index, "class", LabelCssClasses);
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
        if (string.IsNullOrEmpty(InputReference.Id))
        {
            if (blurListenerAdded)
                blurListenerAdded = false;
        }
        else if (!blurListenerAdded)
        {
            await Js.BlurOnPressEnterAsync(InputReference);
            blurListenerAdded = true;
        }
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
