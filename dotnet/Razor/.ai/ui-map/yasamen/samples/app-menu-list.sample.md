# AppMenuList - Sample

## Visão geral
- **Propósito**: lista do menu atual com estados de loading, erro e vazio.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-NAV-NAVIGATION_MENU, UIP-DATA-LIST_ITEM
- **Variações demonstradas**: uso indireto e item atual.

## Exemplos

### Uso indireto via AppMenu

**Objetivo**: renderizar lista de navegação global.

```razor
<AppMenu Handler="menuHandler" />

@code {
    private readonly OffCanvasHandler menuHandler = new();
}
```

**Props usadas**: indiretas por `AppMenu`.  
**Eventos relevantes**: internos do contexto do menu.  
**Por que atende o pattern**: `AppMenuList` renderiza filhos do item atual dentro do menu.

### Componente de lista manual equivalente

**Objetivo**: representar o papel visual quando não usar menu service.

```razor
<Stack AdditionalClasses="gap-2">
    <AppSideItem Active="true">
        <IconButton Icon="BsIconNames.List" title="Clientes" />
    </AppSideItem>
</Stack>
```

**Props usadas**: composição alternativa.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: mostra lista de destinos em sidebar.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `CurrentMenuItem` | `MenuItem` | interno | item raiz exibido |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum público | não aplicável | gerenciado pelo menu |

## Limitações
- Depende de `AppMenuContext`; não é lista genérica.

## Combinações frágeis
- Usar fora do contexto de `AppMenu` tende a exigir infraestrutura do menu.
