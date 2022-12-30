
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract partial class AbstractInput<TValue> : FieldBase<TValue>
{
    [MultiplesParameters]
    public ColumnSizes ColumnSizes { set; get; } = new();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        
        
    }
}

public partial class AbstractInput<TValue>
{
    public AbstractInput()
    {
        ColumnSizes = new ColumnSizes();
        
    }
}

public partial class AbstractInput
{
    public AbstractInput()
    {
        Cols = 1;
    }
}


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
