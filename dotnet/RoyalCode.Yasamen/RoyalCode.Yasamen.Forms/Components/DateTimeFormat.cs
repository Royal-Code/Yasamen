
namespace RoyalCode.Yasamen.Forms.Components;

/// <summary>
/// The format of the date and time of the HTML input type date.
/// </summary>
public enum DateTimeFormat
{
    /// <summary>
    /// Enter the date and the time.
    /// </summary>
    DateTimeLocal,
    
    /// <summary>
    /// Enter only the date.
    /// </summary>
    Date,
    
    /// <summary>
    /// Enter the month and the year.
    /// </summary>
    Month,

    /// <summary>
    /// Enter only the time.
    /// </summary>
    Time,
}

public static class DateTimeFormatExtensions
{
    public static string ToHtmlDateType(this DateTimeFormat format)
    {
        return format switch
        {
            DateTimeFormat.Date => "date",
            DateTimeFormat.DateTimeLocal => "datetime-local",
            DateTimeFormat.Month => "month",
            DateTimeFormat.Time => "time",
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null),
        };
    }

    public static string ToHtmlFormat(this DateTimeFormat format)
    {
        return format switch
        {
            DateTimeFormat.Date => "yyyy-MM-dd",
            DateTimeFormat.DateTimeLocal => "yyyy-MM-ddTHH:mm",
            DateTimeFormat.Month => "yyyy-MM",
            DateTimeFormat.Time => "HH:mm",
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null),
        };
    }
}
