# AppMenuList - Sample

## Contrato de uso

**Entrada pública**: `<AppMenuList>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: UI-NAV
**Propósito**: Componente **interno** do `AppMenu`. Renderiza a lista de itens do menu atual baseado no `CurrentMenuItem`.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: Gerenciado automaticamente pelo `AppMenu`

## Regras rápidas

- **Use para**: não usar diretamente — é gerenciado internamente pelo `AppMenu`
- **Evite quando**: qualquer uso direto — componente interno sem garantia de API pública estável

## API relevante

- **Props/parâmetros**: `CurrentMenuItem: MenuItem?` — item pai cujos filhos serão renderizados
- Componente interno — API sujeita a mudanças sem aviso
