using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface IShow<TComponent>
    where TComponent : class, IComponent
{
    void Create(IShowDescriptionBuilder<TComponent> builder);
}
