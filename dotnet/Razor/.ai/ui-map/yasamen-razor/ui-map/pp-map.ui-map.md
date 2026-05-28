# PP-MAP - Map

**GAP crítico — UIP-SURFACE-MAP é GAP (nota 0)**

A biblioteca não tem componente de mapa. PP-MAP depende de `UIP-SURFACE-MAP` como superfície espacial, que é GAP completo. A implementação requer biblioteca externa (Leaflet.js via JS interop, Google Maps API, Blazor.Leaflet, etc.).

## Componentes por zona funcional

### Zona: Superfície (mapa) — GAP

1. (UIP-SURFACE-MAP — nota 0)
- `cobertura`: sem cobertura nativa; viewport cartográfico requer biblioteca externa;
- `nota`: 0;
- `justificativa`: GAP crítico — toda a superfície de mapa é responsabilidade de biblioteca externa.

### Zona: Filtros

1. Bar + FieldText (busca de local)
- `cobertura`: busca por nome, endereço ou categoria sobre o mapa;
- `nota`: 7;
- `justificativa`: toolbar de busca — componente nativo.

2. OffCanvas (UIP-INPUT-FILTER_PANEL)
- `cobertura`: filtros de camada/categoria em drawer;
- `nota`: 9;
- `justificativa`: filtros avançados em painel lateral.

### Zona: Detalhe do marcador

1. OffCanvas ou Modal (detalhe do ponto)
- `cobertura`: detalhe do ponto selecionado com endereço, ações, foto;
- `nota`: 9;
- `justificativa`: detalhe do ponto de interesse.

### Zona: Ações

1. Bar + Button (ações sobre o mapa)
- `cobertura`: "Nova localização", "Minha localização", toggle de camadas;
- `nota`: 8;
- `justificativa`: ações de controle do mapa.

**Descartados**: nenhum.

## Como integrar com biblioteca de mapa externa

```razor
@* Estrutura de PP-MAP com Leaflet via JS interop *@
@page "/mapa"
@inject IJSRuntime JS

@code {
    private bool painelAberto;
    private PontoDto? pontoSelecionado;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("initMap", "mapa-container", DotNetObjectReference.Create(this));
            await CarregarPontos();
        }
    }

    [JSInvokable]
    public void OnMarkerClick(int pontoId)
    {
        pontoSelecionado = pontos.FirstOrDefault(p => p.Id == pontoId);
        painelAberto = true;
        StateHasChanged();
    }
}

@* Layout: mapa + controles *@
<div class="relative h-full w-full">
    @* Toolbar sobreposta ao mapa *@
    <div class="absolute top-4 left-4 right-4 z-10 max-w-lg">
        <Box Border="BorderBuilder.Box" AdditionalClasses="bg-white shadow-lg p-2">
            <Bar>
                <StartContent>
                    <FieldText Placeholder="Buscar no mapa..." @bind-Value="busca"
                               @oninput="FiltrarPontos" />
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Filter" Style="Themes.Default"
                               OnClick='() => OffCanvasService.Open<FiltrosMapaDrawer>()' />
                    <IconButton Icon="WellKnownIcons.Location" Style="Themes.Default"
                               title="Minha localização"
                               OnClick='async () => await JS.InvokeVoidAsync("centerOnUser")' />
                </EndContent>
            </Bar>
        </Box>
    </div>

    @* Container do mapa (preenchido por Leaflet/Google Maps) *@
    <div id="mapa-container" class="w-full h-full">
        @* Biblioteca de mapa renderiza aqui via JS *@
    </div>

    @* Botão de nova localização *@
    <div class="absolute bottom-6 right-6 z-10">
        <Button Style="Themes.Primary"
                AdditionalClasses="rounded-full shadow-lg"
                Label="+ Adicionar ponto"
                OnClick='() => ModalService.Open<NovoPontoModal>()' />
    </div>
</div>

@* Painel de detalhe do ponto selecionado *@
<OffCanvas Title="@(pontoSelecionado?.Nome ?? "Detalhe")"
           @bind-IsOpen="painelAberto"
           Position="OffCanvasPosition.End"
           Size="OffCanvasSize.Medium">
    <ChildContent>
        @if (pontoSelecionado is not null)
        {
            <Stack Gap="Gaps.Medium">
                @if (pontoSelecionado.ImagemUrl is not null)
                {
                    <img src="@pontoSelecionado.ImagemUrl" alt="@pontoSelecionado.Nome"
                         class="w-full h-40 object-cover rounded" />
                }
                <dl class="space-y-2 text-sm">
                    <div>
                        <dt class="text-dark-400 text-xs">Endereço</dt>
                        <dd class="text-dark-600">@pontoSelecionado.Endereco</dd>
                    </div>
                    <div>
                        <dt class="text-dark-400 text-xs">Categoria</dt>
                        <dd><Badge Style="@pontoSelecionado.CategoriaTema"
                                   Text="@pontoSelecionado.Categoria" /></dd>
                    </div>
                </dl>
            </Stack>
        }
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Fechar"
                OnClick="() => painelAberto = false" />
        <Button Style="Themes.Primary" Label="Ver detalhes"
                OnClick='() => Nav.NavigateTo($"/pontos/{pontoSelecionado?.Id}")' />
    </FooterContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 1;
- `limitações`: sem componente de mapa nativo — GAP crítico; todo o viewport cartográfico requer biblioteca externa; a lib contribui apenas com toolbar, filtros e painéis de detalhe em overlay;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `Bar` + `OffCanvas` + `Modal` + `Button` cobrem os controles e overlays do mapa com boa qualidade;
  - A superfície de mapa em si é responsabilidade de Leaflet.js, Google Maps, Azure Maps ou equivalente;
  - Nota 1 reflete dependência total de biblioteca externa para a zona de superfície principal.
