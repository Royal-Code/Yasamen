# Template: `hist-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/hist-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:` e sem placeholder deste template.
- Criar o arquivo somente ao iniciar a entrega.
- Escrever `*a fazer*` em `Aceite humano` até o humano aceitar.
- Escrever evidência com caminho e linha reais. Verificar que o caminho existe.

## Shape

```md
# Entrega — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Status final | Aguardando aceite | Concluída |
| Data | <AAAA-MM-DD> |

## Resumo
Responde: o que foi entregue e quais desvios existem em relação ao plano?
- **Entregue:** <resumo>
- **Desvios:** <descrição ou nenhum>

## Changelog
- **Added:** `<Componente>` em `src/lib/components/<dominio>/`
- **Added:** `src/lib/styles/css/components/<nome>.css`
- **Added:** `src/demo/pages/<Nome>Page.tsx`
- **Changed:** <item>

## Rastreabilidade

| Item | Evidência | Status |
|---|---|---|
| CA<n> | `<arquivo>:<linha>` | OK |
| TC<n> | `<arquivo>:<linha>` | OK |

## Validação

| Comando ou rota | Resultado |
|---|---|
| `bun run test` | <quantidade> passando, <quantidade> falhas |
| `bun run build` | <resultado> |
| `bun run lint` | <resultado> |
| `bun run build:demo` | <resultado> |

## Revisões

| Arquivo | Avaliação | Achados válidos |
|---|---|---|
| `rev-code-<slug>-<nn>.md` | `aval-code-<slug>-<nn>.md` | <quantidade> |

## Limitações conhecidas

- <limitação ou nenhuma>

## Aceite humano

*a fazer*
```

## Regras deste documento

- Marcar `Completed` na spec somente com aceite humano registrado.
- Registrar o aceite com data e o que o humano conferiu.
- Listar toda `V<n>` de verificação manual com o resultado.
- Sincronizar o status final com `.ai/specs/specs.index.md`.

## Checklist final

- [ ] Todo `CA<n>` tem evidência com caminho existente.
- [ ] Os quatro comandos de validação têm resultado registrado.
- [ ] Toda revisão tem avaliação.
- [ ] Aceite humano registrado.
