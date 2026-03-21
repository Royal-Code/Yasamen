# RoyalCode.Razor - Instruções de Repositório para Copilot

Este repositório é uma solução .NET de biblioteca de componentes Razor.

## Contexto base

- Use `.ai/ui-map/ui-map.md` como mapa de cobertura e lacunas.
- Use `.ai/roadmap/ui-plan.md` como fonte de fase, prioridade e sequência.
- Use `.ai/guides/` como referência normativa para estrutura, CSS, anatomia de componentes, showcases e execução de specs.
- Use `.ai/guides/expand/cross-cutting-component-decisions.md` como checklist curto para qualquer componente ou spec.
- Use `.ai/guides/rules/cross-cutting-app-decisions.md` como checklist curto para qualquer `app spec`.
- Use `.ai/guides/screens/planning-and-ui-mapping.md` para planeamento de telas e mapeamento `UIP -> Yasamen`.
- Use `.ai/guides/yasamen/consumer-app-conventions.md` para convenções de app consumidor.
- Use `.ai/templates/apps/spec/` como base para novas app specs.
- Use `.ai/templates/lib/spec/` como base para novas library specs.
- Use `.ai/templates/screens/spec/` como base para novas screen specs.

## Regras de trabalho

- Em documentação e specs, use sempre acentuação.
- Preserve a separação entre `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.
- Não copie templates sem adaptação.
- Preserve mudanças existentes do utilizador; não sobrescreva trabalho alheio sem necessidade.

## Componentes e CSS

- Novos componentes devem seguir a estrutura e os namespaces definidos nos guides.
- Prefira CSS público em `RoyalCode.Razor.Styles/wwwroot/css/components/` com import em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Trate `*.razor.css` em pacotes da biblioteca como legado ou exceção justificada, não como padrão a expandir.
- Para qualquer componente novo, avalie explicitamente `Style: Themes` e `Size: Sizes`; se um deles não se aplicar, justifique no design.
- Quando `Style` existir, registre o fallback de `Themes.Default`.
- Use os tokens de `RoyalCode.Razor.Styles/wwwroot/yasamen.css` para cores, espaçamento, tipografia e breakpoints antes de inventar valores novos.
- Para componentes de formulário ainda pouco definidos, use `form-components.md` junto com `form-components-lightweight.md`.
- Para qualquer componente novo, use também `component-composition-and-dependencies.md` e `cross-cutting-component-decisions.md`.
- Avalie explicitamente se ele é primitivo base, composto ou se depende de outro componente-base ainda ausente.
- Se o design concluir que o componente precisa de pacote novo, siga `.ai/instructions/expand/create-library-project.md` durante a implementação.

## Showcase e documentação

- O host atual de showcase é `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client`.
- Não trate `RoyalCode.Razor.Show` como host operacional atual.
- Quando a tarefa envolver showcase, siga `.ai/guides/expand/showcases-and-docs.md`.
- Para trabalho direto em showcases e páginas de documentação, prefira o agente `yasamen`.

## Fluxo de specs

- Para escolher o próximo alvo, consulte as specs existentes em `.ai/specs/` antes de sugerir criar algo novo.
- Para criar ou refinar specs, mantenha rastreabilidade com `ui-map.md`, `components-plan-list.md`, `ui-plan.md` e os guides aplicados.
- Para implementar uma spec, feche também `delivery.md` e `tasks.md`, e atualize `ui-map.md` ou `ui-plan.md` quando a cobertura ou o roadmap mudarem.
- Para revisão crítica de implementação, bugs, regressões e aderência à spec, prefira o agente `yasamen`.
- Para pedido de pacote ou projeto novo da biblioteca, preserve o padrão `spec-first`; via `station`, encaminhe para `lib-spec`; use `create-library-project.md` diretamente apenas para scaffolding explícito.

## Fluxo de telas

- Para planejar telas, use `.ai/screen-spec.md` como orquestrador próprio.
- Em telas, preserve a cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP`.
- Use `.ai/ui-map/catalogo-ui.md` como base agnóstica e `.ai/ui-map/ui-map.md` como mapeamento para Yasamen.
- Feche os checkpoints de `.ai/guides/rules/cross-cutting-screen-decisions.md` em qualquer fluxo de tela.
- Para planeamento, criação ou refinamento de `screen specs`, prefira o agente `screen-spec`.

## Fluxo de apps consumidores

- Para planejar um app consumidor, use `.ai/app-spec.md` como orquestrador próprio.
- Em app consumidor, feche primeiro shell, navegação, convenções locais e consumo de Yasamen antes de multiplicar telas.
- Quando o pedido envolver app novo, a `app spec` deve cobrir também estrutura de projetos, integração à solution, referências, `Program.cs`, `_Imports.razor` e estilos públicos.
- Quando o pedido for apenas criar o projeto ou a base do app, opere no nível `fundação do app` e não force detalhamento funcional.
- Nesse caso, não crie a `app spec` sem confirmar nome canônico, interpretação exata do host quando ambígua e arquétipo de shell.
- Em apps corporativos ou administrativos, a `app spec` deve decidir explicitamente estratégia inicial de dados, autenticação e integrações apenas quando esse detalhe já fizer parte do pedido.
- Ao criar uma `app spec`, distinguir o que é referência base confirmada do que é referência candidata.
- Ao criar uma `app spec`, não marque `tasks.md` por reflexo e não confunda completude da spec com implementação do app.
- Ao pedir informação em `app-spec`, prefira linguagem de domínio do utilizador e evite ancorar a conversa em exemplos de famílias de componentes do repositório.
- Para planeamento, criação ou refinamento de `app specs`, prefira o agente `app-spec`.
- Após criação ou refinamento de qualquer spec, executar uma revisão de spec por `spec-review` quando essa capacidade estiver disponível.
- A resposta final de criação ou refinamento de spec deve sempre recomendar explicitamente o próximo fluxo: `refine`, `implement`, `screen-spec`, `yasamen` ou equivalente.

## Agentes preferenciais

- `spec-station`: entrada portátil e roteamento para `app-spec`, `screen-spec`, `yasamen` ou encaminhamento para `lib-spec`.
- `lib-spec`: domínio de componentes, pacotes e specs de biblioteca.
- `app-spec`: domínio de apps consumidores que usam Yasamen.
- `screen-spec`: domínio de telas e `screen specs`.
- `spec-review`: revisão crítica de specs recém-criadas ou refinadas.
- `yasamen`: execução direta no repositório sem criar spec nova por padrão.



