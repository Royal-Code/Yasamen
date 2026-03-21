# Design - <Nome do App>

## Contexto Estrutural

- Host Blazor.
- Shell principal.
- Justificativa estrutural.
- Módulos, áreas ou agrupamentos principais.

## Estrutura de Projetos

- Projetos que serão criados ou reutilizados.
- Papel de cada projeto.
- Integração com a solution.
- Convenção de nomes e pastas.

## Referências e Consumo de Yasamen

- Estratégia de `ProjectReference` ou `PackageReference`.
- Quais projetos ou pacotes entram em cada projeto do app como base confirmada.
- Quais projetos ou pacotes ficam apenas como candidatos, dependentes das telas ou módulos.
- Limites entre consumo público e expansão da biblioteca.

## Quadro As-Is / To-Be

### As-Is

- Estrutura atual do app, quando existir.
- Principais problemas observados.

### To-Be

- Estrutura alvo do app.
- Principais mudanças de shell, layout e navegação.

## Pacotes, Estilos e Serviços

- Pacotes Yasamen base confirmados.
- Pacotes adicionais candidatos por necessidade.
- Estratégia de carga de estilos.
- Serviços públicos e onde serão registrados.

## Dados, Autenticação e Integrações

- Estratégia inicial de dados da primeira entrega.
- Uso de mocks, estado local, API real ou backend ainda não definido.
- Estratégia inicial de autenticação e autorização.
- Integrações externas relevantes ou decisão explícita de que não entram na primeira fase.

Regra:

- em `fundação do app`, este bloco pode ser preenchido como `adiado para evolução funcional`.

## Bootstrapping da Aplicação

- Configuração esperada de `Program.cs`.
- Configuração esperada de `_Imports.razor`.
- Layout inicial, `App.razor` e ponto de entrada relevante.
- Estratégia de carregamento de `yasamen.css`.
- Extensões públicas `AddYasamenXxx(...)` necessárias.

## Navegação e Convenções Locais

- Convenção de rota.
- Convenção de menu ou agrupamento.
- Convenção de docs, demo ou showcase, quando houver.
- Observações de layout local.

## Relação com Telas

- Telas ou módulos prioritários.
- Quais precisam de `screen spec`.
- Quais podem seguir direto para execução.
- Dependências e ordem sugerida.

Regra:

- em `fundação do app`, este bloco pode registrar apenas direção inicial e derivação futura, sem inventar backlog funcional.

## Limites e Escalonamento

- O que fica em `app-spec`.
- O que deve escalar para `screen-spec`.
- O que deve escalar para `lib-spec`.
- O que pode seguir direto por `yasamen`.

## Riscos e Questões em Aberto

- Ambiguidades estruturais.
- Gaps de biblioteca ainda não resolvidos.
- Dependências externas ao escopo do app.

## Validação Esperada

- Revisão do shell e do host escolhido.
- Revisão da convenção de navegação e rotas.
- Revisão do consumo de Yasamen.
- Revisão da estratégia de dados, autenticação e integrações, quando fizer parte do escopo atual.
- Lista de `screen specs` e gaps derivados.
