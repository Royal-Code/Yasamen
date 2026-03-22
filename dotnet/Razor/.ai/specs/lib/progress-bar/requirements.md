# Requirements — ProgressBar

## Metadados

| Campo | Valor |
|---|---|
| Status | `Aprovada` |
| Prioridade | `P3` |
| Fase do plano | `Backlog histórico sem fase ativa no ui-plan atual` |
| UI Pattern | `UIP-FEEDBACK-LOADING_STATE` *(apoio parcial; não é `Stepper`)* |
| Roadmap | `R1 › Componentes Diversos › ProgressBar` |
| Pacote sugerido | `RoyalCode.Razor.Alerts` |
| Showcase inicial | `/demo/feedback/progress-bar` |
| Guides aplicados | `project-structure`, `styles-and-css`, `component-anatomy`, `showcases-and-docs`, `spec-execution-and-delivery`, `cross-cutting-component-decisions`, `component-composition-and-dependencies`, `css-visual-contract`, `animations` |

## Objetivo

Entregar um componente semântico de barra de progresso para feedback de operações em curso, cobrindo o caso de progresso mensurável e o caso indeterminado com animação contínua. O componente deve reforçar `Loading State` sem tentar substituir `Skeleton`, `Spinner` ou `Stepper`.

Observação de backlog:

- o item existe no roadmap histórico em `components-plan-list.md`;
- ele não aparece como frente explícita no `ui-plan.md` atual;
- a spec segue mesmo assim porque houve pedido direto do utilizador e o componente cobre uma lacuna real de feedback reutilizável.

## Escopo

- `ProgressBar` como componente público único.
- Modo determinado com valor real (`Value`, `Min`, `Max`).
- Modo indeterminado para operações sem percentagem conhecida.
- Texto opcional de rótulo e texto opcional de valor.
- Variação visual por `Style: Themes`.
- Variação dimensional por `Size: Sizes`.
- Opção de animação contínua com dois tipos:
  - `BarberPole` — zebrado diagonal em movimento contínuo;
  - `PingPong` — brilho/degradê suave que vai do início ao fim e retorna.
- Responsividade, acessibilidade e showcase no `RoyalCode.Razor.Docs.Client`.
- Avaliação explícita de composição, dependências, CSS público e tokens de `yasamen.css`.

## Fora de Escopo

- `ProgressCircle` ou qualquer indicador circular.
- `Stepper`, fluxo multi-etapas ou qualquer semântica de navegação de wizard.
- Barra vertical no primeiro release.
- Buffer, segmento secundário ou modo “streaming” com duas barras simultâneas.
- Integração automática com upload, HTTP, SignalR ou fila de background.
- Substituir `Skeleton`, `RotationMotion` ou overlays completos de loading.
- Slots ricos de cabeçalho ou conteúdo interno no primeiro release.

## Casos de Uso

1. Exibir progresso numérico de upload, importação, processamento ou sincronização.
2. Exibir operação em curso sem percentagem conhecida, com movimento contínuo perceptível.
3. Exibir barra compacta em painel, formulário, notificação ou contêiner estreito sem quebrar o layout.

## Requisitos Funcionais

- O componente público deve se chamar `ProgressBar`.
- A API mínima deve expor:
  - `double Value`
  - `double Min = 0`
  - `double Max = 100`
  - `bool Indeterminate`
  - `Themes Style = Themes.Default`
  - `Sizes Size = Sizes.Default`
  - `string? Label`
  - `bool ShowValue`
  - `string? ValueText`
  - `string? AriaLabel`
  - `ProgressBarAnimation Animation = ProgressBarAnimation.None`
  - `string? AdditionalClasses`
  - `Dictionary<string, object>? AdditionalAttributes`
- Quando `Indeterminate = true`, o componente deve ignorar o preenchimento real derivado de `Value`, `Min` e `Max`.
- Quando `Indeterminate = false`, o preenchimento deve ser calculado a partir de `Value`, `Min` e `Max`, com `Value` limitado ao intervalo efetivo.
- Quando `Max <= Min`, o componente deve usar um fallback interno previsível (`0..100`) para evitar renderização quebrada.
- Quando `ShowValue = true` e `ValueText` não for informado, o componente deve renderizar percentagem formatada a partir do valor efetivo.
- `ValueText`, quando informado, deve ter precedência sobre a formatação automática.
- Em modo indeterminado, `ShowValue` só deve produzir texto quando `ValueText` for informado explicitamente.
- `Animation` deve ser opcional e suportar, no mínimo:
  - `None`
  - `BarberPole`
  - `PingPong`
- Em modo determinado, a animação deve atuar apenas como overlay visual e não pode esconder a largura real preenchida.
- Em modo indeterminado, a animação pode dominar a percepção do movimento da barra.
- O componente deve suportar `Style: Themes`, com fallback explícito de `Themes.Default` para `Themes.Primary`.
- O componente deve suportar `Size: Sizes`, afetando espessura da barra, raio, tipografia auxiliar e densidade do cabeçalho.
- O componente deve aceitar `AdditionalClasses` e `AdditionalAttributes`.
- O componente deve ser tratado como primitivo base de feedback linear, sem depender de um componente-base novo antes dele.
- O pacote sugerido deve permanecer em `RoyalCode.Razor.Alerts`; a spec não pede projeto novo.
- O desenho deve usar tokens de `yasamen.css` para cores, espaçamentos, tipografia, raio e tempo de transição.

## Acessibilidade e Responsividade

- O elemento que representa o estado de progresso deve usar `role="progressbar"`.
- Em modo determinado, deve expor `aria-valuemin`, `aria-valuemax` e `aria-valuenow`.
- Em modo indeterminado, `aria-valuenow` não deve ser renderizado.
- O componente deve aceitar nome acessível por `Label` visível ou `AriaLabel`.
- O componente é apenas informativo; não deve entrar na ordem de tabulação nem exigir interação por teclado.
- O cabeçalho com rótulo e valor deve se reorganizar sem quebra visual em larguras reduzidas.
- As animações devem respeitar `prefers-reduced-motion`, com redução ou desativação adequada do movimento.
- O contraste entre trilha, preenchimento e texto auxiliar deve permanecer legível nos temas claros e escuros.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/ProgressBarPage.razor`.
- Registrar a rota `/demo/feedback/progress-bar`.
- Adicionar item em `ConfigureMenu.cs` dentro do grupo `Feedback`.
- Cobrir no showcase:
  - uso básico determinado;
  - uso com rótulo e valor automático;
  - modo indeterminado;
  - animação `BarberPole`;
  - animação `PingPong`;
  - variações de tema e tamanho;
  - contêiner estreito para leitura em largura reduzida;
  - composição em cenário de operação longa sem usar API interna.

## Critérios de Aceite

- [ ] O componente cobre progresso determinado e indeterminado sem ambiguidade semântica.
- [ ] O componente não é desenhado como substituto de `Stepper`.
- [ ] As animações `BarberPole` e `PingPong` estão previstas e documentadas.
- [ ] O modo determinado mantém a largura real visível mesmo quando animado.
- [ ] O modo indeterminado funciona sem `aria-valuenow`.
- [ ] O fallback de `Themes.Default` foi decidido e documentado.
- [ ] A decisão sobre `Size: Sizes` foi tomada e documentada.
- [ ] O CSS público usa classes `ya-progress-bar*` em `RoyalCode.Razor.Styles`.
- [ ] Não é criado `*.razor.css` novo.
- [ ] Há showcase em `RoyalCode.Razor.Docs.Client` com rota e menu definidos.
- [ ] Há previsão de testes e validação humana para as animações e a leitura visual.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A implementação foi comparada com requirements, design e guides.
- [ ] O aceite humano foi registrado para os cenários visuais previstos.
- [ ] O status final da spec foi atualizado de forma coerente.
