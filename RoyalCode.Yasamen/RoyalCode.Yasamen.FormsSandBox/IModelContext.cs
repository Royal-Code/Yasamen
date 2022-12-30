using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     Um context que contém um modelo que é editado em um formulário.
/// </para>
/// <para>
///     Os modelos podem ser editados em um formulário de forma aninhada,
///     assim um contexto pode conter um outro contexto.
/// </para>
/// <para>
///     O contexto pode ser usado para validar o modelo e para notificar
///     os componentes que o modelo foi alterado.
///     Isto é feito através do <see cref="EditorMessages"/>.
/// </para>
/// </summary>
public interface IModelContext
{
    object? GetModel();

    IModelContext? Parent { get; }

    EditorMessages EditorMessages { get; }

    PropertyChangeSupport PropertyChangeSupport { get; }

    string GetModelNameIdentifier()
    {
        var parentName = Parent?.GetModelNameIdentifier();
        if (parentName is not null)
            return $"{parentName}.{GetModelName()}";
        else
            return GetModelName();
    }

    private string GetModelName() => GetModel()?.GetType().Name ?? "_";
}
