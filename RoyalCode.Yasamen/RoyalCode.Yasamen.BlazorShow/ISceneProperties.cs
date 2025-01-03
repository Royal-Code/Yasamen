using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.YasamenBlazorShow;

public interface ISceneProperties<TComponent>
    where TComponent : class, IComponent
{
    IScenePropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value);
}
