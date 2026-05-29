# Pagination - Sample

## Contrato de uso

**Entrada pública**: `<Pagination>` — namespace `RoyalCode.Razor.Navigation`
**Grupo**: UI-NAV
**Propósito**: Controle de paginação com versões desktop (janela de páginas, ellipsis, first/prev/next/last) e mobile (prev/next + summary). Totalmente acessível com aria-labels.
**Patterns**:
- `implementa`: UIP-NAV-PAGINATION
- `compõe`: UIP-FEEDBACK-LOADING_STATE
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: listagens paginadas de dados — abaixo da lista ou tabela
- **Evite quando**: a navegação é entre seções/abas semânticas — use `AppMenu` ou nav por rota; para scroll infinito, não use Pagination
- **Cuidado**: não renderiza quando `TotalPages <= 1` por default (`SinglePageMode.Hide`) — se quiser exibir mesmo com 1 página, use `SinglePageMode="PaginationSinglePageMode.Render"`

## Exemplos

### `UIP-NAV-PAGINATION, UIP-FEEDBACK-LOADING_STATE` — Paginação básica de listagem

Use abaixo da lista ou tabela; `OnPageChanged` recebe o número da nova página.

```razor
@code {
    private int pagina = 1;
    private int totalPaginas;
    private bool carregando;
    private List<ItemDto> itens = [];

    protected override async Task OnInitializedAsync() => await Carregar();

    private async Task OnMudarPagina(int novaPagina)
    {
        pagina = novaPagina;
        await Carregar();
    }

    private async Task Carregar()
    {
        carregando = true;
        var resultado = await Service.ListarAsync(pagina, tamanhoPagina: 20);
        itens = resultado.Itens;
        totalPaginas = resultado.TotalPaginas;
        carregando = false;
    }
}

@* Lista de itens *@
<Stack AdditionalClasses="gap-2 mb-4">
    @foreach (var item in itens)
    {
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
            <p class="text-sm text-dark-700">@item.Nome</p>
        </Box>
    }
</Stack>

@* Paginação com loading state *@
<Pagination CurrentPage="@pagina"
            TotalPages="@totalPaginas"
            Loading="@carregando"
            OnPageChanged="OnMudarPagina"
            AdditionalClasses="mt-4" />
```

**API usada**: `CurrentPage`, `TotalPages`, `Loading`, `OnPageChanged`
**Nota**: Labels default em PT-BR ("Anterior", "Próximo", "Primeira", "Última"). Para idioma diferente, usar `PreviousLabel` / `NextLabel`.

### `UIP-NAV-PAGINATION` — Opções de configuração

```razor
@* Página única visível — forçar exibição mesmo com 1 página *@
<Pagination CurrentPage="1" TotalPages="1"
            SinglePageMode="PaginationSinglePageMode.Render"
            OnPageChanged="OnPagina" />

@* Janela desktop reduzida — menos páginas visíveis *@
<Pagination CurrentPage="@pagina" TotalPages="@totalPaginas"
            DesktopWindowSize="5"
            Size="Sizes.Small"
            OnPageChanged="OnPagina" />
```

**API usada**: `SinglePageMode`, `DesktopWindowSize`, `Size`

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `CurrentPage` | `int` | EditorRequired | Página atual (base 1) |
| `TotalPages` | `int` | EditorRequired | Total de páginas |
| `OnPageChanged` | `EventCallback<int>` | — | Callback com nova página ao clicar |
| `Loading` | `bool` | false | Estado de carregamento — aplica `ya-pagination-loading` |
| `Size` | `Sizes` | Medium | Tamanho visual |
| `SinglePageMode` | `PaginationSinglePageMode` | Hide | Hide=oculta com 1 pg; Render=sempre exibe; Message=exibe mensagem |
| `DesktopWindowSize` | `int` | 7 | Número de páginas visíveis na versão desktop |
| `PreviousLabel` / `NextLabel` | `string` | PT-BR | Labels de navegação |

## Defaults importantes

- `SinglePageMode` default `Hide`: com `TotalPages <= 1`, o componente não renderiza — se o usuário precisa ver a paginação mesmo assim, usar `Render`
- Desktop vs mobile: renderiza automaticamente versão desktop (`ya-pagination-desktop`) e mobile (`ya-pagination-mobile`) via CSS — não é controlável por parâmetro
