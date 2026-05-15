# InputFieldBase - Sample

## Visão geral
- **Propósito**: base genérica interna para inputs com binding, tipo, maxlength e shell de field.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR, PP-FORM
- **Variações demonstradas**: uso via `TextField`, senha e evento de binding.

## Exemplos

### Uso recomendado via TextField

**Objetivo**: consumir a base por meio do componente público.

```razor
<TextField Label="Nome" @bind-Value="name" Placeholder="Digite seu nome" />

@code {
    private string name = string.Empty;
}
```

**Props usadas**: `Value`, `Placeholder`, `Label`.  
**Eventos relevantes**: `ValueChanged` via bind.  
**Por que atende o pattern**: usa binding e estrutura visual sem tocar a base.

### Tipo senha

**Objetivo**: usar tipo suportado pela base.

```razor
<TextField Label="Senha"
           Type="InputType.Password"
           @bind-Value="password"
           MaxLength="64" />

@code {
    private string password = string.Empty;
}
```

**Props usadas**: `Type`, `MaxLength`.  
**Eventos relevantes**: bind.  
**Por que atende o pattern**: muda o `type` HTML para senha.

### Bind por input

**Objetivo**: atualizar valor durante digitação.

```razor
<TextField Label="Busca"
           @bind-Value="query"
           BindEvent="oninput"
           Placeholder="Pesquisar..." />

@code {
    private string query = string.Empty;
}
```

**Props usadas**: `BindEvent`.  
**Eventos relevantes**: atualização via `oninput`.  
**Por que atende o pattern**: adequado para busca textual reativa.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Type` | `InputType` | texto/senha | tipo HTML |
| `MaxLength` | `int?` | limite de entrada | atributo maxlength |
| `BindEvent` | `string` | onchange/oninput | momento de atualização |
| props de `FieldBase` | várias | shell do field | label, erro, slots |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `ValueChanged` | valor muda | binding |
| `OnChange` | mudança | reação externa |

## Limitações
- Base interna; criar componentes especializados deve seguir seus contratos.

## Combinações frágeis
- `BindEvent="oninput"` em validações caras pode gerar excesso de processamento.
