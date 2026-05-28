# UIP-INPUT-FILTER_PANEL - Filter Panel

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de filter panel. Requer composição de controles existentes em `Box`/`OffCanvas` para o painel de filtros.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. OffCanvas (para filtros em drawer)
- `cobertura`: painel de filtros lateral que abre sob demanda; `OffCanvasService` para abrir; `Title "Filtros"`; campos de filtro como conteúdo; botões Aplicar/Limpar no footer;
- `nota`: 7;
- `justificativa`: drawer de filtros — padrão correto para telas com pouco espaço e filtros densos.

2. Box (para filtros em painel lateral)
- `cobertura`: painel lateral fixo de filtros em layout desktop; `border-r` para separação; campos de filtro empilhados;
- `nota`: 6;
- `justificativa`: container do painel lateral fixo de filtros em desktop.

3. FieldSelect / FieldCheckbox / FieldText
- `cobertura`: controles de filtro por atributo — select para status/categoria, checkbox para multi-select, text para busca textual;
- `nota`: 6;
- `justificativa`: controles de filtro individuais — cobrem os tipos mais comuns.

4. Bar + Badge (indicador de filtros ativos)
- `cobertura`: barra acima da coleção com botão "Filtros" + badge de contagem de filtros ativos; badges de filtro removíveis para cada filtro ativo;
- `nota`: 7;
- `justificativa`: indicador e acesso rápido a filtros ativos.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `chips/tags de filtros ativos removíveis`: compor `Badge` + `IconButton X` por filtro ativo;
  - `aplicação reativa vs. por botão`: lógica de debounce ou botão "Aplicar" no app C#;
  - `filtros em drawer mobile`: `OffCanvas` cobre;
  - `ordenação integrada ao painel`: `FieldSelect` de ordenação no topo do painel.

- `tipo de adaptação`: composição + estado de filtros no app
- `o que precisa ser feito`:
  - Estado de filtros em C# (`record FiltroDto` ou objeto anônimo) no componente pai;
  - `OffCanvas` ou `Box` lateral como container; controles de filtro no interior;
  - Botão "Filtros" + badge de ativos na barra da coleção; chips de filtros ativos acima da coleção.

## Como usar

### Filtros em drawer (mobile-first)

```razor
@inject OffCanvasService OffCanvasService

@code {
    private FiltroDto filtros = new();
    private int FiltrosAtivos => 
        (filtros.Status != null ? 1 : 0) +
        (filtros.Categoria != null ? 1 : 0) +
        (filtros.DataDe != null ? 1 : 0);

    private void AplicarFiltros()
    {
        OffCanvasService.CloseAsync("filtros");
        CarregarDados();
    }
}

<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="filtros.Busca" Placeholder="Buscar..."
                   @oninput="CarregarDados" />
    </StartContent>
    <EndContent>
        <div class="relative">
            <Button Style="Themes.Secondary" Outline=true Label="Filtros"
                    Icon="WellKnownIcons.Filter"
                    OnClick="() => OffCanvasService.OpenAsync("filtros")" />
            @if (FiltrosAtivos > 0)
            {
                <Badge Style="Themes.Primary" Text="@FiltrosAtivos.ToString()"
                       AdditionalClasses="absolute -top-1 -right-1 text-xs" />
            }
        </div>
    </EndContent>
</Bar>

@* Chips de filtros ativos *@
@if (FiltrosAtivos > 0)
{
    <div class="flex flex-wrap gap-2 mb-3">
        @if (filtros.Status != null)
        {
            <div class="flex items-center gap-1 px-2 py-1 bg-primary-50 rounded-full text-xs">
                <span>Status: @filtros.Status</span>
                <button @onclick="() => { filtros.Status = null; CarregarDados(); }">×</button>
            </div>
        }
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Limpar filtros"
                OnClick="() => { filtros = new(); CarregarDados(); }" />
    </div>
}

<OffCanvas Id="filtros" Title="Filtros">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            @* [inferido] FieldSelect não existe — usar <InputSelect> Blazor *@
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
                        OnClick="() => { filtros = new(); OffCanvasService.CloseAsync("filtros"); CarregarDados(); }" />
            </StartContent>
            <EndContent>
                <Button Style="Themes.Primary" Label="Aplicar"
                        OnClick="AplicarFiltros" />
            </EndContent>
        </Bar>
    </ChildContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem componente de filter panel nativo; painel lateral, drawer e chips de filtros ativos são composição manual; sem persitência de filtros ou filtros salvos nativos; ordenação integrada requer lógica manual;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `OffCanvas` + controles de filtro + `Badge` cobrem o padrão de filter panel funcional;
  - Nota 4 reflete composição manual adequada mas sem abstração dedicada de filter panel na lib.
