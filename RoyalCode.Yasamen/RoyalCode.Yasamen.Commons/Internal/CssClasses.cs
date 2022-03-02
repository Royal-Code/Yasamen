
namespace RoyalCode.Yasamen.Commons.Internal;

internal class CssClasses : ICssClassBuilder
{
    private readonly string[] cssClasses;

    public CssClasses(string[] cssClasses)
    {
        this.cssClasses = cssClasses ?? throw new ArgumentNullException(nameof(cssClasses));
    }

    public void Build(ICollection<string> classes)
    {
        for (int i = 0; i < cssClasses.Length; i++)
        {
            classes.Add(cssClasses[i]);
        }
    }
}
