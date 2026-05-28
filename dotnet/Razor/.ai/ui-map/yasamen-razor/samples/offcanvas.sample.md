# OffCanvas - Sample

## Contrato de uso

**Entrada pública**: `<OffCanvas>` — namespace `RoyalCode.Razor.Components`
**Grupo**: UI-OVERLAY
**Propósito**: Painel deslizante lateral (drawer) com suporte a posição Start/End, fitting Incorporated/Overlaying/Float, backdrop e título opcional via `AsideBox` integrado.
**Patterns**:
- `implementa`: UIP-OVERLAY-DRAWER
- `compõe`: PP-LIST-DETAIL, PP-CATALOG, PP-DASHBOARD, SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS, SHP-PORTAL, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE
**Setup necessário**: `builder.Services.AddYasamenOffCanvas()` + `<YasamenStyles />` no `<head>`; `OffCanvasOutlet` incluído automaticamente pelo `AppLayout`

## Regras rápidas

- **Use para**: painéis laterais de filtro, detalhes, formulários de edição rápida, navegação contextual
- **Evite quando**: deve bloquear toda interação como diálogo — use `Modal`; para notificações temporárias — use `Notification`
- **Cuidado**: `Position` deve ser `Start` ou `End` — qualquer outro valor lança `InvalidOperationException`; `Fitting.Incorporated` (padrão) empurra o conteúdo principal, `Fitting.Overlaying` sobrepõe sem mover

## Exemplos

### `UIP-OVERLAY-DRAWER, PP-LIST-DETAIL` — Drawer de detalhes com UseBox (padrão)

`UseBox=true` (padrão) envolve automaticamente o conteúdo em `AsideBox` com título e botão fechar.

```razor
@code {
    private OffCanvas? drawerDetalhes;
    private ItemDto? itemSelecionado;

    private async Task AbrirDetalhes(ItemDto item)
    {
        itemSelecionado = item;
        if (drawerDetalhes is not null)
            await drawerDetalhes.OpenAsync();
    }
}

<OffCanvas @ref="drawerDetalhes"
           Position="Positions.End"
           Title="Detalhes do item"
           UseBox=true
           Closeable=true
           Modal=true>
    <ChildContent>
        <Stack AdditionalClasses="gap-4">
            <div>
                <p class="text-sm text-dark-500">Nome</p>
                <p class="text-dark-700 font-medium">@itemSelecionado?.Nome</p>
            </div>
            <div>
                <p class="text-sm text-dark-500">Status</p>
                <Badge Style="Themes.Success" Label="@itemSelecionado?.Status" />
            </div>
        </Stack>
        <Bar AdditionalClasses="mt-6">
            <EndContent>
                <Button Style="Themes.Primary" Label="Editar"
                        OnClick="() => IrParaEdicao(itemSelecionado!.Id)" />
            </EndContent>
        </Bar>
    </ChildContent>
</OffCanvas>
```

**API usada**: `@ref`, `Position`, `Title`, `UseBox`, `Closeable`, `Modal`, `OpenAsync()`
**Nota**: `Modal=true` adiciona backdrop escuro. `Closeable=true` mostra botão × no cabeçalho do AsideBox e fecha ao clicar no backdrop.

### `UIP-OVERLAY-DRAWER, PP-CATALOG, PP-DASHBOARD, SHP-PORTAL, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE` — Drawer de filtros com OffCanvasHandler e UseBox=false

`UseBox=false` libera layout customizado; `OffCanvasHandler` permite controle externo desacoplado.

```razor
@code {
    private OffCanvasHandler filtrosHandler = new();
    private FiltroDto filtros = new();
}

<Button Style="Themes.Default" Label="Filtros"
        OnClick="async () => await filtrosHandler.Show()" />

<OffCanvas Handler="@filtrosHandler"
           Position="Positions.Start"
           Fitting="Fitting.Overlaying"
           UseBox=false
           Closeable=true>
    <ChildContent>
        <div class="p-6 h-full flex flex-col">
            <Bar AdditionalClasses="mb-6">
                <StartContent>
                    <h2 class="text-lg font-semibold text-dark-700">Filtros</h2>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Close"
                               Style="Themes.Default"
                               OnClick="async () => await filtrosHandler.Hide()" />
                </EndContent>
            </Bar>
            <Stack AdditionalClasses="gap-4 flex-1">
                <TextField @bind-Value="filtros.Busca" Label="Busca" />
                <TextField @bind-Value="filtros.Categoria" Label="Categoria" />
            </Stack>
            <Bar AdditionalClasses="mt-4 border-t border-light-200 pt-4">
                <EndContent>
                    <Button Style="Themes.Default" Label="Limpar"
                            OnClick="() => filtros = new()" />
                    <Button Style="Themes.Primary" Label="Aplicar"
                            OnClick="async () => { await AplicarFiltros(); await filtrosHandler.Hide(); }" />
                </EndContent>
            </Bar>
        </div>
    </ChildContent>
</OffCanvas>
```

**API usada**: `Handler`, `Position`, `Fitting`, `UseBox`
**Nota**: `Fitting.Overlaying` sobrepõe o conteúdo principal sem mover o layout; `Fitting.Incorporated` (padrão) empurra o conteúdo. Com `UseBox=false`, toda estrutura interna é responsabilidade do conteúdo — inclua o botão fechar manualmente via `filtrosHandler.Hide()`.

### `SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS` — Drawer lateral com Toggle via handler

Padrão workspace: botão no topbar abre/fecha drawer de navegação ou contexto.

```razor
@code {
    private OffCanvasHandler contextoHandler = new();
}

<AppTopBar>
    <StartContent>
        <IconButton Icon="WellKnownIcons.Menu"
                   Style="Themes.Default"
                   OnClick="async () => await contextoHandler.Toggle()" />
    </StartContent>
</AppTopBar>

<OffCanvas Handler="@contextoHandler"
           Position="Positions.Start"
           Fitting="Fitting.Incorporated"
           Title="Contexto"
           BoxSize="Sizes.Large"
           Closeable=true>
    <ChildContent>
        <Stack AdditionalClasses="gap-2">
            <p class="text-sm text-dark-600">Área de contexto ou navegação secundária</p>
        </Stack>
    </ChildContent>
</OffCanvas>
```

**API usada**: `Handler`, `Fitting`, `BoxSize`, `Toggle()`
**Nota**: `IsVisible` em `contextoHandler` pode ser usado para refletir estado no botão (ex: `Style="contextoHandler.IsVisible ? Themes.Primary : Themes.Default"`). `BoxSize` controla a largura do `AsideBox` interno.

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Position` | `Positions` | `End` | `Start` ou `End` — outros valores lançam `InvalidOperationException` |
| `Fitting` | `Fitting` | `Incorporated` | `Incorporated` empurra conteúdo; `Overlaying` sobrepõe; `Float` |
| `Modal` | `bool` | false | Adiciona backdrop escuro |
| `Closeable` | `bool` | true | Fecha ao clicar no backdrop; exibe botão × no AsideBox |
| `Handler` | `OffCanvasHandler?` | null | Controle externo — alternativa a `@ref` |
| `UseBox` | `bool` | true | Envolve conteúdo em `AsideBox` com cabeçalho |
| `Title` | `string?` | null | Título do AsideBox (requer `UseBox=true`) |
| `BoxSize` | `Sizes` | `Medium` | Tamanho (largura) do AsideBox interno |
| `OnVisibilityChanged` | `EventCallback<bool>` | — | Callback ao abrir/fechar |

- **Métodos públicos** (via `@ref`): `OpenAsync()`, `CloseAsync()`
- **OffCanvasHandler** (via `Handler`): `Show()`, `Hide()`, `Toggle()`, `IsVisible`, `RegisterStateHasChanged(Action)`
- **Slots**: `ChildContent: RenderFragment`

## Limites e combinações frágeis

- `Position` aceita apenas `Start` ou `End` — `Positions.Center` e outros lançam `InvalidOperationException` em `SetParametersAsync`
- `OffCanvasOutlet` deve estar no DOM (incluído automaticamente pelo `AppLayout`) — sem ele, o painel não renderiza
- `Title` e botão fechar automático só funcionam com `UseBox=true`; com `UseBox=false`, estruture o cabeçalho manualmente
- `RegisterStateHasChanged` é necessário quando o estado `IsVisible` do handler precisa refletir na UI do componente pai — registrar no `OnInitialized`/`OnAfterRender` e limpar no `Dispose`
