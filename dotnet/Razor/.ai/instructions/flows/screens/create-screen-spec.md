# Instrução Operacional - Criar uma Screen Spec

> Use este arquivo como base em novos chats para que a IA crie uma `screen spec` completa a partir de requisitos de tela, catálogo de `UIP-*` e mapeamento para Yasamen.

## Fontes Obrigatórias

Antes de escrever a `screen spec`, a IA deve ler:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/ui-map.md`
- `.ai/guides/screens/planning-and-ui-mapping.md`
- `.ai/guides/rules/cross-cutting-screen-decisions.md`
- o template em `.ai/templates/screens/spec/`

Se houver backlog, roadmap ou mapa local de gaps do projeto, a IA deve ler também.

Neste repositório, os arquivos padrão para isso são:

- `.ai/roadmap/components-plan-list.md`
- `.ai/roadmap/ui-plan.md`

## Saída Esperada

Criar a `screen spec` em:

`.ai/specs/screens/<nome-da-tela>/`

Arquivos obrigatórios:

- `requirements.md`
- `design.md`
- `tasks.md`
- `delivery.md`

## Regras Estruturais

- Toda `screen spec` deve decidir explicitamente:
  - se a tela é nova ou alteração de tela existente;
  - qual é o shell de referência;
  - qual é o `Page Pattern` principal;
  - quais são as zonas funcionais;
  - quais `UIP-*` entram em cada zona;
  - como cada `UIP-*` mapeia para Yasamen;
  - quais componentes já existem;
  - quais dependem de composição;
  - quais representam `Gap de componente`;
  - quais representam `Gap estrutural da tela`.

- Se a tela já existir:
  - registrar o `As-Is`;
  - registrar o `To-Be`;
  - destacar o delta principal.

- Se a tela depender de componentes ausentes, a `screen spec` deve escolher uma destas saídas:
  - apontar specs filhas já existentes;
  - recomendar abertura de novas specs de componente;
  - justificar por que a tela pode seguir mesmo com a dependência ainda aberta.

- Se jornadas ou capacidades forem fornecidas:
  - registrar como entrada opcional da tela;
  - não remodelar a `screen spec` inteira em torno delas.

## Regra de completude

Antes de criar a `screen spec`, a IA deve verificar se já conhece informação suficiente para preencher pelo menos:

- objetivo e contexto da tela;
- natureza da tela: nova ou alteração;
- shell ou hipótese inicial de shell;
- `Page Pattern` principal ou hipótese forte;
- zonas funcionais iniciais;
- estratégia de mapeamento para Yasamen;
- principais gaps ou dependências de componente.

Se isso não estiver suficientemente claro:

- não inventar;
- não responder só com explicação do fluxo;
- pedir uma lista enumerada única do que precisa saber para abrir a spec com qualidade.

## Regras de Qualidade

- Não copiar o template sem adaptação.
- Não inventar `UIP-*` fora do catálogo.
- Não misturar a `screen spec` com API detalhada de componente.
- Não tratar `ui-map.md` como catálogo agnóstico; ele é adapter tecnológico.
- Não esconder gaps de componente dentro de texto genérico.
- Se houver informação suficiente, criar os arquivos da `screen spec` em vez de só orientar o utilizador a fazê-lo.
- Usar sempre acentuação.

## Etapa pós-criação

Depois de criar ou refinar a `screen spec`:

- acionar o agente `spec-review` do Copilot para revisar a spec, quando o ambiente suportar subagentes;
- se o subagente não estiver disponível, fazer revisão equivalente localmente;
- incorporar os ajustes relevantes antes de encerrar a resposta.

## Fechamento da resposta

A resposta final da criação da `screen spec` deve informar:

- onde a spec foi criada;
- se a revisão da spec encontrou ou não pontos relevantes;
- qual é o próximo passo recomendado no fluxo.

Opções típicas de próximo passo:

- `refine screen-spec`, quando a revisão encontrar inconsistências;
- `yasamen`, quando a tela já estiver pronta para implementação;
- `lib-spec`, quando a revisão revelar gap real de componente.


