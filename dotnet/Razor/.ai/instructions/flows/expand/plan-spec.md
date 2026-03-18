# Instrução Operacional - Planejar uma Spec

> Use este arquivo como base em novos chats para que a IA planeje uma spec em colaboração com o utilizador, por etapas, com gates explícitos de aprovação.

## Fontes Obrigatórias

Antes de iniciar o planeamento, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/roadmap/components-plan-list.md`
- `.ai/guides/expand/cross-cutting-component-decisions.md`
- `.ai/templates/lib/spec/requirements.md`
- `.ai/templates/lib/spec/design.md`
- `.ai/templates/lib/spec/tasks.md`
- `.ai/templates/lib/spec/delivery.md`
- os guides claramente aplicáveis ao tema

Para componentes de formulário ainda pouco definidos:

- combinar `form-components.md` com `form-components-lightweight.md`.

## Gates Obrigatórios

1. escolha do alvo;
2. problema, objetivo e escopo macro;
3. casos de uso, acessibilidade e critérios de aceite;
4. estrutura técnica, composição, dependências e arquitetura;
5. API pública, `Style`, `Size` e contrato visual;
6. pacote existente versus pacote novo e plano de implementação estrutural;
7. plano de execução e fechamento.

## Regras

- Trabalhar em gates.
- Em cada gate, apresentar proposta curta, decisões, pontos em aberto e uma pergunta objetiva.
- Fechar explicitamente os checkpoints transversais do guide `cross-cutting-component-decisions.md`.
- Se um pacote novo for necessário, registrar que a implementação deverá seguir `.ai/instructions/expand/create-library-project.md`.
- Esperar aprovação antes de avançar.
- Usar sempre acentuação.


