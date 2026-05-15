# NotificationGroup - Sample

## Visão geral
- **Propósito**: agrupar notificações por `Placement`.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT
- **Variações demonstradas**: placement e lista dinâmica.

## Exemplos

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: renderizar notificações em uma posição.

```razor
<NotificationGroup Placement="Placements.TopEnd">
    <Notification Theme="Themes.Success" Text="Salvo" Icon="true" Closeable="true" />
    <Notification Theme="Themes.Warning" Text="Atenção necessária" Icon="true" Closeable="true" />
</NotificationGroup>
```

**Props usadas**: `Placement`, `ChildContent`.  
**Eventos relevantes**: eventos ficam nas notificações.  
**Por que atende o pattern**: controla zona visual de toasts.

### Lista dinâmica

**Objetivo**: renderizar coleção de toasts.

```razor
<NotificationGroup Placement="@placement">
    @foreach (var item in items)
    {
        <Notification Theme="@item.Theme" Text="@item.Text" Closeable="true" />
    }
</NotificationGroup>

@code {
    private Placements placement = Placements.TopEnd;
    private readonly (Themes Theme, string Text)[] items = [(Themes.Info, "Processando")];
}
```

**Props usadas**: `Placement`, `ChildContent`.  
**Eventos relevantes**: `Notification.OnClose` para remoção.  
**Por que atende o pattern**: permite pilha de notificações.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Placement` | `Placements` | posicionar grupo | canto/zona |
| `ChildContent` | `RenderFragment?` | conteúdo | notificações |
| `AdditionalClasses` | `string?` | ajuste local | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Está em área interna/avançada apesar de aparecer em demo.

## Combinações frágeis
- Preferir `Notify`/outlet global para uso comum.
