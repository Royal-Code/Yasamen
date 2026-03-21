# Skill `lib-spec` para Codex

Este diretório guarda a versão do repositório para o skill de `library specs`.

## Objetivo

Fornecer no Codex o equivalente funcional de [`lib-spec.agent.md`](../../../.github/agents/lib-spec.agent.md), mas no formato nativo de skill.

## Organização

- O material específico do Codex fica em `.codex/`.
- O material agnóstico de ferramenta continua em `.ai/`.

## Como usar

Exemplos de prompt:

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Quero planejar a próxima spec.
```

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Refine a spec `search-field`.
```

```text
Use $lib-spec e leia `.ai/lib-spec.md`. Implemente a spec `search-field`.
```

## Descoberta pelo Codex

Se quiser que a instalação local do Codex descubra este skill automaticamente, aponte `%USERPROFILE%\.codex\skills\lib-spec` para este diretório versionado no repositório.

Exemplo:

```powershell
New-Item -ItemType SymbolicLink `
  -Path "$env:USERPROFILE\.codex\skills\lib-spec" `
  -Target "C:\git\github\royal-code\Yasamen\dotnet\Razor\.codex\skills\lib-spec"
```

## Fonte de verdade

- O comportamento do skill fica versionado aqui.
- As instruções de domínio continuam no próprio repositório, especialmente em:
  - `.ai/lib-spec.md`
  - `.ai/instructions/flows/expand/*`
  - `.ai/templates/lib/spec/*`
  - `.ai/guides/expand/cross-cutting-component-decisions.md`
