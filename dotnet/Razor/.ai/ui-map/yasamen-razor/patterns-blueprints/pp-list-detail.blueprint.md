# PP-LIST-DETAIL - Blueprint completo

## Pattern

PP-LIST-DETAIL — List Detail — ver `pp-list-detail.ui-map.md`

## Gap coberto

A lib cobre bem os itens da lista e o detalhe. O gap é coordenar: layout split CSS assimétrico (`lg:w-80 flex-shrink-0` + `flex-1`) com responsividade mobile/desktop via `hidden/flex`, estado `selecionado` compartilhado entre os dois painéis, scroll independente por painel, e toggle de painel no mobile.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `div.flex.border.rounded-md.overflow-hidden` com altura calculada (`calc(100vh - 160px)`); painel esquerdo `w-full lg:w-80 flex-shrink-0 border-r`; painel direito `flex-1`; visibilidade por `mostrarDetalheMobile` + `hidden/flex` em mobile; `selecionado: ItemDto?` central.
- `eixos cobertos sem componente novo`:
  - item de lista → `Bar(hover + active) + Badge + DropIconButton`;
  - detalhe → `Box + Bar(header) + dl.grid`;
  - busca/filtro → `TextField(@oninput) + OffCanvas(filtros avançados)`;
  - ações → `Bar + Button + DropIconButton`;
  - estados → `Feedback(Light/Danger)` em ambos os painéis;
  - empty detail → `Feedback(Light) "Selecione um item para ver os detalhes."`.

## Componentes usados

- `Bar` — papel: principal (toolbar, header do detalhe, linha de item) — ver `bar.sample.md`
- `Stack` — papel: composição (lista de itens) — ver `bar.sample.md`
- `Box` — papel: composição (container do detalhe) — ver `box.sample.md`
- `Badge` — papel: composição (status por item e no detalhe) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações contextuais por item) — ver `button.sample.md`
- `Button` — papel: composição (ação primária, editar) — ver `button.sample.md`
- `TextField` — papel: composição (busca inline) — ver `field-text.sample.md`
- `Feedback` — papel: composição (empty state, loading, error) — ver `feedback.sample.md`
- `IconButton` — papel: composição (voltar no mobile, fechar) — ver `button.sample.md`

## Recursos visuais

- `flex border border-light-200 rounded-md overflow-hidden` — container split
- `style="height: calc(100vh - 160px)"` — altura que ocupa o viewport disponível
- `w-full lg:w-80 flex-shrink-0` — painel de lista (mobile: full width, desktop: 320px fixo)
- `hidden lg:flex` / `flex lg:hidden` — toggle de painel entre mobile/desktop
- `bg-primary-50` — item selecionado na lista
- `text-primary-700` — texto do item selecionado

## Receita

### Estrutura base

Split page com lista de itens, busca, detalhe em painel direito e responsividade mobile.

```razor
@page "/itens"
@inject NavigationManager Nav
@inject ModalService ModalService

@code {
    private List<ItemDto> itens = [];
    private ItemDto? selecionado;
    private bool mostrarDetalheMobile;
    private string busca = "";
    private bool carregando = true;
    private string? erro;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            itens = await Service.ListarAsync();
        }
        catch (Exception ex) { erro = ex.Message; }
        finally { carregando = false; }
    }

    private void Selecionar(ItemDto item)
    {
        selecionado = item;
        mostrarDetalheMobile = true;
    }

    private IEnumerable<ItemDto> ItensFiltrados =>
        string.IsNullOrEmpty(busca) ? itens
        : itens.Where(i => i.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase));
}

@* Barra de ações da página *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar..."
                   @oninput='e => busca = e.Value?.ToString() ?? ""' />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo item"
                OnClick="() => ModalService.OpenAsync("novo-item")" />
    </EndContent>
</Bar>

@* Layout split *@
<div class="flex border border-light-200 rounded-md overflow-hidden"
     style="height: calc(100vh - 160px);">

    @* Painel de lista *@
    <div class="@(mostrarDetalheMobile ? "hidden lg:flex" : "flex") flex-col
                w-full lg:w-80 flex-shrink-0 border-r border-light-200">

        @if (carregando)
        {
            <div class="p-3 space-y-2">
                @for (int i = 0; i < 8; i++)
                {
                    <div class="animate-pulse h-14 bg-light-100 rounded"></div>
                }
            </div>
        }
        else if (erro is not null)
        {
            <div class="flex-1 flex items-center justify-center p-4">
                <Feedback Style="Themes.Danger" Text="@erro">
                    <ChildContent>
                        <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                                Label="Tentar novamente"
                                OnClick="() => OnInitializedAsync()" />
                    </ChildContent>
                </Feedback>
            </div>
        }
        else if (!ItensFiltrados.Any())
        {
            <div class="flex-1 flex items-center justify-center p-4">
                <Feedback Style="Themes.Light"
                          Text="@(string.IsNullOrEmpty(busca) ? "Nenhum item." : $"Sem resultados para \"{busca}\".")" />
            </div>
        }
        else
        {
            <div class="overflow-y-auto flex-1">
                @foreach (var item in ItensFiltrados)
                {
                    <div class="border-b border-light-100 last:border-0">
                        <Bar AdditionalClasses="px-3 py-3 cursor-pointer transition-colors
                                               @(selecionado?.Id == item.Id
                                                 ? "bg-primary-50"
                                                 : "hover:bg-light-50")"
                             @onclick="() => Selecionar(item)">
                            <StartContent>
                                <div>
                                    <p class="text-sm font-medium
                                              @(selecionado?.Id == item.Id
                                                ? "text-primary-700"
                                                : "text-dark-600")">
                                        @item.Nome
                                    </p>
                                    <p class="text-xs text-dark-400 mt-0.5">@item.Subtitulo</p>
                                </div>
                            </StartContent>
                            <EndContent>
                                <div class="flex items-center gap-1">
                                    <Badge Style="@item.StatusTema" Text="@item.Status" />
                                    <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                   Style="Themes.Default" Size="Sizes.Small"
                                                   OnClick:stopPropagation>
                                        <DropItem Label="Editar"
                                                  OnClick="() => Editar(item)" />
                                        <DropItem Label="Excluir" Style="Themes.Danger"
                                                  OnClick="() => ConfirmarExclusao(item)" />
                                    </DropIconButton>
                                </div>
                            </EndContent>
                        </Bar>
                    </div>
                }
            </div>
        }
    </div>

    @* Painel de detalhe *@
    <div class="@(mostrarDetalheMobile ? "flex" : "hidden lg:flex") flex-col flex-1 overflow-hidden">
        @if (selecionado is null)
        {
            <div class="flex-1 flex items-center justify-center">
                <Feedback Style="Themes.Light"
                          Text="Selecione um item para ver os detalhes." />
            </div>
        }
        else
        {
            @* Header do detalhe *@
            <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 bg-light-50 flex-shrink-0">
                <StartContent>
                    <div class="flex items-center gap-2">
                        @* Botão voltar — apenas mobile *@
                        <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Default"
                                    AdditionalClasses="lg:hidden"
                                    OnClick="() => mostrarDetalheMobile = false" />
                        <div>
                            <h2 class="text-base font-semibold text-dark-700">@selecionado.Nome</h2>
                            <p class="text-xs text-dark-400">@selecionado.Descricao</p>
                        </div>
                    </div>
                </StartContent>
                <EndContent>
                    <Badge Style="@selecionado.StatusTema" Text="@selecionado.Status" />
                    <Button Style="Themes.Default" Size="Sizes.Small" Label="Editar"
                            OnClick="() => Editar(selecionado)" />
                    <DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default">
                        <DropItem Label="Duplicar" OnClick="() => Duplicar(selecionado)" />
                        <DropItem Label="Excluir" Style="Themes.Danger"
                                  OnClick="() => ConfirmarExclusao(selecionado)" />
                    </DropIconButton>
                </EndContent>
            </Bar>

            @* Corpo do detalhe *@
            <div class="flex-1 overflow-y-auto p-4">
                <dl class="grid grid-cols-1 sm:grid-cols-2 gap-x-6 gap-y-3 text-sm">
                    <div>
                        <dt class="text-xs text-dark-400 mb-0.5">Campo 1</dt>
                        <dd class="text-dark-600 font-medium">@selecionado.Campo1</dd>
                    </div>
                    <div>
                        <dt class="text-xs text-dark-400 mb-0.5">Campo 2</dt>
                        <dd class="text-dark-600 font-medium">@selecionado.Campo2</dd>
                    </div>
                </dl>
            </div>
        }
    </div>
</div>
```

### Cenários de composição

#### Detalhe com abas

```razor
@* Abas dentro do painel de detalhe *@
@if (selecionado is not null)
{
    <div class="flex border-b border-light-200 flex-shrink-0">
        @foreach (var aba in new[] { "Detalhes", "Histórico", "Anexos" })
        {
            <button class="px-4 py-2 text-sm border-b-2 transition-colors
                           @(abaAtiva == aba
                             ? "border-primary-500 text-primary-700 font-medium"
                             : "border-transparent text-dark-500 hover:text-dark-700")"
                    @onclick="() => abaAtiva = aba">
                @aba
            </button>
        }
    </div>
    <div class="flex-1 overflow-y-auto p-4">
        @if (abaAtiva == "Detalhes") { @* campos *@ }
        else if (abaAtiva == "Histórico") { @* timeline *@ }
        else if (abaAtiva == "Anexos") { @* lista de arquivos *@ }
    </div>
}
```

### Estados de página

- `loading` (lista): 8 linhas `animate-pulse h-14 bg-light-100 rounded`;
- `empty` (lista): `Feedback(Light)` centralizado no painel;
- `error` (lista): `Feedback(Danger)` com `Button "Tentar novamente"`;
- `sem seleção` (detalhe): `Feedback(Light) "Selecione um item para ver os detalhes."`.

## Limites

- Split panel é CSS manual — sem resize de painéis;
- `calc(100vh - 160px)` depende da altura do header+toolbar do app — ajustar conforme layout;
- Mobile mostra apenas um painel por vez — coordenação via `mostrarDetalheMobile`;
- Seleção de item não persiste ao navegar para outra rota — estado local ao componente;
- Para detalhe com muitos campos considerar sub-rotas (`/itens/{id}`) em vez de state local.

### Responsividade

Mobile (< lg): painel de lista ocupa tela inteira; ao selecionar item, painel de detalhe substitui a lista com `mostrarDetalheMobile = true`; `IconButton(ChevronLeft)` visível apenas no mobile para voltar à lista.
