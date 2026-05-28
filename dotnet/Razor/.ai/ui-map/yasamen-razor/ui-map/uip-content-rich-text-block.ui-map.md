# UIP-CONTENT-RICH_TEXT_BLOCK - Rich Text Block

**GAP parcial — sem editor ou renderer nativo**

A biblioteca não tem componente de rich text block (nem editor, nem renderer de Markdown/HTML). Conteúdo HTML raw pode ser renderizado com `@((MarkupString)html)` do Blazor. Editor rico requer biblioteca externa.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Box
- `cobertura`: container do bloco editorial com padding e borda opcional; espaço de leitura delimitado;
- `nota`: 6;
- `justificativa`: container visual do bloco de conteúdo.

2. `@((MarkupString)html)` (Blazor nativo)
- `cobertura`: renderização de HTML sanitizado como conteúdo editorial; headings, parágrafos, listas, links;
- `limitações`: requer sanitização prévia do HTML (risco de XSS se HTML não for confiável); sem Markdown nativo;
- `nota`: 5;
- `justificativa`: mecanismo Blazor para conteúdo HTML livre — funcional para conteúdo de banco de dados sanitizado.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `Markdown rendering`: sem nativo — usar biblioteca `Markdig` para converter Markdown para HTML, depois `@((MarkupString)html)`;
  - `rich text editor (WYSIWYG)`: sem nativo — requer biblioteca externa (Quill via JS interop, TipTap, Froala, CKEditor);
  - `tipografia editorial padronizada`: aplicar `prose` classes do Tailwind Typography (`@apply prose prose-sm`) ao container;
  - `sanitização de HTML`: usar `HtmlSanitizer` NuGet antes de renderizar HTML externo.

- `tipo de adaptação`: composição + Blazor MarkupString + bibliotecas externas para editor
- `o que precisa ser feito`:
  - Para renderização de HTML armazenado: `@((MarkupString)conteudoHtml)` em `Box` com classe de tipografia;
  - Para Markdown: converter com `Markdig.ToHtml()` + `@((MarkupString)html)`;
  - Para editor WYSIWYG: biblioteca externa com JS interop.

## Como usar

### Renderização de HTML sanitizado

```razor
@* Conteúdo HTML vem do banco de dados — sanitizar antes de persistir *@
<Box AdditionalClasses="p-6 prose prose-sm max-w-none">
    @((MarkupString)entidade.ConteudoHtml)
</Box>
```

### Renderização de Markdown (com Markdig)

```razor
@* Requer pacote NuGet: Markdig *@
@code {
    private string HtmlConteudo =>
        Markdown.ToHtml(entidade.ConteudoMarkdown, new MarkdownPipelineBuilder()
            .UseAdvancedExtensions().Build());
}

<Box AdditionalClasses="p-6 prose prose-sm max-w-none">
    @((MarkupString)HtmlConteudo)
</Box>
```

### Conteúdo truncado com "Ler mais"

```razor
@code {
    private bool expandido = false;
}

<Box AdditionalClasses="p-4">
    <div class="@(expandido ? "" : "max-h-32 overflow-hidden") relative">
        @((MarkupString)entidade.ConteudoHtml)
        @if (!expandido)
        {
            <div class="absolute bottom-0 left-0 right-0 h-12 bg-gradient-to-t from-white"></div>
        }
    </div>
    @if (!expandido)
    {
        <Button Style="Themes.Default" Label="Ler mais"
                OnClick="() => expandido = true" AdditionalClasses="mt-2" />
    }
</Box>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem componente de rich text nativo; sem editor WYSIWYG; Markdown requer Markdig; HTML rendering via `MarkupString` requer sanitização manual; sem tipografia editorial por padrão (requer Tailwind Typography);
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Box` + `@((MarkupString)html)` cobrem renderização de conteúdo armazenado com boa semântica;
  - Para editor rico: biblioteca externa obrigatória;
  - Nota 5 reflete cobertura parcial — renderização funcional mas sem abstração editorial na lib.
