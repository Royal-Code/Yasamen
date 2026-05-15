# AppLayout - Sample

## Visão geral
- **Propósito**: shell de aplicação com topbar, menus laterais, conteúdo, footer e outlets globais.
- **Complexidade**: 8
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU, PP-DASHBOARD
- **Variações demonstradas**: slots, menu lateral e classes de conteúdo.

## Exemplos

### SHP-WORKSPACE_ADMIN

**Objetivo**: shell administrativo completo.

```razor
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart><strong>Operação</strong></TopStart>
    <TopEnd><Button Label="Novo" Style="Themes.Primary" Size="Sizes.Small" /></TopEnd>
    <LeftMenu><AppSideMenuButton /></LeftMenu>
    <Main>
        <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
            @Body
        </Box>
    </Main>
    <Footer><span class="text-sm text-dark-500">Rodapé</span></Footer>
</AppLayout>
```

**Props usadas**: `TopStart`, `TopEnd`, `LeftMenu`, `Main`, `Footer`, `AdditionalMainClasses`.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: mantém navegação global e área de trabalho persistentes.

### Shell com menu direito

**Objetivo**: painel auxiliar lateral.

```razor
<AppLayout>
    <RightMenu>
        <Box AdditionalClasses="p-4 bg-white h-full border-l border-light-300">Contexto</Box>
    </RightMenu>
    <Main>Conteúdo</Main>
</AppLayout>
```

**Props usadas**: `RightMenu`, `Main`.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: sustenta detalhe/contexto no shell.

### Ajuste de zonas

**Objetivo**: aplicar classes por área.

```razor
<AppLayout AdditionalHeaderClasses="border-b border-light-300"
           AdditionalMainClasses="p-6"
           AdditionalFooterClasses="text-sm text-dark-500">
    <Main>Conteúdo</Main>
    <Footer>Atualizado agora</Footer>
</AppLayout>
```

**Props usadas**: classes adicionais por zona.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: preserva shell e permite ajuste visual local.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `TopStart`/`TopCenter`/`TopEnd` | `RenderFragment` | topbar | conteúdo superior |
| `LeftMenu`/`RightMenu` | `RenderFragment` | navegação/contexto | sidebars |
| `Main` | `RenderFragment` | sempre | conteúdo |
| `Footer` | `RenderFragment` | rodapé | base |
| `TopSize`/`FooterSize`/menus | `SpacingSize` | dimensão | tamanho de zonas |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Busca do `AppMenu` não está pronta.

## Combinações frágeis
- Shell muito customizado pode quebrar camadas de modal/offcanvas/notificação.
