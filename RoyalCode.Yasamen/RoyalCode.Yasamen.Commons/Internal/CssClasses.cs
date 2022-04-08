
namespace RoyalCode.Yasamen.Commons.Internal;

internal class CssClasses : ICssClassBuilder
{
    private readonly string?[] cssClasses;

    public CssClasses(string?[] cssClasses)
    {
        this.cssClasses = cssClasses ?? throw new ArgumentNullException(nameof(cssClasses));
    }

    public void Build(ICollection<string> classes)
    {
        for (int i = 0; i < cssClasses.Length; i++)
        {
            var cssClass = cssClasses[i];
            if (cssClass is null)
                continue;
            
            classes.Add(cssClass);
        }
    }
}
