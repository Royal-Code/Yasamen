# UIP-SYSTEM-OFFLINE_SYNC - Blueprint resumido

## Pattern

UIP-SYSTEM-OFFLINE_SYNC — Offline Sync — ver `uip-system-offline-sync.ui-map.md`

## Gap coberto

A lib não tem componente de offline/sync. O gap é orientar: banner persistente `Feedback(Warning)` para estado offline detectado via JS interop, e `Badge(Warning/Danger)` por item com status de sincronização pendente.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: JS interop com `window.addEventListener('online'/'offline')` via `[JSInvokable]` para detectar conectividade; `Feedback(Warning)` condicionado a `!isOnline` no shell; `Badge` por item para status de sync pendente/conflito.

## Componentes usados

- `Feedback` — papel: principal (banner de estado offline) — ver `feedback.sample.md`
- `Badge` — papel: composição (status de sync por item) — ver `badge.sample.md`

## Recursos visuais

- `Feedback(Themes.Warning)` — banner de offline persistente
- `Badge(Themes.Warning, "Pendente")` — item aguardando sync
- `Badge(Themes.Danger, "Conflito")` — item com conflito de sync

## Receita

JS interop para detectar conectividade + `Feedback` condicional no shell + `Badge` por item.

```razor
@inject IJSRuntime JS
@implements IDisposable

@code {
    private bool isOnline = true;
    private DotNetObjectReference<MinhaPage>? _ref;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _ref = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("eval", @"
                window.addEventListener('offline', () =>
                    DotNet.invokeMethodAsync('SeuApp', 'OnOffline'));
                window.addEventListener('online', () =>
                    DotNet.invokeMethodAsync('SeuApp', 'OnOnline'));
            ");
        }
    }

    [JSInvokable] public static Task OnOffline() { /* atualizar isOnline */ return Task.CompletedTask; }
    [JSInvokable] public static Task OnOnline()  { /* atualizar isOnline */ return Task.CompletedTask; }

    public void Dispose() => _ref?.Dispose();
}

@* Banner de estado offline *@
@if (!isOnline)
{
    <Feedback Style="Themes.Warning" AdditionalClasses="mb-4">
        <ChildContent>
            <p class="text-sm font-medium">Você está offline</p>
            <p class="text-xs mt-0.5">
                Algumas funcionalidades podem não estar disponíveis.
                Suas alterações serão sincronizadas ao reconectar.
            </p>
        </ChildContent>
    </Feedback>
}

@* Badge de status de sync por item *@
@foreach (var item in itens)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
        <Bar>
            <StartContent>
                <span class="text-sm text-dark-600">@item.Nome</span>
            </StartContent>
            <EndContent>
                @if (item.Conflito)
                {
                    <Badge Style="Themes.Danger" Text="Conflito" />
                }
                else if (item.SyncPendente)
                {
                    <Badge Style="Themes.Warning" Text="Pendente" />
                }
            </EndContent>
        </Bar>
    </Box>
}
```

## Limites

- Detecção via `navigator.onLine` pode ser imprecisa — um IP detectado mas sem conectividade real não é detectado;
- Estratégia offline-first (service worker, IndexedDB, fila de sincronização) é responsabilidade do app — a lib apenas provê os indicadores visuais;
- `[JSInvokable]` estático limita a atualização de componentes específicos — para reatividade fina usar instâncias `DotNetObjectReference`.
