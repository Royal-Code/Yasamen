# Instrução Operacional - Implementar uma Spec

> Use este arquivo como base em novos chats para que a IA execute uma spec completa, do planeamento ao encerramento.

## Objetivo

Quando o utilizador pedir para implementar uma spec `<nome-da-spec>`, a IA deve executar a entrega completa, não apenas analisar.

## Arquivos da Spec

Para a spec `<nome-da-spec>`, a IA deve localizar e ler:

- `.ai/specs/lib/<nome-da-spec>/requirements.md`
- `.ai/specs/lib/<nome-da-spec>/design.md`
- `.ai/specs/lib/<nome-da-spec>/tasks.md`
- `.ai/specs/lib/<nome-da-spec>/delivery.md`

## Guides Obrigatórios

A IA deve ler todos os guides listados em `Guides aplicados` na spec.

Além disso:

- se a spec envolver showcase ou documentação, aplicar `showcases-and-docs.md`;
- em qualquer execução completa de spec, aplicar `spec-execution-and-delivery.md`;
- em qualquer implementação de componente, aplicar `cross-cutting-component-decisions.md`;
- se a spec for de formulário ainda pouco definido, respeitar também `form-components-lightweight.md` quando ele estiver em `Guides aplicados`.
- se o `design.md` exigir pacote novo ou reestruturação de projeto, aplicar `.ai/instructions/expand/create-library-project.md` como subfluxo técnico antes de implementar o componente.

## Regras

- Verificar coerência entre requirements, design, tasks e guides antes de codar.
- Corrigir incoerências pequenas e claras antes da implementação.
- Respeitar as decisões estruturais, visuais, composicionais e de entrega já fechadas na spec, conforme `cross-cutting-component-decisions.md`.
- Se o `design.md` indicar pacote novo, criar ou ajustar o projeto primeiro seguindo `.ai/instructions/expand/create-library-project.md`.
- Não improvisar estrutura de pacote quando a spec já tiver decidido isso.
- Implementar a spec de forma end-to-end.
- Atualizar showcase no `RoyalCode.Razor.Docs.Client` quando aplicável.
- Executar build, testes e validações manuais previstos.
- Fechar `delivery.md`, `tasks.md` e o status final da spec.
- Em formulários ainda pouco definidos, não forçar uma API maior do que a spec aprovou.
- Usar sempre acentuação.

## Validação Visual com Playwright MCP

Quando a spec envolver UI ou showcase, a IA deve tentar uma validação visual ao final da implementação.

Fluxo esperado:

1. verificar se o MCP do Playwright está disponível no ambiente;
2. se estiver disponível:
   - subir a aplicação ou projeto de docs necessário;
   - abrir a rota relevante;
   - validar a página;
   - capturar screenshots quando isso fizer parte da entrega;
3. se não estiver disponível:
   - não bloquear a entrega por isso;
   - registrar a ausência em `delivery.md`, se a validação visual fizer parte relevante da evidência;
   - mencionar explicitamente no resumo final que o MCP do Playwright não estava disponível.

Regra:

- a IA não deve fingir validação visual que não conseguiu executar;
- a ausência do MCP deve ser comunicada ao desenvolvedor na resposta final;
- se houver screenshots gerados, registrar onde ficaram salvos.


