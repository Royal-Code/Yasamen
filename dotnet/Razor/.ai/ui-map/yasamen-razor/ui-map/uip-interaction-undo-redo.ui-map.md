# UIP-INTERACTION-UNDO_REDO - Undo Redo

**GAP — sem cobertura viável**

A biblioteca não provê suporte a histórico de ações (undo/redo). Toda lógica de desfazer/refazer é responsabilidade do app.

## Componentes

**Principais**: nenhum.

**Composição**:

1. Button / IconButton
- `cobertura`: botões de "Desfazer" / "Refazer" na action bar;
- `nota`: 5;
- `justificativa`: apenas o botão de ação — sem lógica de histórico.

## Esforço de adaptação

- `tipo de adaptação`: nova implementação
- `o que precisa ser feito`:
  - Implementar pilha de histórico (`Stack<TState>`) em serviço C# do app;
  - Botões de undo/redo via `Button` + lógica de habilitação via `Disabled="@!podeDesfazer"`;
  - Para toast de undo após ação: usar `Notification` com `Button` "Desfazer" no `ChildContent`.

## Como usar

### Toast com ação de undo

```razor
@* Toast com ação de desfazer via NotificationService + ChildContent *@
await NotificationService.ShowAsync(new NotificationOptions
{
    Style = Themes.Success,
    Title = "Registro excluído",
    Content = @<Button Style="Themes.Light" Label="Desfazer" OnClick="DesfazerExclusao" />
});
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem suporte a histórico; Toast com undo é a única variante coberta indiretamente;
- `recomendação`: `evitar`
- `justificativa geral`: nenhum suporte nativo de undo/redo — lógica deve ser implementada pelo app.
