# UIP-ACTION-COMMAND_PALETTE - Command Palette

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de command palette. Requer composição manual com Modal + FieldText + lógica de busca/filtro no app.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Modal
- `cobertura`: overlay de tela cheia ou centrado que cobre o conteúdo da página; abre/fecha programaticamente via `ModalService`; foco controlado dentro do Modal; `Esc` fecha;
- `limitações`: sem atalho de teclado global nativo (Ctrl+K) — requer `@onkeydown` no document via JS interop;
- `nota`: 6;
- `justificativa`: container overlay correto para command palette — fecha com Esc, controla foco.

2. FieldText
- `cobertura`: campo de entrada para filtro de comandos; `Placeholder`, `Value`, `OnInput/OnChange` para filtro reativo; auto-foco via `@ref` + JS call após abertura;
- `nota`: 7;
- `justificativa`: campo de busca principal da paleta — filtra comandos em tempo real.

3. Button / IconButton
- `cobertura`: itens de resultado como botões clicáveis; `Style=Themes.Default` para item neutro; destaque do item selecionado via `Active=true` ou CSS;
- `nota`: 5;
- `justificativa`: item de resultado executável — sem abstração de lista de comandos nativa.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `atalho global (Ctrl+K / Cmd+K)`: não nativo — requer JS interop com `document.addEventListener('keydown', ...)`;
  - `fuzzy matching`: lógica de filtro no app C# — sem componente de busca fuzzy;
  - `histórico de comandos recentes`: persistência no app (localStorage via JS interop ou estado de sessão);
  - `navegação por teclado na lista (↑↓ Enter)`: não nativo no Modal — requer `@onkeydown` no campo + índice selecionado em estado C#;
  - `categorias e grupos de comandos`: composição manual com títulos de seção HTML entre grupos de resultados.

- `tipo de adaptação`: composição + lógica de app
- `o que precisa ser feito`:
  - `Modal` como container overlay com `FieldText` no topo e lista de resultados abaixo;
  - Filtro de comandos em C# (`IEnumerable.Where()`) + renderização condicional da lista;
  - JS interop para atalho global e foco automático no `FieldText`;
  - Navegação por teclado na lista via estado `indiceAtivo` + `@onkeydown`.

## Como usar

### Command palette básica (composição manual)

```razor
@inject ModalService ModalService
@inject IJSRuntime JS

@code {
    private string filtro = "";
    private int indiceAtivo = 0;
    private List<CommandItem> todos = [
        new("Novo usuário", WellKnownIcons.UserAdd, "/usuarios/novo"),
        new("Relatório mensal", WellKnownIcons.Chart, "/relatorios/mensal"),
        new("Configurações", WellKnownIcons.Settings, "/config"),
        new("Exportar dados", WellKnownIcons.Export, null, ExportarDados),
    ];

    private IEnumerable<CommandItem> Filtrados =>
        string.IsNullOrWhiteSpace(filtro)
            ? todos
            : todos.Where(c => c.Label.Contains(filtro, StringComparison.OrdinalIgnoreCase));

    private async Task AbrirPaleta()
    {
        filtro = "";
        indiceAtivo = 0;
        await ModalService.OpenAsync("command-palette");
    }

    private async Task ExecutarItem(CommandItem item)
    {
        await ModalService.CloseAsync("command-palette");
        if (item.Url is not null)
            Navigation.NavigateTo(item.Url);
        else
            await item.Acao!.Invoke();
    }
}

@* Trigger: botão visível ou atalho via JS interop *@
<Button Style="Themes.Secondary" Outline=true Label="Buscar comandos..."
        AdditionalClasses="text-dark-400 font-normal w-64"
        Icon="WellKnownIcons.Search" OnClick="AbrirPaleta" />

<Modal Id="command-palette" Title="" HideHeader=true
       AdditionalClasses="max-w-lg w-full mt-24">
    <ChildContent>
        <div class="p-2 border-b border-light-200">
            <TextField @bind-Value="filtro" Placeholder="Buscar comandos..."
                       AdditionalClasses="w-full" autofocus />
        </div>
        <div class="max-h-64 overflow-y-auto py-1">
            @{var lista = Filtrados.ToList();}
            @if (lista.Count == 0)
            {
                <p class="text-sm text-dark-400 text-center py-6">Nenhum resultado para "@filtro"</p>
            }
            else
            {
                @for (int i = 0; i < lista.Count; i++)
                {
                    var item = lista[i];
                    var idx = i;
                    <button class="w-full flex items-center gap-3 px-4 py-2 text-sm text-left
                                   hover:bg-light-100 @(idx == indiceAtivo ? "bg-primary-50" : "")"
                            @onclick="() => ExecutarItem(item)"
                            @onmouseenter="() => indiceAtivo = idx">
                        @item.Icon("text-base text-dark-400")
                        <span>@item.Label</span>
                    </button>
                }
            }
        </div>
    </ChildContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de command palette nativo; atalho global requer JS interop; fuzzy matching é responsabilidade do app; navegação por teclado na lista requer estado manual; sem histórico, categorias ou atalhos visuais nativos;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `Modal` + `FieldText` + lista de `Button` formam uma command palette funcional mas completamente manual;
  - Nota 2 reflete que a lib fornece apenas primitivos genéricos — toda lógica de paleta é do app;
  - Adequado apenas para apps tipo admin/workbench com usuários avançados; incomum em apps CRUD padrão.
