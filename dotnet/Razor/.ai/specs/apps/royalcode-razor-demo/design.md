# Design - RoyalCode.Razor.Demo

## Contexto Estrutural

- Host Blazor: `Blazor Web App` com host server `RoyalCode.Razor.Demo` e projeto client `RoyalCode.Razor.Demo.Client`.
- Shell principal: shell corporativo-demo com menu lateral, cabeçalho contextual e área principal orientada a demonstrações.
- Justificativa estrutural: o pedido exige modo `client/server`, e a solução já prova localmente esse padrão com host ASP.NET Core + projeto client WebAssembly usando serviços públicos e `ProjectReference`.
- Agrupamentos principais na fundação:
  - visão geral do demo;
  - áreas de bibliotecas e capacidades;
  - exemplos guiados;
  - área futura de comparação ou matrizes de cobertura.

## Estrutura de Projetos

- `RoyalCode.Razor.Demo`
  - host server do app;
  - responsável por `AddRazorComponents()`, modos interativos, mapeamento de assets estáticos e hospedagem do projeto client.
- `RoyalCode.Razor.Demo.Client`
  - projeto WebAssembly com as páginas, layouts e demos interativas;
  - concentra `_Imports.razor`, navegação local, registro de serviços públicos Yasamen e composição das telas.

Integração com a solution:

- adicionar ambos os projetos à `Razor.sln`;
- manter o par server/client como app consumidor isolado dos projetos de biblioteca;
- usar `RoyalCode.Razor.Docs` apenas como referência técnica local para a fundação do host.

Convenção de nomes e pastas:

- manter prefixo `RoyalCode.Razor.Demo`;
- pastas de host e client lado a lado na raiz da solution, seguindo o mesmo padrão já usado em `RoyalCode.Razor.Docs`.

## Referências e Consumo de Yasamen

Estratégia:

- usar `ProjectReference` em vez de `PackageReference` para os projetos Yasamen da própria solution;
- consumir apenas APIs públicas, sem dependência de namespaces `Internal.*`;
- registrar apenas extensões públicas do tipo `AddYasamenXxx(...)`.

Base confirmada para a fundação do app:

- `RoyalCode.Razor.Styles`
- `RoyalCode.Razor.Commons`
- `RoyalCode.Razor.Alerts`
- `RoyalCode.Razor.Modals`
- `RoyalCode.Razor.OffCanvas`
- `RoyalCode.Razor.Layouts.Apps`
- `RoyalCode.Razor.Icons`
- `RoyalCode.Razor.Icons.Bootstrap`

Projetos candidatos, dependentes das primeiras áreas e telas:

- `RoyalCode.Razor.Navigation`
- `RoyalCode.Razor.Buttons`
- `RoyalCode.Razor.Forms`
- `RoyalCode.Razor.Breadcrumbs`
- `RoyalCode.Razor.Drops`
- `RoyalCode.Razor.Animations`
- `RoyalCode.Razor.Show`

Limites entre consumo e expansão:

- o app deve apenas demonstrar o que já existe de forma pública;
- qualquer lacuna reutilizável identificada durante a evolução deve ser registrada como possível `lib-spec`.

## Quadro As-Is / To-Be

### As-Is

- não existe app demo dedicado para esta finalidade;
- existe um host técnico local em `RoyalCode.Razor.Docs` que valida o padrão de hospedagem e composição inicial.

### To-Be

- app demo dedicado, separado das docs da biblioteca;
- fundação pronta para demos corporativas por áreas;
- crescimento incremental por rotas, telas e roteiros de apresentação.

## Pacotes, Estilos e Serviços

Projetos Yasamen base confirmados:

- `RoyalCode.Razor.Styles` para `yasamen.css` e estilos públicos.
- `RoyalCode.Razor.Commons` para infraestrutura base.
- `RoyalCode.Razor.Alerts` para notificações e feedback global.
- `RoyalCode.Razor.Modals` para diálogos e overlays.
- `RoyalCode.Razor.OffCanvas` para experiências laterais ou menu móvel.
- `RoyalCode.Razor.Layouts.Apps` para o shell corporativo e menu principal.
- `RoyalCode.Razor.Icons` e `RoyalCode.Razor.Icons.Bootstrap` para iconografia pública.

Serviços públicos esperados no bootstrapping de server e client:

- `AddYasamenCommons()`
- `AddYasamenModal()`
- `AddYasamenOffCanvas()`
- `AddYasamenNotification()`
- `AddYasamenMenu()`
- `BootstrapIcons.Include()`

Estratégia de carga de estilos:

- carregar o CSS público em `_content/RoyalCode.Razor.Styles/yasamen.css`;
- permitir overrides locais do demo apenas em estilos próprios do app, sem copiar CSS interno da biblioteca.

## Dados, Autenticação e Integrações

- estratégia inicial de dados: adiada para evolução funcional;
- primeira fase do app: sem backend de domínio e sem integração externa obrigatória;
- autenticação e autorização: adiadas;
- integrações externas: adiadas.

Justificativa:

- a spec atual está no nível `fundação do app` e não precisa bloquear o scaffolding base por ausência de domínio funcional detalhado.

## Bootstrapping da Aplicação

Configuração esperada de `Program.cs` no host server:

- `AddRazorComponents()` com componentes interativos server e WebAssembly;
- registro dos serviços públicos Yasamen;
- `BootstrapIcons.Include()`;
- `MapStaticAssets()` e `MapRazorComponents<App>()` com `AddInteractiveServerRenderMode()` e `AddInteractiveWebAssemblyRenderMode()`;
- referência adicional ao assembly do projeto client.

Configuração esperada de `Program.cs` no client:

- `WebAssemblyHostBuilder.CreateDefault(args)`;
- `BootstrapIcons.Include()`;
- mesmo conjunto inicial de extensões públicas Yasamen para manter paridade de execução interativa.

Configuração esperada de `_Imports.razor` no client:

- namespaces públicos do app;
- namespaces públicos de `Commons`, `Styles`, `Layouts.Apps`, `Icons` e `Icons.Bootstrap`;
- inclusão apenas de namespaces adicionais conforme áreas futuras confirmarem o uso.

Layout inicial e ponto de entrada relevante:

- `App.razor` e layout principal do client orientados ao shell corporativo-demo;
- página inicial com visão geral da biblioteca e acesso às áreas de demonstração.

## Navegação e Convenções Locais

Convenção de rota inicial:

- `/` para visão geral do demo;
- `/fundamentos/...` para capacidades transversais;
- `/bibliotecas/...` para famílias de bibliotecas ou áreas de demonstração;
- `/roteiros/...` para jornadas guiadas futuras.

Convenção de menu ou agrupamento:

- menu lateral principal por áreas de apresentação;
- cabeçalho com contexto da área atual;
- possibilidade de favoritos ou atalhos futuros sem bloquear a fundação.

Convenção de docs, demo ou showcase:

- o app é um demo próprio, não extensão direta do host de docs atual;
- toda convenção de rota e agrupamento pertence ao novo app consumidor.

Observações de layout local:

- o shell deve parecer um aplicativo corporativo real, não uma galeria solta de componentes;
- a apresentação das bibliotecas deve acontecer dentro de cenários e áreas coerentes.

## Relação com Telas

Direção inicial:

- a fundação prepara as primeiras áreas de demonstração, mas não fecha telas detalhadas nesta spec;
- as primeiras telas prováveis são:
  - visão geral do demo;
  - catálogo das bibliotecas disponíveis;
  - jornada de shell e navegação;
  - áreas futuras para formulários, feedback e interações.

Dependências de `screen spec`:

- abrir `screen specs` quando houver decisão sobre jornadas, áreas prioritárias ou narrativa de demonstração;
- não abrir `screen specs` enquanto a fundação ainda estiver sem scaffold.

## Limites e Escalonamento

- fica em `app-spec`:
  - estrutura do app;
  - host client/server;
  - shell e convenções globais;
  - referências confirmadas e candidatas;
  - bootstrapping e handoff.
- escala para `screen-spec`:
  - definição de páginas do demo;
  - organização de zonas, padrões de página e narrativa das telas.
- escala para `lib-spec`:
  - qualquer gap de componente reutilizável descoberto durante o demo.
- pode seguir direto por `yasamen`:
  - scaffolding do app;
  - configuração inicial dos projetos;
  - implementação da fundação confirmada por esta spec.

## Riscos e Questões em Aberto

- ainda não há decisão sobre a primeira lista de telas detalhadas do demo;
- ainda não há decisão sobre estratégia de dados mockados para demos mais ricas;
- algumas referências candidatas podem deixar de ser necessárias após o primeiro recorte funcional.

## Validação Esperada

- revisão do shell corporativo-demo;
- revisão do host `Blazor Web App` client/server;
- revisão da lista de referências confirmadas versus candidatas;
- revisão do bootstrapping base com serviços públicos e carga de `yasamen.css`;
- validação do handoff para scaffolding do app.
