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

1. Listar os `CA<n>`.
2. Criar `TC<n>` por `CA<n>`: caminho feliz, cada prop pública, cada tema e tamanho usados, estados desabilitado, vazio e erro, evento, teclado e foco.
3. Criar `TC<n>` de borda: primeiro e último `Sizes`, lista vazia, lista com um item.
4. Criar `TC<n>` de contrato: componente exportado em `src/lib/index.ts`; toda classe de `<nome>-classes.ts` existe em `<nome>.css`.
5. Declarar camada, falha que pega e `Prova de falha: *a fazer*` em cada `TC<n>`.
6. Criar `V<n>` de verificação manual para o efeito visual que L1 não prova.

### GATE TP.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo `CA<n>` tem `TC<n>`;
- todo `TC<n>` declara camada e falha que pega;
- nenhum efeito visual está só em L1 sem `V<n>`.

## 2. Registrar

Somente após gate `TP.1` satisfeito.

1. Escrever `test-{slug}.md` conforme `templates/test.md`.
2. Atualizar `Próximos IDs` em `dec-{slug}.md`.
3. Apresentar ao humano: estratégia por camada e verificações manuais.
