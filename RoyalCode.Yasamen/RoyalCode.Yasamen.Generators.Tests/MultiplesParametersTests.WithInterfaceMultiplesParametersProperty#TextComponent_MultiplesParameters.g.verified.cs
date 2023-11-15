//HintName: TextComponent_MultiplesParameters.g.cs
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests
{
    public partial class TextComponent : IHasColumns
    {

        [Parameter]
        public int Cols
        {
            get => Parameters.Cols;
            set => Parameters.Cols = value;
        }

    }
}
