# Template: `aval-{tipo}-{slug}-{nn}.md`

Caminho: `.ai/specs/spec-{slug}/aval-{tipo}-{slug}-{nn}.md`. Corresponde a `rev-{tipo}-{slug}-{nn}.md`.

Regras do template:
- Gerar o documento sem marcador e sem placeholder deste template.
- Criar uma avaliação por achado da revisão, com o mesmo número `<N>.<N>`.
- Classificar: `válido`, `parcial`, `inválido`.
- Escrever `*a fazer*` na correção até aplicá-la.

## Shape

```md
# Avaliação <code|spec> — <Nome> (<nn>)

| Campo | Valor |
|---|---|
| Revisão | rev-<tipo>-<slug>-<nn>.md |
| Spec | spec-<slug> |

## Resumo

| Avaliação | Quantidade |
|---|---|
| válido | <n> |
| parcial | <n> |
| inválido | <n> |

## <N>.<N>. <Título do achado>

**Avaliação:** válido | parcial | inválido
**Verificação:** <o que foi conferido e onde>

<afirmação confirmada ou refutada, com evidência>

**Justificativa:** <obrigatória em parcial e inválido>
**Correção:** <ação aplicada, com caminho, ou tarefa T<n>> | *a fazer*
**Verificação da correção:** <comando e resultado>
```

## Regras deste documento

- Verificar a validade e a veracidade de cada afirmação antes de aceitá-la.
- Corrigir o achado válido. Aplicar a parte válida do achado parcial.
- Justificar com evidência a discordância do achado inválido ou parcial.
- Registrar a correção com caminho e resultado de validação.
- Converter correção grande em `T<n>` em `tasks-{slug}.md` e citá-la.
- Marcar a revisão `Avaliada` somente com todos os achados avaliados.

## Checklist final

- [ ] Todo achado da revisão tem avaliação.
- [ ] Todo `parcial` e `inválido` tem justificativa com evidência.
- [ ] Todo `válido` tem correção registrada ou tarefa.
- [ ] Resumo confere com as avaliações.
