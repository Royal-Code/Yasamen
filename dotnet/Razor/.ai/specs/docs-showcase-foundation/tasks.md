# Tasks — Docs Showcase Foundation

## Preparação

- [ ] Validar o `09-showcases-and-docs.md` como referência normativa.
- [ ] Confirmar a taxonomia inicial de grupos: `Commons`, `Feedback`, `Forms`, `Layouts`, `Navigation`, `Overlays`.
- [ ] Confirmar a estratégia de migração de rotas legadas.

## Infraestrutura de Showcase

- [ ] Criar `Components/Showcases/ShowcasePage.razor`.
- [ ] Criar `Components/Showcases/ShowcaseSection.razor`.
- [ ] Criar `Components/Showcases/ShowcaseExample.razor`.
- [ ] Criar `Components/Showcases/ShowcasePlayground.razor`.
- [ ] Criar `Components/Showcases/ShowcaseNotes.razor`.

## Estilos do Docs

- [ ] Criar `RoyalCode.Razor.Docs/wwwroot/css/showcase.css`.
- [ ] Importar `showcase.css` em `RoyalCode.Razor.Docs/wwwroot/app.css`.
- [ ] Definir classes visuais do shell de página, seção, exemplo e playground.

## Navegação e Rotas

- [ ] Normalizar o padrão de rotas novas para `/demo/{grupo}/{componente}`.
- [ ] Ajustar `ConfigureMenu.cs` para refletir a nova taxonomia.
- [ ] Decidir e implementar a política para páginas legadas em rota raiz.

## Migração de Conteúdo

- [ ] Migrar `ButtonsPage.razor` para o padrão novo.
- [ ] Migrar `BadgesPage.razor` para o padrão novo.
- [ ] Migrar `FeedbacksPage.razor` para o padrão novo.
- [ ] Migrar `NotificationsPage.razor` removendo dependência de namespace interno.
- [ ] Migrar `TextFieldPage.razor` para o shell comum.
- [ ] Revisar `IconButtonPage.razor`, removendo markup solto antes de `@page`.
- [ ] Migrar `DropsPage.razor`, reduzindo duplicação e priorizando cenários.
- [ ] Reescrever `AppLayoutPage.razor`, hoje superficial demais para um showcase.
- [ ] Migrar `ElementJsPage.razor`, removendo `<style>` inline.

## Verificação

- [ ] Validar consistência visual entre páginas migradas.
- [ ] Garantir que showcases usem apenas API pública dos componentes documentados.
- [ ] Rodar build do `RoyalCode.Razor.Docs.Client`.

## Continuidade

- [ ] Atualizar o template de specs sempre que o padrão de showcase evoluir.
- [ ] Revisitar a relação entre `Docs` e `RoyalCode.Razor.Show` quando a plataforma de showcase começar a existir.
