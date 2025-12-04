namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     Representa uma mensagem de erro de validação, não necessariamente associada a um campo específico.
/// </para>
/// <para>
///     Para mensagens assiciadas a campos específicos, utilize <see cref="FieldErrorMessage"/>.
/// </para>
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// Tipo ou identificador da mensagem de erro.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Texto da mensagem de erro.
    /// </summary>
    public required string Text { get; set; }
}
