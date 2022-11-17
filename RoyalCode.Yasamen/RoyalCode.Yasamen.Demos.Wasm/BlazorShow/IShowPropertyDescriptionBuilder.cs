using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowPropertyDescriptionBuilder<TComponent, TProperty>
    where TComponent : class, IComponent
{
    IShowPropertyDescriptionBuilder<TComponent, TProperty> Name(string name);
    IShowPropertyDescriptionBuilder<TComponent, TProperty> Description(string description);
    IShowPropertyDescriptionBuilder<TComponent, TProperty> Hide();
    IShowPropertyDescriptionBuilder<TComponent, TProperty> HasEnumValues<TEnum>()
        where TEnum : Enum;
    IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlAttributes();
    IShowPropertyDescriptionBuilder<TComponent, TProperty> HtmlClasses();

    IShowPropertyDescriptionBuilder<TComponent, TProperty> HasValueSet<TValueSet>()
        where TValueSet : ValueSet<TProperty>, new();

}