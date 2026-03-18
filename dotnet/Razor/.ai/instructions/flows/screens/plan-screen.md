# Instrução Operacional - Planejar uma Tela

> Use este arquivo como base em novos chats para que a IA planeje uma tela em colaboração com o utilizador, por gates, usando `Page Pattern`, `UIP-*` e mapeamento para Yasamen.

## Fontes Obrigatórias

Antes de iniciar o planeamento, a IA deve ler:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/ui-map.md`
- `.ai/guides/screens/planning-and-ui-mapping.md`
- `.ai/guides/rules/cross-cutting-screen-decisions.md`
- `.ai/templates/screens/spec/requirements.md`
- `.ai/templates/screens/spec/design.md`
- `.ai/templates/screens/spec/tasks.md`
- `.ai/templates/screens/spec/delivery.md`

Se houver backlog, roadmap ou mapa local de gaps do projeto, a IA deve ler também.

Neste repositório, os arquivos padrão para isso são:

- `.ai/roadmap/components-plan-list.md`
- `.ai/roadmap/ui-plan.md`

Se a tela for virar protótipo, showcase ou página navegável em docs:

- combinar também com `.ai/guides/expand/showcases-and-docs.md`

## Gates Obrigatórios

1. alvo, contexto e natureza da tela;
2. shell de referência;
3. `Page Pattern` principal;
4. zonas funcionais;
5. `UIP-*` por zona;
6. mapeamento para Yasamen e gaps de componente;
7. fechamento da `screen spec`.

## Regras

- Trabalhar em gates.
- Em cada gate, apresentar proposta curta, decisões, pontos em aberto e uma pergunta objetiva.
- Se a tela já existir, começar pelo quadro `As-Is` antes de propor o `To-Be`.
- Fechar explicitamente a cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP`.
- Para cada zona, escolher apenas `UIP-*` do catálogo.
- Não criar `UIP` local.
- Classificar cada necessidade da tela como:
  - `Existente`
  - `Composição com existentes`
  - `Gap de componente`
  - `Gap estrutural da tela`
- Se a tela depender de componentes ausentes, registrar isso e indicar se será preciso abrir ou refinar specs filhas em `.ai/specs/`.
- Jornadas e capacidades, quando fornecidas, podem reforçar contexto e prioridade; quando ausentes, não bloqueiam o fluxo.
- Esperar aprovação antes de avançar.
- Usar sempre acentuação.


