# Orquestrador de Lib Specs

> Use este arquivo como ponto único de entrada para specs de componentes, pacotes e bibliotecas da solução Yasamen.

## Escopo

Este orquestrador trata:

- escolha da próxima spec de biblioteca;
- planeamento de spec de componente;
- criação e refinamento de `lib specs`;
- implementação de `lib specs`;
- decisão e preparação de pacote ou projeto de biblioteca quando isso surgir no fluxo;
- ajuste de implementações existentes.

Ele não substitui `.ai/screen-spec.md`.

Regra:

- `.ai/lib-spec.md` é a entrada para componentes, pacotes e bibliotecas;
- `.ai/screen-spec.md` é a entrada para telas e páginas.

---

## Roteamento de Intenções

### 1. Escolher a próxima lib spec

Pedido típico:

- `qual deve ser a próxima spec`
- `qual o próximo passo`

Fluxo:

- `.ai/instructions/flows/expand/select-next-spec.md`

### 2. Planejar uma lib spec

Pedido típico:

- `quero planejar a próxima spec`
- `planeje a spec x`

Fluxo:

- `.ai/instructions/flows/expand/select-next-spec.md`, quando o alvo ainda não estiver claro;
- `.ai/instructions/flows/expand/plan-spec.md`, após definir o alvo.

### 3. Pedir um componente novo sem falar em spec

Pedido típico:

- `crie o componente x`
- `implemente o componente x`
- `quero um componente x`

Fluxo:

- consultar `.ai/roadmap/components-plan-list.md` e `.ai/roadmap/ui-plan.md`;
- verificar se já existe spec para o componente;
- se não existir spec:
  - criar ou planejar a spec primeiro;
- se a spec já existir:
  - refinar, se estiver mole;
  - implementar, se já estiver pronta.

Regra:

- pedido de componente novo é, por padrão, fluxo orientado por spec;
- a criação de pacote novo não substitui a spec;
- se o `design.md` concluir que o pacote ainda não existe, a implementação deve usar `.ai/instructions/expand/create-library-project.md` como subfluxo técnico.

### 4. Criar uma lib spec

Pedido típico:

- `crie a spec x`

Fluxo:

- `.ai/instructions/flows/expand/create-spec.md`

### 5. Refinar uma lib spec existente

Pedido típico:

- `refine a spec x`
- `fortaleça a spec x`

Fluxo:

- `.ai/instructions/flows/expand/refine-spec.md`

### 6. Implementar uma lib spec

Pedido típico:

- `implemente a spec x`
- `execute a spec x`

Fluxo:

- `.ai/instructions/flows/expand/implement-spec.md`

### 7. Pedir um pacote ou projeto de biblioteca novo

Pedido típico:

- `crie o projeto x`
- `crie o pacote x`
- `prepare o novo pacote x`

Fluxo padrão:

- criar ou planejar a spec do pacote primeiro;
- depois, quando a spec já estiver suficientemente fechada, usar `.ai/instructions/expand/create-library-project.md`.

Regra:

- via `.ai/lib-spec.md`, pedido de projeto novo é `spec-first` por padrão;
- scaffolding direto só deve acontecer quando o utilizador pedir isso explicitamente ou chamar `.ai/instructions/expand/create-library-project.md`;
- quando o pedido é de componente, a criação de projeto deve sair do design da spec.

### 8. Ajustar uma implementação de que o utilizador não gostou

Pedido típico:

- `não gostei da implementação da spec x`
- `ajuste a implementação da spec x`
- `corrija esta entrega`

Fluxo:

- se o comportamento desejado da spec não mudou:
  - reaplicar `.ai/instructions/flows/expand/implement-spec.md` com os ajustes pedidos;
- se o comportamento, API, composição ou escopo mudou:
  - primeiro `.ai/instructions/flows/expand/refine-spec.md`;
  - depois `.ai/instructions/flows/expand/implement-spec.md`.

Regra:

- a IA deve deixar explícito se está corrigindo a implementação ou primeiro corrigindo a spec.

---

## Regras de Qualidade

- Usar sempre acentuação.
- Não misturar planeamento colaborativo com implementação sem pedido explícito.
- Em pedidos de componente novo, consultar `components-plan-list.md` e `ui-plan.md`.
- Em qualquer fluxo de componente ou spec, fechar os checkpoints de `.ai/guides/expand/cross-cutting-component-decisions.md`.
- Em pedidos de componente novo, tratar pacote novo como decisão de design, não como palpite.
- Em pedidos de ajuste, distinguir claramente:
  - erro de implementação;
  - mudança de design;
  - mudança de escopo.
- Em spec com comportamento observável ou showcase, não marcar o trabalho como `Concluído` sem aceite humano explícito dos testes previstos; até lá, usar estado aberto ou `Aguardando validação humana`.
- Depois de criar ou refinar uma `lib spec`, executar revisão por `spec-review` quando essa capacidade estiver disponível.
- Encerrar a resposta com próximo passo recomendado no fluxo: `refine lib-spec`, `implement lib-spec` ou `create-library-project`.

---

## Exemplos de Uso

```text
Leia `.ai/lib-spec.md` e quero planejar a próxima spec.
```

```text
Leia `.ai/lib-spec.md` e crie o componente `ip-address-field`.
```

```text
Leia `.ai/lib-spec.md` e implemente a spec `pagination`.
```

```text
Leia `.ai/lib-spec.md` e quero um novo pacote `RoyalCode.Razor.Navigation`; primeiro feche a spec e depois prepare o projeto.
```

```text
Leia `.ai/lib-spec.md` e não gostei da implementação da spec `pagination`; quero estes ajustes: ...
```


