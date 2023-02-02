using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Commons.Options;
using RoyalCode.Yasamen.Icons;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class IntNullField : NumberField<int> { }
public sealed class IntField : NumberField<int> { }
public sealed class DecimalField : NumberField<decimal> { }
public sealed class LongField : NumberField<long> { }
public sealed class ShortField : NumberField<short> { }
public sealed class FloatField : NumberField<float> { }
public sealed class DoubleField : NumberField<double> { }
public sealed class ByteField : NumberField<byte> { }


public class NumberField<TValue> : InputFieldBase<TValue>
    where TValue : INumber<TValue>
{
    protected override bool HasInputGroup => HasStep() || base.HasInputGroup;

    [Parameter]
    public TValue Step { get; set; } = default!;

    [Parameter]
    public string? Format { get; set; }

    [Parameter]
    public int Decimals { get; set; }

    protected override void OnParametersSet()
    {
        if (Format == null)
        {
            if (typeof(TValue) == typeof(short) || typeof(TValue) == typeof(int) || typeof(TValue) == typeof(long))
            {
                Format = "#,##0";
            }
            else if (Decimals > 0)
            {
                Format = "#,##0.".PadRight(6 + Decimals, '0');
            }
        }

        if (string.IsNullOrEmpty(InputAdditionalClasses))
            InternalInputClasses = "numeric";
        else if (InputAdditionalClasses.IndexOf("numeric") == -1)
            InternalInputClasses += " numeric";
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
            errorMessage = ParsingErrorMessage is not null
                ? string.Format(ParsingErrorMessage, FieldLabel)
                : InvalidInputErrorMessage;
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override string? FormatValue(TValue? value) => value.FormatNumberAsString(Format);

    protected override int RenderPrepend(RenderTreeBuilder builder, int index)
    {
        if (HasStep())
        {
            if (CommonsOptions.Get<Icon>().TryGet<Enum>(WellKnownIcons.Minus, out var icon))
            {
                builder.OpenComponent<FieldButton>(index);
                builder.AddAttribute(1 + index, "Icon", icon);
                builder.AddAttribute(2 + index, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, StepDown));
                builder.CloseComponent();
            }
            else
            {
                builder.OpenComponent<FieldAddon>(3 + index);
                builder.AddAttribute(4 + index, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, StepDown));
                builder.AddAttribute(5 + index, "AdditionalClasses", "pointer");
                builder.AddAttribute(6 + index, "ChildContent", (RenderFragment)(b =>
                {
                    b.AddContent(7, "-");
                }));
                builder.CloseComponent();
            }
        }

        return base.RenderPrepend(builder, index + 8);
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
                builder.CloseComponent();
            }
            else
            {
                builder.OpenComponent<FieldAddon>(3 + index);
                builder.AddAttribute(4 + index, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, StepUp));
                builder.AddAttribute(5 + index, "AdditionalClasses", "pointer");
                builder.AddAttribute(6 + index, "ChildContent", (RenderFragment)(b =>
                {
                    b.AddContent(7, "+");
                }));
                builder.CloseComponent();
            }
        }

        return base.RenderAppend(builder, index + 8);
    }

    protected virtual bool HasStep()
    {
        return Step > TValue.Zero;
    }

    protected virtual void StepDown()
    {
        UpdateStepValue(false);
    }

    protected virtual void StepUp()
    {
        UpdateStepValue(true);
    }

    protected virtual void UpdateStepValue(bool up)
    {
        CurrentValue = (Value ?? TValue.Zero) + (up ? Step : -Step);
    }
}