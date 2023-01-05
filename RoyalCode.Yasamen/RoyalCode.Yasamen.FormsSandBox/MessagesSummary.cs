using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Forms.Messages;

namespace RoyalCode.Yasamen.Forms;

public sealed class MessagesSummary : ComponentBase, IDisposable
{
    private readonly Action stateHasChangedDelegate;

    private IModelContext modelContext = null!;
    private IMessageListener messageListener = null!;
    private MessagesList messagesList = null!;

    public MessagesSummary()
    {
        stateHasChangedDelegate = StateHasChanged;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if(messagesList.Any)
        {
            if (messagesList.HasErrors)
            {
                RenderAlert(builder, AlertStyles.Danger, messagesList.Errors);
            }
            if (messagesList.HasWarnings)
            {
                RenderAlert(builder, AlertStyles.Warning, messagesList.Warnings);
            }
            if (messagesList.HasInfos)
            {
                RenderAlert(builder, AlertStyles.Info, messagesList.Infos);
            }
            if (messagesList.HasSuccesses)
            {
                RenderAlert(builder, AlertStyles.Success, messagesList.Successes);
            }
        }
    }

    private void RenderAlert(RenderTreeBuilder builder, AlertStyles style, IEnumerable<IResultMessage> messages)
    {
        builder.OpenComponent<Alert>(0);
        builder.AddAttribute(1, nameof(Alert.AlertStyle), style);
        builder.AddAttribute(2, nameof(Alert.AdditionalClasses), "py-1");
        builder.AddAttribute(3, nameof(Alert.ChildContent), RenderMessages(messages));
        builder.CloseComponent();
    }

    private RenderFragment RenderMessages(IEnumerable<IResultMessage> messages)
    {
        return builder =>
        {
            foreach (var message in messages)
            {
                builder.OpenElement(0, "p");
                builder.AddAttribute(1, "class", "m-0");
                builder.AddContent(2, message.Text);
                builder.CloseElement();
            }
        };
    }

    [Parameter]
    public object? Model { get; set; }

    [CascadingParameter]
    IModelContext CascadeModelContext { get; set; } = default!;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (CascadeModelContext is null)
            throw new InvalidOperationException(
                $"{GetType()} requires a cascading parameter " +
                $"of type {nameof(IModelContext)}. For example, you can use {GetType()} inside " +
                $"an {nameof(ModelEditor<object>)}.");

        if (!ReferenceEquals(modelContext, CascadeModelContext))
        {
            Detach();
            modelContext = CascadeModelContext;
            messageListener = Model is null 
                ? modelContext.EditorMessages.CreateModellessFallbackListner()
                : modelContext.EditorMessages.CreateFallbackListner(Model);
            messageListener.ListenChanges(stateHasChangedDelegate);
            messagesList = messageListener.Messages;
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    private void Detach()
    {
        messageListener?.Dispose();
        messageListener = null!;
        messagesList = null!;
    }

    public void Dispose()
    {
        Detach();
    }
}
