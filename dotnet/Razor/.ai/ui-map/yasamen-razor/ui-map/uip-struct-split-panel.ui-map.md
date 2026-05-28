# UIP-STRUCT-SPLIT_PANEL - Split Panel

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de split panel. Requer composição com CSS Flexbox (`flex`) + dois filhos com larguras relativas + scroll independente por painel. Sem divisor ajustável nativo.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. AppLayout (estrutura raiz)
- `cobertura`: layout principal com `AppSideBar` como painel primário fixo + área de conteúdo como painel secundário; sem divisor ajustável;
- `nota`: 4;
- `justificativa`: split fixo de app shell — cobre list+detail em nivel de shell.

2. Container+Slot (grade dois painéis)
- `cobertura`: `Columns="2"` com proporção 1:2 ou 1:3 via `AdditionalClasses`; responsivo por breakpoints; sem divisor ajustável;
- `nota`: 5;
- `justificativa`: split estático de colunas — proporções fixas.

3. Box + Stack (painéis individuais)
- `cobertura`: cada painel com scroll independente `overflow-y-auto`; altura fixa via `h-full` ou `h-screen`;
- `nota`: 6;
- `justificativa`: container de painel com scroll próprio.

4. Feedback (empty state do painel secundário)
- `cobertura`: "Nenhum item selecionado" quando painel secundário está vazio;
- `nota`: 8;
- `justificativa`: estado vazio do painel secundário.

**Descartados**: AppSideBar (sidebar de navegação, não painel de dados).

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `divisor ajustável (resizer)`: sem nativo — JS com `mousedown/mousemove` para ajustar `width` de cada painel;
  - `colapso do painel secundário`: estado `bool secundarioAberto` + `@if` + botão de toggle;
  - `responsividade (mobile = sequência)`: `hidden lg:flex` no wrapper + navegação entre painéis em mobile.

- `tipo de adaptação`: composição CSS manual
- `o que precisa ser feito`:
  - `<div class="flex h-full gap-0">` + dois filhos com `w-1/3` e `w-2/3` (ou customizado);
  - Painel primário com `overflow-y-auto`; painel secundário com `overflow-y-auto flex-1`;
  - `Feedback` no painel secundário quando nenhum item selecionado;
  - `hidden lg:flex` para ocultar split em mobile.

## Como usar

### Split list/detail estático

```razor
@code {
    private ItemDto? selecionado;
    private List<ItemDto> itens = [];
}

<div class="flex h-full border border-light-200 rounded-md overflow-hidden">
    @* Painel primário: lista *@
    <div class="w-80 flex-shrink-0 border-r border-light-200 overflow-y-auto">
        <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
            <StartContent>
                <span class="text-sm font-semibold text-dark-600">Itens</span>
            </StartContent>
        </Bar>
        <Stack Gap="Gaps.None">
            @foreach (var item in itens)
            {
                <button class="w-full text-left px-3 py-2 text-sm border-b border-light-100
                               hover:bg-light-50 transition-colors
                               @(selecionado?.Id == item.Id ? "bg-primary-50 text-primary-700" : "text-dark-600")"
                        @onclick="() => selecionado = item">
                    <p class="font-medium">@item.Nome</p>
                    <p class="text-xs text-dark-400">@item.Descricao</p>
                </button>
            }
        </Stack>
    </div>

    @* Painel secundário: detalhe *@
    <div class="flex-1 overflow-y-auto">
        @if (selecionado is null)
        {
            <div class="flex items-center justify-center h-full">
                <Feedback Style="Themes.Light" Text="Selecione um item para ver os detalhes." />
            </div>
        }
        else
        {
            <div class="p-4">
                <Bar AdditionalClasses="mb-4">
                    <StartContent>
                        <div>
                            <h2 class="text-lg font-semibold text-dark-700">@selecionado.Nome</h2>
                            <p class="text-sm text-dark-400">@selecionado.Descricao</p>
                        </div>
                    </StartContent>
                    <EndContent>
                        <Badge Style="@selecionado.StatusTema" Text="@selecionado.Status" />
                    </EndContent>
                </Bar>
                @* detalhe do item *@
            </div>
        }
    </div>
</div>
```

### Split responsivo (mobile: sequência)

```razor
@code {
    private ItemDto? selecionado;
    private bool mostrarDetalhe; // mobile only

    private void SelecionarItem(ItemDto item)
    {
        selecionado = item;
        mostrarDetalhe = true;
    }
}

@* Desktop: flex side-by-side; Mobile: um painel por vez *@
<div class="flex h-full">
    @* Lista: oculta em mobile quando detalhe está aberto *@
    <div class="@(mostrarDetalhe ? "hidden lg:flex" : "flex") flex-col w-full lg:w-80
                flex-shrink-0 border-r border-light-200 overflow-y-auto">
        @foreach (var item in itens)
        {
            <button class="px-4 py-3 text-left text-sm hover:bg-light-50 border-b border-light-100"
                    @onclick="() => SelecionarItem(item)">
                @item.Nome
            </button>
        }
    </div>

    @* Detalhe: oculto em mobile quando lista está ativa *@
    <div class="@(mostrarDetalhe ? "flex" : "hidden lg:flex") flex-col flex-1 overflow-y-auto">
        @if (selecionado is null)
        {
            <Feedback Style="Themes.Light" Text="Selecione um item." />
        }
        else
        {
            @* botão voltar mobile *@
            <Bar AdditionalClasses="px-4 py-2 border-b border-light-200 lg:hidden">
                <StartContent>
                    <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Default"
                               OnClick="() => mostrarDetalhe = false" />
                    <span class="text-sm font-medium text-dark-600">@selecionado.Nome</span>
                </StartContent>
            </Bar>
            <div class="p-4">
                @* detalhe *@
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de split panel dedicado; divisor ajustável requer JS; proporções são fixas por CSS; responsividade é CSS manual; toda a estrutura é composição HTML;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - Flexbox CSS cobre split estático com dois painéis — funcional e suficiente para PP-LIST-DETAIL;
  - `Feedback` + `Box` + `Stack` dentro de cada painel completam o comportamento;
  - Nota 3 reflete ausência de abstração — toda estrutura de split é HTML/CSS manual.
