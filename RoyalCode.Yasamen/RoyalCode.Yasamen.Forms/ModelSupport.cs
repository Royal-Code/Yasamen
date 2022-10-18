using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Localization;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;
using RoyalCode.Yasamen.Services;

namespace RoyalCode.Yasamen.Forms;

public class ModelSupport<TModel> : ComponentBase, IDisposable
    where TModel : class, new()
{
    private readonly ModelSupportContext<TModel> context;
    private ValidationMessageStore? messageStore;
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
    public PropertyChangeSupport PropertyChangeSupport { get; set; } = null!;
    
    [CascadingParameter]
    public EditContext EditContext { get; set; } = null!;

    public ModelSupport()
    {
        context = new(this);
    }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Tracer.Write("ModelSupport", "BuildRenderTree", "Begin");
        
        builder.OpenComponent<CascadingValue<IModelLoadingState>>(0);
        
        builder.AddAttribute(1, "Value", context);
        builder.AddAttribute(2, "IsFixed", true);
        
        if (ChildContent.IsNotEmptyFragment())
            builder.AddAttribute(3, "ChildContent",  Fragment);
        else
            Tracer.Write("ModelSupport", "BuildRenderTree", "ChildContent is Empty");
        
        builder.CloseComponent();
        
        Tracer.Write("ModelSupport", "BuildRenderTree", "End");
    }

    private RenderFragment Fragment => builder => ChildContent(context.Model)(builder);

    protected override void OnInitialized()
    {
        Tracer.Write("ModelSupport", "OnInitialized", "Begin");
        
        if (EditContext is null)
        {
            throw new InvalidOperationException(
                $"{GetType()} requires a cascading parameter "
                + "of type EditContext. For example, you can use " 
                + GetType().FullName + " inside a ModelEditor.");
        }

        if (PropertyChangeSupport is null)
        {
            throw new InvalidOperationException(
                $"{GetType()} requires a cascading parameter " 
                + "of type PropertyChangeSupport. For example, you can use " 
                + GetType().FullName + " inside a ModelEditor.");
        }

        if (FilterSupport is not null)
        {
            changeSupportListener = PropertyChangeSupport.GetChangeSupport(FilterSupport)
                .OnAnyChanged(FindModelAsync);
        }

        if (MessageFieldSupport is not null)
        {
            messageFieldChangeSupport = PropertyChangeSupport.GetChangeSupport(MessageFieldSupport);
        }

        var alias = EditContext.Properties["Alias"] as string ?? string.Empty;
        finder = DataServicesProvider.GetFinder<TModel>(alias);
        
        base.OnInitialized();
        
        Tracer.Write("ModelSupport", "OnInitialized", "End");
    }
    
    protected override async Task OnInitializedAsync()
    {
        Tracer.Write("ModelSupport", "OnInitializedAsync", "Begin");
        
        if (Model is null)
        {
            Model = new TModel();
            //await FireModelChange(Model);
        }

        await base.OnInitializedAsync();
        
        Tracer.Write("ModelSupport", "OnInitializedAsync", "End");
    }

    protected virtual async Task FireModelChange(TModel model)
    {
        Tracer.Write("ModelSupport", "FireModelChange", "Begin");
        
        await ModelChanged.InvokeAsync(model);

        Tracer.Write("ModelSupport", "FireModelChange", "Begin");
    }
    
    protected async void FindModelAsync(FieldIdentifier fieldIdentifier, object? oldValue, object? newValue)
    {
        Tracer.Write("ModelSupport", "FindModelAsync", $"Begin, field: {fieldIdentifier.FieldName}, old: {oldValue}, new: {newValue}.");

        var field = messageFieldChangeSupport?.Identifier ?? fieldIdentifier;

        var temp = new TModel();
        context.StartingLoad(temp);
        ClearMessage(field);

        await FireModelChange(temp);

        try
        {
            temp = await finder.FindAsync(newValue);
            if (temp is null)
            {
                Tracer.Write("ModelSupport", "FindModelAsync", "Finder ResultNotFound");

                temp = context.ResultNotFound();
                AddMessage(field, Localizer["Not found"]);
            }
            else
            {
                Tracer.Write("ModelSupport", "FindModelAsync", $"Finder ResultFound");

                context.ResultFound();
            }
        }
        catch (Exception ex)
        {
            Tracer.Write("ModelSupport", "FindModelAsync", $"Finder Exception '{ex.Message}'.");

            temp = context.ResultError(ex);
            AddMessage(field, ex.Message);
        }

        Model = temp;
        EditContext.NotifyFieldChanged(field);

        await FireModelChange(temp);
        StateHasChanged();

        Tracer.Write("ModelSupport", "FindModelAsync", "End");
    }
    
    private void ClearMessage(FieldIdentifier field)
    {
        if (messageStore is null)
            return;

        messageStore.Clear();
        EditContext.NotifyFieldChanged(field);
    }

    private void AddMessage(FieldIdentifier field, string message)
    {
        messageStore ??= new ValidationMessageStore(EditContext);
        messageStore.Add(field, message);
        EditContext.NotifyFieldChanged(field);
    }
    
    public void Dispose()
    {
        Tracer.Write("ModelSupport", "Dispose", "Begin");
        
        changeSupportListener?.Dispose();
        changeSupportListener = null;
        
        Tracer.Write("ModelSupport", "Dispose", "End");
    }
}