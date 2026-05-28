# NotificationContent - Sample

## Contrato de uso

**Entrada pública**: `<NotificationContent>` — namespace `RoyalCode.Razor.Alerts`
**Grupo**: UI-FEEDBACK
**Propósito**: Conteúdo estruturado para `Notification` com texto principal e linha de detalhes em duas linhas.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-FEEDBACK-TOAST_ALERT, UIP-SYSTEM-BACKGROUND_PROGRESS
**Setup necessário**: `builder.Services.AddYasamenNotification()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: dentro de `<Notification>` quando precisa de texto principal + uma linha de detalhes complementares
- **Evite quando**: o conteúdo da notificação é texto simples — use diretamente o parâmetro `Text` de `Notification`

## Exemplos

### `UIP-FEEDBACK-TOAST_ALERT, UIP-SYSTEM-BACKGROUND_PROGRESS` — Texto + detalhes em notificação

Use como `ChildContent` de `Notification` para exibir mensagem principal e linha de detalhe.

```razor
<Notification Theme="Themes.Success" Icon=true>
    <ChildContent>
        <NotificationContent Text="Relatório exportado"
                             Details="arquivo: relatorio-q4-2025.pdf (2,3 MB)" />
    </ChildContent>
</Notification>

<Notification Theme="Themes.Danger" Icon=true Closeable=true>
    <ChildContent>
        <NotificationContent Text="Falha ao sincronizar"
                             Details="Verifique a conexão e tente novamente." />
    </ChildContent>
</Notification>
```

**API usada**: `Text`, `Details` (ambos EditorRequired)

## API relevante

- **Props/parâmetros**: `Text: string` (EditorRequired), `Details: string` (EditorRequired)
- **Slots**: -
