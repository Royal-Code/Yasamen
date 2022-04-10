﻿
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// A context that holds the model to edit and the fields options.
/// </summary>
/// <typeparam name="TModel">The model type</typeparam>
public class ModelContext<TModel>
{
    public ModelContext(TModel model, IEnumerable<FieldOptions> options)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Options = options;
    }

    public TModel Model { get; }

    public IEnumerable<FieldOptions> Options { get; }

    internal Task Submit()
    {
        return Task.CompletedTask;
    }
}

public class ModelFieldOptions
{
    private readonly List<FieldOptions> fieldOptions;

    public IEnumerable<FieldOptions> Fields => fieldOptions.AsEnumerable();

    public void AddField(FieldOptions fieldOptions) => this.fieldOptions.Add(fieldOptions);
}

public class FieldOptions
{
    public FieldOptions(Type modelType, string fieldName)
    {
        ModelType = modelType;
        FieldName = fieldName;
    }

    public Type ModelType { get; }

    public string FieldName { get; }


}