# Tasks — EmptyState

## Preparação

- [ ] Validar a decisão de implementar em `RoyalCode.Razor.Alerts`.
- [ ] Validar a opção por `ActionContent` em vez de `ActionLabel`/`OnAction`.
- [ ] Fechar `EmptyStateVariant` e ícones padrão sugeridos.

## Implementação

- [ ] Criar `EmptyState.razor` e `EmptyState.razor.cs`.
- [ ] Criar `EmptyStateVariant.cs`.
- [ ] Implementar slots `Graphic`, `ActionContent` e `ChildContent`.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes`.
- [ ] Garantir fallback visual quando não houver `Graphic`.

## Estilos

- [ ] Criar `empty-state.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [ ] Registrar o `@import` no `yasamen.css`.
- [ ] Cobrir centralização, espaçamento, variantes e Mobile.

## Testes

- [ ] Testar renderização mínima e variante padrão.
- [ ] Testar `Graphic`, `ActionContent` e `ChildContent`.
- [ ] Testar classes por variante e estrutura semântica básica.

## Documentação

- [ ] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/EmptyStatePage.razor`.
- [ ] Registrar o item `/demo/feedback/empty-state` em `ConfigureMenu.cs`.
- [ ] Cobrir `NoData`, `NoResults`, `NoPermission`, CTA e variação em largura reduzida.
- [ ] Atualizar `ui-map.md` quando o componente estiver pronto.
- [ ] Reavaliar a relação entre `Feedback` e `EmptyState`.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validação manual do showcase.
- [ ] Fazer revisão crítica do diff final.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
