using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Commons.Layout;

/// <summary>
/// Interface base para componentes de layout que expõem seus valores (tamanhos e referências
/// de elementos) por meio de <c>CascadingValue</c> para componentes descendentes.
/// </summary>
/// <remarks>
/// Fornece informações estruturais do layout, incluindo:
/// <list type="bullet">
/// <item><description>Tamanhos de espaçamento (header, footer, menus lateral esquerdo e direito).</description></item>
/// <item><description>Referências aos elementos do DOM para interop, medições ou aplicação dinâmica de estilos.</description></item>
/// </list>
/// Um componente de layout que implementa esta interface normalmente faz:
/// <code>
/// &lt;CascadingValue Value="this"&gt;
///     @Body
/// &lt;/CascadingValue&gt;
/// </code>
/// Componentes filhos podem receber o contexto injetando-o com:
/// <code>[CascadingParameter] public ILayoutContext? Layout { get; set; }</code>
/// </remarks>
public interface ILayoutContext
{
    /// <summary>
    /// Tamanho de espaçamento aplicado ao topo (header) do layout.
    /// </summary>
    SpacingSize? TopSize { get; }

    /// <summary>
    /// Tamanho de espaçamento aplicado ao rodapé (footer) do layout.
    /// </summary>
    SpacingSize? FooterSize { get; }

    /// <summary>
    /// Tamanho de espaçamento referente ao menu lateral esquerdo (left menu).
    /// </summary>
    SpacingSize? LeftMenuSize { get; }

    /// <summary>
    /// Tamanho de espaçamento referente ao menu lateral direito (right menu).
    /// </summary>
    SpacingSize? RightMenuSize { get; }

    /// <summary>
    /// Referência ao elemento raiz que envolve todo o layout.
    /// </summary>
    ElementReference LayoutReference { get; }

    /// <summary>
    /// Referência ao elemento da região de cabeçalho (header).
    /// </summary>
    ElementReference HeaderReference { get; }

    /// <summary>
    /// Referência ao elemento da área principal de conteúdo (main).
    /// </summary>
    ElementReference MainReference { get; }

    /// <summary>
    /// Referência ao elemento da região de rodapé (footer).
    /// </summary>
    ElementReference FooterReference { get; }

    /// <summary>
    /// Referência ao elemento do menu lateral esquerdo.
    /// </summary>
    ElementReference LeftMenuReference { get; }

    /// <summary>
    /// Referência ao elemento do menu lateral direito.
    /// </summary>
    ElementReference RightMenuReference { get; }
}
