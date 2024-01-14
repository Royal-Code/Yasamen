namespace RoyalCode.Yasamen.Commons.Internal;

internal interface ICssClassBuilder
{
    void Build(ClassesCollection classes);
}

internal interface ICssClassBuilder<T>
{
    void Build(T value, ClassesCollection classes);
}
