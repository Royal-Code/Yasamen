# UIP-STRUCT-SCROLLABLE_REGION - Blueprint

## Identificação
- **Pattern**: UIP-STRUCT-SCROLLABLE_REGION - Scrollable Region.
- **Nível final**: resumido.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_struct.pattern.md`, samples de `Box`, `Stack`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen não possui componente de região rolável, mas classes utilitárias e `Box` permitem compor scroll local. O gap é definir altura, estados e limites de uso.

## Decisão arquitetural principal
Criar `[API proposta] ScrollableRegion` com `Header`, `Footer`, `Loading`, `EndReached`, `Error` e `ChildContent`, usando CSS de overflow confirmado por utilitários.

## Componentes reaproveitados
`Box` delimita a região, `Stack` organiza conteúdo, `Feedback` representa empty/loading/error e `Button` pode carregar mais.

## Bloco principal de código

```razor
@* [API proposta] ScrollableRegion *@
<Box AdditionalClasses="bg-white border border-light-300 rounded-md overflow-hidden">
    @if (Header is not null)
    {
        <div class="p-4 border-b border-light-300">@Header</div>
    }
    <div class="max-h-[32rem] overflow-y-auto p-4">
        @if (Loading)
        {
            <Feedback Style="Themes.Info" Text="Carregando conteúdo..." Block="true" />
        }
        else
        {
            @ChildContent
        }
    </div>
    @if (Footer is not null)
    {
        <div class="p-4 border-t border-light-300">@Footer</div>
    }
</Box>
```

## Exemplo principal de uso
Usar em inbox, feed, lista lateral, conversa e painel secundário com altura definida pelo shell.

## Justificativa breve da cobertura proposta
A cobertura sobe porque o blueprint fixa as regras de altura, overflow e estados, sem inventar componente nativo.

## Limitações remanescentes
- Não há callback nativo de fim de scroll.
- Virtualização e infinite scroll dependem do app.

## Pontos de adaptação
- Definir altura por contexto, não por chute.
- Evitar múltiplas regiões roláveis competindo na mesma tela.
