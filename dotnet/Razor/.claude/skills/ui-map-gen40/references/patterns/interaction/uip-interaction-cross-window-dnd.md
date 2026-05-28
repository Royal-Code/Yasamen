# UIP-INTERACTION-CROSS_WINDOW_DND - Cross Window Drag and Drop

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Arrastar e soltar entre janelas da mesma app, entre apps ou entre a app e o sistema de arquivos.

**Objetivo estrutural**: Permitir transferência de dados, arquivos ou objetos por gesto direto entre contextos separados.

**Não confundir com**: UIP-INTERACTION-DRAG_DROP (arraste dentro da mesma tela), clipboard copy/paste (fora do catálogo), upload por arraste em zona única (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando o usuário trabalha com arquivos ou objetos transferíveis entre janelas; quando integração com Finder, Explorer ou outra app é esperada; quando o app tem múltiplas janelas, documentos ou workspaces paralelos.

**Quando evitar**: quando todo drag/drop ocorre dentro da mesma vista; quando clipboard, import/export ou file picker resolvem melhor; quando a interação é rara e o custo de integração com o host não compensa.

**Alternativas próximas**: UIP-INTERACTION-DRAG_DROP (arraste interno), UIP-INPUT-FILE_UPLOAD (envio de arquivo).

**Sinais de escolha**:
- múltiplas janelas
- assets ou arquivos transferíveis
- integração com o sistema de arquivos
- editores com layers ou objetos transferíveis
- apps de produtividade com documentos independentes

**Grau de Rigidez**: Médio — arraste entre janelas ou sistema é invariante; tipos de dados, feedback e destino de soltars variam.

## Composição

**Zonas usuais**: Superfície, Painel Auxiliar.

**Variantes reconhecidas**: arraste entre janelas da app; arraste para o sistema de arquivos; arraste de arquivo externo para o app; arraste entre apps; file promise ou exportação lazy.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-MEDIA_CONTENT, SHP-DASHBOARD_ANALYTICS.

**Incompatibilidades explícitas**: SHP-KIOSK_EMBEDDED, SHP-PORTAL, SHP-FOCUSED.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-DETAIL.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-CATALOG, PP-BOARD.

**Incompatibilidades explícitas**: não substitui drag/drop interno para reorder, associação ou movimentação dentro da mesma superfície.

## Estrutura e Transição

**Estrutura Desktop**: source com preview, destinos válidos, operação indicada como copy, move ou link, cancelamento por escape e integração com arquivos quando aplicável.

**Estrutura Mobile**: geralmente inadequado; preferir share sheet, picker ou import/export.

**Regra de Transição**: mostrar preview e destinos válidos, suportar cancelamento, não bloquear a UI durante o arraste e validar permissões e formato antes de concluir.

## Estados

**Estados próprios**: idle, arrastando, sobre destino válido, sobre destino inválido, solto, processando, cancelado, falhou.

**Reação a estados da página**: `no-permission` → drop zone desativada. `error` no drop → feedback no escopo da operação, com undo quando possível.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar os limites do browser e oferecer file picker, upload ou copy/paste como fallback.

**Adaptação Mobile nativo**: preferir share sheet, picker, import/export ou arraste interno quando houver suporte real.

**Adaptação Desktop nativo**: integrar APIs de drag/drop do SO, sistema de arquivos, múltiplas janelas e permissões.
