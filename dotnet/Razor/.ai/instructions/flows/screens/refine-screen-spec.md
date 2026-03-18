# Instrução Operacional - Refinar uma Screen Spec

> Use este arquivo como base em novos chats para que a IA fortaleça uma `screen spec` existente antes do handoff técnico ou antes de uma alteração de tela.

## Fontes Obrigatórias

Antes de refinar a `screen spec`, a IA deve ler:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/components-plan-list.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/guides/screens/planning-and-ui-mapping.md`
- `.ai/guides/rules/cross-cutting-component-decisions.md`
- `.ai/templates/screens/spec/requirements.md`
- `.ai/templates/screens/spec/design.md`
- `.ai/templates/screens/spec/tasks.md`
- `.ai/templates/screens/spec/delivery.md`
- os arquivos da `screen spec` alvo

## Regras

- Tornar a `screen spec` mais consistente, específica, executável e rastreável.
- Validar explicitamente:
  - shell de referência;
  - `Page Pattern`;
  - zonas funcionais;
  - `UIP-*` por zona;
  - mapeamento para Yasamen;
  - gaps de componente e gaps estruturais;
  - dependências de specs filhas.
- Se a tela existente estiver sendo alterada, garantir que a distinção entre `As-Is` e `To-Be` fique clara.
- Preservar o que já estiver bom.
- Se a `screen spec` revelar componentes ausentes que já deveriam ter spec, registrar isso de forma explícita.
- Jornadas e capacidades continuam opcionais nesta versão; se existirem, devem servir como contexto, não como ruído extra.
- Usar sempre acentuação.


