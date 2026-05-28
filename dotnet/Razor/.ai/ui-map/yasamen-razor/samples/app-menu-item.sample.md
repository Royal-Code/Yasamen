# AppMenuItem - Sample

## Contrato de uso

**Entrada pública**: `<AppMenuItem>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: UI-NAV
**Propósito**: Componente **interno** do `AppMenu`. Item de menu com suporte a três tipos: Link (NavLink), Module (nó com filhos) e Divider. Suporta favoritos toggle.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: Gerenciado automaticamente pelo `AppMenuList` → `AppMenu`

## Regras rápidas

- **Use para**: não usar diretamente — é gerenciado internamente pelo `AppMenuList`
- **Evite quando**: qualquer uso direto — componente interno sem garantia de API pública estável

## API relevante

- **Props/parâmetros**: `Item: MenuItem` (EditorRequired); `AppMenuContext` via cascading
- Componente interno — API sujeita a mudanças sem aviso
