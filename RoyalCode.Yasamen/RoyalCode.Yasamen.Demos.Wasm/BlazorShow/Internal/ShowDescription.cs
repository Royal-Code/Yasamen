namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowDescription : IShowDescription
{
    private readonly List<IScene> scenes = new();
    private readonly ShowProperties<TComponent> showProperties = new();

    public ShowDescription(Type componentType)
    {
        ComponentType = componentType;
    }

    public Type ComponentType { get; }
    public IEnumerable<IScene> Scenary => scenes;

    public string? Description { get; internal set; }
    public string? Group { get; internal set; }
    public string? Name { get; internal set; }
    public string? Route { get; internal set; }
}
