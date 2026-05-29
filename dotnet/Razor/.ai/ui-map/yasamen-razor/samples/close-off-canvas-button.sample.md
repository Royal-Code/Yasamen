# CloseOffCanvasButton - Sample

## Contrato de uso

**Entrada pública**: `<CloseOffCanvasButton>` — namespace `RoyalCode.Razor.OffCanvas`
**Grupo**: UI-ACTION
**Propósito**: Botão de fechar para `OffCanvas`. Obtém o `OffCanvasHandler` via cascading e chama `Hide()` ao clicar.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-OVERLAY-DRAWER, UIP-NAV-NAVIGATION_MENU
**Setup necessário**: `builder.Services.AddYasamenOffCanvas()` + `<YasamenStyles />` no `<head>`; requer contexto cascading de `OffCanvasHandler`

## Regras rápidas

- **Use para**: botão de fechar dentro de `OffCanvas` com `UseBox=false` (conteúdo customizado) — quando o `AsideBox` automático não é usado
- **Evite quando**: o `OffCanvas` já usa `UseBox=true` com `Closeable=true` — o botão fechar já está incluso automaticamente no `AsideBox`
- **Cuidado**: lança `InvalidOperationException` se `OffCanvasHandler` não estiver disponível no cascading — só funciona dentro de um `OffCanvas`

## Exemplos

### `UIP-OVERLAY-DRAWER, UIP-NAV-NAVIGATION_MENU` — Botão fechar em OffCanvas com conteúdo customizado

Use dentro de `OffCanvas` com `UseBox=false` quando o header do drawer é construído manualmente.

```razor
@code {
    private OffCanvasHandler drawerHandler = new();
}

<Button Style="Themes.Default" Label="Abrir painel"
        OnClick="async () => await drawerHandler.Show()" />

<OffCanvas Position="Positions.End"
           Fitting="Fitting.Overlaying"
           Modal=true
           Handler="@drawerHandler">
    @* Header customizado com CloseOffCanvasButton *@
    <Bar AdditionalClasses="px-6 py-4 border-b border-light-200">
        <StartContent>
            <h2 class="text-base font-semibold text-dark-700">Detalhes do pedido</h2>
        </StartContent>
        <EndContent>
            <CloseOffCanvasButton />
        </EndContent>
    </Bar>
    <div class="p-6">
        <p class="text-sm text-dark-600">Conteúdo do painel...</p>
    </div>
</OffCanvas>
```

**Nota**: `CloseOffCanvasButton` não precisa de nenhum parâmetro — captura `OffCanvasHandler` via cascading do `OffCanvas` pai. `Handler` no `OffCanvas` é propagado automaticamente para os filhos.

## API relevante

- **Props/parâmetros**: nenhum parâmetro público — o `OffCanvasHandler` vem por cascading obrigatório
- **Eventos/comandos**: chama `handler.Hide()` ao clicar (interno)
- **Slots**: -

## Limites e combinações frágeis

- Lança `InvalidOperationException` se usado fora de um `OffCanvas` (sem cascading de `OffCanvasHandler`)
- Quando `OffCanvas` usa `UseBox=true` com `Closeable=true`, o `CloseOffCanvasButton` já está incluso no `AsideBox` — não adicionar manualmente para evitar duplicação
