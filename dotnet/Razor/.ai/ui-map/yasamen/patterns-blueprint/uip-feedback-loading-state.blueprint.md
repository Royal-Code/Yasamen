# UIP-FEEDBACK-LOADING_STATE - Blueprint

## Identificação
- **Pattern**: UIP-FEEDBACK-LOADING_STATE - Loading State.
- **Nível final**: completo.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_feedback.pattern.md`, samples de `Pagination`, `Button`, `RotationMotion`, `Icon`, `Feedback`, `NotificationAnimation`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen tem loading em `Pagination`, disabled em botões e `RotationMotion`, mas não possui skeleton ou estratégia consistente. O blueprint define loading por ação, bloco, lista e página.

## Requisitos ainda não atendidos
- Loading inicial de página.
- Loading de bloco/painel.
- Loading de ação.
- Skeleton de lista/card.
- Progressivo em scroll/pagination.

## Diagnóstico estruturado do gap
`Pagination Loading=true` já existe. `Button Disabled` e `Feedback Info` ajudam. `RotationMotion` permite spinner. Skeleton precisa ser composição CSS proposta.

## Justificativa detalhada da meta
A cobertura 8 é possível com regras de aplicação e peças propostas. Não chega a 9 porque skeleton não é componente nativo.

## Estratégia de composição
- Ação: desabilitar `Button`/`IconButton` e mudar label.
- Lista: skeleton proposto ou `Feedback Info`.
- Painel: `Feedback Info` localizado.
- Paginação: usar `Loading=true`.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] LoadingBlock`: Title, Size, Kind.
- `[API proposta] SkeletonLine` e `[API proposta] SkeletonCard`.
- `[API proposta] LoadingAction`: envolve botão com estado.

## Aplicação objetiva da linguagem visual
Loading deve ser discreto, com `light-100/200`, sem cor semântica forte. Use `Info` apenas para mensagem textual de espera.

## Aplicação de estilos e tokens
Skeleton usa `bg-light-200`, `rounded-md`, `animate-pulse` se disponível no Tailwind bundle. Se `animate-pulse` não estiver disponível no destino, usar bloco estático.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] LoadingBlock *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-3">
    <div class="h-4 w-1/3 bg-light-200 rounded-md"></div>
    <div class="h-3 w-full bg-light-200 rounded-md"></div>
    <div class="h-3 w-5/6 bg-light-200 rounded-md"></div>
</Box>
```

## Blocos principais de código

```razor
@* loading já suportado pela Pagination *@
<Pagination CurrentPage="@page"
            TotalPages="@totalPages"
            Loading="@loading"
            OnPageChanged="ChangePage" />

@* ação em progresso *@
<Button Label="Salvando..."
        Style="Themes.Primary"
        Disabled="true" />
```

## Estados e comportamento responsivo
- Página: skeleton das zonas principais.
- Painel: skeleton local.
- Ação: botão disabled.
- Lista progressiva: indicador no final.
- Mobile: preservar altura mínima para evitar salto.

## Exemplo principal de uso

```razor
@if (loading)
{
    <LoadingBlock />
}
else
{
    @Content
}
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Pagination | forte | mantido |
| Botão | disabled | padrão de ação |
| Skeleton | ausente | proposto |
| Bloco | manual | `LoadingBlock` |

## Limitações remanescentes
- Skeleton é CSS proposto.
- Não há progress bar nativa.

## Pontos de adaptação
- Preferir loading local ao bloqueio global.
- Usar altura estável para evitar layout shift.
