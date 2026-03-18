# Instrução Operacional - Criar uma Spec

> Use este arquivo como base em novos chats para que a IA crie uma spec completa, consistente com os templates, guides e documentos de planeamento da solução.

## Fontes Obrigatórias

Antes de escrever a spec, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/roadmap/components-plan-list.md`
- `.ai/guides/rules/cross-cutting-component-decisions.md`
- os guides relevantes em `.ai/guides/`
- o template da spec em `.ai/templates/lib/spec/`

## Regras Estruturais

- Toda spec nova deve fechar explicitamente os checkpoints do guide `cross-cutting-component-decisions.md`.
- Isso inclui, no mínimo:
  - backlog e contexto;
  - pacote existente versus pacote novo;
  - API pública;
  - decisão sobre `Style: Themes`;
  - decisão sobre `Size: Sizes`;
  - fallback de `Themes.Default`, quando houver `Style`;
  - tokens de `yasamen.css`;
  - composição, reuso e pré-requisitos;
  - showcase;
  - evidência de entrega.

- Se houver dependência composicional natural de um componente ainda não implementado, a IA deve escolher uma destas saídas:
  - abrir a spec do componente-base primeiro;
  - registrar o componente-base como pré-requisito;
  - justificar por que o alvo seguirá sem essa abstração no primeiro release.

- Se o componente não aparecer em `components-plan-list.md` ou `ui-plan.md` do roadmap, a spec deve registrar essa ausência e justificar por que o trabalho segue mesmo assim.

- Se a spec concluir que o componente precisa de pacote novo:
  - registrar isso explicitamente no `design.md`;
  - identificar o pacote alvo;
  - indicar que a implementação deverá seguir `.ai/instructions/expand/create-library-project.md`.

## Seleção de Guides

- `cross-cutting-component-decisions` entra por padrão em qualquer spec de componente.

- componente visual simples:
  - `project-structure`
  - `styles-and-css`
  - `component-anatomy`
  - `showcases-and-docs`
  - `spec-execution-and-delivery`
  - `cross-cutting-component-decisions`
  - `css-visual-contract`
  - `component-composition-and-dependencies`
- componente de formulário consolidado:
  - adicionar `form-components`
- componente de formulário ainda pouco definido:
  - adicionar `form-components`
  - adicionar `form-components-lightweight`
- componente com service/outlet:
  - adicionar `service-pattern`
  - adicionar `outlet-patterns`
- componente de navegação:
  - adicionar `navigation-patterns`
  - adicionar `css-visual-contract`

## Regras de Qualidade

- Usar sempre acentuação.
- Não copiar o template sem adaptação.
- Não inventar pacotes ou dependências sem justificativa.
- Não deixar implícita a decisão de criar pacote novo.
- Não tratar `RoyalCode.Razor.Show` como host atual de showcase.
- Em componentes de formulário ainda pouco definidos, preferir `form-components` + `form-components-lightweight`.
- Não omitir `delivery.md`.


