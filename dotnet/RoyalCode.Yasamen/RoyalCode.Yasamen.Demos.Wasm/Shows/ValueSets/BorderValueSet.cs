using RoyalCode.Yasamen.BlazorShow;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.ValueSets;

public class BorderValueSet : ValueSet<BorderClasses>
{
	public BorderValueSet()
	{
        Add(new ValueDescription<BorderClasses>("Box", Css.Border.Box()));
        Add(new ValueDescription<BorderClasses>("Rounded", Css.Border.BoxRounded()));
        Add(new ValueDescription<BorderClasses>("With Shadow", Css.Border.BoxWithShadow()));
        Add(new ValueDescription<BorderClasses>("Rounded With Shadow", Css.Border.BoxRoundedWithShadow()));
        Add(new ValueDescription<BorderClasses>("For Headers", Css.Border.Header()));
        Add(new ValueDescription<BorderClasses>("For Headers With Shadow", Css.Border.HeaderWithShadow()));
        Add(new ValueDescription<BorderClasses>("For Footers", Css.Border.Footer()));
        Add(new ValueDescription<BorderClasses>("For Footers With Shadow", Css.Border.FooterWithShadow()));
        Add(new ValueDescription<BorderClasses>("None", Css.Border.None()));
    }
}
