# Tasks — Pagination

## Preparação

- [ ] Confirmar o pacote alvo `RoyalCode.Razor.Navigation`.
- [ ] Fechar a API pública de `Pagination`.
- [ ] Fechar a estratégia visual de Desktop e Mobile.

## Implementação

- [ ] Criar `Pagination.razor` e `Pagination.razor.cs`.
- [ ] Criar helper interno de cálculo da janela de páginas.
- [ ] Implementar validação de limites e no-op para destinos inválidos.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes`.
- [ ] Garantir comportamento de loading e desabilitação.

## Estilos

- [ ] Criar `pagination.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [ ] Registrar o `@import` no `yasamen.css`.
- [ ] Cobrir página ativa, hover, foco, desabilitado e resumo Mobile.

## Testes

- [ ] Testar cálculo da janela numérica.
- [ ] Testar mudança de página e bloqueio durante loading.
- [ ] Testar navegação de borda e limites.
- [ ] Testar marcação ARIA e layout Mobile.

## Documentação

- [ ] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`.
- [ ] Registrar o item `/demo/navigation/pagination` em `ConfigureMenu.cs`.
- [ ] Cobrir uso básico, loading, janela numérica, largura reduzida e integração com lista paginada.
- [ ] Atualizar `ui-map.md` após a implementação.
