# NotificationContent - Sample

## Visão geral
- **Propósito**: conteúdo padronizado para `Notification`, com texto e detalhes.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT
- **Variações demonstradas**: texto e detalhes.

## Exemplos

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: estruturar notificação com título e detalhe.

```razor
<Notification Theme="Themes.Info" Icon="true" Closeable="true">
    <NotificationContent Text="Sincronização iniciada"
                         Details="A operação pode levar alguns minutos." />
</Notification>
```

**Props usadas**: `Text`, `Details`.  
**Eventos relevantes**: eventos ficam em `Notification`.  
**Por que atende o pattern**: separa mensagem curta e detalhe sem layout manual.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Text` | `string` | sempre | mensagem principal |
| `Details` | `string` | quando houver contexto | texto secundário |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | conteúdo passivo |

## Limitações
- Deve ser usado dentro de `Notification`.

## Combinações frágeis
- Não usar como bloco de conteúdo geral fora de toast.
