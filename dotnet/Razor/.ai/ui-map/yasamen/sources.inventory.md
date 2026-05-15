# Sources Inventory - yasamen

## Escopo da rodada

- Biblioteca principal: `yasamen`.
- Tipo de fonte: `repo`.
- Versão conhecida: `0.0.0.1`, obtida de `Directory.Build.props` em `LibVer`.
- Plataforma-alvo: `web`, inferida do uso de Blazor/Razor.
- Raiz fonte permitida: `C:\git\RoyalCode\Yasamen\dotnet\Razor\`.
- Exclusões declaradas pelo humano: não ler `.ai/` fora de `.ai/ui-map/yasamen/` e não ler `.old/`.
- Objetivo dos artefatos: orientar IA, especialmente `screen-designer`, para gerar telas com a biblioteca Yasamen.

## Fontes principais

| Tipo | Fonte | Uso consolidado |
|---|---|---|
| code | `Directory.Build.props` | Versão da biblioteca (`LibVer`), target framework (`net10.0`), versões base ASP.NET/Extensions. |
| code | `RoyalCode.Razor.Alerts/` | Componentes de alertas, badges, feedback, notificações e serviço `Notify`. |
| code | `RoyalCode.Razor.Animations/` | Componentes e utilitários de animação. |
| code | `RoyalCode.Razor.Breadcrumbs/` | Componentes de breadcrumbs. |
| code | `RoyalCode.Razor.Buttons/` | Componentes de botões, botões de ícone e grupos de botões. |
| code | `RoyalCode.Razor.Commons/` | Base comum, JS interop, serviços, extensões e suporte compartilhado. |
| code | `RoyalCode.Razor.Drops/` | Componentes de drops, menus/dropdowns e conteúdo flutuante. |
| code | `RoyalCode.Razor.Forms/` | Componentes e infraestrutura de formulários. |
| code | `RoyalCode.Razor.Icons/` | Infraestrutura de ícones, factories e `WellKnownIcons`. |
| code | `RoyalCode.Razor.Icons.Bootstrap/` | Provider Bootstrap Icons para a infraestrutura de ícones. |
| code | `RoyalCode.Razor.Layouts/` | Primitivas de layout como box, bar, container, slot e stack. |
| code | `RoyalCode.Razor.Layouts.Apps/` | Layouts de aplicação, menus, sidebars, topbar e shell. |
| code | `RoyalCode.Razor.Modals/` | Componentes, serviços, handler e outlet de modal. |
| code | `RoyalCode.Razor.Navigation/` | Componentes de navegação, especialmente paginação. |
| code | `RoyalCode.Razor.OffCanvas/` | Componentes, serviços, handler e outlet de offcanvas/asides. |
| code | `RoyalCode.Razor.Styles/` | CSS distribuído, tokens, temas, tamanhos, variáveis, componentes e classes utilitárias. |

## Fontes documentais e contextuais

| Tipo | Fonte | Uso consolidado |
|---|---|---|
| docs | `RoyalCode.Razor.Docs/` | Aplicação/documentação Blazor para validar rotas, setup, `App.razor`, render modes e serviços. |
| samples | `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/` | Páginas de demo por componente/padrão. |
| samples | `RoyalCode.Razor.Show/` | Projeto de exibição/showcase, quando havia uso demonstrável. |
| tests | `RoyalCode.Razor.Buttons.Tests/` | Evidência de contrato para botões, ripple e setup bUnit. |
| tests | `RoyalCode.Razor.Commons.Tests/` | Evidência de contrato para commons/JS interop. |
| tests | `RoyalCode.Razor.Navigation.Tests/` | Evidência de contrato para paginação/navegação. |

## Fontes corporativas da rodada

| Tipo | Fonte | Uso consolidado |
|---|---|---|
| corporate | Decisão humana na etapa `corporate-guides` | Guias devem orientar IA em forma de regras executáveis. |
| corporate | Decisão humana na etapa `corporate-guides` | Não gerar `yasamen-auth-http.guide.md`, `yasamen-testing.guide.md` e `yasamen-packaging-versioning.guide.md`. |

## Bibliotecas auxiliares

Nenhuma biblioteca auxiliar foi declarada ou consumida nesta rodada.

## Dependências externas observadas

| Nome | Versão | Evidência | Uso |
|---|---:|---|---|
| `.NET / TargetFramework` | `net10.0` | `Directory.Build.props` | Target framework dos projetos Razor. |
| `Microsoft.AspNetCore.Components.Web` | `10.0.1` | `Directory.Build.props` e csproj de styles | Componentes Blazor e app de docs. |
| `Microsoft.Extensions.*` | `10.0.1` | `Directory.Build.props` (`ExtVer`) | DI, options e infraestrutura usada por serviços. |
| `Bootstrap Icons CSS` | `1.13.1` | `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Components/App.razor` | Renderização visual dos ícones Bootstrap (`bi-*`). |
| `tailwindcss` | `4.1.11` | `RoyalCode.Razor.Styles/package.json` | Pipeline de CSS da biblioteca. |
| `@tailwindcss/cli` | `4.1.11` | `RoyalCode.Razor.Styles/package.json` | Build do CSS Tailwind (`yasamen.dist.css`, `yasamen.min.css`). |
| `gulp` | `5.0.1` | `RoyalCode.Razor.Styles/package.json` | Bundle de CSS. |
| `gulp-clean-css` | `4.3.0` | `RoyalCode.Razor.Styles/package.json` | Minificação/limpeza no pipeline CSS. |
| `gulp-concat` | `2.6.1` | `RoyalCode.Razor.Styles/package.json` | Concatenação no pipeline CSS. |

## Decisões finais

- Nome canônico da rodada: `yasamen`.
- Plataforma-alvo da rodada: `web`.
- Versão registrada no fechamento: `0.0.0.1`.
- Referência de origem no manifest: path local, pois não foi registrado commit/tag nesta rodada.
