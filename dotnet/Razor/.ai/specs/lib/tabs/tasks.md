# Tasks — Tabs

## Preparação

- [ ] Confirmar a criação do pacote `RoyalCode.Razor.Navigation`.
- [ ] Criar `TabOrientation.cs` em `Internal/Navigation/` com valores `Horizontal` e `Vertical`.
- [ ] Criar o `.csproj` do pacote com referências a `RoyalCode.Razor.Commons` e `RoyalCode.Razor.Styles`.
- [ ] Criar `_Imports.razor` com `@using RoyalCode.Razor.Internal.Navigation`.
- [ ] Confirmar a lista final de classes `ya-tabs*`.

## Implementação

- [ ] Criar `Internal/Navigation/TabOrientation.cs`.
- [ ] Criar `Internal/Navigation/TabsContext.cs` com `Register`, `Unregister`, `ActivateAsync` e `OnChanged`.
- [ ] Criar `Internal/Navigation/TabRegistration.cs` com `Value`, `Title`, `BadgeText`, `Disabled`, `ChildContent`, `TabId`, `PanelId`.
- [ ] Implementar `Tabs.razor` e `Tabs.razor.cs` — renderiza `tablist` com base nos registros, projeta o painel ativo, fornece `CascadingValue<TabsContext>`.
- [ ] Implementar `Tab.razor` e `Tab.razor.cs` — recebe `CascadingParameter TabsContext`, registra em `OnInitialized`, remove em `Dispose`.
- [ ] Implementar geração de IDs ARIA: `tab-{id}` e `tabpanel-{id}` via `YasamenExtensions.GenerateId()`.
- [ ] Implementar roving tabindex: aba ativa com `tabindex="0"`, demais com `tabindex="-1"`.
- [ ] Implementar navegação por teclado: `ArrowLeft`/`Right` (horizontal), `ArrowUp`/`Down` (vertical), `Home`, `End`, `Enter`, `Space`; pular tabs desabilitadas.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes` no elemento raiz do `Tabs`.

## Estilos

- [ ] Criar `tabs.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [ ] Registrar o `@import` no `yasamen.css`.
- [ ] Cobrir estado ativo, foco visível, desabilitado e overflow horizontal em Mobile.

## Testes

- [ ] Criar o projeto de testes do novo pacote ou incluir cobertura equivalente.
- [ ] Testar `TabsContext`: registro, remoção, ativação e callback `OnChanged`.
- [ ] Testar seleção inicial sem `ActiveTab` (deve ativar a primeira tab não desabilitada).
- [ ] Testar modo controlado (`ActiveTab` externo + `ActiveTabChanged`).
- [ ] Testar troca de aba por clique.
- [ ] Testar navegação por teclado: `ArrowLeft`/`Right`, `Home`, `End`, `Enter`, `Space` (horizontal).
- [ ] Testar navegação por teclado: `ArrowUp`/`Down` (vertical).
- [ ] Testar que tab desabilitada é ignorada no clique e nas setas.
- [ ] Verificar que `aria-selected`, `aria-controls`, `role="tab"` e `tabindex` estão corretos por estado.
- [ ] Testar renderização com badge.

## Documentação

- [ ] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/TabsPage.razor`.
- [ ] Registrar a rota `/demo/navigation/tabs` e o item em `ConfigureMenu.cs` dentro do grupo `Navigation`.
- [ ] Cobrir nas seções do showcase:
  - `Básico` — tabs simples, troca por clique;
  - `Orientação` — horizontal vs. vertical lado a lado;
  - `Estados` — tab desabilitada, tab com badge;
  - `Largura reduzida` — contêiner estreito para simular Mobile com overflow.
- [ ] Usar apenas `Tabs` e `Tab` públicos; zero uso de `RoyalCode.Razor.Internal.*`.
- [ ] Atualizar `ui-map.md` (nota de `UIP-NAV-TABS`) após a implementação.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validação manual do showcase.
- [ ] Fazer revisão crítica do diff final.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.

