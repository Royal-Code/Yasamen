using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Layout;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract partial class InputFieldBase<TValue> : FieldBase<TValue>
{
    protected const string CssScopeAttribute = "b-input-field";

    protected static readonly Dictionary<string, object> AdditionalContainerAttributes = new()
    {
        {CssScopeAttribute, true}
    };

    private readonly RenderFragment contentFragment;
    private bool isFocused;

    public InputFieldBase()
    {
        contentFragment = BuildContent;
    }

    private CssClassMap InputCssClasses => CssClassMap.Create("form-control")
        .Add(() => InputAdditionalClasses)
        .Add(() => InternalInputClasses)
        .Add(() => IsInvalid, "is-invalid");

    protected virtual bool HasInputGroup => Prepend.IsNotEmptyFragment() || Append.IsNotEmptyFragment();

    protected string? InternalInputClasses { get; set; }

    protected virtual string FieldType => Type.ToString().ToLower();

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

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter] 
    public string? ParsingErrorMessage { get; set; } = string.Empty;

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

    protected virtual void BuildContent(RenderTreeBuilder builder)
    {
        var index = RenderBegin(builder);
        index = RenderLabel(builder, index);

        var hasInputGroup = HasInputGroup;
        if (hasInputGroup)
        {
            builder.OpenElement(index, "div");
            builder.AddAttribute(1 + index, "class", "input-group");
            builder.AddAttribute(2 + index, CssScopeAttribute);

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
            builder.AddAttribute(3 + index, CssScopeAttribute);
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
        builder.AddAttribute(4 + index, "type", FieldType);
        builder.AddAttribute(5 + index, "class", InputCssClasses);
        builder.AddAttribute(6 + index, CssScopeAttribute);

        index = RenderInputValueAndBinder(builder, index + 7);

        builder.AddAttribute(index, "onfocus", EventCallback.Factory.Create(this, OnFocus));
        builder.AddAttribute(1 + index, "onblur", EventCallback.Factory.Create(this, OnBlur));
        builder.AddAttribute(2 + index, "onmouseout", EventCallback.Factory.Create(this, OnMouseOut));
        builder.AddAttribute(3 + index, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
        if (ModelContext?.ContainerState.IsLoading ?? false)
            builder.AddAttribute(4 + index, "disabled", true);
        if (IsInvalid)
            builder.AddAttribute(5 + index, "aria-invalid", true);
        builder.AddElementReferenceCapture(6 + index, __inputReference => Element = __inputReference);

        builder.CloseElement();

        return index + 7;
    }

    protected virtual int RenderInputValueAndBinder(RenderTreeBuilder builder, int index)
    {
        builder.AddAttribute(index, "value", CurrentValueAsString);
        builder.AddAttribute(1 + index, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString ?? string.Empty));
        return index + 2;
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
        builder.OpenComponent<FieldMessages>(index);
        builder.AddAttribute(1 + index, "FieldIdentifier", FieldIdentifier);
        builder.AddAttribute(2 + index, "FieldName", FieldName);
        builder.CloseComponent();
        
        return index + 3;
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
            builder.AddAttribute(4 + index, CssScopeAttribute);
            builder.CloseElement();
        }
        return index + 5;
    }

    protected virtual void RenderEnd(RenderTreeBuilder builder, int index) { }

    protected override string GetInvalidInputErrorMessage()
    {
        return ParsingErrorMessage ?? base.GetInvalidInputErrorMessage();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Js.BlurOnPressEnterAsync(Element);
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
