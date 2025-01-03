using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.YasamenBlazorShow;

public interface IShowProperties<TComponent>
    where TComponent : class, IComponent
{
    IShowPropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value);
}
