namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowDescription
{
    Type ComponentType { get; }

    string? Group { get; }
    
    string? Name { get; }
    
    string? Description { get; }
    
    string? Route { get; }

    IEnumerable<IShowPropertyDescription> Properties { get; }

    IEnumerable<IScene> Scenary { get; }
}
