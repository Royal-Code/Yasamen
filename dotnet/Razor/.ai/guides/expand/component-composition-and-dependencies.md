# Component Composition and Dependencies

> Como decidir se um componente deve ser um primitivo, um composto, ou se depende de outro componente-base que ainda precisa existir antes.

---

## Visão Geral

Este guide existe para evitar dois erros comuns:

1. implementar um componente complexo sem avaliar se ele deveria reutilizar componentes já existentes;
2. implementar um componente derivado antes do componente-base que ele naturalmente pede.

Ele também fecha uma regra de desenho importante:

- todo componente novo deve avaliar explicitamente se faz sentido suportar `Size: Sizes`;
- se não fizer sentido, isso deve ser justificado no `design.md`.

---

## Regra principal

Antes de implementar um componente novo, a IA ou o desenvolvedor deve classificá-lo em um destes grupos:

1. **Primitivo base**
2. **Composto sobre componentes existentes**
3. **Composto que depende de um primitivo ainda ausente**

Essa decisão não pode ficar implícita.

---

## 1. Primitivo base

É o componente que introduz a capacidade fundamental.

Exemplos típicos:

- `Button`
- `IconButton`
- futuro `ButtonGroup`
- futuro `Tabs`

Quando o componente for um primitivo base:

- a API dele deve ser pensada para reuso;
- o contrato visual deve ser pequeno e estável;
- ele pode destravar outros componentes acima dele.

---

## 2. Composto sobre componentes existentes

É o componente que nasce da composição de primitives ou componentes já implementados.

Exemplos possíveis:

- dropdown disparado por `Button` ou `IconButton`;
- confirm dialog sobre `Modal`;
- empty state composto com `Feedback`, `Icon` e `Button`, se isso fizer sentido como API pública.

Quando esse for o caso:

- preferir reutilizar componentes já existentes;
- evitar reimplementar markup, estados ou estilos já resolvidos;
- registrar no `design.md` quais componentes estão sendo reutilizados e por quê.

---

## 3. Composto que depende de um primitivo ainda ausente

Esse é o caso mais importante para ordem de implementação.

Exemplo conceitual:

- se `Pagination` de fato pede um `ButtonGroup` como primitivo reutilizável, então a spec deve avaliar se `ButtonGroup` precisa ser implementado primeiro.

Regra:

- se o componente alvo depende naturalmente de um componente-base ainda ausente, isso deve ser tratado explicitamente.

As saídas válidas são:

1. implementar primeiro o componente-base;
2. abrir spec separada para o componente-base;
3. justificar por que o alvo seguirá sem essa abstração no primeiro release.

O que não pode acontecer é a dependência ficar invisível.

---

## Uso obrigatório de `components-plan-list.md`

Ao planejar ou criar spec de componente, a IA deve consultar:

- `.ai/roadmap/components-plan-list.md`

Objetivo:

- identificar componentes-base já previstos;
- detectar quando o alvo atual é subconjunto, variação ou composição de outro item do roadmap;
- evitar que a biblioteca acumule componentes irmãos sem um primitivo coerente.

---

## Ordem de implementação

A ordem ideal tende a ser:

1. primitivo base;
2. composto simples;
3. composto especializado;
4. templates e conveniências.

Exemplos:

- `ButtonGroup` antes de componentes que naturalmente se organizam como grupo de botões;
- `Tabs` antes de variantes mais ricas de navegação por seções;
- base de forms antes de inputs concretos;
- infraestrutura de showcase antes de multiplicar páginas de demo.

---

## Regra de `Size: Sizes`

Todo componente novo deve avaliar explicitamente se faz sentido suportar variação de tamanho.

Perguntas:

1. o componente aparece em contextos densos e espaçosos?
2. ele pode conviver com `Button`, `IconButton`, `FieldGroup` ou outros componentes que já variam por tamanho?
3. a legibilidade ou a ergonomia mudam de forma relevante com escala?
4. há expectativa real de uso compacto, padrão e expandido?

Se a maioria for "sim", a tendência é suportar `Size: Sizes`.

Se a resposta for "não":

- o `design.md` deve justificar explicitamente a ausência de `Size`.

Exemplos típicos em que `Size` tende a caber:

- botões;
- inputs;
- grupos de botões;
- tabs;
- chips e badges;
- controles de navegação compactos.

Exemplos em que pode não caber:

- overlays estruturais grandes;
- containers de layout;
- componentes cuja escala já depende totalmente do conteúdo e do container.

---

## O que deve entrar no `design.md`

Toda spec de componente deve responder explicitamente:

1. este componente é primitivo ou composto?
2. quais componentes existentes ele reutiliza?
3. existe componente-base ausente que deveria vir antes?
4. ele suporta `Size: Sizes`?
5. se não suporta, qual é a justificativa?

---

## O que deve entrar no `tasks.md`

O plano de execução deve incluir ao menos uma checagem de:

- dependência composicional;
- necessidade de componente-base;
- decisão sobre `Size`.

---

## Sinais de desenho ruim

Há chance alta de o desenho estar ruim quando:

1. dois componentes quase iguais surgem sem um primitivo comum;
2. o composto duplica muito comportamento de componentes já existentes;
3. o alvo depende de um base component óbvio, mas ninguém o registrou;
4. o componente não tem `Size`, mas todos os pares dele na biblioteca têm;
5. a ausência de `Size` não está justificada.

---

## Checklist

- [ ] O componente foi classificado como primitivo ou composto?
- [ ] `components-plan-list.md` foi consultado?
- [ ] A spec registrou componentes reutilizados?
- [ ] A spec avaliou se existe componente-base ausente?
- [ ] A decisão sobre `Size: Sizes` foi tomada?
- [ ] A ausência de `Size`, se houver, foi justificada no design?


