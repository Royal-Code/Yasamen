# OffCanvasOutlet - Sample

## Visão geral
- **Propósito**: outlet global de offcanvas ajustado ao contexto de layout.
- **Complexidade**: 6
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU, UIP-INPUT-FILTER_PANEL
- **Variações demonstradas**: uso indireto pelo shell e direto.

## Exemplos

### Uso recomendado via AppLayout

**Objetivo**: incluir infraestrutura de offcanvas no shell.

```razor
<AppLayout>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: indiretas pelo shell.  
**Eventos relevantes**: internos do serviço de offcanvas.  
**Por que atende o pattern**: mantém camadas de painel respeitando topbar/menus.

### Uso direto em shell custom

**Objetivo**: permitir offcanvas global sem `AppLayout`.

```razor
<main class="min-h-screen bg-light-100">
    @Body
    <OffCanvasOutlet />
</main>
```

**Props usadas**: service-driven/contexto.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: renderiza painéis registrados pelo serviço.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| contexto de layout | `ILayoutContext` | interno | offsets do shell |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | abertura/fechamento | coordenar camada |

## Limitações
- Infraestrutura interna; preferir `AppLayout`.

## Combinações frágeis
- Sem contexto de layout, offsets podem não refletir topbar/sidebar.
