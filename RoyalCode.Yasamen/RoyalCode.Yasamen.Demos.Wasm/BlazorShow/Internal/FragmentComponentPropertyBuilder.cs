using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class FragmentComponentPropertyBuilder<TFragmentComponent, TProperty>
    : IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty>
    where TFragmentComponent : class, IComponent
{
    private readonly FragmentComponentPropertyValue propertyValue;

    public FragmentComponentPropertyBuilder(FragmentComponentDescription description, PropertyInfo property)
    {
        var propertyValue = description.PropertyValues.FirstOrDefault(v => v.PropertyInfo == property);
        if (propertyValue is null)
        {
            propertyValue = new FragmentComponentPropertyValue(description, property);
            description.PropertyValues.Add(propertyValue);
        }
        this.propertyValue = propertyValue;
    }

    public void RenderComponent<T>(
        Action<IFragmentComponentBuilder<T>>? configure = null)
        where T : class, IComponent
    {
        var componentDescription = new FragmentComponentDescription(typeof(T));
        configure?.Invoke(new FragmentComponentBuilder<T>(componentDescription));

        propertyValue.AddFragmentComponent(componentDescription);
    }

    public void SetValue(TProperty value)
    {
        propertyValue.Value = value;
    }
}