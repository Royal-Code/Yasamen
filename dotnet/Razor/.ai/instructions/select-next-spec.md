# Instrução Operacional — Selecionar a Próxima Spec

> Use este arquivo como base em novos chats para que a IA analise o estado atual do planeamento e recomende qual spec deve ser criada, refinada ou implementada a seguir.

## Objetivo

Quando o utilizador pedir para escolher a próxima spec, a IA deve analisar o estado atual da solução e recomendar o próximo melhor passo, em vez de responder apenas com opinião solta.

A IA deve considerar três possibilidades:

1. **criar** uma spec nova;
2. **refinar** uma spec existente;
3. **implementar** uma spec já pronta.

## Fontes Obrigatórias

Antes de recomendar o próximo passo, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/ui-map/ui-plan.md`
- `.ai/specs/` para identificar specs já existentes
- `.ai/guides/09-showcases-and-docs.md`, se houver impacto em Docs/showcase
- `.ai/guides/10-spec-execution-and-delivery.md`

Se existirem documentos relevantes em `.ai/a_fazer/` ou `.ai/a_fazer/feito/` ligados ao tema, a IA pode usá-los como apoio, mas sem substituir `ui-map.md` e `ui-plan.md` como fonte principal.

## Pergunta que a IA Deve Responder

A IA deve responder, de forma fundamentada:

- qual é o próximo melhor alvo;
- se o próximo passo é `create-spec`, `refine-spec` ou `implement-spec`;
- por que esse alvo é melhor do que as alternativas imediatas.

## Critérios de Decisão

### 1. Prioridade no `ui-plan.md`

Itens `P1` tendem a vir antes de `P2`, `P3` e `P4`.

### 2. Cobertura atual no `ui-map.md`

Quanto menor a nota atual do padrão coberto, maior a urgência potencial.

### 3. Poder de desbloqueio

Priorizar itens que destravam outros:

- `Pagination` destrava `DataGrid`;
- `SearchField` destrava busca em listagens e no `AppMenu`;
- `Skeleton` destrava estados de loading em vários componentes.

### 4. Existência e maturidade da spec

Entre dois alvos parecidos, a tendência é:

- implementar uma spec já madura;
- refinar uma spec existente mas fraca;
- criar spec nova só quando o gap ainda não tiver spec.

### 5. Coerência de pacote e infraestrutura

Se uma decisão estrutural ainda estiver em aberto, pode ser melhor:

- refinar antes de implementar;
- ou criar uma spec de infraestrutura primeiro.

Exemplo:

- antes de multiplicar showcases, pode fazer sentido priorizar `docs-showcase-foundation`.

### 6. Custo e risco

Se dois itens têm prioridade próxima, preferir o que:

- tem menos dependências ocultas;
- cabe melhor no estado atual do repositório;
- produz ganho claro com risco controlado.

## Fluxo Obrigatório

### 1. Mapear o backlog real

A IA deve separar:

- itens do plano sem spec;
- specs já abertas;
- specs prontas para implementação;
- specs que ainda precisam de refinamento.

### 2. Classificar o próximo tipo de ação

A IA deve escolher uma das três ações:

- `Criar spec`
- `Refinar spec`
- `Implementar spec`

### 3. Sugerir um alvo principal e alternativas

A resposta deve conter:

- **1 recomendação principal**
- **até 2 alternativas**

### 4. Justificar com base documental

A recomendação deve citar:

- fase e prioridade do `ui-plan.md`;
- nota/gap do `ui-map.md`;
- dependências ou desbloqueios;
- se já existe ou não spec para o alvo.

## Formato Esperado da Resposta

A IA deve responder com algo como:

1. **Próximo melhor passo:** implementar/refinar/criar a spec `x`.
2. **Justificativa curta:** prioridade, cobertura, desbloqueio e estado da spec.
3. **Alternativas próximas:** `y` e `z`, com motivo resumido.
4. **Prompt recomendado:** qual arquivo de instrução usar em seguida.

## Regras de Qualidade

- Usar sempre acentuação.
- Não sugerir item fora de `ui-plan.md` ou `ui-map.md` sem justificar claramente.
- Não ignorar specs já existentes.
- Não sugerir implementação de spec claramente imatura sem antes apontar o refinamento necessário.
- Não devolver lista longa e genérica; priorizar decisão.

## Prompt Curto Recomendado

```text
Leia `.ai/instructions/select-next-spec.md` e diga qual deve ser a próxima spec.
```

Ou:

```text
Leia `.ai/instructions/select-next-spec.md` e diga se o próximo passo deve ser criar, refinar ou implementar alguma spec.
```

Ou:

```text
Leia `.ai/instructions/select-next-spec.md` e recomende a próxima spec com base no `ui-map.md`, `ui-plan.md` e nas specs já existentes.
```
