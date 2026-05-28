# Modal - Sample

## Contrato de uso

**Entrada pública**: `<Modal>` — namespace `RoyalCode.Razor.Modals`
**Grupo**: UI-OVERLAY
**Propósito**: Modal overlay com transições de abertura/fechamento. Renderiza via `SectionContent` com gestão centralizada por `ModalService`. Suporta controle por referência (`@ref`) ou por `ModalHandler` externo.
**Patterns**:
- `implementa`: UIP-OVERLAY-MODAL, UIP-FEEDBACK-CONFIRMATION_DIALOG
- `compõe`: UIP-SYSTEM-PERMISSION_FLOW, UIP-SYSTEM-AUTH_SESSION, UIP-ACTION-COMMAND_PALETTE
**Setup necessário**: `builder.Services.AddYasamenModal()` + `<YasamenStyles />` no `<head>`; `ModalOutlet` incluído automaticamente pelo `AppLayout`

## Regras rápidas

- **Use para**: diálogos de confirmação, formulários modais, detalhes em overlay que bloqueiam interação com a tela principal
- **Evite quando**: o painel deve ser lateral sem bloquear o conteúdo — use `OffCanvas`; para notificações temporárias — use `Notification`
- **Cuidado**: apenas um Modal abre por vez via `ModalService`; tentativas simultâneas ficam em fila

## Exemplos

### `UIP-FEEDBACK-CONFIRMATION_DIALOG` — Modal de confirmação de ação destrutiva

Use `@ref` para abrir via C# ou `ModalHandler` para controle externo; inclua sempre botão Cancel.

```razor
@code {
    private Modal? modalExclusao;
    private ItemDto? itemParaExcluir;

    private async Task ConfirmarExclusao(ItemDto item)
    {
        itemParaExcluir = item;
        if (modalExclusao is not null)
            await modalExclusao.OpenAsync();
    }

    private async Task Excluir()
    {
        await Service.ExcluirAsync(itemParaExcluir!.Id);
        if (modalExclusao is not null)
            await modalExclusao.CloseAsync();
        itemParaExcluir = null;
    }
}

<Modal @ref="modalExclusao" Id="modal-excluir" Size="ModalSize.Small">
    <ChildContent>
        <div class="p-6">
            <h2 class="text-lg font-semibold text-dark-700 mb-2">Confirmar exclusão</h2>
            <p class="text-sm text-dark-600">
                Deseja excluir permanentemente "@(itemParaExcluir?.Nome)"?
                Esta ação não pode ser desfeita.
            </p>
        </div>
        <div class="px-6 py-4 border-t border-light-200 flex justify-end gap-2">
            <Button Style="Themes.Default" Label="Cancelar"
                    OnClick="async () => await modalExclusao!.CloseAsync()" />
            <Button Style="Themes.Danger" Label="Excluir" OnClick="Excluir" />
        </div>
    </ChildContent>
</Modal>
```

**API usada**: `@ref`, `Id`, `OpenAsync()`, `CloseAsync()`
**Nota**: `ModalSize` pode ser `Small`, `Medium`, `Large`. `[inferido]` — verificar enum exato.

### `UIP-OVERLAY-MODAL` — Modal de formulário com ModalHandler

`ModalHandler` permite controle externo desacoplado do componente pai.

```razor
@code {
    private ModalHandler modalFormHandler = new();

    private async Task AbrirEdicao(int id)
    {
        itemId = id;
        await modalFormHandler.OpenAsync();
    }
}

<Button Style="Themes.Primary" Label="Editar"
        OnClick="() => AbrirEdicao(item.Id)" />

<Modal Id="modal-editar-item"
       Handler="@modalFormHandler"
       Center=true
       OnOpenClose="OnModalChange">
    <ChildContent>
        <div class="p-6">
            <Bar AdditionalClasses="mb-4">
                <StartContent>
                    <h2 class="text-lg font-semibold text-dark-700">Editar item</h2>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Close"
                               Style="Themes.Default"
                               OnClick="async () => await modalFormHandler.CloseAsync()" />
                </EndContent>
            </Bar>
            <EditForm Model="modelEdicao" OnValidSubmit="Salvar">
                <DataAnnotationsValidator />
                <Stack AdditionalClasses="gap-4">
                    <TextField @bind-Value="modelEdicao.Nome" Label="Nome" required />
                </Stack>
                <Bar AdditionalClasses="mt-6">
                    <EndContent>
                        <Button Style="Themes.Default" Label="Cancelar"
                                OnClick="async () => await modalFormHandler.CloseAsync()" />
                        <Button Style="Themes.Primary" Label="Salvar"
                                Type="ButtonTypes.Submit" />
                    </EndContent>
                </Bar>
            </EditForm>
        </div>
    </ChildContent>
</Modal>
```

**API usada**: `Handler`, `Center`, `OnOpenClose`

### `UIP-ACTION-COMMAND_PALETTE` — Command palette em Modal

Modal com busca e lista de resultados para ação rápida por teclado.

```razor
@code {
    private Modal? modalComando;
    private string buscaComando = "";
}

<IconButton Icon="WellKnownIcons.Search"
           Style="Themes.Default"
           OnClick="async () => await modalComando!.OpenAsync()"
           title="Abrir comando (Ctrl+K)" />

<Modal @ref="modalComando" Id="modal-comando" Center=true>
    <ChildContent>
        <div class="p-4">
            <TextField @bind-Value="buscaComando"
                       Placeholder="Digite um comando ou pesquise..."
                       autofocus />
            <div class="mt-3 max-h-64 overflow-y-auto">
                @* Lista de resultados filtrados *@
                @foreach (var cmd in comandos.Where(c => c.Nome.Contains(buscaComando, StringComparison.OrdinalIgnoreCase)))
                {
                    <button class="w-full text-left p-2 text-sm text-dark-700 hover:bg-light-50 rounded"
                            @onclick="() => ExecutarComando(cmd)">
                        @cmd.Nome
                    </button>
                }
            </div>
        </div>
    </ChildContent>
</Modal>
```

**API usada**: `@ref`, `Id`, `Center`

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Id` | `string` | EditorRequired | Identificador único do modal |
| `Handler` | `ModalHandler?` | null | Controle externo — alternativa a `@ref` |
| `Closeable` | `bool` | true | Permite fechar ao clicar no backdrop |
| `Center` | `bool` | true | Centraliza na viewport |
| `OnOpenClose` | `EventCallback<ModalEventArgs>` | — | Callback de abertura/fechamento |

- **Métodos públicos** (via `@ref`): `OpenAsync()`, `CloseAsync()`
- **Slots**: `ChildContent: RenderFragment`

## Limites e combinações frágeis

- Apenas um modal abre por vez — `ModalService` gerencia fila; segundo `OpenAsync()` enquanto há modal aberto enfileira o segundo
- `ModalOutlet` deve estar no DOM (incluído automaticamente pelo `AppLayout`) — sem ele, o modal não renderiza
