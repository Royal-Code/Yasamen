# AppTopBar - Sample

## Visão geral
- **Propósito**: topbar de aplicação com slots de início, centro e fim.
- **Complexidade**: 4
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-ACTION-ACTION_BAR
- **Variações demonstradas**: uso indireto via `AppLayout` e direto.

## Exemplos

### Uso via AppLayout

**Objetivo**: preencher topbar do shell.

```razor
<AppLayout>
    <TopStart><strong>Admin</strong></TopStart>
    <TopCenter><span class="text-sm text-dark-500">Clientes</span></TopCenter>
    <TopEnd><Button Label="Novo" Style="Themes.Primary" Size="Sizes.Small" /></TopEnd>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: slots do `AppLayout` repassados à topbar.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: cria cabeçalho operacional persistente.

### Uso direto

**Objetivo**: topbar em composição específica.

```razor
<AppTopBar Size="SpacingSize.LargerX2">
    <StartContent>Início</StartContent>
    <CenterContent>Centro</CenterContent>
    <EndContent><IconButton Icon="BsIconNames.Gear" /></EndContent>
</AppTopBar>
```

**Props usadas**: `Size`, `StartContent`, `CenterContent`, `EndContent`.  
**Eventos relevantes**: eventos nos filhos.  
**Por que atende o pattern**: separa zonas da barra superior.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Size` | `SpacingSize` | altura | dimensão |
| `StartContent` | `RenderFragment` | marca/menu | esquerda |
| `CenterContent` | `RenderFragment` | contexto | centro |
| `EndContent` | `RenderFragment` | ações | direita |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Geralmente preferir via `AppLayout`.

## Combinações frágeis
- Excesso de conteúdo no centro compete com ações.
