using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalCode.Yasamen.Forms;

public class ModelEditor<TModel> : ComponentBase
{
    private ModelContext<TModel>? modelContext;
    private readonly Func<Task> handleSubmitDelegate;

    public ModelEditor()
    {
        handleSubmitDelegate = HandleSubmitAsync;
    }

    [Parameter]
    public ModelContext<TModel>? ModelContext 
    {
        get => modelContext ??= new ModelContext<TModel>();
        set => modelContext = value;
    }

    /// <summary>
    /// Specifies the content to be rendered inside this <see cref="ModelEditor{TModel}"/>.
    /// </summary>
    [Parameter]
    public RenderFragment<TModel?>? ChildContent { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted.
    ///
    /// If using this parameter, you are responsible for triggering any validation
    /// manually, e.g., by calling <see cref="ModelEditor{TModel}.Validate"/>.
    /// </summary>
    [Parameter]
    public EventCallback<ModelContext<TModel>> OnSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="ModelEditor{TModel}"/> is determined to be valid.
    /// </summary>
    [Parameter] 
    public EventCallback<ModelContext<TModel>> OnValidSubmit { get; set; }

    /// <summary>
    /// A callback that will be invoked when the form is submitted and the
    /// <see cref="ModelEditor{TModel}"/> is determined to be invalid.
    /// </summary>
    [Parameter]
    public EventCallback<ModelContext<TModel>> OnInvalidSubmit { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created <c>form</c> element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] 
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        modelContext ??= new ModelContext<TModel>();

        // If _editContext changes, tear down and recreate all descendants.
        // This is so we can safely use the IsFixed optimization on CascadingValue,
        // optimizing for the common case where _editContext never changes.
        builder.OpenRegion(modelContext.GetHashCode());

        builder.OpenElement(0, "form");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "onsubmit", handleSubmitDelegate);
        builder.OpenComponent<CascadingValue<ModelContext<TModel>>>(3);
        builder.AddAttribute(4, "IsFixed", true);
        builder.AddAttribute(5, "Value", modelContext);
        
        
        builder.AddAttribute(6, "ChildContent", ChildContent?.Invoke(modelContext.Model));
        
        
        builder.CloseComponent();
        builder.CloseElement();

        builder.CloseRegion();
    }


    private async Task HandleSubmitAsync()
    {
        if (OnSubmit.HasDelegate)
        {
            // When using OnSubmit, the developer takes control of the validation lifecycle
            await OnSubmit.InvokeAsync(modelContext);
        }
        else
        {
            // Otherwise, the system implicitly runs validation on form submission
            var isValid = modelContext.Validate(); // This will likely become ValidateAsync later

            if (isValid && OnValidSubmit.HasDelegate)
            {
                await OnValidSubmit.InvokeAsync(modelContext);
            }

            if (!isValid && OnInvalidSubmit.HasDelegate)
            {
                await OnInvalidSubmit.InvokeAsync(modelContext);
            }
        }
    }
}
