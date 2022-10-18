using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Flex;

public class FlexModelEditor<TModel> : ModelEditor<TModel>
{
    protected override RenderFragment ContentFragment()
    {
        return builder =>
        {
            builder.OpenComponent<Container>(0);
            builder.AddContent(1, base.ContentFragment());
            builder.CloseComponent();
        };
    }
}
