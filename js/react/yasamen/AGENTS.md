# AGENTS.md — Yasamen React

## Início de sessão

1. Ler `.ai/instructions/kernel.rules.md`.
2. Ler `.ai/instructions/triage.md`.
3. Identificar o pedido do humano e ler o protocolo indicado na triagem.
4. Ler os templates e os arquivos de `.ai/rules/` que o protocolo indicar.
5. Executar somente o protocolo do pedido.

Regras que a IA deve seguir estritamente:
- Não escrever código antes de ler `.ai/rules/`.
- Não iniciar implementação de componente sem spec com status `Approved`.
- Não decidir sem referência ou confirmação humana.
- Escrever em português com acentuação correta.

## Mapa

| Caminho | Conteúdo |
|---|---|
| `.ai/README.md` | Índice do pacote |
| `.ai/instructions/` | Kernel, triagem, protocolos, templates |
| `.ai/rules/` | Regras técnicas do código |
| `.ai/roadmap/roadmap.md` | Componentes existentes e pendentes |
| `.ai/specs/` | Specs ativas e `specs.index.md` |
| `.ai/archive/` | Specs e itens de roadmap arquivados |
