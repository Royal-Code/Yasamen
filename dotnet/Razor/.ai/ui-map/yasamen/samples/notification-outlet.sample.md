# NotificationOutlet - Sample

## Visão geral
- **Propósito**: outlet interno que renderiza grupos de notificação do serviço.
- **Complexidade**: 6
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: uso indireto pelo shell e uso direto.

## Exemplos

### Uso via AppLayout

**Objetivo**: ter toasts globais disponíveis.

```razor
<AppLayout>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: indiretas pelo shell.  
**Eventos relevantes**: eventos das notificações.  
**Por que atende o pattern**: renderiza notificações emitidas pelo serviço.

### Uso direto em shell custom

**Objetivo**: adicionar área global de notificações.

```razor
<main>
    @Body
    <NotificationOutlet />
</main>
```

**Props usadas**: service-driven.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: conecta `Notify` à UI.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| service-driven | interno | shell | renderização global |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | notificação abre/fecha | sincronização |

## Limitações
- Infraestrutura interna; preferir `AppLayout`.

## Combinações frágeis
- Sem outlet/serviço, `Notify` não produz UI visível.
