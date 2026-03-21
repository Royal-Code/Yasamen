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
- Se houver informação suficiente, ele deve abrir ou refinar a `screen spec`, não apenas explicar o fluxo.
- Se faltar informação, ele deve pedir uma lista enumerada única do que falta para continuar.
- Depois de criar ou refinar a spec, ele deve acionar `spec-review` quando essa capacidade estiver disponível.
- Ele deve terminar a resposta com o próximo passo recomendado no fluxo, por exemplo `refine screen-spec`, `yasamen` ou `lib-spec`.

