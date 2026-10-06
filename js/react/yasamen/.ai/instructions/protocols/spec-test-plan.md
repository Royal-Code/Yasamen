# Protocolo: Plano de testes

## Regras

Regras que a IA deve seguir estritamente:
- Seguir `.ai/rules/testing.md`.
- Cobrir todo `CA<n>` com ao menos um `TC<n>`.
- Declarar camada, falha que pega e prova de falha de cada `TC<n>`.
- Não planejar `TC<n>` de efeito visual somente em L1.
- Perguntar ao humano quando L2 for necessário e não estiver configurado. Registrar `Q<n>`.

## Arquivos a ler

- `req-{slug}.md`: obter `CA<n>`, acessibilidade e casos de uso.
- `ds-{slug}.md`: obter props, temas, tamanhos, classes e riscos.
- `.ai/rules/testing.md`: aplicar armadilhas e camadas.
- `templates/test.md`: seguir o shape.

## 1. Derivar casos

1. Obter os `UC<n>` e `CA<n>` de `req-{slug}.md`.
2. Finalizar os `TC<n>` rascunhados na discovery: orientar a cobertura com múltiplos testes (caminho feliz, caminhos infelizes e casos de borda).
3. Mapear cada `TC<n>` de efeito visual ou interação de layout para uma história no Storybook (camada L2 via Playwright).
4. Criar `TC<n>` de contrato: componente exportado em `src/lib/index.ts`; toda classe de `<nome>-classes.ts` existe em `<nome>.css`.
5. Declarar tipo, camada, falha que pega e `Prova de falha: *a fazer*` em cada `TC<n>`.
6. Criar `V<n>` de verificação manual para o efeito visual quando L2 não estiver disponível no ambiente.

### GATE TP.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo `CA<n>` e `UC<n>` possuem casos de teste `TC<n>`;
- todo `TC<n>` declara tipo, camada e falha que pega;
- nenhum efeito visual está só em L1 sem teste L2 ou `V<n>`.

## 2. Registrar

Somente após gate `TP.1` satisfeito.

1. Escrever `test-{slug}.md` conforme `templates/test.md`.
2. Atualizar `Próximos IDs` em `dec-{slug}.md`.
3. Apresentar ao humano: estratégia por camada e verificações manuais.
