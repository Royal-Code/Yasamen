using RoyalCode.Yasamen.Commons;
using System.Text.Json;

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
        Values = scene.SceneProperties.Select(p => new ScenePropertyValue(p, callbackDelegate)).ToList();
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

    internal string Serialize()
    {
        var valuesSerialized = new LinkedList<ScenePropertyValue.PropertySerialization>();

        foreach (var value in Values)
        {
            valuesSerialized.AddLast(value.Serialize());
        }

        var contextSerialization = new ContextSerialization()
        {
            Values = valuesSerialized
        };

        return JsonSerializer.Serialize(contextSerialization);
    }

    internal static SceneContext Deserialize(IScene scene, string json)
    {
        var contextSerialization = JsonSerializer.Deserialize<ContextSerialization>(json)!;

        var context = new SceneContext(scene);

        Tracer.Begin<SceneContext>("Deserialize");

        foreach (var valueSerialization in contextSerialization.Values)
        {
            var value = context.GetProperty(valueSerialization.PropertyName);
            value.DeserializeValue(valueSerialization);

            Tracer.Write<SceneContext>("Deserialize", "Deserialized: {0} = {1}", valueSerialization.PropertyName, value.Value!);
        }

        Tracer.End<SceneContext>("Deserialize");

        return context;
    }

    internal class ContextSerialization
    {
        public IEnumerable<ScenePropertyValue.PropertySerialization> Values { get; set; }
    }
}
