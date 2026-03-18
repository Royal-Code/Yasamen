# Tasks — Pagination

## Preparação

- [x] Confirmar o pacote alvo `RoyalCode.Razor.Navigation`.
- [x] Fechar a API pública de `Pagination`.
- [x] Fechar a estratégia visual de Desktop e Mobile.

## Implementação

- [x] Criar `Pagination.razor` e `Pagination.razor.cs`.
- [x] Criar helper interno de cálculo da janela de páginas.
- [x] Implementar validação de limites e no-op para destinos inválidos.
- [x] Garantir `AdditionalClasses` e `AdditionalAttributes`.
- [x] Garantir comportamento de loading e desabilitação.

## Estilos

- [x] Criar `pagination.css` em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
- [x] Registrar o `@import` no `yasamen.css`.
- [x] Cobrir página ativa, hover, foco, desabilitado e resumo Mobile.

## Testes

- [x] Testar cálculo da janela numérica.
- [x] Testar mudança de página e bloqueio durante loading.
- [x] Testar navegação de borda e limites.
- [x] Testar marcação ARIA e layout Mobile.

## Documentação

- [x] Criar `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`.
- [x] Registrar o item `/demo/navigation/pagination` em `ConfigureMenu.cs`.
- [x] Cobrir uso básico, loading, janela numérica, largura reduzida e integração com lista paginada.
- [x] Atualizar `ui-map.md` após a implementação.

## Encerramento

- [x] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [x] Executar build, testes e validação manual do showcase.
- [x] Fazer revisão crítica do diff final.
- [x] Preencher `delivery.md`.
- [x] Atualizar o status final da spec.

