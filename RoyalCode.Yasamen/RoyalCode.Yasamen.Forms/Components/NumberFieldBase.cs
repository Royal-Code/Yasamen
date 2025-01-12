using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Commons.Options;
using RoyalCode.Yasamen.Icons;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable S3963 // "static" fields should be initialized inline
#pragma warning disable S3877 // Exceptions should not be thrown from unexpected methods

namespace RoyalCode.Yasamen.Forms.Components;

public abstract class NumberFieldBase<TValue> : InputFieldBase<TValue>
{
    protected static readonly bool IsInteger = typeof(TValue) == typeof(int) ||
            typeof(TValue) == typeof(long) ||
            typeof(TValue) == typeof(short) ||
            typeof(TValue) == typeof(byte);

    private string format = default!;

    protected override bool HasInputGroup => HasStep() || base.HasInputGroup;

    [Parameter]
    public string? Format { get; set; }

    [Parameter]
    public int Decimals { get; set; }

    protected override void OnParametersSet()
    {
        format = Format!;
        if (format is null)
        {
            if (IsInteger)
            {
                format = "#,##0";
            }
            else if (Decimals > 0)
            {
                format = "#,##0.".PadRight(6 + Decimals, '0');
            }
        }

        if (string.IsNullOrEmpty(InputAdditionalClasses))
            InternalInputClasses = "numeric";
        else if (InputAdditionalClasses.IndexOf("numeric") == -1)
            InternalInputClasses += " numeric";

        if (ParsingErrorPattern.IsMissing())
            ParsingErrorPattern = IsInteger
                ? "The {0} field must be an integer"
                : "The {0} field must be numeric";
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out TValue result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (value.TryParseValueFromString<TValue>(out var parseResult))
        {
            result = parseResult;
            errorMessage = null;
            return true;
        }
        else
        {
            result = default;
            errorMessage = GetInvalidInputErrorMessage();
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override string? FormatValue(TValue? value) => value.FormatNumberAsString(format);

    protected override int RenderPrepend(RenderTreeBuilder builder, int index)
    {
        if (HasStep())
        {
            if (CommonsOptions.Get<Icon>().TryGet<Enum>(WellKnownIcons.Minus, out var icon))
            {
                builder.OpenComponent<FieldButton>(index);
                builder.AddAttribute(1 + index, "Icon", icon);
                builder.AddAttribute(2 + index, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, StepDown));
                builder.AddAttribute(3 + index, "disabled", Disabled);
                builder.CloseComponent();
            }
            else
            {
                builder.OpenComponent<FieldAddon>(4 + index);
                builder.AddAttribute(5 + index, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, StepDown));
                builder.AddAttribute(6 + index, "AdditionalClasses", "pointer");
                builder.AddAttribute(7 + index, "disabled", Disabled);
                builder.AddAttribute(8 + index, "ChildContent", (RenderFragment)(b =>
                {
                    b.AddContent(9, "-");
                }));
                builder.CloseComponent();
            }
        }

        return base.RenderPrepend(builder, index + 10);
    }

    protected override int RenderAppend(RenderTreeBuilder builder, int index)
    {
        if (HasStep())
        {
            if (CommonsOptions.Get<Icon>().TryGet<Enum>(WellKnownIcons.Plus, out var icon))
            {
                builder.OpenComponent<FieldButton>(index);
                builder.AddAttribute(1 + index, "Icon", icon);
                builder.AddAttribute(2 + index, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, StepUp));
                builder.AddAttribute(3 + index, "disabled", Disabled);
                builder.CloseComponent();
            }
            else
            {
                builder.OpenComponent<FieldAddon>(4 + index);
                builder.AddAttribute(5 + index, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, StepUp));
                builder.AddAttribute(6 + index, "AdditionalClasses", "pointer");
                builder.AddAttribute(7 + index, "disabled", Disabled);
                builder.AddAttribute(8 + index, "ChildContent", (RenderFragment)(b =>
                {
                    b.AddContent(9, "+");
                }));
                builder.CloseComponent();
            }
        }

        return base.RenderAppend(builder, index + 10);
    }

    protected abstract bool HasStep();

    protected virtual void StepDown()
    {
        UpdateStepValue(false);
    }

    protected virtual void StepUp()
    {
        UpdateStepValue(true);
    }

    protected abstract void UpdateStepValue(bool up);
}