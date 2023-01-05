using RoyalCode.Yasamen.Commons.Options;
using RoyalCode.Yasamen.Icons;

namespace RoyalCode.Yasamen.Forms.Components;

public partial class SearchButton : SubmitButton
{
    private readonly Enum? searchItemKind;
    
    public SearchButton()
	{
        IsInline = true;
        CommonsOptions.Get<Icon>().TryGet<Enum>(WellKnownIcons.Search, out searchItemKind);
        Icon = searchItemKind;
    }
}
