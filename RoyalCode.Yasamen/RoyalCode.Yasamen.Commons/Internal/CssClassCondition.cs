
namespace RoyalCode.Yasamen.Commons.Internal;

internal class CssClassCondition : ICssClassBuilder
{
    private readonly Func<bool> condition;
    private readonly string cssClass;

    public CssClassCondition(Func<bool> condition, string cssClass)
    {
        this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
        this.cssClass = cssClass ?? throw new ArgumentNullException(nameof(cssClass));
    }

    public void Build(ICollection<string> classes)
    {
        if (condition())
            classes.Add(cssClass);
    }
}
