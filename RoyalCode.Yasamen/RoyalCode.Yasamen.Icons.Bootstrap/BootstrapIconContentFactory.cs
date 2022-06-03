using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Icons.Factory;

namespace RoyalCode.Yasamen.Icons.Bootstrap;

internal class BootstrapIconContentFactory : IIconContentFactory
{
    public RenderFragment GetFragment(
        Enum iconKind,
        string? AdditionalClasses,
        Dictionary<string, object>? AdditionalAttributes)
    {
        var cssClass = $"bi-{iconKind.GetDescription()}";
        if (AdditionalClasses is not null)
            cssClass = $"{cssClass} {AdditionalClasses}";

        return builder =>
        {
            builder.OpenElement(0, "i");
            builder.AddAttribute(1, "class", cssClass);
            if (AdditionalAttributes is not null)
                builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.CloseElement();
        };
    }
}
