# `.ai/` — Yasamen React

| Caminho | Conteúdo |
|---|---|
| `instructions/kernel.rules.md` | Regras globais da IA |
| `instructions/triage.md` | Pedido → protocolo |
| `instructions/protocols/` | Fluxos com gates |
| `instructions/templates/` | Shape dos artefatos |
| `rules/` | Regras técnicas do código |
| `roadmap/roadmap.md` | Componentes: existentes, parciais, pendentes |
| `specs/` | Specs ativas e `specs.index.md` |
| `archive/` | Specs e itens de roadmap concluídos |

Ordem de leitura ao iniciar: `kernel.rules.md`, `triage.md`, protocolo do pedido, templates e `rules/` que o protocolo indicar.

## Arquivos de uma spec

Pasta `.ai/specs/spec-{slug}/`:

| Arquivo | Conteúdo |
|---|---|
| `req-{slug}.md` | Problema, características, escopo, casos de uso, requisitos, critérios de aceite |
| `ds-{slug}.md` | Arquitetura, API, CSS, tokens, riscos |
| `dec-{slug}.md` | Questões, decisões confirmadas, próximos IDs |
| `tasks-{slug}.md` | Tarefas, grupos, resultado das tarefas |
| `test-{slug}.md` | Plano de testes e casos de teste |
| `doc-{slug}.md` | Plano de documentação |
| `rev-{tipo}-{slug}-{nn}.md` | Revisão (`code` ou `spec`) |
| `aval-{tipo}-{slug}-{nn}.md` | Avaliação da revisão |
| `hist-{slug}.md` | Entrega e histórico |
