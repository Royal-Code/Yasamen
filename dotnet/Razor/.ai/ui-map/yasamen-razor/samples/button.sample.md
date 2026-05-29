# Button - Sample

## Contrato de uso

**Entrada pública**: `<Button>` — namespace `RoyalCode.Razor.Buttons`
**Grupo**: UI-ACTION
**Propósito**: Botão HTML estilizado com label, ícone, tema, tamanho, outline, block, active, disabled e navegação client-side.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-ACTION-ACTION_BAR, UIP-CONTENT-CONTENT_HEADER, UIP-FEEDBACK-CONFIRMATION_DIALOG, UIP-FEEDBACK-LOADING_STATE, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-ACTION-FLOATING_ACTION, UIP-NAV-SECTION_NAV, UIP-NAV-TABS, UIP-INPUT-FILTER_PANEL
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: ações primárias, secundárias e destrutivas em formulários, diálogos, toolbars e headers de página
- **Evite quando**: a ação é representada apenas por ícone — use `IconButton`; para links de navegação pura sem semântica de ação, use `<NavLink>`
- **Cuidado**: máximo 1 botão `Themes.Primary` filled por contexto visual imediato (hierarquia por saturação); `Label` é obrigatório mesmo quando se usa `ChildContent`

## Exemplos

### `UIP-ACTION-ACTION_BAR, UIP-CONTENT-CONTENT_HEADER` — Barra de ações com variantes de tema

Use `Themes.Primary` para a ação mais importante e `Outline=true` para ações secundárias no mesmo contexto.

```razor
@* Header de página com ação primária + secundária *@
<Bar AdditionalClasses="mb-7">
    <StartContent>
        <h1 class="text-xl font-semibold text-dark-600">Pedidos</h1>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Default" Outline=true Label="Exportar" OnClick="Exportar" />
        <Button Style="Themes.Primary" Label="Novo Pedido" OnClick="AbrirCriacao" />
    </EndContent>
</Bar>

@* Grupo de ação destrutiva dentro de seção *@
<Bar>
    <EndContent>
        <Button Style="Themes.Default" Label="Cancelar" OnClick="Cancelar" />
        <Button Style="Themes.Danger" Label="Excluir conta" OnClick="ConfirmarExclusao" />
    </EndContent>
</Bar>
```

**API usada**: `Style`, `Outline`, `Label`, `OnClick`

### `UIP-FEEDBACK-CONFIRMATION_DIALOG` — Botões de confirmação em modal

Ação destrutiva sempre requer confirmação via Modal; botão de cancel usa Default/outline.

```razor
<Modal Id="modal-confirmar-exclusao" Handler="@modalHandler">
    <ChildContent>
        <div class="p-6">
            <p class="text-sm text-dark-600">
                Deseja excluir permanentemente "Relatório Q4 2025"?
            </p>
        </div>
        <div class="px-6 py-4 border-t border-light-200 flex justify-end gap-2">
            <Button Style="Themes.Default" Label="Cancelar"
                    OnClick="async () => await modalHandler.CloseAsync()" />
            <Button Style="Themes.Danger" Label="Excluir"
                    OnClick="ExecutarExclusao" />
        </div>
    </ChildContent>
</Modal>

### `UIP-FEEDBACK-LOADING_STATE` — Botão com ícone animado durante operação

Use `IconAnimation` com `RotationMotion` para indicar processamento; combine com `Disabled` para bloquear reenvio.

```razor
@code {
    private bool salvando;

    private AnimationFragment? Spinning =>
        salvando ? new RotationMotionFragment() : null;

    private async Task Salvar()
    {
        salvando = true;
        await Service.SalvarAsync(model);
        salvando = false;
    }
}

<Button Style="Themes.Primary"
        Label="@(salvando ? "Salvando..." : "Salvar")"
        Icon="WellKnownIcons.Save"
        IconAnimation="@Spinning"
        Disabled="@salvando"
        OnClick="Salvar" />
```

**API usada**: `Icon`, `IconAnimation`, `Disabled`, `Label` dinâmico
**Nota**: `RotationMotionFragment` é o helper concreto de `AnimationFragment` para rotação contínua. `[inferido]` — verificar tipo exato em `RoyalCode.Razor.Animations`.

### `UIP-NAV-SECTION_NAV, UIP-NAV-TABS` — Botão com estado ativo para navegação local

Use `Active=true` para marcar o item corrente; troque o estado ao clicar.

```razor
@code {
    private string secaoAtiva = "resumo";
}

<Bar AdditionalClasses="border-b border-light-200 mb-6">
    <StartContent>
        @foreach (var (id, label) in new[] { ("resumo","Resumo"), ("itens","Itens"), ("historico","Histórico") })
        {
            <Button Label="@label"
                    Style="Themes.Default"
                    Outline="@(secaoAtiva != id)"
                    Active="@(secaoAtiva == id)"
                    OnClick="() => secaoAtiva = id" />
        }
    </StartContent>
</Bar>
```

**API usada**: `Active`, `Outline`, `Style`

### `UIP-ACTION-FLOATING_ACTION, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-INPUT-FILTER_PANEL` — Usos variados

Floating action: botão fixo com classes Tailwind de posicionamento.

```razor
@* Floating action button — CSS position via AdditionalClasses *@
<Button Style="Themes.Primary"
        Icon="WellKnownIcons.Add"
        Label="Novo"
        AdditionalClasses="fixed bottom-6 right-6 shadow-lg z-50"
        OnClick="AbrirCriacao" />

@* Empty state — ação de recuperação *@
<Feedback Style="Themes.Light" Text="Nenhum item encontrado.">
    <ChildContent>
        <Button Style="Themes.Default" Size="Sizes.Small"
                Label="Limpar filtros" OnClick="LimparFiltros" />
    </ChildContent>
</Feedback>

@* Filter panel trigger *@
<Button Style="Themes.Default" Label="Filtros"
        Icon="WellKnownIcons.Filter"
        OnClick="AbrirFiltros" />
```

**API usada**: `AdditionalClasses`, `Size`, `Icon`, `Style`

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Label` | `string` | — (EditorRequired) | Texto do botão; obrigatório mesmo com ChildContent |
| `Style` | `Themes` | — | Cor semântica: Primary, Secondary, Danger, Default, etc. |
| `Size` | `Sizes` | Medium | Densidade visual |
| `Outline` | `bool` | false | Estilo borda sem preenchimento |
| `Active` | `bool` | false | Estado ativo visual (toggle/tab) |
| `Disabled` | `bool` | false | Desabilita e aplica opacity-50 |
| `Block` | `bool` | false | Largura total (w-full) |
| `Icon` | `Enum?` | null | Ícone via `WellKnownIcons` ou enum registrado |
| `IconPosition` | `Positions` | Start | Start ou End — Center inválido (coercido para Start) |
| `IconAnimation` | `AnimationFragment?` | null | Animação no ícone (ex: RotationMotion para loading) |
| `NavigateTo` | `string?` | null | URI de navegação client-side ao clicar |
| `OnClick` | `EventCallback<MouseEventArgs>` | — | Callback de clique |
| `Type` | `ButtonTypes` | button | button \| submit \| reset |

- **Slots**: `ChildContent` — conteúdo alternativo ao label; `ButtonGroupContext` via cascading herda Style, Size, Disabled do grupo pai

## Limites e combinações frágeis

- `IconPosition.Center` não é válido — é coercido para Start sem erro aparente
- `NavigateTo` e `OnClick` podem coexistir; ambos são executados ao clicar
- Dentro de `ButtonGroup`, Style e Size são sobrescritos pelo contexto cascading do grupo — declarar no nível do Button só tem efeito quando o Button está fora de um grupo

## Defaults importantes

- `Type` default `ButtonTypes.button`: para submit em `EditForm`, declarar `Type="ButtonTypes.Submit"` explicitamente
- `Outline` default `false`: botão filled por padrão — use outline para ações secundárias
