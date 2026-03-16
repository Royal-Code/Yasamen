# Requirements — Tabs

## Metadados

| Campo | Valor |
|---|---|
| Status | Rascunho |
| Prioridade | `P1` |
| Fase do plano | `F1.1` |
| UI Pattern | `UIP-NAV-TABS` |
| Roadmap | `R1 › Componentes Diversos › Tabs` |
| Pacote sugerido | `RoyalCode.Razor.Navigation` |
| Showcase inicial | `/demo/navigation/tabs` |
| Guides aplicados | `01-project-structure`, `02-styles-and-css`, `06-component-anatomy`, `09-showcases-and-docs` |

## Objetivo

Entregar um componente de navegação por seções que cubra o gap de `Tabs` no catálogo, com semântica acessível, API pública previsível e uso consistente com o restante da biblioteca.

## Escopo

- `Tabs` como componente contêiner.
- `Tab` como item declarativo com conteúdo próprio.
- Modo controlado e modo com estado interno.
- Orientação horizontal e vertical.
- Tab desabilitada.
- Indicador visual de tab ativa.
- Badge simples por tab.
- Overflow horizontal em Mobile.

## Fora de Escopo

- Sincronização automática com rota.
- Fechamento, reordenação ou drag-and-drop de tabs.
- Persistência do estado em `localStorage`.
- Lazy loading de painéis e virtualização.
- Variante com navegação inferior Mobile.

## Casos de Uso

1. Alternar entre abas de uma página de detalhe sem recarregar a rota.
2. Exibir grupos de informações em formulários ou dashboards com navegação lateral.
3. Exibir tabs com contagem de itens pendentes ou resultados.

## Requisitos Funcionais

- Cada `Tab` deve possuir um `Value` estável e único dentro de um `Tabs`.
- `Tabs` deve aceitar `ActiveTab` externo e também funcionar sem controle externo, ativando a primeira tab não desabilitada.
- A mudança de aba deve expor `ActiveTabChanged` e `OnTabChanged`.
- `Tab` deve aceitar `Title`, `Disabled`, `BadgeText` e `ChildContent`.
- Apenas o painel ativo deve ser exibido no fluxo padrão do primeiro release.
- O componente deve suportar navegação por clique e teclado.
- O componente deve expor `AdditionalClasses` e `AdditionalAttributes` no elemento raiz.

## Acessibilidade e Responsividade

- O cabeçalho deve usar `role="tablist"`.
- Cada gatilho de aba deve usar `role="tab"`, `aria-selected`, `aria-controls` e foco por teclado.
- Cada painel deve usar `role="tabpanel"` e associação por `id`.
- Deve haver suporte para `ArrowLeft`, `ArrowRight`, `Home` e `End` no modo horizontal.
- Em Mobile, o cabeçalho deve aceitar overflow horizontal sem quebrar o layout.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/TabsPage.razor`.
- Registrar a rota `/demo/navigation/tabs`.
- Adicionar item em `ConfigureMenu.cs` dentro do grupo `Navigation`.
- Cobrir no showcase:
  - uso básico;
  - orientação vertical;
  - tab desabilitada;
  - tab com badge;
  - largura reduzida para simular Mobile.

## Critérios de Aceite

- [ ] É possível declarar `Tabs` e múltiplas `Tab` em markup Razor simples.
- [ ] O componente cobre os cenários horizontal, vertical, desabilitado e com badge.
- [ ] O contrato visual usa classes `ya-tabs*` em `RoyalCode.Razor.Styles`.
- [ ] Não é criado `*.razor.css` no pacote.
- [ ] Há showcase funcional em `RoyalCode.Razor.Docs.Client`.
- [ ] Há testes cobrindo troca de aba por clique e teclado.
