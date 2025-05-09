using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface ISceneProperties<TComponent>
    where TComponent : class, IComponent
{
    IScenePropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value);
}
