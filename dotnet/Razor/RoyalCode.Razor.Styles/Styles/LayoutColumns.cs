namespace RoyalCode.Razor.Styles;

public enum LayoutColumns
{
    Default,
    Auto,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve
}

public static class LayoutColumnsExtensions
{
    public static string ToCssClass(this LayoutColumns columns)
    {
        return columns switch
        {
            LayoutColumns.Default => string.Empty,
            LayoutColumns.Auto => "columns-auto",
            LayoutColumns.One => "columns-1",
            LayoutColumns.Two => "columns-2",
            LayoutColumns.Three => "columns-3",
            LayoutColumns.Four => "columns-4",
            LayoutColumns.Five => "columns-5",
            LayoutColumns.Six => "columns-6",
            LayoutColumns.Seven => "columns-7",
            LayoutColumns.Eight => "columns-8",
            LayoutColumns.Nine => "columns-9",
            LayoutColumns.Ten => "columns-10",
            LayoutColumns.Eleven => "columns-11",
            LayoutColumns.Twelve => "columns-12",
            _ => throw new ArgumentOutOfRangeException(nameof(columns), columns, null)
        };
    }
}
