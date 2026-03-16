# Design — <Nome do Componente>

## Decisões de Estrutura

- Pacote alvo e justificativa.
- Namespaces públicos e internos.
- Referências diretas realmente necessárias no `.csproj`.
- Relação com componentes já existentes.

## API Pública Proposta

### Componentes públicos

- `ComponentePrincipal`
- `SubcomponenteOpcional`

### Parâmetros

- Parâmetros obrigatórios.
- Parâmetros opcionais.
- `AdditionalClasses`.
- `AdditionalAttributes`.

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
- Estrutura da página conforme `09-showcases-and-docs.md`.
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
