# UIP-INPUT-INPUT_FIELD - Blueprint resumido

## Pattern

UIP-INPUT-INPUT_FIELD — Input Field — ver `uip-input-input-field.ui-map.md`

## Gap coberto

`TextField` cobre texto e senha com anatomia completa. Os gaps são: tipos semânticos sem enum (`email`, `tel`, `url`), textarea e campos numéricos estilizados ausentes — requerem Blazor nativo sem estilo da lib.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `TextField` direto para texto/senha; `FieldText/FieldAction` nos slots para adornos; `<InputTextArea>/<InputNumber>` Blazor com classes Tailwind para tipos sem cobertura nativa.

## Componentes usados

- `TextField` — papel: principal — ver `field-text.sample.md`
- `FieldText` — papel: composição (prefixo/sufixo textual) — ver `field-text.sample.md`
- `FieldAction` — papel: composição (ação acoplada) — ver `field-text.sample.md`

## Recursos visuais

- `Type="InputType.Text"` — campo de texto padrão
- `Type="InputType.Password"` — campo de senha com máscara
- `ReadOnly=true` — campo somente leitura
- `Information="..."` — texto de ajuda abaixo do campo
- `w-full border border-light-300 rounded-md px-3 py-2 text-sm` — estilo manual para Blazor nativo

## Receita

`TextField` para texto/senha; slots para adornos; Blazor nativo para tipos especializados.

```razor
@* Campos básicos *@
<TextField @bind-Value="model.Nome" Label="Nome completo"
           Placeholder="Ex: João Silva" required />
<TextField @bind-Value="model.Email" Label="E-mail"
           Placeholder="usuario@dominio.com"
           Information="Usado para login" required />
<TextField @bind-Value="model.Senha" Type="InputType.Password" Label="Senha" required />

@* Campo com prefixo textual *@
<TextField @bind-Value="model.Site" Label="Site">
    <Prepend>
        <FieldText>https://</FieldText>
    </Prepend>
</TextField>

@* Campo com sufixo e ação acoplada *@
<TextField @bind-Value="model.Token" Label="Token de acesso" ReadOnly=true>
    <Append>
        <FieldText>Bearer</FieldText>
    </Append>
    <FooterAction>
        <FieldAction Label="Copiar" Icon="WellKnownIcons.Copy"
                     Style="Themes.Secondary" OnClick="CopiarToken" />
    </FooterAction>
</TextField>

@* Campo monetário com sufixo percentual *@
<TextField @bind-Value="model.Desconto" Label="Desconto">
    <Append>
        <FieldText>%</FieldText>
    </Append>
</TextField>

@* Textarea — Blazor nativo sem estilo da lib *@
<div class="flex flex-col gap-1">
    <label class="text-sm font-medium text-dark-600">Observações</label>
    <InputTextArea @bind-Value="model.Observacao" rows="4"
                   class="w-full border border-light-300 rounded-md px-3 py-2 text-sm
                          focus:outline-none focus:ring-2 focus:ring-primary-400" />
    <ValidationMessage For="() => model.Observacao" class="text-xs text-danger-600" />
</div>

@* Campo numérico — Blazor nativo sem estilo da lib *@
<div class="flex flex-col gap-1">
    <label class="text-sm font-medium text-dark-600">Quantidade</label>
    <InputNumber @bind-Value="model.Quantidade" min="0"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm
                        focus:outline-none focus:ring-2 focus:ring-primary-400" />
    <ValidationMessage For="() => model.Quantidade" class="text-xs text-danger-600" />
</div>
```

## Limites

- `InputType` enum tem apenas `Text` e `Password` — campos com tipo semântico `email`/`tel`/`url` requerem `<input type="email">` HTML nativo ou atributo via `AdditionalAttributes` (comportamento não garantido);
- Textarea e `InputNumber` não recebem estilo visual da lib — aparência diverge do `TextField`;
- Máscara de entrada (CPF, CNPJ, telefone) requer JS interop com biblioteca de máscara ou C# em `@oninput`.
