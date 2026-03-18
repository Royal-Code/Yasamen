# Instrução Operacional - Refinar uma App Spec

> Use este arquivo como base em novos chats para que a IA fortaleça uma `app spec` existente antes do handoff para criação de projeto, telas ou execução direta.

## Fontes obrigatórias

Antes de refinar a `app spec`, a IA deve ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/guides/yasamen/consumer-app-conventions.md`
- `.ai/guides/rules/cross-cutting-app-decisions.md`
- `.ai/templates/apps/spec/requirements.md`
- `.ai/templates/apps/spec/design.md`
- `.ai/templates/apps/spec/tasks.md`
- `.ai/templates/apps/spec/delivery.md`
- os arquivos da `app spec` alvo

## Regras

- Tornar a `app spec` mais consistente, específica, executável e rastreável.
- Validar explicitamente:
  - contexto do app;
  - tipo do host;
  - shell, layout e navegação;
  - referências e pacotes confirmados versus candidatos;
  - pacotes, estilos e serviços públicos;
  - estratégia inicial de dados, autenticação e integrações;
  - telas prioritárias e dependências de `screen spec`;
  - convenções locais do projeto;
  - limites entre consumo, execução direta e expansão da biblioteca.
- Se o app existente estiver sendo alterado, garantir que a distinção entre `As-Is` e `To-Be` fique clara.
- Se a spec usar referência ao repositório atual, validar se isso está marcado como referência técnica local e não como justificativa de produto.
- Corrigir seções que confundam completude da spec com implementação do app.
- Preservar o que já estiver bom.
- Usar sempre acentuação.
