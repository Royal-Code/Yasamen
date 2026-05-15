# UIP-DATA-LIST_ITEM - Blueprint

## Identificação
- **Pattern**: UIP-DATA-LIST_ITEM - List Item.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_data.pattern.md`, samples de `Box`, `Badge`, `IconButton`, `DropIconButton`, `DropItem`, `Button`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen permite montar item com `Box`, `Badge` e ações, mas não define slots para título, subtítulo, metadado, estado ativo e overflow.

## Decisão arquitetural principal
Criar `[API proposta] ListItem` como leaf composicional com `Title`, `Subtitle`, `Meta`, `Status`, `Actions`, `Active`, `Disabled`.

## Componentes reaproveitados
`Box` para superfície, `Badge` para status, `DropIconButton` para ações secundárias e `IconButton` para ação compacta visível.

## Bloco principal de código

```razor
@* [API proposta] ListItem *@
<Box AdditionalClasses="@Classes">
    <div class="flex items-center justify-between gap-4">
        <div class="min-w-0">
            <div class="font-medium text-dark-900 truncate">@Title</div>
            <div class="text-sm text-dark-500 truncate">@Subtitle</div>
        </div>
        <div class="flex items-center gap-3">
            @if (!string.IsNullOrWhiteSpace(Status))
            {
                <Badge Text="@Status" Style="@StatusTheme" Size="Sizes.Small" />
            }
            <DropIconButton Icon="BsIconNames.ThreeDots">@Actions</DropIconButton>
        </div>
    </div>
</Box>
```

## Exemplo principal de uso
Use em resultados simples, listas de navegação, listas de detalhe e itens de feed que não exigem cronologia forte.

## Justificativa breve da cobertura proposta
O blueprint formaliza slots e estados sobre componentes existentes. Não tenta substituir tabela em cenários comparativos.

## Limitações remanescentes
- Skeleton de item não é nativo.
- Seleção múltipla precisa componente de tabela/lista maior.

## Pontos de adaptação
- Usar `Active` apenas quando há seleção real.
- Não colocar muitas badges no mesmo item.
