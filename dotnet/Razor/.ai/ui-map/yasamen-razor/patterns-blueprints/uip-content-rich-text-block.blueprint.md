# UIP-CONTENT-RICH_TEXT_BLOCK - Blueprint resumido

## Pattern

UIP-CONTENT-RICH_TEXT_BLOCK — Rich Text Block — ver `uip-content-rich-text-block.ui-map.md`

## Gap coberto

A lib não tem renderer nem editor de rich text. O gap é orientar: `@((MarkupString)html)` em `Box.prose` para HTML armazenado, Markdig para Markdown, e truncamento com "Ler mais".

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Box(prose prose-sm)` com `@((MarkupString)html)` para renderizar HTML sanitizado; Markdig NuGet para converter Markdown antes de renderizar; `max-h + overflow-hidden + gradient` para truncamento.

## Componentes usados

- `Box` — papel: principal (container editorial) — ver `box.sample.md`
- `Button` — papel: composição (expandir "Ler mais") — ver `button.sample.md`

## Recursos visuais

- `prose prose-sm max-w-none` — tipografia editorial via Tailwind Typography plugin
- `@((MarkupString)html)` — renderização de HTML nativo do Blazor
- `max-h-32 overflow-hidden` — truncamento de conteúdo longo
- `bg-gradient-to-t from-white` — fade visual do corte

## Receita

`Box.prose` + `MarkupString` para HTML; Markdig para Markdown; truncamento com `expandido` bool.

```razor
@* Renderização de HTML sanitizado (conteúdo do banco) *@
@* IMPORTANTE: sanitizar o HTML antes de persistir — nunca renderizar HTML de fonte não confiável *@
<Box AdditionalClasses="p-6 prose prose-sm max-w-none">
    @((MarkupString)entidade.ConteudoHtml)
</Box>

@* Renderização de Markdown com Markdig (NuGet: Markdig) *@
@code {
    private string HtmlConteudo =>
        Markdown.ToHtml(entidade.ConteudoMarkdown,
            new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
}

<Box AdditionalClasses="p-6 prose prose-sm max-w-none">
    @((MarkupString)HtmlConteudo)
</Box>

@* Conteúdo truncado com expansão *@
@code { private bool expandido; }

<Box AdditionalClasses="p-4">
    <div class="@(!expandido ? "max-h-32 overflow-hidden" : "") relative">
        @((MarkupString)entidade.ConteudoHtml)
        @if (!expandido)
        {
            <div class="absolute bottom-0 left-0 right-0 h-12
                        bg-gradient-to-t from-white pointer-events-none"></div>
        }
    </div>
    @if (!expandido)
    {
        <Button Style="Themes.Default" Label="Ler mais"
                OnClick="() => expandido = true"
                AdditionalClasses="mt-2" />
    }
</Box>
```

## Limites

- `@((MarkupString)html)` renderiza HTML sem sanitização — nunca usar com HTML de fonte externa não confiável (risco XSS); usar pacote `HtmlSanitizer` antes de persistir conteúdo editorial;
- Tailwind Typography (`prose`) requer plugin `@tailwindcss/typography` configurado — verificar se disponível no projeto;
- Editor WYSIWYG requer biblioteca externa (Quill via JS interop, BlazorWysiwygEditor, etc.) — não coberto aqui.
