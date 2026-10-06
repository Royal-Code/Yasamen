# Design — Offcanvas

## Arquitetura de Componentes
- **Componente Principal**: `<Offcanvas>`
- **Outlet de Renderização**: `<OffcanvasOutlet>`
- **Provedor de Sistema**: `<OffcanvasProvider>`
- **Contextos**:
  - `OffcanvasContext`: Gerencia registro, fila de ações e lista de itens abertos.
  - `OffcanvasHandlerContext`: Disponibiliza `{ open, close }` para os filhos do Offcanvas.
- **Backdrop**: `<OffcanvasBackdrop>`

## Contrato da API Pública (TypeScript)
```typescript
export interface OffcanvasProps extends React.HTMLAttributes<HTMLElement> {
    id: string;
    position?: 'left' | 'right';
    backdrop?: boolean;
    closeOnBackdropClick?: boolean;
    closeable?: boolean;
    children: React.ReactNode;
    onOpenClose?: (isOpen: boolean) => void;
    handler?: OffcanvasHandler;
    className?: string;
}

export interface OffcanvasHandler {
    open: () => void;
    close: () => void;
}
```

## Variações e Posicionamento
- **Posições suportadas**:
  - `'left'`: desliza da borda esquerda (`ya-offcanvas-start`).
  - `'right'`: desliza da borda direita (`ya-offcanvas-end`, padrão).
- **Backdrop**:
  - Suportado e ativo por padrão (`backdrop = true`).
  - Classe `ya-offcanvas-backdrop`.

## Contrato Visual e Classes CSS (`ya-*`)
- Folha de estilo: `src/lib/styles/css/components/offcanvas.css`
- Mapeamento: `src/lib/components/offcanvas/offcanvas-classes.ts`
- Classes públicas:
  - Base: `ya-offcanvas`
  - Posicionamento: `ya-offcanvas-start`, `ya-offcanvas-end`
  - Transições: `ya-offcanvas-opening-start`, `ya-offcanvas-opening`, `ya-offcanvas-open`, `ya-offcanvas-closing-start`, `ya-offcanvas-closing`, `ya-offcanvas-closed`
  - Outlet: `ya-offcanvas-outlet`, `ya-offcanvas-outlet-open`
  - Backdrop: `ya-offcanvas-backdrop`, `ya-offcanvas-backdrop-show`, `ya-offcanvas-backdrop-opening-start`, etc.

## Tokens Tailwind Utilizados
- Larguras e Alturas: `--ya-fit-top`, `--ya-fit-bottom`, `--ya-fit-left`, `--ya-fit-right`
- Z-Index: `@utility z-offcanvas` (1030), `@utility z-offcanvas-backdrop` (1020)
- Transições: `transition-all duration-150` ou `transition-default`

## Riscos e Questões em Aberto
- **Risco**: Interação de scroll quando o offcanvas está aberto. Mitigação: `overflow-hidden` temporário ou backdrop cobrindo viewport.
- **Risco**: Ausência de `OffcanvasProvider` em uso avulso. Mitigação: Fallback elegante se renderizado sem provider ou obrigatoriedade transparente via `AppLayout`.
