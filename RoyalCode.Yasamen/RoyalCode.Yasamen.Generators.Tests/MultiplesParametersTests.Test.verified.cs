//HintName: TextComponent_MultiplesParameters.g.cs
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests
{
    public partial class TextComponent
    {

        [Parameter]
        public int Cols
        {
            get => Parameters.Cols;
            set => Parameters.Cols = value;
        }


        [Parameter]
        public int? XsCols
        {
            get => Parameters.XsCols;
            set => Parameters.XsCols = value;
        }


        [Parameter]
        public int? SmCols
        {
            get => Parameters.SmCols;
            set => Parameters.SmCols = value;
        }


        [Parameter]
        public int? MdCols
        {
            get => Parameters.MdCols;
            set => Parameters.MdCols = value;
        }


        [Parameter]
        public int? LgCols
        {
            get => Parameters.LgCols;
            set => Parameters.LgCols = value;
        }


        [Parameter]
        public int? XlCols
        {
            get => Parameters.XlCols;
            set => Parameters.XlCols = value;
        }

    }
}
