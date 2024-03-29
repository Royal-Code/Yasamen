﻿
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

    public void Build(ClassesCollection classes)
    {
        if (condition())
            classes.Add(cssClass);
    }
}

internal class CssClassCondition<T> : ICssClassBuilder<T>
{
    private readonly Func<T, bool> condition;
    private readonly string cssClass;

    public CssClassCondition(Func<T, bool> condition, string cssClass)
    {
        this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
        this.cssClass = cssClass ?? throw new ArgumentNullException(nameof(cssClass));
    }

    public void Build(T value, ClassesCollection classes)
    {
        if (string.IsNullOrWhiteSpace(cssClass))
            return;
        
        if (condition(value))
            classes.Add(cssClass);
    }
}