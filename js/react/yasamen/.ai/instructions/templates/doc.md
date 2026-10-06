# Template: `doc-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/doc-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:` e sem placeholder deste template.
- Listar somente documentação que a spec produz ou atualiza.
- Escrever `*a fazer*` em `Status` até a entrega.

## Shape

```md
# Documentação — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |

## Itens

| Item | Caminho | Status |
|---|---|---|
| Página da demo | src/demo/pages/<Nome>Page.tsx | *a fazer* |
| Histórias | src/stories/components/<Nome>.stories.tsx | *a fazer* |
| JSDoc das props | src/lib/components/<dominio>/<Nome>.tsx | *a fazer* |
| Roadmap | .ai/roadmap/roadmap.md | *a fazer* |
| Regras técnicas | .ai/rules/<arquivo>.md | *a fazer* |

## Conteúdo por item

### <Item>
[DERIVAR]
Responde: o que o item exibe ou descreve?
- **Mostra:** <temas, tamanhos, estados>
- **Pronto quando:** <condição observável>

## Regras deste documento

- Cobrir toda prop pública com JSDoc.
- Marcar o componente no roadmap ao concluir a spec.
- Atualizar `.ai/rules/` somente quando a spec criar convenção nova.
- Incluir tarefa em `tasks-{slug}.md` para cada item.
```

## Checklist final

- [ ] Demo, Storybook, JSDoc e roadmap listados.
- [ ] Cada item tem condição de pronto observável.
- [ ] Cada item tem tarefa em `tasks-{slug}.md`.
