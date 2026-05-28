# UIP-ACTION-ACTION_BAR - Action Bar

## Componentes

**Principais**:

1. Bar
- `cobertura`: barra horizontal para ações primárias e secundárias; `StartContent`/`EndContent` para posicionamento de grupos; `CenterContent` disponível; border e separação visual entre zonas; papel de barra de cabeçalho de lista, barra de seleção múltipla e barra de ações de detalhe;
- `limitações`: sem comportamento de overflow automático para mobile; sem sticky nativo — requer `AdditionalClasses="sticky top-0"`;
- `nota`: 9;
- `justificativa`: container nativo de barra horizontal com layout Start/Center/End — mapeia diretamente à estrutura de action bar.

2. Button
- `cobertura`: ação primária (`Themes.Primary`), destrutiva (`Themes.Danger`), secundária (`Themes.Secondary Outline=true`); estado `Disabled=true` para ações bloqueadas por permissão ou ausência de seleção; estado `Loading=true` para ação em progresso;
- `nota`: 9;
- `justificativa`: cobertura completa de variantes de ação com feedback visual de estado.

3. ButtonGroup
- `cobertura`: agrupa ações relacionadas em sequência visual unificada; sem separação de margem entre botões do grupo; use para conjunto de 2-4 ações secundárias; combina com `Outline=true`;
- `nota`: 8;
- `justificativa`: agrupamento visual semântico de ações relacionadas sem redundância de estilo.

4. IconButton
- `cobertura`: ação com ícone apenas para ações de baixa descrição (Refresh, Filter, Export); economiza espaço na barra; suporta `Disabled` e `Loading`;
- `nota`: 8;
- `justificativa`: ação compacta para barra com muitos controles.

**Composição**:

1. DropButton / DropIconButton
- `cobertura`: overflow de ações secundárias em dropdown; DropIconButton com ícone de ellipsis/kebab para "mais ações"; DropItem por ação no overflow;
- `nota`: 8;
- `justificativa`: substitui toolbar overflow para ações que não cabem na barra.

2. Box / Badge
- `cobertura`: indicador de contagem de seleção ativa (`Badge Style=Primary`) embutido na barra de seleção múltipla;
- `nota`: 7;
- `justificativa`: feedback visual de quantos itens estão selecionados.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `overflow automático de ações em viewport pequeno`: não automático — decidir explicitamente quais ações migram para DropButton;
  - `barra contextual de seleção múltipla`: sem abstração dedicada — implementar condicionalmente via `@if (temSeleção)` com `Bar` alternativo;
  - `barra fixa no footer (mobile)`: sem sticky bottom nativo — `AdditionalClasses="sticky bottom-0 bg-white border-t z-10"`.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - Usar `Bar` com `StartContent` (label de contexto + Badge de seleção) e `EndContent` (ações primária + secundárias + DropButton overflow);
  - Para seleção múltipla: alternar entre barra normal e barra contextual via estado C#;
  - Ações destrutivas sempre em `Themes.Danger` e separadas das ações neutras.

## Como usar

### Barra de ações da página (lista)

```razor
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <span class="text-sm font-semibold text-dark-600">Usuários</span>
    </StartContent>
    <EndContent>
        <ButtonGroup>
            <Button Style="Themes.Secondary" Outline=true Icon="WellKnownIcons.Filter"
                    Label="Filtrar" OnClick="AbrirFiltros" />
            <Button Style="Themes.Secondary" Outline=true Icon="WellKnownIcons.Export"
                    Label="Exportar" OnClick="Exportar" />
        </ButtonGroup>
        <Button Style="Themes.Primary" Icon="WellKnownIcons.Add"
                Label="Novo Usuário" OnClick="NovoUsuario" />
    </EndContent>
</Bar>
```

### Barra contextual de seleção múltipla

```razor
@if (selecionados.Count > 0)
{
    <Bar AdditionalClasses="mb-4 bg-primary-50 border border-primary-200 rounded-md px-4">
        <StartContent>
            <div class="flex items-center gap-2">
                <Badge Style="Themes.Primary" Text="@selecionados.Count.ToString()" />
                <span class="text-sm text-dark-600">selecionado(s)</span>
            </div>
        </StartContent>
        <EndContent>
            <ButtonGroup>
                <Button Style="Themes.Secondary" Outline=true Label="Exportar"
                        OnClick="ExportarSelecionados" />
                <Button Style="Themes.Secondary" Outline=true Label="Mover"
                        OnClick="MoverSelecionados" />
            </ButtonGroup>
            <Button Style="Themes.Danger" Outline=true Label="Excluir"
                    OnClick="ExcluirSelecionados" />
        </EndContent>
    </Bar>
}
else
{
    <Bar AdditionalClasses="mb-4">
        <EndContent>
            <Button Style="Themes.Primary" Label="Novo" OnClick="Novo" />
        </EndContent>
    </Bar>
}
```

### Barra de ações de detalhe com overflow

```razor
<Bar>
    <StartContent>
        <Breadcrumb>
            <BreadcrumbItem Href="/usuarios" Label="Usuários" />
            <BreadcrumbItem Label="@usuario.Nome" />
        </Breadcrumb>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Editar" OnClick="Editar" />
        <DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Secondary" Outline=true>
            <DropItem Label="Duplicar" OnClick="Duplicar" />
            <DropItem Label="Exportar PDF" OnClick="ExportarPdf" />
            <DropItem Label="Excluir" Style="Themes.Danger" OnClick="ConfirmarExclusao" />
        </DropIconButton>
    </EndContent>
</Bar>
```

### Ações com estado de loading/disabled

```razor
<Bar>
    <EndContent>
        <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                Disabled="@salvando" OnClick="Cancelar" />
        <Button Style="Themes.Primary" Label="Salvar"
                Loading="@salvando" Disabled="@(!formValido)"
                OnClick="Salvar" />
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: overflow de ações não automático — requer DropButton manual; barra contextual de seleção múltipla requer alternância via estado C# explícito; sticky footer mobile requer AdditionalClasses;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Bar` + `Button` + `ButtonGroup` + `IconButton` + `DropButton` cobrem nativamente todos os cenários de action bar;
  - A composição é direta — sem abstração adicional necessária;
  - Nota 9 reflete cobertura nativa completa; a única limitação é overflow não automático.
