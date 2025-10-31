using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons.Bootstrap;

internal class BootstrapIconContentFactory : IIconContentFactory
{
    public IconFragment GetFragment(Enum iconKind)
    {
        var baseCssClass = $"bi-{iconKind.GetDescription()}";

        return (string? additionalClasses, Dictionary<string, object>? additionalAttributes) => builder =>
        {
            var cssClass = baseCssClass;
            if (!string.IsNullOrWhiteSpace(additionalClasses))
                cssClass = $"{cssClass} {additionalClasses}";

            builder.OpenElement(0, "i");
            builder.AddAttribute(1, "class", cssClass);
            if (additionalAttributes is not null)
                builder.AddMultipleAttributes(2, additionalAttributes);
            builder.CloseElement();
        };
    }
}
