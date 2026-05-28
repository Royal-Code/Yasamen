# SHP-PORTAL - Portal

## Definição

**Definição curta**: Shell para conteúdo público, institucional, descoberta leve e jornadas lineares ou hierárquicas.

**Objetivo estrutural**: Sustentar navegação pública, clareza de entrada e progressão simples entre seções.

**Interação dominante**: Informativa

**Não confundir com**: SHP-MEDIA_CONTENT (consumo de mídia), SHP-WORKSPACE_ADMIN (operação interna), SHP-TRANSACTIONAL_COMMERCE (conversão e transação).

## Decisão

**Sinais de escolha**:
- conteúdo público
- navegação linear ou hierárquica
- baixa densidade operacional
- foco em descoberta, leitura, onboarding ou autoatendimento leve

**Limites**: não usar como shell principal de sistemas internos densos, operações complexas ou monitoramento contínuo.

**Grau de Rigidez**: Médio — header e navegação global são estáveis; estrutura interna de seções e CTAs varia por jornada e público.

## Navegação e Estrutura

**Modelo de navegação global**: header superior, navegação simples, rodapé informativo e CTAs claros.

**Estrutura Desktop**: header superior com navegação horizontal e corpo linear por seções.

**Estrutura Mobile**: header compacto, menu recolhível e fluxo vertical dominante.

**Regra de transição**: preservar a clareza de navegação e dos CTAs com simplificação progressiva da hierarquia.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LANDING, PP-DETAIL, PP-CATALOG, PP-FEED.

**Compatibilidade Secundária**: PP-FORM, PP-WIZARD, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-LIST-DETAIL como padrão dominante multi-módulo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Web.


## Adaptação por Plataforma

**Adaptação Web**: manter a navegação global simples e decidir o comportamento de header e menu em viewport pequeno.

**Adaptação Mobile nativo**: converter jornadas lineares em stack ou onboarding; evitar copiar a estrutura de site longo quando a experiência for de app.
