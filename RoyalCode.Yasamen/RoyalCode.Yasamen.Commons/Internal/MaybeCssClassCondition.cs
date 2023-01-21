namespace RoyalCode.Yasamen.Commons.Internal;

internal class MaybeCssClassCondition : ICssClassBuilder
{
    private readonly CssClassMap.Maybe maybe;

    public MaybeCssClassCondition(CssClassMap.Maybe maybe)
    {
        this.maybe = maybe ?? throw new ArgumentNullException(nameof(maybe));
    }

    public void Build(ICollection<string> classes)
    {
        var value = maybe();
        if (!string.IsNullOrWhiteSpace(value))
            classes.Add(value);
    }
}