# Guide 10 — Execução e Conclusão de Specs

> Como uma IA ou desenvolvedor deve pegar uma spec, implementar, validar, revisar e concluir a entrega de forma rastreável.

---

## Visão Geral

Uma spec só está realmente concluída quando há:

1. implementação;
2. validação;
3. revisão;
4. rastreabilidade entre guides, requirements, design e código;
5. encerramento formal da spec.

Sem isso, a spec vira apenas planeamento, não evidência de entrega.

---

## Artefatos Obrigatórios

Toda spec deve ter estes arquivos:

- `requirements.md`
- `design.md`
- `tasks.md`
- `delivery.md`

Papéis:

- `requirements.md`: define problema, escopo, critérios de aceite e showcase.
- `design.md`: define arquitetura, API, estrutura interna e decisões técnicas.
- `tasks.md`: define checklist de execução.
- `delivery.md`: prova o que foi feito, como foi validado e se a spec pode ser dada como concluída.

---

## Ciclo de Vida de Status

Status recomendados:

- `Rascunho`
- `Aprovada`
- `Em implementação`
- `Concluída`
- `Parcial`
- `Bloqueada`

Regra:

- o `requirements.md` pode refletir o estado macro da spec;
- o `delivery.md` registra o estado final da execução concreta;
- `Concluída` só pode ser usado quando os critérios mínimos de entrega forem atendidos.

---

## Fluxo Obrigatório de Execução

### 1. Leitura e alinhamento

Antes de implementar:

- ler `requirements.md`;
- ler `design.md`;
- ler `tasks.md`;
- ler os guides listados em `Guides aplicados`.

### 2. Checagem de consistência

Antes de escrever código, validar:

- se `requirements.md` e `design.md` não se contradizem;
- se o design cobre os requisitos principais;
- se os guides impõem alguma restrição ainda ausente na spec;
- se há gaps de pacote, CSS, showcase, DI ou testes.

Se houver conflito:

- corrigir a spec antes da implementação, quando isso for seguro e claro;
- ou registrar o conflito explicitamente e parar para decisão.

### 3. Implementação

Implementar apenas o que está dentro do escopo aprovado.

Se surgir desvio necessário:

- atualizar a spec;
- ou registrar o desvio em `delivery.md`.

### 4. Validação

Toda implementação deve ser validada com evidência.

Validação mínima esperada:

- `dotnet build` do projeto ou solução afetada;
- testes automatizados aplicáveis;
- validação manual do showcase no `Docs.Client`, quando houver UI;
- revisão do impacto em `ui-map.md` e `ui-plan.md`, quando aplicável.

### 5. Revisão de código

Depois de implementar e validar, a própria IA deve revisar o diff em modo reviewer.

A revisão deve procurar prioritariamente:

- bugs funcionais;
- regressões de comportamento;
- inconsistências com guides;
- CSS fora do padrão;
- API pública incoerente;
- falta de testes;
- gaps no showcase;
- divergência entre spec e implementação.

### 6. Encerramento

Só então:

- preencher `delivery.md`;
- marcar `tasks.md`;
- atualizar o status da spec;
- declarar a entrega como concluída ou parcial.

---

## Comparação Obrigatória: Guide x Requirements x Design x Código

Toda conclusão deve responder a quatro perguntas:

### 1. O código implementa o que os requirements pediam?

Se não:

- registrar o que ficou de fora;
- marcar `Parcial` se necessário.

### 2. O código respeita o design acordado?

Se houve desvio:

- justificar no `delivery.md`;
- apontar se o design precisa ser corrigido.

### 3. O código respeita os guides aplicados?

Se não:

- o desvio precisa ser explícito, justificado e raro.

### 4. As tasks foram realmente concluídas?

Task não verificada não deve ser marcada como concluída.

---

## Definition of Done

Uma spec pode ser marcada como `Concluída` quando:

- [ ] a implementação cobre o escopo acordado;
- [ ] os critérios de aceite principais foram atendidos;
- [ ] build executado com sucesso;
- [ ] testes relevantes executados ou ausência justificada;
- [ ] showcase criado ou atualizado no `Docs.Client`, quando aplicável;
- [ ] revisão de código feita;
- [ ] `delivery.md` preenchido;
- [ ] `tasks.md` encerrado;
- [ ] `ui-map.md` e `ui-plan.md` atualizados, quando a cobertura mudou.

Se algum ponto falhar, o estado mais honesto tende a ser:

- `Parcial`
- ou `Bloqueada`

---

## Estrutura Esperada de `delivery.md`

O `delivery.md` deve registrar:

1. status final;
2. resumo da entrega;
3. changelog da spec;
4. rastreabilidade entre guides, requirements, design e evidências;
5. validação executada;
6. revisão de código;
7. pendências ou riscos aceitos;
8. fechamento das tasks.

Ele não substitui commit, diff ou testes. Ele organiza a evidência da entrega.

---

## Regras para IA

Se uma IA receber uma spec para implementar, a sequência correta é:

1. ler a spec e os guides;
2. corrigir inconsistências óbvias da própria spec;
3. implementar;
4. validar;
5. revisar o próprio trabalho criticamente;
6. preencher `delivery.md`;
7. fechar `tasks.md`;
8. atualizar status e artefatos derivados.

O erro mais comum é parar na etapa 3.

---

## Quando Não Dar Como Concluída

Não marcar como concluída se:

- o showcase não foi feito e ele faz parte do escopo;
- os testes falharam;
- o build não passa;
- a implementação divergiu do design sem registro;
- ainda há tasks abertas essenciais;
- os critérios de aceite não foram comprovados.

---

## Checklist

- [ ] Li requirements, design, tasks e guides aplicados?
- [ ] Verifiquei conflitos internos da spec antes de implementar?
- [ ] Implementei apenas o escopo aprovado?
- [ ] Rodei build e testes aplicáveis?
- [ ] Validei o showcase, quando necessário?
- [ ] Revisei criticamente o diff?
- [ ] Preenchi `delivery.md`?
- [ ] Fechei `tasks.md` com honestidade?
- [ ] Atualizei status e artefatos derivados?
