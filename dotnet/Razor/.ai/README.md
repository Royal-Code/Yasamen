# Camada de IA

Esta pasta concentra a base conceitual e operacional usada por IA e por humanos para planejar, especificar, implementar e revisar trabalho neste repositório.

Ela está organizada em três camadas:

- `portátil`: pode ser levada para outro projeto que use Yasamen;
- `adapter yasamen`: conecta o fluxo portátil ao uso real da biblioteca;
- `expand`: cobre a evolução da própria biblioteca e do repositório Yasamen.

## Entradas Ativas

Estes são os pontos de entrada curtos e estáveis:

- [station.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/station.md)
- [lib-spec.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/lib-spec.md)
- [app-spec.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/app-spec.md)
- [screen-spec.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/screen-spec.md)

## Estrutura

- [guides/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/guides): conhecimento normativo.
- [instructions/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions): fluxos operacionais e instruções por tarefa.
- [templates/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/templates): moldes canônicos por domínio.
- [ui-map/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/ui-map): catálogo, padrões e mapeamento de UI.
- [roadmap/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/roadmap): priorização, planos e sequência de evolução.
- [specs/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/specs): specs concretas e entregas.

## Quando usar cada entrada

- `station`: entrada portátil para roteamento entre `app-spec`, `screen-spec`, `yasamen` e encaminhamento para `lib-spec`.
- `app-spec`: planeamento e autoria de apps consumidores que usam Yasamen.
- `screen-spec`: planeamento e autoria de telas.
- `lib-spec`: expansão da biblioteca.
- `yasamen`: execução direta no repositório ou em app consumidor quando a solução já estiver clara.

## Papel de cada área

- `guides`: regras, padrões e critérios de decisão.
- `instructions`: como executar uma tarefa.
- `templates`: forma dos artefatos.
- `ui-map`: catálogo, `Page Pattern`, `Shell Pattern` e mapeamento tecnológico.
- `roadmap`: backlog, fases, planos e protocolos de apoio.
- `specs`: instâncias concretas de `app spec`, `screen spec` e `lib spec`.

## Regras de Organização

- `guides` definem regras, padrões e critérios de decisão.
- `instructions` dizem como executar uma tarefa.
- `templates` definem a forma dos artefatos.
- `specs` guardam trabalho concreto, não templates.
- `ui-map` guarda conhecimento de produto, padrões e cobertura de UI.
- `roadmap` guarda o que priorizar e em que ordem.

## Relação com `.github`

`.ai` é a base de conhecimento e organização.

`.github` é a camada operacional do Copilot:

- agentes;
- instruções do Copilot;
- integrações futuras, como hooks e skills.

Regra:

- a lógica canônica vive em `.ai`;
- `.github` apenas projeta essa lógica para o Copilot.

## Legado

Material antigo ou fora do fluxo ativo deve ir para:

- [`.old/`](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.old)

Regra:

- manter na camada ativa apenas o que participa do fluxo atual.

