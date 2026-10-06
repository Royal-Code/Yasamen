# Protocolo: Discovery da spec

## Regras

Regras que a IA deve seguir estritamente:
- Não escrever código neste protocolo.
- Não inferir requisito. Perguntar ao humano quando faltar informação (`kernel.rules.md`, seção `Decisão humana`).
- Escrever `req`, `ds` e `dec` somente com o conteúdo confirmado ou derivado de fonte verificada.
- Criar a spec com status `Draft`.

## Arquivos a ler

- `.ai/roadmap/roadmap.md`: localizar o item, a prioridade e a paridade com o Razor.
- `.ai/rules/architecture.md`, `component-anatomy.md`, `component-profiles.md`, `css-contract.md`, `tokens.md`: aplicar ao design.
- `.ai/instructions/protocols/spec-characterization.md`: protocolo de caracterização e escopo.
- `.ai/specs/specs.index.md`: conferir se já existe spec do componente.
- Componente equivalente em `dotnet/Razor`: derivar paridade, quando existir.
- `.ai/instructions/templates/req.md`, `ds.md`, `dec.md`: seguir o shape.

## 1. Enquadrar

1. Definir `{slug}` em kebab-case a partir do nome do componente.
2. Confirmar o slug com o humano.
3. Criar `.ai/specs/spec-{slug}/`.
4. Criar `dec-{slug}.md` com `Próximos IDs` iniciais.
5. Adicionar a linha em `specs.index.md` com status `Draft`.

### GATE SD.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu o slug da spec;
- a pasta e `dec-{slug}.md` existem;
- a linha existe em `specs.index.md`.

## 2. Levantar requisitos

Somente após gate `SD.1` satisfeito.

1. Executar `protocols/spec-characterization.md` para classificar o perfil, mapear características e confirmar inclusões/exclusões com o humano.
2. Executar `protocols/spec-refinement.md` para as questões pontuais de produto: resultado, fluxo e critérios de aceite.
3. Escrever `req-{slug}.md` conforme `templates/req.md`, registrando a matriz em `Características` e os fluxos em `Casos de uso` (`UC<n>`).
4. Rascunhar os casos de teste (`TC<n>`) e itens de documentação derivados de cada `UC<n>`.

### GATE SD.2

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- `req-{slug}.md` existe com as seções `Características` e `Casos de uso` (`UC<n>`);
- humano respondeu a entrevista de características e questões de aceite;
- todo `CA<n>` usa `Dado / Quando / Então`.

## 3. Projetar

Somente após gate `SD.2` satisfeito.

1. Derivar arquitetura, API, classes e tokens de `.ai/rules/` e do Razor.
2. Executar `protocols/spec-refinement.md` para as decisões materiais de design: props, temas, tamanhos, slots, compatibilidade.
3. Escrever `ds-{slug}.md` conforme `templates/ds.md`.
4. Executar `protocols/api-compatibility.md` quando `Compatibilidade` indicar alteração de API existente.

### GATE SD.3

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- `ds-{slug}.md` existe com todas as seções do shape;
- humano respondeu toda decisão material de design;
- todo risco tem mitigação.

## 4. Encaminhar

Somente após gate `SD.3` satisfeito.

1. Apresentar ao humano: resumo da API pública, temas e tamanhos, questões abertas, riscos.
2. Executar `protocols/review-spec.md` quando o humano pedir revisão da spec.
3. Perguntar ao humano se aprova `req` e `ds`.
4. Alterar o status para `Approved` em `req-{slug}.md` e em `specs.index.md` somente com aprovação explícita.
5. Encaminhar para `protocols/spec-tasks.md`.

### GATE SD.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu aprovação explícita da spec;
- nenhuma `Q<n>` bloqueadora aberta em `dec-{slug}.md`;
- status `Approved` sincronizado em `req-{slug}.md` e `specs.index.md`.
