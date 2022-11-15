using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ScenePropertyDescriptionBuilder<TComponent, TProperty> 
    : IScenePropertyDescriptionBuilder<TComponent, TProperty>
    where TComponent : class, IComponent
{
    private readonly ScenePropertyDescription scenePropertyDescription;

    public ScenePropertyDescriptionBuilder(ScenePropertyDescription scenePropertyDescription)
    {
        this.scenePropertyDescription = scenePropertyDescription;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> DefaultValue(object? defaultValue)
    {
        scenePropertyDescription.DefaultValue = defaultValue;
        return this;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> Description(string? description)
    {
        scenePropertyDescription.Description = description;
        return this;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> Hide(bool isHidden)
    {
        scenePropertyDescription.IsHidden = isHidden;
        return this;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> Name(string? name)
    {
        scenePropertyDescription.Name = name;
        return this;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> HasEnumValues<TEnum>()
        where TEnum : Enum
    {
        scenePropertyDescription.HasEnumValues = true;
        scenePropertyDescription.EnumType = typeof(TEnum);
        return this;
    }

    public IScenePropertyDescriptionBuilder<TComponent, TProperty> RenderComponent<TFragmentComponent>(
        Action<IFragmentComponentBuilder<TFragmentComponent>>? configure = null)
        where TFragmentComponent : class, IComponent
    {
        var description = new FragmentComponentDescription(typeof(TFragmentComponent));
        configure?.Invoke(new FragmentComponentBuilder<TFragmentComponent>(description));

        scenePropertyDescription.AddFragmentComponent(description);
        return this;
    }
}

