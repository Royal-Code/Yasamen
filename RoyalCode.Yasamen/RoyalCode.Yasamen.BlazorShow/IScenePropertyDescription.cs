namespace RoyalCode.Yasamen.BlazorShow;

public interface IScenePropertyDescription : IShowPropertyDescription
{
    object? DefaultValue { get; }

    bool HasComponents { get; }
}
