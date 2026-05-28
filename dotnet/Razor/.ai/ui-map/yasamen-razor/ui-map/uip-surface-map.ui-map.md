# UIP-SURFACE-MAP - Map Surface

**GAP — sem componente dedicado**

A biblioteca não tem componente de mapa cartográfico. Requer biblioteca externa (Leaflet.js, Google Maps, Bing Maps via JS interop).

## Componentes

**Principais**: nenhum.

**Composição**:

1. Box
- `cobertura`: container do viewport do mapa;
- `nota`: 3;
- `justificativa`: container visual apenas — sem capacidade cartográfica.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: biblioteca externa com JS interop
- `o que precisa ser feito`:
  - Integrar Leaflet.js ou Google Maps JavaScript API via `IJSRuntime`;
  - Criar Razor component wrapper com `@ref` para div container + `IJSObjectReference`;
  - Para lista de locais sem necessidade de mapa interativo: usar `UIP-DATA-LIST_ITEM` com endereço textual.

## Como usar

### Container para mapa via JS interop (esqueleto)

```razor
@inject IJSRuntime JS

<div @ref="mapaDiv" class="w-full h-96 rounded-md border border-light-200"></div>

@code {
    private ElementReference mapaDiv;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initMap", mapaDiv, Lat, Lng, Zoom);
    }
}
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente cartográfico nativo; depende completamente de biblioteca JS externa; JS interop necessário para toda interação;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A lib não provê superfície cartográfica — requer biblioteca externa de mapa via JS interop;
  - Para localização textual, `UIP-DATA-LIST_ITEM` com endereço resolve sem mapa;
  - Nota 0 reflete ausência total de suporte nativo.
