using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace RoyalCode.Yasamen.Forms.Components;

/// <summary>
/// Input for integer fields (<see cref="int"/>), using the <c>input</c> element.
/// </summary>
public sealed class IntField : NumberField<int> { }

/// <summary>
/// Input for decimal fields (<see cref="decimal"/>), using the <c>input</c> element.
/// </summary>
public sealed class DecimalField : NumberField<decimal> { }

/// <summary>
/// Input for <see cref="long"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class LongField : NumberField<long> { }

/// <summary>
/// Input for <see cref="short"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class ShortField : NumberField<short> { }

/// <summary>
/// Input for <see cref="float"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class FloatField : NumberField<float> { }

/// <summary>
/// Input for <see cref="double"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class DoubleField : NumberField<double> { }

/// <summary>
/// Input for <see cref="byte"/> fields, using the <c>input</c> element.
/// </summary>
public sealed class ByteField : NumberField<byte> { }

/// <summary>
/// Base input for numbers.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class NumberField<TValue> : NumberFieldBase<TValue>
    where TValue : INumber<TValue>
{
    [Parameter]
    public TValue Step { get; set; } = default!;

    protected override bool HasStep()
    {
        return Step > TValue.Zero;
    }

    protected override void UpdateStepValue(bool up)
    {
        CurrentValue = (Value ?? TValue.Zero) + (up ? Step : -Step);
    }
}