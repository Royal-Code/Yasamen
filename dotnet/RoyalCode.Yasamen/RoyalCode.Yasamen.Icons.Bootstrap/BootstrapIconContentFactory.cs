using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Icons.Factory;

namespace RoyalCode.Yasamen.Icons.Bootstrap;

internal class BootstrapIconContentFactory : IIconContentFactory
{
    public RenderFragment GetFragment(
        Enum iconKind,
        string? additionalClasses,
        Dictionary<string, object>? additionalAttributes)
    {
        var cssClass = $"bi-{iconKind.GetDescription()}";
        if (additionalClasses is not null)
            cssClass = $"{cssClass} {additionalClasses}";

        return builder =>
        {
            builder.OpenElement(0, "i");
            builder.AddAttribute(1, "class", cssClass);
            if (additionalAttributes is not null)
                builder.AddMultipleAttributes(2, additionalAttributes);
            builder.CloseElement();
        };
    }
}
