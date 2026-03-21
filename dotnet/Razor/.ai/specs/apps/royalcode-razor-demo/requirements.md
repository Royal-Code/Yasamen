# Requirements - RoyalCode.Razor.Demo

## Metadados

| Campo | Valor |
|---|---|
| Status | `Rascunho estruturado` |
| Tipo | `App novo` |
| Host Blazor | `Blazor Web App client/server com projeto client WebAssembly` |
| Shell principal | `Shell corporativo-demo com navegação lateral por áreas` |
| Alvo | `App consumidor com Yasamen` |
| Artefato relacionado | `Aplicação de demonstração` |
| Guides aplicados | `using-yasamen-in-blazor`, `consumer-app-conventions`, `cross-cutting-app-decisions` |

## Objetivo

Planejar a fundação de um novo app demo client/server para apresentar as funcionalidades públicas das bibliotecas Yasamen em um contexto de aplicativo corporativo, consumindo os projetos diretamente da solution por `ProjectReference` em vez de instalar pacotes NuGet.

## Contexto do App

- Tipo de sistema: app de demonstração técnica e funcional.
- Utilizadores principais: equipa de desenvolvimento, revisão técnica, validação visual e apresentação interna das bibliotecas.
- Natureza: app nova.
- Host Blazor esperado: `Blazor Web App` com host server e projeto client WebAssembly, seguindo a interpretação confirmada de `client/server`.
- Entradas disponíveis: pedido do utilizador, convenções de consumo Yasamen e referência técnica local do host de docs da solution.

## Escopo

- Criar a fundação estrutural de um demo app composto por:
  - `RoyalCode.Razor.Demo` como projeto de host server.
  - `RoyalCode.Razor.Demo.Client` como projeto client WebAssembly.
- Integrar os projetos à solution atual.
- Adotar `ProjectReference` para os projetos Yasamen usados pelo demo.
- Definir shell, layout e navegação base com perfil corporativo.
- Definir configuração inicial de `_Imports.razor`, `Program.cs`, estilos públicos e ponto de entrada.
- Definir referências confirmadas e candidatas de Yasamen para a fundação do app.
- Definir convenção inicial de rotas, agrupamento por áreas e política local de demonstração.
- Preparar o handoff para scaffolding base e posterior evolução funcional.

## Fora de Escopo

- Implementação detalhada das telas de demonstração.
- Backlog funcional completo por módulo de negócio ou por família de componentes.
- Expansão de componentes ou criação de pacotes novos da biblioteca.
- Definição detalhada de `screen specs` antes da validação da fundação do app.

## Quadro As-Is / To-Be

### As-Is

- Não existe `app spec` anterior para este demo.
- A solution já possui uma referência técnica local de host client/server em `RoyalCode.Razor.Docs`, mas ela não deve ser tratada como justificativa de produto do novo app.

### To-Be

- Novo app demo `RoyalCode.Razor.Demo` com host server e client WebAssembly.
- Shell corporativo de apresentação das bibliotecas, com navegação lateral por áreas de demonstração.
- Consumo direto dos projetos Yasamen via `ProjectReference`.
- Estrutura pronta para crescimento incremental por áreas, telas e roteiros de demo.

## Hipótese Estrutural

- Host Blazor: `Blazor Web App` com renderização interativa server + WebAssembly, porque atende o pedido `client/server` e já possui referência técnica local madura na solution.
- Shell principal: aplicação corporativa de demonstração com menu lateral persistente, topo de contexto e área principal para experiências guiadas.
- Convenção de navegação e rota: rotas por áreas de demonstração, com agrupamento inicial por `visão geral`, `fundamentos`, `navegação`, `formulários`, `feedback` e áreas futuras.

## Critérios de Completude da Spec

- [x] A estrutura de projetos do app foi definida.
- [x] A estratégia de referência a Yasamen foi definida.
- [x] Ficou explícito o que é referência ou projeto confirmado e o que é candidato.
- [x] A configuração inicial de `Program.cs`, `_Imports.razor` e estilos foi definida.
- [x] O host Blazor foi escolhido e justificado.
- [x] O shell principal foi definido.
- [x] A convenção de navegação e rota foi definida.
- [x] Os projetos, estilos e serviços públicos de Yasamen foram identificados.
- [x] A estratégia inicial de dados, autenticação e integrações foi explicitamente adiada.
- [x] As telas ou módulos prioritários foram explicitamente adiados para evolução posterior.
- [x] As dependências de `screen spec` foram identificadas ou adiadas.
- [x] Os limites entre consumo e expansão da biblioteca ficaram claros.

## Critérios de Prontidão para Execução

- [x] Existe `delivery.md` preenchido ao final do trabalho.
- [x] O handoff do app está pronto para scaffolding base.
- [x] As convenções locais do projeto ficaram explícitas.
