
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public partial class SubmitButton
{
    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();
}
