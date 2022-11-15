using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IFragmentComponentBuilder<TFragmentComponent>
    where TFragmentComponent : class, IComponent
{
    IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty> Property<TProperty>(
        Expression<Func<TFragmentComponent, TProperty>> value);
}
