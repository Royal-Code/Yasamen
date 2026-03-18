# Instructions

Este índice organiza as instruções por papel lógico e por domínio.

## Entradas Principais

- [station.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/station.md)
- [lib-spec.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/lib-spec.md)
- [screen-spec.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/screen-spec.md)

## Grupos

- [expand/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions/expand): ações para expandir a biblioteca.
- [yasamen/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions/yasamen): ações para usar Yasamen em apps e telas.
- [rules/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions/rules): instruções genéricas e transversais.
- [flows/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions/flows): fluxos orientados por domínio.
- [agents/](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/instructions/agents): documentação conceitual de comportamento de agentes.

## Mapa Atual

### Fluxos de expansão da biblioteca

Conteúdo canônico:

- [flows/expand/select-next-spec.md](flows/expand/select-next-spec.md)
- [flows/expand/plan-spec.md](flows/expand/plan-spec.md)
- [flows/expand/create-spec.md](flows/expand/create-spec.md)
- [flows/expand/refine-spec.md](flows/expand/refine-spec.md)
- [flows/expand/implement-spec.md](flows/expand/implement-spec.md)
- [expand/create-library-project.md](expand/create-library-project.md)

### Fluxos de telas

Conteúdo canônico:

- [flows/screens/plan-screen.md](flows/screens/plan-screen.md)
- [flows/screens/create-screen-spec.md](flows/screens/create-screen-spec.md)
- [flows/screens/refine-screen-spec.md](flows/screens/refine-screen-spec.md)

### Uso do Yasamen

Conteúdo ativo:

- [yasamen/install-yasamen-packages.md](yasamen/install-yasamen-packages.md)
- [yasamen/create-blazor-yasamen-project.md](yasamen/create-blazor-yasamen-project.md)
- [yasamen/create-or-edit-screen.md](yasamen/create-or-edit-screen.md)

Escopo:

- instalar pacote;
- configurar serviços;
- criar projeto front-end que usa Yasamen;
- criar ou editar telas consumidoras da biblioteca.

## Regras Operacionais

- Para componente ou spec, use também [cross-cutting-component-decisions.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/guides/rules/cross-cutting-component-decisions.md).
- Para tela, use também [planning-and-ui-mapping.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/guides/screens/planning-and-ui-mapping.md) e [cross-cutting-screen-decisions.md](/c:/git/github/royal-code/Yasamen/dotnet/Razor/.ai/guides/rules/cross-cutting-screen-decisions.md).
- `station` é a entrada portátil; para expansão da biblioteca, encaminhe para `lib-spec`.
- Pedido de pacote novo via `lib-spec` é `spec-first` por padrão.

## Agentes Preferenciais

- `@spec-station`
- `@lib-spec`
- `@screen-spec`
- `@yasamen`

