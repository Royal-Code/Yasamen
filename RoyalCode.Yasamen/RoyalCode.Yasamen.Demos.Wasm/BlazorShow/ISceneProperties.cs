using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface ISceneProperties<TComponent>
    where TComponent : class, IComponent
{
    IScenePropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value);
}
