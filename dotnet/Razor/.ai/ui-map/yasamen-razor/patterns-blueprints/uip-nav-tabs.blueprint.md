# UIP-NAV-TABS - Blueprint resumido

## Pattern

UIP-NAV-TABS — Tabs — ver `uip-nav-tabs.ui-map.md`

## Gap coberto

A lib não tem componente de Tabs. O padrão é feito com `Bar + ButtonGroup(Active)` para a barra de abas e `@if` para o painel de conteúdo. O gap é orientar os dois cenários: tabs com conteúdo inline e tabs como navegação de rota.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Bar + ButtonGroup + Button(Active)` + `@if/@switch` cobrem o padrão completo; o estilo visual difere do underline clássico (usa preenchimento `Active`), mas é consistente com o design system.

## Componentes usados

- `Bar` — papel: principal (container das abas) — ver `bar.sample.md`
- `ButtonGroup` — papel: principal (grupo de abas) — ver `button.sample.md`
- `Button` — papel: composição (aba individual) — ver `button.sample.md`

## Recursos visuais

- `border-b border-light-200` — linha separadora entre tabs e conteúdo
- `Button.Active` — aba selecionada visualmente
- `Button.Outline` — abas não selecionadas com borda

## Receita

`ButtonGroup` na `Bar` com `Active/Outline` por aba; `@switch` renderiza o painel correspondente.

```razor
@code {
    private string abaAtiva = "perfil";
}

@* Tabs inline com conteúdo gerenciado por C# *@
<Bar AdditionalClasses="border-b border-light-200 mb-4">
    <StartContent>
        <ButtonGroup Style="Themes.Default">
            @foreach (var (id, label) in new[] {
                ("perfil", "Perfil"),
                ("seguranca", "Segurança"),
                ("notificacoes", "Notificações")
            })
            {
                <Button Label="@label"
                        Active="@(abaAtiva == id)"
                        Outline="@(abaAtiva != id)"
                        OnClick="() => abaAtiva = id" />
            }
        </ButtonGroup>
    </StartContent>
</Bar>

@* Painel de conteúdo da aba ativa *@
@switch (abaAtiva)
{
    case "perfil":
        <div>@* conteúdo de Perfil *@</div>
        break;
    case "seguranca":
        <div>@* conteúdo de Segurança *@</div>
        break;
    case "notificacoes":
        <div>@* conteúdo de Notificações *@</div>
        break;
}

@* Tabs como navegação de rota — usar NavLink diretamente *@
<Bar AdditionalClasses="border-b border-light-200 mb-4">
    <StartContent>
        <NavLink href="/configuracoes/perfil"
                 class="px-4 py-2 text-sm text-dark-500 border-b-2 border-transparent
                        hover:text-dark-700 transition-colors"
                 ActiveClass="border-primary-500 text-primary-700 font-medium">
            Perfil
        </NavLink>
        <NavLink href="/configuracoes/seguranca"
                 class="px-4 py-2 text-sm text-dark-500 border-b-2 border-transparent
                        hover:text-dark-700 transition-colors"
                 ActiveClass="border-primary-500 text-primary-700 font-medium">
            Segurança
        </NavLink>
    </StartContent>
</Bar>
```

## Limites

- O visual de aba ativa usa preenchimento (`ButtonGroup Active`), não underline — para underline, usar `NavLink` com `border-b-2 border-primary-500` CSS manual (ver variante de rota acima);
- Tabs com scroll horizontal (quando muitas abas) requer `overflow-x-auto` no container.
