# UIP-CONTENT-CONTENT_HEADER - Content Header

## Componentes

**Principais**:

1. Bar
- `cobertura`: linha de cabeçalho com título dominante (`StartContent`) e ações/status (`EndContent`); `CenterContent` disponível; border-bottom para separação da seção abaixo; suporte a `Breadcrumb` como filho de `StartContent`;
- `nota`: 9;
- `justificativa`: container natural de cabeçalho — título + metadados + ações no mesmo eixo horizontal.

**Composição**:

1. Badge
- `cobertura`: status da entidade (`Themes.Success` para ativo, `Themes.Danger` para bloqueado, `Themes.Warning` para pendente, etc.); tags/etiquetas de categorização; contagem de itens associados;
- `nota`: 9;
- `justificativa`: indicadores de estado, categoria e metadado curto.

2. Breadcrumb
- `cobertura`: localização hierárquica da entidade antes do título; links de retorno; nível atual em `BreadcrumbItem`;
- `nota`: 9;
- `justificativa`: contexto de localização acima ou à esquerda do título.

3. Stack
- `cobertura`: empilhamento vertical de título + subtítulo + metadados quando o layout é em coluna (mobile ou header de perfil);
- `nota`: 8;
- `justificativa`: composição vertical de elementos do header.

4. Button / DropIconButton
- `cobertura`: ações contextuais no `EndContent` do `Bar`; ação primária + menu de overflow;
- `nota`: 9;
- `justificativa`: ações da entidade posicionadas no header.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `avatar/imagem da entidade no header`: HTML `<img>` ou div com classe de avatar ao lado do `StartContent`;
  - `métricas curtas no header`: `Badge` ou números em `<span>` com label contextual;
  - `skeleton de loading do header`: usar `RotationMotion` ou div com `animate-pulse` via AdditionalClasses.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - `Bar` com título em `StartContent` e ações em `EndContent`;
  - `Badge` para status e tags; `Breadcrumb` para localização;
  - Empilhar `Breadcrumb` + `Bar` para header completo de entidade.

## Como usar

### Header de entidade simples

```razor
<Stack Gap="Gaps.Small" AdditionalClasses="mb-6">
    <Breadcrumb>
        <BreadcrumbItem Href="/clientes" Label="Clientes" />
        <BreadcrumbItem Label="@cliente.Nome" />
    </Breadcrumb>
    <Bar>
        <StartContent>
            <div class="flex items-center gap-3">
                <div>
                    <h1 class="text-xl font-bold text-dark-600">@cliente.Nome</h1>
                    <span class="text-sm text-dark-400">@cliente.Documento</span>
                </div>
                <Badge Style="@(cliente.Ativo ? Themes.Success : Themes.Danger)"
                       Text="@(cliente.Ativo ? "Ativo" : "Inativo")" />
            </div>
        </StartContent>
        <EndContent>
            <Button Style="Themes.Primary" Label="Editar" OnClick="Editar" />
            <DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default">
                <DropItem Label="Arquivar" OnClick="Arquivar" />
                <DropItem Label="Excluir" Style="Themes.Danger" OnClick="Excluir" />
            </DropIconButton>
        </EndContent>
    </Bar>
</Stack>
```

### Header de seção com tags

```razor
<Bar AdditionalClasses="border-b border-light-200 pb-3 mb-4">
    <StartContent>
        <div class="flex items-center gap-2">
            <h2 class="text-base font-semibold text-dark-600">Pedidos recentes</h2>
            <Badge Style="Themes.Light" Text="@($"{totalPedidos} itens")" />
        </div>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Secondary" Outline=true Label="Ver todos"
                NavigateTo="/pedidos" />
    </EndContent>
</Bar>
```

### Header de perfil com avatar

```razor
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <div class="flex items-center gap-4">
            <div class="w-12 h-12 rounded-full bg-primary-100 flex items-center justify-center">
                <span class="text-lg font-bold text-primary-600">
                    @usuario.Nome.Substring(0, 1).ToUpper()
                </span>
            </div>
            <div>
                <h1 class="text-xl font-bold text-dark-600">@usuario.Nome</h1>
                <span class="text-sm text-dark-400">@usuario.Email</span>
            </div>
            <Badge Style="@GetPerfilTema(usuario.Perfil)" Text="@usuario.Perfil" />
        </div>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Editar perfil" OnClick="EditarPerfil" />
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: sem componente de content header dedicado — composição manual; avatar/imagem requer HTML inline; skeleton de loading requer CSS manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Bar` + `Badge` + `Breadcrumb` cobrem nativamente todas as variantes de content header;
  - Composição direta sem overhead — componentes existentes mapeiam exatamente aos elementos esperados;
  - Nota 8 reflete cobertura nativa excelente com apenas avatar e skeleton sem abstração dedicada.
