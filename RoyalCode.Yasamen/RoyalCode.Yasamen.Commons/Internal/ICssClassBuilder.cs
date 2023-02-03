
namespace RoyalCode.Yasamen.Commons.Internal;

internal interface ICssClassBuilder
{
    void Build(ICollection<string> classes);
}

internal interface ICssClassBuilder<T>
{
    void Build(T value, ICollection<string> classes);
}