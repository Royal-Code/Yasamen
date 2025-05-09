using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface IShowProperties<TComponent>
    where TComponent : class, IComponent
{
    IShowPropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value);
}
