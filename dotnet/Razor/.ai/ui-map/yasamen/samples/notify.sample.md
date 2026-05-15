# Notify - Sample

## Visão geral
- **Propósito**: serviço para disparar notificações por tema.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: disparo simples e ajuste de placement.

## Exemplos

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: emitir toast global após ação.

```razor
@inject Notify Notify

<Button Label="Salvar"
        Style="Themes.Primary"
        OnClick="@(_ => Notify.ShowAsync(Themes.Success, "Salvo", "Alterações gravadas."))" />
```

**Props usadas**: não aplicável; é serviço.  
**Eventos relevantes**: não aplicável.  
**Por que atende o pattern**: dispara feedback não bloqueante sem montar `Notification` manualmente.

### Placement customizado

**Objetivo**: enviar notificação para posição específica.

```razor
@inject Notify Notify

<Button Label="Avisar"
        OnClick="@(_ => Notify.ShowAsync(Themes.Info, "Processando", "Aguarde.", item => item.Placement = Placements.TopEnd))" />
```

**Props usadas**: `Themes`, `text`, `details`, callback de item.  
**Eventos relevantes**: configuráveis no item de notificação.  
**Por que atende o pattern**: permite orquestrar toast por serviço.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Themes` nos métodos | `Themes` | semântica | define aparência |
| `text` | `string` | sempre | mensagem principal |
| `details` | `string?` | contexto | detalhe |
| callback de item | `Action<NotificationItem>` | ajustes | placement/timer/flags |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| callbacks no item | abertura/fechamento | rastrear toast |

## Limitações
- Requer registro dos serviços/outlets de notificação no app.

## Combinações frágeis
- Não usar para mensagens que precisam ficar persistentes na página.
