# Requirements - <Nome do App>

## Metadados

| Campo | Valor |
|---|---|
| Status | `Rascunho` |
| Tipo | `App novo | Evolução de app` |
| Host Blazor | `A definir` |
| Shell principal | `A definir` |
| Alvo | `App consumidor com Yasamen` |
| Artefato relacionado | `Aplicação | Front-end` |
| Guides aplicados | `using-yasamen-in-blazor`, `consumer-app-conventions`, `cross-cutting-app-decisions` |

## Objetivo

Descrever o que o app resolve, quem o utiliza e qual contexto de consumo da biblioteca Yasamen será adotado.

## Contexto do App

- Tipo de sistema.
- Utilizadores principais.
- App nova ou evolução de app existente.
- Host Blazor esperado.
- Entradas disponíveis: briefing, requisitos, app existente, jornadas ou capacidades, quando existirem.

## Escopo

- Objetivos principais do app.
- Criação do projeto ou conjunto de projetos Blazor necessários.
- Integração do app à solution, quando aplicável.
- Estratégia de `ProjectReference` ou `PackageReference`.
- Shell, layout e navegação.
- Configuração de `_Imports.razor`, `Program.cs`, estilos públicos e layout base.
- Pacotes, serviços e estilos públicos.
- Estratégia inicial de dados, autenticação e integrações.
- Telas ou módulos prioritários.
- Convenções locais de rota, menu, docs ou showcase.

## Fora de Escopo

- Implementação detalhada de componente da biblioteca.
- Definição detalhada de tela que deva virar `screen spec`.
- Expansão da biblioteca que pertença a `lib-spec`.

## Quadro As-Is / To-Be

### As-Is

- Preencher quando o app já existir.

### To-Be

- Descrever a mudança desejada ou o alvo final do app.

## Hipótese Estrutural

- Host Blazor e justificativa.
- Shell principal e justificativa.
- Convenção de navegação e rota.

## Critérios de Completude da Spec

- [ ] A estrutura de projetos do app foi definida.
- [ ] A estratégia de referência a Yasamen foi definida.
- [ ] Ficou explícito o que é referência ou pacote confirmado e o que é candidato.
- [ ] A configuração inicial de `Program.cs`, `_Imports.razor` e estilos foi definida.
- [ ] O host Blazor foi escolhido e justificado.
- [ ] O shell principal foi definido.
- [ ] A convenção de navegação e rota foi definida.
- [ ] Os pacotes, estilos e serviços públicos de Yasamen foram identificados.
- [ ] A estratégia inicial de dados, autenticação e integrações foi definida.
- [ ] As telas ou módulos prioritários foram listados.
- [ ] As dependências de `screen spec` foram identificadas.
- [ ] Os limites entre consumo e expansão da biblioteca ficaram claros.

## Critérios de Prontidão para Execução

- [ ] Existe `delivery.md` preenchido ao final do trabalho.
- [ ] O handoff do app está pronto para scaffolding, `screen specs` ou execução direta.
- [ ] As convenções locais do projeto ficaram explícitas.
