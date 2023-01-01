using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.Layout;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Forms;

public class ModelEditor<TModel> : ComponentBase
{
    private readonly RenderFragment containerFragment;
    private readonly RenderFragment contentFragment;

    private ModelContext<TModel> modelContext = default!;
    private readonly Func<Task> handleSubmitDelegate;
    
    public ModelEditor()
    {
        handleSubmitDelegate = HandleSubmitAsync;
        contentFragment = ContentFragment;
        containerFragment = ContainerFragment;
    }

    [Inject]
    private IValidatorProvider ValidatorProvider { get; set; } = null!;

    [Parameter]
    public ModelContext<TModel>? ModelContext 
    {
        get => modelContext;
        set => modelContext = value ?? throw new ArgumentNullException(nameof(ModelContext));
    }

    [Parameter]
    public TModel? Model
    {
        get => modelContext.Model;
        set => modelContext = new ModelContext<TModel>(value ?? throw new ArgumentNullException(nameof(Model)));
    }

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

    [MemberNotNull(nameof(modelContext))]
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        modelContext ??= new ModelContext<TModel>();
        
        builder.OpenRegion(modelContext.GetHashCode());

        builder.OpenElement(0, "form");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "onsubmit", handleSubmitDelegate);
        builder.OpenComponent<CascadingValue<ModelContext<TModel>>>(3);
        builder.AddAttribute(4, "IsFixed", true);
        builder.AddAttribute(5, "Value", modelContext);
        
        if (UseContainer)
        {
            builder.AddAttribute(6, "ChildContent", containerFragment);
        }
        else
        {
            builder.AddAttribute(7, "ChildContent", contentFragment);
        }
        
        builder.CloseComponent();
        builder.CloseElement();

        builder.CloseRegion();
    }

    private void ContainerFragment(RenderTreeBuilder builder)
    {
        builder.OpenComponent<Container>(0);
        builder.AddAttribute(1, "ChildContent", contentFragment);
        builder.CloseComponent();
    }


    private void ContentFragment(RenderTreeBuilder builder)
    {
        // TODO:    criar o componente para exibir mensagens aqui.

        if (Title is not null)
        {
            builder.OpenElement(0, "fieldset");
            builder.OpenElement(1, "legend");
            builder.AddContent(2, Title);
            builder.CloseElement();
        }

        builder.AddContent(3, ChildContent?.Invoke(modelContext!.Model));

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

    protected override void OnParametersSet()
    {
        if (modelContext is null)
            throw new InvalidOperationException("The ModelContext or the Model property must be set.");

        if (!modelContext.IsInitialized)
        {
            modelContext.Initialize(ValidatorProvider);
        }

        modelContext.InternalConteinerState.UsingContainer = UseContainer;
    }
}
