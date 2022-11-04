using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowProperties<TComponent> : IShowProperties<TComponent>
    where TComponent : class, IComponent
{
    private readonly ShowDescription showDescription;

    public ShowProperties(ShowDescription showDescription)
    {
        this.showDescription = showDescription;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Property<TProperty>(
        Expression<Func<TComponent, TProperty>> value)
    {
        var property = GetPropertyInfo(value);
        var propertyDescription = showDescription.FindPropertyDescription(property);

        if (propertyDescription is null)
        {
            throw new ArgumentException(
                $"The property '{property.Name}' was not found in the component '{showDescription.ComponentType.Name}'.");
        }

        return new ShowPropertyDescriptionBuilder<TComponent, TProperty>(propertyDescription);
    }
    
    private static PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<TComponent, TProperty>> value)
    {
        if (value.Body is not MemberExpression memberExpression)
            throw new ArgumentException("The expression is not a member access expression.", nameof(value));

        if (memberExpression.Member is not PropertyInfo propertyInfo)
            throw new ArgumentException("The member access expression does not access a property.", nameof(value));

        var getMethod = propertyInfo.GetMethod;
        if (getMethod is null)
            throw new ArgumentException("The referenced property does not have a get method.", nameof(value));

        if (getMethod.IsStatic)
            throw new ArgumentException("The referenced property is a static property.", nameof(value));

        return propertyInfo;
    }
}
