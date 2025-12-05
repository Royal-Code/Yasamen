using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Razor.Commons.Extensions;
using RoyalCode.Razor.Commons.Modules;
using RoyalCode.Razor.Components;
using RoyalCode.Razor.Styles;
using System.Reflection;

namespace RoyalCode.Razor.Internal.Forms;

/// <summary>
/// Base class for form fields.
/// </summary>
public abstract class FieldBase : ComponentBase, IAsyncDisposable
{
    private PropertyInfo? propertyInfo;
    private string? labelId;
    private string? inputId;
    private string? inputName;
    private string? label;
    private ValidationMessageStore? validationMessageStore;
    private List<ErrorMessage>? errorMessages;
    private bool initialized;

    /// <summary>
    /// Style classes passed to the outermost element of the component.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// additional HTML attributes.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Component ID.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Name used in the <c>input</c> component that stores the value.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Component label.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Component label ID.
    /// </summary>
    [Parameter]
    public string? LabelId { get; set; }

    /// <summary>
    /// Component placeholder, used in the <c>input</c> component that stores the value.
    /// </summary>
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets additional information provided by the user about the field.
    /// </summary>
    [Parameter]
    public string? Information { get; set; }

    /// <summary>
    /// Gets or sets the error message to be displayed.
    /// </summary>
    [Parameter]
    public string? Error { get; set; }

    /// <summary>
    /// Indicates whether the component is disabled.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Indicates whether the component is in read mode.
    /// </summary>
    [Parameter]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// Indicates the size of the component. ?????????????????????????
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; } = Sizes.Default;

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter]
    public string? ParsingErrorPattern { get; set; } = string.Empty;

    /// <summary>
    /// The EditContext provided by an <see cref="EditForm"/>.
    /// </summary>
    [CascadingParameter]
    protected EditContext? CascadedEditContext { get; set; }

    /// <summary>
    /// Prepend content for the field.
    /// </summary>
    [Parameter]
    public RenderFragment Prepend { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// Append content for the field.
    /// </summary>
    [Parameter]
    public RenderFragment Append { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// Description complement for the field. Placed with the label justified to the end of the field.
    /// </summary>
    [Parameter]
    public RenderFragment DescriptionComplement { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// JS interop utilities for work with the field element.
    /// </summary>
    public FieldJs Js { get; } = new();

    /// <summary>
    /// The field element that has the value (input, select, textarea).
    /// </summary>
    public ElementReference Element
    {
        get => Js.Element;
        protected set => Js.Element = value;
    }

    /// <summary>
    /// Module for Js interop.
    /// </summary>
    [Inject]
    protected FormsJs FormsJs
    {
        get => Js.Module!;
        set => Js.Module = value;
    }

    /// <summary>
    /// Determines whether the component is loading.
    /// This is an internal state and should not be informed by any external parameter or component.
    /// </summary>
    protected bool IsLoading { get; set; }

    /// <summary>
    /// Gets the associated <see cref="EditContext"/>.
    /// This property is uninitialized if the input does not have a parent <see cref="EditForm"/>.
    /// </summary>
    protected EditContext EditContext { get; set; } = default!;

    /// <summary>
    /// Field identifier.
    /// </summary>
    protected FieldIdentifier FieldIdentifier { get; set; }

    /// <summary>
    /// Error message to occur if there is a parsing problem between the value entered in the element <c>input</c>
    /// and the data type of the component.
    /// </summary>
    protected string? ParseError { get; set; }

    /// <summary>
    /// For internal use, an error message for when the value entered is invalid.
    /// These validations are intended to validate via EditForm.
    /// </summary>
    protected string? ValidationErrorMessage { get; set; }

    /// <summary>
    /// Default error message for when there is a problem parsing the input value to the data type.
    /// </summary>
    protected virtual string InvalidInputErrorMessageFallback => "The value entered is invalid.";

    /// <summary>
    /// Default label for when the field name cannot be obtained.
    /// </summary>
    protected virtual string LabelFallback => "Field";

    /// <summary>
    /// Gets the property of the field.
    /// </summary>
    protected PropertyInfo? FieldPropertyInfo
    {
        get
        {
            propertyInfo ??= FieldIdentifier.Model?.GetType().GetProperty(FieldIdentifier.FieldName);
            return propertyInfo;
        }
    }

    /// <summary>
    /// Get the field ID.
    /// </summary>
    /// <returns></returns>
    protected string FieldInputId
    {
        get => Id ?? (inputId ??= $"{FieldIdentifier.Model?.GetType().Name}--{FieldIdentifier.FieldName}--{YasamenExtensions.GenerateId()}");
    }

    /// <summary>
    /// Get the label ID of the field.
    /// </summary>
    /// <returns></returns>
    protected string FieldLabelId
    {
        get => labelId ?? (labelId = $"{FieldIdentifier.FieldName}_{FieldLabel.ToHtmlId()}");
    }

    /// <summary>
    /// Get the field name.
    /// </summary>
    /// <returns></returns>
    protected string FieldInputName
    {
        get => Name ?? (inputName ??= FieldIdentifier.FieldName);
    }

    /// <summary>
    /// Get the label of the field.
    /// </summary>
    /// <returns></returns>
    protected string FieldLabel
    {
        get => Label ?? (label ??= FieldPropertyInfo?.GetDefaultDisplayName() ?? LabelFallback);
    }

    /// <summary>
    /// Gets the value of the field as a string.
    /// </summary>
    /// <returns></returns>
    protected abstract string FieldValueAsString { get; }

    /// <summary>
    /// Determines whether it is invalid, if there is any error message for the field.
    /// </summary>
    protected virtual bool IsInvalid => GetErrorMessage().IsPresent();

    /// <summary>
    /// Executed when the field value is changed.
    /// </summary>
    protected virtual void OnValueChange() { }

    /// <summary>
    /// Get the error message for when a problem occurs in parsing the input value for the data type.
    /// </summary>
    /// <returns></returns>
    protected virtual string GetInvalidInputErrorMessage(string? input)
    {
        var pattern = ParsingErrorPattern.IsPresent() ? ParsingErrorPattern : InvalidInputErrorMessageFallback;

        if (pattern.Contains("{0}"))
        {
            if (pattern.Contains("{1}"))
            {
                return string.Format(pattern, FieldLabel, input);
            }
            return string.Format(pattern, FieldLabel);
        }

        return pattern;
    }

    /// <summary>
    /// Updates the field validation messages.
    /// </summary>
    protected virtual void UpdateValidationMessageStore()
    {
        if (EditContext is not null && FieldIdentifier.FieldName.IsPresent())
        {
            validationMessageStore ??= new ValidationMessageStore(EditContext);
            validationMessageStore.Clear(FieldIdentifier);
            var errorMessage = GetErrorMessage();
            if (errorMessage is not null)
                validationMessageStore.Add(FieldIdentifier, errorMessage);
        }
    }

    /// <summary>
    /// Get the error message from the field, if any.
    /// </summary>
    /// <returns>The error message or <c>null</c> if there isn't one.</returns>
    protected virtual string? GetErrorMessage()
    {
        if (ParseError.IsPresent())
            return ParseError;

        if (Error.IsPresent())
            return Error;

        if (errorMessages is not null && errorMessages.Count > 0)
            return errorMessages[0].Text;

        if (ValidationErrorMessage.IsPresent())
            return ValidationErrorMessage;

        return null;
    }

    /// <summary>
    /// Adds an error message to the field.
    /// </summary>
    /// <param name="errorMessage"></param>
    public void AddErrorMessage(ErrorMessage errorMessage)
    {
        errorMessages ??= [];
        errorMessages.Add(errorMessage);
        UpdateValidationMessageStore();
    }

    /// <summary>
    /// Removes an error message from the field.
    /// </summary>
    /// <param name="errorMessage"></param>
    public void RemoveErrorMessage(ErrorMessage errorMessage)
    {
        if (errorMessages is not null)
        {
            errorMessages.Remove(errorMessage);
            UpdateValidationMessageStore();
        }
    }

    /// <summary>
    /// Removes an error message from the field by type.
    /// </summary>
    /// <param name="type"></param>
    public void RemoveErrorMessage(string type)
    {
        if (errorMessages is not null)
        {
            var item = errorMessages.FirstOrDefault(x => x.Type == type);
            if (item is not null)
            {
                errorMessages.Remove(item);
                UpdateValidationMessageStore();
            }
        }
    }

    /// <summary>
    /// Clears all error messages from the field.
    /// </summary>
    public void ClearErrorMessages()
    {
        errorMessages?.Clear();
        UpdateValidationMessageStore();
    }

    /// <summary>
    /// Dispose.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing) { }

    /// <summary>
    /// Dispose Async.
    /// </summary>
    /// <param name="disposing"></param>
    /// <returns></returns>
    protected virtual ValueTask DisposeAsync(bool disposing) => default;

    /// <summary>
    /// Disposal of internal dependencies.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        await Js.DisposeAsync();

        Dispose(true);
        await DisposeAsync(true);
    }

    /// <inheritdoc />
    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (!initialized)
        {
            if (CascadedEditContext is not null)
            {
                EditContext = CascadedEditContext;
            }

            initialized = true;
        }
        else if (CascadedEditContext != EditContext)
        {
            // Not the first run

            // We don't support changing EditContext because it's messy to be clearing up state and event
            // handlers for the previous one, and there's no strong use case. If a strong use case
            // emerges, we can consider changing this.
            throw new InvalidOperationException(
                $"{GetType()} does not support changing the " +
                $"{nameof(EditContext)} dynamically.");
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }
}
