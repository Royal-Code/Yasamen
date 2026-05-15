# UIP-FEEDBACK-CONFIRMATION_DIALOG - Blueprint

## Identificação
- **Pattern**: UIP-FEEDBACK-CONFIRMATION_DIALOG - Confirmation Dialog.
- **Nível final**: resumido.
- **Cobertura atual**: 7.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_feedback.pattern.md`, samples de `Modal`, `ButtonGroup`, `Button`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
`Modal` e botões cobrem a base, mas falta contrato de confirmação, ação destrutiva, estado processando e mensagem de impacto.

## Decisão arquitetural principal
Criar `[API proposta] ConfirmationDialog` sobre `Modal`, com `Title`, `Message`, `ConfirmLabel`, `ConfirmTheme`, `OnConfirm`, `Processing`.

## Componentes reaproveitados
`Modal`, `ButtonGroup`, `Button`, `Feedback`.

## Bloco principal de código

```razor
@* [API proposta] ConfirmationDialog *@
<Modal Id="@Id" Handler="Handler" Center="true" Closeable="@(!Processing)">
    <Box AdditionalClasses="p-6 bg-white rounded-md space-y-5">
        <div>
            <h2 class="font-medium text-dark-900">@Title</h2>
            <p class="text-sm text-dark-600">@Message</p>
        </div>
        @if (!string.IsNullOrWhiteSpace(Warning))
        {
            <Feedback Style="Themes.Warning" Text="@Warning" Block="true" />
        }
        <ButtonGroup AriaLabel="Confirmação">
            <Button Label="@ConfirmLabel" Style="@ConfirmTheme" Disabled="@Processing" OnClick="Confirm" />
            <Button Label="Cancelar" Style="Themes.Light" Disabled="@Processing" OnClick="Cancel" />
        </ButtonGroup>
    </Box>
</Modal>
```

## Exemplo principal de uso
Use para excluir, cancelar processo, sair com alterações ou ação irreversível.

## Justificativa breve da cobertura proposta
O modal já é forte; o blueprint só padroniza conteúdo, risco e estado assíncrono.

## Limitações remanescentes
- Focus trap e acessibilidade dependem do comportamento real do `Modal`.
- Handler e serviço de modal precisam ser configurados pelo app.

## Pontos de adaptação
- Usar `Themes.Danger` para ação destrutiva.
- Não usar confirmação para ação reversível comum.
