using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Services;

/// <summary>
/// Data service used to load a collection of models.
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IModelLoader<TModel>
{
    /// <summary>
    /// Determines whether the data models then being loaded.
    /// </summary>
    bool IsLoading { get; }

    /// <summary>
    /// If an error occurred when loading the data.
    /// </summary>
    [MemberNotNullWhen(true, nameof(LoadException))]
    bool HasError { get; }

    /// <summary>
    /// Determines whether there are any records, considering the loading to be finalised.
    /// </summary>
    bool Any { get; }

    /// <summary>
    /// If <see cref="LoadAsync"/> never was executed.
    /// </summary>
    bool NotLoaded { get; }

    /// <summary>
    /// If <see cref="LoadAsync"/> never was executed, or the first load not finalised.
    /// </summary>
    bool IsFirstLoad { get; }

    /// <summary>
    /// Loaded values.
    /// </summary>
    IReadOnlyList<TModel> Values { get; }

    /// <summary>
    /// Exception occurred when loading the data.,
    /// This property will not be null when <see cref="HasError"/> is true.
    /// </summary>
    Exception? LoadException { get; }

    /// <summary>
    /// Performs the loading of data models.
    /// </summary>
    Task LoadAsync(CancellationToken token = default);

    /// <summary>
    /// Adds an action to be notified (listen) when the state of the component is changed.
    /// </summary>
    /// <param name="callback">Callback action.</param>
    void AddListener(Func<IModelLoader<TModel>, ValueTask> callback);

    /// <summary>
    /// Removes a listener from the change of state of the component.
    /// </summary>
    /// <param name="callback">The Callback action.</param>
    void RemoveListener(Func<IModelLoader<TModel>, ValueTask> callback);
}

/// <summary>
/// Data service used to load a collection of models.
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IModelLoader<TModel, TFilter> : IModelLoader<TModel>, IFilterableLoader<TFilter>
{
    /// <summary>
    /// Executa o carregamento dos modelos de dados utilizando o filtro.
    /// </summary>
    /// <param name="filter">Filtro.</param>
    /// <returns>Task para processamento assíncrono.</returns>
    Task LoadAsync(TFilter filter);
}


/// <summary>
/// Interface auxiliar para componentes/serviços de carregamento de modelos de dados que possuem um filtro
/// para o carregamento.
/// </summary>
public interface IFilterableLoader
{
    ///// <summary>
    ///// Adiciona um componente de suporte para escutar alterações no valor do filtro.
    ///// </summary>
    ///// <param name="support">Componente de suporte para escutar alterações em valores e propriedades.</param>
    //ChangeSupportListener AddFilterSupport(ChangeSupport support);
}

/// <summary>
/// Interface auxiliar para componentes/serviços de carregamento de modelos de dados que possuem um filtro
/// para o carregamento.
/// </summary>
/// <typeparam name="TFilter"></typeparam>
public interface IFilterableLoader<TFilter> : IFilterableLoader
{
    /// <summary>
    /// Filtro atual.
    /// </summary>
    TFilter CurrentFilter { get; set; }
}
