﻿using RoyalCode.OperationResults;

namespace RoyalCode.Yasamen.Forms.Validation;

/// <summary>
/// <para>
///     Interface to validate a model.
/// </para>
/// </summary>
/// <typeparam name="TModel">The type of the model.</typeparam>
public interface IValidator<in TModel>
{
    /// <summary>
    /// <para>
    ///     Validate the model.
    /// </para>
    /// </summary>
    /// <param name="model">The model to be validated.</param>
    /// <returns>The result of the validation.</returns>
    ValidableResult Validate(TModel model);
}
