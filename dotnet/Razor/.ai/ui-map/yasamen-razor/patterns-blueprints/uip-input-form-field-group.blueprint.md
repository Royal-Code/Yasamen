# UIP-INPUT-FORM_FIELD_GROUP - Blueprint resumido

## Pattern

UIP-INPUT-FORM_FIELD_GROUP — Form Field Group — ver `uip-input-form-field-group.ui-map.md`

## Gap coberto

A lib não tem `FormGroup` ou `Fieldset` component. O gap é orientar a composição de seções de formulário com título, help text, layout de 1 e 2 colunas, e campos dependentes.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Stack(Gap.Medium)` para layout vertical de campos; `Box(BorderBuilder.Box)` para delimitação visual de seção; heading HTML com classes Tailwind para título e help text; grid CSS para 2 colunas.

## Componentes usados

- `Stack` — papel: principal (layout de campos) — ver `bar.sample.md`
- `Box` — papel: composição (seção delimitada) — ver `box.sample.md`
- `Bar` — papel: composição (rodapé de ações) — ver `bar.sample.md`

## Recursos visuais

- `text-sm font-semibold text-dark-700` — título de seção
- `text-xs text-dark-400` — help text de seção
- `flex flex-col gap-6` — espaçamento entre seções
- `grid grid-cols-1 sm:grid-cols-2 gap-4` — layout 2 colunas responsivo

## Receita

Seções de formulário com `Stack` para campos; `Box` para delimitação visual; grid CSS para 2 colunas.

```razor
<EditForm Model="@model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    <div class="flex flex-col gap-6">
        @* Seção simples com título e help text *@
        <div>
            <p class="text-sm font-semibold text-dark-700 mb-1">Dados pessoais</p>
            <p class="text-xs text-dark-400 mb-4">Informações de identificação do usuário.</p>
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="model.Nome" Label="Nome completo" required />
                <TextField @bind-Value="model.Email" Label="E-mail" required />
                <TextField @bind-Value="model.Telefone" Label="Telefone" />
            </Stack>
        </div>

        @* Seção com Box delimitador *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-sm font-semibold text-dark-700 mb-4">Configurações</p>
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="model.EmailNotificacao" Label="E-mail de notificação" />
                <TextField @bind-Value="model.Webhook" Label="URL de Webhook" />
            </Stack>
        </Box>

        @* Seção 2 colunas (grid responsivo) *@
        <div>
            <p class="text-sm font-semibold text-dark-700 mb-4">Endereço</p>
            <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                <TextField @bind-Value="model.Cep" Label="CEP" required />
                <TextField @bind-Value="model.Cidade" Label="Cidade" required />
                <TextField @bind-Value="model.Estado" Label="Estado" />
                <TextField @bind-Value="model.Logradouro" Label="Logradouro" />
            </div>
        </div>
    </div>

    <Bar AdditionalClasses="mt-6">
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Label="Cancelar" OnClick="Cancelar" />
            <Button Style="Themes.Primary" Label="Salvar" Loading="@salvando" />
        </EndContent>
    </Bar>
</EditForm>
```

## Limites

- Sem `FormGroup` ou `Fieldset` com semântica HTML nativa estilizada — heading manual não é equivalente semântico de `<legend>`;
- Validação de formulário por `DataAnnotationsValidator` funciona normalmente independente do container de seção;
- Campos dependentes (`@if` por valor de outro campo) requerem lógica C# manual no componente pai.
