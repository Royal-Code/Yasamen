# UIP-FEEDBACK-ERROR_STATE - Blueprint

## Identificação
- **Pattern**: UIP-FEEDBACK-ERROR_STATE - Error State.
- **Nível final**: resumido.
- **Cobertura atual**: 6.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_feedback.pattern.md`, samples de `Feedback`, `Button`, `ButtonGroup`, `Box`, `FieldError`, `visual.language.md` e `styles.map.md`.

## Gap resumido
`Feedback` cobre mensagem de erro, mas falta composição de erro recuperável com retry, detalhe técnico opcional e escopo local/página.

## Decisão arquitetural principal
Criar `[API proposta] ErrorState` com `Title`, `Message`, `Details`, `RetryAction`, `Scope`.

## Componentes reaproveitados
`Feedback`, `Button`, `ButtonGroup`, `Box`, `FieldError` para campo.

## Bloco principal de código

```razor
@* [API proposta] ErrorState *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <Stack AdditionalClasses="space-y-4">
        <Feedback Style="Themes.Danger" Title="@Title" Text="@Message" Block="true" />
        @if (!string.IsNullOrWhiteSpace(Details))
        {
            <p class="text-sm text-dark-500">@Details</p>
        }
        <ButtonGroup AriaLabel="Recuperação do erro" Size="Sizes.Small">
            <Button Label="Tentar novamente" Style="Themes.Primary" OnClick="Retry" />
            <Button Label="Voltar" Style="Themes.Light" OnClick="Back" />
        </ButtonGroup>
    </Stack>
</Box>
```

## Exemplo principal de uso
Use quando carregamento, submissão ou recurso falhar. Para ausência sem falha, usar Empty State.

## Justificativa breve da cobertura proposta
O blueprint adiciona recuperação e escopo ao feedback de erro já forte.

## Limitações remanescentes
- Logging e correlação técnica dependem do app.
- No permission pode exigir padrão próprio.

## Pontos de adaptação
- Mensagem deve dizer o que aconteceu e próximo passo.
- `Danger` é erro; `Alert` é atenção operacional.
