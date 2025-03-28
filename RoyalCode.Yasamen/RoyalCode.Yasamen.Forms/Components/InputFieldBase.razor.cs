﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public static class InputFieldShared
{
    public const string CssScopeAttribute = "b-input-field";

    public static readonly Dictionary<string, object> AdditionalContainerAttributes = new()
    {
        {CssScopeAttribute, true}
    };
}

public abstract partial class InputFieldBase<TValue> : FieldBase<TValue>
{
    private readonly RenderFragment contentFragment;
    private bool isFocused;
    private bool hasDisableAttribute;

    protected InputFieldBase()
    {
        contentFragment = BuildContent;
    }

    private static readonly CssMap<InputFieldBase<TValue>> inputCssClasses = Css.Map<InputFieldBase<TValue>>()
        .Add("form-control")
        .Add(static i => i.InputAdditionalClasses)
        .Add(static i => i.InternalInputClasses)
        .Add(static i => i.IsInvalid, "is-invalid")
        .Build();

    protected virtual bool HasInputGroup => Prepend.IsNotEmptyFragment() || Append.IsNotEmptyFragment();

    protected string? InternalInputClasses { get; set; }

    protected virtual string FieldType => Type.ToString().ToLower();

    protected virtual bool Disabled => hasDisableAttribute;

    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

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

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        hasDisableAttribute = AdditionalAttributes?.TryGetValue("disabled", out _) ?? false;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (ModelContext.ContainerState.UsingContainer)
        {
            builder.OpenComponent<Column>(0);
            builder.AddAttribute(1, "ParentColumn", this);
            builder.AddAttribute(2, "AdditionalClasses", "field");
            builder.AddMultipleAttributes(3, InputFieldShared.AdditionalContainerAttributes);
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
            builder.AddAttribute(2 + index, InputFieldShared.CssScopeAttribute);

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
            builder.AddAttribute(3 + index, InputFieldShared.CssScopeAttribute);
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
        builder.AddAttribute(5 + index, "class", inputCssClasses(this));
        builder.AddAttribute(6 + index, InputFieldShared.CssScopeAttribute);

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
        builder.AddAttribute(1 + index, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
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
            builder.AddAttribute(4 + index, InputFieldShared.CssScopeAttribute);
            builder.CloseElement();
        }
        return index + 5;
    }

    protected virtual void RenderEnd(RenderTreeBuilder builder, int index) { }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Js.BlurOnPressEnterAsync();
        }

        await base.OnAfterRenderAsync(firstRender);
    }
    
    protected virtual async Task OnFocus()
    {
        isFocused = true;
        if (IsInvalid)
            ModelContext.EditorMessages.Show(FieldIdentifier);

        await Js.SelectTextAsync();
    }

    protected virtual void OnBlur()
    {
        isFocused = false;
        if (IsInvalid)
            ModelContext.EditorMessages.Hide(FieldIdentifier);
    }

    protected virtual void OnMouseOut()
    {
        if (IsInvalid && !isFocused)
            ModelContext.EditorMessages.Hide(FieldIdentifier);
    }

    protected virtual void OnMouseEnter()
    {
        if (IsInvalid && !isFocused)
            ModelContext.EditorMessages.Show(FieldIdentifier);
    }
}
