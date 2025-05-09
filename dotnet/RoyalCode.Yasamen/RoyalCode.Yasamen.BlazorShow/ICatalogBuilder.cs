using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface ICatalogBuilder
{
    ICatalogBuilder AddShow<TShow, TComponent>()
        where TShow : IShow<TComponent>, new()
        where TComponent : class, IComponent;
}
