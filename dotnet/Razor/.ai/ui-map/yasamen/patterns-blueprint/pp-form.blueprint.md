# PP-FORM - Blueprint

## Identificação
- **Pattern**: PP-FORM.
- **Nível final**: resumido.
- **Cobertura atual**: 7.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `TextField`, `FieldText`, `FieldBadge`, `FieldAction`, `Container`, `Slot`, `Button`, `ButtonGroup`, `Feedback`, `Notification`, `Modal`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen cobre bem campo textual, ações e feedback, mas não possui formulário completo com convenção de seções, validação agregada, resumo de erro e controles não textuais. A lacuna é mais de composição do que de shell.

## Decisão arquitetural principal
Usar `EditForm` do Blazor como contrato real e criar `[API proposta] FormPageLayout` apenas para padronizar seções, action bar, feedback e grid responsivo.

## Componentes reaproveitados
- `TextField`, `FieldText`, `FieldBadge`, `FieldAction`: entrada textual e complementos.
- `Container` e `Slot`: colunas responsivas.
- `ButtonGroup` e `Button`: ações primária/secundária.
- `Feedback`: erro geral e instrução.
- `Notification`/`Notify`: confirmação após salvar.
- `Modal`: confirmação quando houver perda de alterações.

## Peça proposta
`[API proposta] FormPageLayout` com `Header`, `Sections`, `Actions`, `ErrorSummary`, `IsSaving` e `IsDirty`.

## Bloco principal de código

```razor
@* [API proposta] layout de formulário usando EditForm real *@
<EditForm Model="Model" OnValidSubmit="SaveAsync">
    <Stack AdditionalClasses="space-y-6">
        @if (!string.IsNullOrWhiteSpace(ErrorSummary))
        {
            <Feedback Style="Themes.Danger" Title="Revise os campos" Text="@ErrorSummary" Block="true" />
        }

        <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
            <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default">
                <Slot Span="4" LaptopSpan="6">
                    <TextField Label="Nome" @bind-Value="Model.Name" Error="@NameError" />
                </Slot>
                <Slot Span="4" LaptopSpan="6">
                    <TextField Label="E-mail" @bind-Value="Model.Email" Information="Usado para contato." />
                </Slot>
            </Container>
        </Box>

        <ButtonGroup AriaLabel="Ações do formulário">
            <Button Label="Salvar" Type="ButtonType.Submit" Style="Themes.Primary" />
            <Button Label="Cancelar" Style="Themes.Light" OnClick="Cancel" />
        </ButtonGroup>
    </Stack>
</EditForm>
```

## Exemplo principal de uso
Use para cadastro, edição simples e confirmação de dados em uma etapa. Quando a validação depender de etapas sequenciais, migrar para `PP-WIZARD`.

## Justificativa breve da cobertura proposta
O blueprint adiciona convenção de página e erro agregado sobre APIs já fortes, elevando a cobertura sem criar controles inexistentes. A lacuna de selects, checkboxes e date picker permanece explícita.

## Limitações remanescentes
- Controles não textuais precisam componentes externos ou novas peças.
- Validação e mensagens dependem do app.
- Dirty state é proposto, não nativo.

## Pontos de adaptação
- Definir modelo e validação do domínio.
- Decidir quando exibir confirmação de abandono.
- Usar `Themes.Danger` para erros e `Themes.Success` para confirmação.
