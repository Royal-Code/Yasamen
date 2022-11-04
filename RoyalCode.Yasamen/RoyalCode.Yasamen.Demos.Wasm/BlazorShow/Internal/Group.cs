namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

/// <summary>
/// <para>
///     A group of <see cref="ShowDescription"/>.
/// </para>
/// </summary>
public class Group
{
    /// <summary>
    /// Create new group.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <param name="shows">The show descriptions of the group.</param>
    public Group(string name, IEnumerable<IShowDescription> shows)
    {
        Name = name;
        Shows = shows;
    }

    /// <summary>
    /// The name of the group.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The show descriptions of the group.
    /// </summary>
    public IEnumerable<IShowDescription> Shows { get; }
}