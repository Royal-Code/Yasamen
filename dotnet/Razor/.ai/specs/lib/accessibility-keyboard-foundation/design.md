# Design — Accessibility Keyboard Foundation

## Decisões de Estrutura

- Esta é uma spec transversal; não cria um pacote novo.
- A implementação tende a tocar vários projetos já existentes, principalmente:
  - `RoyalCode.Razor.Navigation`
  - `RoyalCode.Razor.Modals`
  - `RoyalCode.Razor.OffCanvas`
  - `RoyalCode.Razor.Drops`
  - `RoyalCode.Razor.Forms`
  - `RoyalCode.Razor.Buttons`
  - `RoyalCode.Razor.Alerts`
  - `RoyalCode.Razor.Styles`
  - `RoyalCode.Razor.Docs.Client`
- O objetivo não é criar helpers genéricos cedo demais; o primeiro foco é consolidar comportamento real em componentes âncora.

## Entregáveis Estruturais

### Matriz mínima

A entrega deve produzir uma matriz prática de requisitos por família:

- botões e gatilhos;
- navegação;
- overlays e outlets;
- formulários;
- listas interativas, se algum caso entrar na primeira onda.

Essa matriz pode nascer primeiro na própria spec e em `delivery.md`, e virar guide posterior quando houver base implementada suficiente.

### Componentes âncora sugeridos

Primeira onda recomendada:

- `Pagination`
- `Modal`
- `OffCanvas`
- `Drop`
- `TextField`

Componentes adicionais podem entrar se o custo for baixo e a convergência for clara.

## Regras por Família

### Navegação

- Usar semântica de navegação quando aplicável.
- Indicar item atual de forma semântica.
- Garantir previsibilidade em bordas e teclado.
- Validar especificamente `Pagination`.

### Overlays e outlets

- Garantir abertura e fechamento coerentes por teclado.
- Garantir foco inicial e restauração de foco quando aplicável.
- Garantir escape previsível em `Modal` e `OffCanvas`.
- Tratar `Drop` como caso separado, por ser mais próximo de comportamento local com interop.

### Formulários

- Garantir associação entre label, descrição, erro e campo.
- Garantir foco visível e estado inválido coerente.
- Para campos ainda pouco definidos, seguir `form-components-lightweight.md`.

### Botões e gatilhos

- Garantir semântica nativa sempre que possível.
- Evitar `role="button"` quando um `<button>` resolver.
- Quando não houver botão nativo, justificar teclado e semântica no componente.

## CSS e Contrato Visual

- Melhorias visuais de foco devem seguir `css-visual-contract.md`.
- Sempre que possível, o estado de foco visível deve ficar em `RoyalCode.Razor.Styles`.
- Não usar `*.razor.css` novo como solução padrão para foco e estados públicos.
- O design deve tratar foco visível como parte do contrato público, não como detalhe de implementação.

## Testes e Documentação

- Expandir testes existentes quando já houver projeto de testes adequado.
- Criar testes novos para comportamentos críticos de aria e teclado.
- Atualizar showcases existentes para servir como validação manual.
- Registrar claramente no `delivery.md` o que foi testado por automação e o que foi validado manualmente.

## Showcase no Docs

- Priorizar atualização das páginas já existentes, em vez de abrir uma página transversal nova imediatamente.
- Páginas candidatas:
  - `PaginationPage.razor`
  - `ModalPage.razor`
  - `NotificationsPage.razor`
  - `TextFieldPage.razor`
- Cada página tocada deve mostrar ao menos um cenário ou nota ligada a teclado e acessibilidade.

## Riscos e Questões em Aberto

- Há pouca uniformidade atual entre famílias de componentes.
- A cobertura de testes ainda é desigual entre pacotes.
- Nem todo requisito de acessibilidade deve ser imposto igualmente a todos os componentes.
- Pode surgir necessidade de pequenos helpers internos de foco, mas isso não deve ser antecipado sem uso real.
- A spec depende de disciplina para não virar uma “lista infinita” sem entrega incremental.

## Validação Esperada

- Build dos projetos afetados.
- Testes dos projetos afetados e dos novos testes criados.
- Validação manual por teclado nos showcases atualizados.
- Registro explícito, em `delivery.md`, da matriz aplicada e dos componentes cobertos.
- Base suficiente para derivar um guide futuro de acessibilidade e teclado sem depender apenas de intenção abstrata.


