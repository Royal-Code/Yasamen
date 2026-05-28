# Icon - Sample

## Contrato de uso

**Entrada pública**: `<Icon>` + `WellKnownIcons` — namespace `RoyalCode.Razor.Icons`
**Grupo**: UI-CONTENT
**Propósito**: Renderiza um ícone via sistema extensível de `IIconContentFactory`. Sem ícones embutidos — requer pacote de ícones registrado.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: `builder.Services.AddYasamenBootstrapIcons()` (ou pacote equivalente) + `<YasamenStyles />` no `<head>`; sem pacote de ícones registrado, exibe ícone de fallback "ban"

## Regras rápidas

- **Use para**: renderizar ícones via `Enum Kind` em componentes customizados; raramente necessário diretamente — a maioria dos componentes da lib aceita parâmetro `Icon: Enum?`
- **Evite quando**: o componente alvo já aceita `Icon` como parâmetro — passe o enum diretamente ao componente (Button, Badge, etc.) sem usar `<Icon>` explicitamente
- **Cuidado**: sem pacote de ícones registrado via DI, todos os ícones renderizam como fallback "ban"

## Exemplos

### Renderização direta de ícone em componente customizado

Use `<Icon Kind="...">` quando construir um componente custom que precisa de ícone inline.

```razor
@* Ícone via WellKnownIcons — enum semântico registrado estaticamente *@
<div class="flex items-center gap-2 text-sm text-dark-600">
    <Icon Kind="WellKnownIcons.Info" />
    <span>Esta ação não pode ser desfeita.</span>
</div>

@* WellKnownIcons como parâmetro de componentes — modo preferido *@
<Button Style="Themes.Primary" Label="Salvar" Icon="WellKnownIcons.Save" />
<Badge Style="Themes.Success" Text="Ativo" Icon="WellKnownIcons.Check" />
```

**Nota**: `WellKnownIcons` é um registro estático de `IconFragment` por nome semântico (Save, Close, Add, Edit, Delete, Menu, Refresh, etc.). O pacote `RoyalCode.Razor.Icons.Bootstrap` registra a implementação padrão.

## API relevante

- **Props/parâmetros**: `Kind: Enum` — enum do ícone registrado via `IIconContentFactory`
- **Eventos/comandos**: -
- **Slots**: -

## Limites e combinações frágeis

- Usar SVG inline em parâmetros de ícone não é suportado — o sistema usa factory por enum, não RenderFragment direto em `Kind`
- `WellKnownIcons` é estático e extensível; ícones customizados requerem registro no DI via `IIconContentFactory`
