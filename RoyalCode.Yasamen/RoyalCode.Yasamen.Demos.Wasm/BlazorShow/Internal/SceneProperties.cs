using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

internal class SceneProperties<TComponent> : ISceneProperties<TComponent>
    where TComponent : class, IComponent
{
    private Scene<TComponent> scene;

    public SceneProperties(Scene<TComponent> scene)
    {
        this.scene = scene;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value)
    {
        var property = value.GetPropertyInfo();
        var propertyDescription = scene.FindPropertyDescription(property);

        if (propertyDescription is null)
        {
            throw new ArgumentException(
                $"The property '{property.Name}' was not found in the component '{scene.Show.ComponentType.Name}'.");
        }

        return new ScenePropertyDescriptionBuilder<TComponent, TProperty>(propertyDescription);
    }
}