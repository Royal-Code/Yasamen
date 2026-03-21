# Copilot Instructions

Esta pasta contém instruções operacionais do Copilot.

## Regra de arquitetura

- a fonte principal de conhecimento continua em `.ai/`;
- esta pasta referencia e projeta esse conhecimento para o Copilot.

## Escopo típico

- instruções por caminho;
- reforço de comportamento de agentes;
- alinhamento entre Copilot e a base documental de `.ai`.

Agentes de domínio ativos:

- `spec-station`
- `lib-spec`
- `app-spec`
- `screen-spec`
- `spec-review`
- `yasamen`

## Instruções legadas arquivadas

As instruções ligadas a orquestradores antigos foram movidas para:

- [`.old/.github/instructions/`](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.old/.github/instructions)

Regra:

- o fluxo novo deve partir dos agentes ativos e dos arquivos em `.ai/`;
- as instruções em `.old/` servem apenas como histórico.

