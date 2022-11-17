using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.PropertyRenders;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components;

public class PropertyValueRender : ComponentBase
{
    [CascadingParameter]
    public SceneContext Context { get; set; }

    [Parameter, EditorRequired]
    public IScenePropertyDescription Property { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Console.WriteLine("BuildRenderTree PropertyValueRender");

        if (Property.IsHtmlClasses)
            RenderClasses(builder);

        else if (Property.IsHtmlAttributes)
            RenderAttributes(builder);

        else if (Property.IsFragment)
            RenderFragmentProperty(builder);

        else if (Property.IsHidden)
            return;

        else if (Property.IsStringType())
            RenderText(builder);

        else if (Property.IsNumberType())
            RenderNumber(builder);

        else if (Property.IsEnum())
            RenderEnum(builder);

        else if (Property.IsBoolType())
            RenderBool(builder);

        else
            RenderCustom(builder);
    }

    private void RenderCustom(RenderTreeBuilder builder)
    {
        builder.OpenRegion(0);
        builder.AddContent(1, Property.Property.PropertyType.Name);
        builder.CloseRegion();
    }

    private void RenderBool(RenderTreeBuilder builder)
    {
        builder.OpenComponent(0, typeof(BoolProperty));
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderText(RenderTreeBuilder builder)
    {
        builder.OpenComponent(0, typeof(TextProperty));
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderNumber(RenderTreeBuilder builder)
    {
        RenderCustom(builder);
        return;
        throw new NotImplementedException();
    }

    private void RenderAttributes(RenderTreeBuilder builder)
    {
        builder.OpenComponent(0, typeof(HtmlAttributesProperty));
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderClasses(RenderTreeBuilder builder)
    {
        builder.OpenComponent(0, typeof(HtmlClassesProperty));
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderEnum(RenderTreeBuilder builder)
    {
        var componentType = typeof(EnumProperty<>)
            .MakeGenericType(Property.EnumType ?? Property.Property.PropertyType);

        builder.OpenComponent(0, componentType);
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderFragmentProperty(RenderTreeBuilder builder)
    {
        builder.OpenComponent(0, typeof(FragmentProperty));
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }
}

