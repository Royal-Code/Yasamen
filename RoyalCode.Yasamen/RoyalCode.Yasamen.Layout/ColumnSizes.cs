
namespace RoyalCode.Yasamen.Layout;

/// <summary>
/// <para>
///     Represents the sizes of the columns.
/// </para>
/// <para>
///     Can use the <see cref="MultiplesParametersAttribute"/> to set the sizes of the columns.
/// </para>
/// </summary>
public class ColumnSizes : IHasColumnSizes
{
    public int Cols { get; set; }

    public int? TabletCols { get; set; }

    public int? PhoneCols { get; set; }

    public int? Quarters { get; set; }

    public int? XsCols { get; set; }

    public int? SmCols { get; set; }

    public int? LgCols { get; set; }

    public int? XlCols { get; set; }

    public bool Fullsize { get; set; }

    public bool XsFullsize { get; set; }

    public bool SmFullsize { get; set; }

    public bool LgFullsize { get; set; }

    public bool XlFullsize { get; set; }
}
