namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;

public class SceneContext
{
    private readonly Action callbackDelegate;
    private readonly LinkedList<Action> propertyChangedListeners = new();
    
    public IScene Scene { get; }

    public IEnumerable<ScenePropertyValue> Values { get; }

    public SceneContext(IScene scene)
    {
        callbackDelegate = PropertyStateHasChanged;

        Scene = scene;
        Values = scene.Show.Properties.Select(p => new ScenePropertyValue(p, scene, callbackDelegate)).ToList();
    }

    public ScenePropertyValue GetProperty(string name)
        => Values.FirstOrDefault(p => p.PropertyDescription.Property.Name == name)
            ?? throw new ArgumentException($"Property '{name}' not found.", nameof(name));

    private void PropertyStateHasChanged()
    {
        foreach (var listener in propertyChangedListeners)
            listener();
    }

    public void AddPropertyChangedListener(Action callback) => propertyChangedListeners.AddLast(callback);

    public void RemovePropertyChangedListener(Action callback) => propertyChangedListeners.Remove(callback);
}
