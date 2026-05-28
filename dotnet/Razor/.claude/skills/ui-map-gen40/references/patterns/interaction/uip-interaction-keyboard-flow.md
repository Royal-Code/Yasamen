# UIP-INTERACTION-KEYBOARD_FLOW - Keyboard Flow

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Navegação e operação completa da interface via teclado, com gestão de foco, atalhos e indicadores de foco.

**Objetivo estrutural**: Permitir operação produtiva sem pointer por tab navigation, gestão de foco, landmarks, atalhos e comandos descobríveis.

**Não confundir com**: UIP-ACTION-COMMAND_PALETTE (busca e execução de comandos), acessibilidade genérica (fora do catálogo), navegação por controle remoto (fora do catálogo).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o público usa teclado com frequência; quando a produtividade depende de atalhos e foco previsível; quando o app é usado por longos períodos; quando operação sem mouse é requisito funcional ou regulatório.

**Quando evitar**: não deve ser evitado em interfaces operacionais; pode ser reduzido quando a plataforma não tem teclado. O escopo precisa ser compatível com a complexidade real do app.

**Alternativas próximas**: UIP-ACTION-COMMAND_PALETTE (busca e execução de comandos por teclado).

**Sinais de escolha**:
- IDE, editor, terminal, planilha, admin denso ou dashboard operacional
- sessões longas e operações repetitivas
- múltiplos atalhos esperados

**Grau de Rigidez**: Alto — navegação completa por teclado com indicadores de foco é invariante; atalhos e ordem variam.

## Composição

**Zonas usuais**: Navegação, Conteúdo, Ações.

**Variantes reconhecidas**: tab flow; roving focus; access keys; atalhos de teclado; shortcut overlay; focus trap; navegação por landmarks.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH, SHP-DASHBOARD_ANALYTICS.

**Compatibilidade Secundária**: SHP-COMMUNICATION, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE.

**Incompatibilidades explícitas**: nenhuma ampla; plataformas sem teclado físico apenas reduzem o escopo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-FORM, PP-DASHBOARD, PP-CANVAS, PP-SETTINGS.

**Compatibilidade Secundária**: Todos os Page Patterns quando há teclado ou navegação por foco.

**Incompatibilidades explícitas**: não substitui command palette nem resolve sozinho gestos especializados de canvas.

## Estrutura e Transição

**Estrutura Desktop**: tab order lógico, atalhos por plataforma, foco visível em modo teclado, menus e tooltips com atalhos, escopos de foco claros.

**Estrutura Mobile**: foco e navegação por teclado quando houver teclado físico ou acessibilidade; não assumir teclado.

**Regra de Transição**: respeitar as convenções da plataforma. Atalhos descobríveis, sem capturar atalhos do sistema. Modal, popover e drawer controlam o foco no próprio escopo.

## Estados

**Estados próprios**: modo pointer, modo teclado, foco ativo, foco preso em modal, shortcut overlay ativo, conflito de atalho, elemento desativado, escopo de foco alterado.

**Reação a estados da página**: `loading` → foco preservado ou movido de forma previsível. `error` e `empty` → foco movido para a mensagem. `no-permission` → elementos restritos removidos do tab order.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo, Mobile nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar foco, landmarks, atalhos, skip links quando aplicável e conflitos com o browser.

**Adaptação Mobile nativo**: mapear para teclado físico ou entrada acessível quando houver equivalência real; não assumir teclado.

**Adaptação Desktop nativo**: respeitar `Ctrl` no Windows/Linux e `Cmd` no macOS; integrar menus, atalhos e focus chain do host.
