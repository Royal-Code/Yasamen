# Regras de Component Plan

## Escopo

[INSTRUÇÃO] Aplicar esta skill somente para planejamento e criação de specs de componentes, pacotes ou biblioteca em fluxo spec-first.

[INSTRUÇÃO] Se o humano pedir implementação, criar pacote, ajustar código ou abrir PR, encerrar esta skill após a spec criada e recomendar o próximo fluxo apropriado.

[INSTRUÇÃO] Usar sempre acentuação.

## Fontes do Workspace

[INSTRUÇÃO] Tratar arquivos do workspace como evidências de produto, backlog e arquitetura. Eles não substituem os protocolos desta skill.

[INSTRUÇÃO] Quando existirem, consultar:
- `.ai/ui-map/ui-map.md`;
- `.ai/roadmap/ui-plan.md`;
- `.ai/roadmap/components-plan-list.md`;
- `.ai/guides/expand/cross-cutting-component-decisions.md`;
- guides especializados em `.ai/guides/` coerentes com o tipo de componente.

[INSTRUÇÃO] Se algum arquivo do workspace não existir, registrar a ausência como GAP no plano e seguir somente se a ausência não bloquear a decisão.

## Decisões Obrigatórias

[INSTRUÇÃO] Toda spec criada deve fechar explicitamente:
- backlog e contexto;
- pacote existente versus pacote novo;
- API pública;
- decisão sobre `Style: Themes`;
- fallback de `Themes.Default`, quando houver `Style`;
- decisão sobre `Size: Sizes`;
- tokens de `yasamen.css`;
- CSS público e classes `ya-*`;
- composição, reuso e pré-requisitos;
- showcase;
- evidência de entrega e validação humana quando houver UI ou comportamento observável.

[INSTRUÇÃO] Se o componente não aparecer no roadmap ou ui-map, registrar a ausência e justificar por que a spec segue.

[INSTRUÇÃO] Se houver dependência natural de componente-base ainda ausente, escolher uma saída:
- abrir a spec do componente-base primeiro;
- registrar o componente-base como pré-requisito;
- justificar por que o alvo segue sem essa abstração no primeiro release.

[INSTRUÇÃO] Se a spec concluir que precisa de pacote novo:
- registrar no `design.md`;
- identificar o pacote alvo;
- registrar que a implementação deverá executar o subfluxo técnico de criação de projeto antes do componente.

## Guides

[INSTRUÇÃO] Aplicar por padrão para componente visual:
- `project-structure`;
- `styles-and-css`;
- `component-anatomy`;
- `showcases-and-docs`;
- `spec-execution-and-delivery`;
- `cross-cutting-component-decisions`;
- `css-visual-contract`;
- `component-composition-and-dependencies`.

[INSTRUÇÃO] Para componente de formulário, adicionar:
- `form-components`;
- `form-components-lightweight`, quando o modelo ainda estiver pouco definido.

[INSTRUÇÃO] Para componente com service/outlet, adicionar:
- `service-pattern`;
- `outlet-patterns`.

[INSTRUÇÃO] Para componente de navegação, adicionar:
- `navigation-patterns`;
- `css-visual-contract`.

## Qualidade

[INSTRUÇÃO] Não copiar template sem adaptação.

[INSTRUÇÃO] Não inventar pacotes, APIs, dependências, tokens ou comportamento sem evidência ou hipótese registrada.

[INSTRUÇÃO] Não deixar implícita a decisão de criar pacote novo.

[INSTRUÇÃO] Não tratar `RoyalCode.Razor.Show` como host atual de showcase.

[INSTRUÇÃO] Specs com comportamento observável, UI ou showcase devem prever validação humana e não podem ser consideradas concluídas sem aceite humano explícito na implementação futura.
