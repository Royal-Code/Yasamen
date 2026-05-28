# UIP-INPUT-INLINE_EDITOR - Inline Editor

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de inline editor. Requer composição manual com alternância de estado `editando` + `FieldText`/`IconButton` para ativar/confirmar/cancelar edição no ponto de leitura.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. FieldText
- `cobertura`: campo de edição exibido quando `editando == true`; `@bind-Value` para o valor editável; `@onkeydown` para Enter (confirmar) e Escape (cancelar);
- `nota`: 7;
- `justificativa`: campo de edição inline — cobre o controle de input em modo de edição.

2. IconButton
- `cobertura`: trigger de ativação de edição (ícone de lápis/edit); botões de confirmar (check) e cancelar (X) durante edição;
- `nota`: 7;
- `justificativa`: controles de ativação, confirmação e cancelamento da edição inline.

3. Button
- `cobertura`: alternativa ao IconButton para confirmar/cancelar com labels explícitos em mobile;
- `nota`: 7;
- `justificativa`: ações de confirmação/cancelamento com label visível.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `ativação por clique no próprio texto`: estado `editando` toggle + renderização condicional;
  - `auto-save ao blur`: `@onblur="Salvar"` no `FieldText`;
  - `foco automático ao ativar`: `@ref` + `FocusAsync()` após `StateHasChanged()`;
  - `erro de validação inline`: `Feedback Danger` pequeno abaixo do campo em modo edição.

- `tipo de adaptação`: composição + estado de edição no componente
- `o que precisa ser feito`:
  - Estado `bool editando` + `string valorEdicao` no componente;
  - Renderização condicional: modo leitura (span + ícone lápis) vs. modo edição (FieldText + confirmar/cancelar);
  - `@onkeydown` para Enter/Escape; `@onblur` para auto-save quando aplicável.

## Como usar

### Inline editor com confirmar/cancelar

```razor
@code {
    private bool editando = false;
    private string valorEdicao = "";
    private bool salvando = false;

    private void IniciarEdicao() { valorEdicao = ValorAtual; editando = true; }
    private void CancelarEdicao() { editando = false; }
    private async Task ConfirmarEdicao()
    {
        salvando = true;
        await SalvarValor(valorEdicao);
        ValorAtual = valorEdicao;
        editando = false;
        salvando = false;
    }
    
    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter") await ConfirmarEdicao();
        if (e.Key == "Escape") CancelarEdicao();
    }

    [Parameter] public string ValorAtual { get; set; } = "";
    [Parameter] public Func<string, Task> SalvarValor { get; set; } = _ => Task.CompletedTask;
}

@if (editando)
{
    <div class="flex items-center gap-1">
        <FieldText @bind-Value="valorEdicao" @onkeydown="OnKeyDown"
                   AdditionalClasses="py-0.5" AutoFocus=true />
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
            @ValorAtual
        </span>
        <IconButton Icon="WellKnownIcons.Edit" Style="Themes.Default"
                    Size="Sizes.Small"
                    AdditionalClasses="opacity-0 group-hover:opacity-100 transition-opacity"
                    OnClick="IniciarEdicao" />
    </div>
}
```

### Edição inline com auto-save (blur)

```razor
@if (editando)
{
    <FieldText @bind-Value="valorEdicao"
               @onblur="ConfirmarEdicao"
               @onkeydown="OnKeyDown"
               AutoFocus=true />
}
else
{
    <span class="cursor-pointer hover:bg-light-100 px-1 rounded" @onclick="IniciarEdicao">
        @(string.IsNullOrEmpty(ValorAtual) ? "Clique para editar..." : ValorAtual)
    </span>
}
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de inline editor nativo; toda lógica de edição/confirmação/cancelamento é do app; foco automático requer `@ref` + JS ou `AutoFocus`; sem validação inline automática;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `FieldText` + `IconButton` + estado `editando` formam um inline editor funcional;
  - A lógica de alternância é totalmente manual — sem abstração dedicada;
  - Nota 2 reflete que apenas primitivos genéricos cobrem o pattern sem suporte específico da lib.
