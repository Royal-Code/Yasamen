using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components;
public sealed class SceneRender : ComponentBase, IDisposable
{
    private readonly Action changeListenerDelegate;

    public SceneRender()
    {
        changeListenerDelegate = ChangeListener;
    }
    
    [CascadingParameter]
    public SceneContext Context { get; set; }

    protected override void OnInitialized()
    {
        Context.AddPropertyChangedListener(changeListenerDelegate);
    }

    public void Dispose()
    {
        Context.RemovePropertyChangedListener(changeListenerDelegate);
    }

    private void ChangeListener()
    {
        InvokeAsync(StateHasChanged);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Console.WriteLine("BuildRenderTree SceneRender");
        
        builder.OpenComponent(0, Context.Scene.Show.ComponentType);

        int seq = 1;
        foreach (var property in Context.Values)
        {
            if (property.PropertyDescription.IsCaptureUnmatchedValues)
                builder.AddMultipleAttributes(seq++, property.GetMultipleAttributes());

            else if (property.PropertyDescription.IsHtmlAttributes)
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, property.GetAttributesDictionary());
            
            else if (property.PropertyDescription.IsHtmlClasses)
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, property.GetClasses());
            
            else
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, property.Value);
            
        }

        builder.CloseComponent();
    }
}
