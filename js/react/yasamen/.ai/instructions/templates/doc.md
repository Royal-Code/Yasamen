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
| Histórias Storybook | src/stories/components/<Nome>.stories.tsx | *a fazer* |
| Página MDX | src/stories/components/<Nome>.mdx | *a fazer* |
| JSDoc das props | src/lib/components/<dominio>/<Nome>.tsx | *a fazer* |
| Roadmap | .ai/roadmap/roadmap.md | *a fazer* |
| Regras técnicas | .ai/rules/<arquivo>.md | *a fazer* |

## Casos de uso e stories

[DERIVAR]
Responde: qual story do Storybook materializa e testa cada caso de uso?

| UC | Story | CA | TC | Tipo |
|---|---|---|---|---|
| UC<n> | <NomeDaStory> | CA<n> | TC<n> | feliz |
| UC<n> | <NomeDaStory> | CA<n> | TC<n> | infeliz |
| UC<n> | <NomeDaStory> | CA<n> | TC<n> | borda |

## Conteúdo por item

### <Item>
[DERIVAR]
Responde: o que o item exibe ou descreve?
- **Mostra:** <temas, tamanhos, estados>
- **Pronto quando:** <condição observável>

## Regras deste documento

- Mapear cada `UC<n>` para ao menos uma story com `play` function.
- Cobrir toda prop pública com JSDoc.
- Incluir página MDX descritiva por componente.
- Marcar o componente no roadmap ao concluir a spec.
- Atualizar `.ai/rules/` somente quando a spec criar convenção nova.
- Incluir tarefa em `tasks-{slug}.md` para cada item.
```

## Checklist final

- [ ] Demo, Storybook, MDX, JSDoc e roadmap listados.
- [ ] Tabela de rastreabilidade UC ↔ Story ↔ CA ↔ TC preenchida.
- [ ] Cada item tem condição de pronto observável.
- [ ] Cada item tem tarefa em `tasks-{slug}.md`.
