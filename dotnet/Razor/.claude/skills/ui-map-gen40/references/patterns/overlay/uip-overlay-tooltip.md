# UIP-OVERLAY-TOOLTIP - Tooltip

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Ajuda contextual curta acionada por foco, hover ou gesto equivalente.

**Objetivo estrutural**: Explicar brevemente um controle, rótulo, ícone, estado ou dado sem alterar a estrutura da tela.

**Não confundir com**: UIP-OVERLAY-POPOVER (superfície contextual interativa), UIP-FEEDBACK-TOAST_ALERT (feedback por evento), help permanente (fora do catálogo), validação de formulário (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando um elemento precisa de explicação curta; quando um ícone ou estado não é autoexplicativo; quando a informação é auxiliar e não essencial para concluir a tarefa.

**Quando evitar**: quando o texto é essencial para a decisão; quando a plataforma não oferece hover ou foco equivalente; quando a ajuda precisa conter interação, links ou conteúdo longo; quando o tooltip seria usado para esconder rótulos necessários.

**Alternativas próximas**: UIP-OVERLAY-POPOVER (superfície contextual interativa), UIP-FEEDBACK-TOAST_ALERT (feedback por evento).

**Sinais de escolha**:
- conteúdo curto
- originador claro
- não há ação dentro do conteúdo
- a informação pode aparecer sob demanda
- o elemento continua compreensível sem depender do tooltip

**Grau de Rigidez**: Alto — ajuda contextual curta acionada por hover ou foco é invariante; posição e conteúdo variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: tooltip simples; tooltip de truncamento; tooltip de status; tooltip de atalho; help hint.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não usar para conteúdo essencial, erro de validação, confirmação, decisão ou ajuda longa.

## Estrutura e Transição

**Estrutura Desktop**: texto curto ancorado ao elemento em hover ou foco, com posicionamento ajustado ao viewport e dismiss automático.

**Estrutura Mobile**: usar apenas quando houver gesto equivalente claro; caso contrário, transformar em texto inline, help icon com popover ou sheet, ou label explícito.

**Regra de Transição**: preservar a ajuda contextual sem tornar informação essencial inacessível. Em touch, não depender de hover.

## Estados

**Estados próprios**: oculto, aguardando delay, visível, reposicionado, fechado por blur ou dismiss.

**Reação a estados da página**: não compete com modal, popover ou menu ativo. `loading` → tooltips de controles indisponíveis podem ser desativados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: garantir acionamento por foco além de hover e não esconder informação essencial.

**Adaptação Mobile nativo**: preferir texto inline, help icon ou popover/sheet para conteúdo necessário; long press só quando for padrão claro.

**Adaptação Desktop nativo**: pode mostrar atalhos e descrições curtas de ferramentas, respeitando delay e foco.
