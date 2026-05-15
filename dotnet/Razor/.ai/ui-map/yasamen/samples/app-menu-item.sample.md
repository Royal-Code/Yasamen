# AppMenuItem - Sample

## Visão geral
- **Propósito**: renderizar item de menu como link, módulo ou divider, com favorito.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-NAV-NAVIGATION_MENU, UIP-DATA-LIST_ITEM
- **Variações demonstradas**: uso indireto e item visual equivalente.

## Exemplos

### Uso indireto via AppMenu

**Objetivo**: renderizar itens a partir do serviço/modelo de menu.

```razor
<AppLayout>
    <LeftMenu><AppSideMenuButton /></LeftMenu>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: indiretas por `AppMenuList`.  
**Eventos relevantes**: internos do menu.  
**Por que atende o pattern**: `AppMenuItem` é a unidade de destino global.

### Item visual equivalente

**Objetivo**: alternativa manual quando não usar menu service.

```razor
<Box AdditionalClasses="p-3 bg-white border border-light-300 rounded-md">
    <div class="flex items-center justify-between">
        <span>Clientes</span>
        <IconButton Icon="BsIconNames.Star" title="Favorito" />
    </div>
</Box>
```

**Props usadas**: composição alternativa.  
**Eventos relevantes**: eventos no botão.  
**Por que atende o pattern**: representa unidade de navegação com ação secundária.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Item` | `MenuItem` | interno | destino renderizado |
| `AppMenuContext` | contexto | interno | navegação/favoritos |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | clique/favorito | navegação |

## Limitações
- Não é componente público genérico de list item.

## Combinações frágeis
- Favoritos e módulos dependem de infraestrutura do menu.
