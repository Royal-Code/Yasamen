# Template: `dec-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/dec-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:` e sem placeholder deste template.
- Manter `Próximos IDs` atualizado a cada ID criado.
- Escrever uma questão por bloco `Q<n>`, com opções `A`, `B`, `C`.
- Escrever consequência concreta em cada opção.
- Manter questão respondida. Marcar `[x]` e registrar o `DC<n>` resultante.
- Escrever `*a fazer*` na resposta de questão aberta.

## Shape

```md
# Decisões — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Próximos IDs | DC<n>, Q<n>, CA<n>, T<n>, R<n>, V<n>, TC<n> |

## Questões

- [ ] **Q<n> — <título>**
  - **Status:** aberta
  - **Decide:** <o que o humano decide>
  - **Contexto:** <uma ou duas linhas>
  - **A:** <opção> — **Consequência:** <efeito concreto>
  - **B:** <opção> — **Consequência:** <efeito concreto>
  - **Recomendação:** <opção e motivo curto>
  - **Resposta:** *a fazer*

- [x] **Q<n> — <título>**
  - **Status:** respondida
  - **Decide:** <o que o humano decide>
  - **Resposta:** <opção escolhida>
  - **Vira:** DC<n>

## Decisões confirmadas

- [x] **DC<n>:** <decisão> — **Origem:** Q<n> — **Data:** <AAAA-MM-DD>
- [x] **DC<n>:** <decisão> — **Origem:** humano — **Data:** <AAAA-MM-DD>

## Descartadas

- **Q<n>:** <motivo curto>
```

## Regras deste documento

- Fazer a pergunta ao humano na conversa. Registrar no arquivo não basta.
- Não tratar `Resposta: *a fazer*` como aprovação.
- Não alterar `DC<n>` confirmada. Criar nova `DC<n>` que substitui e citar a anterior.
- Fechar `Q<n>` somente com resposta do humano.

## Checklist final

- [ ] Toda `Q<n>` aberta foi apresentada ao humano na conversa.
- [ ] Toda `Q<n>` respondida aponta para uma `DC<n>`.
- [ ] `Próximos IDs` confere com os IDs usados na spec.
