# Orquestrador de Specs

> Use este arquivo como ponto único de entrada em novos chats para que a IA escolha e aplique o fluxo correto de specs.

## Objetivo

O objetivo deste arquivo é permitir prompts curtos como:

```text
Leia `.ai/spec.md` e quero planejar a próxima spec.
```

ou:

```text
Leia `.ai/spec.md` e implemente a spec `pagination`.
```

Ao ler este arquivo, a IA deve identificar a intenção do utilizador e, em seguida, aplicar a instrução operacional correta em `.ai/instructions/`.

## Roteamento de Intenções

### 1. Escolher a próxima spec

Se o utilizador pedir algo como:

- `qual deve ser a próxima spec`
- `qual o próximo passo`
- `diga se devo criar, refinar ou implementar`

então a IA deve aplicar:

- `.ai/instructions/select-next-spec.md`

### 2. Planejar a próxima spec

Se o utilizador pedir algo como:

- `quero planejar a próxima spec`
- `vamos definir a próxima spec`

então a IA deve:

1. aplicar `.ai/instructions/select-next-spec.md`;
2. propor o alvo principal;
3. após aprovação do utilizador, aplicar `.ai/instructions/plan-spec.md`.

### 3. Planejar uma spec específica

Se o utilizador pedir algo como:

- `planeje a spec x`
- `vamos planejar a spec x`
- `quero definir a spec x com gates`

então a IA deve aplicar:

- `.ai/instructions/plan-spec.md`

### 4. Criar uma spec completa

Se o utilizador pedir algo como:

- `crie a spec x`
- `gere a spec x`

então a IA deve aplicar:

- `.ai/instructions/create-spec.md`

### 5. Refinar uma spec existente

Se o utilizador pedir algo como:

- `refine a spec x`
- `fortaleça a spec x`
- `revise a spec x`

então a IA deve aplicar:

- `.ai/instructions/refine-spec.md`

### 6. Implementar uma spec

Se o utilizador pedir algo como:

- `implemente a spec x`
- `execute a spec x`

então a IA deve aplicar:

- `.ai/instructions/implement-spec.md`

## Regras de Roteamento

- A IA deve ler apenas as instruções necessárias para a intenção pedida.
- Se a intenção exigir mais de uma instrução, usar a sequência mínima necessária.
- Se o nome da spec não for informado e ele for necessário, a IA deve:
  - usar `select-next-spec.md`, quando isso fizer sentido;
  - ou pedir uma pergunta curta e objetiva ao utilizador.

## Fluxos Compostos Permitidos

### Fluxo A — Seleção + Planeamento

Pedido:

```text
Leia `.ai/spec.md` e quero planejar a próxima spec.
```

Sequência:

1. `select-next-spec.md`
2. aprovação do alvo
3. `plan-spec.md`

### Fluxo B — Planeamento de Spec Específica

Pedido:

```text
Leia `.ai/spec.md` e quero planejar a spec `search-field`.
```

Sequência:

1. `plan-spec.md`
2. seguir os gates e atualizar a spec gradualmente

### Fluxo C — Seleção + Implementação

Pedido:

```text
Leia `.ai/spec.md` e diga qual spec devo implementar agora.
```

Sequência:

1. `select-next-spec.md`
2. se o utilizador aprovar, próximo comando recomendado: `implement-spec.md`

## Relação com os Arquivos de Spec

A IA deve assumir a convenção:

- `.ai/specs/<nome-da-spec>/requirements.md`
- `.ai/specs/<nome-da-spec>/design.md`
- `.ai/specs/<nome-da-spec>/tasks.md`
- `.ai/specs/<nome-da-spec>/delivery.md`

## Regras de Qualidade

- Usar sempre acentuação.
- Não misturar planeamento colaborativo com implementação sem pedido explícito.
- Não iniciar implementação quando o utilizador pediu planeamento.
- Em fluxos com gates, esperar aprovação do utilizador entre etapas.
- Quando houver recomendação clara, apresentá-la antes de abrir a pergunta.

## Exemplos de Uso

Escolher o próximo passo:

```text
Leia `.ai/spec.md` e diga qual deve ser a próxima spec.
```

Planejar a próxima spec:

```text
Leia `.ai/spec.md` e quero planejar a próxima spec.
```

Planejar uma spec específica:

```text
Leia `.ai/spec.md` e planeje a spec `filter-panel`.
```

Criar uma spec de uma vez:

```text
Leia `.ai/spec.md` e crie a spec `date-picker`.
```

Refinar:

```text
Leia `.ai/spec.md` e refine a spec `tabs`.
```

Implementar:

```text
Leia `.ai/spec.md` e implemente a spec `pagination`.
```
