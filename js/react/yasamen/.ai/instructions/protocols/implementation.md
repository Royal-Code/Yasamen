# Protocolo: Implementação

## Regras

Regras que a IA deve seguir estritamente:
- Implementar somente spec com status `Approved` e `tasks-{slug}.md` aprovado.
- Não alterar `req`, `ds` ou critério de aceite aprovado. Registrar `Q<n>` e perguntar ao humano.
- Seguir `.ai/rules/`.
- Marcar `[-]` ao iniciar a tarefa. Marcar `[x]` somente após concluir e validar.
- Registrar o resultado em `tasks-{slug}.md` ao iniciar e ao concluir a tarefa.
- Não executar `git commit` nem `git push` (`kernel.rules.md`, seção `Ações só com pedido explícito`).
- Parar e perguntar ao humano quando a implementação exigir decisão não registrada em `dec-{slug}.md`.

## Arquivos a ler

- `tasks-{slug}.md`: obter a próxima tarefa e os grupos.
- `req`, `ds`, `test`, `doc` da spec: obter critérios, contrato e casos.
- `.ai/rules/component-anatomy.md`, `css-contract.md`, `tokens.md`, `testing.md`: aplicar ao código.

## 1. Iniciar

1. Alterar o status da spec para `InProgress` em `req-{slug}.md` e `specs.index.md`.

### GATE IM.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- spec e `tasks-{slug}.md` com status `Approved`;
- nenhuma `Q<n>` bloqueadora aberta.

## 2. Executar por grupo

Somente após gate `IM.1` satisfeito.

Para cada grupo `G<n>`, na ordem de dependência:
1. Marcar as tarefas do grupo `[-]`.
2. Implementar na ordem: CSS e `@import`, componente e classes, exports (`<dominio>/index.ts`, `src/lib/index.ts`), testes, demo, Storybook, JSDoc.
3. Escrever o teste e executar a prova de falha de cada `TC<n>` (`.ai/rules/testing.md`, seção `Regra central`). Preencher `Prova de falha` em `test-{slug}.md`.
4. Executar `bun run test`, `bun run build` e `bun run lint`. Executar `bun run build:demo` quando tocar a demo.
5. Corrigir falhas e repetir o passo 4.
6. Marcar `[x]` as tarefas concluídas e validadas.
7. Preencher `Resultado das tarefas` do grupo.

### GATE IM.2

Use as regras de GATE de `kernel.rules.md` para validar os itens, a cada grupo:
- comandos de validação do grupo passam;
- `Prova de falha` preenchida nos `TC<n>` do grupo;
- `Resultado das tarefas` preenchido.

A iteração do grupo só termina com o gate `IM.2` satisfeito.

## 3. Encerrar

Somente após todos os grupos satisfazerem o gate `IM.2`.

1. Atualizar `.ai/roadmap/roadmap.md` conforme `doc-{slug}.md`.
2. Preencher `Encerramento` em `tasks-{slug}.md`.
3. Encaminhar para `protocols/delivery.md`.
