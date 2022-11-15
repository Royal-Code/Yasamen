using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class FragmentComponentBuilder<TFragmentComponent> : IFragmentComponentBuilder<TFragmentComponent>
    where TFragmentComponent : class, IComponent
{
    private readonly FragmentComponentDescription description;

    public FragmentComponentBuilder(FragmentComponentDescription description)
    {
        this.description = description;
    }

    public IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty> Property<TProperty>(
        Expression<Func<TFragmentComponent, TProperty>> value)
    {
        var property = value.GetPropertyInfo();
        return new FragmentComponentPropertyBuilder<TFragmentComponent, TProperty>(description, property);
    }
}
