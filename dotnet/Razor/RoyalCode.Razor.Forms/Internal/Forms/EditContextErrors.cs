using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Razor.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Internal.Forms;

/// <summary>
/// <para>
///     Coleção de erros de validação para formulários.
/// </para>
/// <para>
///     Use com componente <see cref="FormValidations"/>.
/// </para>
/// </summary>
public class EditContextErrors
{
    private readonly Dictionary<string, FieldBase> fieldErrors = [];
    private List<ErrorMessage>? generalErros;
    private EditContext? editContext;

    /// <summary>
    /// Erros de validação sem campo específico. Mensagens gerais que não estão associadas a um campo específico.
    /// </summary>
    public IReadOnlyList<ErrorMessage> GeneralErrors => generalErros ?? [];

    /// <summary>
    /// <para>
    ///     Atribui o EditContext associado a este conjunto de erros.
    ///     Esta associação é feita automaticamente pelo componente <see cref="FormValidations"/>.
    /// </para>
    /// </summary>
    internal void UseEditContext(EditContext editContext)
    {
        ArgumentNullException.ThrowIfNull(editContext);

        if (this.editContext is not null && ReferenceEquals(this.editContext, editContext))
            return;

        if (this.editContext is not null)
        {
            // Limpa os erros associados ao EditContext anterior
            Clear();
            // Remove Item do EditContext anterior
            this.editContext.Properties.Remove(nameof(EditContextErrors));
        }

        this.editContext = editContext;

        // Adiciona este FormErrors ao EditContext atual
        this.editContext.Properties[nameof(EditContextErrors)] = this;
    }

    /// <summary>
    /// Remove todos os erros de validação.
    /// </summary>
    public void Clear()
    {
        generalErros?.Clear();
        foreach (var item in fieldErrors.Values)
            item.ClearErrorMessages();
        fieldErrors.Clear();
    }

    /// <summary>
    /// Adiciona uma mensagem de erro de validação geral (não associada a um campo específico).
    /// </summary>
    /// <param name="text">O texto da mensagem de erro.</param>
    /// <param name="type">Opcional, o tipo ou identificador da mensagem de erro.</param>
    public void AddError(string text, string? type = null)
    {
        AddError(new ErrorMessage { Text = text, Type = type });
    }

    /// <summary>
    /// Adiciona uma mensagem de erro de validação associada a um campo específico.
    /// </summary>
    /// <param name="fieldName">
    ///     O nome do campo associado ao erro.
    ///     Deve corresponder ao nome usado em um componente que herde de <see cref="FieldBase{TValue}"/>.
    /// </param>
    /// <param name="text">O texto da mensagem de erro.</param>
    /// <param name="type">Opcional, o tipo ou identificador da mensagem de erro.</param>
    public void AddInputError(string fieldName, string text, string? type = null)
    {
        AddError(new FieldErrorMessage { FieldName = fieldName, Text = text, Type = type });
    }

    /// <summary>
    /// Adiciona uma mensagem de erro de validação, que pode ser geral ou associada a um campo específico.
    /// </summary>
    /// <param name="error"></param>
    public void AddError(ErrorMessage error)
    {
        ArgumentNullException.ThrowIfNull(error);

        if (error is FieldErrorMessage inputError)
        {
            AddError(inputError);
        }
        else
        {
            generalErros ??= [];
            generalErros.Add(error);
        }

    }

    /// <summary>
    /// Adiciona uma mensagem de erro de validação associada a um campo específico.
    /// </summary>
    /// <param name="error"></param>
    public void AddError(FieldErrorMessage error)
    {
        ArgumentNullException.ThrowIfNull(error);

        if (editContext is not null && error.FieldName.IsPresent())
        {
            if (fieldErrors.TryGetValue(error.FieldName, out var storedField))
            {
                storedField.AddErrorMessage(error);
            }
            else if (editContext.Properties[new FieldIdentifier(editContext.Model, error.FieldName)] is FieldBase field)
            {
                field.AddErrorMessage(error);
                fieldErrors.Add(error.FieldName, field);
                return;
            }
        }

        // erros gerais

        generalErros ??= [];
        generalErros.Add(error);
    }

    /// <summary>
    /// Remove um erro de validação geral pelo tipo ou identificador.
    /// </summary>
    /// <param name="type"></param>
    public void RemoveError(string type)
    {
        generalErros?.RemoveAll(e => e.Type == type);
    }

    /// <summary>
    /// Remove um erro de validação associado a um campo específico pelo nome do campo e tipo ou identificador do erro.
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="type"></param>
    public void RemoveInputError(string fieldName, string type)
    {
        if (fieldErrors.TryGetValue(fieldName, out var field))
            field.RemoveErrorMessage(type);

        RemoveError(type);
    }

    /// <summary>
    /// Limpa todos os erros de validação associados a um campo específico.
    /// </summary>
    /// <param name="fieldName"></param>
    public void ClearInputErros(string fieldName)
    {
        if (fieldErrors.TryGetValue(fieldName, out var field))
            field.ClearErrorMessages();
        
        generalErros?.OfType<FieldErrorMessage>()
            .Where(e => e.FieldName == fieldName)
            .ToList()
            .ForEach(e => generalErros?.Remove(e));
    }
}
