namespace RoyalCode.Yasamen.Commons;

public static partial class Css
{
}

#region Text

public readonly struct Text
{
    private readonly HashSet<string> classes;

    public Text(HashSet<string> classes)
    {
        this.classes = classes;
    }

    public override string ToString() => string.Join(" ", classes);

    public Text Center()
    {
        classes.Add("text-center");
        return this;
    }
}

#endregion