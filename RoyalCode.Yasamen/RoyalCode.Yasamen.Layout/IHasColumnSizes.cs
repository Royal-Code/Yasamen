
using System.Text;

namespace RoyalCode.Yasamen.Layout;

/// <summary>
/// Interface para componentes de colunas de um Grid com possibilidade de definir os tamanhos.
/// </summary>
public interface IHasColumnSizes
{
    int Cols { get; set; }

    int? TabletCols { get; set; }

    int? PhoneCols { get; set; }

    int? Quarters { get; set; }

    int? XsCols { get; set; }

    int? SmCols { get; set; }

    int? LgCols { get; set; }

    int? XlCols { get; set; }

    bool Fullsize { get; set; }

    bool XsFullsize { get; set; }

    bool SmFullsize { get; set; }

    bool LgFullsize { get; set; }

    bool XlFullsize { get; set; }

    string GetVariableValues()
    {
        var sb = new StringBuilder();

        sb.Append("--b-cols: ").Append(Cols).Append(';');

        if (XsCols.HasValue)
            sb.Append("--b-cols-xs: ").Append(XsCols).Append(';');

        if (SmCols.HasValue)
            sb.Append("--b-cols-sm: ").Append(SmCols).Append(';');

        if (LgCols.HasValue)
            sb.Append("--b-cols-lg: ").Append(LgCols).Append(';');

        if (XlCols.HasValue)
            sb.Append("--b-cols-xl: ").Append(XlCols).Append(';');

        return sb.ToString();
    }

    void CopyFrom(IHasColumnSizes other)
    {
        Cols = other.Cols;
        TabletCols = other.TabletCols;
        PhoneCols = other.PhoneCols;
        Quarters = other.Quarters;
        XsCols = other.XsCols;
        SmCols = other.SmCols;
        LgCols = other.LgCols;
        XlCols = other.XlCols;
        Fullsize = other.Fullsize;
        XsFullsize = other.XsFullsize;
        SmFullsize = other.SmFullsize;
        LgFullsize = other.LgFullsize;
        XlFullsize = other.XlFullsize;
    }
}
