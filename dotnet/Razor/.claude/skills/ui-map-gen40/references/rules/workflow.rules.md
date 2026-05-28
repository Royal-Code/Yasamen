# Regras gerais para o workflow

[INSTRUÇÃO] Os arquivos gerados são destinados para uso da IA em skills consumidoras (screen-designer, ui-coder, outras). Devem ser escritos para entendimento, instrução e uso da IA — não para leitura humana explicativa.

[INSTRUÇÃO] Ao concluir/finalizar uma etapa, faça:
- apresentar resumo ao humano, pedir avaliação;
- perguntar ao humano se deseja executar análise de qualidade dos artefatos da etapa;
- falar sobre a próxima etapa, perguntar se pode prosseguir;
- atender pedidos de alteração antes de seguir.

[INSTRUÇÃO] A pausa entre etapas só é dispensada quando houver pedido explícito do humano para executar até o final sem parar, conforme regra de override do `kernel.rules.md`.

[INSTRUÇÃO] Só dar uma etapa como concluída se GATE e checklist estiverem satisfeitos. Quando não satisfeitos: informar problemas, elaborar perguntas ao humano e só prosseguir com permissão explícita.

[INSTRUÇÃO] Registrar em `state.yaml` apenas estado mecânico (etapa atual, stages, próxima ação, blockers, open_gaps). Não duplicar no state informações que podem ser inferidas do filesystem.

[INSTRUÇÃO] Não se basear em análises de outras bibliotecas. Não ler arquivos de mapeamento de outras libs em `.ai/ui-map/`.

[INSTRUÇÃO] Resolver diretório de trabalho.
- se o humano informar diretório explícito, usar;
- caso contrário, usar convenção `.ai/ui-map/{slug}/` onde `slug` = nome da biblioteca em dash-case;
- criar diretório se não existir, quando o protocolo pedir;

[INSTRUÇÃO] Criar artefatos no diretório de trabalho conforme regra a seguir:
- artefatos do diretório de trabalho:
  - `state.yaml`
  - `components.summary.md`
  - `structure.md`
  - `ui-guide.md`
  - `visual.language.md`
  - `visual.map.md`
  - `patterns.orientations.md`
  - `manifest.md`
- diretórios de artefatos específicos (dentro do diretório de trabalho)
  - `ui-map/` — mapeamentos entre patterns e componentes, `patterns.table.md`
  - `samples/` — exemplos de componentes
  - `patterns-blueprints/` — blueprints de patterns com baixa adaptação a biblioteca, `blueprints.table.md`
  - `rules/` — regras corporativas
  - `analysis/` — análises e revisões
  - `releases/` — releases de versões do ui-map

[INSTRUÇÃO] Regra para `state.yaml`:
- crie ou atualize conforme o protocolo pedir;
- leia `state.template.yaml` para entender a estrutura do documento `state.yaml`;
- crie o arquivo quando identificado o diretório de trabalho e ele não existir;
- ao criar preencha o `directory`, `library` e suas propriedades, `auxiliary_libraries`;
- conforme o fluxo, crie uma `task` em `tasks` com `type` conforme o fluxo;
- atualize as propriedades da `task` conforme avanço em etapas, seções e passos, ou conforme o protocolo pedir.

[INSTRUÇÃO] Ao final de uma etapa, protocolo, ou ao final de uma seção, **sempre atualize** o estado atual da `task` no `state.yaml`.
