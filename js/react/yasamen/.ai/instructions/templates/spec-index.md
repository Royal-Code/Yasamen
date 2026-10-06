# Template: `specs.index.md`

Caminho: `.ai/specs/specs.index.md`.

Regras do template:
- Gerar o documento sem marcador e sem placeholder deste template.
- Ordenar as linhas pela data de criação.
- Atualizar a linha na mesma operação que muda o status da spec.
- Mover a linha para `Arquivadas` ao arquivar a spec.

## Shape

```md
# Índice de specs

## Ativas

| Data | Spec | Status | Componente |
|---|---|---|---|
| <AAAA-MM-DD> | [spec-<slug>](spec-<slug>/) | Draft | <Nome> |

## Arquivadas

| Data | Spec | Status | Caminho |
|---|---|---|---|
| <AAAA-MM-DD> | spec-<slug> | Completed | `.ai/archive/specs/spec-<slug>/` |
```

## Regras deste documento

- Usar somente os status `Draft`, `Approved`, `InProgress`, `Completed`, `Superseded`.
- Manter uma linha por spec.

## Checklist final

- [ ] Cada pasta de `.ai/specs/` tem uma linha em `Ativas`.
- [ ] Cada linha de `Arquivadas` aponta para pasta existente.
