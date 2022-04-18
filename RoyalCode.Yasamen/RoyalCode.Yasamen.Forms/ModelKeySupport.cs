using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Forms;

public class ModelKeySupport<TModel, TKey> : ModelSupport<TModel>
    where TModel : class, new()
{
    [Parameter]
    public TKey? Key { get; set; }

    [Parameter]
    public EventCallback<TKey>? KeyChanged { get; set; }

    [Parameter]
    public Expression<Func<TKey>>? KeyExpression { get; set; }
    
    [Parameter]
    public Func<TModel, TKey> KeySelect { get; set; } = null!;

    protected override async Task FireModelChange(TModel model)
    {
        await base.FireModelChange(model);

        Model = model;
        Key = KeySelect(model);
        if (KeyChanged.HasValue)
            await KeyChanged.Value.InvokeAsync(Key);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (KeySelect is null)
            throw new ArgumentException($"The parameter {nameof(KeySelect)} is required");
    }
}