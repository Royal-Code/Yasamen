using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.ValueSets;

public class BorderValueSet : ValueSet<Borders>
{
	public BorderValueSet()
	{
        Add(new ValueDescription<Borders>("Default", Borders.Default));
        Add(new ValueDescription<Borders>("Rounded", Borders.DefaultRounded));
        Add(new ValueDescription<Borders>("With Shadow", Borders.DefaultWithShadow));
        Add(new ValueDescription<Borders>("Rounded With Shadow", Borders.DefaultRoundedWithShadow));
        Add(new ValueDescription<Borders>("For Headers", Borders.DefaultForHeaders));
        Add(new ValueDescription<Borders>("For Headers With Shadow", Borders.DefaultForHeaders with { Shadow = Shadows.Small }));
        Add(new ValueDescription<Borders>("For Footers", Borders.DefaultForFooters));
        Add(new ValueDescription<Borders>("None", Borders.DefaultNone));
    }
}
