# Delivery - RoyalCode.Razor.Demo

## Status Final

- `Spec de fundação pronta para scaffolding base`

## Resumo

- Foi definida a fundação de um novo demo app `RoyalCode.Razor.Demo` com host `Blazor Web App` client/server.
- O app foi posicionado como aplicativo corporativo para apresentação das funcionalidades públicas das bibliotecas Yasamen.
- A estratégia de consumo foi fechada com `ProjectReference` para projetos da solution, sem instalação de pacotes NuGet do próprio Yasamen.
- O shell base, o bootstrapping público e a convenção inicial de rotas ficaram definidos.
- Dados, autenticação, integrações e telas detalhadas ficaram explicitamente adiados para evolução posterior.

## Changelog

- `Added`:
  - app spec inicial de `RoyalCode.Razor.Demo`;
  - estrutura base de host server + client WebAssembly;
  - estratégia de `ProjectReference` e bootstrapping público;
  - convenção inicial de shell corporativo-demo.
- `Changed`:
  - não se aplica; trata-se de app nova.
- `Deferred`:
  - telas detalhadas do demo;
  - `screen specs`;
  - dados, autenticação e integrações;
  - backlog funcional por áreas.

## Rastreabilidade

| Origem | Item | Evidência | Status |
|---|---|---|---|
| `using-yasamen-in-blazor.md` | consumo público da biblioteca | `design.md` | `OK` |
| `consumer-app-conventions.md` | convenções locais do app | `design.md` | `OK` |
| `cross-cutting-app-decisions.md` | checkpoints estruturais do app | `requirements.md` | `OK` |
| pedido do utilizador | app demo client/server com `ProjectReference` | `requirements.md` e `design.md` | `OK` |

## Dependências Derivadas

- `screen specs` necessárias:
  - visão geral do demo;
  - catálogo de bibliotecas e áreas de demonstração;
  - jornadas ou roteiros guiados, quando esse recorte for confirmado.
- Gaps que podem escalar para `lib-spec`:
  - qualquer componente reutilizável ausente necessário para as narrativas do demo.
- Itens que podem seguir por `yasamen`:
  - scaffolding dos projetos;
  - configuração inicial do host e do client;
  - implementação do shell base.

## Validação

- Host e shell revisados.
- Navegação e rotas base revisadas.
- Estratégia de consumo por `ProjectReference` revisada.
- Limites entre fundação do app e evolução funcional registrados.

## Próximo Passo Recomendado

- `Criar o projeto consumidor`
