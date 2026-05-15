# PP-WIZARD - Blueprint

## Identificação
- **Pattern**: PP-WIZARD.
- **Nível final**: completo.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Box`, `Badge`, `ButtonGroup`, `Button`, `TextField`, `Feedback`, `Container`, `Slot`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen compõe formulário e ações, mas não possui stepper nem orquestração de etapas. O blueprint propõe `[API proposta] WizardPage`, `[API proposta] StepperIndicator` e contratos de validação por etapa.

## Requisitos ainda não atendidos
- Indicador de etapas.
- Estado por etapa: pendente, atual, completo, erro.
- Navegação anterior/próximo/finalizar.
- Validação antes de avançar.
- Resumo final ou confirmação.

## Diagnóstico estruturado do gap
`Badge`, `ButtonGroup`, `Button`, `Feedback` e `TextField` cobrem visualmente partes do wizard. A biblioteca não coordena estado entre etapas, por isso a solução precisa de componente de aplicação.

## Justificativa detalhada da meta
A meta 8 vem da combinação de stepper proposto, formulário por etapa e action bar. Não chega a 9 porque a biblioteca não possui stepper oficial nem validação integrada.

## Estratégia de composição
- `Container` para limitar a largura do corpo.
- `StepperIndicator` proposto com `Badge` e classes `primary/success/danger`.
- `Box` para corpo da etapa.
- `ButtonGroup` para navegação.
- `Feedback` para erro de etapa.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] WizardPage`: Steps, CurrentStep, CanGoNext, OnNext, OnBack, OnFinish.
- `[API proposta] WizardStep`: Id, Title, IsValid, IsComplete, Content.
- `[API proposta] StepperIndicator`: renderização acessível do progresso.

## Aplicação objetiva da linguagem visual
Etapa atual usa `Primary`, concluída usa `Success`, erro usa `Danger`, pendente usa `Secondary/Light`. O corpo fica em `Box` branco com borda clara.

## Aplicação de estilos e tokens
Usar `space-y-6`, `p-6`, `rounded-md`. Em mobile, stepper deve compactar para "Etapa 2 de 4" antes de quebrar labels.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] WizardPage *@
<Stack AdditionalClasses="space-y-6">
    <StepperIndicator Steps="Steps" CurrentIndex="@CurrentIndex" />
    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
        @CurrentStep.Content
    </Box>
    <Bar>
        <Start>
            <Button Label="Voltar" Style="Themes.Light" Disabled="@(CurrentIndex == 0)" OnClick="Back" />
        </Start>
        <End>
            <ButtonGroup AriaLabel="Ações do wizard">
                <Button Label="Próximo" Style="Themes.Primary" OnClick="Next" />
                <Button Label="Finalizar" Style="Themes.Success" OnClick="Finish" />
            </ButtonGroup>
        </End>
    </Bar>
</Stack>
```

## Blocos principais de código

```razor
@* [API proposta] StepperIndicator *@
<ol class="flex flex-col md:flex-row gap-3">
    @foreach (var step in Steps)
    {
        <li class="flex items-center gap-3">
            <Badge Text="@step.Number" Style="@step.Theme" Size="Sizes.Small" />
            <span class="text-sm font-medium text-dark-800">@step.Title</span>
        </li>
    }
</ol>
```

## Estados e comportamento responsivo
- Desktop: stepper horizontal com labels.
- Mobile: stepper vertical curto ou resumo numérico.
- Erro: `Feedback Danger` no topo da etapa.
- Loading: desabilitar botões e exibir feedback local.
- Final: tela de confirmação com `Feedback Success`.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<WizardPage Steps="steps"
            CurrentIndex="@current"
            OnNext="ValidateAndNext"
            OnBack="Back"
            OnFinish="SubmitAsync" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Form | bom | por etapa |
| Stepper | ausente | proposto |
| Validação | manual | contrato por etapa |
| Responsividade | manual | regra compacta |

## Limitações remanescentes
- Validação real depende do app.
- Persistência parcial e recuperação de sessão ficam fora.
- Não há animação de transição nativa entre etapas.

## Pontos de adaptação
- Definir etapas e critérios de avanço.
- Decidir se finalizar exige modal de confirmação.
- Expor progresso de forma curta em telas pequenas.
