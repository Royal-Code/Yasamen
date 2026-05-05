# Kernel

## 1. Regras Globais para a IA

[INSTRUÇÃO] Todas as instruções marcadas com [INSTRUÇÃO] prevalecem sobre heurísticas padrão da IA.

[INSTRUÇÃO] **Prioridade de instruções dentro da skill:** Skill > Kernel > Protocolo operacional > Template.

[INSTRUÇÃO] Executar na ordem definida. Nenhuma etapa pode ser pulada ou reordenada.

[INSTRUÇÃO] No chat, as perguntas e questões devem ser enumeradas para facilitar a resposta do humano.

[INSTRUÇÃO] Toda etapa deve respeitar gates, dependências e transições definidos no protocolo ativo.

[INSTRUÇÃO] Toda ausência relevante de informação deve virar hipótese, GAP ou pendência visível. Toda ambiguidade deve ser questionada ao humano.

[INSTRUÇÃO] Nunca informar ao humano sobre bloqueio de GATE. Responder ao humano segundo ação necessária para satisfazer o GATE. Por exemplo: responder com uma pergunta contextualizada ao assunto que gera o bloqueio e ao assunto tratado no protocolo + template.

[INSTRUÇÃO] Nunca informar ao humano sobre: GATE satisfeito; criação, atualização, persistência ou registro em arquivo de workspace, backlog, state, inventário ou artefato auxiliar. Apenas fazer silenciosamente.

[INSTRUÇÃO] Quando algum protocolo exigir informar algo ao humano, comunicar apenas o conteúdo semântico identificado e seu uso ou destino. Nunca citar arquivo, criação, atualização, persistência ou registro.

## 2. DENSIDADE

[INSTRUÇÃO] As seções dos templates devem satisfazer a densidade do conteúdo. Os templates declaram a densidade como perguntas que devem ser respondidas a partir do conteúdo da seção.

[INSTRUÇÃO] Densidade do conteúdo é a capacidade da descrição responder as perguntas sobre o assunto, sem subjetividade, sem abstração. **Densidade mede qualidade.**

[INSTRUÇÃO] A Densidade é satisfeita quando: 
- (1) a resposta não se aplica genericamente a outros produtos do mesmo domínio;
- (2) contém pelo menos um elemento concreto não-inferível.

[INSTRUÇÃO] Quando uma resposta falha nos dois = Ausente. Falha em apenas um = Parcial.

[INSTRUÇÃO] Para validar se a Densidade foi satisfeita em uma seção, deve ser possível responder todas as perguntas da seção usando os 2 critérios acima, apenas com base no conteúdo registrado, sem inventar nada fora dele, sem subjetividade e sem abstração.

[INSTRUÇÃO] Se faltar informação, a IA não deve esconder isso sob texto genérico. O correto é registrar hipótese, lacuna ou gap explícito.

[INSTRUÇÃO] Seções condicionais marcadas com `{só incluir se existir}` no template devem ser omitidas quando o conteúdo for vazio ou "nenhum". Não preencher seção apenas para declarar ausência.

[INSTRUÇÃO] Quando a IA achar que a **densidade** foi satisfeita para uma seção:
1. apresentar a seção completa ao humano para confirmação;
2. em memória, elaborar uma resposta para cada pergunta de densidade usando **exclusivamente** o conteúdo da seção, sem inventar nada;
3. avaliar cada resposta elaborada contra os dois critérios: 
  - a resposta não se aplica genericamente a outros produtos do mesmo domínio?
  - contém pelo menos um elemento concreto não-inferível?
4. apresentar ao humano, junto com a seção, um **diagnóstico** do que não foi atendido; se tudo foi atendido, informar "densidade satisfeita".

## 3. GAPs

[INSTRUÇÃO] Registrar GAP quando faltar informação, houver contradição, decisão ausente ou hipótese que afete qualidade, validade ou próxima etapa. Não resolver GAP relevante por suposição silenciosa.

[INSTRUÇÃO] Usar este shape para GAP:
```md
### GAP-NNN — {nome curto}
- tipo: {escopo|requisito|regra|dados|contrato|integração|permissão|segurança|arquitetura|implementação|validação|outro}
- descrição: {curta}
- impacto: {alto|médio|baixo}
- escopo afetado: {item|artefato|etapa|fluxo|global}
- afeta próxima etapa: {sim|não}
- consequência se ignorado: {curta}
- hipótese adotada: {não aplicável|descrição}
- exige Questão: {sim|não}
- Questão relacionada: {id|não aplicável}
- status: {aberto|resolvido|aceito com override}
```

[INSTRUÇÃO] Classificar e tratar GAP assim:
- impacto alto: pode alterar escopo, decisão central, contrato, segurança, permissão, dados, arquitetura, fluxo ou resultado final; sempre exige Questão;
- impacto médio: pode alterar parte relevante do artefato ou exigir retrabalho; exige Questão, salvo justificativa explícita de baixo risco para a próxima etapa;
- impacto baixo: afeta detalhe local sem impacto relevante na próxima etapa; pode ficar sem Questão;
- `afeta próxima etapa: sim`: exige Questão;
- `hipótese adotada` diferente de `não aplicável`: exige Questão de validação, salvo detalhe local de impacto baixo;
- GAP aberto e bloqueante impede avanço no escopo afetado;
- GAP só pode ser encerrado com resposta, evidência, decisão registrada ou override explícito válido.

## 4. GATEs

[INSTRUÇÃO] Não avançar GATE a não ser que esteja completamente satisfeito ou com override explícito válido conforme regra de override.

[INSTRUÇÃO] Não avançar etapas sem GATE satisfeito. Parar e responder ao humano de forma apropriada como pede o protocolo.

[INSTRUÇÃO] Avaliar o checklist do GATE com sinceridade e rigor, fazendo:
- em memória, avaliar individualmente cada item do checklist;
- se o indício da completude do item do checklist não for forte, não dar como satisfeito;
- quando se pede apresentação ou avaliação humana, não dar por concluído o item antes de uma resposta humana clara.

## 5. Avanço e Override Humano

[INSTRUÇÃO] Antes de avançar, validar nesta ordem:
1. Gate satisfeito;
2. nenhum GAP bloqueante no escopo;
3. nenhuma Questão bloqueante no escopo;
4. se algum item falhar, parar no menor escopo afetado e responder ao humano com a pergunta ou decisão necessária.

[INSTRUÇÃO] Interpretar pedidos humanos assim:
- pedido inicial para executar, gerar, criar ou produzir artefatos não autoriza atravessar Gate insatisfeito, GAP aberto ou Questão aberta;
- pedido para executar tarefa de etapa futura não autoriza pular etapa anterior, Gate, GAP ou Questão;
- pedido para executar "até o final sem parar" só é válido quando a frase contiver equivalentes de `executar`, `até o final` e `sem parar`;
- execução contínua autoriza seguir sem pausas opcionais somente enquanto Gates estiverem satisfeitos e não houver GAP ou Questão bloqueante;
- execução contínua não é override de bloqueio.

[INSTRUÇÃO] Aceitar override somente quando:
- o humano autorizar explicitamente atravessar o tipo de bloqueio existente: Gate insatisfeito, GAP aberto, Questão aberta, pendência ou bloqueio;
- o bloqueio aceito estiver indicado por escopo, item em contexto ou termo equivalente;
- se o humano não mencionar "todos" ou equivalente, aplicar o override somente ao Gate, GAP, Questão, etapa ou item em contexto.

[INSTRUÇÃO] Registrar override conforme o protocolo ativo determinar. Se o protocolo ativo não definir local de registro, registrar no artefato de controle da execução.

[INSTRUÇÃO] Inferência de impacto baixo e local pode ser adotada sem Questão, desde que registrada explicitamente como hipótese no GAP com `hipótese adotada` preenchido.

## 6. Inventário global

[INSTRUÇÃO] O inventário global tem itens duráveis já consolidados ou promovidos e que precisem ser consultáveis globalmente.

[INSTRUÇÃO] Cada item durável tem seu próprio arquivo `{nome}.index.md` e ficam no diretório `.ai\indexes\`.

[INSTRUÇÃO] No arquivo `.ai\indexes\indexes.md` tem uma tabela com todos os arquivos de indexes, explicando o conteúdo e quando usar. Este arquivo deve ser lido para poder procurar ou pesquisar por artefatos produzidos.

[INSTRUÇÃO] Quando um protocolo criar um arquivo de index para algum item, deve ser atualizado o `.ai\indexes\indexes.md` explicando sobre o arquivo, seguindo o formato:
```md
## {nome da item indexado}

**Arquivo**: {nome do arquivo (*.index.md)}
**Use para**:
- {lista de informações sobre o item para identificar quando usar o index}
```

## 7. Informações Gerais

- `{YY}` significa o ano em dois dígitos.
- `{DoY}` significa o dia do ano.
- `{MoD}` significa minuto do dia.