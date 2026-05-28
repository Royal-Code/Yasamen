# UIP-SYSTEM-OFFLINE_SYNC - Offline Sync

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de offline/sync. Para web, o estado offline é detectado via JS interop (`navigator.onLine`, eventos `online`/`offline`). A comunicação visual usa componentes genéricos da lib.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Notification (Themes.Warning / Themes.Danger)
- `cobertura`: toast ou banner de estado offline/sync pendente; `NotificationService` para toast não bloqueante;
- `nota`: 6;
- `justificativa`: feedback de conectividade transitória — adequado para notificação de mudança de estado.

2. Feedback (Themes.Warning)
- `cobertura`: banner persistente de estado offline em zonas de conteúdo; texto + ícone de aviso; botão "Tentar novamente";
- `nota`: 6;
- `justificativa`: indicação contextual persistente de estado offline ou pendente.

3. Badge
- `cobertura`: indicador de item não sincronizado em listas; `Themes.Warning` para pendente; `Themes.Danger` para conflito;
- `nota`: 5;
- `justificativa`: marcador de estado de sync por item individual.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: composição + JS interop
- `o que precisa ser feito`:
  - Detectar offline via `window.addEventListener('online'/'offline')` via JS interop;
  - Estado de sincronização gerenciado pelo app (fila pendente, conflitos);
  - Usar `Notification` para mudança de estado; `Feedback` para banner persistente; `Badge` por item;
  - Estratégia offline-first (service worker, IndexedDB) é responsabilidade do app, não da lib.

## Como usar

### Banner de estado offline persistente

```razor
@inject IJSRuntime JS

@code {
    private bool isOnline = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("registerNetworkListeners", DotNetObjectReference.Create(this));
    }

    [JSInvokable] public void OnOffline() { isOnline = false; StateHasChanged(); }
    [JSInvokable] public void OnOnline()  { isOnline = true;  StateHasChanged(); }
}

@if (!isOnline)
{
    <Feedback Style="Themes.Warning"
              Text="Você está offline. Algumas funcionalidades podem não estar disponíveis."
              AdditionalClasses="mb-4" />
}
```

### Badge de item com sync pendente

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
    <Bar>
        <StartContent>
            <span class="text-sm">@item.Nome</span>
        </StartContent>
        <EndContent>
            @if (item.SyncPendente)
            {
                <Badge Style="Themes.Warning" Text="Pendente" />
            }
            @if (item.Conflito)
            {
                <Badge Style="Themes.Danger" Text="Conflito" />
            }
        </EndContent>
    </Bar>
</Box>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de offline/sync nativo; detecção de conectividade requer JS interop; estratégia offline-first (service worker, IndexedDB) é responsabilidade do app; visualização de fila e conflitos é totalmente manual;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Notification` + `Feedback` + `Badge` cobrem os indicadores visuais de estado offline/sync;
  - A lógica offline é responsabilidade do app — a lib contribui apenas com os elementos visuais;
  - Nota 3 reflete cobertura visual básica com toda lógica de sync externa à lib.
