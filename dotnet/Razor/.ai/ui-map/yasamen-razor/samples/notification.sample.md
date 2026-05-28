# Notification - Sample

## Contrato de uso

**Entrada pública**: `<Notification>` + `NotificationService` — namespace `RoyalCode.Razor.Alerts`
**Grupo**: UI-FEEDBACK
**Propósito**: Notificação toast com ícone temático automático, timer visual de auto-dismiss, pausa no hover e suporte a abertura/fechamento programático.
**Patterns**:
- `implementa`: UIP-FEEDBACK-TOAST_ALERT
- `compõe`: UIP-SYSTEM-OFFLINE_SYNC, UIP-SYSTEM-AUTH_SESSION, UIP-SYSTEM-BACKGROUND_PROGRESS, UIP-SYSTEM-NOTIFICATION_CENTER
**Setup necessário**: `builder.Services.AddYasamenNotification()` + `<YasamenStyles />` no `<head>`; `NotificationOutlet` incluído automaticamente pelo `AppLayout`

## Regras rápidas

- **Use para**: feedback temporário de ações (salvo, erro, progresso), alertas com auto-dismiss, toasts de sistema
- **Evite quando**: o feedback precisa persistir e ser lido com calma — use `Feedback`; para confirmações críticas que exigem ação — use `Modal`
- **Cuidado**: `NotificationOutlet` deve estar no layout (incluído pelo `AppLayout`); sem ele, notificações via `NotificationService` não aparecem

## Exemplos

### `UIP-FEEDBACK-TOAST_ALERT` — Toast via NotificationService (modo principal de uso)

Injete `NotificationService` e chame os helpers de tema para exibir toasts programáticos.

```razor
@inject NotificationService NotifService

@code {
    private async Task Salvar()
    {
        try
        {
            await Service.SalvarAsync(model);
            await NotifService.ShowSuccess("Salvo com sucesso!");
        }
        catch (Exception ex)
        {
            await NotifService.ShowDanger($"Erro ao salvar: {ex.Message}");
        }
    }

    private async Task Importar()
    {
        await NotifService.ShowInfo("Importação iniciada. Aguarde...");
        await Service.ImportarAsync();
        await NotifService.ShowSuccess("Importação concluída.");
    }
}
```

**Nota**: `NotificationService` expõe helpers `ShowSuccess`, `ShowDanger`, `ShowWarning`, `ShowInfo` que criam e exibem notificações temporárias. `[inferido]` — verificar assinaturas exatas no serviço.

### `UIP-SYSTEM-BACKGROUND_PROGRESS` — Notificação com conteúdo estruturado via NotificationContent

Para operações em background com texto principal e linha de detalhes, use `NotificationContent` como `ChildContent`.

```razor
@code {
    private Notification? notifProgresso;

    private async Task ExportarRelatorio()
    {
        if (notifProgresso is not null)
            await notifProgresso.OpenAsync();

        await Service.ExportarAsync();

        if (notifProgresso is not null)
            await notifProgresso.CloseAsync();
    }
}

@* Notificação declarativa controlada via referência *@
<Notification @ref="notifProgresso"
              Theme="Themes.Info"
              Icon=true
              StartClosed=true
              Closeable=true>
    <ChildContent>
        <NotificationContent Text="Exportando relatório"
                             Details="Isso pode levar alguns segundos..." />
    </ChildContent>
</Notification>
```

**API usada**: `Theme`, `Icon`, `StartClosed`, `Closeable`, `ChildContent`, `@ref` para `OpenAsync()`/`CloseAsync()`

### `UIP-SYSTEM-OFFLINE_SYNC, UIP-SYSTEM-AUTH_SESSION` — Notificações de estado de sistema

Toasts de sistema para mudanças de conectividade e expiração de sessão.

```razor
@inject NotificationService NotifService

@* Ao detectar reconexão *@
private async Task OnReconectado()
{
    await NotifService.ShowSuccess("Conexão restaurada. Sincronizando...");
}

@* Ao detectar sessão expirando *@
private async Task OnSessaoExpirando()
{
    await NotifService.ShowWarning("Sua sessão expira em 5 minutos.");
}

@* Notificação com CloseOnClick=false para manter visível *@
<Notification Theme="Themes.Warning"
              Timer="@TimeSpan.FromSeconds(10)"
              CloseOnClick=false
              Closeable=true
              Text="Você tem atualizações pendentes de sincronização." />
```

**API usada**: `Timer`, `CloseOnClick`, `Closeable`, `Text`

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Theme` | `Themes` | — | Cor semântica (determina ícone automático) |
| `Text` | `string?` | null | Texto da notificação |
| `Icon` | `bool` | true | Exibe ícone temático automático |
| `Timer` | `TimeSpan?` | null | Duração do auto-dismiss |
| `CloseOnClick` | `bool` | true | Fecha ao clicar na notificação |
| `Closeable` | `bool` | false | Exibe botão fechar manual |
| `StartClosed` | `bool` | false | Inicia fechado (controle via `OpenAsync()`) |
| `OnClose` | `EventCallback` | — | Callback ao fechar |
| `OnOpen` | `EventCallback` | — | Callback ao abrir |

- **Métodos públicos** (via `@ref`): `OpenAsync()`, `CloseAsync()`
- **Slots**: `ChildContent: RenderFragment?` — conteúdo custom; use `NotificationContent` para texto+detalhes estruturados

## Limites e combinações frágeis

- Sem `NotificationOutlet` no DOM (incluso pelo `AppLayout`), notificações via `NotificationService` não renderizam
- A barra de progresso (timer) pausa automaticamente no hover — comportamento nativo, não configurável
