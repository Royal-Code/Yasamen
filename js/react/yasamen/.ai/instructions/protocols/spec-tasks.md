# Protocolo: Tarefas da spec

## Regras

Regras que a IA deve seguir estritamente:
- Gerar tarefas somente com spec `Approved`.
- Gerar tarefas somente sem `Q<n>` bloqueadora aberta.
- Criar uma tarefa para cada ação de implementação, teste e documentação.
- Cobrir todo `CA<n>` com ao menos uma `T<n>`.
- Não criar tarefa sem critério verificável.

## Arquivos a ler

- `req-{slug}.md`: obter `CA<n>`.
- `ds-{slug}.md`: obter arquivos, classes e riscos.
- `dec-{slug}.md`: obter `DC<n>` e próximos IDs.
- `test-{slug}.md` e `doc-{slug}.md`: obter ações que viram tarefas.
- `templates/tasks.md`: seguir o shape.
- `protocols/complexity.md`: classificar cada tarefa.

## 1. Planejar testes e documentação

1. Executar `protocols/spec-test-plan.md`.
2. Executar `protocols/spec-doc-plan.md`.

### GATE ST.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- `test-{slug}.md` existe e cobre todo `CA<n>`;
- `doc-{slug}.md` existe.

## 2. Escrever tarefas

Somente após gate `ST.1` satisfeito.

1. Derivar tarefas na ordem: CSS, componente e classes, exports, testes, demo, Storybook, documentação.
2. Classificar a complexidade de cada tarefa.
3. Agrupar tarefas que tocam o mesmo código (`G<n>`).
4. Preencher `Atende`, `Depende de`, `Validação` e `Riscos` de cada tarefa.
5. Escrever `tasks-{slug}.md` conforme `templates/tasks.md`.
6. Apresentar ao humano: tarefas, grupos, dependências, questões abertas.

### GATE ST.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo `CA<n>` tem `T<n>`;
- humano respondeu aprovação do plano de tarefas;
- nenhuma `Q<n>` bloqueadora aberta.

## 3. Encaminhar

Somente após gate `ST.FINAL` satisfeito.

1. Alterar o status de `tasks-{slug}.md` para `Approved`.
2. Encaminhar para `protocols/implementation.md`, ou para `protocols/implementation-reviewed.md` quando o humano pedir `revisionado`.
