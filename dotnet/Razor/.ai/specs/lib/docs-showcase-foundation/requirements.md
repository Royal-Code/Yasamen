# Requirements — Docs Showcase Foundation

## Metadados

| Campo | Valor |
|---|---|
| Status | Rascunho |
| Prioridade | `P1` |
| Fase do plano | Infra transversal |
| UI Pattern | — |
| Roadmap | — |
| Pacote sugerido | `RoyalCode.Razor.Docs.Client` + `RoyalCode.Razor.Docs` |
| Showcase inicial | — |
| Guides aplicados | `project-structure`, `styles-and-css`, `component-anatomy`, `showcases-and-docs`, `spec-execution-and-delivery` |

## Objetivo

Melhorar a qualidade do `RoyalCode.Razor.Docs.Client` como host oficial de showcases enquanto `RoyalCode.Razor.Show` ainda não existe, criando um padrão consistente de rotas, páginas, navegação e estrutura de demonstração.

## Problemas Atuais Observados

- Rotas e pastas inconsistentes entre páginas de demo.
- Qualidade irregular entre páginas: algumas cobrem bem estados, outras são rasas.
- Uso ocasional de `RoyalCode.Razor.Internal.*` em exemplos de consumidor.
- Uso de HTML cru com classes `ya-*`, estilos inline e `<style>` por página.
- Falta de shell reutilizável para título, seções, exemplos e playground.
- Mistura de idioma e ausência de introdução ou contexto em algumas páginas.

## Escopo

- Padronizar rotas novas sob `/demo/{grupo}/{componente}`.
- Definir grupos de showcase e organização de pastas em `Pages/Demo/...`.
- Criar infraestrutura reutilizável de showcase no `Docs.Client`.
- Criar CSS específico do Docs para shell e blocos de exemplo.
- Migrar progressivamente as páginas existentes para o padrão novo.
- Eliminar dependência de namespaces internos nas páginas públicas de showcase.
- Formalizar a relação futura entre `Docs` e `RoyalCode.Razor.Show`.

## Fora de Escopo

- Implementar `RoyalCode.Razor.Show` como plataforma completa.
- Extrair código-fonte automaticamente da página para exibição.
- Criar editor visual completo no estilo Storybook.
- Versionamento avançado de documentação por release.
- Reescrever o site institucional inteiro do Docs.

## Casos de Uso

1. Um desenvolvedor abre a documentação para entender rapidamente como usar um componente.
2. Um autor de componente precisa adicionar um showcase novo sem reinventar estrutura de página.
3. A equipe quer validar visualmente estados e integrações de um componente antes de publicar o pacote.

## Requisitos Funcionais

- Toda página nova de showcase deve ser criada em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`.
- Toda rota nova de showcase deve seguir `/demo/{grupo}/{componente-kebab-case}`.
- O menu deve ser atualizado em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- O Docs deve oferecer componentes reutilizáveis para:
  - página de showcase;
  - seção de showcase;
  - bloco de exemplo;
  - playground opcional.
- As páginas devem usar apenas API pública dos componentes mostrados.
- O Docs deve ter CSS próprio para o shell de showcase, sem contaminar `RoyalCode.Razor.Styles`.
- As páginas existentes devem entrar em backlog de migração.

## Acessibilidade e Responsividade

- O shell de showcase deve preservar hierarquia semântica clara com `h1`, `h2` e seções.
- Os blocos de exemplo devem funcionar em Desktop e Mobile.
- Controles de playground não devem quebrar a ordem de foco nem esconder o exemplo principal.

## Showcase Obrigatório

- Definir um padrão único de rota, pasta e menu para todos os showcases.
- Definir a anatomia mínima de uma página de showcase.
- Definir os cenários mínimos exigidos por página.

## Critérios de Aceite

- [ ] Existe um guide normativo para showcases e Docs.
- [ ] Existe uma infraestrutura reutilizável mínima para novas páginas de showcase.
- [ ] O Docs possui CSS próprio para o shell de showcase.
- [ ] O padrão de rota `/demo/...` está definido e adotado para páginas novas.
- [ ] Há backlog explícito para migração das páginas legadas.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A implementação foi comparada com requirements, design e guides.
- [ ] O status final da spec foi atualizado com evidência.


