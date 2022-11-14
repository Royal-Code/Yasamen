using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowDescription : IShowDescription
{
    private readonly List<IScene> scenes = new();
    private readonly List<ShowPropertyDescription> propertyDescriptions = new();

    public ShowDescription(Type componentType)
    {
        ComponentType = componentType;

        InitializePropertyDescriptions();
    }
    
    public Type ComponentType { get; }
    public IEnumerable<IScene> Scenes => scenes;
    public IEnumerable<IShowPropertyDescription> Properties => propertyDescriptions;
    public string? Description { get; internal set; }
    public string? Group { get; internal set; }
    public string? Name { get; internal set; }
    public string? Route { get; internal set; }
    public bool HasMultipleScenes => scenes.Count > 1;

    public ShowRenderKind RenderKind { get; set; }

    public string GetDefaultRoute() => Scenes.First().GetRoute();


    private void InitializePropertyDescriptions()
    {
        var properties = ComponentType.GetRuntimeProperties()
            .Where(p => p.GetCustomAttribute<ParameterAttribute>() is not null);
        foreach (var property in properties)
        {
            var propertyDescription = new ShowPropertyDescription(property);
            propertyDescriptions.Add(propertyDescription);
        }
    }

    public ShowPropertyDescription? FindPropertyDescription(string propertyName)
    {
        return propertyDescriptions.FirstOrDefault(p => p.Property.Name == propertyName);
    }

    public ShowPropertyDescription? FindPropertyDescription(PropertyInfo propertyInfo)
    {
        return propertyDescriptions.FirstOrDefault(p => p.Property == propertyInfo);
    }

    public void AddScene(IScene scene)
    {
        scenes.Add(scene);
    }
}
