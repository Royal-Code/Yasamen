# UIP-NAV-STEPPER_INDICATOR - Blueprint

## Identificação
- **Pattern**: UIP-NAV-STEPPER_INDICATOR - Stepper Indicator.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_nav.pattern.md`, samples de `Badge`, `ButtonGroup`, `Button`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não possui stepper, mas `Badge`, `ButtonGroup` e estilos semânticos permitem construir um indicador de progresso. O blueprint propõe `StepperIndicator` para uso com wizard.

## Requisitos ainda não atendidos
- Etapa atual, futura, concluída e com erro.
- Label e número da etapa.
- Compactação mobile.
- Comunicação com validação do wizard.
- Estado processing/loading.

## Diagnóstico estruturado do gap
`Badge` fornece pílula semântica; `ButtonGroup` agrupa ações, mas não serve como stepper completo. Falta contrato de etapas e semântica visual.

## Justificativa detalhada da meta
O stepper proposto atinge 8 como componente de aplicação. Acessibilidade e navegação por teclado devem ser implementadas junto ao wizard.

## Estratégia de composição
- `Badge` para número/estado.
- Texto curto para label.
- Linha ou gap como separador visual com `border-light-300`.
- Mobile: resumo "Etapa X de N" e lista compacta opcional.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] StepperIndicator`: Steps, CurrentIndex, Orientation, Compact.
- `[API proposta] StepState`: Pending, Current, Complete, Error, Disabled.

## Aplicação objetiva da linguagem visual
Atual: `Themes.Primary`; concluída: `Themes.Success`; erro: `Themes.Danger`; futura: `Themes.Secondary` ou `Light`.

## Aplicação de estilos e tokens
Usar `gap-3`, `text-sm`, `border-light-300`; não usar cores fortes em toda a linha.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] StepperIndicator *@
<ol class="hidden md:flex items-center gap-4">
    @foreach (var step in Steps)
    {
        <li class="flex items-center gap-3">
            <Badge Text="@step.Number" Style="@step.Theme" Size="Sizes.Small" />
            <span class="text-sm font-medium text-dark-800">@step.Label</span>
        </li>
    }
</ol>
<div class="md:hidden">
    <Badge Text="@($"Etapa {CurrentIndex + 1} de {Steps.Count}")" Style="Themes.Primary" />
</div>
```

## Blocos principais de código

```razor
@* [API proposta] definição de tema *@
private Themes ThemeFor(StepState state) => state switch
{
    StepState.Current => Themes.Primary,
    StepState.Complete => Themes.Success,
    StepState.Error => Themes.Danger,
    _ => Themes.Secondary
};
```

## Estados e comportamento responsivo
- Desktop: etapas nomeadas.
- Mobile: resumo compacto e, se necessário, lista vertical.
- Error: etapa com `Danger`.
- Loading: etapa atual com texto "Processando" e ações desabilitadas.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<StepperIndicator Steps="wizardSteps" CurrentIndex="@currentStep" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Número/label | manual | contrato |
| Estados | ausentes | definidos |
| Mobile | ausente | compacto |
| Integração wizard | ausente | prevista |

## Limitações remanescentes
- Não executa validação.
- Não substitui navegação do wizard.

## Pontos de adaptação
- Mapear etapa com erro a partir da validação.
- Definir se etapas concluídas podem ser clicáveis.
