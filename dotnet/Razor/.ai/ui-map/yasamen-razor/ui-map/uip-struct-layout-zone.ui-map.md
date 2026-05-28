# UIP-STRUCT-LAYOUT_ZONE - Layout Zone

## Componentes

**Principais**:

1. Box
- `cobertura`: delimita uma zona funcional com borda, padding e margem via builders; sem scroll próprio; adequado para zonas de conteúdo, detalhe e painel auxiliar; estados de zona (loading/empty/error) devem ser colocados como filhos;
- `limitações`: sem estado de loading/empty nativo; sem título de zona; sem comportamento de colapso; borda e padding requerem builders explícitos; não define posição da zona na página por si só;
- `nota`: 7;
- `justificativa`: cobre bem o papel de delimitador de zona funcional com controle de aparência; falta semântica de estado e título de zona, compensáveis por composição.

2. Bar
- `cobertura`: zona horizontal com três slots (Start, Center, End); ideal para zonas de ação/cabeçalho; não cobre zonas de conteúdo vertical ou grade;
- `limitações`: apenas layout horizontal; não serve para zonas de conteúdo principal; sem estado de loading/empty;
- `nota`: 7;
- `justificativa`: cobre o papel de zona de ação e cabeçalho de forma nativa; limitado a uso horizontal.

3. AppLayout (zonas de shell)
- `cobertura`: define zonas funcionais de shell (TopBar, SideBar, AppContent, Footer) com posicionamento fixo, z-index e responsividade; zonas de shell nomeadas e com comportamento definido;
- `limitações`: aplicável apenas ao shell raiz da aplicação; não serve para subzonas de página;
- `nota`: 9;
- `justificativa`: cobertura nativa para zonas de shell; cada zona tem semântica explícita, posicionamento automático e responsividade.

**Composição**:

1. Container + Slot
- `cobertura`: distribui zonas em grade responsiva de 12 colunas; cada Slot é uma subzona com largura configu​rável por breakpoint;
- `limitações`: zonamento por grade, não por responsabilidade funcional; sem título de zona; sem estado;
- `nota`: 8;
- `justificativa`: encaixe natural para criar múltiplas zonas em grade responsiva dentro de uma página.

2. Stack
- `cobertura`: agrupa filhos em sequência vertical; pode ser zona de conteúdo vertical;
- `limitações`: sem semântica de zona funcional; sem estado; puro layout;
- `nota`: 7;
- `justificativa`: útil para o conteúdo interno de zonas verticais.

3. AsideBox
- `cobertura`: zona titulada dentro de OffCanvas com cabeçalho e botão de fechar; adequado para painel auxiliar;
- `limitações`: requer OffCanvas como pai; não serve para zonas de página principal;
- `nota`: 7;
- `justificativa`: cobertura específica para a zona de painel auxiliar em contexto de OffCanvas.

**Descartados**:

1. AppTopBar, AppSideBar
- `motivo`: componentes de zona do shell — cobertos já pelo AppLayout; não são zonas reutilizáveis de página.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `estado de zona (loading/empty/error)`: nenhum componente de zona gerencia estados de forma nativa — colocar Feedback/loading state como filho explícito; impacto baixo;
  - `título semântico de zona`: Box e Container não têm título; usar heading HTML (`<h2>`) ou Bar com StartContent; impacto mínimo;
  - `colapso de zona`: nenhum suporte nativo de colapso em zonas de página — ver UIP-STRUCT-COLLAPSIBLE_SECTION para alternativa customizada.

- `tipo de adaptação`: componente principal + composição
- `o que precisa ser feito`:
  - Para zonas de página geral: usar `Box` com `BorderBuilder` para delimitar, `Stack` ou `Container+Slot` para conteúdo interno;
  - Para zonas de ação/cabeçalho: usar `Bar` com slots Start/Center/End;
  - Para zonas de shell: usar `AppLayout` com slots nomeados;
  - Para estados de zona: inserir `Feedback` ou bloco de loading como primeiro filho condicional;
  - Para painel auxiliar lateral: usar `OffCanvas` + `AsideBox`.

## Como usar

### Zona de conteúdo genérica com Box

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="mb-6">
    <h2 class="text-lg font-semibold text-dark-600 mb-4 pb-3 border-b border-light-200">
        Informações do Cliente
    </h2>
    @if (isLoading)
    {
        <Feedback Style="Themes.Info" Text="Carregando..." />
    }
    else if (cliente is null)
    {
        <Feedback Style="Themes.Warning" Title="Vazio" Text="Nenhum cliente selecionado." />
    }
    else
    {
        <Stack>
            @* conteúdo da zona *@
        </Stack>
    }
</Box>
```

### Zonas em grade responsiva com Container + Slot

```razor
<Container Type="LayoutTypes.Grid" AdditionalClasses="mb-6">
    @* Zona de filtros — 12 colunas mobile, 4 colunas tablet+ *@
    <Slot Span="12" TabletSpan="4">
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <h3 class="text-sm font-semibold text-dark-600 mb-3">Filtros</h3>
            @* conteúdo de filtros *@
        </Box>
    </Slot>
    @* Zona de resultados — 12 colunas mobile, 8 colunas tablet+ *@
    <Slot Span="12" TabletSpan="8">
        <Box Border="BorderBuilder.Box">
            @* conteúdo da listagem *@
        </Box>
    </Slot>
</Container>
```

### Zona de ação com Bar

```razor
<Bar AdditionalClasses="mb-6 pb-4 border-b border-light-200">
    <StartContent>
        <h1 class="text-xl font-semibold text-dark-600">Pedidos</h1>
        <Badge Style="Themes.Info" Text="@($"{totalPedidos} registros")" AdditionalClasses="ml-3" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo Pedido" OnClick="NovoPedido" />
    </EndContent>
</Bar>
```

### Zonas de shell com AppLayout

```razor
<AppLayout>
    <TopBar>
        <AppTopBar>
            <StartContent><AppSideMenuButton /></StartContent>
        </AppTopBar>
    </TopBar>
    <SideBar>
        <AppSideBar>
            <AppSideItem Icon="WellKnownIcons.Home" Href="/" Label="Início" />
        </AppSideBar>
    </SideBar>
    <AppContent>
        @Body
    </AppContent>
</AppLayout>
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: estados de zona (loading/empty/error) não são nativos — inserir filhos condicionais; sem componente de colapso de zona; título de zona requer HTML explícito; cobertura de shell (AppLayout) é excelente, cobertura de zonas de página é boa via composição;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Box` + `BorderBuilder` é o delimitador de zona de conteúdo mais natural e direto;
  - `Bar` é a zona de cabeçalho/ação nativa com três posições;
  - `Container` + `Slot` entrega grade responsiva de zonas em 12 colunas;
  - `AppLayout` cobre zonas de shell com nota 9 — topbar fixo, sidebar, content e footer;
  - A ausência de gerenciamento de estado de zona nativo (loading/empty/error) é contornada com Feedback como filho condicional — impacto baixo;
  - Nota 8 reflete boa cobertura via composição de 2-3 componentes, sem precisar de implementação customizada além de HTML semântico pontual.
