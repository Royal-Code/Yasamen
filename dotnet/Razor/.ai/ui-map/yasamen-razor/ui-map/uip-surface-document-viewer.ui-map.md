# UIP-SURFACE-DOCUMENT_VIEWER - Document Viewer Surface

**GAP — sem componente dedicado**

A biblioteca não tem componente de visualização de documentos paginados. Requer biblioteca externa (PSPDFKit, PDF.js via JS interop, Telerik Document Processing, etc.).

## Componentes

**Principais**: nenhum.

**Composição**:

1. Bar
- `cobertura`: barra de controle do viewer (navegação de páginas, zoom, download);
- `nota`: 5;
- `justificativa`: toolbar do viewer — não provê a superfície do documento.

2. Button / IconButton
- `cobertura`: ações de download, impressão, zoom in/out, página anterior/próxima;
- `nota`: 7;
- `justificativa`: controles de ação do viewer.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: biblioteca externa obrigatória para PDF/documento paginado
- `o que precisa ser feito`:
  - Para PDF: PDF.js via JS interop ou componente Blazor com PDF.js (BlazorPdfViewer, etc.);
  - Para HTML reflowável simples: usar `UIP-CONTENT-RICH_TEXT_BLOCK` — não é este pattern;
  - Controles da barra (download, imprimir, navegação) podem usar `Bar` + `IconButton` da lib.

## Como usar

### Toolbar para viewer externo

```razor
<Bar AdditionalClasses="mb-2 border-b border-light-200 pb-2">
    <StartContent>
        <ButtonGroup>
            <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Secondary" Outline=true
                        OnClick="PaginaAnterior" Disabled="@(paginaAtual <= 1)" />
            <span class="px-3 py-1 text-sm text-dark-600">@paginaAtual / @totalPaginas</span>
            <IconButton Icon="WellKnownIcons.ChevronRight" Style="Themes.Secondary" Outline=true
                        OnClick="ProximaPagina" Disabled="@(paginaAtual >= totalPaginas)" />
        </ButtonGroup>
    </StartContent>
    <EndContent>
        <IconButton Icon="WellKnownIcons.Download" Style="Themes.Secondary" Outline=true
                    OnClick="Download" />
        <IconButton Icon="WellKnownIcons.Print" Style="Themes.Secondary" Outline=true
                    OnClick="Imprimir" />
    </EndContent>
</Bar>

@* Superfície do documento — componente externo *@
<div class="border border-light-200 rounded-md overflow-hidden h-screen">
    @* <PdfViewer Url="@docUrl" Page="@paginaAtual"> ou iframe/embed *@
</div>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente de document viewer nativo; PDF e documentos paginados requerem biblioteca externa; `Bar` + `IconButton` cobrem apenas a toolbar de controle;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A lib não provê superfície de documento paginado;
  - Para anexo simples: link de download com `Button Style=Secondary`;
  - Para rich text reflowável: `UIP-CONTENT-RICH_TEXT_BLOCK`;
  - Nota 0 reflete ausência total de suporte nativo de document viewer.
