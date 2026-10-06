# Protocolo: Implementação revisionada

## Regras

Regras que a IA deve seguir estritamente:
- Executar somente quando o humano pedir `revisionado`.
- Seguir `protocols/implementation.md` para implementar cada grupo.
- Lançar a revisão de código em subagente com o mesmo modelo e esforço de raciocínio.
- Salvar toda revisão e avaliação na pasta da spec.
- Não aceitar achado sem verificação (`protocols/review-evaluation.md`).
- Executar `git commit` e `git push` somente com pedido explícito do humano.

## Arquivos a ler

- `protocols/implementation.md`: executar a implementação do grupo.
- `protocols/review-code.md`: instruir o subagente revisor.
- `protocols/review-evaluation.md`: avaliar a revisão.
- `tasks-{slug}.md`: obter os grupos `G<n>`.

## 1. Agrupar

1. Identificar tarefas que tocam o mesmo problema ou código.
2. Registrar os grupos `G<n>` em `tasks-{slug}.md`, na seção `Grupos`.

### GATE IR.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- toda `T<n>` pertence a um grupo;
- humano pediu `revisionado`.

## 2. Executar por grupo com código

Somente após gate `IR.1` satisfeito.

Para cada grupo que implementa código:
1. Implementar o grupo conforme `protocols/implementation.md`, seção `Executar por grupo`.
2. Lançar subagente com o protocolo `protocols/review-code.md`, escopo: as tarefas do grupo. Salvar em `rev-code-{slug}-{nn}.md`.
3. Avaliar a revisão conforme `protocols/review-evaluation.md`. Salvar em `aval-code-{slug}-{nn}.md`.
4. Aplicar as correções dos achados válidos.
5. Executar `bun run test`, `bun run build` e `bun run lint`.
6. Atualizar `tasks-{slug}.md`: checkboxes e `Resultado das tarefas`.
7. Perguntar ao humano se deve fazer commit e push do grupo. Executar somente com resposta afirmativa.

### GATE IR.2

Use as regras de GATE de `kernel.rules.md` para validar os itens, a cada grupo:
- `rev-code-{slug}-{nn}.md` e `aval-code-{slug}-{nn}.md` existem;
- todo achado válido tem correção registrada;
- comandos de validação passam.

A iteração do grupo só termina com o gate `IR.2` satisfeito.

## 3. Encerrar

Somente após todos os grupos satisfazerem o gate `IR.2`.

1. Lançar subagente com `protocols/review-code.md`, escopo: toda a spec. Salvar em `rev-code-{slug}-{nn}.md`.
2. Avaliar a revisão final. Salvar em `aval-code-{slug}-{nn}.md`. Aplicar as correções.
3. Preencher `Encerramento` em `tasks-{slug}.md`.
4. Encaminhar para `protocols/delivery.md`.

### GATE IR.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- revisão final e avaliação final existem;
- nenhum achado válido sem correção;
- comandos de validação passam.
