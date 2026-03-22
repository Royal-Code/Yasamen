# Tasks — ProgressBar

## Preparação

- [ ] Validar a spec com `ui-plan.md`, `ui-map.md` e `components-plan-list.md`.
- [ ] Registrar na implementação que o item está no roadmap histórico, mas não na fase ativa do `ui-plan`.
- [ ] Confirmar `RoyalCode.Razor.Alerts` como pacote alvo.
- [ ] Confirmar que não é necessário criar `ProgressIndicatorBase` ou pacote novo antes do primeiro release.
- [ ] Confirmar CSS público e nomes de classes `ya-progress-bar*`.
- [ ] Confirmar fallback de `Themes.Default -> Themes.Primary`.
- [ ] Confirmar suporte a `Size: Sizes` e o impacto de cada faixa no componente.
- [ ] Confirmar os tokens de `yasamen.css` que sustentarão trilha, preenchimento, tipografia e motion.

## Implementação

- [ ] Criar `ProgressBar.razor` e `ProgressBar.razor.cs`.
- [ ] Criar `ProgressBarAnimation.cs`.
- [ ] Implementar cálculo normalizado de percentagem e clamp de valores.
- [ ] Implementar modo determinado e modo indeterminado.
- [ ] Implementar `Label`, `ShowValue`, `ValueText` e `AriaLabel`.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes`.
- [ ] Garantir que `Animation` se comporte como overlay no determinado e como motion dominante no indeterminado.

## Estilos

- [ ] Criar `progress-bar.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [ ] Registrar o `@import` no `yasamen.css`.
- [ ] Cobrir classes raiz, cabeçalho, trilha, preenchimento e estados públicos.
- [ ] Cobrir variações de tema.
- [ ] Cobrir variações de tamanho.
- [ ] Implementar `BarberPole` e `PingPong` com tokens do design system.
- [ ] Cobrir `prefers-reduced-motion`.

## Testes

- [ ] Criar ou atualizar testes automatizados para o domínio de `Alerts`.
- [ ] Testar progresso determinado com valor válido.
- [ ] Testar clamp acima e abaixo do intervalo.
- [ ] Testar fallback quando `Max <= Min`.
- [ ] Testar ausência de `aria-valuenow` no modo indeterminado.
- [ ] Testar `ShowValue` e `ValueText`.
- [ ] Testar classes de tema, tamanho e animação.

## Validação Humana

- [ ] Validar visualmente `BarberPole` em operação contínua.
- [ ] Validar visualmente `PingPong` em operação contínua.
- [ ] Validar leitura do componente em largura reduzida.
- [ ] Registrar em `delivery.md` o aceite humano explícito; sem isso, a spec fica em `Aguardando validação humana`.

## Documentação

- [ ] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/ProgressBarPage.razor`.
- [ ] Registrar o item `/demo/feedback/progress-bar` em `ConfigureMenu.cs`.
- [ ] Cobrir uso básico, temas, tamanhos, determinado, indeterminado e animações.
- [ ] Demonstrar o componente em contêiner estreito.
- [ ] Atualizar `ui-map.md` se a entrega mudar a cobertura de `Loading State`.
- [ ] Atualizar `ui-plan.md` apenas se a implementação justificar nova frente explícita.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validações manuais previstos.
- [ ] Fazer revisão crítica do diff final.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
- [ ] Fechar ou justificar tasks remanescentes.
