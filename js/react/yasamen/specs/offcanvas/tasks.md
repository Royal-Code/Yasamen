# Tasks — Offcanvas

## 1. Decisões Confirmadas com o Humano
- [x] O componente espelha o padrão arquitetural de transições por máquina de estados do Modal.
- [x] Suporte obrigatório a posições `left` e `right`.
- [x] Uso do sistema de seções (`SectionContent` / `SectionOutlet`) para permitir injeção a partir de qualquer ponto da árvore.
- [x] Integração transparente com `AppLayout`.

## 2. Questões em Aberto com o Humano
- [ ] Definir se animações devem ter timing customizável por prop ou apenas CSS (definido padrão CSS 150ms/275ms inicial).
- [ ] Definir se múltiplos offcanvases abertos simultaneamente devem empilhar (definido LIFO padrão onde o último tem foco).

## 3. Divisão de Tarefas Implementáveis

### Tarefa 1: Ajuste e Validação da Folha de Estilos CSS
- **Ação**: Atualizar `src/lib/styles/css/components/offcanvas.css` para contemplar todas as fases de transição (`opening-start`, `opening`, `open`, `closing-start`, `closing`, `closed`) para posições start e end, outlet e backdrop.
- **Critérios de Aceite**:
  - [ ] Seletores usam exclusivamente `ya-offcanvas*`.
  - [ ] `@apply` utiliza utilitários existentes como `z-offcanvas`, `z-offcanvas-backdrop`.
  - [ ] Posições `left` e `right` respeitam deslocamentos translate.
- **Validações e Riscos**: Garantir que o build do Tailwind v4 não falhe.

### Tarefa 2: Contexto e Provedor do Sistema Offcanvas
- **Ação**: Implementar `offcanvas-context.ts`, `OffcanvasProvider.tsx` e `OffcanvasBackdrop.tsx` em `src/lib/components/offcanvas/`.
- **Critérios de Aceite**:
  - [ ] Gerencia registro de itens, lista de IDs abertos e despacho de ações.
  - [ ] Disponibiliza `useOffcanvasSystem()` e `useOffcanvasHandler()`.
  - [ ] Trata clique no backdrop e tecla `Escape`.
- **Validações e Riscos**: Evitar memory leak ao desmontar componentes registrados.

### Tarefa 3: Implementação do Componente `<Offcanvas>` e `<OffcanvasOutlet>`
- **Ação**: Implementar `Offcanvas.tsx` e `OffcanvasOutlet.tsx`, completando os arquivos pendentes.
- **Critérios de Aceite**:
  - [ ] Máquina de estado para fases de abertura e fechamento via `onTransitionEnd`.
  - [ ] Encapsula renderização com `<SectionContent id={sectionId}>`.
  - [ ] Vincula métodos do `handler` fornecido (`open`, `close`).
  - [ ] `<OffcanvasOutlet>` renderiza `SectionOutlet` para cada offcanvas registrado e renderiza o backdrop.
- **Validações e Riscos**: Garantir tipagem limpa sem erros em `bun run build`.

### Tarefa 4: Atualização das Exportações e do `AppLayout`
- **Ação**: Atualizar `src/lib/components/offcanvas/index.ts`, `src/lib/index.ts` e incluir `<OffcanvasOutlet />` em `src/lib/components/layouts/apps/AppLayout.tsx`.
- **Critérios de Aceite**:
  - [ ] `Offcanvas`, `OffcanvasOutlet`, `OffcanvasProvider`, `OffcanvasBackdrop`, `useOffcanvasHandler` exportados publicamente.
  - [ ] `AppLayout` inclui `<OffcanvasOutlet />` ao lado de `<ModalOutlet />`.
- **Validações e Riscos**: Nenhuma regressão de import nos layouts existentes.

### Tarefa 5: Testes Unitários
- **Ação**: Criar `src/lib/components/offcanvas/__tests__/Offcanvas.spec.tsx`.
- **Critérios de Aceite**:
  - [ ] Testa renderização básica com classes de posição `start` e `end`.
  - [ ] Testa abertura e fechamento via `handler`.
  - [ ] Testa chamada de `onOpenClose`.
  - [ ] Executa via `bun run test` com 100% de aprovação.
- **Casos de Teste para Validação**:
  - TC01: Renderiza fechado por padrão.
  - TC02: Abre via handler.open() e aplica classes correspondentes.
  - TC03: Fecha via handler.close() e dispara callback.

### Tarefa 6: Demonstração e Storybook
- **Ação**: Criar página `src/demo/pages/OffcanvasPage.tsx`, registrar rota `/offcanvas` em `src/demo/App.tsx`, adicionar link em `DemoMainLayout.tsx`, e criar história no Storybook.
- **Critérios de Aceite**:
  - [ ] Demonstração interativa de offcanvas à esquerda e à direita.
  - [ ] Botões internos para fechar.
  - [ ] Rota navegável no menu da demo.
- **Casos de Uso para Validação**:
  - UC01: Abrir gaveta lateral esquerda e fechar pelo botão interno.
  - UC02: Abrir gaveta lateral direita e fechar clicando no backdrop.

## 4. Validações Finais
- [ ] `bun run test` verde sem falhas.
- [ ] `bun run build` gerando `dist/` com sucesso.
- [ ] `specs/offcanvas/delivery.md` preenchido.
- [ ] Aceite com o humano.
