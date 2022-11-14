namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowDescription
{
    Type ComponentType { get; }

    string? Group { get; }
    
    string? Name { get; }
    
    string? Description { get; }
    
    string? Route { get; }

    public ShowRenderKind RenderKind { get; set; }

    IEnumerable<IShowPropertyDescription> Properties { get; }

    IEnumerable<IScene> Scenes { get; }

    bool HasMultipleScenes { get; }

    string GetDefaultRoute();
}
