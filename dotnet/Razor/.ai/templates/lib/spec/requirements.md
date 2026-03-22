# Requirements - <Nome do Componente>

## Metadados

| Campo | Valor |
|---|---|
| Status | `Rascunho` |
| Prioridade | `P?` |
| Fase do plano | `F?.?` |
| UI Pattern | `UIP-...` |
| Roadmap | `R? > ...` |
| Pacote sugerido | `RoyalCode.Razor.<Pacote>` |
| Showcase inicial | `/demo/<grupo>/<componente>` |
| Guides aplicados | `project-structure`, `styles-and-css`, `component-anatomy`, `showcases-and-docs`, `spec-execution-and-delivery`, `cross-cutting-component-decisions` |

## Objetivo

Descrever o problema que o componente resolve, em que cenários ele será usado e qual lacuna do catálogo ou do roadmap ele cobre.

## Escopo

- Componentes públicos a entregar.
- Estados visuais obrigatórios.
- Comportamentos funcionais mínimos.
- Requisitos de responsividade e acessibilidade.
- Entregáveis de documentação e exemplo.
- Avaliação explícita de composição, dependências, `Style: Themes`, `Size: Sizes` e tokens visuais.

## Fora de Escopo

- Itens explicitamente adiados para fases futuras.
- Integrações opcionais que não bloqueiam o primeiro release.
- Refinamentos que dependem de outros componentes ainda não existentes.

## Casos de Uso

1. Caso principal de uso em página comum.
2. Caso secundário em layout responsivo.
3. Caso com estado vazio, carregando, desabilitado ou equivalente.

## Requisitos Funcionais

- Definir a API pública mínima.
- Definir estados obrigatórios.
- Definir eventos, callbacks e slots.
- Definir como o componente reage a parâmetros inválidos ou ausentes.
- Definir se o pacote sugerido já existe ou se precisará ser criado.
- Definir se o componente deve suportar `Style: Themes` ou justificar explicitamente por que não.
- Definir o fallback de `Themes.Default`, quando houver `Style`.
- Definir se o componente deve suportar `Size: Sizes` ou justificar explicitamente por que não.
- Definir se o componente é primitivo base ou composto e quais dependências precisam vir antes.
- Definir quais tokens de `yasamen.css` sustentam tema, espaçamento, tipografia e responsividade.

## Acessibilidade e Responsividade

- Descrever papéis ARIA, foco por teclado e atributos semânticos.
- Descrever comportamento em Mobile, Tablet e Desktop.
- Descrever contraste, leitura por leitor de tela e ordem lógica do conteúdo.

## Showcase Obrigatório

- Definir a rota inicial no `RoyalCode.Razor.Docs.Client`.
- Definir a pasta da página em `Pages/Demo/...`.
- Definir o grupo de menu em `ConfigureMenu.cs`.
- Definir os cenários mínimos do showcase: básico, variações, estados e composição.

## Critérios de Aceite

- [ ] O componente cobre o caso principal previsto no `ui-map.md`.
- [ ] A API pública está consistente com os guides da biblioteca.
- [ ] O CSS público usa classes `ya-*` em `RoyalCode.Razor.Styles`.
- [ ] O componente não depende de `*.razor.css` novo.
- [ ] Há showcase em `RoyalCode.Razor.Docs.Client` com rota e menu definidos.
- [ ] A decisão sobre pacote existente versus pacote novo foi tomada e documentada.
- [ ] A decisão sobre `Style: Themes` foi tomada e documentada.
- [ ] A decisão sobre `Size: Sizes` foi tomada e documentada.
- [ ] A decisão sobre composições, reuso e pré-requisitos foi tomada e documentada.
- [ ] Os tokens relevantes de `yasamen.css` foram identificados e aplicados de forma coerente.
- [ ] Existem exemplos e testes suficientes para evitar regressão básica.
- [ ] A spec define testes ou validação humana quando a entrega tiver comportamento observável, UI ou showcase.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A comparação entre requirements, design, guides e código foi registrada.
- [ ] O aceite humano foi registrado quando a spec exigir validação humana.
- [ ] O status final da spec foi atualizado de forma coerente.


