using Microsoft.AspNetCore.Components;

namespace RoyalCode.YasamenBlazorShow;

public interface IShow<TComponent>
    where TComponent : class, IComponent
{
    void Create(IShowDescriptionBuilder<TComponent> builder);
}
