# Protocolo: Refinamento com o humano

## Regras

Regras que a IA deve seguir estritamente:
- Fazer pergunta somente quando a resposta alterar escopo, API, acessibilidade, paridade, custo ou critério de aceite.
- Perguntar decisão, não detalhe de implementação que não altere esses itens.
- Escrever pergunta concreta e decisiva. Escrever "Aceitar `closeOnBackdropClick` por padrão?" e não "Como deve ser o fechamento?".
- Apresentar duas ou mais opções com consequência concreta quando houver escolha real.
- Indicar a opção recomendada e o motivo. Declarar que ela não foi assumida.
- Agrupar perguntas por tema. Fazer de três a cinco por rodada.
- Não criar `DC<n>` sem resposta do humano.
- Registrar cada `Q<n>` em `dec-{slug}.md` conforme `templates/dec.md`.

## Arquivos a ler

- `dec-{slug}.md`: obter questões abertas e próximo ID.
- `req-{slug}.md` e `ds-{slug}.md`: obter o contexto da questão.
- `.ai/rules/`: derivar o que já está decidido. Não perguntar o que as regras já definem.

## 1. Preparar a rodada

1. Listar fatos confirmados com o arquivo que os registra.
2. Listar incertezas que alteram escopo, API, acessibilidade, custo ou critério de aceite.
3. Criar `Q<n>` para cada incerteza, com opções `A`, `B`, `C`, consequência e recomendação.
4. Selecionar de três a cinco questões do mesmo tema.

## 2. Perguntar

Apresentar ao humano, nesta ordem:
1. O que se sabe: fatos confirmados e arquivos.
2. O que está incerto.
3. Opções e consequências de cada questão.
4. Recomendação.
5. Decisão necessária: perguntas curtas.
6. Próxima ação após as respostas.

### GATE SR.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- as questões da rodada foram apresentadas na conversa;
- humano respondeu cada questão da rodada.

## 3. Registrar

Somente após gate `SR.1` satisfeito.

1. Marcar `[x]` a `Q<n>` respondida e preencher `Resposta`.
2. Criar `DC<n>` com a `Q<n>` de origem.
3. Tratar resposta parcial: manter a `Q<n>` aberta, registrar a premissa como pendente e limitar o artefato ao confirmado.
4. Tratar "não sei": manter a `Q<n>` aberta, propor a opção recomendada com consequência e perguntar de novo.
5. Atualizar `req`, `ds`, `tasks` ou `test` afetados e remover o que a decisão invalidou.
6. Atualizar `Próximos IDs` em `dec-{slug}.md`.

### GATE SR.2

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- toda `Q<n>` respondida tem `DC<n>`;
- nenhum artefato contradiz uma `DC<n>`;
- `Próximos IDs` confere.

## 4. Encerrar

Repetir as etapas 1 a 3 enquanto houver `Q<n>` bloqueadora aberta. Retornar ao protocolo chamador quando nenhuma `Q<n>` bloqueadora estiver aberta.
