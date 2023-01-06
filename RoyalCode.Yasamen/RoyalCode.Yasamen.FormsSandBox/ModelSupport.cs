using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Localization;
using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Forms;

public sealed class ModelSupport<TModel> : ComponentBase, IDisposable
    where TModel : class, new()
{
    private bool initialized;
    private bool hasBinding;
    private TModel model;
    private ModelContext<TModel> context = null!;
    private ChangeSupportListener? changeSupportListener;
    private ChangeSupport? messageFieldChangeSupport;

    private IModelFinder<TModel> finder = null!;

    [Inject]
    public IDataServicesProvider DataServicesProvider { get; set; } = null!;

    [Inject]
    public IStringLocalizer Localizer { get; set; } = null!;

    [Parameter]
    public TModel? Model { get; set; }

    [Parameter]
    public EventCallback<TModel> ModelChanged { get; set; }

    [Parameter]
    public Expression<Func<TModel>>? ModelExpression { get; set; }

    [Parameter]
    public RenderFragment<TModel> ChildContent { get; set; } = null!;

    [Parameter]
    public string? ChangeSupport { get; set; }

    [Parameter]
    public string? FilterSupport { get; set; }

    [Parameter]
    public string? MessageFieldSupport { get; set; }

    [CascadingParameter]
    public IModelContext CascadeModelContext { get; set; } = null!;

    public ModelSupport()
    {
        // todo: atribuir no parameter set
        //context = new(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Tracer.Write("ModelSupport", "BuildRenderTree", "Begin");

        builder.OpenComponent<CascadingValue<ModelContext<TModel>>>(0);

        builder.AddAttribute(1, "Value", context);
        builder.AddAttribute(2, "IsFixed", true);

        if (ChildContent.IsNotEmptyFragment())
            builder.AddAttribute(3, "ChildContent", Fragment);
        else
            Tracer.Write("ModelSupport", "BuildRenderTree", "ChildContent is Empty");

        builder.CloseComponent();

        Tracer.Write("ModelSupport", "BuildRenderTree", "End");
    }

    private RenderFragment Fragment => builder => ChildContent(context.Model)(builder);

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (CascadeModelContext is null)
        {
            throw new InvalidOperationException(
                $"{GetType()} requires a cascading parameter "
                + "of type ModelContext. For example, you can use "
                + GetType().FullName + " inside a ModelEditor.");
        }

        hasBinding = ModelExpression is not null;

        if (hasBinding && Model is null)
        {
            throw new InvalidOperationException(
                $"{GetType()} does not support null value for the 'Model' parameter when have two-way binding.");
        }

        if (initialized)
        {
            if (!ReferenceEquals(context.Parent, CascadeModelContext))
            {
                throw new InvalidOperationException(
                $"{GetType()} does not support changing the {nameof(ModelContext<object>)} dynamically.");
            }

            if (hasBinding && !ReferenceEquals(Model, context.Model))
            {
                Tracer.Write("ModelEditor", "SetParametersAsync", "Model has changed");

                model = Model!;
                context = new ModelContext<TModel>(model, CascadeModelContext);

                changeSupportListener?.Dispose();
                changeSupportListener = null;
                messageFieldChangeSupport?.Reset();
                messageFieldChangeSupport = null;
            }
        }
        else
        {
            model = Model ?? new();
            context = new ModelContext<TModel>(model, CascadeModelContext);

            //var alias = EditContext.Properties["Alias"] as string ?? string.Empty;
            //finder = DataServicesProvider.GetFinder<TModel>(alias);

            initialized = true;
        }

        if (FilterSupport is not null && changeSupportListener is null)
        {
            changeSupportListener = context.PropertyChangeSupport
                .GetChangeSupport(FilterSupport)
                .OnAnyChanged(FindModelAsync);
        }

        if (MessageFieldSupport is not null && messageFieldChangeSupport is null)
        {
            messageFieldChangeSupport = context.PropertyChangeSupport.GetChangeSupport(MessageFieldSupport);
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    private async Task FireModelChange(TModel model)
    {
        Tracer.Write("ModelSupport", "FireModelChange", "Begin");

        if (hasBinding)
        {
            await ModelChanged.InvokeAsync(model);
        }
        else
        {
            this.model = model;
            StateHasChanged();
        }

        Tracer.Write("ModelSupport", "FireModelChange", "Begin");
    }

    protected async void FindModelAsync(FieldIdentifier fieldIdentifier, object? oldValue, object? newValue)
    {
        Tracer.Write("ModelSupport", "FindModelAsync", $"Begin, field: {fieldIdentifier.FieldName}, old: {oldValue}, new: {newValue}.");

        var field = messageFieldChangeSupport?.Identifier ?? fieldIdentifier;

        // Em vez de iniciar tempo com um modelo em branco, é simplesmente declado
        //var temp = new TModel();
        TModel? temp = null;

        // a comando abaixo é comentada pois o método não existe,
        // alem disso, um modelo em branco não é pretendido usar.
        // no comando seguinte, é atribuído que o container está sendo carregado.
        // o que substitui o comando comentado.
        //context.StartingLoad(temp);
        context.InternalConteinerState.IsLoading = true;

        ClearMessage(field);

        // aqui, não disparamos esse vento pq irá fazer o redraw de tudo,
        // e também pq não usamos esse temp, por hora....
        // pode ser alterado os fields, que exibirão uma animação de load,
        // para exibir um valor em branco enquanto o load não terminar.
        //await FireModelChange(temp);

        try
        {
            temp = await finder.FindAsync(newValue);
            if (temp is null)
            {
                Tracer.Write("ModelSupport", "FindModelAsync", "Finder ResultNotFound");

                // em vez executar um ResultNotFound em context, mais abaixo é terminado o loading
                //temp = context.ResultNotFound();

                // TODO: usar WellKnownLabels
                AddMessage(field, Localizer["Not found"]);
            }
            else
            {
                Tracer.Write("ModelSupport", "FindModelAsync", $"Finder ResultFound");

                // em vez executar um ResultFound em context, mais abaixo é terminado o loading
                //context.ResultFound();
            }

            context.InternalConteinerState.IsLoading = false;
        }
        catch (Exception ex)
        {
            Tracer.Write("ModelSupport", "FindModelAsync", $"Finder Exception '{ex.Message}'.");

            // em vez executar um ResultError em context, mais abaixo é terminado o loading
            //temp = context.ResultError(ex);

            AddMessage(field, ex.Message);

            context.InternalConteinerState.IsLoading = false;
        }

        if (temp is not null)
            await FireModelChange(temp);
        
        Tracer.Write("ModelSupport", "FindModelAsync", "End");
    }

    private void ClearMessage(FieldIdentifier field)
    {
        context.EditorMessages.Clear(field);
    }

    private void AddMessage(FieldIdentifier field, string message)
    {
        context.EditorMessages.Add(field, ResultMessage.Error(message));
    }

    public void Dispose()
    {
        Tracer.Write("ModelSupport", "Dispose", "Begin");

        context.EditorMessages.Clear(model);
        changeSupportListener?.Dispose();
        changeSupportListener = null;
        messageFieldChangeSupport?.Reset();
        messageFieldChangeSupport = null;

        Tracer.Write("ModelSupport", "Dispose", "End");
    }
}
