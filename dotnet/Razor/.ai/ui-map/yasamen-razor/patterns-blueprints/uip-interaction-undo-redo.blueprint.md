# UIP-INTERACTION-UNDO_REDO - Blueprint resumido

## Pattern

UIP-INTERACTION-UNDO_REDO — Undo Redo — ver `uip-interaction-undo-redo.ui-map.md`

## Gap coberto

A lib não tem suporte a histórico de ações. O gap é orientar: toast de undo imediato após ação destrutiva via `Notification + Button(Desfazer)`, e toolbar undo/redo com `ButtonGroup + Button(Disabled)` para contextos de edição.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: para undo pontual usar `NotificationService` com `Button "Desfazer"` no `ChildContent` do toast; para undo/redo sistemático usar `Stack<TState>` em serviço C# + `ButtonGroup` com botões `Disabled` controlados.

## Componentes usados

- `Button / IconButton` — papel: principal (ações undo/redo) — ver `button.sample.md`
- `ButtonGroup` — papel: composição (grupo undo/redo na toolbar) — ver `button.sample.md`

## Recursos visuais

- `Disabled="@!podeDesfazer"` — undo desabilitado quando histórico vazio
- `Disabled="@!podeRefazer"` — redo desabilitado quando não há futuro

## Receita

Toast com undo imediato; toolbar de undo/redo para contextos de edição.

```razor
@* Padrão 1: Toast com undo imediato após ação destrutiva *@
@inject NotificationService NotificationService

@code {
    private ItemDto? itemExcluido;

    private async Task Excluir(ItemDto item)
    {
        itemExcluido = item;
        await ItemService.ExcluirAsync(item.Id);
        await NotificationService.ShowAsync(new NotificationOptions
        {
            Style = Themes.Success,
            Title = $""{item.Nome}" excluído",
            ChildContent = @<Button Style="Themes.Light" Label="Desfazer"
                                    OnClick="DesfazerExclusao" />
        });
    }

    private async Task DesfazerExclusao()
    {
        if (itemExcluido is null) return;
        await ItemService.RestaurarAsync(itemExcluido);
        itemExcluido = null;
    }
}

@* Padrão 2: Toolbar undo/redo para editor *@
@code {
    private Stack<EstadoEditor> historico = new();
    private Stack<EstadoEditor> futuro = new();
    private EstadoEditor estadoAtual = new();

    private bool PodeDesfazer => historico.Count > 0;
    private bool PodeRefazer => futuro.Count > 0;

    private void ExecutarAcao(EstadoEditor novoEstado)
    {
        historico.Push(estadoAtual);
        futuro.Clear();
        estadoAtual = novoEstado;
    }

    private void Desfazer()
    {
        if (!PodeDesfazer) return;
        futuro.Push(estadoAtual);
        estadoAtual = historico.Pop();
    }

    private void Refazer()
    {
        if (!PodeRefazer) return;
        historico.Push(estadoAtual);
        estadoAtual = futuro.Pop();
    }
}

<Bar AdditionalClasses="mb-4">
    <StartContent>
        <ButtonGroup>
            <IconButton Icon="WellKnownIcons.Undo" Style="Themes.Default"
                        Disabled="@(!PodeDesfazer)"
                        OnClick="Desfazer"
                        title="Desfazer (Ctrl+Z)" />
            <IconButton Icon="WellKnownIcons.Redo" Style="Themes.Default"
                        Disabled="@(!PodeRefazer)"
                        OnClick="Refazer"
                        title="Refazer (Ctrl+Y)" />
        </ButtonGroup>
    </StartContent>
</Bar>
```

## Limites

- Toast de undo tem janela temporal implícita — se o usuário fechar o toast, a ação não pode mais ser desfeita (design correto para undo-toast);
- `Stack<TState>` para histórico exige serialização do estado completo da tela — adequado para editores simples; para editores complexos considerar padrão Command;
- Atalhos de teclado Ctrl+Z/Ctrl+Y requerem listener global via JS interop — ver `uip-interaction-keyboard-flow.blueprint.md`.
