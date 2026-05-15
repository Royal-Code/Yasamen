# CloseOffCanvasButton - Sample

## Visão geral
- **Propósito**: botão de fechar offcanvas usando handler cascated.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-INPUT-FILTER_PANEL, UIP-NAV-NAVIGATION_MENU
- **Variações demonstradas**: uso dentro de `OffCanvas`.

## Exemplos

### UIP-INPUT-FILTER_PANEL

**Objetivo**: fechar painel lateral pelo contexto.

```razor
<OffCanvas Handler="filters" UseBox="false" Position="Positions.End">
    <div class="p-4 bg-white">
        <div class="flex justify-between">
            <h2 class="font-medium">Filtros</h2>
            <CloseOffCanvasButton />
        </div>
    </div>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filters = new();
}
```

**Props usadas**: handler vem por cascata.  
**Eventos relevantes**: clique fecha o offcanvas.  
**Por que atende o pattern**: oferece saída explícita do painel.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| handler cascated | `OffCanvasHandler` | dentro de offcanvas | fecha painel |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| clique interno | clique no botão | fechar painel |

## Limitações
- Lança exceção sem `OffCanvasHandler` cascated.

## Combinações frágeis
- Não usar fora de `OffCanvas`/`AsideBox`.
