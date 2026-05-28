# UIP-SYSTEM-DOCK_INTEGRATION - Dock Integration

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Integração com dock ou taskbar do sistema operacional para progresso, badges, jump lists e ações rápidas.

**Objetivo estrutural**: Usar a presença do app no dock ou taskbar para comunicar estado e oferecer acesso rápido a destinos ou ações sem abrir uma tela específica.

**Não confundir com**: UIP-SYSTEM-TRAY (presença em background), notificação do SO (fora do catálogo), feedback interno de página (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando o app tem operação longa comunicável pelo taskbar ou dock; quando badges numéricos são relevantes; quando jump lists, dock menu ou documentos recentes aceleram o retorno; quando o estado precisa ser percebido fora da janela ativa.

**Quando evitar**: quando o app não tem estado comunicável pelo dock; quando badges viram ruído; quando a operação exige feedback contextual dentro da página; quando o host não suporta integração.

**Alternativas próximas**: UIP-SYSTEM-TRAY (presença em background), UIP-SYSTEM-BACKGROUND_PROGRESS (progresso de operação longa), UIP-FEEDBACK-LOADING_STATE (carregamento local).

**Sinais de escolha**:
- download, upload, build ou export em background
- mensagens não lidas
- documentos recentes
- ações frequentes acessíveis fora da janela

**Grau de Rigidez**: Médio — integração com dock ou taskbar é invariante; badges, jump lists e progresso variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: progress bar na taskbar; badge numérico; badge de estado; jump list; dock menu; tarefas de usuário na taskbar.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-COMMUNICATION, SHP-STUDIO_WORKBENCH, SHP-WORKSPACE_ADMIN.

**Compatibilidade Secundária**: SHP-MEDIA_CONTENT, SHP-DASHBOARD_ANALYTICS, SHP-TRANSACTIONAL_COMMERCE.

**Incompatibilidades explícitas**: apps sem estado externo relevante ou sem integração de host.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui feedback contextual da página.

## Estrutura e Transição

**Estrutura Desktop**: progress bar na taskbar, badge numérico ou de estado, jump list e dock menu com recentes e ações rápidas.

**Estrutura Mobile**: substituir por badge de app, notificações e background progress nativo.

**Regra de Transição**: usar progresso para operações longas, badge para contadores com valor operacional e jump ou dock menu para destinos úteis. Limpar badges e progresso quando o estado deixa de existir.

## Estados

**Estados próprios**: sem indicação, badge ativo, progresso determinado, progresso indeterminado, progresso pausado, progresso com erro, jump list disponível.

**Reação a estados da página**: operação em background → progresso no host. `error` → estado de erro quando suportado. Conclusão → limpar progresso e sinalizar apenas se exigir atenção.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar app badges, shortcuts e instalação antes de planejar dependência.

**Adaptação Mobile nativo**: substituir por badge de app, notificações e background progress nativo.

**Adaptação Desktop nativo**: integrar APIs de taskbar ou dock, progress, badge, jump list, recentes e ações rápidas.
