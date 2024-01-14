namespace RoyalCode.Yasamen.Commons.Internal;

internal class CssClassesBuilder<T> : ICssMapBuilder<T>
{
    private readonly List<ICssClassBuilder<T>> conditions = new();

    public ICssMapBuilder<T> Add(string? cssClass)
    {
        conditions.Add(new CssClasses<T>(new string?[] { cssClass }));
        return this;
    }
        
    public ICssMapBuilder<T> Add(params string?[] cssClasses)
    {
        conditions.Add(new CssClasses<T>(cssClasses));
        return this;
    }

    public ICssMapBuilder<T> Add(Func<T, string?> cssClass)
    {
        conditions.Add(new MaybeCssClassCondition<T>(cssClass));
        return this;
    }

    public ICssMapBuilder<T> Add(Func<T, bool> condition, string cssClass)
    {
        conditions.Add(new CssClassCondition<T>(condition, cssClass));
        return this;
    }

    public ICssMapBuilder<T> Add(Func<T, bool> condition, string cssClassWhenTrue, string cssClassWhenFalse)
    {
        conditions.Add(new CssClassCondition<T>(condition, cssClassWhenTrue));
        conditions.Add(new CssClassCondition<T>((t) => !condition(t), cssClassWhenFalse));
        return this;
    }

    public ICssMapBuilder<T> Add(Func<T, bool> condition, Func<T, string?> cssClass)
    {
        conditions.Add(new MaybeCssClassCondition<T>(cssClass, condition));
        return this;
    }

    public ICssMapBuilder<T> Add(Func<T, bool> condition, params Func<T, string?>[] cssClass)
    {
        foreach (var cssClassFunc in cssClass)
            conditions.Add(new MaybeCssClassCondition<T>(cssClassFunc, condition));

        return this;
    }

    public CssMap<T> Build()
    {
        return (value) =>
        {
            if (value is null)
                return null;

            var classes = new ClassesCollection();

            foreach (var condition in conditions)
                condition.Build(value, classes);

            if (classes.IsEmpty)
                return null;

            return classes.ToString();
        };
    }
}
