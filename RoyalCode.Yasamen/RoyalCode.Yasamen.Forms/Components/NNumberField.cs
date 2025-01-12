using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace RoyalCode.Yasamen.Forms.Components;

/// <summary>
/// Input for nullable integer fields (<see cref="int"/>), using the <c>input</c> element.
/// </summary>
public sealed class NIntField : NNumberField<int> { }

/// <summary>
/// Input for nullable decimal fields (<see cref="decimal"/>), using the <c>input</c> element.
/// </summary>
public sealed class NDecimalField : NNumberField<decimal> { }

/// <summary>
/// Input for nullable <see cref="long"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class NLongField : NNumberField<long> { }

/// <summary>
/// Input for nullable <see cref="short"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class NShortField : NNumberField<short> { }

/// <summary>
/// Input for nullable <see cref="float"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class NFloatField : NNumberField<float> { }

/// <summary>
/// Input for nullable <see cref="double"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class NDoubleField : NNumberField<double> { }

/// <summary>
/// Input for nullable <see cref="byte"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class NByteField : NNumberField<byte> { }

/// <summary>
/// Base input for nullable numbers.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class NNumberField<TValue> : NumberFieldBase<TValue?>
    where TValue : INumber<TValue>
{
    [Parameter]
    public TValue Step { get; set; } = default!;

    /// <inheritdoc />
    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out TValue result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (value.IsMissing())
        {
            result = default!;
            errorMessage = null;
            return true;
        }

        return base.TryParseValue(value, out result, out errorMessage);
    }

    protected override bool HasStep()
    {
        return Step > TValue.Zero;
    }

    protected override void UpdateStepValue(bool up)
    {
        CurrentValue = (Value ?? TValue.Zero) + (up ? Step : -Step);
    }
}
