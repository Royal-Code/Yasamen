//HintName: AbstractComponent_MultiplesParameters.g.cs
#pragma warning disable BL0007
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests
{
    public partial class AbstractComponent<T> : IHasColumns
    {

        [Parameter]
        public int Cols
        {
            get => Parameters.Cols;
            set => Parameters.Cols = value;
        }

    }
}
