# Protocolo: Entrega

## Regras

Regras que a IA deve seguir estritamente:
- Registrar somente evidência verificada. Verificar que cada caminho citado existe.
- Não marcar a spec `Completed` sem aceite humano explícito.
- Não declarar validação sem executar o comando.

## Arquivos a ler

- `tasks-{slug}.md`: conferir que toda tarefa está `[x]` ou justificada.
- `req-{slug}.md`: obter `CA<n>`.
- `test-{slug}.md`: obter `TC<n>` e verificações manuais `V<n>`.
- `rev-*` e `aval-*` da spec: obter revisões e avaliações.
- `templates/hist.md`: seguir o shape.

## 1. Validar

1. Executar `bun run test`, `bun run build`, `bun run lint` e `bun run build:demo`.
2. Registrar comando e resultado.
3. Conferir que toda revisão tem `aval-` com status `Avaliada`.
4. Conferir que o componente está em `src/lib/index.ts`.

### GATE DL.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- os quatro comandos passam;
- toda tarefa está `[x]` ou justificada;
- toda revisão tem avaliação.

## 2. Registrar

Somente após gate `DL.1` satisfeito.

1. Escrever `hist-{slug}.md` conforme `templates/hist.md`, com status `Aguardando aceite`.
2. Preencher a rastreabilidade: `CA<n>` e `TC<n>` com `arquivo:linha`.
3. Apresentar ao humano: resumo, validação, verificações manuais `V<n>` e limitações.

### GATE DL.2

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- `hist-{slug}.md` existe com evidência por `CA<n>`;
- humano respondeu o resultado de cada verificação manual `V<n>`.

## 3. Aceitar

Somente após gate `DL.2` satisfeito.

1. Perguntar ao humano se aceita a entrega.
2. Registrar o aceite com data na seção `Aceite humano`.
3. Alterar o status para `Completed` em `req-{slug}.md`, `hist-{slug}.md` e `specs.index.md`.
4. Marcar o item no `.ai/roadmap/roadmap.md`.
5. Perguntar ao humano se deve arquivar a spec (`protocols/archive.md`).

### GATE DL.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu aceite explícito;
- status `Completed` sincronizado nos três arquivos;
- roadmap atualizado.
