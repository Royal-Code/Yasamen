
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Forms;

public class ModelContainer<TModel> : ComponentBase, IDisposable
    where TModel : class, new()
{
    private bool initialized;
    private bool hasBinding;
    private TModel model = null!;
    private ModelContext<TModel> context = null!;
    private ChangeSupportListener? changeSupportListener;
    
    [Parameter]
    public TModel Model { get; set; } = null!;

    [Parameter]
    public EventCallback<TModel> ModelChanged { get; set; }

    [Parameter]
    public Expression<Func<TModel>>? ModelExpression { get; set; }

    [Parameter]
    public RenderFragment<TModel> ChildContent { get; set; } = null!;

    [Parameter]
    public string? ChangeSupport { get; set; }

    [CascadingParameter]
    public IModelContext CascadeModelContext { get; set; } = null!;

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
            }
        }
        else
        {
            model = Model ?? new();
            context = new ModelContext<TModel>(model, CascadeModelContext);

            initialized = true;
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    public void Dispose()
    {
        Tracer.Write("ModelSupport", "Dispose", "Begin");

        context.EditorMessages.Clear(model);
        changeSupportListener?.Dispose();
        changeSupportListener = null;

        Tracer.Write("ModelSupport", "Dispose", "End");
    }
}
