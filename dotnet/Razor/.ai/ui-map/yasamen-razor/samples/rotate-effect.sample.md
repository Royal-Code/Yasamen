# RotateEffect - Sample

## Contrato de uso

**Entrada pública**: `<RotateEffect>` / `Effects.Rotate(degrees)` — namespace `RoyalCode.Razor.Animations`
**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Wrapper que aplica rotação estática em ângulo fixo ao conteúdo via CSS custom property `--rotate-effect-deg`.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: rotacionar ícones em ângulo fixo (ex: chevron expandido, seta direcional)
- **Evite quando**: a rotação deve ser animada (girar continuamente) — usar `RotationMotion`

## Exemplos

### Rotação estática via `Effects.Rotate()` como `IconAnimation`

A forma preferida é via factory `Effects.Rotate(degrees)` como `AnimationFragment` passado para `IconAnimation` em `Button` ou `IconButton`.

```razor
@* Chevron apontando para baixo → rotacionar 180° para "cima" quando expandido *@
<Button Style="Themes.Default"
        Label="@(expandido ? "Recolher" : "Expandir")"
        Icon="WellKnownIcons.ChevronDown"
        IconPosition="Positions.End"
        IconAnimation="@(expandido ? Effects.Rotate(180) : null)"
        OnClick="() => expandido = !expandido" />

@* Ou diretamente como componente wrapper *@
<RotateEffect Degrees="90">
    <Icon Kind="WellKnownIcons.ChevronDown" />
</RotateEffect>
```

**API usada**: `Effects.Rotate(double degrees)` → `AnimationFragment`; `RotateEffect.Degrees` [EditorRequired]
**Nota**: `Effects.Rotate()` retorna um `AnimationFragment` — delegate que encapsula `RotateEffect` para uso como parâmetro `IconAnimation` nos componentes de botão. O uso direto de `<RotateEffect>` é equivalente mas menos idiomático nesse contexto.

## API relevante

- **`RotateEffect`**: `Degrees: int` [EditorRequired], `ChildContent: RenderFragment`
- **`Effects.Rotate(double degrees)`**: retorna `AnimationFragment` (delegate `RenderFragment(RenderFragment)`)
- **`AnimationFragment`**: `delegate RenderFragment AnimationFragment(RenderFragment content)`
