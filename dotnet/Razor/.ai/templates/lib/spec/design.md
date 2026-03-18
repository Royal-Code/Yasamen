# Design - <Nome do Componente>

## Decisões de Estrutura

- Pacote alvo e justificativa.
- Declarar explicitamente se o pacote já existe ou se precisará ser criado.
- Se precisar de pacote novo, registrar que a implementação deverá seguir `.ai/instructions/expand/create-library-project.md`.
- Namespaces públicos e internos.
- Referências diretas realmente necessárias no `.csproj`.
- Relação com componentes já existentes.

## Composição, Dependências e Ordem de Implementação

- Classificar o componente como primitivo base ou componente composto.
- Listar quais componentes existentes serão reutilizados.
- Verificar `.ai/roadmap/components-plan-list.md` para identificar dependências naturais.
- Registrar se existe um componente-base ausente que deveria vir antes.
- Se a implementação seguir sem o componente-base ausente, justificar explicitamente.

## API Pública Proposta

### Componentes públicos

- `ComponentePrincipal`
- `SubcomponenteOpcional`

### Parâmetros

- Parâmetros obrigatórios.
- Parâmetros opcionais.
- `AdditionalClasses`.
- `AdditionalAttributes`.

### Variações visuais e dimensionais

- Avaliar explicitamente se o componente suporta `Style: Themes`.
- Se suportar:
  - definir quais temas entram no primeiro release;
  - definir o fallback de `Themes.Default`;
  - definir como o tema afeta classes públicas, estados e showcase.
- Se não suportar:
  - justificar explicitamente por que `Style` não é cabível para este componente.
- Avaliar explicitamente se o componente suporta `Size: Sizes`.
- Se suportar:
  - definir quais tamanhos entram no primeiro release;
  - definir como isso afeta markup, CSS, tipografia, ícones, densidade e showcase.
- Se não suportar:
  - justificar explicitamente por que `Size` não é cabível para este componente.

### Slots e eventos

- `ChildContent` e slots nomeados.
- `EventCallback` e contratos de mudança de estado.

## Estrutura Interna

- Arquivos previstos em `Components/`.
- Tipos internos previstos em `Internal/`.
- Estratégia de estado interno.
- Estratégia para IDs, registro de filhos, helpers ou serviços, quando houver.

## CSS e Contrato Visual

- Arquivo CSS em `RoyalCode.Razor.Styles/wwwroot/css/...`.
- Classes públicas `ya-*`.
- Variantes visuais e classes de estado.
- Tokens de `RoyalCode.Razor.Styles/wwwroot/yasamen.css` que serão usados para cores, espaçamento, tipografia e breakpoints.
- Política explícita de não usar `*.razor.css` novo.

## Testes e Documentação

- Casos mínimos de teste.
- Página de demonstração em `RoyalCode.Razor.Docs.Client`.
- Cenários de exemplo para validação manual.
- Relação futura com `RoyalCode.Razor.Show`, se existir.

## Showcase no Docs

- Rota da página em `/demo/...`.
- Caminho físico em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`.
- Grupo e item de menu em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura da página conforme `showcases-and-docs.md`.
- Cenários obrigatórios do showcase para este componente.

## Riscos e Questões em Aberto

- Dependências novas ou controversas.
- Decisões que ainda precisam de validação.
- Trade-offs assumidos para o primeiro release.

## Validação Esperada

- Build e projetos afetados que devem ser executados.
- Testes mínimos esperados.
- Validação manual esperada no showcase.
- Impactos esperados em `ui-map.md` e `ui-plan.md`, se houver.


