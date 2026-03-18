# Execução e Conclusão de Specs

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
- se os checkpoints transversais aplicáveis estão realmente fechados;
- se os guides impõem alguma restrição ainda ausente na spec;
- se há gaps de pacote, CSS, showcase, DI ou testes.

### 3. Implementação

Implementar apenas o que está dentro do escopo aprovado.

### 4. Validação

Toda implementação deve ser validada com evidência.

Validação mínima esperada:

- `dotnet build` do projeto ou solução afetada;
- testes automatizados aplicáveis;
- validação manual do showcase no `Docs.Client`, quando houver UI;
- revisão do impacto em `ui-map.md` e `ui-plan.md`, quando aplicável.

### 5. Validação visual com Playwright MCP

Quando houver UI relevante, a IA deve tentar uma validação visual adicional.

Regra:

1. verificar se o MCP do Playwright está disponível;
2. se estiver disponível:
   - abrir a página ou rota do showcase;
   - validar o comportamento visual;
   - tirar screenshots quando isso fizer parte do fluxo da entrega;
3. se não estiver disponível:
   - não inventar a validação;
   - registrar a limitação em `delivery.md`;
   - informar explicitamente isso no resumo final ao desenvolvedor.

Se houver screenshots, elas devem ser tratadas como artefato de evidência.

### 6. Revisão de código

Depois de implementar e validar, a própria IA deve revisar o diff em modo reviewer.

### 7. Encerramento

Só então:

- preencher `delivery.md`;
- marcar `tasks.md`;
- atualizar o status da spec;
- declarar a entrega como concluída ou parcial.

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

Se houve tentativa de validação visual:

- [ ] a disponibilidade do Playwright MCP foi verificada;
- [ ] a evidência visual foi registrada ou a indisponibilidade foi justificada.

---

## Regras para IA

Se uma IA receber uma spec para implementar, a sequência correta é:

1. ler a spec e os guides;
2. corrigir inconsistências óbvias da própria spec;
3. implementar;
4. validar;
5. tentar validação visual quando houver UI relevante;
6. revisar o próprio trabalho criticamente;
7. preencher `delivery.md`;
8. fechar `tasks.md`;
9. atualizar status e artefatos derivados.




