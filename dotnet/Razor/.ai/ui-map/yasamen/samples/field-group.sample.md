# FieldGroup - Sample

## Visão geral
- **Propósito**: estrutura interna de label, informação, erro, prepend/control/append e footer de campo.
- **Complexidade**: 6
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP
- **Variações demonstradas**: uso indireto via `TextField` e estrutura direta avançada.

## Exemplos

### Uso recomendado via TextField

**Objetivo**: aproveitar `FieldGroup` sem consumir componente interno diretamente.

```razor
<TextField Label="Nome"
           @bind-Value="name"
           Information="Informe o nome completo."
           Error="@error">
    <Prepend><FieldText>#</FieldText></Prepend>
    <FooterAction><FieldAction Label="Validar" /></FooterAction>
</TextField>

@code {
    private string name = string.Empty;
    private string? error;
}
```

**Props usadas**: props de `TextField` repassadas ao grupo.  
**Eventos relevantes**: eventos do field.  
**Por que atende o pattern**: entrega grupo de campo completo com API pública.

### Uso direto avançado

**Objetivo**: compor controle custom mantendo shell de field.

```razor
<FieldGroup Label="Código" LabelFor="custom-code" Information="Código interno">
    <Control>
        <input id="custom-code" class="ya-input-field" @bind="code" />
    </Control>
</FieldGroup>

@code {
    private string code = string.Empty;
}
```

**Props usadas**: `Label`, `LabelFor`, `Information`, `Control`.  
**Eventos relevantes**: eventos do controle custom.  
**Por que atende o pattern**: permite reusar a estrutura visual de field quando não há componente pronto.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Label` | `string?` | rótulo | descrição principal |
| `Information` | `string?` | ajuda | texto auxiliar |
| `ErrorMessage` | `string?` | validação | mostra erro |
| `Prepend`/`Append` | `RenderFragment` | composição | prefixo/sufixo |
| `Control` | `RenderFragment` | uso direto | controle central |
| `FooterAction` | `RenderFragment` | ação local | comando contextual |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos ficam no controle |

## Limitações
- É interno/suporte; preferir `TextField` quando possível.

## Combinações frágeis
- Uso direto precisa garantir acessibilidade do controle.
