using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Commons;

public class YasamenBase : ComponentBase
{
    protected AdditionalAttributes Attributes { get; }
    protected CapturedValue AdditionalClasses { get; }

    public YasamenBase()
    {
        Attributes = new AdditionalAttributes();
        AdditionalClasses = Attributes.CaptureClass();
    }

#pragma warning disable BL0007 // AdditionalAttributes should be auto-property
    [Parameter(CaptureUnmatchedValues = true)]
    public IEnumerable<KeyValuePair<string, object>>? AdditionalAttributes
    {
        get => Attributes.GetCapturedAttributes();
        set => Attributes.CapturedUnmatchedAttributes(value);
    }
#pragma warning restore BL0007 // AdditionalAttributes should be auto-property
}
