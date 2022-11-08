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
    public IShowPropertyDescription Property { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Console.WriteLine("BuildRenderTree PropertyValueRender");
        
        if (Property.IsHtmlClasses)
            RenderClasses(builder);

        else if (Property.IsHtmlAttributes)
            RenderAttributes(builder);

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
    }

    private void RenderBool(RenderTreeBuilder builder)
    {
        return;
        throw new NotImplementedException();
    }

    private void RenderText(RenderTreeBuilder builder)
    {
        return;
        throw new NotImplementedException();
    }

    private void RenderNumber(RenderTreeBuilder builder)
    {
        return;
        throw new NotImplementedException();
    }

    private void RenderAttributes(RenderTreeBuilder builder)
    {
        return;
        throw new NotImplementedException();
    }

    private void RenderClasses(RenderTreeBuilder builder)
    {
        return;
        throw new NotImplementedException();
    }

    private void RenderEnum(RenderTreeBuilder builder)
    {
        Console.WriteLine("RenderEnum PropertyValueRender");

        var componentType = typeof(EnumProperty<>)
            .MakeGenericType(Property.EnumType ?? Property.Property.PropertyType);

        builder.OpenComponent(0, componentType);
        builder.AddAttribute(1, "Context", Context);
        builder.AddAttribute(2, "Property", Property);

        builder.CloseComponent();
    }
}
