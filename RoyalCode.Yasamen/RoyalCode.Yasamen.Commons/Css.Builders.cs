namespace RoyalCode.Yasamen.Commons;

public static partial class Css
{
    public static Utility Utility => new([]);
}

public interface IBase
{
    Utility Utility { get; }

    Text Text { get; }
}

#region Utility

public readonly struct Utility : IBase
{
    private readonly HashSet<string> classes;

    public Utility(HashSet<string> classes)
    {
        this.classes = classes;
    }

    public override string ToString() => string.Join(" ", classes);

    public Text Text => new(classes);

    Utility IBase.Utility => this;

    //visible
    public Utility Visible()
    {
        classes.Add("visible");
        return this;
    }

    //invisible
    public Utility Invisible()
    {
        classes.Add("invisible");
        return this;
    }

    //visually-hidden
    public Utility VisuallyHidden()
    {
        classes.Add("visually-hidden");
        return this;
    }

    //overflow-hidden
    public Utility OverflowHidden()
    {
        classes.Add("overflow-hidden");
        return this;
    }

    //position-static
    public Utility PositionStatic()
    {
        classes.Add("position-static");
        return this;
    }

    //position-relative
    public Utility PositionRelative()
    {
        classes.Add("position-relative");
        return this;
    }

    //position-absolute
    public Utility PositionAbsolute()
    {
        classes.Add("position-absolute");
        return this;
    }

    //position-fixed
    public Utility PositionFixed()
    {
        classes.Add("position-fixed");
        return this;
    }

    //position-sticky
    public Utility PositionSticky()
    {
        classes.Add("position-sticky");
        return this;
    }

    //opacity-{0-9}
    public Utility Opacity(int value)
    {
        if (value < 0 || value > 9)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 9");
        classes.Add($"opacity-{value}");
        return this;
    }
}

#endregion

#region Width

public readonly struct Width
{
    private readonly HashSet<string> classes;
    public Width(HashSet<string> classes)
    {
        this.classes = classes;
    }
    public override string ToString() => string.Join(" ", classes);
    public Utility Utility => new(classes);
    public Width W(int value)
    {
        classes.Add($"w-{value}");
        return this;
    }
    public Width Full()
    {
        classes.Add("w-full");
        return this;
    }

    public Width Screen()
    {
        classes.Add("w-screen");
        return this;
    }
    public Width Auto()
    {
        classes.Add("w-auto");
        return this;
    }
    

}

#endregion

#region Text

public readonly struct Text : IBase
{
    private readonly HashSet<string> classes;

    public Text(HashSet<string> classes)
    {
        this.classes = classes;
    }

    public override string ToString() => string.Join(" ", classes);

    public Utility Utility => new(classes);

    Text IBase.Text => this;

    public Text Center()
    {
        classes.Add("text-center");
        return this;
    }
}

#endregion