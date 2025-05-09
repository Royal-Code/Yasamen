namespace RoyalCode.Yasamen.Commons.Internal;

internal class MaybeCssClassCondition<T> : ICssClassBuilder<T>
{
    private readonly Func<T, string?> maybe;
    private readonly Func<T, bool>? condition;

    public MaybeCssClassCondition(Func<T, string?> maybe, Func<T, bool>? condition = null)
    {
        this.maybe = maybe ?? throw new ArgumentNullException(nameof(maybe));
        this.condition = condition;
    }

    public void Build(T value, ClassesCollection classes)
    {
        if (condition is not null && condition(value) is false)
            return;

        var c = maybe(value);
        if (!string.IsNullOrWhiteSpace(c))
            classes.Add(c);
    }
}