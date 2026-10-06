# Template: `rev-{tipo}-{slug}-{nn}.md`

Caminho: `.ai/specs/spec-{slug}/rev-{tipo}-{slug}-{nn}.md`. `{tipo}`: `code` ou `spec`. `{nn}`: sequência de dois dígitos por tipo.

Regras do template:
- Gerar o documento sem marcador e sem placeholder deste template.
- Numerar achados como `<N>.<N>`.
- Classificar severidade: `crítica`, `alta`, `média`, `baixa`, `mínima`.
- Escrever cada achado com problema, impacto e recomendação.
- Citar arquivo e linha ou seção em cada achado.
- Não escrever avaliação neste arquivo. Avaliar em `aval-{tipo}-{slug}-{nn}.md`.

## Shape

```md
# Revisão <code|spec> — <Nome> (<nn>)

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Tipo | code | spec |
| Escopo | <tarefas T<n> ou arquivos da spec> |
| Status | Aberta |

## Objetivo
Responde: o que esta revisão verifica?
<uma frase>

## 1. <Área revisada>

<escopo da área em uma frase>

### 1.1. <Título do achado>

**Severidade:** média
**Local:** `<arquivo>:<linha>` ou `<arquivo>` § `<seção>`

<problema encontrado>

**Impacto:** <efeito concreto>

**Recomendação:** <ação>

### 1.2. <Título do achado>

---

## 2. <Área revisada>
```

## Áreas de revisão de código

Cobrir, nesta ordem:
1. Atendimento aos `CA<n>` e ao escopo da spec.
2. Contrato público e compatibilidade (`protocols/api-compatibility.md`).
3. Contrato CSS e tokens (`.ai/rules/css-contract.md`, `.ai/rules/tokens.md`).
4. Anatomia do componente (`.ai/rules/component-anatomy.md`).
5. Acessibilidade.
6. Testes: armadilhas de `.ai/rules/testing.md`, prova de falha, cobertura dos `CA<n>`.
7. Demo, Storybook, JSDoc e exports.

## Áreas de revisão de spec

Cobrir, nesta ordem:
1. Critério de aceite observável e completo.
2. Contradição entre `req`, `ds`, `dec`, `tasks` e `test`.
3. Decisão material sem `DC<n>`.
4. `CA<n>` sem `TC<n>` ou sem `T<n>`.
5. Aderência a `.ai/rules/`.
6. Riscos sem mitigação.

## Regras deste documento

- Verificar cada afirmação no código ou na spec antes de registrá-la.
- Não registrar achado sem local e sem recomendação.
- Não corrigir o artefato revisado dentro da revisão.
- Registrar no topo `Status: Avaliada` somente quando existir o `aval-` correspondente.

## Checklist final

- [ ] Todas as áreas listadas cobertas.
- [ ] Todo achado tem severidade, local, impacto e recomendação.
- [ ] Nenhum achado sem verificação.
