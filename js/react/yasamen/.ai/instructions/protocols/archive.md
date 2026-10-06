# Protocolo: Arquivamento

## Regras

Regras que a IA deve seguir estritamente:
- Arquivar somente com pedido do humano ou resposta afirmativa em `protocols/delivery.md`.
- Arquivar spec somente com status `Completed` ou `Superseded`.
- Mover o conteúdo. Não apagar.
- Preservar nomes de arquivo ao mover.

## Arquivos a ler

- `.ai/specs/specs.index.md`: localizar a spec e o status.
- `.ai/roadmap/roadmap.md`: localizar itens concluídos.

## Arquivar spec

1. Conferir que o status é `Completed` ou `Superseded`.
2. Mover `.ai/specs/spec-{slug}/` para `.ai/archive/specs/spec-{slug}/` com `git mv`.
3. Mover a linha de `Ativas` para `Arquivadas` em `specs.index.md`, com o novo caminho.
4. Corrigir links relativos quebrados pela movimentação.

### GATE ARQ.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- a pasta existe em `.ai/archive/specs/` e não existe em `.ai/specs/`;
- `specs.index.md` aponta para o novo caminho.

## Arquivar itens do roadmap

Aplicar quando o humano pedir ou quando o roadmap passar a atrapalhar a leitura.

1. Listar os itens `[x]` cuja spec está `Completed`.
2. Perguntar ao humano quais itens mover.
3. Copiar os itens movidos para `.ai/archive/roadmap-concluidos.md`, com data e caminho da spec arquivada.
4. Manter no roadmap a linha do componente com `[x]` e o caminho do código. Remover somente a descrição histórica longa.

### GATE ARQ.2

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu quais itens mover;
- cada item movido existe em `roadmap-concluidos.md`.
