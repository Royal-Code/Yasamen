using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     A collection of <see cref="ChangeSupport"/>.
/// </para>
/// <para>
///     This class manages the <see cref="ChangeSupport"/> and its lifecycle.
/// </para>
/// </summary>
public sealed class ChangeSupportCollection
{
    private readonly LinkedList<ChangeSupport> supports = new();
    private readonly PropertyChangeSupport? parentPropertyChangeSupport;

    public ChangeSupportCollection(PropertyChangeSupport? parentPropertyChangeSupport = null)
    {
        this.parentPropertyChangeSupport = parentPropertyChangeSupport;
    }

    /// <summary>
    /// <para>
    ///     Gets a <see cref="ChangeSupport"/> for a given name.
    /// </para>
    /// <para>
    ///     The same instance is always returned for the same name.
    /// </para>
    /// </summary>
    /// <param name="name">Name of the support for change.</param>
    /// <returns>An instance of <see cref="ChangeSupport"/>.</returns>
    public ChangeSupport GetChangeSupport(string? name = null)
    {
        name ??= string.Empty;

        var changeSupport = supports.FirstOrDefault(s => s.Name == name);
        if (changeSupport is null)
        {
            changeSupport = new ChangeSupport(name, this, parentPropertyChangeSupport);
            supports.AddLast(changeSupport);
        }
        return changeSupport;
    }

    public IEnumerable<ChangeSupport> Filter<TProperty>(FieldIdentifier fieldIdentifier)
    {
        return supports.Where(s => (fieldIdentifier.Equals(s.Identifier) && s.FieldType == typeof(TProperty))
                                   || s.Name == string.Empty);
    }
}