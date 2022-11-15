namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using Microsoft.AspNetCore.Components;

public interface IScenePropertyDescriptionBuilder<TComponent, TProperty>
    where TComponent : class, IComponent
{
    IScenePropertyDescriptionBuilder<TComponent, TProperty> DefaultValue(object? defaultValue);

    IScenePropertyDescriptionBuilder<TComponent, TProperty> Name(string? name);

    IScenePropertyDescriptionBuilder<TComponent, TProperty> Description(string? description);

    IScenePropertyDescriptionBuilder<TComponent, TProperty> Hide(bool isHidden);

    IScenePropertyDescriptionBuilder<TComponent, TProperty> HasEnumValues<TEnum>()
        where TEnum : Enum;

    IScenePropertyDescriptionBuilder<TComponent, TProperty> RenderComponent<TFragmentComponent>(
        Action<IFragmentComponentBuilder<TFragmentComponent>>? configure = null)
        where TFragmentComponent : class, IComponent;
}
