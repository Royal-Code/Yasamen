# Yasamen Forms Guide

## Objetivo
Orientar a IA a gerar formulários e campos com os componentes de forms do Yasamen, respeitando binding, validação, slots e estilos esperados.

## Quando usar
Use este guide ao gerar:
- Formulários Blazor com `EditForm`.
- Campos de texto, validação, estado inválido, ajuda contextual ou badges.
- Composição com `Prepend`, `Append`, `DescriptionComplement` ou `FooterAction`.
- Telas CRUD, filtros, cadastro, edição ou busca.

## Decisão corporativa
Formulários Yasamen devem usar os componentes de campo da biblioteca, especialmente `TextField` para texto. A IA deve usar `@bind-Value`, `Label`, `Placeholder`, `Information`, `Error`, `Size`, `ReadOnly`, `Disabled` e slots documentados pela implementação. Quando houver conflito entre comentário de demo e implementação real, a implementação do componente tem precedência.

## Regras
- Use `TextField` para campos de texto em vez de `<input class="...">` manual quando o caso for coberto pelo componente.
- Garanta `AddYasamenCommons()` no app, pois campos dependem de serviços comuns como `FormsJs`.
- Use `@bind-Value` para binding bidirecional; dentro de `EditForm`, o binding também fornece a expressão usada por validação.
- Use `Label` e `Placeholder` para texto visível do campo; não esconda label sem necessidade.
- Use `Information` para ajuda curta abaixo do controle.
- Use `Error` para erro explícito de campo quando a tela já possui mensagem de validação ou falha de operação.
- Use `ReadOnly="true"` para campo consultivo que ainda deve ser legível e `Disabled="true"` para campo indisponível.
- Use `Size="Sizes.Smallest|Smaller|Small|Medium|Large|Larger|Largest"` em vez de inventar classes de tamanho.
- Use `BindEvent="oninput"` quando a tela precisa reagir enquanto o usuário digita; mantenha o padrão quando a atualização no change for suficiente.
- Use `Prepend` para conteúdo antes do controle e `Append` para conteúdo depois do controle.
- Use `DescriptionComplement` com `FieldBadge` para complemento ao lado da descrição/label.
- Use `FooterAction` com `FieldAction` para ação inferior do campo; a implementação de `FieldBase`, `InputFieldBase` e `FieldGroup` suporta esse slot.
- Se uma demo ou comentário contradizer o suporte a `FooterAction`, priorize a implementação atual e registre a divergência se estiver escrevendo documentação.
- Para campos string, saiba que `TextField` converte valor nulo para `string.Empty` e não gera erro de parsing.
- Não misture validação manual e validação do `EditContext` sem motivo; o próprio `FieldBase` atualiza mensagens quando recebe `Error` ou mensagens do `EditContext`.
- Use `FieldBadge Style="Themes.*"` para badges de complemento, não classes cromáticas inventadas.

## Exemplos / Passo-a-passo

### Campo simples

```razor
<TextField Label="Nome"
           @bind-Value="model.Name"
           Placeholder="Digite o nome" />

@code {
    private CustomerModel model = new();

    private sealed class CustomerModel
    {
        public string Name { get; set; } = string.Empty;
    }
}
```

### Campo com informação, erro e tamanho

```razor
<TextField Label="Usuário"
           Size="Sizes.Medium"
           @bind-Value="model.UserName"
           Placeholder="usuario"
           Information="Use apenas letras, números e ponto."
           Error="@userNameError" />

@code {
    private CustomerModel model = new();
    private string? userNameError = "Este usuário já está em uso.";
}
```

### Campo com complemento de descrição

```razor
<TextField Label="Apelido" @bind-Value="model.Nickname">
    <DescriptionComplement>
        <FieldBadge Style="Themes.Info" AdditionalClasses="text-xs">
            Opcional
        </FieldBadge>
    </DescriptionComplement>
</TextField>
```

### Campo com prepend, append e ação de rodapé

```razor
<TextField Label="Site"
           @bind-Value="model.Site"
           Placeholder="minhaempresa">
    <Prepend>
        <FieldText>https://</FieldText>
    </Prepend>
    <Append>
        <FieldText>.com.br</FieldText>
    </Append>
    <FooterAction>
        <FieldAction Label="Testar URL"
                     Style="Themes.Secondary"
                     OnClick="TestUrlAsync" />
    </FooterAction>
</TextField>

@code {
    private Task TestUrlAsync()
    {
        return Task.CompletedTask;
    }
}
```

### Formulário com `EditForm`

```razor
<EditForm Model="model" OnValidSubmit="SaveAsync">
    <TextField Label="Nome" @bind-Value="model.Name" />
    <TextField Label="E-mail" @bind-Value="model.Email" BindEvent="oninput" />

    <div class="flex justify-end gap-3 mt-6">
        <Button Label="Cancelar" Style="Themes.Secondary" />
        <Button Label="Salvar" Style="Themes.Primary" Type="ButtonTypes.Submit" />
    </div>
</EditForm>

@code {
    private CustomerModel model = new();

    private Task SaveAsync()
    {
        return Task.CompletedTask;
    }
}
```

## Anti-padrões
- Não criar input manual quando `TextField` atende ao caso.
- Não usar classes de tamanho inventadas; use `Sizes`.
- Não colocar erro apenas em texto solto abaixo do campo quando `Error` resolve a semântica visual do campo.
- Não usar `Disabled` para dado apenas bloqueado para edição; prefira `ReadOnly` se o valor ainda deve participar da leitura normal da tela.
- Não assumir que `TextField` valida tipo numérico ou datas; ele é um campo string.
- Não declarar `FooterAction` como proibido sem verificar a implementação atual.

## Fontes
- `RoyalCode.Razor.Forms/Components/TextField.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor`
- `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/FieldBase.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/FieldBase'1.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/FieldGroup.razor`
- `RoyalCode.Razor.Forms/Components/FieldBadge.razor`
- `RoyalCode.Razor.Forms/Components/FieldAction.razor`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`
- `RoyalCode.Razor.Commons/Extensions/YasamenServiceCollectionExtensions.cs`
