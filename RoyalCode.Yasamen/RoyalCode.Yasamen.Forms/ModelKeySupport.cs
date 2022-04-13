using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Forms;

public class ModelKeySupport<TModel, TKey> : ModelSupport<TModel>
    where TModel : class, new()
{
    [Parameter]
    public TKey? Value { get; set; }

    [Parameter]
    public EventCallback<TKey> ValueChanged { get; set; }

    [Parameter] 
    public Func<TModel, TKey> ValueSelect { get; set; } = null!;

    protected override async Task FireModelChange(TModel model)
    {
        await base.FireModelChange(model);

        Model = model;
        await ValueChanged.InvokeAsync(ValueSelect(model));
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ValueSelect is null)
            throw new ArgumentException($"The parameter {nameof(ValueSelect)} is required");
    }
}