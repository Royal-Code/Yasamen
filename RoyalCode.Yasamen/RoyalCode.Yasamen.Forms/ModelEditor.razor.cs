
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public partial class ModelEditor<TModel>
{
    internal EditContext editContext = null!;

    [Parameter]
    public TModel? Model { get; set; }

    [Parameter]
    public ModelContext<TModel>? ModelContext { get; set; }

    [Parameter]
    public string Alias { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment<TModel>? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public PropertyChangeSupport Support { get; set; } = null!;

    [Inject]
    public IOptionsMonitor<ModelFieldOptions> FieldsOptions { get; set; } = null!;

    protected override void OnParametersSet()
    {
        Tracer.Write("ModelEditor", "OnParametersSet", "Begin");
        
        bool contextWasCreated = false;
        if (ModelContext is null)
        {
            if (Model is null)
                throw new ArgumentException("The ModelEditor component requires a Model or ModelContext");

            ModelContext = CreateModelContext(Model);

            contextWasCreated = true;
        }

        if (Model is null)
        {
            Model = ModelContext.Model;
        }
        else if (!contextWasCreated)
        {
            ModelContext = CreateModelContext(Model);
        }

        Support ??= new PropertyChangeSupport();

        editContext = new(Model)
        {
            Properties =
            {
                [ModelContext.GetType()] = ModelContext,
                ["Alias"] = Alias,
                [typeof(ModelContext)] = ModelContext,
                [typeof(PropertyChangeSupport)] = Support
            }
        };

        base.OnParametersSet();
        
        Tracer.Write("ModelEditor", "OnParametersSet", "End");
    }

    private ModelContext<TModel> CreateModelContext(TModel model)
    {
        var name = Alias == string.Empty ? typeof(TModel).Name : $"{typeof(TModel).Name}.{Alias}";
        var options = FieldsOptions.Get(name);
        return new ModelContext<TModel>(model, Alias, options.Fields);
    }
}
