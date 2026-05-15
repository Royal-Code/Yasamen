# UIP-NAV-TABS - Blueprint

## Identificação
- **Pattern**: UIP-NAV-TABS - Tabs.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_nav.pattern.md`, samples de `ButtonGroup`, `Button`, `Badge`, `Box`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen só simula tabs com `ButtonGroup`; não há semântica, painéis, teclado ou estado de erro por aba. O blueprint propõe `Tabs` e `TabPanel` como `[API proposta]`.

## Requisitos ainda não atendidos
- Lista de tabs com estado ativo.
- Painéis associados.
- Badges/erro por tab.
- Keyboard navigation e aria.
- Scroll horizontal mobile.

## Diagnóstico estruturado do gap
`ButtonGroup` resolve alternância visual, mas não expressa `role=tablist`, `role=tab` e `role=tabpanel`. A proposta preserva o visual e adiciona contrato semântico.

## Justificativa detalhada da meta
Com tabs propostas, cobertura 8 é plausível. Acessibilidade completa depende de implementação de teclado no app ou componente futuro.

## Estratégia de composição
- `ButtonGroup` como base visual.
- `Button Active` para tab ativa.
- `Badge` dentro do label quando houver contagem.
- `Box` para painel.
- `Feedback` para erro/empty da tab.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] Tabs`: Items, ActiveId, OnActiveChanged.
- `[API proposta] TabItem`: Id, Label, Badge, Disabled, HasError.
- `[API proposta] TabPanel`: ActiveId, ChildContent.

## Aplicação objetiva da linguagem visual
Tab ativa deve usar `Active=true` e tema `Primary` ou destaque de borda. Tabs inativas ficam neutras; erro usa `Badge Danger`.

## Aplicação de estilos e tokens
Em mobile, usar `overflow-x-auto` e manter tabs visíveis. Não esconder em menu sem alternativa explícita.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] Tabs *@
<div>
    <div role="tablist" class="overflow-x-auto">
        <ButtonGroup AriaLabel="@AriaLabel" Size="Sizes.Small">
            @foreach (var tab in Items)
            {
                <Button Label="@tab.Label"
                        Active="@(tab.Id == ActiveId)"
                        Disabled="@tab.Disabled"
                        OnClick="@(_ => Activate(tab.Id))" />
            }
        </ButtonGroup>
    </div>
    <Box AdditionalClasses="mt-4 p-6 bg-white border border-light-300 rounded-md" role="tabpanel">
        @ActivePanel
    </Box>
</div>
```

## Blocos principais de código

```razor
@* [API proposta] tab com erro/contagem *@
<Button Active="@IsActive" OnClick="Activate">
    <span class="inline-flex items-center gap-2">
        @Label
        @if (Count is not null)
        {
            <Badge Text="@Count.ToString()" Style="Themes.Secondary" Size="Sizes.Small" />
        }
        @if (HasError)
        {
            <Badge Text="!" Style="Themes.Danger" Size="Sizes.Small" />
        }
    </span>
</Button>
```

## Estados e comportamento responsivo
- Desktop: tabbar horizontal.
- Mobile: scroll horizontal; muitas tabs podem usar selector proposto.
- Loading: conteúdo da tab ativa em loading.
- Error: sinalizar tab e painel.
- Disabled: tab visível, mas não acionável.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<Tabs Items="settingsTabs" ActiveId="@activeTab" OnActiveChanged="SetTab">
    <TabPanel Id="profile">...</TabPanel>
    <TabPanel Id="security">...</TabPanel>
</Tabs>
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Visual | `ButtonGroup` | mantido |
| Semântica | ausente | roles propostos |
| Painel | manual | `TabPanel` |
| Mobile | manual | scroll definido |

## Limitações remanescentes
- Keyboard navigation precisa implementação.
- Deep link por tab depende do app.

## Pontos de adaptação
- Usar tabs apenas para vistas irmãs.
- Evitar tabs em fluxos sequenciais; usar stepper.
