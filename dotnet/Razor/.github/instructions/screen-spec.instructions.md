---
applyTo: ".ai/screen-spec.md"
---

# Instruções para o orquestrador de screen specs

- Este arquivo é a entrada de domínio para tela e página.
- Ele deve preservar a cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP`.
- Quando a tela já existir, deve exigir o quadro `As-Is` antes do `To-Be`.
- Ele deve usar `catalogo-ui.md` como base agnóstica e `ui-map.md` como adapter tecnológico.
- Ele deve fechar os checkpoints de `.ai/guides/rules/cross-cutting-screen-decisions.md`.
- Ele deve tratar backlog ou roadmap local como entrada opcional; neste repositório, os arquivos padrão são `.ai/roadmap/components-plan-list.md` e `.ai/roadmap/ui-plan.md`.

