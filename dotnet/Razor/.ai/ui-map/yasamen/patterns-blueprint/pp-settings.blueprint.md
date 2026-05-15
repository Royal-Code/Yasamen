# PP-SETTINGS - Blueprint

## Identificação
- **Pattern**: PP-SETTINGS.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Stack`, `Box`, `TextField`, `ButtonGroup`, `Button`, `Breadcrumb`, `Feedback`, `Badge`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen fornece campos, seções e ações, mas não define navegação local de configurações, salvamento por seção, dirty state ou feedback persistente de preferências.

## Decisão arquitetural principal
Criar `[API proposta] SettingsPage` com seções estáveis, navegação local opcional e action bar de salvar/restaurar.

## Componentes reaproveitados
- `Stack` e `Box`: seções.
- `TextField`: entradas textuais.
- `ButtonGroup` e `Button`: salvar/restaurar.
- `Breadcrumb` ou tabs propostas: localização.
- `Feedback`: erro/sucesso local.
- `Badge`: status de alteração.

## Peça proposta
`SettingsPage` expõe `Sections`, `ActiveSection`, `IsDirty`, `OnSave`, `OnReset` e `SaveMode` por página ou por seção.

## Bloco principal de código

```razor
@* [API proposta] SettingsPage *@
<Stack AdditionalClasses="space-y-6">
    <Bar>
        <Start>
            <div>
                <h1 class="text-2xl font-medium text-dark-900">Configurações</h1>
                @if (IsDirty)
                {
                    <Badge Text="Alterações não salvas" Style="Themes.Warning" Size="Sizes.Small" />
                }
            </div>
        </Start>
        <End>
            <ButtonGroup AriaLabel="Ações de configuração" Size="Sizes.Small">
                <Button Label="Salvar" Style="Themes.Primary" OnClick="Save" />
                <Button Label="Restaurar" Style="Themes.Light" OnClick="Reset" />
            </ButtonGroup>
        </End>
    </Bar>

    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
        <h2 class="font-medium text-dark-900">Perfil</h2>
        <TextField Label="Nome público" @bind-Value="Settings.DisplayName" />
        <TextField Label="E-mail de contato" @bind-Value="Settings.Email" />
    </Box>
</Stack>
```

## Exemplo principal de uso
Use para preferências, parâmetros de conta, políticas simples e configurações administrativas. Se as alterações forem sequenciais e dependentes, migrar para `PP-WIZARD`.

## Justificativa breve da cobertura proposta
A proposta adiciona navegação, dirty state e ação de salvamento sobre componentes existentes, cobrindo o essencial do pattern sem prometer controles ausentes.

## Limitações remanescentes
- Tabs reais não existem; usar blueprint de tabs quando necessário.
- Toggle/checkbox/select dependem de componentes externos ou futuros.
- Salvar por seção é contrato do app.

## Pontos de adaptação
- Definir se a página salva tudo ou por seção.
- Definir confirmação para sair com alterações.
- Evitar misturar configurações com operações transacionais longas.
