# UIP-ACTION-CONTEXTUAL_MENU - Contextual Menu

## Componentes

**Principais**:

1. DropIconButton
- `cobertura`: trigger de ícone (ellipsis/kebab) que abre dropdown de ações locais por item; `DropItem` por ação com `Label`, `OnClick`, `Style`, `Disabled`; separação de grupos via HTML `<hr>` dentro do dropdown; ações destrutivas com `Style=Themes.Danger` no DropItem; posicionamento automático do dropdown relativo ao botão; fecha ao clicar fora;
- `limitações`: sem menu de clique secundário (right-click); sem agrupamento nativo de itens (apenas separador HTML); sem submenu nativo;
- `nota`: 9;
- `justificativa`: cobertura nativa completa do overflow menu por item — trigger de ícone + dropdown + ações com variantes de estado e tema.

2. DropButton
- `cobertura`: variante com label + dropdown; útil quando o item precisa de label visível além do ícone; combina ação primária visível (label) com ações secundárias no dropdown;
- `nota`: 8;
- `justificativa`: alternativa ao DropIconButton quando a ação primária deve ficar visível.

**Composição**:

1. DropItem
- `cobertura`: item de ação individual no dropdown; `Label`, `Icon`, `OnClick`, `Style`, `Disabled`; `Style=Themes.Danger` para destrutivas;
- `nota`: 9;
- `justificativa`: leaf de ação contextual com semântica completa.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `menu de clique secundário (right-click)`: não suportado — apenas botão explícito;
  - `agrupamento semântico de itens`: sem grupos nativos — usar `<hr class="my-1 border-light-200">` entre itens para separação visual;
  - `submenu / menu hierárquico`: não suportado — nivelar ações ou usar Modal para seleção aninhada;
  - `adaptação mobile como bottom sheet`: não automático — DropIconButton permanece dropdown também em mobile.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Colocar `DropIconButton` com ícone de overflow (ellipsis/kebab) na célula de ações de cada item;
  - `DropItem` por ação com estado e tema corretos;
  - Ações destrutivas no final do dropdown separadas por `<hr>` e com `Style=Themes.Danger`.

## Como usar

### Menu contextual por linha de tabela

```razor
<DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default" Size="Sizes.Small">
    <DropItem Label="Visualizar" Icon="WellKnownIcons.Eye" OnClick="() => Visualizar(item.Id)" />
    <DropItem Label="Editar" Icon="WellKnownIcons.Edit" OnClick="() => Editar(item.Id)" />
    <DropItem Label="Duplicar" Icon="WellKnownIcons.Copy" OnClick="() => Duplicar(item.Id)" />
    <hr class="my-1 border-light-200" />
    <DropItem Label="Excluir" Icon="WellKnownIcons.Trash" Style="Themes.Danger"
              OnClick="() => ConfirmarExclusao(item.Id)" />
</DropIconButton>
```

### Menu contextual com ações condicionais

```razor
<DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default">
    <DropItem Label="Editar" OnClick="() => Editar(item.Id)"
              Disabled="@(!item.Editavel)" />
    @if (item.Status == StatusEnum.Rascunho)
    {
        <DropItem Label="Publicar" Icon="WellKnownIcons.Check"
                  Style="Themes.Success" OnClick="() => Publicar(item.Id)" />
    }
    @if (item.Status == StatusEnum.Publicado)
    {
        <DropItem Label="Arquivar" OnClick="() => Arquivar(item.Id)" />
    }
    <hr class="my-1 border-light-200" />
    <DropItem Label="Excluir" Style="Themes.Danger"
              Disabled="@(!item.Excluivel)"
              OnClick="() => ConfirmarExclusao(item.Id)" />
</DropIconButton>
```

### Menu em card (DropButton com ação primária)

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar>
        <StartContent>
            <span class="font-semibold">@item.Nome</span>
        </StartContent>
        <EndContent>
            <DropButton Label="Ações" Style="Themes.Secondary" Outline=true>
                <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                <DropItem Label="Compartilhar" OnClick="() => Compartilhar(item.Id)" />
                <hr class="my-1 border-light-200" />
                <DropItem Label="Remover" Style="Themes.Danger"
                          OnClick="() => Remover(item.Id)" />
            </DropButton>
        </EndContent>
    </Bar>
</Box>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: sem right-click nativo; sem agrupamento semântico de itens (apenas separador visual HTML); sem submenu; dropdown permanece dropdown em mobile (sem adaptação para bottom sheet automática);
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `DropIconButton` + `DropItem` cobrem nativamente o padrão de menu contextual por item;
  - API simples e direta — sem composição manual necessária além dos próprios DropItem;
  - Nota 9 reflete cobertura nativa excelente; limitações são edge cases não críticos para web.
