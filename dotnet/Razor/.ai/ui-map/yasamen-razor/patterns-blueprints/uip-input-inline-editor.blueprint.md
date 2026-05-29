# UIP-INPUT-INLINE_EDITOR - Blueprint resumido

## Pattern

UIP-INPUT-INLINE_EDITOR — Inline Editor — ver `uip-input-inline-editor.ui-map.md`

## Gap coberto

A lib não tem componente de inline editor. O gap é orientar o padrão de alternância leitura/edição com `bool editando` + `TextField + IconButton` + `@onkeydown` para Enter/Escape + ícone lápis visível via `group-hover`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: estado `bool editando + string valorEdicao` no componente; modo leitura com `group-hover:opacity-100` no ícone lápis; modo edição com `TextField + IconButton(check/X)`; `@onkeydown` para Enter/Escape; `autofocus` para foco automático.

## Componentes usados

- `TextField` — papel: principal (campo de edição inline) — ver `field-text.sample.md`
- `IconButton` — papel: composição (editar, confirmar, cancelar) — ver `button.sample.md`

## Recursos visuais

- `group flex items-center gap-1` — wrapper para hover do ícone lápis
- `opacity-0 group-hover:opacity-100 transition-opacity` — ícone lápis visível só no hover
- `autofocus` — foco automático ao entrar no modo edição

## Receita

Alternância entre modo leitura (span + ícone hover) e modo edição (TextField + confirmar/cancelar).

```razor
@code {
    private bool editando;
    private string valorEdicao = "";
    private bool salvando;

    [Parameter] public string ValorAtual { get; set; } = "";
    [Parameter] public Func<string, Task> AoSalvar { get; set; } = _ => Task.CompletedTask;

    private void IniciarEdicao()
    {
        valorEdicao = ValorAtual;
        editando = true;
    }

    private void CancelarEdicao() => editando = false;

    private async Task ConfirmarEdicao()
    {
        salvando = true;
        await AoSalvar(valorEdicao);
        ValorAtual = valorEdicao;
        editando = false;
        salvando = false;
    }

    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter") await ConfirmarEdicao();
        else if (e.Key == "Escape") CancelarEdicao();
    }
}

@if (editando)
{
    <div class="flex items-center gap-1">
        <TextField @bind-Value="valorEdicao"
                   @onkeydown="OnKeyDown"
                   AdditionalClasses="py-0.5"
                   autofocus />
        <IconButton Icon="WellKnownIcons.Check" Style="Themes.Success"
                    Size="Sizes.Small" Loading="@salvando"
                    OnClick="ConfirmarEdicao" />
        <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                    Size="Sizes.Small" Disabled="@salvando"
                    OnClick="CancelarEdicao" />
    </div>
}
else
{
    <div class="group flex items-center gap-1">
        <span class="text-dark-600 cursor-pointer" @ondblclick="IniciarEdicao">
            @(string.IsNullOrEmpty(ValorAtual) ? "Clique para editar..." : ValorAtual)
        </span>
        <IconButton Icon="WellKnownIcons.Edit" Style="Themes.Default"
                    Size="Sizes.Small"
                    AdditionalClasses="opacity-0 group-hover:opacity-100 transition-opacity"
                    OnClick="IniciarEdicao" />
    </div>
}

@* Variante: auto-save ao perder foco (blur) *@
@if (editando)
{
    <TextField @bind-Value="valorEdicao"
               @onblur="ConfirmarEdicao"
               @onkeydown="OnKeyDown"
               autofocus />
}
else
{
    <span class="cursor-pointer hover:bg-light-100 px-1 rounded text-dark-600"
          @onclick="IniciarEdicao">
        @(string.IsNullOrEmpty(ValorAtual) ? "Clique para editar..." : ValorAtual)
    </span>
}
```

## Limites

- `autofocus` funciona na primeira renderização — para foco programático em re-render usar `@ref + FocusAsync()` com `await InvokeAsync(StateHasChanged)`;
- Auto-save com `@onblur` dispara antes do click no botão cancelar em alguns browsers — preferir confirmar/cancelar explícitos;
- Sem validação inline automática — adicionar `Feedback(Danger)` abaixo do campo se necessário.
