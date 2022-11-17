using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class ShowPropertyDescription : IShowPropertyDescription
{
    public ShowPropertyDescription(PropertyInfo property)
    {
        Property = property;

        InitValues();
    }
    
    public PropertyInfo Property { get; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsHidden { get; set; }

    public bool IsFragment { get; set; }
    
    public bool HasEnumValues { get; set; }
    
    public Type? EnumType { get; set; }

    public bool IsHtmlAttributes { get; set; }

    public bool IsHtmlClasses { get; set; }

    public bool IsCaptureUnmatchedValues { get; private set; }
    
    private void InitValues()
    {
        Name = Property.Name;

        var descriptionAttribute = Property.GetCustomAttribute<DescriptionAttribute>();
        Description = descriptionAttribute?.Description ?? Name;

        if (Property.GetCustomAttribute<ParameterAttribute>()!.CaptureUnmatchedValues)
        {
            IsHtmlAttributes = true;
            IsCaptureUnmatchedValues = true;
        }
        else if (Name == "AdditionalAttributes")
        {
            IsHtmlAttributes = true;
        }
        else if (Name.EndsWith("Classes"))
        {
            IsHtmlClasses = true;
        }

        if (Property.PropertyType.IsEnum)
        {
            HasEnumValues = true;
            EnumType = Property.PropertyType;
        }
        else if (Property.PropertyType == typeof(RenderFragment))
        {
            IsFragment = true;
        }
    }
}
