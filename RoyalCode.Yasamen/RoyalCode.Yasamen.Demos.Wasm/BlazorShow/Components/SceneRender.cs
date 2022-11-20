using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

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
            
            else if (property.PropertyDescription.HasComponents)
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, RenderFragment(property.ValueFragmentComponents!));
            
            else if (property.PropertyDescription.HasValueSet)
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, property.TryGetValue<IValueDescription>()?.GetValue());

            else
                builder.AddAttribute(seq++, property.PropertyDescription.Property.Name, property.Value);
        }

        builder.CloseComponent();
    }

    private RenderFragment RenderFragment(List<FragmentComponentDescription> fragmentComponents)
    {
        return builder =>
        {
            int seq = 0;
            foreach (var description in fragmentComponents)
            {
                builder.OpenComponent(seq++, description.ComponentType);
                
                foreach (var property in description.PropertyValues)
                {
                    if (property.Value is null)
                        continue;

                    if (property.IsCaptureUnmatchedValues)
                        builder.AddMultipleAttributes(seq++, (IEnumerable<KeyValuePair<string, object>>)property.Value);
                                        
                    else if (property.HasComponents)
                        builder.AddAttribute(seq++, 
                            property.PropertyInfo.Name, 
                            RenderFragment((List<FragmentComponentDescription>)property.Value));

                    else
                        builder.AddAttribute(seq++, property.PropertyInfo.Name, property.Value);
                }
                
                builder.CloseComponent();
            }
        };
    }
}
