# Requirements — ButtonGroup

## Metadados

| Campo | Valor |
|---|---|
| Status | `Rascunho` |
| Prioridade | `P3` |
| Fase do plano | `F3.x (backlog estrutural de composição de ações)` |
| UI Pattern | `— (primitivo transversal; apoio direto a UIP-ACTION-ACTION_BAR)` |
| Roadmap | `R1 › Componentes básicos iniciais › ButtonGroup` |
| Pacote sugerido | `RoyalCode.Razor.Buttons` |
| Showcase inicial | `/demo/buttons/button-group` |
| Guides aplicados | `project-structure`, `styles-and-css`, `component-anatomy`, `showcases-and-docs`, `spec-execution-and-delivery`, `css-visual-contract`, `component-composition-and-dependencies`, `cross-cutting-component-decisions` |

## Objetivo

Entregar um componente-base para agrupar ações relacionadas com continuidade visual e semântica de grupo, reduzindo composições ad hoc com `div.flex`, CSS manual e ajustes locais sobre `Button` e `IconButton`.

## Contexto de Backlog

`ButtonGroup` aparece explicitamente como pendente em `.ai/roadmap/components-plan-list.md`, dentro dos componentes básicos iniciais de `R1`. Ao mesmo tempo, ele não aparece como frente ativa do `.ai/roadmap/ui-plan.md` nem como item isolado do `.ai/ui-map/ui-map.md`, porque não mapeia sozinho para um `UIP-*` canônico. A spec segue mesmo assim porque:

- é um primitivo estrutural já previsto no backlog histórico;
- o guide `component-composition-and-dependencies.md` cita `ButtonGroup` como componente-base futuro;
- ele reduz atrito em `Action Bar`, cabeçalhos operacionais, pares de ações e agrupamentos compactos de navegação local.

## Escopo

- `ButtonGroup` como componente público único.
- Orientação horizontal e vertical.
- Agrupamento visual de filhos diretos `Button` e `IconButton`.
- Herança opcional de `Style: Themes` e `Size: Sizes` a partir do grupo para filhos que permaneçam no valor default.
- Desabilitação em cascata a partir do grupo.
- Semântica acessível de grupo com nome acessível opcional.
- Showcase funcional no host atual de docs.
- Testes automatizados no projeto já existente `RoyalCode.Razor.Buttons.Tests`.

## Fora de Escopo

- Modelo de seleção controlada, toggle exclusivo ou comportamento de `segmented control`.
- Semântica completa de `toolbar` com roving tabindex.
- Overflow responsivo, quebra automática de linha ou colapso em dropdown.
- Suporte visual garantido para wrappers intermediários, filhos arbitrários ou componentes externos ao pacote.
- Parâmetro de grupo para `Outline`, porque a API atual de `Button` e `IconButton` não distingue com segurança “valor omitido” de “false explícito”.
- Migração completa das páginas legadas `/buttons` e `/icon-buttons`, embora a nova rota de showcase já deva seguir a taxonomia `/demo/...`.

## Casos de Uso

1. Agrupar ações complementares como `Salvar`, `Salvar e Continuar` e `Cancelar` em cabeçalhos operacionais.
2. Combinar `IconButton` e `Button` em ações compactas de lista, detalhe ou toolbar simples.
3. Exibir um conjunto vertical de ações em painel estreito, mantendo alinhamento, foco visível e desabilitação uniforme.

## Requisitos Funcionais

- `ButtonGroup` deve aceitar `ChildContent` com filhos diretos `Button` e `IconButton`.
- O componente deve aceitar `Orientation`, `Style`, `Size`, `Disabled`, `AriaLabel`, `AdditionalClasses` e `AdditionalAttributes`.
- O agrupamento visual deve funcionar sem CSS manual do consumidor quando os filhos diretos forem `Button` ou `IconButton`.
- Quando `Style` do grupo for diferente de `Themes.Default`, filhos `Button` e `IconButton` com `Style = Themes.Default` devem herdar esse tema como valor efetivo.
- O fallback de `Themes.Default` deve permanecer coerente com os componentes atuais: se o grupo não impuser tema, cada botão continua a cair no comportamento já existente, cujo fallback final é `Secondary`.
- Quando `Size` do grupo for diferente de `Sizes.Default`, filhos `Button` e `IconButton` com `Size = Sizes.Default` devem herdar esse tamanho como valor efetivo.
- O fallback de `Sizes.Default` deve permanecer coerente com os componentes atuais: se o grupo não impuser tamanho, cada botão continua com o baseline já existente, que hoje resulta em `Medium`.
- `Disabled = true` no grupo deve desabilitar todos os `Button` e `IconButton` filhos, independentemente do valor local deles.
- Um filho com `Style` ou `Size` explícito deve sobrescrever o default herdado do grupo.
- O componente deve expor `Style: Themes` no nível do grupo como default herdado, não como pintura própria do contêiner.
- O componente deve expor `Size: Sizes` no nível do grupo como default herdado, não como escala visual independente do contêiner.
- O componente deve ser classificado como primitivo base do domínio de ações, e não como composto derivado.
- A spec deve registrar explicitamente que não há componente-base ausente antes deste release; `ButtonGroup` é o próprio componente-base faltante do backlog.
- O contrato visual deve ser sustentado por classes públicas `ya-btn-group*` em `RoyalCode.Razor.Styles`, reutilizando os tokens já existentes de raio, borda, foco, espaçamento e cores semânticas herdadas dos próprios botões.
- O pacote alvo deve continuar sendo `RoyalCode.Razor.Buttons`; não há justificativa para criar `RoyalCode.Razor.ButtonGroups` neste fluxo.

## Acessibilidade e Responsividade

- O contêiner raiz deve expor `role="group"`.
- O componente deve aceitar nome acessível por `AriaLabel`; quando o grupo for composto apenas por botões de ícone, o showcase e a documentação devem recomendar explicitamente esse uso.
- A navegação por teclado deve permanecer a navegação normal por `Tab` entre os botões do grupo; não haverá roving tabindex no primeiro release.
- O foco visível dos botões agrupados não pode ser engolido pela sobreposição de bordas ou pela junção entre itens.
- Em largura reduzida, o componente não deve quebrar a geometria do grupo automaticamente; quando a composição horizontal deixar de ser adequada, o consumidor deve poder usar a orientação vertical.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`.
- Registrar a rota `/demo/buttons/button-group`.
- Adicionar item em `ConfigureMenu.cs`, preferencialmente sob um agrupamento `Buttons` alinhado à taxonomia nova de demos.
- Cobrir no showcase:
  - uso básico horizontal;
  - herança de `Style` e `Size`;
  - mistura de `Button` e `IconButton`;
  - orientação vertical;
  - estados ativos e desabilitados;
  - contêiner estreito e composição em action bar simples.

## Critérios de Aceite

- [ ] É possível declarar `ButtonGroup` com `Button` e `IconButton` filhos sem CSS adicional do consumidor.
- [ ] O agrupamento horizontal remove bordas e raios redundantes entre os itens.
- [ ] O agrupamento vertical mantém a mesma coerência visual em coluna.
- [ ] `Style` herdado do grupo afeta apenas filhos que permaneçam com `Themes.Default`.
- [ ] `Size` herdado do grupo afeta apenas filhos que permaneçam com `Sizes.Default`.
- [ ] `Disabled` no grupo desabilita todos os filhos suportados.
- [ ] O contrato visual usa classes públicas `ya-btn-group*`.
- [ ] Não é criado `*.razor.css` novo.
- [ ] Há showcase funcional em `RoyalCode.Razor.Docs.Client`.
- [ ] Há testes cobrindo agrupamento, herança de defaults, orientação vertical e mistura de `Button` com `IconButton`.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A implementação foi comparada com requirements, design e guides.
- [ ] O status final da spec foi atualizado com evidência.
