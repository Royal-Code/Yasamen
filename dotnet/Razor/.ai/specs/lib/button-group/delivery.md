# Delivery — ButtonGroup

## Metadados

| Campo | Valor |
|---|---|
| Status final | `Não iniciada` |
| Data | `—` |
| Implementador | `—` |
| Spec | `button-group` |

## Resumo

- Spec criada e estruturada.
- Implementação, validação e revisão ainda pendentes.
- Escopo inicial fechado como primitivo de agrupamento visual e semântico para `Button` e `IconButton`, sem virar `segmented control`.

## Changelog

### Added

- Pasta de spec `button-group` com `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.

### Changed

- Nenhuma implementação ainda.

### Fixed

- N/A

### Breaking

- Nenhum.

## Rastreabilidade

| Origem | Item | Evidência | Status |
|---|---|---|---|
| Guide | `cross-cutting-component-decisions` | Pacote alvo, API pública, decisões de `Style`, `Size`, CSS e showcase documentadas | `Planeado` |
| Guide | `component-composition-and-dependencies` | Classificação como primitivo base e ausência de pré-requisito obrigatório | `Planeado` |
| Guide | `css-visual-contract` | Contrato público reduzido a `ya-btn-group*` e sem `*.razor.css` novo | `Planeado` |
| Requirement | Herança de `Style` e `Size` | Seção `API Pública Proposta` | `Planeado` |
| Requirement | Showcase em Docs | Seção `Showcase no Docs` | `Planeado` |

## Validação Executada

| Tipo | Evidência | Resultado |
|---|---|---|
| Build | Ainda não executado | `Pendente` |
| Testes | Ainda não executados | `Pendente` |
| Showcase | Ainda não criado | `Pendente` |
| Visual | Validação Playwright não iniciada | `Pendente` |

## Revisão de Código

### Achados

- Implementação ainda não iniciada.

### Riscos Residuais

- A herança de defaults em `Button` e `IconButton` precisa ser implementada sem introduzir precedência confusa entre valor local e valor do grupo.
- A junção visual entre botões mistos pode exigir ajuste fino de CSS, principalmente em foco e combinações de tema muito diferentes.
- A integração com o host atual de docs ainda convive com rotas legadas de botões, o que pode pedir uma pequena decisão de migração na PR de implementação.

## Divergências da Spec

- Nenhuma até o momento.

## Fechamento das Tasks

- [ ] Todas as tasks essenciais foram concluídas.
- [ ] Tasks não concluídas foram justificadas.
- [ ] O status final da spec foi atualizado.

## Artefatos Atualizados

- [x] `requirements.md`
- [x] `design.md`
- [x] `tasks.md`
- [ ] `ui-map.md`
- [ ] `ui-plan.md`
