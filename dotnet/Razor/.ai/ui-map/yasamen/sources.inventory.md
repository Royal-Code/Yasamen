# Sources Inventory - yasamen

## Escopo da rodada

- Biblioteca principal: `yasamen`.
- Tipo de fonte: `repo`.
- Versao conhecida: `desconhecida`.
- Plataforma-alvo: `web`, inferida do uso de Blazor/Razor.
- Raiz fonte permitida: `C:\git\RoyalCode\Yasamen\dotnet\Razor\`.
- Exclusoes declaradas pelo humano: não ler `.ai/` fora de `.ai/ui-map/yasamen/` e não ler `.old/`.

## Fontes principais

| Tipo | Fonte | Uso esperado |
|---|---|---|
| code | `RoyalCode.Razor.Alerts/` | Componentes de alertas, badges, feedback e notificações. |
| code | `RoyalCode.Razor.Animations/` | Componentes e utilitários de animação. |
| code | `RoyalCode.Razor.Breadcrumbs/` | Componentes de breadcrumbs. |
| code | `RoyalCode.Razor.Buttons/` | Componentes de botões e grupos de botões. |
| code | `RoyalCode.Razor.Commons/` | Base comum, JS interop, serviços, extensoes e suporte compartilhado. |
| code | `RoyalCode.Razor.Drops/` | Componentes de drops, menus/dropdowns e conteúdo flutuante. |
| code | `RoyalCode.Razor.Forms/` | Componentes e infraestrutura de formulários. |
| code | `RoyalCode.Razor.Icons/` | Infraestrutura de ícones. |
| code | `RoyalCode.Razor.Icons.Bootstrap/` | Catálogo/fabrica de Bootstrap Icons para a infraestrutura de ícones. |
| code | `RoyalCode.Razor.Layouts/` | Primitivas de layout como box, bar, container, slot e stack. |
| code | `RoyalCode.Razor.Layouts.Apps/` | Layouts de aplicação, menus e barras laterais/superiores. |
| code | `RoyalCode.Razor.Modals/` | Componentes e serviços de modal. |
| code | `RoyalCode.Razor.Navigation/` | Componentes de navegação, especialmente paginação. |
| code | `RoyalCode.Razor.OffCanvas/` | Componentes e serviços de off-canvas/asides. |
| code | `RoyalCode.Razor.Styles/` | CSS distribuido, variáveis, componentes e classes utilitarias. |

## Fontes documentais e contextuais

| Tipo | Fonte | Uso esperado |
|---|---|---|
| docs | `RoyalCode.Razor.Docs/` | Aplicação/documentação Blazor para validar rotas, setup e exemplos. |
| samples | `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/` | Páginas de demo por componente/padrão. |
| samples | `RoyalCode.Razor.Show/` | Projeto de exibição/showcase, se houver uso demonstravel. |
| tests | `RoyalCode.Razor.Buttons.Tests/` | Evidência de contrato para botões. |
| tests | `RoyalCode.Razor.Commons.Tests/` | Evidência de contrato para commons/JS interop. |
| tests | `RoyalCode.Razor.Navigation.Tests/` | Evidência de contrato para paginação/navegação. |

## Bibliotecas auxiliares

Nenhuma biblioteca auxiliar foi declarada para esta rodada.

## Pendencias de confirmação

1. Confirmar se `yasamen` e o nome canônico da biblioteca nesta rodada.
2. Confirmar se `web` e a única plataforma-alvo pretendida.
3. Confirmar se a versao deve permanecer `desconhecida` ou se há uma versao de pacote/release a usar.
