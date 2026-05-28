# UIP-INPUT-CHOICE_GROUP - Choice Group

**GAP parcial — sem componentes dedicados de radio group e checkbox group**

A biblioteca não tem componentes de `RadioGroup`, `CheckboxGroup` ou `ToggleGroup`. Disponível: `FieldCheckbox` (boolean) e HTML nativo para radio/checkbox múltiplo.

## Componentes

**Principais**: nenhum dedicado para grupo.

**Composição**:

1. FieldCheckbox
- `cobertura`: seleção binária (liga/desliga, sim/não); `Label`, `@bind-Value` para `bool`; integrado com `EditForm` e validação;
- `limitações`: apenas binário — sem grupo de múltipla seleção nativa;
- `nota`: 7;
- `justificativa`: switch/toggle binário com semântica correta.

2. FieldSelect (HTML `<select multiple>`)
- `cobertura`: seleção única (`<select>`) ou múltipla (`<select multiple>`) de lista curta; integrado com Blazor;
- `limitações`: visual nativo do browser — sem estilização de radio group ou checkbox group;
- `nota`: 4;
- `justificativa`: semântica correta mas visual de dropdown, não de choice group visível.

3. ButtonGroup + Button (como segmented choice)
- `cobertura`: seleção única visível entre 2-4 opções curtas via `ButtonGroup` com `Button Active="@(valor==opcao)"`; visual de botões selecionados; sem semântica de radio;
- `nota`: 5;
- `justificativa`: segmented control visual com estado ativo — bom para 2-4 opções curtas.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `radio group estilizado`: usar HTML `<input type="radio">` + CSS ou composição com `Box` + `@onclick`;
  - `checkbox group estilizado`: múltiplos `FieldCheckbox` em `Stack` com `Label` do grupo acima;
  - `toggle/switch binário`: `FieldCheckbox` cobre;
  - `segmented control (opções visíveis)`: `ButtonGroup` + `Button Active` cobre visualmente.

- `tipo de adaptação`: composição + HTML nativo
- `o que precisa ser feito`:
  - Binário (sim/não, liga/desliga): `FieldCheckbox`;
  - Segmented choice (2-4 opções curtas): `ButtonGroup` + `Button` com `Active`;
  - Radio group / checkbox group estilizado: `Stack` de HTML inputs + CSS ou composição manual.

## Como usar

### Toggle binário

```razor
<FieldCheckbox @bind-Value="model.Ativo" Label="Usuário ativo" />
<FieldCheckbox @bind-Value="model.Notificacoes" Label="Receber notificações por e-mail" />
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
                OnClick="() => plano = "basico"" />
        <Button Label="Profissional" Style="Themes.Secondary"
                Active="@(plano=="pro")" Outline="@(plano!="pro")"
                OnClick="() => plano = "pro"" />
        <Button Label="Enterprise" Style="Themes.Secondary"
                Active="@(plano=="enterprise")" Outline="@(plano!="enterprise")"
                OnClick="() => plano = "enterprise"" />
    </ButtonGroup>
</div>
```

### Checkbox group manual

```razor
<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Permissões</label>
    <FieldCheckbox @bind-Value="model.PodeEditar" Label="Editar registros" />
    <FieldCheckbox @bind-Value="model.PodeExcluir" Label="Excluir registros" />
    <FieldCheckbox @bind-Value="model.PodeExportar" Label="Exportar dados" />
    <FieldCheckbox @bind-Value="model.PodeGerenciarUsuarios" Label="Gerenciar usuários" />
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
- `limitações`: sem RadioGroup ou CheckboxGroup dedicados; `FieldCheckbox` cobre apenas boolean; radio group e checkbox group visíveis requerem HTML nativo + CSS; segmented control via ButtonGroup tem visual de botão, não de radio;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `FieldCheckbox` cobre toggle binário; `ButtonGroup` + `Button Active` cobre segmented choice visual;
  - Para radio/checkbox group estilizado, HTML nativo com `accent-primary-500` é a via mais direta;
  - Nota 2 reflete ausência de componentes dedicados de grupo de escolha.
