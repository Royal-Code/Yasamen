namespace RoyalCode.Yasamen.Commons;

public interface ICssMapBuilder<T>
{
    ICssMapBuilder<T> Add(Func<T, bool> condition, Func<T, string?> cssClass);
    
    ICssMapBuilder<T> Add(Func<T, bool> condition, params Func<T, string?>[] cssClass);
    
    ICssMapBuilder<T> Add(Func<T, bool> condition, string cssClass);
    
    ICssMapBuilder<T> Add(Func<T, bool> condition, string cssClassWhenTrue, string cssClassWhenFalse);
    
    ICssMapBuilder<T> Add(Func<T, string?> cssClass);

    ICssMapBuilder<T> Add(string? cssClass);
    
    ICssMapBuilder<T> Add(params string?[] cssClasses);

    CssMap<T> Build();
}