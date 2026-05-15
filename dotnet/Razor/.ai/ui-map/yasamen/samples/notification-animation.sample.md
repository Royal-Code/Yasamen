# NotificationAnimation - Sample

## Visão geral
- **Propósito**: wrapper animado para abrir e fechar notificações.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-LOADING_STATE
- **Variações demonstradas**: referência de componente e fechamento animado.

## Exemplos

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: animar entrada de notification em grupo.

```razor
<NotificationGroup Placement="Placements.TopEnd">
    <NotificationAnimation @ref="animation">
        <Notification Text="Notificação animada"
                      Theme="Themes.Info"
                      Closeable="true"
                      OnClose="@CloseAsync" />
    </NotificationAnimation>
</NotificationGroup>

@code {
    private NotificationAnimation? animation;

    private async Task CloseAsync()
    {
        if (animation is not null)
            await animation.CloseAsync();
    }
}
```

**Props usadas**: `ChildContent`.  
**Eventos relevantes**: métodos `OpenAsync`/`CloseAsync` via `@ref`.  
**Por que atende o pattern**: adiciona movimento curto e funcional ao toast.

### Abertura pós-renderização

**Objetivo**: abrir animação quando a referência estiver disponível.

```razor
<NotificationAnimation @ref="animation">
    <Notification Text="Novo evento" Theme="Themes.Success" />
</NotificationAnimation>

@code {
    private NotificationAnimation? animation;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && animation is not null)
            await animation.OpenAsync();
    }
}
```

**Props usadas**: `ChildContent`.  
**Eventos relevantes**: métodos via ref.  
**Por que atende o pattern**: controla entrada sem inventar API de notificação.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ChildContent` | `RenderFragment` | sempre | conteúdo animado |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OpenAsync` | chamado por ref | abrir animação |
| `CloseAsync` | chamado por ref | fechar animação |

## Limitações
- É suporte interno/avançado; não é primeira escolha para tela simples.

## Combinações frágeis
- Usar sem `@ref` reduz controle de entrada/saída.
