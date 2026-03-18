# Requirements - <Nome da Tela>

## Metadados

| Campo | Valor |
|---|---|
| Status | `Rascunho` |
| Tipo | `Tela nova` |
| Shell de referência | `A definir` |
| Page Pattern | `PP-...` |
| Rota ou contexto | `A definir` |
| Alvo de implementação | `App existente | Prototipagem | A definir` |
| Artefato relacionado | `Tela | Página | Fluxo` |
| Guides aplicados | `cross-cutting-screen-decisions`, `planning-and-ui-mapping` |

## Objetivo

Descrever o que a tela resolve, quem a usa, qual tarefa principal ela suporta e qual resultado precisa entregar.

## Contexto da Tela

- Utilizador ou papel principal.
- Contexto de navegação.
- Tela nova ou alteração de tela existente.
- Entradas disponíveis: briefing, print, tela atual, requisitos, jornadas ou capacidades, quando existirem.

## Escopo

- Objetivos principais da tela.
- Estados obrigatórios.
- Zonas funcionais esperadas.
- Necessidades de responsividade e acessibilidade.
- Necessidade de mapeamento para Yasamen.
- Dependências de componente que a tela pode revelar.
- Convenções locais do projeto para rota, menu, docs ou showcase, quando existirem.

## Fora de Escopo

- Componentes internos ainda sem spec, quando ficarem como pré-requisito.
- Detalhes de implementação de componente que pertencem a specs filhas.
- Decisões de jornada ou capacidade não necessárias para fechar a tela.

## Quadro As-Is / To-Be

### As-Is

- Preencher quando a tela já existir.

### To-Be

- Descrever a mudança desejada ou o alvo final da tela.

## Hipótese de Shell e `Page Pattern`

- Shell de referência e justificativa.
- `Page Pattern` principal e justificativa.

## Critérios de Aceite

- [ ] O shell de referência foi definido ou herdado.
- [ ] O `Page Pattern` principal foi escolhido e justificado.
- [ ] As zonas funcionais principais da tela foram identificadas.
- [ ] Cada zona possui `UIP-*` selecionados do catálogo.
- [ ] O mapeamento para Yasamen foi classificado entre `Existente`, `Composição`, `Gap de componente` ou `Gap estrutural`.
- [ ] As dependências de component spec foram listadas.
- [ ] A distinção entre `As-Is` e `To-Be` ficou clara quando a tela já existia.
- [ ] Convenções locais do projeto foram registradas quando forem relevantes para a tela.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final do trabalho.
- [ ] A cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP` foi registrada.
- [ ] O handoff técnico da tela está pronto para implementação ou decomposição em specs filhas.
- [ ] O uso de Yasamen como adapter tecnológico ficou explícito, quando aplicável.


