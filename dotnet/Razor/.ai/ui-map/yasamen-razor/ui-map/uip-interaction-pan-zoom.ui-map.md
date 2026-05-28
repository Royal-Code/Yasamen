# UIP-INTERACTION-PAN_ZOOM - Pan Zoom

**GAP — sem cobertura viável**

Navegação espacial por zoom e pan requer superfície especializada. A biblioteca não provê nenhum componente ou primitivo para este pattern.

## Componentes

**Principais**: nenhum.
**Composição**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `viewport pan/zoom`: totalmente fora do escopo da lib — requer lib JS especializada (react-zoom-pan-pinch, panzoom, etc.) via JS interop.
- `tipo de adaptação`: nova implementação externa
- `o que precisa ser feito`: integrar lib JS de pan/zoom via interop Blazor em elemento `<div>` com conteúdo a ser manipulado.

## Como usar

```razor
@* Sem implementação suportada pela biblioteca *@
@* Usar lib JS externa via interop: panzoom, react-zoom-pan-pinch, etc. *@
<div id="pan-zoom-container" style="overflow:hidden;width:100%;height:400px">
    @* conteúdo a ser manipulado *@
</div>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: nenhum suporte na biblioteca; requer lib JS externa;
- `recomendação`: `evitar`
- `justificativa geral`: pattern fora do escopo da lib — implementação exclusivamente via lib JS externa.
