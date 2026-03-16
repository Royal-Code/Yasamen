# Requirements — Pagination

## Metadados

| Campo | Valor |
|---|---|
| Status | Rascunho |
| Prioridade | `P1` |
| Fase do plano | `F1.2` |
| UI Pattern | `UIP-NAV-PAGINATION` |
| Roadmap | `R1 › Componentes Diversos › Pagination` |
| Pacote sugerido | `RoyalCode.Razor.Navigation` |
| Showcase inicial | `/demo/navigation/pagination` |
| Guides aplicados | `01-project-structure`, `02-styles-and-css`, `06-component-anatomy`, `09-showcases-and-docs` |

## Objetivo

Entregar um componente de paginação reutilizável para listas, tabelas e grids, cobrindo o gap total atual do catálogo com um comportamento responsivo e acessível.

## Escopo

- `Pagination` como componente público único.
- Navegação para primeira, anterior, próxima e última página.
- Janela numérica de páginas no Desktop.
- Modo compacto no Mobile.
- Estado de loading.
- Estados desabilitados nos limites.
- API orientada a estado externo.

## Fora de Escopo

- Carregamento de dados e integração automática com back-end.
- Persistência de página na URL.
- Seletor de tamanho de página no primeiro release.
- Paginação infinita e virtualização.
- Internacionalização automática de rótulos.

## Casos de Uso

1. Paginar listagens simples com poucas páginas.
2. Paginar tabelas maiores, incluindo loading entre trocas.
3. Reutilizar o mesmo componente em `DataGrid` e páginas administrativas comuns.

## Requisitos Funcionais

- `CurrentPage` deve ser 1-based.
- `TotalPages` deve ser obrigatório e maior ou igual a 1.
- O componente deve emitir `OnPageChanged` apenas quando a página realmente mudar.
- Em Desktop, devem ser exibidas páginas numeradas com janela deslizante.
- Em Mobile, o componente deve reduzir a UI para anterior, indicador textual e próxima.
- O estado `Loading` deve desabilitar a navegação.
- O componente deve aceitar `AdditionalClasses` e `AdditionalAttributes`.

## Acessibilidade e Responsividade

- O contêiner deve usar `<nav aria-label="Paginação">`.
- Os botões devem ser focáveis por teclado e anunciar corretamente a página atual.
- O botão da página ativa deve expor `aria-current="page"`.
- Em Mobile, o layout deve caber em largura reduzida sem quebra visual.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`.
- Registrar a rota `/demo/navigation/pagination`.
- Adicionar item em `ConfigureMenu.cs` dentro do grupo `Navigation`.
- Cobrir no showcase:
  - uso básico;
  - janela numérica no início, meio e fim;
  - estado `Loading`;
  - largura reduzida;
  - integração simples com uma lista paginada.

## Critérios de Aceite

- [ ] O componente funciona em modo Desktop e Mobile.
- [ ] Os botões de borda ficam desabilitados corretamente.
- [ ] O loading impede cliques duplicados.
- [ ] O contrato visual usa classes `ya-pagination*`.
- [ ] Não é criado `*.razor.css` no pacote.
- [ ] Há showcase no `RoyalCode.Razor.Docs.Client` com lista paginada.
