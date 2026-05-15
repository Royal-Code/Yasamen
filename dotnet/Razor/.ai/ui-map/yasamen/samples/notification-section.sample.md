# NotificationSection - Sample

## Visão geral
- **Propósito**: converter item do serviço em `Notification` visual.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT
- **Variações demonstradas**: uso indireto via `Notify` e outlet.

## Exemplos

### Uso via Notify

**Objetivo**: acionar a cadeia service -> section -> notification.

```razor
@inject Notify Notify

<Button Label="Notificar"
        Style="Themes.Primary"
        OnClick="@(_ => Notify.ShowAsync(Themes.Info, "Processando", "Aguarde."))" />
```

**Props usadas**: indiretas no `NotificationItem`.  
**Eventos relevantes**: eventos de `NotificationItem`.  
**Por que atende o pattern**: usa a ponte interna sem acoplamento ao componente.

### Uso via NotificationOutlet

**Objetivo**: renderizar itens emitidos pelo serviço.

```razor
<NotificationOutlet />
```

**Props usadas**: service-driven.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: `NotificationSection` aparece dentro do outlet.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Item` | `NotificationItem` | interno | dados do toast |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | fechar/abrir | sincronizar serviço |

## Limitações
- Não consumir diretamente em tela comum.

## Combinações frágeis
- Duplicar renderização manual e via serviço pode mostrar toast duas vezes.
