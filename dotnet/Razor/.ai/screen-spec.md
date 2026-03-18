# Orquestrador de Screen Specs

> Use este arquivo como ponto único de entrada para planejar telas, criar ou refinar `screen specs` e analisar gaps de implementação a partir de requisitos de página.

## Escopo

Este orquestrador trata:

- telas novas;
- alteração de telas existentes;
- escolha de `Page Pattern`;
- composição por zonas;
- seleção de `UIP-*`;
- mapeamento para Yasamen;
- geração de `screen spec`.

Ele não substitui `.ai/lib-spec.md`.

Se o problema estiver no nível estrutural do app consumidor, usar `.ai/app-spec.md` antes de detalhar telas.

Regra:

- `.ai/lib-spec.md` continua para componentes, pacotes e specs técnicas;
- `.ai/screen-spec.md` passa a ser a entrada para telas e páginas.

---

## Roteamento de Intenções

### 1. Planejar uma tela nova

Pedido típico:

- `quero planejar a tela x`
- `planeje a página x`

Fluxo:

- `.ai/instructions/flows/screens/plan-screen.md`

Regra:

- usar este fluxo quando o utilizador quiser planeamento explícito por gates;
- se a informação já for suficiente para abrir a `screen spec`, preferir `.ai/instructions/flows/screens/create-screen-spec.md`.

### 2. Criar uma screen spec

Pedido típico:

- `crie a screen spec x`
- `gere a spec da tela x`

Fluxo:

- `.ai/instructions/flows/screens/create-screen-spec.md`

Regra:

- este é o fluxo preferencial quando o utilizador quer “planejar” uma tela e já há informação suficiente para materializar a spec;
- se faltar informação, pedir lista enumerada do que falta para preencher os campos essenciais da spec.

### 3. Refinar uma screen spec existente

Pedido típico:

- `refine a screen spec x`
- `fortaleça a spec da tela x`

Fluxo:

- `.ai/instructions/flows/screens/refine-screen-spec.md`

### 4. Alterar uma tela existente

Pedido típico:

- `quero alterar a tela x`
- `mude a página x`

Fluxo:

- se já existir `screen spec`:
  - `.ai/instructions/flows/screens/refine-screen-spec.md`
- se não existir:
  - capturar `As-Is`;
  - criar a screen spec;
  - registrar o `To-Be`.

Regra:

- alteração de tela existente deve começar pelo retrato do estado atual.

### 5. Analisar gaps de componentes a partir de uma tela

Pedido típico:

- `esta tela precisa de quais componentes`
- `mapeie esta página para Yasamen`

Fluxo:

- `.ai/instructions/flows/screens/plan-screen.md`, com foco em `Page Pattern`, `UIP-*` e mapeamento.

---

## Regras de Qualidade

- Usar sempre acentuação.
- Não inventar `UIP-*` local.
- Usar `.ai/ui-map/catalogo-ui.md` como base agnóstica.
- Usar `.ai/ui-map/ui-map.md` como adapter tecnológico para Yasamen.
- Fechar os checkpoints de `.ai/guides/rules/cross-cutting-screen-decisions.md`.
- Se shell, layout, navegação ou convenções locais do app ainda estiverem indefinidos, escalar para `.ai/app-spec.md`.
- Consultar backlog, roadmap ou mapa local de gaps quando isso existir.
- Neste repositório, usar `.ai/roadmap/components-plan-list.md` e `.ai/roadmap/ui-plan.md` como referência padrão para dependências reveladas pela tela.
- Tratar gaps de tela e gaps de componente como coisas diferentes.
- Jornadas e capacidades podem ser lidas se existirem, mas não bloqueiam o fluxo nesta versão.
- Não responder só com explicação do fluxo quando já for possível abrir ou refinar a `screen spec`.
- Quando faltar informação, pedir lista enumerada única do que precisa ser conhecido para continuar.

---

## Exemplos de Uso

```text
Leia `.ai/screen-spec.md` e quero planejar a tela de listagem de clientes.
```

```text
Leia `.ai/screen-spec.md` e crie a screen spec `customers-list-page`.
```

```text
Leia `.ai/screen-spec.md` e refine a screen spec `orders-detail-page`.
```

```text
Leia `.ai/screen-spec.md` e quero alterar a tela existente `orders/detail`; primeiro registre o estado atual e depois proponha a mudança.
```

