using Microsoft.AspNetCore.Components;
using System.Text;

namespace RoyalCode.Yasamen.Commons;

// <summary>
/// Struct para construir classes CSS.
/// </summary>
public struct CssClasses
{
    /// <summary>
    /// Implementação do operador de conversão implícita para string
    /// </summary>
    /// <param name="cssClasses"></param>
    public static implicit operator string(CssClasses cssClasses)
    {
        return cssClasses.ToString();
    }

    // campos 
    private string? first;
    private StringBuilder? builder;

    /// <summary>
    /// Cria nova struct de <see cref="CssClasses"/>.
    /// </summary>
    /// <param name="first"></param>
    public CssClasses(string? first)
    {
        this.first = first;
    }

    /// <summary>
    /// Adiciona uma classe a string de classes, caso o valor other esteja presente.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public CssClasses AddClass(string? other)
    {
        if (other.IsPresent())
        {
            if (first is null)
            {
                first = other;
            }
            else if (builder is null)
            {
                builder = new StringBuilder(first).Append(' ').Append(other);
            }
            else
            {
                builder.Append(' ').Append(other);
            }
        }

        return this;
    }

    /// <summary>
    /// Adiciona uma classe se a condição for atendida e caso o valor other esteja presente.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public CssClasses AddClass(bool condition, string? other)
    {
        return condition
            ? AddClass(other)
            : this;
    }

    /// <summary>
    /// Adiciona uma das duas classes conforme a condição.
    /// </summary>
    /// <param name="condition">Condição</param>
    /// <param name="otherWhenTrue">Classe para quando satisfazer a condição.</param>
    /// <param name="otherWhenFalse">Classe para quando não satisfazer a condição.</param>
    /// <returns></returns>
    public CssClasses AddClass(bool condition, string? otherWhenTrue, string? otherWhenFalse)
    {
        return condition
            ? AddClass(otherWhenTrue)
            : AddClass(otherWhenFalse);
    }

    /// <summary>
    /// Adiciona uma classe proveniente de uma função, caso o valor value esteja presente.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="function"></param>
    /// <returns></returns>
    public CssClasses AddClass<T>(T? value, Func<T, string?> function)
    {
        if (value is not null)
        {
            return AddClass(function(value));
        }
        return this;
    }

    /// <summary>
    /// Adiciona uma classe proveniente de uma função, caso os valores value1 e value2 estejam presentes.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="function"></param>
    /// <returns></returns>
    public CssClasses AddClass<T1, T2>(T1? value1, T2? value2, Func<T1, T2, string?> function)
    {
        if (value1 is not null && value2 is not null)
        {
            return AddClass(function(value1, value2));
        }
        return this;
    }

    /// <summary>
    /// Obtém a string que representa as classes.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return builder?.ToString() ?? first ?? string.Empty;
    }
}