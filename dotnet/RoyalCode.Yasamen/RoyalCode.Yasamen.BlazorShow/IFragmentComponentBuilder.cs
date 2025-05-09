using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface IFragmentComponentBuilder<TFragmentComponent>
    where TFragmentComponent : class, IComponent
{
    IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty> Property<TProperty>(
        Expression<Func<TFragmentComponent, TProperty>> value);
}
