# UIP-SURFACE-CANVAS - Canvas Surface

**GAP — sem componente dedicado**

A biblioteca não tem componente de canvas editável. Requer biblioteca de canvas/diagrama externa (Excalidraw, React Flow via WASM, fabric.js, Blazor Diagram, etc.) com JS interop.

## Componentes

**Principais**: nenhum.

**Composição**: nenhum viável — canvas editável com pan/zoom, objetos, layers e handles não é construtível a partir dos componentes existentes.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: biblioteca externa obrigatória
- `o que precisa ser feito`:
  - Para flow/diagrama: Blazor Diagrams (Blazor-native), GoDiagram ou Mermaid.js via JS interop;
  - Para canvas de desenho/whiteboard: Excalidraw ou fabric.js via JS interop;
  - Para editor de layout simples: bibliotecas Blazor como MudBlazor MudDropContainer;
  - A lib yasamen-razor não participa da superfície canvas.

## Como usar

```razor
@* Nenhum uso disponível com componentes da lib *@
@* Usar biblioteca externa de canvas com JS interop ou Blazor-native *@
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente de canvas nativo; pan/zoom, objetos, layers e handles requerem lib especializada; apenas bibliotecas externas são viáveis;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A lib não provê nenhum primitivo de canvas editável;
  - Requer biblioteca externa especializada — yasamen-razor não participa deste pattern;
  - Nota 0 reflete ausência total de suporte nativo.
