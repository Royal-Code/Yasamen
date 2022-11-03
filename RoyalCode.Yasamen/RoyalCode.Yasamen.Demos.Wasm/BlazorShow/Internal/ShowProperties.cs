using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowProperties<TComponent> : IShowProperties<TComponent>
    where TComponent : class, IComponent
{
    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value)
    {
        // get the PropertyInfo from the lambda expression value.




        throw new NotImplementedException();
    }

}

public class ShowPropertyDescriptionBuilder<TComponent, TProperty>
    : IShowPropertyDescriptionBuilder<TComponent, TProperty>
    where TComponent : class, IComponent
{

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Description(string description)
    {
        throw new NotImplementedException();
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Hide()
    {
        throw new NotImplementedException();
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlAttributes()
    {
        throw new NotImplementedException();
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlClasses()
    {
        throw new NotImplementedException();
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Name(string name)
    {
        throw new NotImplementedException();
    }

    IShowPropertyDescriptionBuilder<TComponent, TProperty> IShowPropertyDescriptionBuilder<TComponent, TProperty>.HasEnumValues<TEnum>()
    {
        throw new NotImplementedException();
    }
}