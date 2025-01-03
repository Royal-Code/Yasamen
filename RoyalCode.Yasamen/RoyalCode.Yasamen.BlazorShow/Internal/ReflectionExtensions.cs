using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Reflection;

internal static class ReflectionExtensions
{

    internal static PropertyInfo GetPropertyInfo<TComponent, TProperty>(
        this Expression<Func<TComponent, TProperty>> value)
        where TComponent : class, IComponent
    {
        if (value.Body is not MemberExpression memberExpression)
            throw new ArgumentException("The expression is not a member access expression.", nameof(value));

        if (memberExpression.Member is not PropertyInfo propertyInfo)
            throw new ArgumentException("The member access expression does not access a property.", nameof(value));

        var getMethod = propertyInfo.GetMethod;
        if (getMethod is null)
            throw new ArgumentException("The referenced property does not have a get method.", nameof(value));

        if (getMethod.IsStatic)
            throw new ArgumentException("The referenced property is a static property.", nameof(value));

        return propertyInfo;
    }
}