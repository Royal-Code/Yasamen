# Design - <Nome do Componente>

## Decisões de Estrutura

- Pacote alvo e justificativa.
- Declarar explicitamente se o pacote já existe ou se precisará ser criado.
- Se precisar de pacote novo, registrar que a implementação deverá executar o subfluxo técnico de criação de projeto antes do componente.
- Namespaces públicos e internos.
- Referências diretas realmente necessárias no `.csproj`.
- Relação com componentes já existentes.

## Composição, Dependências e Ordem de Implementação

- Classificar o componente como primitivo base ou componente composto.
- Listar quais componentes existentes serão reutilizados.
- Identificar dependências naturais no plano de componentes.
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
- Página de demonstração no docs client.
- Cenários de exemplo para validação humana e critério esperado de aceite.
- Relação futura com hosts de showcase alternativos, se existirem.

## Showcase no Docs

- Rota da página em `/demo/...`.
- Caminho físico em `Pages/Demo/...`.
- Grupo e item de menu.
- Estrutura da página conforme guide de showcases.
- Cenários obrigatórios do showcase para este componente.

## Riscos e Questões em Aberto

- Dependências novas ou controversas.
- Decisões que ainda precisam de validação.
- Trade-offs assumidos para o primeiro release.

## Validação Esperada

- Build e projetos afetados que devem ser executados.
- Testes mínimos esperados.
- Validação manual esperada no showcase.
- Validação humana esperada e quem deve aprovar o aceite, quando aplicável.
- Impactos esperados no mapa de UI e no plano de UI, se houver.
