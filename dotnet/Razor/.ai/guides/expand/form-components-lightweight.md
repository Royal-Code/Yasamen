# Form Components Lightweight

> Guardrails leves para componentes de formulário ainda pouco definidos, quando a infraestrutura base já existe, mas a API específica do controle ainda não está madura.

---

## Visão Geral

Este guide complementa o [form-components.md](form-components.md).

O guide 07 continua sendo a referência principal para a infraestrutura de formulários da biblioteca. Este guide 14 existe para um cenário mais específico:

- o componente é claramente um form component;
- o repositório ainda não tem exemplos suficientes para congelar sua API final;
- mas já existe base suficiente para evitar decisões erradas cedo.

Em outras palavras: este guide não fecha o desenho do controle; ele fecha o que não deveria variar.

---

## Quando usar

Use este guide quando a spec ou o componente estiver em um destes cenários:

- novo campo com comportamento ainda em exploração;
- controle com UX ainda aberta;
- componente que depende de decisões futuras de máscara, sugestões, popup, seleção ou parsing;
- componente de formulário que ainda não tem massa crítica suficiente no repositório para virar padrão rígido.

Exemplos típicos:

- `SearchField`
- `DatePicker`
- `SelectField`
- `NumberField`
- `InlineEditor`

---

## O que já está consolidado

Mesmo em componentes ainda abertos, estas regras já devem valer:

1. integração coerente com a infraestrutura de forms existente;
2. uso de label, info, error e addons por meio da infraestrutura comum, quando fizer sentido;
3. contrato visual público em `RoyalCode.Razor.Styles`;
4. `AdditionalClasses` e `AdditionalAttributes`;
5. IDs, rótulos e mensagens acessíveis;
6. estado e binding explícitos.

---

## Regra principal

Se o comportamento específico do controle ainda não estiver decidido, não inventar uma API extensa só para parecer completa.

É melhor:

- uma API menor;
- pontos em aberto documentados;
- e uma spec honesta;

do que:

- uma API supercomplicada;
- incoerente com o restante da biblioteca;
- e difícil de manter depois.

---

## Base técnica esperada

### Preferência

Quando possível, novos controles devem aproveitar:

- `FieldBase` / `FieldBase<T>`;
- `FieldGroup`;
- `InputFieldBase`;
- integração com `EditContext`.

### Exceção

Se o controle não encaixar bem nessa base, a spec deve justificar explicitamente por quê.

Exemplos de casos que podem exigir adaptação:

- calendário popup;
- seleção múltipla complexa;
- campo com dropdown rico;
- editor inline com múltiplos modos;
- componente híbrido que não é só input textual.

---

## O que deve ficar estável desde cedo

Mesmo em controle pouco definido, estes pontos devem sair claros:

### 1. Surface mínima

- valor principal;
- callback de mudança;
- `Disabled`;
- `ReadOnly`, se fizer sentido;
- `Placeholder`, se fizer sentido;
- `AdditionalClasses`;
- `AdditionalAttributes`.

### 2. Integração de formulário

- nome do campo;
- label;
- erro;
- info;
- estado inválido;
- relação com validação.

### 3. Contrato visual

- classe raiz `ya-*`;
- classes de estado público;
- CSS em `RoyalCode.Razor.Styles`;
- evitar `*.razor.css` novo.

### 4. Acessibilidade básica

- label associada;
- estado inválido exposto;
- foco previsível;
- ordem lógica de tabulação;
- semântica mínima coerente com o tipo de controle.

---

## O que pode ficar em aberto

É aceitável deixar em aberto, desde que a spec registre isso:

- política final de teclado avançado;
- formatação e parsing completos;
- máscara;
- sugestões assíncronas;
- virtualização;
- popup ou overlay auxiliar;
- seleção única versus múltipla;
- atalhos de teclado ricos;
- estratégia de debounce;
- surface de busca remota.

---

## Como escrever a spec nesses casos

Quando a API ainda não estiver madura:

1. fixar a infraestrutura comum;
2. declarar explicitamente os pontos em aberto;
3. limitar o primeiro release ao comportamento validável;
4. evitar prometer variações que ainda não existem no código;
5. separar bem o que é requisito confirmado do que é hipótese futura.

---

## Relação com showcase

Para componentes de formulário ainda pouco definidos, o showcase deve ser ainda mais útil que o normal.

Ele deve validar:

- uso básico;
- erro/inválido;
- disabled;
- integração com formulário real;
- ao menos um cenário de composição.

O showcase ajuda a fechar a API do controle antes que ela congele de vez.

---

## Sinais de que o guide leve já não basta

É hora de migrar do guide leve para um padrão mais rígido quando:

1. já existem 2 ou 3 controles concretos semelhantes;
2. o comportamento já estabilizou em mais de um componente;
3. há testes e showcases suficientes para consolidar a API;
4. as mesmas decisões param de voltar como dúvida em novas specs.

---

## Checklist

- [ ] O componente usa a infraestrutura de forms existente ou justifica o desvio?
- [ ] A API mínima já está clara?
- [ ] Os pontos em aberto estão explícitos na spec?
- [ ] O contrato visual público já está em `RoyalCode.Razor.Styles`?
- [ ] A acessibilidade básica está prevista?
- [ ] O showcase ajuda a validar a forma final do controle?



