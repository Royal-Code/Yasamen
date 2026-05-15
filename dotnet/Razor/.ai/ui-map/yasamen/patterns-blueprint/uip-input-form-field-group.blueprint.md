# UIP-INPUT-FORM_FIELD_GROUP - Blueprint

## Identificação
- **Pattern**: UIP-INPUT-FORM_FIELD_GROUP - Form Field Group.
- **Nível final**: resumido.
- **Cobertura atual**: 7.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_input.pattern.md`, samples de `TextField`, `FieldText`, `FieldBadge`, `FieldAction`, `FieldGroup`, `Container`, `Slot`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen cobre campos textuais e validação inline, mas falta uma seção de campos com título, ajuda, erro agregado e layout responsivo padronizado.

## Decisão arquitetural principal
Criar `[API proposta] FormFieldSection` como composição de `Box`, `Container`, `Slot`, `TextField` e `Feedback`.

## Componentes reaproveitados
`TextField`, `FieldText`, `FieldBadge`, `FieldAction`, `FieldGroup`, `Container`, `Slot`, `Feedback`.

## Bloco principal de código

```razor
@* [API proposta] FormFieldSection *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <div>
        <h2 class="font-medium text-dark-900">@Title</h2>
        <p class="text-sm text-dark-500">@Description</p>
    </div>
    @if (!string.IsNullOrWhiteSpace(Error))
    {
        <Feedback Style="Themes.Danger" Text="@Error" Block="true" />
    }
    <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default">
        @ChildContent
    </Container>
</Box>
```

## Exemplo principal de uso

```razor
@* [API proposta] *@
<FormFieldSection Title="Contato">
    <Slot Span="4" LaptopSpan="6"><TextField Label="Nome" @bind-Value="model.Name" /></Slot>
    <Slot Span="4" LaptopSpan="6"><TextField Label="E-mail" @bind-Value="model.Email" Error="@emailError" /></Slot>
</FormFieldSection>
```

## Justificativa breve da cobertura proposta
A seção formaliza o agrupamento e preserva a força dos componentes de campo. Controles ausentes continuam como lacuna.

## Limitações remanescentes
- Select, checkbox, radio e textarea não são cobertos.
- Validação agregada depende do app.

## Pontos de adaptação
- Usar uma seção por responsabilidade lógica.
- Preservar validação inline abaixo do campo.
