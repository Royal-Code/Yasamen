# Roadmap — Yasamen React

Auditado em 2026-10-06 contra `src/lib/components/` e `src/lib/index.ts`.

Legenda:
- `[x]` existe, com caminho.
- `[~]` parcial, com o que falta.
- `[ ]` ausente.
- `Razor:` situação do equivalente em `dotnet/Razor` (`[x]`, `[~]`, `[ ]`).
- `P1`, `P2`, `P3`: prioridade confirmada. Item sem prioridade não foi priorizado.
- `Spec:` pasta em `.ai/specs/` ou `.ai/archive/specs/`.

Regras que a IA deve seguir estritamente:
- Iniciar componente novo pelo protocolo `spec-discovery.md`.
- Marcar `[x]` somente com o caminho do código verificado e a spec `Completed`.
- Propor o próximo componente a partir dos itens `P1`. Perguntar ao humano antes de iniciar.
- Atualizar este arquivo ao concluir uma spec (`protocols/delivery.md`).
- Mover itens concluídos antigos conforme `protocols/archive.md`.

## Roadmap 1 — Componentes básicos iniciais

- [x] Ripple — `src/lib/components/commons/Ripple.tsx` — Razor: [x]
- [x] Button — `src/lib/components/button/Button.tsx` — Razor: [x]
- [x] IconButton — `src/lib/components/button/IconButton.tsx` — Razor: [x]
- [x] Icon — `src/lib/components/icon/icon.tsx` — Razor: [x]
- [x] Bootstrap Icons — `src/lib/components/bsicons/` — Razor: [x]
- [x] Bar — `src/lib/components/layouts/Bar.tsx` — Razor: [x]
- [x] Stack — `src/lib/components/layouts/Stack.tsx` — Razor: [x]
- [x] Container — `src/lib/components/layouts/Container.tsx` — Razor: [x]
- [x] Cols (equivale a `Slot` do Razor) — `src/lib/components/layouts/Cols.tsx` — Razor: [x]
- [x] AppLayout — `src/lib/components/layouts/apps/AppLayout.tsx` — Razor: [x]
- [x] SectionOutlet e SectionContent — `src/lib/components/outlet/` — Razor: [x]
- [x] Modal (Dialog) — `src/lib/components/modal/Modal.tsx` — Razor: [x]
- [x] Offcanvas — `src/lib/components/offcanvas/Offcanvas.tsx` — Razor: [x] — Spec: spec-offcanvas
- [x] Status e Status404 — `src/lib/components/status/` — Razor: sem equivalente
- [ ] ButtonGroup — Razor: [x]
- [ ] Badge — P1 — Razor: [x]
- [ ] Alert (Feedback) — Razor: [x]
- [ ] Notification (Toast) — P1 — Razor: [x]
- [ ] Dropdown (DropButton, DropIconButton, DropItem) — P2 — Razor: [x]
- [ ] Breadcrumb — P2 — Razor: [x]
- [ ] Pagination — Razor: [x]
- [ ] Spinner (Loader) — Razor: [x]
- [ ] Animations (RotateEffect, RotationMotion) — Razor: [x]
- [ ] Box (container com borda, padding e margin) — Razor: [x]
- [ ] AppMainLayout, AppTopBar, AppSideBar, AppSideItem, AppSideMenuButton, AppMenu, AppMenuList, AppMenuItem — Razor: [x]

## Roadmap 1 — Formulários

- [ ] FormControl (FieldGroup, ControlGroup) — P3 — Razor: [x]
- [ ] TextField — P3 — Razor: [x]
- [ ] FieldAction, FieldBadge, FieldText — P3 — Razor: [x]
- [ ] TextArea — Razor: [ ]
- [ ] Select — Razor: [ ]
- [ ] CheckBox — Razor: [ ]
- [ ] RadioBox e RadioGroup — Razor: [ ]
- [ ] Switch (toggle) — Razor: [ ]
- [ ] NumberField — Razor: [ ]
- [ ] DatePicker (data, hora, data e hora) — Razor: [ ]
- [ ] FileInput (Uploader) — Razor: [ ]
- [ ] ColorPicker — Razor: [ ]
- [ ] Range (slider) — Razor: [ ]
- [ ] AutoComplete — Razor: [ ]
- [ ] Campo Compact (label sobre a borda do input ou grupo) — Razor: [ ]
- [ ] Campo `size: Sizes` nos inputs — Razor: [x]

## Roadmap 1 — Peculiares

- [ ] ValueBadge — Razor: [ ]
- [ ] BadgeListField — Razor: [ ]
- [ ] CascaderSelect — Razor: [ ]
- [ ] CheckBoxSelect — Razor: [ ]
- [ ] CheckBoxTreeSelect — Razor: [ ]
- [ ] TimeSpanPicker — Razor: [ ]
- [ ] Rate — Razor: [ ]
- [ ] TreeSelect — Razor: [ ]
- [ ] SignatureInput — Razor: [ ]
- [ ] DashboardLayout — Razor: [ ]

## Roadmap 1 — Diversos

- [ ] Accordion — Razor: [ ]
- [ ] Affix — Razor: [ ]
- [ ] Card — Razor: [~] (`Box` serve como card)
- [ ] Carousel — Razor: [ ]
- [ ] CheckTree — Razor: [ ]
- [ ] Collapse — Razor: [ ]
- [ ] ListGroup — Razor: [ ]
- [ ] Tabs — Razor: [ ]
- [ ] Tree — Razor: [ ]
- [ ] Panel — Razor: [~]
- [ ] Placeholders e Skeleton — Razor: [ ]
- [ ] Popover — Razor: [ ]
- [ ] ProgressBar — Razor: [ ]
- [ ] Scrollspy — Razor: [ ]
- [ ] Steps e Stepper — Razor: [ ]
- [ ] Timeline — Razor: [ ]
- [ ] Tooltip — Razor: [ ]

## Roadmap 1 — Complexos

- [ ] Agenda (Calendar) — Razor: [ ]
- [ ] DataGrid — Razor: [ ]
- [ ] QueryBuilder — Razor: [ ]
- [ ] TreeGrid — Razor: [ ]
- [ ] Charts — Razor: [ ]
- [ ] BarCode — Razor: [ ]
- [ ] QRCode — Razor: [ ]
- [ ] Kanban — Razor: [ ]
- [ ] Maps — Razor: [ ]
- [ ] StockChart — Razor: [ ]
- [ ] GanttChart — Razor: [ ]

## Roadmap 2

- [ ] Drag and Drop (áreas e itens movíveis entre áreas) — Razor: [ ]
- [ ] VideoPlayer — Razor: [ ]
- [ ] Camera — Razor: [ ]
- [ ] Speech — Razor: [ ]
- [ ] Split (painel com divisor) — Razor: [~]
- [ ] GoTop — Razor: [ ]
- [ ] RibbonTab — Razor: [ ]
- [ ] IpAddressField — Razor: [ ]
- [ ] Captcha — Razor: [ ]
- [ ] ProgressCircle — Razor: [ ]
- [ ] Geolocation — Razor: [ ]
- [ ] SearchField — Razor: [ ]
- [ ] Dispatch — Razor: [ ]
- [ ] PopConfirm — Razor: [ ]
- [ ] Transfer — Razor: [ ]
- [ ] Empty — Razor: [ ]
- [ ] Result — Razor: [ ]

## Roadmap 3

- [ ] Avatar e AvatarGroup — Razor: [ ]
- [ ] Board e BoardRow — Razor: [ ]
- [ ] ConfirmDialog — Razor: [~]
- [ ] ResultDialog — Razor: [ ]
- [ ] ContextMenu — Razor: [ ]
- [ ] Details — Razor: [ ]
- [ ] MessageList — Razor: [ ]
- [ ] Scroller — Razor: [ ]
- [ ] LoadPanel — Razor: [ ]
- [ ] UserProfile — Razor: [ ]
- [ ] Gauge — Razor: [ ]
- [ ] Windows (dialog móvel, maximizável e redimensionável) — Razor: [ ]

## Pendências de qualidade existentes

- [ ] Infraestrutura de testes de stories no browser (`test:stories`) com Playwright e checagem automática de acessibilidade (`@storybook/addon-a11y`).
- [ ] Cobertura de casos de uso (`UC`) e stories com `play` functions para componentes legados (Ripple, Button, Modal, Bar, Stack, etc.).
- [ ] `src/lib/styles/css/components/status.css` não está importado em `yasamen.css`.
- [ ] Testes ausentes: Modal, Stack, Container, Cols, AppLayout, Status, SectionOutlet, Icon.
- [ ] Páginas de demo ausentes para: Status.
- [ ] Histórias do Storybook ausentes para: Modal, Status, SectionOutlet, AppLayout.
- [ ] Specs ausentes para os componentes existentes, exceto Offcanvas.

## Mapa de componentes existentes

| Domínio | Componentes | Caminho |
|---|---|---|
| `commons` | `Ripple`, `getNavigator`, `Themes`, `Sizes`, `Positions`, spacing | `src/lib/components/commons/` |
| `button` | `Button`, `IconButton` | `src/lib/components/button/` |
| `icon` | `Icon`, factory, registry, `WellKnownIcons` | `src/lib/components/icon/` |
| `bsicons` | Provedor Bootstrap Icons | `src/lib/components/bsicons/` |
| `layouts` | `Bar`, `Stack`, `Container`, `Cols` | `src/lib/components/layouts/` |
| `layouts/apps` | `AppLayout` | `src/lib/components/layouts/apps/` |
| `modal` | `Modal`, `ModalOutlet`, `ModalProvider`, `ModalBackdrop` | `src/lib/components/modal/` |
| `offcanvas` | `Offcanvas`, `OffcanvasOutlet`, `OffcanvasProvider`, `OffcanvasBackdrop` | `src/lib/components/offcanvas/` |
| `outlet` | `SectionProvider`, `SectionContent`, `SectionOutlet` | `src/lib/components/outlet/` |
| `status` | `Status`, `Status404` | `src/lib/components/status/` |
