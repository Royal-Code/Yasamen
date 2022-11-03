namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowDescription
{
    Type ComponentType { get; }

    IEnumerable<IScene> Scenary { get; }

    string? Description { get; }

    string? Group { get; }

    string? Name { get; }

    string? Route { get; }
}
