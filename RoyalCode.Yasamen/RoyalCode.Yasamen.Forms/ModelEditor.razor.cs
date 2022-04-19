
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public partial class ModelEditor<TModel>
{
    internal EditContext? editContext;

    [Parameter]
    public TModel? Model { get; set; }

    [Parameter]
    public ModelContext<TModel>? ModelContext { get; set; }

    [Parameter]
    public string Alias { get; set; } = string.Empty;

    [Parameter] 
    public RenderFragment<TModel> ChildContent { get; set; } = null!;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public PropertyChangeSupport? Support { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted.
    ///
    /// If using this parameter, you are responsible for triggering any validation
    /// manually, e.g., by calling <see cref="EditContext.Validate"/>.
    /// </summary>
    [Parameter] public EventCallback<EditContext> OnSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="EditContext"/> is determined to be valid.
    /// </summary>
    [Parameter] public EventCallback<EditContext> OnValidSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="EditContext"/> is determined to be invalid.
    /// </summary>
    [Parameter] public EventCallback<EditContext> OnInvalidSubmit { get; set; }

    protected override void OnParametersSet()
    {
        Tracer.Write("ModelEditor", "OnParametersSet", "Begin");
        
        bool contextWasCreated = false;
        if (ModelContext is null)
        {
            if (Model is null)
                throw new ArgumentException("The ModelEditor component requires a Model or ModelContext");

            ModelContext = new(Model, Alias);

            contextWasCreated = true;
        }

        if (Model is null)
        {
            Model = ModelContext.Model;
        }
        else if (!contextWasCreated)
        {
            ModelContext = new(Model, Alias);
        }

        Support ??= new PropertyChangeSupport();

        editContext ??= new(Model!)
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
}
