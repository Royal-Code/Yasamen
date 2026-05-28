# UIP-INPUT-CHOICE_GROUP - Choice Group

**GAP parcial — sem componentes dedicados de radio group e checkbox group**

A biblioteca não tem `FieldCheckbox`, `RadioGroup` ou `CheckboxGroup`. Para boolean usa-se `<InputCheckbox>` Blazor nativo ou HTML `<input type="checkbox">`. Seleção única visível entre poucas opções: `ButtonGroup` + `Button`.

## Componentes

**Principais**: nenhum dedicado para grupo.

**Composição**:

1. ButtonGroup + Button (como segmented choice)
- `cobertura`: seleção única visível entre 2-4 opções curtas via `ButtonGroup` com `Button Active="@(valor==opcao)"`; visual de botões selecionados; sem semântica de radio;
- `nota`: 5;
- `justificativa`: segmented control visual com estado ativo — bom para 2-4 opções curtas, mas sem semântica de form field.

2. HTML `<input type="checkbox">` / Blazor `<InputCheckbox>` (boolean)
- `cobertura`: seleção binária (liga/desliga, sim/não); `<InputCheckbox @bind-Value="model.Ativo">` integra com `EditForm`; `<input type="checkbox" @bind="model.Ativo">` funciona fora de EditForm; sem estilização da biblioteca;
- `nota`: 4;
- `justificativa`: funcional mas sem Label, sem estilização nativa da lib — requer HTML manual de `<label>` + input.

3. HTML `<select multiple>` / Blazor `<InputSelect>` (multi-select)
- `cobertura`: seleção múltipla via `<select multiple>`; visual nativo do browser; sem estilização da biblioteca;
- `nota`: 3;
- `justificativa`: funcional mas visual de dropdown nativo do browser, não de choice group estilizado.

**Descartados**:
- `FieldCheckbox`: componente não existe na biblioteca.
- `FieldSelect`: componente não existe na biblioteca.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `toggle/switch binário estilizado`: sem nativo — HTML `<input type="checkbox">` + CSS ou `ButtonGroup` com 2 opções;
  - `radio group estilizado`: HTML `<input type="radio">` com `accent-primary-500` ou `ButtonGroup` para seleção única;
  - `checkbox group estilizado`: múltiplos `<input type="checkbox">` com `<label>` em `Stack`;
  - `segmented control (opções visíveis)`: `ButtonGroup` + `Button Active` cobre visualmente.

- `tipo de adaptação`: composição + HTML nativo
- `o que precisa ser feito`:
  - Binário (sim/não, liga/desliga): `<InputCheckbox>` Blazor em EditForm + `<label>` HTML manual;
  - Segmented choice (2-4 opções curtas): `ButtonGroup` + `Button` com `Active`;
  - Radio/checkbox group: HTML nativo com `accent-primary-500` e classes Tailwind para estilo.

## Como usar

### Toggle binário (Blazor InputCheckbox)

```razor
<div class="flex flex-col gap-2 mb-4">
    <div class="flex items-center gap-2">
        <InputCheckbox @bind-Value="model.Ativo" id="cb-ativo" class="accent-primary-500" />
        <label for="cb-ativo" class="text-sm text-dark-600 cursor-pointer">Usuário ativo</label>
    </div>
    <div class="flex items-center gap-2">
        <InputCheckbox @bind-Value="model.Notificacoes" id="cb-notif" class="accent-primary-500" />
        <label for="cb-notif" class="text-sm text-dark-600 cursor-pointer">Receber notificações por e-mail</label>
    </div>
</div>
```

### Segmented choice (seleção única visível)

```razor
@code {
    private string plano = "basico";
}

<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Plano</label>
    <ButtonGroup>
        <Button Label="Básico" Style="Themes.Secondary"
                Active="@(plano=="basico")" Outline="@(plano!="basico")"
                OnClick='() => plano = "basico"' />
        <Button Label="Profissional" Style="Themes.Secondary"
                Active="@(plano=="pro")" Outline="@(plano!="pro")"
                OnClick='() => plano = "pro"' />
        <Button Label="Enterprise" Style="Themes.Secondary"
                Active="@(plano=="enterprise")" Outline="@(plano!="enterprise")"
                OnClick='() => plano = "enterprise"' />
    </ButtonGroup>
</div>
```

### Checkbox group com HTML nativo

```razor
<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Permissões</label>
    @foreach (var (id, label, prop) in new[] {
        ("perm-edit", "Editar registros", model.PodeEditar),
        ("perm-del", "Excluir registros", model.PodeExcluir),
        ("perm-exp", "Exportar dados", model.PodeExportar)
    })
    {
        <div class="flex items-center gap-2">
            <input type="checkbox" id="@id" checked="@prop"
                   class="accent-primary-500" />
            <label for="@id" class="text-sm text-dark-600 cursor-pointer">@label</label>
        </div>
    }
</div>
```

### Radio group HTML nativo com estilo

```razor
<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Tipo de conta</label>
    @foreach (var tipo in new[] { ("pf", "Pessoa Física"), ("pj", "Pessoa Jurídica") })
    {
        <label class="flex items-center gap-2 cursor-pointer">
            <input type="radio" name="tipoConta" value="@tipo.Item1"
                   checked="@(model.TipoConta == tipo.Item1)"
                   @onchange="() => model.TipoConta = tipo.Item1"
                   class="accent-primary-500" />
            <span class="text-sm text-dark-600">@tipo.Item2</span>
        </label>
    }
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem `FieldCheckbox`, `RadioGroup` ou `CheckboxGroup` nativos; toggle binário e radio/checkbox group requerem HTML nativo + CSS; `ButtonGroup` cobre apenas segmented choice visual;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `ButtonGroup` + `Button Active` cobre segmented choice visual;
  - Para toggle/checkbox/radio: HTML nativo com `accent-primary-500` é a via direta;
  - Nota 2 reflete ausência de componentes dedicados de grupo de escolha estilizados.
