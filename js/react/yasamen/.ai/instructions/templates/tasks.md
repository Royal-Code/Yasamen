# Template: `tasks-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/tasks-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:` e sem placeholder deste template.
- Numerar tarefas como `T<n>`, a partir do próximo ID de `dec-{slug}.md`.
- Referenciar `CA<n>`, `R<n>`, `V<n>`, `TC<n>` e `DC<n>` por ID.
- Classificar complexidade segundo `protocols/complexity.md`.
- Escrever `*a fazer*` em `Resultado das tarefas` até a tarefa ser iniciada.
- Criar a entrada de resultado quando a tarefa for iniciada.

## Shape

```md
# Tasks — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Status | Draft |

## Grupos

[DERIVAR]
Responde: quais tarefas tocam o mesmo código e são implementadas juntas?
- **G<n>:** T<n>, T<n>

## Tarefas

- [ ] **T<n> — <título>**
  - **Ação:** <o que fazer, com caminho>
  - **Atende:** CA<n>
  - **Complexidade:** Simples | Média | Complexa | Muito Complexa
  - **Depende de:** T<n> ou nenhuma
  - **Validação:** V<n>
  - **Riscos:** R<n> ou nenhum

## Validações

- [ ] **V<n>:** <comando ou verificação> — **Resultado esperado:** <valor>
- [ ] **V<n>:** <comando ou verificação> — **Resultado esperado:** <valor>

## Resultado das tarefas

*a fazer*

### T<n> — <título>
- **Entregue:** <o que foi feito>
- **Validações:** <comando e resultado>
- **Pendente:** <o que falta ou bloqueia, quando parcial>

## Encerramento

*a fazer*
```

## Regras deste documento

- Marcar `[-]` ao iniciar. Marcar `[x]` somente após concluir e validar.
- Registrar em `Resultado das tarefas` toda tarefa iniciada ou concluída.
- Incluir tarefa para toda ação de `doc-{slug}.md` e de `test-{slug}.md`.
- Incluir tarefa para cada achado válido de revisão e referenciar o arquivo `rev-`.
- Executar as tarefas de um grupo juntas.
- Registrar comando e resultado de `bun run test`, `bun run build` e `bun run lint` por grupo de código.

## Checklist final

- [ ] Todo `CA<n>` é atendido por pelo menos uma `T<n>`.
- [ ] Toda `T<n>` tem complexidade, validação e dependência.
- [ ] Tarefas de teste e documentação existem.
- [ ] Nenhuma `Q<n>` bloqueadora aberta em `dec-{slug}.md`.
