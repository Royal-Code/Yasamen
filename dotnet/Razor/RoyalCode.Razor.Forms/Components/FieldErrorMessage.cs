using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     Mensagem de erro de validação associada a um campo específico.
/// </para>
/// </summary>
public class FieldErrorMessage : ErrorMessage
{
    /// <summary>
    /// <para>
    ///     Campo específico associado ao erro de validação.
    /// </para>
    /// <para>
    ///     Deve ser o mesmo nome do <see cref="FieldIdentifier"/> usando em algum componente
    ///     que herde de <c>FieldBase</c>.
    /// </para>
    /// </summary>
    public required string FieldName { get; set; }
}