# Protocolo: Caracterização de componente

## Regras

Regras que a IA deve seguir estritamente:
- Executar antes de redigir requisitos em `spec-discovery.md`.
- Classificar o componente com base em `.ai/rules/component-profiles.md`.
- Não inventar características sem indicar a fonte (código atual, Razor ou regra).
- Marcar sugestões sem fonte verificável explicitamente como "sugestão da IA".
- Conduzir entrevista com o humano agrupada por tema. Limitar a três a cinco perguntas por rodada.
- Não presumir resposta. Tratar cada item como `incluir`, `excluir` ou `futuro` apenas após confirmação.

## Arquivos a ler

- `.ai/rules/component-profiles.md`: catálogo de perfis e características-base.
- `.ai/rules/architecture.md`, `component-anatomy.md`, `tokens.md`: padrões técnicos do projeto.
- Componente equivalente em `dotnet/Razor`: paridade e capacidades existentes.
- Código atual em `src/lib/components/`: quando o componente já existir parcialmente.

## 1. Classificar e levantar

1. Identificar o perfil do componente conforme `.ai/rules/component-profiles.md` (Ação, Overlay, Layout, Entrada, Exibição, Navegação, Feedback ou Coleção).
2. Levantar as características-base do perfil: estados, variações, props, interação e teclado, acessibilidade e slots.
3. Adaptar à realidade do Yasamen: tipos `Themes`, `Sizes`, suporte a `navigateTo`, suporte a `Ripple` e paridade com o Razor.
4. Montar a matriz de características com as colunas: Característica, Categoria, Sugestão (`incluir`, `excluir`, `futuro`) e Fonte verificada.

### GATE SC.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- perfil classificado com base em `component-profiles.md`;
- matriz de características montada com fonte para cada item;
- nenhuma característica sem marcação inicial proposta.

## 2. Entrevistar o humano

Somente após gate `SC.1` satisfeito.

1. Apresentar ao humano a classificação do componente e a matriz proposta de características.
2. Formular perguntas objetivas agrupadas por tema (ex.: variações visuais, estados especiais, comportamento de teclado ou composição).
3. Registrar as escolhas do humano:
   - `incluir`: entra na spec atual como requisito e caso de uso.
   - `excluir`: marcado formalmente como fora de escopo.
   - `futuro`: registrado para roadmap ou specs posteriores.

### GATE SC.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu a entrevista de escopo;
- todas as características marcadas definitivamente como `incluir`, `excluir` ou `futuro`;
- matriz consolidada pronta para alimentar `req-{slug}.md`.
