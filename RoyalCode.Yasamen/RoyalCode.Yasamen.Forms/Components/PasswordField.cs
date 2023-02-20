using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Yasamen.Commons.Options;
using RoyalCode.Yasamen.Icons;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class PasswordField : InputFieldBase<string>
{
    protected override string FieldType => ShowPassword ? "text" : "password";

    protected override bool HasInputGroup => true;

    [Parameter]
    public bool ShowPassword { get; set; }

    [Parameter]
    public EventCallback<bool> ShowPasswordChanged { get; set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override bool TryParseValue(string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out string result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        result = value ?? string.Empty;
        errorMessage = null;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override string? FormatValue(string? value) => value;
    
    public override Task SetParametersAsync(ParameterView parameters)
    {
        if (parameters.TryGetValue<InputType>(nameof(Type), out var type) && type != InputType.Password)
            throw new InvalidOperationException("The type of the field must be 'Password'. " +
                "You don't need to specify it, because it is the default value.");

        return base.SetParametersAsync(parameters);
    }

    protected override int RenderAppend(RenderTreeBuilder builder, int index)
    {
        index = base.RenderAppend(builder, index);

        string iconKey = ShowPassword ? WellKnownIcons.HidePassord : WellKnownIcons.ShowPassord;

        if (CommonsOptions.Get<Icon>().TryGet<Enum>(iconKey, out var icon))
        {
            builder.OpenComponent<FieldButton>(index);
            builder.AddAttribute(1 + index, "Icon", icon);
            builder.AddAttribute(2 + index, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, ToggleShowPassword));
            builder.AddAttribute(3 + index, "tabindex", "-1");
            builder.CloseComponent();
        }
        else
        {
            builder.OpenComponent<FieldAddon>(4 + index);
            builder.AddAttribute(5 + index, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, ToggleShowPassword));
            builder.AddAttribute(6 + index, "AdditionalClasses", "pointer");
            builder.AddAttribute(7 + index, "tabindex", "-1");
            builder.AddAttribute(8 + index, "ChildContent", (RenderFragment)(b =>
            {
                string caption = ShowPassword ? "Hide Password" : "Show Password";

                b.OpenElement(9 + index, "span");
                b.AddAttribute(10 + index, "title", caption);
                
                if (ShowPassword)
                    b.AddContent(11 + index, "*");
                else
                    b.AddContent(12 + index, "a");
                b.CloseElement();
            }));
            builder.CloseComponent();
        }

        return index + 13;
    }

    private async Task ToggleShowPassword()
    {
        if (ShowPasswordChanged.HasDelegate)
            await ShowPasswordChanged.InvokeAsync(!ShowPassword);
        else
            ShowPassword = !ShowPassword;
    }
}
