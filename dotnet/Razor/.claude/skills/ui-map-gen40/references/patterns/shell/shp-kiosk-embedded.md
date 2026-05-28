# SHP-KIOSK_EMBEDDED - Kiosk/Embedded

## Definição

**Definição curta**: Shell para dispositivos dedicados, atendimento assistido, contexto embarcado ou uso full-screen com fluxo restrito.

**Objetivo estrutural**: Sustentar tarefas rápidas, foco extremo, baixo desvio e integração com contexto físico ou hardware.

**Interação dominante**: Guiada

**Não confundir com**: SHP-PORTAL (conteúdo público navegável), SHP-WORKSPACE_ADMIN (operação multi-módulo), SHP-FOCUSED (tela autônoma sem fluxo dedicado).

## Decisão

**Sinais de escolha**:
- dispositivo dedicado
- touchscreen
- fluxo curto
- contexto físico
- sessões efêmeras
- navegação muito restrita
- integração com periféricos

**Limites**: não usar como shell principal para sistemas com exploração livre, multitarefa rica ou navegação profunda.

**Grau de Rigidez**: Alto — full-screen, navegação mínima e foco guiado são invariantes; periféricos e fluxo variam por dispositivo.

## Navegação e Estrutura

**Modelo de navegação global**: navegação mínima, full-screen, ações grandes e progressão guiada.

**Estrutura Desktop**: fullscreen, com poucos destinos e alta legibilidade.

**Estrutura Mobile**: comportamento equivalente, priorizando toque, foco e baixo desvio.

**Regra de transição**: preservar foco absoluto na tarefa e minimizar caminhos alternativos.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-DETAIL.

**Compatibilidade Secundária**: PP-CALENDAR, PP-DASHBOARD, PP-MAP.

**Incompatibilidades explícitas**: PP-LIST-DETAIL multi-módulo; PP-CANVAS como experiência principal.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: tratar como host técnico quando o browser estiver bloqueado ou em fullscreen.

**Adaptação Mobile nativo**: modelar permissões, lifecycle e periféricos quando câmera, localização, scanner ou impressora forem parte da tarefa.

**Adaptação Desktop nativo**: fullscreen, sessão controlada, poucos destinos, integração com hardware e recuperação explícita de falhas de periférico.
