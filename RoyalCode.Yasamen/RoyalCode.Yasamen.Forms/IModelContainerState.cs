﻿
namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// <para>
///     A class to share the state of a component that can load a model.
/// </para>
/// <para>
///     Used as a cascading parameter.
/// </para>
/// </summary>
public interface IModelContainerState
{
    /// <summary>
    /// If the model is being loaded.
    /// </summary>
    bool IsLoading { get; }

    /// <summary>
    /// If the <see cref="ModelEditor{TModel}"/> uses container.
    bool UsingContainer { get; }
}
