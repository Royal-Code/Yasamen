# RotationMotion - Sample

## Contrato de uso

**Entrada pública**: `<RotationMotion>` / `Motions.Rotation(clockwise)` — namespace `RoyalCode.Razor.Animations`
**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Wrapper que aplica animação CSS de rotação contínua (clockwise ou counter-clockwise) via atributos HTML customizados.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-FEEDBACK-LOADING_STATE, UIP-SYSTEM-BACKGROUND_PROGRESS
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: indicadores de loading/spinner em ícones de botão durante operações assíncronas
- **Evite quando**: a rotação é estática (ângulo fixo) — usar `RotateEffect`

## Exemplos

### `UIP-FEEDBACK-LOADING_STATE, UIP-SYSTEM-BACKGROUND_PROGRESS` — Spinner em botão e indicador de progresso

A forma idiomática é via `Motions.Rotation()` como `AnimationFragment` passado para `IconAnimation` em `Button` ou `IconButton`.

```razor
@code {
    private bool salvando;

    private async Task Salvar()
    {
        salvando = true;
        await Service.SalvarAsync(modelo);
        salvando = false;
    }
}

@* UIP-FEEDBACK-LOADING_STATE: spinner no ícone do botão *@
<Button Style="Themes.Primary"
        Label="@(salvando ? "Salvando..." : "Salvar")"
        Icon="WellKnownIcons.Save"
        IconAnimation="@(salvando ? Motions.Rotation() : null)"
        Disabled="salvando"
        OnClick="Salvar" />

@* UIP-SYSTEM-BACKGROUND_PROGRESS: indicador inline de processo em segundo plano *@
@if (processandoEmBackground)
{
    <div class="flex items-center gap-2 text-sm text-dark-500">
        <RotationMotion>
            <Icon Kind="WellKnownIcons.Sync" />
        </RotationMotion>
        <span>Sincronizando...</span>
    </div>
}
```

**API usada**: `Motions.Rotation(bool clockwise = true)` → `AnimationFragment`; `<RotationMotion>` direto
**Nota**: `Motions.Rotation()` retorna `AnimationFragment` — passe `null` quando não está em loading para remover a animação. O atributo HTML aplicado é `ya-rotation` (clockwise) ou `ya-rotation-clockwise` (counter-clockwise) — seletores CSS presentes via `YasamenStyles`.

## API relevante

- **`RotationMotion`**: `ChildContent: RenderFragment`, `CounterClockwise: bool` (default false)
- **`Motions.Rotation(bool clockwise = true)`**: retorna `AnimationFragment`
- **Renderização**: `<div ya-rotation>` ou `<div ya-rotation-clockwise>` (atributo HTML, não classe CSS)
