# Tasks — Tabs

## Preparação

- [ ] Confirmar a criação do pacote `RoyalCode.Razor.Navigation`.
- [ ] Validar `TabOrientation`, `ActiveTab` e eventos da API pública.
- [ ] Confirmar a lista final de classes `ya-tabs*`.

## Implementação

- [ ] Criar `RoyalCode.Razor.Navigation.csproj` com referências diretas mínimas.
- [ ] Criar `_Imports.razor` do pacote com os namespaces necessários.
- [ ] Implementar `Tabs.razor` e `Tabs.razor.cs`.
- [ ] Implementar `Tab.razor` e `Tab.razor.cs`.
- [ ] Implementar o contexto interno de registro das tabs.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes` no raiz de `Tabs`.
- [ ] Implementar geração estável de IDs e atributos ARIA.

## Estilos

- [ ] Criar `tabs.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [ ] Registrar o `@import` no `yasamen.css`.
- [ ] Cobrir estado ativo, foco visível, desabilitado e overflow horizontal em Mobile.

## Testes

- [ ] Criar o projeto de testes do novo pacote ou incluir cobertura equivalente.
- [ ] Testar seleção inicial e modo controlado.
- [ ] Testar clique, teclado e tab desabilitada.
- [ ] Testar renderização vertical e com badge.

## Documentação

- [ ] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/TabsPage.razor`.
- [ ] Registrar o item `/demo/navigation/tabs` em `ConfigureMenu.cs`.
- [ ] Cobrir básico, vertical, desabilitado, badge e largura reduzida.
- [ ] Atualizar o `ui-map.md` quando a implementação estiver pronta.
- [ ] Reavaliar a nota de `UIP-NAV-TABS`.
