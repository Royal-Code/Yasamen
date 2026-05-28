# AsideBox - Sample

## Contrato de uso

**Entrada pública**: `<AsideBox>` — namespace `RoyalCode.Razor.Components`
**Grupo**: UI-OVERLAY
**Propósito**: Container de conteúdo interno do `OffCanvas` com cabeçalho opcional (título + botão fechar) e largura controlada por `Size`.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-STRUCT-LAYOUT_ZONE, UIP-OVERLAY-MODAL, UIP-OVERLAY-DRAWER
**Setup necessário**: `<YasamenStyles />` no `<head>`; normalmente usado dentro de `OffCanvas` com `UseBox=false`

## Regras rápidas

- **Use para**: layout customizado dentro de `OffCanvas` quando `UseBox=false` — substitui o AsideBox gerado automaticamente
- **Evite quando**: `UseBox=true` no `OffCanvas` — nesse caso o AsideBox é gerenciado automaticamente; não usar fora de um contexto de OffCanvas

## Exemplos

### `UIP-STRUCT-LAYOUT_ZONE, UIP-OVERLAY-MODAL, UIP-OVERLAY-DRAWER` — AsideBox em OffCanvas com UseBox=false

`AsideBox` recebe `Handler` por cascading do `OffCanvas` pai e exibe `CloseOffCanvasButton` automaticamente quando `Closeable=true` e `Handler` está disponível.

```razor
<OffCanvas Handler="@meuHandler"
           Position="Positions.End"
           UseBox=false
           Closeable=true>
    <ChildContent>
        <AsideBox Title="Detalhes"
                  Closeable=true
                  Size="Sizes.Large"
                  AdditionalClasses="min-h-screen">
            <Stack AdditionalClasses="gap-4">
                <p class="text-sm text-dark-600">Conteúdo personalizado do painel</p>
                <TextField @bind-Value="modelo.Nome" Label="Nome" />
            </Stack>
        </AsideBox>
    </ChildContent>
</OffCanvas>
```

**API usada**: `Title`, `Closeable`, `Size`
**Nota**: `Handler` (cascading) é propagado automaticamente pelo `OffCanvas` pai via `CascadingValue` — não passe manualmente. `Closeable=true` só exibe o botão × quando `Handler` não é null; sem handler cascading, o botão não aparece.

## API relevante

- **Props/parâmetros**: `Title: string?`, `Closeable: bool` (default false), `Size: Sizes` (default Medium), `ChildContent: RenderFragment`, `AdditionalClasses: string?`
- **Cascading**: `Handler: OffCanvasHandler` — recebido do `OffCanvas` pai; obrigatório para que `CloseOffCanvasButton` funcione
- **Renderização**: `<div class="ya-aside-box">` com header `<header>` condicional (se `Title != null || Closeable`)

## Limites e combinações frágeis

- `Handler` cascading vem do `OffCanvas` pai — se `AsideBox` for usado fora de `OffCanvas`, o botão fechar não aparece e não haverá erro, mas `Closeable` será ineficaz
- Normalmente desnecessário usar diretamente — quando `OffCanvas.UseBox=true`, o `AsideBox` é criado automaticamente com `Title` e `Closeable` propagados de `OffCanvas`
