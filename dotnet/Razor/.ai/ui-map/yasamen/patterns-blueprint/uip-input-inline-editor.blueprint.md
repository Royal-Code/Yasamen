# UIP-INPUT-INLINE_EDITOR - Blueprint

## Identificação
- **Pattern**: UIP-INPUT-INLINE_EDITOR - Inline Editor.
- **Nível final**: resumido.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_input.pattern.md`, samples de `TextField`, `ButtonGroup`, `Button`, `IconButton`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen fornece campo e botões, mas não define troca view/edit, commit, cancelamento, saving e erro local.

## Decisão arquitetural principal
Criar `[API proposta] InlineEditor` com modos `Display`, `Editing`, `Saving`, `Error`.

## Componentes reaproveitados
`TextField`, `ButtonGroup`, `Button`, `IconButton`, `Feedback`.

## Bloco principal de código

```razor
@* [API proposta] InlineEditor *@
@if (!Editing)
{
    <div class="flex items-center gap-3">
        <span class="text-dark-900">@Value</span>
        <IconButton Icon="BsIconNames.Pencil" Style="Themes.Secondary" OnClick="BeginEdit" />
    </div>
}
else
{
    <Stack AdditionalClasses="space-y-2">
        <TextField @bind-Value="Draft" Error="@Error" />
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ações de edição inline">
            <Button Label="Salvar" Style="Themes.Primary" OnClick="Commit" Disabled="@Saving" />
            <Button Label="Cancelar" Style="Themes.Light" OnClick="Cancel" Disabled="@Saving" />
        </ButtonGroup>
    </Stack>
}
```

## Exemplo principal de uso
Use em detail block, settings e células simples. Não usar para edição complexa com campos dependentes.

## Justificativa breve da cobertura proposta
O blueprint formaliza estados e mantém a edição local. A cobertura depende do app implementar commit/cancel corretamente.

## Limitações remanescentes
- Sem suporte nativo a Enter/Escape.
- Sem controle de conflito remoto.

## Pontos de adaptação
- Salvar no blur apenas quando o risco for baixo.
- Em mobile, sempre exibir botões explícitos.
