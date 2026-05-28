# Ripple - Sample

## Contrato de uso

**Entrada pública**: `<Ripple>` — namespace `RoyalCode.Razor.Commons`
**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Efeito visual de onda material ao clicar em botões. Componente de infraestrutura injetado automaticamente por `Button` e `IconButton`.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Não usar diretamente** — é injetado automaticamente pelos componentes `Button` e `IconButton`
- Se necessário em componente customizado: inserir `<Ripple Dark="true|false" />` dentro do elemento clicável

## Exemplos

### Uso interno em componente customizado de botão

```razor
@* Normalmente desnecessário — apenas se construindo um botão customizado *@
<button class="ya-btn ya-btn-primary" @onclick="OnClick">
    @Label
    <Ripple Dark="false" />
</button>
```

**Nota**: `Dark=false` (padrão) usa `bg-white/50` (onda clara — para botões escuros). `Dark=true` usa `bg-black/30` (onda escura — para botões claros). `Button` usa `DarkRipple` que é false por padrão; `IconButton` usa `Dark=true` sempre.

## API relevante

- **Props/parâmetros**: `Dark: bool` — variante dark do efeito (default false)
- **Inicialização**: `RippleJs.RippleAsync(ElementReference)` — chamado via `OnAfterRenderAsync` no primeiro render
