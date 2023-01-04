using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms;

public class ModelEditor<TModel> : ComponentBase
{
    private readonly RenderFragment contentFragment;
    private readonly RenderFragment childFragment;
    private readonly Func<Task> handleSubmitDelegate;
    
    private ModelContext<TModel> modelContext = default!;
    private bool initialized;
    
    
    public ModelEditor()
    {
        handleSubmitDelegate = HandleSubmitAsync;
        contentFragment = ContentFragment;
        childFragment = ChildFragment;
    }

    [Inject]
    private IValidatorProvider ValidatorProvider { get; set; } = null!;

    [Parameter]
    public ModelContext<TModel>? ModelContext { get; set; }

    [Parameter]
    public TModel? Model { get; set; }

    /// <summary>
    /// If will render a container componente around the children.
    /// </summary>
    [Parameter]
    public bool UseContainer { get; set; } = true;

    /// <summary>
    /// The title of the form, it will render a fielset and legend html element.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// Specifies the content to be rendered inside this <see cref="ModelEditor{TModel}"/>.
    /// </summary>
    [Parameter]
    public RenderFragment<TModel?>? ChildContent { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted.
    ///
    /// If using this parameter, you are responsible for triggering any validation
    /// manually, e.g., by calling <see cref="ModelContext{TModel}.Validate"/>.
    /// </summary>
    [Parameter]
    public EventCallback OnSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="ModelEditor{TModel}"/> is determined to be valid.
    /// </summary>
    [Parameter] 
    public EventCallback OnValidSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="ModelEditor{TModel}"/> is determined to be invalid.
    /// </summary>
    [Parameter]
    public EventCallback OnInvalidSubmit { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created <c>form</c> element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] 
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        Tracer.Write("ModelEditor", "SetParametersAsync", "parameters setted");
        
        if (!initialized)
        {
            Tracer.Write("ModelEditor", "SetParametersAsync", "Initializing ModelContext");

            if (Model is not null)
            {
                modelContext = new ModelContext<TModel>(Model);
            }
            else if (ModelContext is not null)
            {
                modelContext = ModelContext;
            }
            else
            {
                throw new InvalidOperationException("The ModelEditor must have a Model or ModelContext.");
            }
            
            initialized = true;
        }
        else
        {
            if (ModelContext is not null && !ReferenceEquals(ModelContext, modelContext))
            {
                Tracer.Write("ModelEditor", "SetParametersAsync", "Context has changed");
                
                modelContext = ModelContext;
            }
            else if (Model is not null && !ReferenceEquals(Model, modelContext.Model))
            {
                Tracer.Write("ModelEditor", "SetParametersAsync", "Model has changed");

                modelContext = new ModelContext<TModel>(Model);
            }
            else
            {
                Tracer.Write("ModelEditor", "SetParametersAsync", "Nothing changed");
            }
        }

        if (!modelContext.IsInitialized)
        {
            modelContext.Initialize(ValidatorProvider);
        }
        modelContext.InternalConteinerState.UsingContainer = UseContainer;
        
        return base.SetParametersAsync(ParameterView.Empty);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        modelContext ??= new ModelContext<TModel>();
        
        builder.OpenRegion(modelContext.GetHashCode());

        // begin form
        builder.OpenElement(0, "form");
        builder.AddAttribute(1, "b-model-editor");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "onsubmit", handleSubmitDelegate);

        // begin cascade value of model context, the form element content will be rendered inside
        builder.OpenComponent<CascadingValue<ModelContext<TModel>>>(4);
        builder.AddAttribute(5, "IsFixed", true);
        builder.AddAttribute(6, "Value", modelContext);
        builder.AddAttribute(7, "ChildContent", contentFragment);
        
        // end cascade value
        builder.CloseComponent();
        // end form
        builder.CloseElement();

        builder.CloseRegion();
    }

    private void ContentFragment(RenderTreeBuilder builder)
    {
        builder.OpenComponent<MessagesSummary>(0);
        builder.AddAttribute(1, "Model", modelContext.Model);
        builder.CloseComponent();

        if (UseContainer)
            ContainerFragment(builder, 2);
        else
            ChildFragment(builder, 2);
    }

    private void ContainerFragment(RenderTreeBuilder builder, int index)
    {
        builder.OpenComponent<Container>(index);
        builder.AddAttribute(1 + index, "ChildContent", childFragment);
        builder.CloseComponent();
    }
    private void ChildFragment(RenderTreeBuilder builder) => ChildFragment(builder, 0);
    
    private void ChildFragment(RenderTreeBuilder builder, int index)
    {
        if (Title is not null)
        {
            builder.OpenElement(index, "fieldset");
            builder.OpenElement(1 + index, "legend");
            builder.AddContent(2 + index, Title);
            builder.CloseElement();
        }

        builder.AddContent(3 + index, ChildContent?.Invoke(modelContext!.Model));

        if (Title is not null)
        {
            builder.CloseElement();
        }
    }

    private async Task HandleSubmitAsync()
    {
        if (modelContext is null)
            throw new InvalidOperationException("The ModelContext is null.");

        if (OnSubmit.HasDelegate)
        {
            // When using OnSubmit, the developer takes control of the validation lifecycle
            await OnSubmit.InvokeAsync();
        }
        else
        {
            var isValid = modelContext.Validate();

            if (isValid && OnValidSubmit.HasDelegate)
            {
                await OnValidSubmit.InvokeAsync();
            }

            if (!isValid && OnInvalidSubmit.HasDelegate)
            {
                await OnInvalidSubmit.InvokeAsync();
            }
        }
    }
}
