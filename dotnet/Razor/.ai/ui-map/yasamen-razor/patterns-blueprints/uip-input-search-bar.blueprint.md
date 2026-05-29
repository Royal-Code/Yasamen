# UIP-INPUT-SEARCH_BAR - Blueprint resumido

## Pattern

UIP-INPUT-SEARCH_BAR — Search Bar — ver `uip-input-search-bar.ui-map.md`

## Gap coberto

`TextField` cobre a busca textual simples. Os gaps são: debounce reativo, botão limpar integrado, e integração com botão "Pesquisar" explícito — todos por composição com `Bar + TextField + IconButton`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `TextField + @oninput + Task.Delay(CancellationToken)` para busca reativa com debounce; `Bar(TextField + IconButton + Button)` para busca com ação explícita; `@oninput` condicionado para exibir botão de limpar.

## Componentes usados

- `TextField` — papel: principal (campo de busca) — ver `field-text.sample.md`
- `Bar` — papel: composição (container da barra) — ver `bar.sample.md`
- `Button / IconButton` — papel: composição (pesquisar e limpar) — ver `button.sample.md`

## Recursos visuais

- `flex gap-2 w-full` — campo + botões em linha
- `flex-1` no `TextField` — campo ocupa espaço disponível
- `AdditionalClasses="w-full max-w-md"` — largura máxima do campo em layout largo

## Receita

Busca reativa com debounce via `CancellationTokenSource`; ou busca por clique com `Button "Buscar"` ao lado.

```razor
@* Busca reativa com debounce *@
@code {
    private string termoBusca = "";
    private CancellationTokenSource? _cts;

    private async Task OnBuscar(ChangeEventArgs e)
    {
        termoBusca = e.Value?.ToString() ?? "";
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        try
        {
            await Task.Delay(300, _cts.Token);
            await CarregarResultados(termoBusca);
        }
        catch (TaskCanceledException) { }
    }
}

<TextField Value="@termoBusca" Placeholder="Buscar usuários..."
           @oninput="OnBuscar" />

@* Busca com botão explícito e limpar *@
<Bar AdditionalClasses="mb-4">
    <StartContent AdditionalClasses="flex-1">
        <div class="flex gap-2 w-full">
            <TextField @bind-Value="termoBusca"
                       Placeholder="Buscar..."
                       AdditionalClasses="flex-1" />
            @if (!string.IsNullOrEmpty(termoBusca))
            {
                <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                            OnClick="() => { termoBusca = ""; CarregarResultados(""); }" />
            }
            <Button Style="Themes.Primary" Label="Buscar"
                    Icon="WellKnownIcons.Search"
                    OnClick="() => CarregarResultados(termoBusca)" />
        </div>
    </StartContent>
</Bar>

@* Search integrada na barra com acesso a filtros *@
<Bar AdditionalClasses="mb-4">
    <StartContent AdditionalClasses="flex-1">
        <TextField @bind-Value="termoBusca"
                   Placeholder="Buscar por nome ou código..."
                   AdditionalClasses="w-full max-w-md"
                   @oninput="OnBuscar" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Secondary" Outline=true
                Label="Filtros"
                Icon="WellKnownIcons.Filter"
                OnClick="AbrirFiltros" />
    </EndContent>
</Bar>
```

## Limites

- Sem botão X integrado visualmente dentro do campo (`relative` + `absolute`) — botão ao lado como alternativa funcional;
- Sem sugestões/autocomplete nativo — ver `uip-input-option-picker.blueprint.md` para combobox manual;
- Debounce requer `CancellationTokenSource` manual — padrão verboso mas robusto.
