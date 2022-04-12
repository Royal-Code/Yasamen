using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace RoyalCode.Yasamen.Forms;

public class ModelContainer<TModel> : ComponentBase, IDisposable
    where TModel : class, new()
{
    // private readonly FinderContext<TModel> context;

    private ValidationMessageStore messageStore;
    // private PropertyChangedSupport propertyChangedSupport;
    // private ChangeSupport fieldChangeSupport;
    // private ChangeSupportListener changeSupportListener;

    public ModelContainer()
    {
        //context = new FinderContext<TModel>(this);
    }

    // [Inject] 
    // public FinderService FinderService { get; set; }
    //
    // [Inject] 
    // public IStringLocalizer Localizer { get; set; }

    [Parameter] 
    public RenderFragment<TModel> ChildContent { get; set; }

    [Parameter] 
    public TModel Model { get; set; }

    [Parameter] 
    public EventCallback<TModel> ModelChanged { get; set; }

    [Parameter] 
    public Expression<Func<TModel>> ModelExpression { get; set; }

    [Parameter]
    public string FindHandler { get; set; }

    [Parameter] 
    public string FieldSupport { get; set; }

    [CascadingParameter]
    public EditContext EditContext { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // builder.OpenComponent<CascadingValue<ISharedFieldState>>(0);
        // builder.AddAttribute(1, "Value", context);
        // builder.AddAttribute(2, "IsFixed", true);
        // builder.AddAttribute(3, "ChildContent", ChildContent(context.Model));
        // builder.CloseComponent();
    }

    protected override void OnInitialized()
    {
        if (EditContext is null)
        {
            throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
                                                "of type EditContext. For example, you can use " + GetType().FullName +
                                                " inside an EditForm.");
        }

        // propertyChangedSupport = EditContext.TryGetItem<PropertyChangedSupport>();
        //
        // if (FindHandler is not null && propertyChangedSupport is not null)
        // {
        //     changeSupportListener = propertyChangedSupport.GetChangeSupport(FindHandler).OnAnyChanged(FindModelAsync);
        // }
        //
        // if (FieldSupport is not null && propertyChangedSupport is not null)
        // {
        //     fieldChangeSupport = propertyChangedSupport.GetChangeSupport(FieldSupport);
        // }

        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        if (Model is null)
        {
            Model = new TModel();
            await FireModelChange(Model);
        }

        await base.OnInitializedAsync();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

    protected virtual async Task FireModelChange(TModel model)
    {
        await ModelChanged.InvokeAsync(model);
    }

    protected async void FindModelAsync(FieldIdentifier fieldIdentifier, object oldValue, object newValue)
    {
        // //Console.WriteLine($"Finder Start {field}, {oldValue}, {newValue}");
        //
        // var field = fieldChangeSupport is not null ? fieldChangeSupport.Identifier : fieldIdentifier;
        //
        // var temp = new TModel();
        // context.StartingLoad(temp);
        // ClearMessage(field);
        //
        // await FireModelChange(temp);
        //
        // try
        // {
        //     temp = await FinderService.FindAsync<TModel>(newValue);
        //     if (temp is null)
        //     {
        //         //Console.WriteLine("Finder ResultNotFound");
        //
        //         temp = context.ResultNotFound();
        //         AddMessage(field, Localizer.GetString("Não encontrado"));
        //     }
        //     else
        //     {
        //         //Console.WriteLine($"Finder ResultFound");
        //
        //         context.ResultFound();
        //     }
        // }
        // catch (Exception ex)
        // {
        //     //Console.WriteLine($"Finder Exception '{ex.Message}'.");
        //
        //     temp = context.ResultError(ex);
        //     AddMessage(field, ex.Message);
        // }
        //
        // await FireModelChange(temp);
        //
        // //Console.WriteLine("Finder StateHasChanged");
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
        //changeSupportListener?.Dispose();
        //changeSupportListener = null;
    }
}