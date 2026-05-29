# Bar - Sample

## Contrato de uso

**Entrada pública**: `<Bar>` — namespace `RoyalCode.Razor.Layouts`
**Grupo**: UI-STRUCT
**Propósito**: Container horizontal com três zonas (Start, Middle, End) para distribuição de conteúdo em linha — toolbars, headers de seção e linhas de item.
**Patterns**:
- `implementa`: UIP-ACTION-ACTION_BAR, UIP-CONTENT-CONTENT_HEADER, UIP-STRUCT-LAYOUT_ZONE
- `compõe`: UIP-NAV-SECTION_NAV, UIP-NAV-TABS, UIP-NAV-STEPPER_INDICATOR, UIP-DATA-LIST_ITEM, UIP-STRUCT-COLLAPSIBLE_SECTION, UIP-OVERLAY-MODAL, UIP-OVERLAY-DRAWER
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: qualquer distribuição horizontal com zonas Start/End — headers de página, toolbars, linhas de lista, rodapés de modal
- **Evite quando**: a distribuição é vertical — use `Stack`; quando precisa de grid responsivo — use `Container`+`Slot`
- **Cuidado**: zonas não preenchidas rendem `<div>` vazio — não é problema visual, mas evitar declarar zonas sem conteúdo

## Exemplos

### `UIP-ACTION-ACTION_BAR, UIP-CONTENT-CONTENT_HEADER` — Header de página e toolbar

O padrão mais comum: título no Start, ação primária no End; `mb-7` separa do conteúdo.

```razor
@* Header de página com ação *@
<Bar AdditionalClasses="mb-7">
    <StartContent>
        <h1 class="text-xl font-semibold text-dark-600">Usuários</h1>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Default" Outline=true Label="Exportar" OnClick="Exportar" />
        <Button Style="Themes.Primary" Label="Novo usuário" OnClick="Abrir" />
    </EndContent>
</Bar>

@* Toolbar com filtros no Start e ações no End *@
<Bar AdditionalClasses="mb-4 flex-wrap gap-2">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar..." AdditionalClasses="w-56" />
        <ButtonGroup Style="Themes.Secondary" Size="Sizes.Small">
            <Button Label="Todos" Active="@(filtro == null)" OnClick='() => filtro = null' />
            <Button Label="Ativos" Active="@(filtro == "ativo")" OnClick='() => filtro = "ativo"' />
        </ButtonGroup>
    </StartContent>
    <EndContent>
        <IconButton Icon="WellKnownIcons.Refresh" Style="Themes.Default" OnClick="Atualizar" />
    </EndContent>
</Bar>
```

**API usada**: `StartContent`, `EndContent`, `AdditionalClasses`

### `UIP-STRUCT-LAYOUT_ZONE` — Zona de layout com três áreas

Use `MiddleContent` quando o layout precisa de três colunas bem distribuídas.

```razor
@* Header de aplicação com logo, busca central e usuário *@
<Bar AdditionalClasses="px-6 py-3 bg-white border-b border-light-200">
    <StartContent>
        <span class="font-bold text-dark-700 text-lg">AppName</span>
    </StartContent>
    <MiddleContent>
        <TextField @bind-Value="buscaGlobal"
                   Placeholder="Buscar..."
                   AdditionalClasses="w-72" />
    </MiddleContent>
    <EndContent>
        <span class="text-sm text-dark-600">@usuario.Nome</span>
        <IconButton Icon="WellKnownIcons.Settings" Style="Themes.Default" />
    </EndContent>
</Bar>
```

**API usada**: `StartContent`, `MiddleContent`, `EndContent`

### `UIP-NAV-SECTION_NAV, UIP-NAV-TABS, UIP-NAV-STEPPER_INDICATOR` — Navegação horizontal com Bar

```razor
@* Section nav / tabs — botões com Active *@
<Bar AdditionalClasses="border-b border-light-200 mb-6">
    <StartContent>
        @foreach (var (id, label) in new[] { ("geral","Geral"), ("avancado","Avançado"), ("billing","Faturamento") })
        {
            <Button Label="@label"
                    Style="Themes.Default"
                    Outline="@(secao != id)"
                    Active="@(secao == id)"
                    OnClick="() => secao = id" />
        }
    </StartContent>
</Bar>

@* Stepper indicator — passos com badges *@
<Bar AdditionalClasses="mb-6">
    <StartContent>
        @for (int i = 1; i <= 3; i++)
        {
            int passo = i;
            <div class="flex items-center gap-2">
                <Badge Style="@(passo == passoAtual ? Themes.Primary : (passo < passoAtual ? Themes.Success : Themes.Light))"
                       Text="@passo.ToString()" />
                <span class="text-sm @(passo == passoAtual ? "font-semibold text-dark-700" : "text-dark-400")">
                    @PassoLabel(passo)
                </span>
                @if (i < 3) { <span class="text-dark-300 mx-2">→</span> }
            </div>
        }
    </StartContent>
</Bar>
```

### `UIP-DATA-LIST_ITEM, UIP-STRUCT-COLLAPSIBLE_SECTION` — Bar em listas e cabeçalhos de seção

```razor
@* List item — dado no Start, ações no End *@
@foreach (var item in itens)
{
    <Bar AdditionalClasses="p-3 border-b border-light-100">
        <StartContent>
            <div>
                <p class="text-sm font-semibold text-dark-700">@item.Nome</p>
                <p class="text-xs text-dark-400">@item.Descricao</p>
            </div>
        </StartContent>
        <EndContent>
            <Badge Style="@item.StatusTema" Text="@item.Status" />
            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                           Style="Themes.Default" Size="Sizes.Small"
                           ContentType="DropContentType.List">
                <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                <DropItem Label="Excluir" OnClick="() => Excluir(item.Id)" />
            </DropIconButton>
        </EndContent>
    </Bar>
}

@* Collapsible section header *@
<Bar AdditionalClasses="p-3 cursor-pointer select-none"
     @onclick="() => secaoAberta = !secaoAberta">
    <StartContent>
        <span class="text-sm font-semibold text-dark-700">Histórico de alterações</span>
        <Badge Style="Themes.Secondary" Text="@($"{historico.Count}")" Size="Sizes.Small" />
    </StartContent>
    <EndContent>
        <Icon Kind="@(secaoAberta ? WellKnownIcons.ChevronUp : WellKnownIcons.ChevronDown)" />
    </EndContent>
</Bar>
```

### `UIP-OVERLAY-MODAL, UIP-OVERLAY-DRAWER` — Rodapé de modal e header de drawer

```razor
@* Footer de Modal com ações — Bar dentro do ChildContent *@
<Modal Id="modal-editar" Handler="@modalHandler">
    <ChildContent>
        <div class="p-6">@* conteúdo principal *@</div>
        <div class="px-6 py-4 border-t border-light-200">
            <Bar>
                <EndContent>
                    <Button Style="Themes.Default" Label="Cancelar"
                            OnClick="async () => await modalHandler.CloseAsync()" />
                    <Button Style="Themes.Primary" Label="Confirmar"
                            OnClick="Confirmar" />
                </EndContent>
            </Bar>
        </div>
    </ChildContent>
</Modal>

@* Header customizado de OffCanvas com UseBox=false *@
<OffCanvas Position="Positions.End" Handler="@drawerHandler" UseBox=false>
    <Bar AdditionalClasses="px-6 py-4 border-b border-light-200 shrink-0">
        <StartContent>
            <h2 class="text-base font-semibold text-dark-700">Detalhes</h2>
        </StartContent>
        <EndContent>
            <CloseOffCanvasButton />
        </EndContent>
    </Bar>
    <div class="p-6 overflow-y-auto flex-1">@* conteúdo *@</div>
</OffCanvas>
```

## API relevante

- **Props/parâmetros**: `AdditionalClasses: string?`, `AdditionalAttributes`
- **Slots**: `StartContent`, `MiddleContent`, `EndContent` — todos opcionais (`RenderFragment`, default vazio)
- **Base CSS**: `ya-bar flex justify-between items-center w-full` — aplica flexbox horizontal com espaçamento entre zonas
