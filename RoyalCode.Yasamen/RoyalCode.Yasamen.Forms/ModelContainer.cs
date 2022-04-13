using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public class ModelContainer<TModel> : ComponentBase
    where TModel : class, new()
{
    [Parameter]
    public TModel Model { get; set; } = null!;

    [Parameter]
    public PropertyChangeSupport? Support { get; set; }

    [Parameter]
    public RenderFragment<TModel>? ChildContent { get; set; }

    [CascadingParameter]
    public PropertyChangeSupport? ParentPropertyChangeSupport { get; set; }

    protected override void OnParametersSet()
    {
        if (Support is null)
            Support = new PropertyChangeSupport();

        if (ParentPropertyChangeSupport is not null)
            Support.SetParent(ParentPropertyChangeSupport);

        base.OnParametersSet();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenRegion(Support!.GetHashCode());

        builder.OpenComponent<CascadingValue<PropertyChangeSupport>>(0);
        builder.AddAttribute(1, "IsFixed", true);
        builder.AddAttribute(2, "Value", Support);

        builder.AddAttribute(3, "ChildContent", ChildContent?.Invoke(Model!));

        builder.CloseComponent();

        builder.CloseRegion();
    }
}