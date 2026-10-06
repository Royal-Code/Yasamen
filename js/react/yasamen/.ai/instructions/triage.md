# Triagem — pedido para protocolo

Identificar o pedido do humano. Ler o protocolo da linha correspondente. Seguir somente esse protocolo.

## Roteamento

| Pedido do humano | Protocolo |
|---|---|
| Planejar, especificar ou iniciar componente | `protocols/spec-discovery.md` |
| Refinar, responder questões ou decidir pendências da spec | `protocols/spec-refinement.md` |
| Revisar a spec | `protocols/review-spec.md` |
| Gerar tarefas | `protocols/spec-tasks.md` |
| Planejar testes ou casos de teste | `protocols/spec-test-plan.md` |
| Planejar documentação | `protocols/spec-doc-plan.md` |
| Implementar spec aprovada | `protocols/implementation.md` |
| Implementar de forma `revisionada` | `protocols/implementation-reviewed.md` |
| Revisar código | `protocols/review-code.md` |
| Avaliar revisão | `protocols/review-evaluation.md` |
| Finalizar ou validar entrega | `protocols/delivery.md` |
| Classificar complexidade de tarefa | `protocols/complexity.md` |
| Mudar export, prop, classe `ya-*` ou token existente | `protocols/api-compatibility.md` |
| Arquivar spec ou roadmap | `protocols/archive.md` |
| Consultar próximo componente ou situação do roadmap | `roadmap/roadmap.md` |
| Corrigir bug sem mudança de API | Seção `Mudança pequena` abaixo |

## Mudança pequena

Aplicar quando a mudança não altera API pública, não cria componente e não cria classe `ya-*`.

Regras que a IA deve seguir estritamente:
- Dispensar a spec.
- Ler `.ai/rules/` aplicáveis à área alterada.
- Escrever ou ajustar o teste que reproduz o defeito antes da correção. Seguir `.ai/rules/testing.md`.
- Rodar `test`, `build` e `lint`.
- Perguntar ao humano se a mudança exige spec quando houver dúvida.

## Quando exigir spec

- Criar componente.
- Adicionar ou remover prop, slot, export ou classe `ya-*` pública.
- Alterar comportamento observável de componente existente.
- Alterar token de `@theme`.

## Pedido ambíguo

Regras que a IA deve seguir estritamente:
- Perguntar ao humano qual protocolo aplicar. Não escolher por conta própria.
- Não iniciar implementação sem spec `Approved` quando o pedido exigir spec.
