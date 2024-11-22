using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demo.NewResources.DataSources;

public partial class ComboDemo<T> where T : class
{
    [Inject]
    public IResources Resources { get; set; }

    [Parameter]
    public T Selected { get; set; }

    /// <summary>
    /// Gets or sets a callback that updates the bound value.
    /// </summary>
    [Parameter]
    public EventCallback<T> SelectedChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter]
    public Expression<Func<T>> SelectedExpression { get; set; }

    [Parameter]
    public Func<T, object> Key { get; set; }

    [Parameter]
    public Func<T, string> Description { get; set; }

    [Parameter]
    public IEnumerable<T> Items { get; set; }

    [Parameter]
    public IResourceList<T> Resource { get; set; }

    [CascadingParameter]
    public IResourceList<T> CascadingResource { get; set; }
}
