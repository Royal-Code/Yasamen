using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public class ModelEditor<TModel> : ComponentBase
    where TModel : class
{
    private EditContext editContext = null!;

    [Parameter]
    public TModel? Model { get; set; }

    [Parameter]
    public ModelContext<TModel>? ModelContext { get; set; }

    [Parameter]
    public string Alias { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment<TModel> ChildContent { get; set; } = null!;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? Attributes { get; set; }

    [Parameter]
    public PropertyChangeSupport Support { get; set; } = null!;

    [Inject]
    public IOptionsMonitor<ModelFieldOptions> FieldsOptions { get; set; } = null!;

    protected override void OnParametersSet()
    {
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
                [typeof(ModelContext)] = ModelContext,
                [typeof(PropertyChangeSupport)] = Support
            }
        };

        base.OnParametersSet();
    }

    private ModelContext<TModel> CreateModelContext(TModel model)
    {
        var name = Alias == string.Empty ? typeof(TModel).Name : $"{typeof(TModel).Name}.{Alias}";
        var options = FieldsOptions.Get(name);
        return new ModelContext<TModel>(model, Alias, options.Fields);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenRegion(Support!.GetHashCode());

        builder.OpenComponent<CascadingValue<PropertyChangeSupport>>(0);
        builder.AddAttribute(1, "IsFixed", true);
        builder.AddAttribute(2, "Value", Support);

        builder.OpenComponent<ModelForm>(3);
        builder.AddAttribute(4, "EditContext", editContext);
        builder.AddMultipleAttributes(5, Attributes);

        builder.AddAttribute(6, "ChildContent", ChildContent?.Invoke(Model!));

        builder.CloseComponent();
        builder.CloseComponent();

        builder.CloseRegion();
    }
}
