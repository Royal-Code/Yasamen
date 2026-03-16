# Requirements — EmptyState

## Metadados

| Campo | Valor |
|---|---|
| Status | Rascunho |
| Prioridade | `P1` |
| Fase do plano | `F1.3` |
| UI Pattern | `UIP-FEEDBACK-EMPTY_STATE` |
| Roadmap | `R2 › Empty` |
| Pacote sugerido | `RoyalCode.Razor.Alerts` |
| Showcase inicial | `/demo/feedback/empty-state` |
| Guides aplicados | `01-project-structure`, `02-styles-and-css`, `06-component-anatomy`, `09-showcases-and-docs`, `10-spec-execution-and-delivery` |

## Objetivo

Entregar um componente semântico para estados vazios de tela, reduzindo a necessidade de composições manuais com `Feedback`, `Icon`, `Box` e `Button`.

## Escopo

- `EmptyState` como componente público.
- Variantes semânticas para `NoData`, `NoResults` e `NoPermission`.
- Ícone ou ilustração opcional.
- Título e subtítulo.
- Slot de ação opcional.
- Slot de conteúdo complementar opcional.
- Layout responsivo centrado.

## Fora de Escopo

- Estado de erro completo.
- Estado de loading e skeleton.
- Botão embutido obrigatório na API pública do primeiro release.
- Ilustrações prontas empacotadas pela biblioteca.
- Comportamento de tela cheia forçado.

## Casos de Uso

1. Tela sem registros ainda, com chamada para criação.
2. Resultado vazio após busca ou filtro.
3. Área visível, porém sem permissão de uso.

## Requisitos Funcionais

- O componente deve aceitar `Variant`, `Title`, `Subtitle`, `Icon` e `Graphic`.
- O CTA deve entrar por slot (`ActionContent`) para evitar dependência desnecessária de `Buttons` no primeiro release.
- O componente deve aceitar conteúdo complementar por `ChildContent`.
- O componente deve aceitar `AdditionalClasses` e `AdditionalAttributes`.
- Deve ser possível usar o componente tanto em área pequena quanto em página inteira.

## Acessibilidade e Responsividade

- O conteúdo deve manter hierarquia semântica clara, com título e descrição.
- O componente não deve usar live region por padrão.
- O layout deve empilhar corretamente em Mobile e manter centralização.
- O CTA, quando existir, deve preservar foco visível e ordem lógica de tabulação.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/EmptyStatePage.razor`.
- Registrar a rota `/demo/feedback/empty-state`.
- Adicionar item em `ConfigureMenu.cs` dentro do grupo `Feedback`.
- Cobrir no showcase:
  - `NoData`;
  - `NoResults`;
  - `NoPermission`;
  - exemplo com `ActionContent`;
  - exemplo em contêiner estreito.

## Critérios de Aceite

- [ ] O componente cobre os cenários `NoData`, `NoResults` e `NoPermission`.
- [ ] É possível compor CTA com slot sem acoplar o pacote a `Buttons`.
- [ ] O CSS público usa classes `ya-empty-state*`.
- [ ] Não é criado `*.razor.css` novo.
- [ ] Há showcase no `RoyalCode.Razor.Docs.Client` com e sem ação.
- [ ] Há atualização futura prevista da nota de `UIP-FEEDBACK-EMPTY_STATE`.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A implementação foi comparada com requirements, design e guides.
- [ ] O status final da spec foi atualizado com evidência.
