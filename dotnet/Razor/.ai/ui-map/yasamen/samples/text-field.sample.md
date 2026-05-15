# TextField - Sample

## Visão geral
- **Propósito**: campo textual com label, informação, erro, binding e slots de campo.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR, PP-FORM
- **Variações demonstradas**: binding, erro, senha, prepend/append, footer action.

## Exemplos

### UIP-INPUT-FORM_FIELD_GROUP

**Objetivo**: campo de formulário com validação visual.

```razor
<EditForm Model="model">
    <TextField Label="Nome"
               @bind-Value="model.Name"
               Information="Nome exibido no cadastro."
               Error="@nameError" />
</EditForm>

@code {
    private FormModel model = new();
    private string? nameError;
    private sealed class FormModel { public string Name { get; set; } = string.Empty; }
}
```

**Props usadas**: `Label`, `Value`, `Information`, `Error`.  
**Eventos relevantes**: `ValueChanged` pelo `@bind-Value`; `OnChange` disponível na base.  
**Por que atende o pattern**: agrupa rótulo, ajuda, valor e erro.

### UIP-INPUT-SEARCH_BAR

**Objetivo**: campo de busca textual com ação.

```razor
<TextField Label="Buscar" @bind-Value="query" Placeholder="Nome ou código">
    <Prepend><FieldText>#</FieldText></Prepend>
    <FooterAction>
        <FieldAction Label="Pesquisar" Style="Themes.Primary" OnClick="@Search" />
    </FooterAction>
</TextField>

@code {
    private string query = string.Empty;
    private Task Search(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Placeholder`, `Prepend`, `FooterAction`.  
**Eventos relevantes**: `FieldAction.OnClick`.  
**Por que atende o pattern**: captura termo e expõe comando de busca.

### Campo de senha

**Objetivo**: entrada textual protegida.

```razor
<TextField Label="Senha"
           Type="InputType.Password"
           @bind-Value="password"
           MaxLength="64" />

@code {
    private string password = string.Empty;
}
```

**Props usadas**: `Type`, `MaxLength`, `Value`.  
**Eventos relevantes**: binding.  
**Por que atende o pattern**: usa tipo suportado pela base de input.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Label` | `string?` | quase sempre | rótulo |
| `Value`/`ValueChanged` | `string?`/callback | binding | estado do campo |
| `Type` | `InputType` | texto ou senha | tipo HTML |
| `Information` | `string?` | ajuda | descrição |
| `Error` | `string?` | validação | estado inválido |
| `Prepend`/`Append` | `RenderFragment` | prefixo/sufixo | composição |
| `FooterAction` | `RenderFragment` | ação local | comando no campo |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `ValueChanged` | alteração de valor | binding |
| `OnChange` | mudança de valor | reação externa |

## Limitações
- `InputType` observado cobre `Text` e `Password`.
- Não cobre select, checkbox, textarea ou date picker.

## Combinações frágeis
- Não tratar `TextField` como date picker estruturado.
