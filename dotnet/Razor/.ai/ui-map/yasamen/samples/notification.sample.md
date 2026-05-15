# Notification - Sample

## Visão geral
- **Propósito**: toast/notificação visual individual com tema, ícone, timer e fechamento.
- **Complexidade**: 6
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: texto simples, conteúdo estruturado, timer.

## Exemplos

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: notificação temporária com timer.

```razor
<Notification Text="Operação concluída"
              Theme="Themes.Success"
              Icon="true"
              Closeable="true"
              Timer="@TimeSpan.FromSeconds(6)" />
```

**Props usadas**: `Text`, `Theme`, `Icon`, `Closeable`, `Timer`.  
**Eventos relevantes**: `OnClose`, `OnOpen` disponíveis.  
**Por que atende o pattern**: entrega feedback temporário, sem bloquear a tarefa.

### Conteúdo estruturado

**Objetivo**: mensagem com detalhe.

```razor
<Notification Theme="Themes.Info" Icon="true" Closeable="true">
    <NotificationContent Text="Importação iniciada"
                         Details="Você será avisado quando o processamento terminar." />
</Notification>
```

**Props usadas**: `ChildContent`, `Theme`, `Icon`, `Closeable`.  
**Eventos relevantes**: `OnClose` para remover item de grupo.  
**Por que atende o pattern**: suporta informação principal e detalhamento.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Text` | `string?` | toast simples | mensagem principal |
| `Theme` | `Themes` | semântica | cor |
| `Icon` | `bool` | reforço visual | mostra ícone/barra |
| `Timer` | `TimeSpan?` | fechar automático | duração |
| `Closeable` | `bool` | fechamento manual | mostra fechar |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnOpen` | notificação abre | telemetria |
| `OnClose` | notificação fecha | remover item |

## Limitações
- Posicionamento global deve vir de `NotificationGroup`, `NotificationOutlet` ou `Notify`.

## Combinações frágeis
- Evitar mensagem longa demais em toast; usar `Feedback` inline quando precisar persistência.
