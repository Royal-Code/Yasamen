using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.PropertyRenders;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components;

public class PropertyValueRender : ComponentBase
{
    [Parameter, EditorRequired]
    public SceneContext Context { get; set; }

    [Parameter, EditorRequired]
    public IScenePropertyDescription Property { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Tracer.Begin<PropertyValueRender>("BuildRenderTree");

        builder.OpenRegion(0);

        if (Property.IsHtmlAttributes)
            RenderAttributes(builder);

        else if (Property.HasValueSet)
            RenderValueSet(builder);

        else if (Property.IsHtmlClasses)
            RenderClasses(builder);

        else if (Property.IsFragment)
            RenderFragmentProperty(builder);

        else if (Property.IsEvent)
            RenderEventProperty(builder);

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

        builder.CloseRegion();

        Tracer.End<PropertyValueRender>("BuildRenderTree");
    }

    private void RenderCustom(RenderTreeBuilder builder)
    {
        builder.AddContent(1, Property.Property.PropertyType.Name);
    }

    private void RenderBool(RenderTreeBuilder builder)
    {
        builder.OpenComponent(2, typeof(BoolProperty));
        builder.AddAttribute(3, "Context", Context);
        builder.AddAttribute(4, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderText(RenderTreeBuilder builder)
    {
        builder.OpenComponent(5, typeof(TextProperty));
        builder.AddAttribute(6, "Context", Context);
        builder.AddAttribute(7, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderNumber(RenderTreeBuilder builder)
    {
        RenderCustom(builder);
        return;
    }

    private void RenderAttributes(RenderTreeBuilder builder)
    {
        builder.OpenComponent(8, typeof(HtmlAttributesProperty));
        builder.AddAttribute(9, "Context", Context);
        builder.AddAttribute(10, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderClasses(RenderTreeBuilder builder)
    {
        builder.OpenComponent(11, typeof(HtmlClassesProperty));
        builder.AddAttribute(12, "Context", Context);
        builder.AddAttribute(13, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderEnum(RenderTreeBuilder builder)
    {
        var componentType = typeof(EnumProperty<>)
            .MakeGenericType(Property.EnumType ?? Property.Property.PropertyType);

        builder.OpenComponent(14, componentType);
        builder.AddAttribute(15, "Context", Context);
        builder.AddAttribute(16, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderFragmentProperty(RenderTreeBuilder builder)
    {
        builder.OpenComponent(17, typeof(FragmentProperty));
        builder.AddAttribute(18, "Context", Context);
        builder.AddAttribute(19, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderValueSet(RenderTreeBuilder builder)
    {
        builder.OpenComponent(20, typeof(ValueSetProperty<>).MakeGenericType(Property.Property.PropertyType));
        builder.AddAttribute(21, "Context", Context);
        builder.AddAttribute(22, "Property", Property);

        builder.CloseComponent();
    }

    private void RenderEventProperty(RenderTreeBuilder builder)
    {
        builder.OpenComponent(22, typeof(FragmentProperty));
        builder.AddAttribute(23, "Context", Context);
        builder.AddAttribute(24, "Property", Property);

        builder.CloseComponent();
    }
}


