# UIP-INPUT-CHOICE_GROUP - Blueprint resumido

## Pattern

UIP-INPUT-CHOICE_GROUP — Choice Group — ver `uip-input-choice-group.ui-map.md`

## Gap coberto

A lib não tem `FieldCheckbox`, `RadioGroup` ou `CheckboxGroup`. O gap é orientar quatro variantes: toggle binário, segmented control visual (2-4 opções), radio group, e checkbox group — combinando `ButtonGroup` e HTML nativo.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: segmented control com `ButtonGroup + Button(Active)`; toggle/radio/checkbox com HTML nativo `<InputCheckbox>`/`<input type="radio/checkbox">` + `accent-primary-500`.

## Componentes usados

- `ButtonGroup` — papel: principal (segmented choice) — ver `button.sample.md`
- `Button` — papel: composição (opção visível) — ver `button.sample.md`

## Recursos visuais

- `accent-primary-500` — coloração nativa do checkbox/radio com cor do design system
- `Active="@(valor==opcao)"` — estado ativo no ButtonGroup
- `Outline="@(valor!=opcao)"` — estado não selecionado no ButtonGroup
- `flex items-center gap-2` — alinhamento de input + label

## Receita

Quatro variantes por caso de uso; `ButtonGroup` para visibilidade; HTML nativo para semântica de formulário.

```razor
@* Toggle binário (Blazor InputCheckbox) *@
<div class="flex flex-col gap-2 mb-4">
    <div class="flex items-center gap-2">
        <InputCheckbox @bind-Value="model.Ativo" id="cb-ativo"
                       class="accent-primary-500 w-4 h-4" />
        <label for="cb-ativo" class="text-sm text-dark-600 cursor-pointer">
            Usuário ativo
        </label>
    </div>
    <div class="flex items-center gap-2">
        <InputCheckbox @bind-Value="model.Notificacoes" id="cb-notif"
                       class="accent-primary-500 w-4 h-4" />
        <label for="cb-notif" class="text-sm text-dark-600 cursor-pointer">
            Receber notificações por e-mail
        </label>
    </div>
</div>

@* Segmented choice (seleção única visual — não semântica) *@
@code { private string plano = "basico"; }

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
                Active="@(plano=="ent")" Outline="@(plano!="ent")"
                OnClick='() => plano = "ent"' />
    </ButtonGroup>
</div>

@* Radio group HTML nativo *@
<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Tipo de conta</label>
    @foreach (var tipo in new[] { ("pf", "Pessoa Física"), ("pj", "Pessoa Jurídica") })
    {
        <label class="flex items-center gap-2 cursor-pointer">
            <input type="radio" name="tipoConta" value="@tipo.Item1"
                   checked="@(model.TipoConta == tipo.Item1)"
                   @onchange="() => model.TipoConta = tipo.Item1"
                   class="accent-primary-500 w-4 h-4" />
            <span class="text-sm text-dark-600">@tipo.Item2</span>
        </label>
    }
</div>

@* Checkbox group HTML nativo *@
<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Permissões</label>
    <div class="flex items-center gap-2">
        <input type="checkbox" id="perm-edit" @bind="model.PodeEditar"
               class="accent-primary-500 w-4 h-4" />
        <label for="perm-edit" class="text-sm text-dark-600 cursor-pointer">
            Editar registros
        </label>
    </div>
    <div class="flex items-center gap-2">
        <input type="checkbox" id="perm-del" @bind="model.PodeExcluir"
               class="accent-primary-500 w-4 h-4" />
        <label for="perm-del" class="text-sm text-dark-600 cursor-pointer">
            Excluir registros
        </label>
    </div>
</div>
```

## Limites

- `ButtonGroup` como segmented control não tem semântica de form field (`name`, `value`, `required`) — não integra diretamente com `EditForm`/`DataAnnotationsValidator`;
- Sem componente de toggle switch estilizado (pill on/off) — `<InputCheckbox>` não gera esse visual;
- Sem `FieldCheckbox` com label integrado e estilização da lib.
