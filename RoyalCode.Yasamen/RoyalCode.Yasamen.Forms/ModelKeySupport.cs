using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

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
        Tracer.Write("ModelKeySupport", "FireModelChange", "Begin");
        
        await base.FireModelChange(model);

        Model = model;
        Key = KeySelect(model);
        if (KeyChanged.HasValue)
            await KeyChanged.Value.InvokeAsync(Key);
        
        Tracer.Write("ModelKeySupport", "FireModelChange", "End");
    }

    protected override void OnInitialized()
    {
        Tracer.Write("ModelKeySupport", "OnInitialized", "Begin");
        
        base.OnInitialized();

        if (KeySelect is null)
            throw new ArgumentException($"The parameter {nameof(KeySelect)} is required");
        
        Tracer.Write("ModelKeySupport", "OnInitialized", "End");
    }
}