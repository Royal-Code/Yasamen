# SHP-KIOSK_EMBEDDED - Blueprint

## Identificação
- **Pattern**: SHP-KIOSK_EMBEDDED - Kiosk/Embedded.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `Button`, `IconButton`, `Feedback`, `Container`, `Slot`, `Box`, `Modal`, `Badge`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen possui botões, feedback, modal e layout suficientes para fluxos de foco único, mas não define shell full-screen, toque, sessão efêmera ou navegação restrita. O blueprint propõe um shell de kiosk com tela dedicada, ações grandes, progresso simples e estados de assistência.

## Requisitos ainda não atendidos
- Full-screen com navegação mínima.
- Ações grandes e legíveis para touch.
- Fluxo curto com progresso claro.
- Timeout/sessão efêmera.
- Estados de assistência, erro e confirmação.

## Diagnóstico estruturado do gap
`Button` com `Sizes.Large/Larger`, `Feedback`, `Modal` e `Container` resolvem interação básica. Não há contrato de sessão, timeout, periféricos ou modo touch, então a proposta fica na camada visual e estrutural.

## Justificativa detalhada da meta
A meta 8 é possível para UI de kiosk simples porque Yasamen já tem gramática operacional clara e feedback forte. A meta não cobre hardware, leitor, impressora, câmera ou segurança da sessão.

## Estratégia de composição
- Layout próprio full-screen com `bg-light-100`.
- `Container` e `Slot` para centralizar tarefa.
- `Button` grande com `Themes.Primary` para ação dominante.
- `Feedback` para instrução e erro.
- `Modal` para confirmação ou ajuda assistida.
- `Badge` para etapa ou status.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] KioskShell`: Header, Main, Footer, SessionStatus, Timeout.
- `[API proposta] KioskStep`: title, instruction, content, primaryAction, secondaryAction.
- `[API proposta] KioskTimeoutBanner`: remaining time, onExtend, onCancel.

## Aplicação objetiva da linguagem visual
Usar contraste claro, texto `dark-900`, CTA `Primary`, erro `Danger`, sucesso `Success`. Evitar menus profundos, icon-only sem rótulo e densidade administrativa.

## Aplicação de estilos e tokens
Usar `p-8`, `gap-6`, `rounded-md`, bordas leves. Para touch, aumentar `Sizes.Large` ou `Sizes.Larger`; não depender de hover como único feedback.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] KioskShell *@
<div class="min-h-screen bg-light-100 text-dark-900 flex flex-col">
    <header class="bg-white border-b border-light-300 p-6">
        <Bar>
            <Start><strong>@Title</strong></Start>
            <End><Badge Text="@StepLabel" Style="Themes.Info" Size="Sizes.Large" /></End>
        </Bar>
    </header>

    <main class="flex-1 grid place-items-center p-8">
        <Box AdditionalClasses="w-full max-w-3xl p-8 bg-white border border-light-300 rounded-md space-y-8">
            @ChildContent
        </Box>
    </main>

    <footer class="bg-white border-t border-light-300 p-6">
        @Footer
    </footer>
</div>
```

## Blocos principais de código

```razor
@* [API proposta] passo de kiosk *@
<Stack AdditionalClasses="space-y-8 text-center">
    <div class="space-y-3">
        <h1 class="text-3xl font-medium text-dark-900">@Heading</h1>
        <p class="text-lg text-dark-600">@Instruction</p>
    </div>

    @if (!string.IsNullOrWhiteSpace(Error))
    {
        <Feedback Style="Themes.Danger" Title="Não foi possível continuar" Text="@Error" Block="true" />
    }

    <ButtonGroup Orientation="ButtonGroupOrientation.Vertical" AriaLabel="Ações da etapa" Size="Sizes.Large">
        <Button Label="@PrimaryLabel" Style="Themes.Primary" Block="true" OnClick="Continue" />
        <Button Label="Voltar" Style="Themes.Light" Block="true" OnClick="Back" />
    </ButtonGroup>
</Stack>
```

## Estados e comportamento responsivo
- Full-screen: nenhuma sidebar persistente.
- Touch: botões grandes e labels visíveis.
- Timeout: banner com `Warning` e ação de estender sessão.
- Erro de periférico: `Feedback Danger` com instrução curta.
- Sucesso: `Feedback Success` e reset controlado da sessão.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<KioskShell Title="Autoatendimento" StepLabel="2 de 4">
    <KioskStep Heading="Confirme seus dados"
               Instruction="Revise as informações antes de continuar."
               PrimaryLabel="Confirmar"
               OnContinue="Confirm" />
</KioskShell>
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Botões grandes | possível | regra de touch |
| Shell full-screen | ausente | `KioskShell` proposto |
| Progresso | manual | badge/step proposto |
| Timeout | ausente | banner proposto |
| Hardware | ausente | fora do escopo |

## Limitações remanescentes
- Integração com hardware e timeout real dependem do app.
- Acessibilidade para dispositivos físicos exige teste local.
- Não há modo offline nativo.

## Pontos de adaptação
- Definir tempo de sessão e reset.
- Mapear estados de periféricos.
- Ajustar labels e tamanhos conforme distância de leitura.
