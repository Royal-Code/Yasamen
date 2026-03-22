---
name: lib-spec
description: Use quando estiver a trabalhar neste repositório com specs de biblioteca, componentes ou pacotes no fluxo `.ai/lib-spec.md`, incluindo escolher a próxima spec, planejar, criar, refinar, implementar uma lib spec ou decidir quando criar um novo projeto de biblioteca.
---

# Lib Spec

## Visão geral

Use este skill quando o pedido envolver componente novo, pacote novo, `lib spec` existente ou priorização da próxima spec da biblioteca. Ele aplica o fluxo `spec-first` do repositório, consulta o backlog correto e decide quando parar em planeamento, quando refinar a spec e quando seguir para implementação.

## Fluxo de decisão

1. Classifique a intenção do pedido:
- escolher a próxima spec;
- planejar uma spec;
- criar uma spec;
- refinar uma spec;
- implementar uma spec;
- criar um pacote ou projeto;
- ajustar implementação existente.

2. Leia sempre:
- `.ai/lib-spec.md`

3. Carregue as fontes adicionais conforme o cenário:
- Priorização ou escolha da próxima spec:
  - `.ai/roadmap/components-plan-list.md`
  - `.ai/roadmap/ui-plan.md`
  - `.ai/ui-map/ui-map.md`
  - `.ai/instructions/flows/expand/select-next-spec.md`
- Planeamento:
  - `.ai/instructions/flows/expand/plan-spec.md`
- Criação de spec:
  - `.ai/instructions/flows/expand/create-spec.md`
- Refinamento:
  - `.ai/instructions/flows/expand/refine-spec.md`
- Implementação:
  - `.ai/instructions/flows/expand/implement-spec.md`
- Criação de pacote ou projeto:
  - `.ai/instructions/expand/create-library-project.md`

4. Em qualquer fluxo de componente ou pacote, feche os checkpoints de:
- `.ai/guides/expand/cross-cutting-component-decisions.md`

## Regras operacionais

- Preserve o fluxo orientado por spec para componente novo.
- Via `.ai/lib-spec.md`, o padrão é `spec-first` para componente, pacote e biblioteca.
- Trate criação de pacote como subfluxo técnico quando ela surgir do `design.md`.
- Só parta para scaffolding direto quando o utilizador pedir isso explicitamente ou chamar a instrução técnica dedicada.
- Quando houver `lib spec` existente madura, você pode implementá-la diretamente.
- Quando o utilizador pedir ajuste em implementação existente, não crie spec nova por reflexo.
- Em pedidos de componente novo, consulte sempre:
  - `.ai/roadmap/components-plan-list.md`
  - `.ai/roadmap/ui-plan.md`
  - `.ai/ui-map/ui-map.md`
- Em pedidos de ajuste, deixe explícito se está:
  - corrigindo implementação;
  - corrigindo design da spec;
  - ampliando escopo.
- Em execução de spec com comportamento observável ou showcase, só considere a spec `Concluída` após aceite humano explícito dos testes previstos; antes disso, o estado deve permanecer aberto ou como `Aguardando validação humana`.
- Depois de criar ou refinar uma `lib spec`, execute revisão por subagente quando o ambiente suportar essa capacidade.
- Use sempre acentuação.

## Roteamento prático

### Escolher a próxima spec

Use quando o pedido for do tipo:
- `qual deve ser a próxima spec`
- `qual o próximo passo`

Ação:
- ler backlog, cobertura e instrução de seleção;
- cruzar criticidade do `ui-map` com o backlog do roadmap;
- devolver a melhor próxima spec e a justificativa.

### Planejar uma spec

Use quando o pedido for do tipo:
- `planeje a spec x`
- `quero planejar a próxima spec`

Ação:
- se o alvo ainda não estiver claro, primeiro selecione a melhor próxima spec;
- depois use o fluxo de planeamento.

### Criar ou refinar uma spec

Use quando o pedido for do tipo:
- `crie a spec x`
- `refine a spec x`
- `fortaleça a spec x`

Ação:
- criar ou endurecer `requirements.md`, `design.md`, `tasks.md` e `delivery.md`;
- garantir coerência com a arquitetura atual da biblioteca;
- incorporar checkpoints transversais antes de encerrar.

### Implementar uma spec

Use quando o pedido for do tipo:
- `implemente a spec x`
- `execute a spec x`

Ação:
- confirmar que a spec está madura o suficiente;
- se estiver mole, refinar primeiro;
- se estiver pronta, implementar diretamente.

### Criar pacote ou projeto

Use quando o pedido for do tipo:
- `crie o projeto x`
- `crie o pacote x`

Ação:
- manter `spec-first` por padrão;
- tratar a criação do projeto como consequência do design, não como palpite inicial.

### Ajustar implementação existente

Use quando o pedido for do tipo:
- `não gostei da implementação da spec x`
- `corrija esta entrega`

Ação:
- se o comportamento esperado não mudou, ajustar implementação;
- se API, composição ou escopo mudaram, refinar a spec antes de reimplementar.

## Encerramento obrigatório

Depois de criar, refinar ou planejar uma `lib spec`, termine com um próximo passo recomendado:

- `refine lib-spec`
- `implement lib-spec`
- `create-library-project`

## Exemplos de uso

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Quero planejar a próxima spec.
```

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Crie a spec do componente `search-field`.
```

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Implemente a spec `pagination`.
```

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Quero um novo pacote `RoyalCode.Razor.Navigation`; feche a spec antes de preparar o projeto.
```
