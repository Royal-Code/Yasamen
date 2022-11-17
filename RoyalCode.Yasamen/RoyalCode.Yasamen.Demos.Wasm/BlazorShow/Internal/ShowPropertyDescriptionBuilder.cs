using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowPropertyDescriptionBuilder<TComponent, TProperty>
    : IShowPropertyDescriptionBuilder<TComponent, TProperty>
    where TComponent : class, IComponent
{
    private readonly ShowPropertyDescription propertyDescription;

    public ShowPropertyDescriptionBuilder(ShowPropertyDescription propertyDescription)
    {
        this.propertyDescription = propertyDescription;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Description(string description)
    {
        propertyDescription.Description = description;
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Hide()
    {
        propertyDescription.IsHidden = true;
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlAttributes()
    {
        propertyDescription.IsHtmlAttributes = true;
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlClasses()
    {
        propertyDescription.IsHtmlClasses = true;
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> Name(string name)
    {
        propertyDescription.Name = name;
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HasEnumValues<TEnum>()
        where TEnum : Enum
    {
        propertyDescription.HasEnumValues = true;
        propertyDescription.EnumType = typeof(TEnum);
        return this;
    }

    public IShowPropertyDescriptionBuilder<TComponent, TProperty> HasValueSet<TValueSet>()
        where TValueSet : ValueSet<TProperty>, new()
    {
        propertyDescription.ValueSet = new TValueSet();
        return this;
    }
}
