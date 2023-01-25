using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Layout;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract partial class SelectFieldBase<TValue> : FieldBase<TValue>
{
    protected const string CssScopeAttribute = "b-select-field";

    protected static readonly Dictionary<string, object> AdditionalContainerAttributes = new()
    {
        {CssScopeAttribute, true}
    };
    
    private readonly RenderFragment contentFragment;
    private readonly bool isMultipleSelect;
    private readonly bool isArray;
    private bool isFocused;
    protected ElementReference selectReference;

    public SelectFieldBase()
    {
        contentFragment = BuildContent;
        isArray = typeof(TValue).IsArray;
        isMultipleSelect = isArray || typeof(TValue) == typeof(IEnumerable<string>);
    }

    private CssClassMap LabelCssClasses => CssClassMap.Create("form-label")
        .Add(() => LabelAdditionalClasses);
    
    private CssClassMap SelectCssClasses => CssClassMap.Create("form-select")
        .Add(() => SelectAdditionalClasses)
        .Add(() => InternalSelectClasses)
        .Add(() => IsInvalid, "is-invalid")
        .Add(() => IsLoading, "is-loading");

    private CssClassMap InputGroupCssClasses => CssClassMap.Create("input-group")
        .Add(() => IsLoading, "is-loading");
    
    protected virtual bool HasInputGroup => Prepend.IsNotEmptyFragment() || Append.IsNotEmptyFragment();

    protected virtual bool IsLoading => ModelContext.ContainerState.IsLoading;
        
    protected string? InternalSelectClasses { get; set; }
    
    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    [Inject]
    public FormsJsModule Js { get; set; } = null!;

    [Parameter]
    public string? LabelAdditionalClasses { get; set; }
    
    [Parameter]
    public string? SelectAdditionalClasses { get; set; }

    [Parameter]
    public RenderFragment? Prepend { get; set; }

    [Parameter]
    public RenderFragment? Append { get; set; }

    [Parameter]
    public string NoItemsPlaceholder { get; set; }
    
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
            builder.AddAttribute(1 + index, "class", InputGroupCssClasses);
            builder.AddAttribute(2 + index, CssScopeAttribute);

            index += 3;
        }

        index = RenderPrepend(builder, index);
        index = RenderSelect(builder, index);
        index = RenderAppend(builder, index);

        if (hasInputGroup)
        {
            builder.CloseElement();
        }

        index = RenderLoading(builder, index);

        index = RenderFieldMessages(builder, index);
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
            builder.AddAttribute(2 + index, "class", LabelCssClasses);
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

    protected virtual int RenderSelect(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index, "select");
        
        builder.AddMultipleAttributes(1 + index, AdditionalAttributes);
        builder.AddAttribute(2 + index, "id", FieldId);
        builder.AddAttribute(3 + index, "name", FieldName);
        builder.AddAttribute(3, "multiple", isMultipleSelect);
        builder.AddAttribute(5 + index, "class", SelectCssClasses);
        builder.AddAttribute(6 + index, CssScopeAttribute);

        if (isMultipleSelect)
        {
            builder.AddAttribute(7 + index, "value", BindConverter.FormatValue(CurrentValue)?.ToString());
            builder.AddAttribute(8 + index, "onchange", EventCallback.Factory.CreateBinder<string?[]?>(this, SetCurrentValueAsStringArray, default));
        }
        else
        {
            builder.AddAttribute(9 + index, "value", CurrentValueAsString);
            builder.AddAttribute(10 + index, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, default));
        }

        builder.AddAttribute(11 + index, "onfocus", EventCallback.Factory.Create(this, OnFocus));
        builder.AddAttribute(12 + index, "onblur", EventCallback.Factory.Create(this, OnBlur));
        builder.AddAttribute(13 + index, "onmouseout", EventCallback.Factory.Create(this, OnMouseOut));
        builder.AddAttribute(14 + index, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
        if (IsInvalid)
            builder.AddAttribute(16 + index, "aria-invalid", true);
        builder.AddElementReferenceCapture(17 + index, __ref => selectReference = __ref);

        index = RenderOptions(builder, 18 + index);
        
        builder.CloseElement();
        
        return index;
    }

    protected abstract int RenderOptions(RenderTreeBuilder builder, int index);
    
    protected virtual int RenderLoading(RenderTreeBuilder builder, int index)
    {
        if (!IsLoading)
            return index + 5;

        builder.OpenElement(index, "div");
        builder.AddAttribute(1 + index, "class", "form-loading");
        builder.AddAttribute(2 + index, CssScopeAttribute);
        builder.OpenComponent<ProgressBar>(3 + index);
        builder.AddAttribute(4 + index, "CurrentValue", 100);
        builder.CloseComponent();
        builder.CloseElement();

        return index + 5;
    }
    
    protected virtual int RenderNoItemsPlaceholder(RenderTreeBuilder builder, int index)
    {
        if (NoItemsPlaceholder is not null)
        {
            builder.OpenElement(index, "option");
            builder.AddAttribute(1 + index, "value", string.Empty);
            builder.AddAttribute(2 + index, "disabled", true);
            builder.AddAttribute(3 + index, "selected", true);
            builder.AddAttribute(4 + index, "hidden", true);
            builder.AddContent(5 + index, NoItemsPlaceholder);
            builder.CloseElement();
        }
        return index + 6;
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

    protected virtual void RenderEnd(RenderTreeBuilder builder, int index) { }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Js.BlurOnPressEnterAsync(selectReference);
        }
    }

    private void SetCurrentValueAsStringArray(string?[]? value)
    {
        CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
            ? result
            : default;
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
