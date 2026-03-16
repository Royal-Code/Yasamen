# Instrução Operacional — Planejar uma Spec

> Use este arquivo como base em novos chats para que a IA planeje uma spec em colaboração com o utilizador, por etapas, com gates explícitos de aprovação.

## Objetivo

Quando o utilizador pedir para planejar uma spec, a IA deve conduzir um processo incremental, humano-no-loop, antes de fechar `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.

Este fluxo existe para reduzir ambiguidades cedo, em vez de produzir uma spec inteira de uma vez.

## Quando Usar

Use este fluxo quando o utilizador quiser:

- planejar uma spec nova com discussão em etapas;
- decidir pontos de arquitetura antes de fixar a spec;
- construir a spec com gates de aprovação humana;
- escolher a próxima spec e já começar o planeamento em seguida.

Se o utilizador já quiser a spec pronta em um passo só, use `create-spec.md`.

## Relação com Outras Instruções

Se o utilizador disser algo como:

- `quero planejar a próxima spec`

então a IA deve:

1. aplicar primeiro `.ai/instructions/select-next-spec.md`;
2. propor o alvo recomendado;
3. após aprovação do alvo, entrar neste fluxo de planeamento.

Se o utilizador já informar o nome da spec, este fluxo pode começar diretamente.

## Fontes Obrigatórias

Antes de iniciar o Gate 1, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/ui-map/ui-plan.md`
- `.ai/specs/_template/requirements.md`
- `.ai/specs/_template/design.md`
- `.ai/specs/_template/tasks.md`
- `.ai/specs/_template/delivery.md`
- os guides claramente aplicáveis ao tema

Se a pasta da spec já existir, a IA deve ler também:

- `.ai/specs/<nome-da-spec>/requirements.md`
- `.ai/specs/<nome-da-spec>/design.md`
- `.ai/specs/<nome-da-spec>/tasks.md`
- `.ai/specs/<nome-da-spec>/delivery.md`

## Regra de Colaboração

Este fluxo é orientado por gates.

Em cada gate, a IA deve:

1. apresentar uma proposta curta e concreta;
2. listar decisões, impactos e dúvidas reais;
3. fazer uma pergunta objetiva ao utilizador;
4. esperar aprovação antes de avançar para o próximo gate.

Regra prática:

- preferir 1 pergunta curta por gate;
- só perguntar o que realmente muda escopo, arquitetura ou custo;
- quando houver uma opção claramente melhor, recomendá-la explicitamente.

Se o utilizador disser para assumir a recomendação, a IA pode seguir e deve registrar a decisão na spec.

## Gates Obrigatórios

### Gate 0 — Escolha do Alvo

Objetivo:

- definir qual spec será planejada.

Saída esperada:

- nome da spec;
- ligação com `ui-map.md`;
- fase e prioridade em `ui-plan.md`;
- tipo da spec: componente, infraestrutura, docs, showcase ou transversal.

Se o alvo não estiver definido, usar `select-next-spec.md` antes de seguir.

Nenhum arquivo deve ser criado antes da aprovação deste gate.

### Gate 1 — Problema, Objetivo e Escopo Macro

Objetivo:

- alinhar o problema que a spec resolve;
- definir objetivo, escopo macro e fora de escopo inicial.

Saída esperada:

- rascunho dos metadados;
- objetivo da spec;
- escopo macro;
- fora de escopo inicial;
- risco principal.

Após aprovação:

- criar a pasta `.ai/specs/<nome-da-spec>/`, se ainda não existir;
- criar ou atualizar `requirements.md`;
- registrar `Status: Rascunho`.

### Gate 2 — UX, Casos de Uso e Critérios de Aceite

Objetivo:

- definir o comportamento esperado do ponto de vista do consumidor.

Saída esperada:

- casos de uso principais;
- requisitos funcionais;
- acessibilidade e responsividade;
- showcase obrigatório;
- critérios de aceite testáveis.

Após aprovação:

- atualizar `requirements.md`.

### Gate 3 — Estrutura Técnica e Arquitetura

Objetivo:

- fechar pacote, namespaces, dependências e estrutura interna.

Saída esperada:

- pacote sugerido;
- namespaces públicos e internos;
- referências diretas prováveis;
- relação com serviços, outlets, forms ou infra existente;
- estratégia de CSS;
- risco técnico principal.

Após aprovação:

- criar ou atualizar `design.md`.

### Gate 4 — API Pública e Contrato de Implementação

Objetivo:

- tornar a spec implementável por outra IA ou por um desenvolvedor.

Saída esperada:

- componentes públicos;
- parâmetros;
- eventos;
- estados;
- comportamento em bordas;
- contrato visual;
- plano de showcase no Docs;
- validação esperada.

Após aprovação:

- aprofundar `design.md`;
- ajustar `requirements.md` se necessário.

### Gate 5 — Plano de Execução

Objetivo:

- transformar a spec em trabalho executável.

Saída esperada:

- checklist de `tasks.md`;
- estratégia de testes;
- critérios de conclusão;
- preparação de `delivery.md`;
- pendências ainda abertas, se houver.

Após aprovação:

- criar ou atualizar `tasks.md`;
- criar ou atualizar `delivery.md`.

### Gate 6 — Fechamento do Planeamento

Objetivo:

- consolidar a spec e declarar sua prontidão.

Saída esperada:

- resumo final do que foi decidido;
- pontos ainda em aberto;
- avaliação: pronta para `create-spec`, `refine-spec` ou `implement-spec`.

Se a spec já estiver suficientemente fechada, a recomendação final tende a ser `implement-spec`.

## Regras de Edição

- Não implementar o componente durante este fluxo.
- Não preencher toda a spec antes dos gates serem aprovados.
- Não sobrescrever trabalho existente sem ler e preservar o contexto atual.
- Cada aprovação deve virar documentação concreta nos arquivos da spec.

## Formato Esperado das Mensagens em Cada Gate

Estrutura recomendada:

1. `Gate X — Nome`
2. `Proposta`
3. `Decisões`
4. `Pontos em aberto`
5. `Pergunta`

## Regras de Qualidade

- Usar sempre acentuação.
- Evitar perguntas genéricas ou abertas demais.
- Não travar o fluxo por detalhes menores; apresentar recomendação.
- Registrar na spec as decisões aprovadas a cada etapa.
- Se surgir divergência relevante com os guides, explicitar isso antes de avançar.

## Formato Esperado da Resposta Final

Ao concluir o planeamento, a IA deve responder de forma curta com:

1. a spec planejada;
2. o que foi decidido nos gates;
3. o que ainda ficou em aberto, se houver;
4. qual deve ser o próximo comando: `create-spec`, `refine-spec` ou `implement-spec`.

## Prompts Curtos Recomendados

```text
Leia `.ai/instructions/plan-spec.md` e planeje a spec `search-field`.
```

Ou:

```text
Leia `.ai/instructions/plan-spec.md` e planeje a próxima spec.
```

Ou:

```text
Leia `.ai/instructions/plan-spec.md` e planeje a spec `pagination` em etapas, com gates.
```
