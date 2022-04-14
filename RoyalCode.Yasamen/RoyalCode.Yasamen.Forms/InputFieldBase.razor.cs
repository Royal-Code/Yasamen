
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace RoyalCode.Yasamen.Forms;

public abstract partial class InputFieldBase<TValue>
{
    [Inject]
    public IStringLocalizer Localizer { get; set; } = null!;
    
    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? LabelAdditionalClasses { get; set; }

    [Parameter]
    public InputType Type { get; set; }

    [Parameter]
    public string? InputName { get; set; }

    [Parameter]
    public string? InputAdditionalClasses { get; set; }

    [Parameter]
    public RenderFragment? Prepend { get; set; }

    [Parameter]
    public RenderFragment? Append { get; set; }
}