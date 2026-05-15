# SHP-STUDIO_WORKBENCH - Blueprint

## Identificação
- **Pattern**: SHP-STUDIO_WORKBENCH - Studio/Workbench.
- **Nível final**: completo.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `AppLayout`, `AppSideBar`, `Bar`, `ButtonGroup`, `IconButton`, `OffCanvas`, `Container`, `Slot`, `Box`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen tem shell, toolbar, sidebars e offcanvas suficientes para o contorno de um workbench, mas não oferece superfície de edição, inspector, layers ou ferramentas de criação. O blueprint propõe uma composição de workbench com topbar de ferramentas, painel esquerdo, superfície central e inspector direito, mantendo o editor/canvas como integração do app.

## Requisitos ainda não atendidos
- Área central de criação ou edição.
- Ferramentas persistentes e estado de seleção.
- Inspector/propriedades do item selecionado.
- Painel de assets/layers.
- Responsividade que preserva a superfície principal.

## Diagnóstico estruturado do gap
`AppLayout`, `AppSideBar`, `Bar`, `ButtonGroup` e `IconButton` cobrem shell e ações. `OffCanvas` ajuda no mobile. Falta contrato para superfície principal, seleção, painel de propriedades e ferramentas. Como canvas/editor é especializado, a peça central deve ser slot/integrável.

## Justificativa detalhada da meta
Com uma estrutura `[API proposta] WorkbenchShell`, Yasamen pode cobrir 8 do shell de studio: zonas, hierarquia, toolbar, inspector e responsividade. A cobertura não deve prometer edição rica, drag/drop ou canvas nativo.

## Estratégia de composição
- `AppLayout` para topbar, main e sidebars.
- `Bar` com `ButtonGroup` e `IconButton` para toolbar.
- `Box` para painéis e inspector.
- `OffCanvas` para inspector em mobile.
- `Feedback` para empty selection.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] WorkbenchShell`: Toolbar, AssetsPanel, Surface, Inspector, StatusBar.
- `[API proposta] ToolButton`: ícone, label acessível, active, disabled.
- `[API proposta] InspectorPanel`: selectedItem, sections, save/reset.
- `[API proposta] WorkSurface`: slot externo para editor/canvas.

## Aplicação objetiva da linguagem visual
O workbench deve ser mais denso que portal, mas ainda claro: painéis brancos, bordas `light-300`, toolbar neutra, seleção com `primary-100` e borda `primary-500/50`. Ferramenta ativa usa `IconButton Active=true`.

## Aplicação de estilos e tokens
Topbar fica em `z-app-bar`; offcanvas usa camadas existentes. Evitar sombras pesadas entre painéis; bordas finas e superfícies claras bastam. Usar `Sizes.Small` em toolbars.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] WorkbenchShell *@
<AppLayout AdditionalMainClasses="p-0 bg-light-100">
    <TopStart><strong>Editor</strong></TopStart>
    <TopCenter>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ferramentas">
            <IconButton Icon="BsIconNames.Pencil" Active="@(tool == "draw")" />
            <IconButton Icon="BsIconNames.Search" Active="@(tool == "inspect")" />
        </ButtonGroup>
    </TopCenter>
    <TopEnd>
        <Button Label="Salvar" Style="Themes.Primary" Size="Sizes.Small" />
    </TopEnd>
    <LeftMenu>
        <Box AdditionalClasses="h-full bg-white border-r border-light-300 rounded-none p-4">
            @AssetsPanel
        </Box>
    </LeftMenu>
    <RightMenu>
        <Box AdditionalClasses="h-full bg-white border-l border-light-300 rounded-none p-4">
            @Inspector
        </Box>
    </RightMenu>
    <Main>
        <div class="h-full min-h-[calc(100vh-4rem)] bg-light-100">
            @Surface
        </div>
    </Main>
</AppLayout>
```

## Blocos principais de código

```razor
@* [API proposta] InspectorPanel *@
<Stack AdditionalClasses="space-y-4">
    @if (SelectedItem is null)
    {
        <Feedback Style="Themes.Info" Title="Nada selecionado" Text="Selecione um item para editar propriedades." Block="true" />
    }
    else
    {
        <TextField Label="Nome" @bind-Value="SelectedItem.Name" />
        <TextField Label="Descrição" @bind-Value="SelectedItem.Description" />
        <ButtonGroup AriaLabel="Ações do inspetor" Size="Sizes.Small">
            <Button Label="Aplicar" Style="Themes.Primary" />
            <Button Label="Restaurar" Style="Themes.Light" />
        </ButtonGroup>
    }
</Stack>
```

## Estados e comportamento responsivo
- Desktop: assets, superfície e inspector simultâneos.
- Tablet: inspector pode virar `OffCanvas`.
- Mobile: superfície mantém foco; assets e inspector abrem sob demanda.
- Empty selection: `Feedback Info`.
- Unsaved changes: `Badge Warning` ou `Feedback Warning` no status bar proposto.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<WorkbenchShell Tool="@tool"
                SelectedItem="@selected"
                OnToolChanged="SetTool">
    <Surface>
        <MyCanvasComponent SelectedItem="@selected" />
    </Surface>
</WorkbenchShell>
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Shell | forte para app | workbench especializado |
| Toolbar | manual com botões | contrato de ferramentas |
| Surface | ausente | slot externo |
| Inspector | manual | painel proposto |
| Mobile | offcanvas disponível | regra de colapso definida |

## Limitações remanescentes
- Canvas, drag/drop, zoom e seleção não são fornecidos.
- Undo/redo precisa camada de estado do app destino.
- Atalhos de teclado não são definidos por Yasamen.

## Pontos de adaptação
- Integrar superfície real do domínio.
- Definir modelo de ferramentas e seleção.
- Escolher quais painéis permanecem fixos em desktop e quais viram offcanvas.
