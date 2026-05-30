# Corporate Rules — yasamen-razor

## Índice de rules

| Rule | Arquivo | Quando carregar |
|---|---|---|
| Bootstrap e DI | `bootstrap.rules.md` | Sempre que criar um projeto novo ou adicionar serviços Yasamen |
| Seleção de shell | `shell-selection.rules.md` | Sempre que escolher o shell/layout de uma aplicação |

## Rules recusadas

| Candidato | Motivo da recusa |
|---|---|
| `forms-native-gaps.rules.md` | Dispensável — gaps documentados nos blueprints e samples |
| `modal-offcanvas-id.rules.md` | Rejeitado — API proposta estava errada; padrão correto coberto nos samples |

## Regras transversais obrigatórias

- **Nunca** usar `ModalService` nem `OffCanvasService` diretamente em componentes de aplicação — são serviços internos. Use `@ref` + `OpenAsync()`/`CloseAsync()` ou declare `ModalHandler`/`OffCanvasHandler`.
- **Nunca** usar `@bind-IsOpen` em `OffCanvas` — o parâmetro não existe. Use `OffCanvasHandler` ou `@ref`.
- **Sempre** verificar a lista de shells NÃO-AppLayout antes de criar um novo layout — ver `shell-selection.rules.md`.

## Ordem de leitura recomendada

1. `bootstrap.rules.md` → configuração obrigatória antes de qualquer uso da lib
2. `shell-selection.rules.md` → decisão arquitetural de shell antes de implementar telas
