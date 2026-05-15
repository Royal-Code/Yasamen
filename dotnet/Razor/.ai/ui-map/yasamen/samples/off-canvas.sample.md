# OffCanvas - Sample

## Visão geral
- **Propósito**: painel lateral start/end com handler, fitting, modalidade e box padrão.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-INPUT-FILTER_PANEL, UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: filtros, menu lateral e box.

## Exemplos

### UIP-INPUT-FILTER_PANEL

**Objetivo**: filtros em gaveta lateral.

```razor
<Button Label="Filtros" OnClick="@(async _ => await filters.OpenAsync())" />
<OffCanvas Handler="filters" Position="Positions.End" Title="Filtros">
    <Stack AdditionalClasses="gap-4 p-4">
        <TextField Label="Status" @bind-Value="status" />
        <Button Label="Aplicar" Style="Themes.Primary" />
    </Stack>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filters = new();
    private string status = string.Empty;
}
```

**Props usadas**: `Handler`, `Position`, `Title`, `ChildContent`.  
**Eventos relevantes**: `OnVisibilityChanged` disponível.  
**Por que atende o pattern**: converte filtros em painel acessível sob demanda.

### Navigation Menu

**Objetivo**: menu lateral com conteúdo custom.

```razor
<OffCanvas Position="Positions.Start" Handler="menu" UseBox="false">
    <Box AdditionalClasses="p-4 bg-white h-full">
        <AppSideMenuButton />
    </Box>
</OffCanvas>

@code {
    private readonly OffCanvasHandler menu = new();
}
```

**Props usadas**: `UseBox`, `Position`, `Handler`.  
**Eventos relevantes**: handler.  
**Por que atende o pattern**: sustenta navegação compacta.

### Painel de detalhe

**Objetivo**: painel lateral modal.

```razor
<OffCanvas Handler="details" Position="Positions.End" Modal="true" Title="Detalhes" BoxSize="Sizes.Large">
    <p class="p-4">Conteúdo do detalhe.</p>
</OffCanvas>

@code {
    private readonly OffCanvasHandler details = new();
}
```

**Props usadas**: `Modal`, `BoxSize`, `Title`.  
**Eventos relevantes**: `OnVisibilityChanged`.  
**Por que atende o pattern**: cria camada lateral focada.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Position` | `Positions` | start/end | lado |
| `Fitting` | `Fitting` | relação com shell | encaixe |
| `Modal` | `bool` | bloquear fundo | backdrop |
| `Handler` | `OffCanvasHandler?` | controle externo | abrir/fechar |
| `UseBox` | `bool` | caixa padrão | header/título |
| `Title` | `string?` | box padrão | título |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnVisibilityChanged` | abre/fecha | sincronizar estado |

## Limitações
- Aceita `Positions.Start` ou `Positions.End`.

## Combinações frágeis
- Painel modal com conteúdo longo precisa scroll interno planejado.
