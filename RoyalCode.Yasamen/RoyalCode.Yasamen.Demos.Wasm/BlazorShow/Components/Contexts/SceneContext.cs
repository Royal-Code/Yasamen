namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;

public class SceneContext
{

    public IScene Scene { get; }

    public IEnumerable<ScenePropertyValue> Values { get; }

    public SceneContext(IScene scene)
    {
        Scene = scene;
        Values = scene.Show.Properties.Select(p => new ScenePropertyValue(p, scene)).ToList();
    }

    public ScenePropertyValue GetProperty(string name)
        => Values.FirstOrDefault(p => p.PropertyDescription.Property.Name == name)
            ?? throw new ArgumentException($"Property '{name}' not found.", nameof(name));
}
