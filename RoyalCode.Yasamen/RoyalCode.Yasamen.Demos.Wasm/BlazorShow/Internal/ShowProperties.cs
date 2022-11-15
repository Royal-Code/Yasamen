using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

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
        var property = value.GetPropertyInfo();
        var propertyDescription = showDescription.FindPropertyDescription(property);

        if (propertyDescription is null)
        {
            throw new ArgumentException(
                $"The property '{property.Name}' was not found in the component '{showDescription.ComponentType.Name}'.");
        }

        return new ShowPropertyDescriptionBuilder<TComponent, TProperty>(propertyDescription);
    }
}
