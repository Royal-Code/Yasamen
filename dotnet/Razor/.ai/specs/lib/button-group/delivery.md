# Delivery — ButtonGroup

## Metadados

| Campo | Valor |
|---|---|
| Status final | `Concluída` |
| Data | `2026-03-21` |
| Implementador | `IA` |
| Spec | `button-group` |

## Resumo

- Implementado `ButtonGroup` em `RoyalCode.Razor.Buttons` como primitivo base para agrupar `Button` e `IconButton` com continuidade visual, `role="group"` e orientação horizontal ou vertical.
- `Button` e `IconButton` passaram a consumir defaults herdados de `Style`, `Size` e `Disabled`, preservando precedência para valores explícitos do filho.
- A spec foi encerrada como `Concluída` após build dos projetos impactados, execução da suíte `RoyalCode.Razor.Buttons.Tests`, revisão local do diff e aceite humano explícito dos testes finais neste chat; a validação visual automatizada não pôde ser executada neste ambiente.

## Changelog

### Added

- `ButtonGroup`, `ButtonGroupOrientation` e `ButtonGroupContext` para coordenar o agrupamento semântico e os defaults herdados.
- CSS público `ya-btn-group*` em `RoyalCode.Razor.Styles/wwwroot/css/components/btn-group.css`.
- Cobertura automatizada em `RoyalCode.Razor.Buttons.Tests/ButtonGroupTests.cs`.
- Página de showcase em `/demo/buttons/button-group`.

### Changed

- `Button` e `IconButton` agora consomem defaults herdados do grupo para `Style`, `Size` e `Disabled`.
- `RoyalCode.Razor.Styles/wwwroot/yasamen.css` e `yasamen.dist.css` passaram a incluir o CSS do grupo após `ibtn.css`.
- `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs` recebeu o item `Button Group` sob o módulo `Buttons`.
- `.ai/roadmap/components-plan-list.md`, `requirements.md`, `tasks.md` e `delivery.md` foram alinhados à implementação entregue.

### Fixed

- O catálogo deixou de depender de composição manual com `div` e ajustes locais de borda/raio para grupos simples de ações.

### Breaking

- Nenhum.

## Rastreabilidade

| Origem | Item | Evidência | Status |
|---|---|---|---|
| Guide | `cross-cutting-component-decisions` | `ButtonGroup` entregue em `RoyalCode.Razor.Buttons`, sem pacote novo, com defaults herdados de `Style` e `Size` e showcase no Docs. | `Atendido` |
| Guide | `component-composition-and-dependencies` | O componente foi implementado como primitivo base; o contrato visual continua restrito a filhos diretos `Button` e `IconButton`. | `Atendido` |
| Guide | `css-visual-contract` | O contrato público ficou restrito a `ya-btn-group*`, sem `*.razor.css` novo, com CSS em `RoyalCode.Razor.Styles`. | `Atendido` |
| Requirement | Herança de `Style` e `Size` | `Button` e `IconButton` calculam `EffectiveStyle` e `EffectiveSize`; os testes cobrem herança e sobrescrita explícita. | `Atendido` |
| Requirement | Showcase em Docs | Página `ButtonGroupPage.razor` criada em `/demo/buttons/button-group` e registrada no menu do Docs. | `Atendido` |

## Validação Executada

| Tipo | Evidência | Resultado |
|---|---|---|
| Build | `dotnet build RoyalCode.Razor.Buttons/RoyalCode.Razor.Buttons.csproj` e `dotnet build RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/RoyalCode.Razor.Docs.Client.csproj` executados com sucesso em 2026-03-21. | `Atendido` |
| Testes | `dotnet test RoyalCode.Razor.Buttons.Tests/RoyalCode.Razor.Buttons.Tests.csproj` executado com sucesso em 2026-03-21; `8` testes passados e `0` falhas. | `Atendido` |
| Showcase | A rota `/demo/buttons/button-group` foi criada, o menu foi atualizado e o projeto `Docs.Client` compilou com sucesso. | `Atendido` |
| Humano | Ajustes finais de composição e escala de `IconButton` dentro de `ButtonGroup` foram validados e aprovados explicitamente pelo humano neste chat em 2026-03-21 (`"Fechou esse componente"`). | `Atendido` |
| Visual | Validação visual automatizada via Playwright/MCP não estava disponível neste ambiente; smoke visual manual não foi executado. | `Não executado` |

## Revisão de Código

### Achados

- Sem achados relevantes após revisão local do diff.
- A precedência final de `Style`, `Size` e `Disabled` ficou coerente: o grupo só fornece defaults, e o filho explícito continua vencendo.
- A ordem do import em `yasamen.css` foi ajustada para manter as regras de junção do grupo acima do `IconButton`, evitando conflito com `rounded-full`.

### Riscos Residuais

- O contrato visual continua garantido apenas para filhos diretos `Button` e `IconButton`; wrappers intermediários quebram a geometria do grupo e permanecem fora do escopo.
- A validação visual automatizada continua indisponível sem Playwright/MCP; novas regressões visuais finas ainda dependem de revisão humana em alterações futuras.

## Divergências da Spec

- Nenhuma divergência funcional relevante.
- `ui-map.md` e `ui-plan.md` foram avaliados e permaneceram sem mudança, porque `ButtonGroup` não altera a cobertura dos `UIP-*` ativos; a decisão segue o próprio escopo da spec.

## Fechamento das Tasks

- [x] Todas as tasks essenciais foram concluídas.
- [x] Tasks não concluídas foram justificadas.
- [x] O aceite humano foi registrado ou a spec ficou explicitamente em `Aguardando validação humana`.
- [x] O status final da spec foi atualizado.

## Artefatos Atualizados

- [x] `requirements.md`
- [x] `design.md`
- [x] `tasks.md`
- [x] `delivery.md`
- [x] `.ai/roadmap/components-plan-list.md`
- [ ] `ui-map.md`
- [ ] `ui-plan.md`
