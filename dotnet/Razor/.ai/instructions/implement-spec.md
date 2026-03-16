# Instrução Operacional — Implementar uma Spec

> Use este arquivo como base em novos chats para que a IA execute uma spec completa, do planeamento ao encerramento.

## Objetivo

Quando o utilizador pedir para implementar uma spec `<nome-da-spec>`, a IA deve assumir que a spec está localizada em:

```text
.ai/specs/<nome-da-spec>/
```

E deve executar a entrega completa, não apenas analisar.

## Arquivos da Spec

Para a spec `<nome-da-spec>`, a IA deve localizar e ler:

- `.ai/specs/<nome-da-spec>/requirements.md`
- `.ai/specs/<nome-da-spec>/design.md`
- `.ai/specs/<nome-da-spec>/tasks.md`
- `.ai/specs/<nome-da-spec>/delivery.md`

Se algum desses arquivos não existir:

- a IA deve informar o problema claramente;
- parar apenas se o ficheiro ausente impedir a execução segura;
- corrigir a ausência quando isso for claramente parte do fluxo documental esperado.

## Guides Obrigatórios

A IA deve ler todos os guides listados em `Guides aplicados` na spec.

Além disso:

- se a spec envolver showcase ou documentação, aplicar `09-showcases-and-docs.md`;
- em qualquer execução completa de spec, aplicar `10-spec-execution-and-delivery.md`.

## Fluxo Obrigatório

### 1. Leitura

- Ler os 4 arquivos da spec.
- Ler os guides aplicados.
- Identificar projetos, pacotes, showcases, testes e artefatos impactados.

### 2. Checagem de consistência

Antes de implementar, verificar:

- coerência entre `requirements.md` e `design.md`;
- cobertura das tasks em relação ao design;
- aderência da spec aos guides;
- gaps documentais pequenos que possam ser corrigidos imediatamente.

Se houver inconsistência pequena e a intenção estiver clara:

- corrigir a própria spec antes de codar.

Se houver ambiguidade séria ou decisão de alto impacto:

- interromper e pedir decisão ao utilizador.

### 3. Implementação

- Implementar a spec de forma end-to-end.
- Não parar apenas em plano ou análise.
- Respeitar escopo, design, guides e padrão de CSS/showcase.
- Se necessário, atualizar a spec para refletir decisões pequenas e objetivas descobertas durante a implementação.

### 4. Showcase

Se a spec exigir showcase:

- criar ou atualizar a página em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`;
- registrar rota e item em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`;
- seguir `09-showcases-and-docs.md`.

### 5. Validação

Executar as validações previstas na spec, incluindo quando aplicável:

- `dotnet build`;
- `dotnet test`;
- validação manual do showcase;
- revisão do impacto em `ui-map.md` e `ui-plan.md`.

Se alguma validação não puder ser executada:

- registrar isso claramente em `delivery.md`;
- mencionar o motivo no resumo final.

### 6. Revisão de código

Depois da implementação e validação:

- revisar criticamente o próprio diff;
- procurar bugs, regressões, desvios dos guides, falta de testes e gaps no showcase;
- corrigir o que for razoável antes de encerrar.

### 7. Encerramento documental

Ao final:

- preencher `delivery.md`;
- atualizar `tasks.md`, marcando o que foi concluído;
- atualizar o status da spec;
- atualizar `requirements.md` e `design.md` se houver correções documentais necessárias;
- atualizar `ui-map.md` e `ui-plan.md` se a cobertura ou o roadmap mudarem.

## Definition of Done

A spec só pode ser dada como `Concluída` se:

- a implementação cobre o escopo aprovado;
- os critérios de aceite principais foram atendidos;
- build passou, ou a ausência foi justificada;
- testes relevantes foram executados, ou a ausência foi justificada;
- showcase foi criado/atualizado quando aplicável;
- `delivery.md` foi preenchido;
- `tasks.md` foi encerrado;
- a revisão de código foi feita;
- os artefatos derivados foram atualizados quando necessário.

Caso contrário, usar:

- `Parcial`
- ou `Bloqueada`

## Formato Esperado da Resposta Final

A resposta final da IA deve ser curta e conter:

1. o que foi implementado;
2. validações executadas;
3. pendências ou limitações;
4. status final da spec.

## Regras de Conduta

- Usar sempre acentuação.
- Não tratar a tarefa como brainstorming.
- Não devolver só um plano quando a implementação for viável.
- Só interromper por bloqueio real ou decisão ambígua de alto impacto.

## Prompt Curto Recomendado

```text
Leia `.ai/instructions/implement-spec.md` e implemente a spec `pagination`.
```

Ou:

```text
Leia `.ai/instructions/implement-spec.md` e execute a spec `docs-showcase-foundation`.
```
