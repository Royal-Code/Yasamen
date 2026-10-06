# Template: `test-{slug}.md`

Caminho: `.ai/specs/spec-{slug}/test-{slug}.md`.

Regras do template:
- Gerar o documento sem marcador, sem `Responde:` e sem placeholder deste template.
- Numerar casos como `TC<n>`, a partir do próximo ID de `dec-{slug}.md`.
- Escrever `Prova de falha` como `*a fazer*` até o teste ser implementado.
- Seguir `.ai/rules/testing.md`.

## Shape

```md
# Testes — <Nome>

| Campo | Valor |
|---|---|
| Spec | spec-<slug> |
| Arquivo de teste | src/lib/components/<dominio>/__tests__/<Nome>.spec.tsx |

## Estratégia

[DERIVAR]
Responde: quais camadas L1, L2 e L3 cobrem a spec?
- **L1:** <o que cobre>
- **L2:** <o que cobre ou N/A>
- **L3:** <o que cobre>

## Casos de teste

### TC<n> — <nome como comportamento observável>
- **Atende:** CA<n>
- **Camada:** L1 | L2 | L3
- **Cenário:** <preparação, ação, resultado esperado>
- **Falha que pega:** <defeito concreto>
- **Prova de falha:** *a fazer*

### TC<n> — <nome>
- **Atende:** CA<n>
- **Camada:** L1
- **Cenário:** <descrição>
- **Falha que pega:** <defeito concreto>
- **Prova de falha:** *a fazer*

## Cobertura obrigatória

- [ ] Renderização base e classes aplicadas
- [ ] Cada prop pública
- [ ] Cada tema e tamanho suportado
- [ ] Estados desabilitado, vazio e erro
- [ ] Eventos e `navigateTo`
- [ ] Teclado e foco
- [ ] Bordas: primeiro e último tamanho, lista vazia, lista com um item

## Verificação manual

- **V<n>:** <o que o humano confere na demo ou no Storybook> — **Rota:** <caminho>

## Resultado

*a fazer*
```

## Regras deste documento

- Fazer cada `TC<n>` referenciar pelo menos um `CA<n>`.
- Preencher `Prova de falha` com a mutação aplicada e a quantidade de testes que caíram.
- Não marcar teste como pronto sem `Prova de falha` preenchida.
- Marcar item sem teste automatizado possível como verificação manual `V<n>`.

## Checklist final

- [ ] Todo `CA<n>` tem pelo menos um `TC<n>`.
- [ ] Todo `TC<n>` declara camada e falha que pega.
- [ ] Nenhum `TC<n>` de efeito visual está só em L1.
- [ ] Armadilhas de `.ai/rules/testing.md` conferidas.
