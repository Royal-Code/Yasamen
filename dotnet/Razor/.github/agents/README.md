# Agents

Esta pasta contém os arquivos operacionais de agentes do Copilot.

## Regra de arquitetura

- a definição conceitual e os fluxos vivem em `.ai/`;
- os arquivos desta pasta só fazem o deploy dessas decisões para o Copilot.

## Agentes ativos preferenciais

- `spec-station`
- `lib-spec`
- `app-spec`
- `screen-spec`
- `yasamen`

## Agentes especializados ainda ativos

- `component-review`
- `showcase-docs`

## Agentes legados arquivados

Os antigos orquestradores, planners, authors e implementers foram movidos para:

- [`.old/.github/agents/`](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.old/.github/agents)

Regra:

- não usar esses agentes como entrada de trabalho nova;
- só consultar por histórico ou transição.

