using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ScenePropertyDescription : IScenePropertyDescription
{
    private readonly IShowPropertyDescription showPropertyDescription;
    private string? name;
    private string? description;
    private bool? isHidden;
    private bool? hasEnumValues;
    private Type? enumType;
    private object? valueSet;

    public ScenePropertyDescription(IShowPropertyDescription showPropertyDescription)
    {
        this.showPropertyDescription = showPropertyDescription;
    }

    public object? DefaultValue { get; set; }

    public PropertyInfo Property => showPropertyDescription.Property;

    public string? Name
    {
        get => name ?? showPropertyDescription.Name;
        set => name = value;
    }

    public string? Description
    {
        get => description ?? showPropertyDescription.Description;
        set => description = value;
    }

    public bool IsHidden
    {
        get => isHidden ?? showPropertyDescription.IsHidden;
        set => isHidden = value;
    }

    public bool HasEnumValues
    {
        get => hasEnumValues ?? showPropertyDescription.HasEnumValues;
        set => hasEnumValues = value;
    }

    public Type? EnumType
    {
        get => enumType ?? showPropertyDescription.EnumType;
        set => enumType = value;
    }

    public bool IsFragment => showPropertyDescription.IsFragment;

    public bool IsEvent => showPropertyDescription.IsEvent;

    public bool IsHtmlAttributes => showPropertyDescription.IsHtmlAttributes;

    public bool IsHtmlClasses => showPropertyDescription.IsHtmlClasses;

    public bool IsCaptureUnmatchedValues => showPropertyDescription.IsCaptureUnmatchedValues;

    public bool HasComponents { get; private set; }

    public bool HasValueSet => ValueSet is not null;

    public object? ValueSet
    {
        get => valueSet ?? showPropertyDescription.ValueSet;
        set => valueSet = value;
    }
    
    public void AddFragmentComponent(FragmentComponentDescription description)
    {
        HasComponents = true;

        if (DefaultValue is null || DefaultValue.GetType() != typeof(List<FragmentComponentDescription>))
            DefaultValue = new List<FragmentComponentDescription>();
        
        ((List<FragmentComponentDescription>)DefaultValue).Add(description);
    }
}

public class FragmentComponentDescription
{
    public FragmentComponentDescription(Type componentType)
    {
        ComponentType = componentType;
    }

    public Type ComponentType { get; }

    public ICollection<FragmentComponentPropertyValue> PropertyValues { get; } = new List<FragmentComponentPropertyValue>();

}

public class FragmentComponentPropertyValue
{
    public FragmentComponentPropertyValue(
        FragmentComponentDescription description, 
        PropertyInfo propertyInfo)
    {
        Description = description;
        PropertyInfo = propertyInfo;
    }

    public FragmentComponentDescription Description { get; }
    
    public PropertyInfo PropertyInfo { get; }
    
    public object? Value { get; set; }

    public bool IsCaptureUnmatchedValues => PropertyInfo.GetCustomAttribute<ParameterAttribute>()?.CaptureUnmatchedValues == true;

    public bool HasComponents => Value?.GetType() == typeof(List<FragmentComponentDescription>);

    public void AddFragmentComponent(FragmentComponentDescription description)
    {
        if (Value is null || Value.GetType() != typeof(List<FragmentComponentDescription>))
            Value = new List<FragmentComponentDescription>();

        ((List<FragmentComponentDescription>)Value).Add(description);
    }
}