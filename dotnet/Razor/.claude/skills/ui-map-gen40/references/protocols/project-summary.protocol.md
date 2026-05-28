# Protocolo project summary

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Regras para validação da clareza de caminhos:
- Se for repositório com acesso ao código fonte:
  - Garantir que o humano forneceu os locais onde ficam o código fonte, documentação e exemplos;
- Se for biblioteca pública:
  - Garantir que o humano passou os links da biblioteca, ou pesquisar na internet o que pode ser achado;
  - Verificar os links e validar o acesso a documentação da biblioteca;
  - Apresentar um feedback do que foi encontrado ao humano;
  - Antes de seguir, validar com humano se o que foi encontrado é suficiente;

[INSTRUÇÃO] O sumário/resumo do componente deve ser baseado em evidências, não se deve inventar ou deduzir algo que não está claro.

[INSTRUÇÃO] Ambiguidades devem ser declaradas; não forçar o componente onde não se encaixa naturalmente.

[INSTRUÇÃO] Não deduzir o que o componente é o faz pelo nome, mas sim analisando os fontes, exemplos e documentação.

## Arquivos a ler

- `state.template.yaml` para entender a estrutura do documento `state.yaml`;
- `components-summary.template.md` para guiar a produção de `components.summary.md`.
- `patterns.group.md` para entender os padrões de grupos.

## 1. Iniciar UI-MAP

1. Identificar as entradas, prompts, respostas do humano e avaliar as informações:
- está claro se é repositório de código ou documentação web;
- os caminhos para analisar estão claros;
- bibliotecas extras informadas ou afirmado que não existem;
- nome (slug) da biblioteca informado ou identificado;
- não inventar; não inferir sobre dúvidas ou ambiguidades;

2. Realizar perguntas até satisfazer as questões acima.

3. Criar diretório de trabalho
- criar a pasta de trabalho em `.ai/ui-map/{slug-nome-lib}/`;
- criar as outras pastas dentro do diretório de trabalho usadas pelo workflow.

4. A partir dos diretórios ou URL investigue quais poderão ser usados e qualifique-os em:
- `code` para diretórios onde estão os códigos fontes de componentes;
- `docs` para diretórios que tenham documentações;
- `samples` para diretórios que tenham código fonte para exemplos;
- `stories` para diretórios que tenham stories como storybook ou similar.

5. Identifique a plataforma da biblioteca entre: `Web`, `Mobile nativo`, `Desktop nativo`.

6. Criar `state.yaml` conforme regras do workflow e garanta:
- que `directory`, `library`, `auxiliary_libraries` e `tasks` foram preenchidas direito;
- que as propriedades de `library` estejam preenchidas;
- que em `sources` foram adicionados todos paths e urls de código, documentação, exemplos e stories.
- que a `task` foi criada com o tipo `ui-map` e as outras propriedades escritas.

### GATE PS.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- questionado o humano se algum ponto não estava claro;
- diagnóstico apresentado ao humano quando for documentação web;
- diretório de trabalho criado.
- `state.yaml` criado com todas as informações preenchidas conforme o template.
- `library.sources` contém os diretórios de fontes, documentação e exemplos.

## 2. Criar resumo dos componentes

[INSTRUÇÃO] Somente após gate `PS.1` satisfeito.

1. levantar componentes
- olhar todos os caminhos fornecidos;
- identificar componentes, documentação, storybook, exemplos e outras informações disponíveis;
- para cada componente levantar:
  - nome do componente,
  - as propriedades declaradas no template segundo sua descrição,
  - classificar cada componente em um grupo conforme os grupos de patterns;
- criar `components.summary.md` detalhando os componentes disponíveis da biblioteca;
- criar seções para cada componente conforme template `components-summary.template.md`;
- garantir que todos os componentes tenham as propriedades e conteúdos declarados no template.

### GATE PS.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos caminhos, pastas, subpastas investigadas.
- criada uma seção para cada componente existente.
- estrutura e conteúdo das seções seguem fielmente o template.
- `components.summary.md` criado e persistido.

## 3. Levantar estrutura do projeto

[INSTRUÇÃO] Somente após gate `PS.2` satisfeito.

[INSTRUÇÃO] Se não for `repositório de código` terminar esta seção gerando o arquivo `structure.md` informando que não é possível criar a estrutura pois o tipo `documentação web`.

[INSTRUÇÃO] Quando for `repositório de código` siga os passos a seguir.

1. Levantar estrutura do projeto
- levante linguagem, stack, libs dependentes, arquitetura do componentes e projetos;
- analisar estrutura de pastas, projetos e organização;
- detectar como são organizados os componentes, projetos, css, js, outros;
- procure levantar conteúdo para:
  - como os fontes são organizados, pastas, projetos, interno\externo,
  - como os styles, themes, UI resources e presentations são organizados,
  - como os testes são projetados e organizados,
  - como a documentação é criada e organizada,
  - como storybook e exemplos são criados e organizados,
  - como é feita a composição entre componentes,
  - convenções de naming dos componentes da biblioteca (sufixos, prefixos, estilo semântico vs descritivo, padrões compound como `Card.Header`, alinhamento com convenções de stacks populares quando aplicável),
  - o que fazer para criação de novos componentes;
- não se limitar apenas a isso, todo padrão, organização e informação útil pode ser documentada.

2. Montar o arquivo `structure.md` definindo como é organizado o repositório, de modo que se for preciso criar novos componentes ele sirva de guia de onde criar e como organizar os artefatos.
- o `structure.md` deve ser completo o suficiente para que outra IA consiga criar um novo componente seguindo exatamente o mesmo padrão de organização, imports, exports e convenções.

### GATE PS.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- o arquivo `structure.md` foi criado e persistido.
- quando for `repositório de código`, o projeto foi analisado, sua estrutura documentada.

## 4. Guia UI

[INSTRUÇÃO] Somente após gate `PS.3` satisfeito.

1. Identificar a família técnica da biblioteca a partir das fontes:
- `web` — CSS, SCSS, Less, CSS Modules, Tailwind, CSS-in-JS, styled-components, CSS variables ou theme API web/CSS-like;
- `theme` — Flutter, Jetpack Compose, SwiftUI, React Native ou stack com camada theme-like como paradigma;
- `ui-resources` — XAML, WPF, WinUI, UWP, MAUI ou stack com resource dictionaries;
- `presentation` — Qt/QML, GTK, JavaFX, Compose Desktop sem tema claro ou stack com paradigma de apresentação próprio;
- `none` — biblioteca sem camada visual técnica mapeável.

2. Confirmar com o humano quando a evidência for ambígua entre famílias (parar e questionar).

3. Registrar `library.technical_family` no `state.yaml`, caso ainda não foi identificado.

4. Executar uma das subseções conforme a família:
- quando `web` execute `4.1 Style guide`;
- quando `theme` execute `4.2 Theme guide`;
- quando `ui-resources` execute `4.3 UI resources guide`;
- quando `presentation` execute `4.4 Presentation guide`;
- quando `none` execute `4.5 Sem guide`;

[INSTRUÇÃO] objetivos gerais para criar guia ui:
- levantar tokens, styles, themes, UI resources e presentations conforme tecnologia
- web = CSS-like; mobile = theme; windows = ui resources; other = presentation;
- como é o design system, tokens;
- quais libs, frameworks usam;
- quais as regras;
- como são estruturados nos componentes;
- onde se encontram a documentação e referência do conteúdo levantado;
- o que fazer para criação de novos componentes;
- estes objetivos são satisfeitos pela execução da subseção correspondente; não executar fora dela;
- isto não substitui os passos e orientações de cada subseção específica.

[INSTRUÇÃO] ao produzir `ui-guide.md`:
- organizar no formato mais útil para a stack analisada;
- usar tabelas, diagramas, receitas ou snippets quando reduzirem ambiguidade;
- manter foco em arquitetura e consumo técnico da camada de tema.

### 4.1 Style guide

[INSTRUÇÃO] Somente se família técnica for `web`.

1. Identificar arquitetura de estilos:
- camadas de base, tema, componente, utilitário, override e customização;
- arquivos de entrada e saída de build quando existirem;
- dependências, plugins, CDN, packages ou ferramentas de estilo;
- relação entre estilo interno da lib e consumo pelo app.

2. Levantar recursos concretos:
- tokens, classes, variáveis CSS, mixins, theme keys, props de estilo, utilitários e prefixos;
- cores, tipografia, spacing, dimensões, bordas, radius, shadows/elevation, z-index, motion, breakpoints e assets;
- variantes, estados visuais, responsividade, overrides e extensões.

3. Registrar exemplos reais:
- snippets de uso;
- padrões de composição;
- consumo recomendado pela IA;
- limitações, lacunas, recursos internos e zonas de cuidado.

4. criar `ui-guide.md` e persistir.

### 4.2 Theme guide

[INSTRUÇÃO] Somente se família técnica for `theme`.

1. Identificar arquitetura de tema:
- providers, theme objects, environment, composition locals, contextos ou equivalentes;
- relação entre tema global, tema local, componente, modifier/prop/style e token;
- pontos de extensão, override e configuração por plataforma.

2. Levantar recursos concretos:
- color scheme, typography, shapes, spacing/dimensions, elevation/shadow, motion, icons/assets e density;
- dark/light mode, dynamic color, safe areas, orientation, device classes e recursos adaptativos;
- tokens, theme keys, modifiers, props, assets e componentes ligados ao tema.

3. Registrar comportamento visual:
- variantes e estados: enabled, disabled, pressed, selected, focused, error, loading, empty ou equivalentes;
- acessibilidade visual: text scaling, contrast, reduced motion, hit target, focus/semantics quando afetar aparência;
- exemplos reais, limitações, lacunas e zonas de cuidado.

4. criar `ui-guide.md` e persistir.

### 4.3 UI resources guide

[INSTRUÇÃO] Somente se família técnica for `ui-resources`.

1. Identificar arquitetura de resources:
- resource dictionaries, merged dictionaries, themes, static/dynamic resources ou equivalentes;
- styles e templates: control styles, control templates, data templates, implicit/explicit styles;
- localização de arquivos, namespaces, build e recursos gerados.

2. Levantar recursos concretos:
- brushes, colors, thickness, corner radius, typography, dimensions, icons/assets, shadows/elevation e density;
- resource keys, style keys, template keys, components/controls, visual states, triggers e themes;
- recursos públicos, internos, herdados, gerados ou restritos.

3. Registrar comportamento visual:
- estados visuais: focus, keyboard, disabled, validation, selection, hover/pressed quando aplicável;
- adaptação do sistema: high contrast, accent color, DPI scaling, window chrome, light/dark theme e density;
- exemplos reais, limitações, lacunas e zonas de cuidado.

4. criar `ui-guide.md` e persistir.

### 4.4 Presentation guide

[INSTRUÇÃO] Somente se família técnica for `presentation`.

1. Identificar paradigma de apresentação:
- widget tree, scene graph, renderer, markup, skinning, style engine, config ou API proprietária;
- relação entre componente, layout, estado, asset, efeito, tema/config e extensão;
- pontos públicos, internos, gerados e não editáveis.

2. Levantar recursos concretos:
- componentes, propriedades, tokens/configs, assets, palettes, layouts, slots, states, effects, transitions e overlays;
- containers, layout primitives, navigation, dialogs, feedback e regras de composição;
- recursos de plataforma: janela, DPI, input mouse/teclado/touch, foco, temas do sistema e acessibilidade.

3. Registrar exemplos reais:
- snippets ou trechos equivalentes;
- padrões de composição;
- consumo recomendado pela IA;
- limitações, lacunas, recursos internos e zonas de cuidado.

4. criar `ui-guide.md` e persistir.

### 4.5 Sem guide

[INSTRUÇÃO] Somente se família técnica for `none`.

1. Crie o arquivo `ui-guide.md` informando que não há uma família técnica identificada para a biblioteca.

### GATE PS.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- família técnica da biblioteca identificada.
- em caso de ambiguidade, o humano foi questionado.
- subseção executada conforme família técnica.
- o `ui-guide.md` criado e persistido.

## 5. Finalização

[INSTRUÇÃO] Somente após gate `PS.4` satisfeito.

1. atualizar estado da `task` do `state.yaml` como etapa concluída.

2. apresentar ao humano um resumo do que foi feito na etapa.

3. delegar o workflow a execução da etapa 2 do fluxo `gerar-ui-map`.

### GATE PS.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5.
- todos gates internos satisfeitos: `PS.1`, `PS.2`, `PS.3`, `PS.4`.
- `state.yaml` atualizado com stage concluído e `next_action` apontando para `visual-language`.
