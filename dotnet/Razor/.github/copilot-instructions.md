# RoyalCode.Razor - Instruções de Repositório para Copilot

Este repositório é uma solução .NET de biblioteca de componentes Razor.

## Contexto base

- Use `.ai/ui-map/ui-map.md` como mapa de cobertura e lacunas.
- Use `.ai/roadmap/ui-plan.md` como fonte de fase, prioridade e sequência.
- Use `.ai/guides/` como referência normativa para estrutura, CSS, anatomia de componentes, showcases e execução de specs.
- Use `.ai/guides/rules/cross-cutting-component-decisions.md` como checklist curto para qualquer componente ou spec.
- Use `.ai/guides/screens/planning-and-ui-mapping.md` para planeamento de telas e mapeamento `UIP -> Yasamen`.
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
- Para pedido de pacote ou projeto novo via `station` ou `lib-spec`, preserve o padrão `spec-first`; use `create-library-project.md` diretamente apenas para scaffolding explícito.

## Fluxo de telas

- Para planejar telas, use `.ai/screen-spec.md` como orquestrador próprio.
- Em telas, preserve a cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP`.
- Use `.ai/ui-map/catalogo-ui.md` como base agnóstica e `.ai/ui-map/ui-map.md` como mapeamento para Yasamen.
- Para planeamento, criação ou refinamento de `screen specs`, prefira o agente `screen-spec`.

## Agentes preferenciais

- `spec-station`: entrada máxima e roteamento.
- `lib-spec`: domínio de componentes, pacotes e specs de biblioteca.
- `screen-spec`: domínio de telas e `screen specs`.
- `yasamen`: execução direta no repositório sem criar spec nova por padrão.



