using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class Scene<TComponent> : IScene<TComponent>
    where TComponent : class, IComponent
{
    public Scene(IShowDescription show)
    {
        Show = show;
    }
    
    public bool IsDefault { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IShowDescription Show { get; }
}