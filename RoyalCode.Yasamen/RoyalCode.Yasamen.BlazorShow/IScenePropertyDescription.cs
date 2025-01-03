namespace RoyalCode.YasamenBlazorShow;

public interface IScenePropertyDescription : IShowPropertyDescription
{
    object? DefaultValue { get; }

    bool HasComponents { get; }
}
