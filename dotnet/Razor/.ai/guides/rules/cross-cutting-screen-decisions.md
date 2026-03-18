# Decisões Transversais de Tela

> Checklist curto para qualquer `screen spec`, planeamento de tela ou alteração de página que use catálogo agnóstico, `Page Pattern` e mapeamento para Yasamen.

## Objetivo

Este guide existe para fechar decisões transversais de tela sem depender de regras de expansão da biblioteca.

Ele serve para:

- planeamento de tela;
- criação de `screen spec`;
- refinamento de `screen spec`;
- alteração de tela existente;
- handoff técnico de tela para implementação.

Ele não substitui guides de componente, pacote ou expansão da biblioteca.

## Escopo

Usar este guide quando o trabalho for:

- definir shell, `Page Pattern` e zonas funcionais;
- escolher `UIP-*` do catálogo;
- mapear a tela para Yasamen;
- registrar gaps de componente revelados pela tela;
- preparar uma tela para implementação em projeto consumidor.

Não usar este guide como checklist principal para:

- criar componente novo da biblioteca;
- desenhar API pública de componente;
- criar pacote `RoyalCode.Razor.*`;
- definir contrato visual interno da biblioteca.

## Entradas mínimas

Antes de fechar uma tela, garantir leitura de:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/page-patterns.md`
- `.ai/ui-map/shell-patterns.md`
- `.ai/ui-map/ui-map.md`, quando a tela for mapeada para Yasamen
- `.ai/guides/screens/planning-and-ui-mapping.md`

Se o projeto tiver backlog, roadmap ou mapa local de gaps:

- consultar também esse material;
- neste repositório, os arquivos padrão são `.ai/roadmap/components-plan-list.md` e `.ai/roadmap/ui-plan.md`.

## Checkpoints obrigatórios

### 1. Contexto e alvo

- A tela é nova ou alteração de tela existente?
- O contexto de navegação está claro?
- O utilizador principal está claro?
- A tarefa principal da tela está clara?

Se a tela já existir:

- registrar `As-Is`;
- registrar `To-Be`;
- explicitar o delta principal.

### 2. Shell e `Page Pattern`

- O shell foi herdado, reutilizado ou proposto?
- O `Page Pattern` principal foi escolhido e justificado?
- A cadeia `Shell -> Screen -> Page Pattern` ficou explícita?

### 3. Zonas funcionais

- As zonas principais da tela foram identificadas?
- Cada zona tem responsabilidade clara?
- A composição geral da página está coerente com o `Page Pattern`?

### 4. `UIP-*` por zona

- Cada zona usa apenas `UIP-*` do catálogo?
- Não foi criado `UIP` local?
- O catálogo foi usado como referência agnóstica, não o `ui-map`?

### 5. Mapeamento para Yasamen

Para cada necessidade da tela, classificar como:

- `Existente`
- `Composição com existentes`
- `Gap de componente`
- `Gap estrutural da tela`

Se a tela estiver em projeto que usa Yasamen:

- priorizar API pública e composição com componentes existentes;
- não depender de `Internal.*`;
- não tratar CSS interno da biblioteca como contrato do projeto consumidor.

### 6. Dependências e handoff

- As dependências de componente foram listadas?
- Está claro o que pode ser implementado já?
- Está claro o que depende de `lib spec` ou de outra decisão técnica?
- O handoff técnico da tela está pronto?

## Convenções locais do projeto

Este guide não impõe uma infraestrutura única de docs, showcase, menu ou rota.

Para cada projeto consumidor, registrar de forma explícita:

- convenção de rota;
- convenção de navegação ou menu;
- convenção de showcase, demo ou docs, quando existir;
- convenção de layout ou shell local.

No repositório Yasamen, essas convenções podem apontar para `Docs.Client`, mas isso não faz parte obrigatória do fluxo portátil.

## Critérios de qualidade

- Usar sempre acentuação.
- Não esconder gaps de componente em texto genérico.
- Não misturar decisões de tela com design detalhado de componente.
- Não transformar roadmap local em dependência obrigatória quando ele não existir.
- Quando houver acoplamento a Yasamen, deixar isso explícito como adapter tecnológico.

## Checklist rápido

- [ ] O contexto e o objetivo da tela estão claros?
- [ ] `As-Is` e `To-Be` foram separados, quando aplicável?
- [ ] Shell e `Page Pattern` foram definidos?
- [ ] As zonas funcionais foram identificadas?
- [ ] Cada zona usa `UIP-*` válido do catálogo?
- [ ] O mapeamento para Yasamen foi classificado?
- [ ] Dependências de componente foram registradas?
- [ ] Convenções locais do projeto foram registradas, quando necessárias?
