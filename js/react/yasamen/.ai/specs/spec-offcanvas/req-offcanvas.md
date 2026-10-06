# Requirements — Offcanvas

## Metadados
| Campo | Valor |
|---|---|
| Status | Aprovado |
| Prioridade | P1 |
| UI Pattern | UIP-OVERLAY-DRAWER |
| Roadmap | Roadmap 1 > Componentes Básicos Iniciais |
| Diretório Alvo | `src/lib/components/offcanvas/` |
| Demo Page | `src/demo/pages/OffcanvasPage.tsx` |

## Objetivo
Fornecer um painel lateral retrátil (gaveta / drawer / sidebar) que desliza para dentro da viewport a partir da borda esquerda ou direita, com animação fluida, backdrop opcional e foco acessível, integrando-se ao sistema de seções (`SectionOutlet`) e ao `AppLayout`.

## Escopo
- Componente público `<Offcanvas>`.
- Container `<OffcanvasOutlet>` para projeção em portal/seção.
- Provedor `<OffcanvasProvider>` e hooks `useOffcanvasSystem()` e `useOffcanvasHandler()`.
- Componente auxiliar `<OffcanvasBackdrop>`.
- Suporte a posições: `left` (`start`) e `right` (`end`).
- Suporte a fechamento ao clicar no backdrop (`closeOnBackdropClick`).
- Suporte a fechamento via tecla `Escape`.
- Controle imperativo via `handler` (`open()`, `close()`) e controle declarativo via `isOpen`.
- Estados de animação via máquina de fases (`closed`, `opening_start`, `opening`, `open`, `closing_start`, `closing`).
- Integração no `AppLayout`.
- Página de demonstração em `src/demo/pages/OffcanvasPage.tsx` e rota na aplicação demo.
- Histórias no Storybook.
- Testes unitários com Vitest.

## Fora de Escopo
- Posições `top` e `bottom` (planejadas para iteração futura).
- Arrastar por gesto de swipe touch (planejado para Roadmap 2).

## Casos de Uso
1. **Caso Principal**: Menu lateral de navegação ou painel de configurações que abre pela direita ou esquerda através de clique em botão.
2. **Caso com Backdrop e Fechamento**: Painel modal que escurece a tela e fecha ao clicar no fundo ou teclar ESC.
3. **Caso Aninhado / Conteúdo Rico**: Formulário ou lista de filtros dentro do Offcanvas com botão interno de fechar consumindo `useOffcanvasHandler()`.

## Requisitos Funcionais
- Aceitar `id: string` único para registro e projeção.
- Aceitar `position?: 'left' | 'right'` (padrão `'right'`).
- Aceitar `backdrop?: boolean` (padrão `true`).
- Aceitar `closeOnBackdropClick?: boolean` (padrão `true`).
- Aceitar `closeable?: boolean` (padrão `true`).
- Aceitar `handler?: OffcanvasHandler` com métodos `open()` e `close()`.
- Aceitar `onOpenClose?: (isOpen: boolean) => void`.
- Desencadear transição suave de abertura e fechamento com classes `ya-offcanvas-*`.

## Critérios de Aceite
- [ ] O componente abre e fecha suavemente sem saltos de layout.
- [ ] Suporta posições `left` e `right`.
- [ ] Fecha via tecla ESC e ao clicar no backdrop (quando configurado).
- [ ] Expõe contexto `OffcanvasHandlerContext` permitindo que botões internos fechem o painel.
- [ ] Estilização usa classes `ya-offcanvas*` definidas em `offcanvas.css`.
- [ ] Exportado na raiz de `src/lib/index.ts`.
- [ ] 100% dos testes unitários passando.
- [ ] Página na demo SPA navegável e funcional.
