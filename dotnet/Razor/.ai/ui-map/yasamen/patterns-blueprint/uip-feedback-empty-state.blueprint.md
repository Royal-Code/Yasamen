# UIP-FEEDBACK-EMPTY_STATE - Blueprint

## Identificação
- **Pattern**: UIP-FEEDBACK-EMPTY_STATE - Empty State.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_feedback.pattern.md`, samples de `Feedback`, `Button`, `Icon`, `Box`, `visual.language.md` e `styles.map.md`.

## Gap resumido
`Feedback` mostra mensagem, mas falta composição centrada com título, descrição, ícone e CTA.

## Decisão arquitetural principal
Criar `[API proposta] EmptyState` como composição de `Box`, `Feedback` ou HTML simples com `Button`.

## Componentes reaproveitados
`Feedback`, `Button`, `Icon`, `Box`.

## Bloco principal de código

```razor
@* [API proposta] EmptyState *@
<Box AdditionalClasses="p-8 bg-white border border-light-300 rounded-md text-center">
    <Stack AdditionalClasses="space-y-4 items-center">
        <Icon Kind="BsIconNames.InfoCircle" AdditionalClasses="text-info-500" />
        <div>
            <h2 class="font-medium text-dark-900">@Title</h2>
            <p class="text-sm text-dark-500">@Description</p>
        </div>
        @if (Action is not null)
        {
            @Action
        }
    </Stack>
</Box>
```

## Exemplo principal de uso
Use para lista vazia, sem resultados de filtro ou painel de detalhe sem seleção.

## Justificativa breve da cobertura proposta
O padrão adiciona orientação e CTA ao feedback básico.

## Limitações remanescentes
- Ilustração não é fornecida.
- Ícone deve existir ou ser fornecido via fragment.

## Pontos de adaptação
- Distinguir "sem dados" de "erro".
- CTA deve apontar para próximo passo real.
