# AppSideBar - Sample

## Visão geral
- **Propósito**: sidebar fixa lateral para navegação ou ações.
- **Complexidade**: 4
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU
- **Variações demonstradas**: posição start/end e itens.

## Exemplos

### UIP-NAV-NAVIGATION_MENU

**Objetivo**: navegação lateral no shell.

```razor
<AppSideBar Position="Positions.Start" Size="SpacingSize.LargerX2">
    <AppSideItem Active="true">
        <IconButton Icon="BsIconNames.List" title="Módulos" />
    </AppSideItem>
</AppSideBar>
```

**Props usadas**: `Position`, `Size`, `ChildContent`.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: cria zona persistente para navegação global.

### Uso via AppLayout

**Objetivo**: sidebar integrada ao shell.

```razor
<AppLayout>
    <LeftMenu>
        <AppSideMenuButton />
    </LeftMenu>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: `LeftMenu` do `AppLayout`.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: usa layout-aware side menu.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Size` | `SpacingSize` | largura | dimensão |
| `Position` | `Positions` | start/end | lado |
| `ChildContent` | `RenderFragment` | itens | conteúdo |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Oculta em telas pequenas conforme CSS do shell; menu mobile precisa offcanvas.

## Combinações frágeis
- Usar `Position` fora de Start/End é inválido.
