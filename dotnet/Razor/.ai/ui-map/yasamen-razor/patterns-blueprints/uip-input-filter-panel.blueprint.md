# UIP-INPUT-FILTER_PANEL - Blueprint resumido

## Pattern

UIP-INPUT-FILTER_PANEL — Filter Panel — ver `uip-input-filter-panel.ui-map.md`

## Gap coberto

A lib não tem filter panel. O gap é orientar: drawer de filtros via `OffCanvas`, badge de filtros ativos no trigger, chips removíveis para filtros aplicados, e botões Aplicar/Limpar.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `OffCanvas("filtros")` para drawer mobile-first com `<InputSelect>` por filtro; `Badge` de contagem absoluto no botão trigger; chips de filtros ativos com botão `×` por item.

## Componentes usados

- `OffCanvas` — papel: principal (drawer de filtros) — ver `modal.sample.md`
- `Bar` — papel: composição (barra com trigger de filtros) — ver `bar.sample.md`
- `Badge` — papel: composição (contador de filtros ativos) — ver `badge.sample.md`
- `Button` — papel: composição (aplicar, limpar) — ver `button.sample.md`
- `Stack` — papel: composição (controles de filtro) — ver `stack.sample.md`

## Recursos visuais

- `absolute -top-1 -right-1` — badge de contagem sobreposto ao botão
- `flex flex-wrap gap-2 mb-3` — chips de filtros ativos
- `px-2 py-1 bg-primary-50 rounded-full text-xs` — chip de filtro ativo

## Receita

`OffCanvas` com controles de filtro + `Badge` de contagem no trigger + chips removíveis acima da coleção.

```razor
@code {
    private OffCanvas? offCanvasFiltros;
    private FiltroDto filtros = new();
    private int FiltrosAtivos =>
        (filtros.Status is not null ? 1 : 0) +
        (filtros.Categoria is not null ? 1 : 0) +
        (filtros.DataDe is not null ? 1 : 0);

    private async Task AplicarFiltros()
    {
        await offCanvasFiltros!.CloseAsync();
        CarregarDados();
    }
}

@* Barra com busca + trigger de filtros *@
<Bar AdditionalClasses="mb-4">
    <StartContent AdditionalClasses="flex-1">
        <TextField @bind-Value="filtros.Busca" Placeholder="Buscar..."
                   AdditionalClasses="w-full max-w-md" @oninput="CarregarDados" />
    </StartContent>
    <EndContent>
        <div class="relative">
            <Button Style="Themes.Secondary" Outline=true
                    Label="Filtros"
                    Icon="WellKnownIcons.Filter"
                    OnClick="async () => await offCanvasFiltros!.OpenAsync()" />
            @if (FiltrosAtivos > 0)
            {
                <Badge Style="Themes.Primary"
                       Text="@FiltrosAtivos.ToString()"
                       AdditionalClasses="absolute -top-1 -right-1 text-xs" />
            }
        </div>
    </EndContent>
</Bar>

@* Chips de filtros ativos *@
@if (FiltrosAtivos > 0)
{
    <div class="flex flex-wrap gap-2 mb-3">
        @if (filtros.Status is not null)
        {
            <div class="flex items-center gap-1 px-2 py-1 bg-primary-50
                        rounded-full text-xs text-primary-700">
                <span>Status: @filtros.Status</span>
                <button class="ml-1 text-primary-500 hover:text-primary-700"
                        @onclick="() => { filtros.Status = null; CarregarDados(); }">
                    ×
                </button>
            </div>
        }
        @if (filtros.Categoria is not null)
        {
            <div class="flex items-center gap-1 px-2 py-1 bg-primary-50
                        rounded-full text-xs text-primary-700">
                <span>Categoria: @filtros.Categoria</span>
                <button class="ml-1 text-primary-500 hover:text-primary-700"
                        @onclick="() => { filtros.Categoria = null; CarregarDados(); }">
                    ×
                </button>
            </div>
        }
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Limpar filtros"
                OnClick="() => { filtros = new(); CarregarDados(); }" />
    </div>
}

@* Drawer de filtros *@
<OffCanvas @ref="offCanvasFiltros" Id="filtros" Title="Filtros">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            <div class="flex flex-col gap-1">
                <label class="text-sm font-medium text-dark-600">Status</label>
                <InputSelect @bind-Value="filtros.Status"
                             class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                    <option value="">Todos</option>
                    <option value="ativo">Ativo</option>
                    <option value="inativo">Inativo</option>
                </InputSelect>
            </div>
            <div class="flex flex-col gap-1">
                <label class="text-sm font-medium text-dark-600">Categoria</label>
                <InputSelect @bind-Value="filtros.Categoria"
                             class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                    <option value="">Todas</option>
                    @foreach (var cat in categorias)
                    {
                        <option value="@cat.Id">@cat.Nome</option>
                    }
                </InputSelect>
            </div>
        </Stack>
        <Bar AdditionalClasses="mt-6">
            <StartContent>
                <Button Style="Themes.Default" Label="Limpar"
                        OnClick="async () => { filtros = new(); await offCanvasFiltros!.CloseAsync(); CarregarDados(); }" />
            </StartContent>
            <EndContent>
                <Button Style="Themes.Primary" Label="Aplicar"
                        OnClick="AplicarFiltros" />
            </EndContent>
        </Bar>
    </ChildContent>
</OffCanvas>
```

## Limites

- Sem `FieldSelect` nativo — `<InputSelect>` Blazor com classes Tailwind manuais;
- Chips de filtros ativos requerem mapeamento manual de cada campo do `FiltroDto` para label + valor;
- Painel lateral fixo (desktop) é `Box` com `border-r` — alternar entre painel e drawer requer lógica de breakpoint.
