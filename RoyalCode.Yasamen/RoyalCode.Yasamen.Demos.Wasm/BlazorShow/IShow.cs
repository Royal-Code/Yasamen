using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShow<TComponent>
    where TComponent : class, IComponent
{
    void Create(IShowDescriptionBuilder<TComponent> builder);
}

public interface IShowDescriptionBuilder<TComponent>
    where TComponent : class, IComponent
{
    IShowDescriptionBuilder<TComponent> Description(string description);
    IShowDescriptionBuilder<TComponent> Group(string groupName);
    IShowDescriptionBuilder<TComponent> Name(string name);
    IShowDescriptionBuilder<TComponent> Route(string route);
    IShowDescriptionBuilder<TComponent> AddScene(Action<ISceneBuilder> configure);
    IShowDescriptionBuilder<TComponent> Properties(Action<IShowProperties<TComponent>> configure);
}

public interface IShowProperties<TComponent>
    where TComponent : class, IComponent
{
    IShowPropertyDescription<TComponent, TProperty> Property<TProperty>(Expression<Func<TComponent, TProperty>> value);
}

public interface IShowPropertyDescription<TComponent, TProperty>
    where TComponent : class, IComponent
{
    IShowPropertyDescription<TComponent, TProperty> Name(string name);
    IShowPropertyDescription<TComponent, TProperty> Description(string description);
    IShowPropertyDescription<TComponent, TProperty> Hide();
    IShowPropertyDescription<TComponent, TProperty> HasEnumValues<TEnum>()
        where TEnum : Enum;
}