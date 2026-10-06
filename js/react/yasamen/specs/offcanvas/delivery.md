# Delivery — Offcanvas

## Metadados
| Campo | Valor |
|---|---|
| Status Final | Concluído |
| Data | 2026-10-06 |
| Autor | IA (Antigravity) |
| Spec | `specs/offcanvas/` |

## Resumo da Entrega
Implementação completa da arquitetura do componente `<Offcanvas>` (drawer lateral retrátil), espelhando o padrão de transição e gerenciamento por máquina de estados do Modal e a paridade com o Blazor `RoyalCode.Razor.OffCanvas`.

A entrega engloba:
- Componente `<Offcanvas>` com suporte a posições `left` e `right`, backdrop opcional, fechamento ao clicar no backdrop e via tecla ESC.
- Contextos `OffcanvasContext` e `OffcanvasHandlerContext` para acionamento e fechamento direto de botões filhos via `useOffcanvasHandler()`.
- Provedor `<OffcanvasProvider>` e container `<OffcanvasOutlet>` para projeção em portal/seção.
- Integração no `<AppLayout>`.
- Folha de estilo completa `offcanvas.css` com classes `ya-offcanvas*`.
- 100% dos testes unitários em Vitest (`Offcanvas.spec.tsx`).
- Página de teste interativa `/offcanvas` na demo SPA e história no Storybook.

## Changelog
### Added
- `<Offcanvas>` em `src/lib/components/offcanvas/Offcanvas.tsx`
- `<OffcanvasOutlet>` em `src/lib/components/offcanvas/OffcanvasOutlet.tsx`
- `<OffcanvasProvider>` em `src/lib/components/offcanvas/OffcanvasProvider.tsx`
- `<OffcanvasBackdrop>` em `src/lib/components/offcanvas/OffcanvasBackdrop.tsx`
- Contexto e hooks em `src/lib/components/offcanvas/offcanvas-context.ts`
- Mapeamento de classes em `src/lib/components/offcanvas/offcanvas-classes.ts`
- Exportações públicas em `src/lib/components/offcanvas/index.ts` e `src/lib/index.ts`
- Inclusão de `<OffcanvasOutlet />` em `src/lib/components/layouts/apps/AppLayout.tsx`
- Estilos de animação e posicionamento em `src/lib/styles/css/components/offcanvas.css`
- Suíte de testes unitários `src/lib/components/offcanvas/__tests__/Offcanvas.spec.tsx`
- Página na demo SPA `src/demo/pages/OffcanvasPage.tsx` e rota `/offcanvas`
- Histórias no Storybook `src/stories/components/Offcanvas.stories.tsx`
- Especificação completa Dual Track em `specs/offcanvas/` (`requirements.md`, `design.md`, `tasks.md`, `delivery.md`)

## Rastreabilidade
| Origem | Item | Evidência no Código | Status |
|---|---|---|---|
| Requirement | Suporte a posições `left` e `right` | `Offcanvas.tsx:162-163` | OK |
| Requirement | Fechamento por backdrop e ESC | `OffcanvasOutlet.tsx:210-219`, `OffcanvasBackdrop.tsx:84-88` | OK |
| Design | Transição por máquina de fases | `Offcanvas.tsx:32-60` | OK |
| Tasks | Testes unitários com Vitest | `Offcanvas.spec.tsx:1-96` | OK |

## Validação Executada
| Tipo | Comando / Rota | Resultado |
|---|---|---|
| **Testes Unitários** | `bun run test` | OK (7 arquivos, 30 testes passando) |
| **Build da Lib** | `bun run build` | OK (dist/ gerado com ESM, CJS, dts, css) |
| **Build da Demo** | `bun run build:demo` | OK (SPA compilado com sucesso) |
| **Sensibilidade de Caixa** | Scan script powershell | OK (0 discrepâncias de case) |

## Fechamento de Tasks
- [x] Todas as tarefas de `tasks.md` concluídas.
- [x] Código com zero avisos ou erros de tipagem.
- [x] Testes unitários e build 100% verdes.
