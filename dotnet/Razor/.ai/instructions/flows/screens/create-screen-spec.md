# Instrução Operacional - Criar uma Screen Spec

> Use este arquivo como base em novos chats para que a IA crie uma `screen spec` completa a partir de requisitos de tela, catálogo de `UIP-*` e mapeamento para Yasamen.

## Fontes Obrigatórias

Antes de escrever a `screen spec`, a IA deve ler:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/components-plan-list.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/guides/screens/planning-and-ui-mapping.md`
- `.ai/guides/rules/cross-cutting-component-decisions.md`
- o template em `.ai/templates/screens/spec/`

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

## Regras de Qualidade

- Não copiar o template sem adaptação.
- Não inventar `UIP-*` fora do catálogo.
- Não misturar a `screen spec` com API detalhada de componente.
- Não tratar `ui-map.md` como catálogo agnóstico; ele é adapter tecnológico.
- Não esconder gaps de componente dentro de texto genérico.
- Usar sempre acentuação.


