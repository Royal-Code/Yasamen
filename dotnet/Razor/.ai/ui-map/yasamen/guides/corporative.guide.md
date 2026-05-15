# Corporate Guide — Yasamen

## Roteamento
- Quando carregar: quando a IA for gerar, ajustar ou revisar telas Blazor que usem Yasamen, especialmente com `screen-designer`.
- Objetivo: decidir quais guias corporativos aplicar antes de escolher componentes, layouts, navegação, formulários, ícones, estilos ou overlays.

## Catálogo de guides

| Guide | Quando usar | O que resolve | Status |
|---|---|---|---|
| `yasamen-bootstrap.guide.md` | Ao criar ou revisar o setup de uma aplicação Blazor com Yasamen | Serviços, estilos, ícones, imports e renderização interativa | gerado |
| `yasamen-app-shell-menu.guide.md` | Ao gerar shell, layout, menu lateral, rotas ou navegação estrutural | Uso de `AppMainLayout`, `AppLayout`, `MenuOptions`, `MenuItem` e `AppMenu` | gerado |
| `yasamen-overlays-feedback.guide.md` | Ao usar modal, offcanvas, notificação, toast ou feedback global | Registro de serviços, handlers e outlets esperados | gerado |
| `yasamen-forms.guide.md` | Ao gerar formulários, campos, validação e composição de campo | Uso correto de `TextField`, `FieldBadge`, `FieldAction`, `Error` e slots | gerado |
| `yasamen-styles-assets.guide.md` | Ao aplicar tema, tamanho, classes, assets CSS ou build visual | Uso de `YasamenStyles`, `Themes`, `Sizes`, Tailwind e classes `ya-*` | gerado |
| `yasamen-icons.guide.md` | Ao usar ícones, botões com ícone ou ícones conhecidos | Setup de Bootstrap Icons, `WellKnownIcons`, `Icon`, `IconButton` | gerado |
| `yasamen-component-composition.guide.md` | Ao criar componentes Blazor compostos em cima de Yasamen | Convenções de `RenderFragment`, `AdditionalClasses`, `AdditionalAttributes` e handlers | gerado |
| `yasamen-auth-http.guide.md` | Não carregar nesta rodada | Guia recusado pelo humano | recusado |
| `yasamen-testing.guide.md` | Não carregar nesta rodada | Guia recusado pelo humano | recusado |
| `yasamen-packaging-versioning.guide.md` | Não carregar nesta rodada | Guia recusado pelo humano | recusado |

## Regras corporativas gerais
- A IA deve tratar estes guias como regras de execução, não como documentação humana explicativa.
- A IA deve usar como fonte oficial os projetos de código, demos, testes e artefatos do ui-map da rodada atual de Yasamen.
- A IA não deve usar documentação externa oficial para completar decisões de Yasamen sem autorização explícita do humano.
- A IA não deve inventar APIs, parâmetros, tokens, classes, serviços ou comportamento que não estejam evidenciados nos fontes locais.
- A IA deve preferir componentes e parâmetros Yasamen (`Themes`, `Sizes`, `Positions`, `AdditionalClasses`, handlers e services) antes de criar HTML/CSS manual para comportamentos já cobertos.
- Quando houver conflito entre demo, comentário e implementação, a IA deve priorizar a implementação do componente; se a decisão afetar documentação final, registrar a divergência como gap.
- A IA deve manter os guias recusados fora da geração de tela, salvo nova autorização explícita do humano.

## Fontes
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Program.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Program.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Components/App.razor`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/_Imports.razor`
- `RoyalCode.Razor.Layouts.Apps/`
- `RoyalCode.Razor.Modals/`
- `RoyalCode.Razor.OffCanvas/`
- `RoyalCode.Razor.Alerts/`
- `RoyalCode.Razor.Forms/`
- `RoyalCode.Razor.Icons/`
- `RoyalCode.Razor.Icons.Bootstrap/`
- `RoyalCode.Razor.Styles/`
- Decisão humana nesta etapa: gerar guias para IA, em forma de regras, sem `auth-http`, `testing` e `packaging-versioning`.
