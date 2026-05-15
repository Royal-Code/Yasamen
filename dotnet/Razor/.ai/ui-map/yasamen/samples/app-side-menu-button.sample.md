# AppSideMenuButton - Sample

## Visão geral
- **Propósito**: botão de sidebar que alterna o menu principal em offcanvas.
- **Complexidade**: 5
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU
- **Variações demonstradas**: uso no shell e composição com favoritos.

## Exemplos

### SHP-WORKSPACE_ADMIN

**Objetivo**: abrir menu global no app shell.

```razor
<AppLayout>
    <LeftMenu>
        <AppSideMenuButton />
    </LeftMenu>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: nenhuma pública evidenciada.  
**Eventos relevantes**: handler interno de offcanvas.  
**Por que atende o pattern**: dá acesso ao menu global em shell administrativo.

### Com ação lateral adicional

**Objetivo**: combinar menu principal e ação de sidebar.

```razor
<AppLayout>
    <LeftMenu>
        <AppSideMenuButton />
        <div class="mx-2 py-3 flex justify-center">
            <IconButton Icon="BsIconNames.Gear" title="Configurações" />
        </div>
    </LeftMenu>
</AppLayout>
```

**Props usadas**: nenhuma direta.  
**Eventos relevantes**: eventos nos botões adicionais.  
**Por que atende o pattern**: preserva acesso global e utilitários.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| nenhuma pública evidenciada | não aplicável | uso direto | comportamento fixo |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum público evidenciado | não aplicável | toggle interno |

## Limitações
- Depende do contexto/serviços do app menu.

## Combinações frágeis
- Não substituir por `IconButton` comum se o objetivo for abrir `AppMenu`.
