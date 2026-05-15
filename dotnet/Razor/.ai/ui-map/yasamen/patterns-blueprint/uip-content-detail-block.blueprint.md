# UIP-CONTENT-DETAIL_BLOCK - Blueprint

## Identificação
- **Pattern**: UIP-CONTENT-DETAIL_BLOCK - Detail Block.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_content.pattern.md`, samples de `Box`, `Stack`, `Badge`, `ButtonGroup`, `Button`, `Breadcrumb`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen compõe detalhe com `Box` e `Badge`, mas não define pares label/valor, grupos e ação de edição por seção.

## Decisão arquitetural principal
Criar `[API proposta] DetailBlock` e `[API proposta] DetailItem`.

## Componentes reaproveitados
`Box`, `Stack`, `Badge`, `ButtonGroup`, `Button`.

## Bloco principal de código

```razor
@* [API proposta] DetailBlock *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">@Title</h2></Start>
        <End>@Actions</End>
    </Bar>
    <dl class="grid grid-cols-1 md:grid-cols-2 gap-4">
        @ChildContent
    </dl>
</Box>

@* [API proposta] DetailItem *@
<div>
    <dt class="text-sm text-dark-500">@Label</dt>
    <dd class="font-medium text-dark-900">@Value</dd>
</div>
```

## Exemplo principal de uso
Use em detail page, painel de list-detail e resumo de entidade.

## Justificativa breve da cobertura proposta
O blueprint formaliza leitura estruturada e mantém a estética Yasamen.

## Limitações remanescentes
- Skeleton e inline edit dependem de blueprints próprios.
- Dados complexos podem precisar tabela.

## Pontos de adaptação
- Agrupar atributos por seção lógica.
- Em mobile, manter label e valor em coluna.
