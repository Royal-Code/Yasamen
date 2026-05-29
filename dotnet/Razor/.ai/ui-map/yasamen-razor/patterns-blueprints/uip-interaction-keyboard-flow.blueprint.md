# UIP-INTERACTION-KEYBOARD_FLOW - Blueprint resumido

## Pattern

UIP-INTERACTION-KEYBOARD_FLOW — Keyboard Flow — ver `uip-interaction-keyboard-flow.ui-map.md`

## Gap coberto

O foco visual é automático via CSS da lib. O gap é orientar o que **não** é automático: `tabindex` explícito, atalhos globais via JS interop, e alertas sobre focus trap ausente em `Modal`/`OffCanvas`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `tabindex` via `AdditionalAttributes` para reordenação pontual; atalhos de teclado via `@onkeydown` no componente ou `window.addEventListener` via JS interop; focus trap em Modal requer implementação manual ou biblioteca JS.

## Componentes usados

- `Button / IconButton` — papel: principal (foco visual automático, tabindex via AdditionalAttributes) — ver `button.sample.md`
- `Modal` — papel: composição (focus trap não automático) — ver `modal.sample.md`

## Recursos visuais

- `focus-within:ring-{tema}-300/50` — ring de foco aplicado automaticamente pelo CSS ya-btn
- `tabindex="0"` — tornar elemento não-interativo focalizável
- `tabindex="-1"` — remover elemento do tab order natural

## Receita

Foco visual automático sem código; `tabindex` via `AdditionalAttributes` para casos pontuais; atalhos via `@onkeydown`.

```razor
@* Foco visual: automático em todos os componentes ya-* — nenhum código necessário *@
<Button Style="Themes.Primary" Label="Ação" OnClick="Executar" />
@* Ao receber foco via Tab: ring semitransparente aplicado automaticamente *@

@* Tabindex explícito para reordenação (uso excepcional) *@
<Button Style="Themes.Secondary" Label="Ação secundária"
        AdditionalAttributes="@(new Dictionary<string,object> { {"tabindex", "2"} })" />

@* Atalho de teclado local (@onkeydown no componente) *@
<div @onkeydown="HandleKeyDown" tabindex="0">
    @* ... conteúdo da lista ou grid *@
</div>

@code {
    private void HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Delete" && itemSelecionado is not null)
            ExcluirItem(itemSelecionado);
        if (e.Key == "n" && e.CtrlKey)
            AbrirNovo();
    }
}

@* Atalho global de teclado (via JS interop — para Ctrl+K, F2, etc.) *@
@inject IJSRuntime JS

@code {
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("eval", @"
                window.addEventListener('keydown', function(e) {
                    if (e.key === 'F2') {
                        DotNet.invokeMethodAsync('SeuApp', 'OnAtalhoF2');
                    }
                });
            ");
    }

    [JSInvokable]
    public static Task OnAtalhoF2()
    {
        // lógica de atalho global
        return Task.CompletedTask;
    }
}
```

## Limites

- `Modal` e `OffCanvas` **não** têm focus trap automático — foco pode sair por Tab; implementar via biblioteca de acessibilidade se necessário (ex.: Microsoft.AspNetCore.Components.Web com `FocusTrap`);
- Foco retornado ao elemento de origem após fechar modal requer `ElementReference` + `FocusAsync()` manual;
- `tabindex` positivo (> 0) é antipadrão de acessibilidade — usar apenas quando realmente necessário.
