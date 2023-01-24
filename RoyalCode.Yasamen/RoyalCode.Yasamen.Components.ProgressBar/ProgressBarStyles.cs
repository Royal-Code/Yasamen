
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// <para>
///     Style for the component <see cref="ProgressBar"/>
/// </para>
/// <para>
///     The default is <see cref="Primary"/>.
/// </para>
/// </summary>
public enum ProgressBarStyles
{
    Primary,

    Success,

    Info,

    Warning,

    Danger
}

public static class ProgressBarStylesExtensions
{
    public static string ToCssClass(this ProgressBarStyles style)
    {
        switch (style)
        {
            case ProgressBarStyles.Primary:
                return string.Empty;
            case ProgressBarStyles.Success:
                return "bg-success";
            case ProgressBarStyles.Info:
                return "bg-info";
            case ProgressBarStyles.Warning:
                return "bg-warning";
            case ProgressBarStyles.Danger:
                return "bg-danger";
            default:
                throw new System.NotSupportedException($"The proggres bar style '{style}' is not supported");
        }
    }
}
