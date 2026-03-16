# Design — Docs Showcase Foundation

## Decisões de Estrutura

- O host atual de showcase permanece em `RoyalCode.Razor.Docs.Client`.
- O projeto `RoyalCode.Razor.Show` continua como direção futura, não como dependência operacional atual.
- A infraestrutura reutilizável do showcase deve ficar no próprio `Docs.Client`.
- O CSS do shell de documentação deve ficar no projeto host de Docs, não em `RoyalCode.Razor.Styles`.

## Arquitetura Proposta

### Projetos envolvidos

- `RoyalCode.Razor.Docs.Client`
  - páginas Razor de showcase;
  - componentes reutilizáveis de showcase;
  - configuração do menu de navegação.
- `RoyalCode.Razor.Docs`
  - host da aplicação;
  - CSS global de documentação;
  - carregamento do app e de `YasamenStyles`.

### Componentes reutilizáveis propostos

- `Components/Showcases/ShowcasePage.razor`
- `Components/Showcases/ShowcaseSection.razor`
- `Components/Showcases/ShowcaseExample.razor`
- `Components/Showcases/ShowcasePlayground.razor`
- `Components/Showcases/ShowcaseNotes.razor`

Esses componentes não fazem parte da biblioteca pública de UI; são infraestrutura do ambiente de documentação.

## Taxonomia de Rotas e Pastas

Estrutura alvo:

```text
Pages/Demo/
  Commons/
  Feedback/
  Forms/
  Layouts/
  Navigation/
  Overlays/
```

Rotas alvo:

- `/demo/commons/element-js`
- `/demo/forms/text-field`
- `/demo/navigation/tabs`
- `/demo/navigation/pagination`
- `/demo/feedback/empty-state`
- `/demo/feedback/notifications`
- `/demo/overlays/modal`
- `/demo/overlays/drops`

Regra:

- páginas novas entram já nesse formato;
- páginas legadas em raiz entram em plano de migração e podem manter rota antiga temporariamente.

## Shell de Página

Toda página deve ter:

- título (`h1`);
- texto introdutório curto;
- seções com `h2`;
- blocos visuais consistentes para exemplo, notas e playground.

Estrutura alvo:

```razor
<ShowcasePage Title="Pagination" Summary="Navegação paginada para listas e grids.">
    <ShowcaseSection Title="Básico">
        <ShowcaseExample Title="Uso simples">
            ...
        </ShowcaseExample>
    </ShowcaseSection>

    <ShowcaseSection Title="Estados">
        <ShowcaseExample Title="Loading">
            ...
        </ShowcaseExample>
    </ShowcaseSection>
</ShowcasePage>
```

## CSS do Docs

Criar CSS próprio do Docs para showcase em:

- `RoyalCode.Razor.Docs/wwwroot/css/showcase.css`

E importar em:

- `RoyalCode.Razor.Docs/wwwroot/app.css`

Classes previstas:

- `ya-doc-page`
- `ya-doc-page-header`
- `ya-doc-page-summary`
- `ya-doc-section`
- `ya-doc-section-header`
- `ya-doc-example`
- `ya-doc-example-preview`
- `ya-doc-example-notes`
- `ya-doc-playground`

Essas classes são internas ao Docs e não entram no contrato público dos pacotes da biblioteca.

## Migração das Páginas Existentes

### Prioridade alta

- `ButtonsPage.razor`
- `BadgesPage.razor`
- `FeedbacksPage.razor`
- `NotificationsPage.razor`
- `TextFieldPage.razor`

### Prioridade média

- `IconButtonPage.razor`
- `DropsPage.razor`
- `ModalPage.razor`
- `AppLayoutPage.razor`
- `ElementJsPage.razor`

### Ajustes de conteúdo esperados

- introdução mínima em todas as páginas;
- seções consistentes;
- menos matriz pura e mais cenário real;
- remoção de `RoyalCode.Razor.Internal.*` de showcase público;
- remoção de `<style>` inline;
- remoção de uso manual de classes `ya-*` quando houver componente público equivalente.

## Menu e Descoberta

- `ConfigureMenu.cs` passa a ser a fonte canônica de navegação dos showcases.
- O agrupamento do menu deve espelhar a pasta e a rota.
- Rotas novas em raiz não devem mais ser criadas.

## Riscos e Questões em Aberto

- Confirmar se vale criar aliases temporários para rotas antigas ou fazer migração seca.
- Confirmar se `MainLayout.razor` e `NavMenu.razor` do Docs ainda têm papel ativo ou se são legado removível.
- Confirmar quando `RoyalCode.Razor.Show` deve começar a absorver a infraestrutura reutilizável.

## Validação Esperada

- `dotnet build` do `RoyalCode.Razor.Docs.Client` e do host `RoyalCode.Razor.Docs`.
- Validação manual da navegação, das rotas e do shell visual dos showcases.
- Revisão das páginas migradas para garantir uso apenas de API pública.
- Atualização do template de specs e dos guides relacionados ao fluxo novo.
