# UIP-NAV-PAGINATION - Pagination

## Componentes

**Principais**:

1. Pagination
- `cobertura`: paginação numerada com janela de páginas + primeira/última + elipses; variante desktop (ya-pagination-desktop) e mobile (ya-pagination-mobile) renderizadas simultaneamente — CSS controla visibilidade por breakpoint; estado de carregamento via `Loading=true` (opacity-80); link ativo com `ya-pagination-link-active`; link desabilitado com `ya-pagination-link-disabled`; tema via `Style`; tamanho via `Size`; callback `OnPageChanged` para recarregar dados;
- `limitações`: sem "load more" ou scroll infinito; sem seletor "itens por página" integrado; sem salto direto para página digitada; paginação simplificada mobile (apenas prev/next + "Página X de Y") sem numeração;
- `nota`: 9;
- `justificativa`: cobertura nativa completa para paginação numerada com responsividade automática mobile/desktop.

**Composição**: nenhuma adicional necessária.

**Descartados**: nenhum relevante.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `load-more / scroll infinito`: não suportado — implementar separadamente com Button "Carregar mais";
  - `seletor de itens por página`: não integrado — adicionar via `FieldText` ou `<select>` HTML acima da paginação;
  - `salto para página específica`: sem prop — implementar com `FieldText` + botão de "ir".

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `<Pagination CurrentPage="@p" TotalPages="@t" OnPageChanged="@OnPage">` — direto;
  - Ao mudar página (`OnPageChanged`), recarregar os dados e scroll ao topo se necessário;
  - Para "itens por página": `<select>` ou `FieldText` HTML acima da paginação, com callback separado.

## Como usar

### Paginação padrão

```razor
@code {
    private int currentPage = 1;
    private int totalPages = 10;
    private bool isLoading = false;

    private async Task OnPageChanged(int page)
    {
        isLoading = true;
        currentPage = page;
        await CarregarDados(page);
        isLoading = false;
    }
}

<Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
            OnPageChanged="OnPageChanged" Loading="@isLoading"
            AdditionalClasses="mt-4" />
```

### Paginação com tema e tamanho

```razor
<Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
            OnPageChanged="OnPageChanged"
            Style="Themes.Primary"
            Size="Sizes.Small"
            AdditionalClasses="mt-4" />
```

### Paginação com seletor de página por tamanho (composição manual)

```razor
<Bar AdditionalClasses="mt-4 items-center">
    <StartContent>
        <Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
                    OnPageChanged="OnPageChanged" Loading="@isLoading" />
    </StartContent>
    <EndContent>
        <div class="flex items-center gap-2 text-sm text-dark-600">
            <span>Itens por página:</span>
            <select class="border border-light-200 rounded-md px-2 py-1 text-sm"
                    @onchange="OnTamanhoChanged">
                <option value="10">10</option>
                <option value="25">25</option>
                <option value="50">50</option>
            </select>
        </div>
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: sem load-more/scroll infinito; sem seletor de itens por página integrado; sem salto direto para página digitada; versão mobile simplificada (apenas prev/next + indicador de página);
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Pagination` é componente nativo com responsividade mobile/desktop automática, estado de loading, janela de páginas e elipses;
  - API simples: `CurrentPage`, `TotalPages`, `OnPageChanged`, `Loading`;
  - Nota 9 — cobertura nativa completa do padrão de paginação numerada discreta; load-more não é um sub-tipo deste pattern.
